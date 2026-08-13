

import numpy as np
import matplotlib.pyplot as plt
from matplotlib.tri import Triangulation
import matplotlib.ticker as ticker



outpath = r"C:\Users\dietrichhadler\Documents\Python310\Lib\site-packages\xlfunlab\Test"




def polygon_3d():

    from matplotlib.collections import PolyCollection
    from scipy.stats import poisson

    # Fixing random state for reproducibility
    np.random.seed(19680801)


    def polygon_under_graph(x, y):
        """
        Construct the vertex list which defines the polygon filling the space under
        the (x, y) line graph. This assumes x is in ascending order.
        """
        return [(x[0], 0.), *zip(x, y), (x[-1], 0.)]


    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    x = np.linspace(0., 10., 31)
    lambdas = range(1, 9)

    # verts[i] is a list of (x, y) pairs defining polygon i.
    verts = [polygon_under_graph(x, poisson.pmf(l, x)) for l in lambdas]
    facecolors = plt.colormaps['viridis_r'](np.linspace(0, 1, len(verts)))

    poly = PolyCollection(verts, facecolors=facecolors, alpha=.7)
    ax.add_collection3d(poly, zs=lambdas, zdir='y')

    ax.set(xlim=(0, 10), ylim=(1, 9), zlim=(0, 0.35),
           xlabel='x', ylabel=r'$\lambda$', zlabel='probability')

    plt.show()
##    fig.savefig(outpath + r'\polygon_3d.svg', bbox_inches='tight')
##    print('saved polygon_3d.svg')
##    fig.savefig(outpath + r'\polygon_3d.pdf', bbox_inches='tight')
##    print('saved polygon_3d.pdf')
##    fig.savefig(outpath + r'\polygon_3d.png', bbox_inches='tight')
##    print('saved polygon_3d.png')




def surface_moebius():
    import matplotlib.tri as mtri

    fig = plt.figure(figsize=plt.figaspect(0.5))

    # ==========
    # First plot
    # ==========

    # Make a mesh in the space of parameterisation variables u and v
    u = np.linspace(0, 2.0 * np.pi, endpoint=True, num=50)
    v = np.linspace(-0.5, 0.5, endpoint=True, num=10)
    u, v = np.meshgrid(u, v)
    u, v = u.flatten(), v.flatten()

    # This is the Mobius mapping, taking a u, v pair and returning an x, y, z
    # triple
    x = (1 + 0.5 * v * np.cos(u / 2.0)) * np.cos(u)
    y = (1 + 0.5 * v * np.cos(u / 2.0)) * np.sin(u)
    z = 0.5 * v * np.sin(u / 2.0)

    # Triangulate parameter space to determine the triangles
    tri = mtri.Triangulation(u, v)

    # Plot the surface.  The triangles in parameter space determine which x, y, z
    # points are connected by an edge.
    ax = fig.add_subplot(1, 2, 1, projection='3d')
    ax.plot_trisurf(x, y, z, triangles=tri.triangles, cmap=plt.cm.Spectral)
    ax.set_zlim(-1, 1)


    # ===========
    # Second plot
    # ===========

    # Make parameter spaces radii and angles.
    n_angles = 36
    n_radii = 8
    min_radius = 0.25
    radii = np.linspace(min_radius, 0.95, n_radii)

    angles = np.linspace(0, 2*np.pi, n_angles, endpoint=False)
    angles = np.repeat(angles[..., np.newaxis], n_radii, axis=1)
    angles[:, 1::2] += np.pi/n_angles

    # Map radius, angle pairs to x, y, z points.
    x = (radii*np.cos(angles)).flatten()
    y = (radii*np.sin(angles)).flatten()
    z = (np.cos(radii)*np.cos(3*angles)).flatten()

    # Create the Triangulation; no triangles so Delaunay triangulation created.
    triang = mtri.Triangulation(x, y)

    # Mask off unwanted triangles.
    xmid = x[triang.triangles].mean(axis=1)
    ymid = y[triang.triangles].mean(axis=1)
    mask = xmid**2 + ymid**2 < min_radius**2
    triang.set_mask(mask)

    # Plot the surface.
    ax = fig.add_subplot(1, 2, 2, projection='3d')
    ax.plot_trisurf(triang, z, cmap=plt.cm.CMRmap)

    plt.show()
##    fig.savefig(outpath + r'\surface_moebius.svg', bbox_inches='tight')
##    print('saved surface_moebius.svg')
##    fig.savefig(outpath + r'\surface_moebius.pdf', bbox_inches='tight')
##    print('saved surface_moebius.pdf')
##    fig.savefig(outpath + r'\surface_moebius.png', bbox_inches='tight')
##    print('saved surface_moebius.png')




def voxel_3d():

    # prepare some coordinates
    x, y, z = np.indices((8, 8, 8))

    # draw cuboids in the top left and bottom right corners, and a link between
    # them
    cube1 = (x < 3) & (y < 3) & (z < 3)
    cube2 = (x >= 5) & (y >= 5) & (z >= 5)
    link = abs(x - y) + abs(y - z) + abs(z - x) <= 2

    # combine the objects into a single boolean array
    voxelarray = cube1 | cube2 | link

    # set the colors of each object
    colors = np.empty(voxelarray.shape, dtype=object)
    colors[link] = 'red'
    colors[cube1] = 'blue'
    colors[cube2] = 'green'

    # and plot everything
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(voxelarray, facecolors=colors, edgecolor='k')

    plt.show()
##    fig.savefig(outpath + r'\voxel_3d.svg', bbox_inches='tight')
##    print('saved voxel_3d.svg')
##    fig.savefig(outpath + r'\voxel_3d.pdf', bbox_inches='tight')
##    print('saved voxel_3d.pdf')
##    fig.savefig(outpath + r'\voxel_3d.png', bbox_inches='tight')
##    print('saved voxel_3d.png')


def voxel_3d_numpy():

    def explode(data):
        size = np.array(data.shape)*2
        data_e = np.zeros(size - 1, dtype=data.dtype)
        data_e[::2, ::2, ::2] = data
        return data_e

    # build up the numpy logo
    n_voxels = np.zeros((4, 3, 4), dtype=bool)
    n_voxels[0, 0, :] = True
    n_voxels[-1, 0, :] = True
    n_voxels[1, 0, 2] = True
    n_voxels[2, 0, 1] = True
    facecolors = np.where(n_voxels, '#FFD65DC0', '#7A88CCC0')
    edgecolors = np.where(n_voxels, '#BFAB6E', '#7D84A6')
    filled = np.ones(n_voxels.shape)

    # upscale the above voxel image, leaving gaps
    filled_2 = explode(filled)
    fcolors_2 = explode(facecolors)
    ecolors_2 = explode(edgecolors)

    # Shrink the gaps
    x, y, z = np.indices(np.array(filled_2.shape) + 1).astype(float) // 2
    x[0::2, :, :] += 0.05
    y[:, 0::2, :] += 0.05
    z[:, :, 0::2] += 0.05
    x[1::2, :, :] += 0.95
    y[:, 1::2, :] += 0.95
    z[:, :, 1::2] += 0.95

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(x, y, z, filled_2, facecolors=fcolors_2, edgecolors=ecolors_2)

    plt.show()
##    fig.savefig(outpath + r'\voxel_3d_numpy.svg', bbox_inches='tight')
##    print('saved voxel_3d_numpy.svg')
##    fig.savefig(outpath + r'\voxel_3d_numpy.pdf', bbox_inches='tight')
##    print('saved voxel_3d_numpy.pdf')
##    fig.savefig(outpath + r'\voxel_3d_numpy.png', bbox_inches='tight')
##    print('saved voxel_3d_numpy.png')


def voxel_3d_rgb():

    def midpoints(x):
        sl = ()
        for i in range(x.ndim):
            x = (x[sl + np.index_exp[:-1]] + x[sl + np.index_exp[1:]]) / 2.0
            sl += np.index_exp[:]
        return x

    # prepare some coordinates, and attach rgb values to each
    r, g, b = np.indices((17, 17, 17)) / 16.0
    rc = midpoints(r)
    gc = midpoints(g)
    bc = midpoints(b)

    # define a sphere about [0.5, 0.5, 0.5]
    sphere = (rc - 0.5)**2 + (gc - 0.5)**2 + (bc - 0.5)**2 < 0.5**2

    # combine the color components
    colors = np.zeros(sphere.shape + (3,))
    colors[..., 0] = rc
    colors[..., 1] = gc
    colors[..., 2] = bc

    # and plot everything
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(r, g, b, sphere,
              facecolors=colors,
              edgecolors=np.clip(2*colors - 0.5, 0, 1),  # brighter
              linewidth=0.5)
    ax.set(xlabel='r', ylabel='g', zlabel='b')

    plt.show()
##    fig.savefig(outpath + r'\voxel_3d_rgb.svg', bbox_inches='tight')
##    print('saved voxel_3d_rgb.svg')
##    fig.savefig(outpath + r'\voxel_3d_rgb.pdf', bbox_inches='tight')
##    print('saved voxel_3d_rgb.pdf')
##    fig.savefig(outpath + r'\voxel_3d_rgb.png', bbox_inches='tight')
##    print('saved voxel_3d_rgb.png')


def voxel_3d_cylindric():

    import matplotlib.colors

    def midpoints(x):
        sl = ()
        for i in range(x.ndim):
            x = (x[sl + np.index_exp[:-1]] + x[sl + np.index_exp[1:]]) / 2.0
            sl += np.index_exp[:]
        return x

    # prepare some coordinates, and attach rgb values to each
    r, theta, z = np.mgrid[0:1:11j, 0:np.pi*2:25j, -0.5:0.5:11j]
    x = r*np.cos(theta)
    y = r*np.sin(theta)

    rc, thetac, zc = midpoints(r), midpoints(theta), midpoints(z)

    # define a wobbly torus about [0.7, *, 0]
    sphere = (rc - 0.7)**2 + (zc + 0.2*np.cos(thetac*2))**2 < 0.2**2

    # combine the color components
    hsv = np.zeros(sphere.shape + (3,))
    hsv[..., 0] = thetac / (np.pi*2)
    hsv[..., 1] = rc
    hsv[..., 2] = zc + 0.5
    colors = matplotlib.colors.hsv_to_rgb(hsv)

    # and plot everything
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(x, y, z, sphere,
              facecolors=colors,
              edgecolors=np.clip(2*colors - 0.5, 0, 1),  # brighter
              linewidth=0.5)

    plt.show()
##    fig.savefig(outpath + r'\voxel_3d_cylindric.svg', bbox_inches='tight')
##    print('saved voxel_3d_cylindric.svg')
##    fig.savefig(outpath + r'\voxel_3d_cylindric.pdf', bbox_inches='tight')
##    print('saved voxel_3d_cylindric.pdf')
##    fig.savefig(outpath + r'\voxel_3d_cylindric.png', bbox_inches='tight')
##    print('saved voxel_3d_cylindric.png')


def wireframe_3d_1direction():
    from mpl_toolkits.mplot3d import axes3d

    fig, (ax1, ax2) = plt.subplots(
        2, 1, figsize=(8, 12), subplot_kw={'projection': '3d'})

    # Get the test data
    X, Y, Z = axes3d.get_test_data(0.01)

    # Give the first plot only wireframes of the type y = c
    ax1.plot_wireframe(X, Y, Z, rstride=10, cstride=0)
    ax1.set_title("Column (x) stride set to 0")

    # Give the second plot only wireframes of the type x = c
    ax2.plot_wireframe(X, Y, Z, rstride=0, cstride=10)
    ax2.set_title("Row (y) stride set to 0")

    plt.tight_layout()

    plt.show()
##    fig.savefig(outpath + r'\wireframe_3d_1direction.svg', bbox_inches='tight')
##    print('saved wireframe_3d_1direction.svg')
##    fig.savefig(outpath + r'\wireframe_3d_1direction.pdf', bbox_inches='tight')
##    print('saved wireframe_3d_1direction.pdf')
##    fig.savefig(outpath + r'\wireframe_3d_1direction.png', bbox_inches='tight')
##    print('saved wireframe_3d_1direction.png')



def wireframe_3d():
    from mpl_toolkits.mplot3d import axes3d

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Grab some test data.
    X, Y, Z = axes3d.get_test_data(0.02)

    # Plot a basic wireframe.
    ax.plot_wireframe(X, Y, Z, rstride=10, cstride=10)

    plt.show()
##    fig.savefig(outpath + r'\wireframe_3d.svg', bbox_inches='tight')
##    print('saved wireframe_3d.svg')
##    fig.savefig(outpath + r'\wireframe_3d.pdf', bbox_inches='tight')
##    print('saved wireframe_3d.pdf')
##    fig.savefig(outpath + r'\wireframe_3d.png', bbox_inches='tight')
##    print('saved wireframe_3d.png')








def surface_triangular():
    n_radii = 8
    n_angles = 36

    # Make radii and angles spaces (radius r=0 omitted to eliminate duplication).
    radii = np.linspace(0.125, 1.0, n_radii)
    angles = np.linspace(0, 2*np.pi, n_angles, endpoint=False)[..., np.newaxis]

    # Convert polar (radii, angles) coords to cartesian (x, y) coords.
    # (0, 0) is manually added at this stage,  so there will be no duplicate
    # points in the (x, y) plane.
    x = np.append(0, (radii*np.cos(angles)).flatten())
    y = np.append(0, (radii*np.sin(angles)).flatten())

    # Compute z to make the pringle surface.
    z = np.sin(-x*y)

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    ax.plot_trisurf(x, y, z, linewidth=0.2, antialiased=True)

    #plt.show()
    fig.savefig(outpath + r'\surface_triangular.svg', bbox_inches='tight')
    print('saved surface_triangular.svg')
    fig.savefig(outpath + r'\surface_triangular.pdf', bbox_inches='tight')
    print('saved surface_triangular.pdf')
    fig.savefig(outpath + r'\surface_triangular.png', bbox_inches='tight')
    print('saved surface_triangular.png')




def demo_moebius_1():
    theta = np.linspace(0, 2 * np.pi, 30)
    w = np.linspace(-0.25, 0.25, 8)
    w, theta = np.meshgrid(w, theta)
    phi = 0.5 * theta

    # radius in x-y plane
    r = 1 + w * np.cos(phi)
    x = np.ravel(r * np.cos(theta))
    y = np.ravel(r * np.sin(theta))
    z = np.ravel(w * np.sin(phi))


    fig = plt.figure()
    # triangulate in the underlying parametrization
    tri = Triangulation(np.ravel(w), np.ravel(theta))

    ax = plt.axes(projection='3d')
    ax.plot_trisurf(x, y, z, triangles=tri.triangles,
                    cmap='viridis', linewidths=0.2);


    ax.xaxis.set_major_locator(ticker.MultipleLocator(0.5))
    ax.yaxis.set_major_locator(ticker.MultipleLocator(0.5))
    ax.zaxis.set_major_locator(ticker.MultipleLocator(0.3))

    ax.set_xlim(-1, 1); ax.set_ylim(-1, 1); ax.set_zlim(-0.3, 0.3);
    #ax.set_xlim(-1, 1); ax.set_ylim(-1, 1); ax.set_zlim(-1, 1);

    ax.set_box_aspect([1.0, 1.0, 1.0])


    #plt.show()
    fig.savefig(outpath + r'\moebius.svg', bbox_inches='tight')
    print('saved moebius.svg')
    fig.savefig(outpath + r'\moebius.pdf', bbox_inches='tight')
    print('saved moebius.pdf')
    fig.savefig(outpath + r'\moebius.png', bbox_inches='tight')
    print('saved moebius.png')


def surface_colormap():
    from matplotlib import cm
    from matplotlib.ticker import LinearLocator

    fig, ax = plt.subplots(subplot_kw={"projection": "3d"})

    # Make data.
    X = np.arange(-5, 5, 0.25)
    Y = np.arange(-5, 5, 0.25)
    X, Y = np.meshgrid(X, Y)
    R = np.sqrt(X**2 + Y**2)
    Z = np.sin(R)

    # Plot the surface.
    surf = ax.plot_surface(X, Y, Z, cmap=cm.coolwarm,
                           linewidth=0, antialiased=False)

    # Customize the z axis.
    ax.set_zlim(-1.0, 1.0)
    ax.zaxis.set_major_locator(LinearLocator(3))
    # A StrMethodFormatter is used automatically
    #ax.zaxis.set_major_formatter('{x:.02f}')

    # Add a color bar which maps values to colors.
    #fig.colorbar(surf, shrink=0.5, aspect=5)

    #plt.show()
    fig.savefig(outpath + r'\surface_colormap.svg', bbox_inches='tight')
    print('saved surface_colormap.svg')
    fig.savefig(outpath + r'\surface_colormap.pdf', bbox_inches='tight')
    print('saved surface_colormap.pdf')
    fig.savefig(outpath + r'\surface_colormap.png', bbox_inches='tight')
    print('saved surface_colormap.png')



def surface_hillshading():
    from matplotlib import cbook
    from matplotlib import cm
    from matplotlib.colors import LightSource

    # Load and format data
    dem = cbook.get_sample_data('jacksboro_fault_dem.npz', np_load=True)
    z = dem['elevation']
    nrows, ncols = z.shape
    x = np.linspace(dem['xmin'], dem['xmax'], ncols)
    y = np.linspace(dem['ymin'], dem['ymax'], nrows)
    x, y = np.meshgrid(x, y)

    region = np.s_[5:50, 5:50]
    x, y, z = x[region], y[region], z[region]

    # Set up plot
    fig, ax = plt.subplots(subplot_kw=dict(projection='3d'))

    ls = LightSource(270, 45)
    # To use a custom hillshading mode, override the built-in shading and pass
    # in the rgb colors of the shaded surface calculated from "shade".
    rgb = ls.shade(z, cmap=cm.gist_earth, vert_exag=0.1, blend_mode='soft')
    surf = ax.plot_surface(x, y, z, rstride=1, cstride=1, facecolors=rgb,
                           linewidth=0, antialiased=False, shade=False)

    #plt.show()
    fig.savefig(outpath + r'\surface_hillshading.svg', bbox_inches='tight')
    print('saved surface_colormap.svg')
    fig.savefig(outpath + r'\surface_hillshading.pdf', bbox_inches='tight')
    print('saved surface_colormap.pdf')
    fig.savefig(outpath + r'\surface_hillshading.png', bbox_inches='tight')
    print('saved surface_hillshading.png')




def surface_polar():
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Create the mesh in polar coordinates and compute corresponding Z.
    r = np.linspace(0, 1.25, 50)
    p = np.linspace(0, 2*np.pi, 50)
    R, P = np.meshgrid(r, p)
    Z = ((R**2 - 1)**2)

    # Express the mesh in the cartesian system.
    X, Y = R*np.cos(P), R*np.sin(P)

    # Plot the surface.
    ax.plot_surface(X, Y, Z, cmap=plt.cm.YlGnBu_r)

    # Tweak the limits and add latex math labels.
    ax.set_zlim(0, 1)
    ax.set_xlabel(r'$\phi_\mathrm{real}$')
    ax.set_ylabel(r'$\phi_\mathrm{im}$')
    ax.set_zlabel(r'$V(\phi)$')

    #plt.show()
    fig.savefig(outpath + r'\surface_polar.svg', bbox_inches='tight')
    print('saved surface_polar.svg')
    fig.savefig(outpath + r'\surface_polar.pdf', bbox_inches='tight')
    print('saved surface_polar.pdf')
    fig.savefig(outpath + r'\surface_polar.png', bbox_inches='tight')
    print('saved surface_polar.png')



def surface_checkerboard():
    from matplotlib.ticker import LinearLocator
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Make data.
    X = np.arange(-5, 5, 0.25)
    xlen = len(X)
    Y = np.arange(-5, 5, 0.25)
    ylen = len(Y)
    X, Y = np.meshgrid(X, Y)
    R = np.sqrt(X**2 + Y**2)
    Z = np.sin(R)

    # Create an empty array of strings with the same shape as the meshgrid, and
    # populate it with two colors in a checkerboard pattern.
    colortuple = ('y', 'b')
    colors = np.empty(X.shape, dtype=str)
    for y in range(ylen):
        for x in range(xlen):
            colors[y, x] = colortuple[(x + y) % len(colortuple)]

    # Plot the surface with face colors taken from the array we made.
    surf = ax.plot_surface(X, Y, Z, facecolors=colors, linewidth=0)

    # Customize the z axis.
    ax.set_zlim(-1, 1)
    ax.zaxis.set_major_locator(LinearLocator(6))

    #plt.show()
    fig.savefig(outpath + r'\surface_checkerboard.svg', bbox_inches='tight')
    print('saved surface_checkerboard.svg')
    fig.savefig(outpath + r'\surface_checkerboard.pdf', bbox_inches='tight')
    print('saved surface_checkerboard.pdf')
    fig.savefig(outpath + r'\surface_checkerboard.png', bbox_inches='tight')
    print('saved surface_checkerboard.png')




def surface_solid():

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Make data
    u = np.linspace(0, 2 * np.pi, 100)
    v = np.linspace(0, np.pi, 100)
    x = 10 * np.outer(np.cos(u), np.sin(v))
    y = 10 * np.outer(np.sin(u), np.sin(v))
    z = 10 * np.outer(np.ones(np.size(u)), np.cos(v))

    # Plot the surface
    ax.plot_surface(x, y, z)

    #plt.show()
    fig.savefig(outpath + r'\surface_solid.svg', bbox_inches='tight')
    print('saved surface_solid.svg')
    fig.savefig(outpath + r'\surface_solid.pdf', bbox_inches='tight')
    print('saved surface_solid.pdf')
    fig.savefig(outpath + r'\surface_solid.png', bbox_inches='tight')
    print('saved surface_solid.png')



def stem_3d():

    theta = np.linspace(0, 2*np.pi)
    x = np.cos(theta - np.pi/2)
    y = np.sin(theta - np.pi/2)
    z = theta

    fig, ax = plt.subplots(subplot_kw=dict(projection='3d'))
    ax.stem(x, y, z)

    #plt.show()
    fig.savefig(outpath + r'\stem_3d.svg', bbox_inches='tight')
    print('saved stem_3d.svg')
    fig.savefig(outpath + r'\stem_3d.pdf', bbox_inches='tight')
    print('saved stem_3d.pdf')
    fig.savefig(outpath + r'\stem_3d.png', bbox_inches='tight')
    print('saved stem_3d.png')





# See also: https://matplotlib.org/stable/gallery/mplot3d/scatter3d.html#sphx-glr-gallery-mplot3d-scatter3d-py
def scatter3d():

    # Fixing random state for reproducibility
    np.random.seed(19680801)

    def randrange(n, vmin, vmax):
        """
        Helper function to make an array of random numbers having shape (n, )
        with each number distributed Uniform(vmin, vmax).
        """
        return (vmax - vmin)*np.random.rand(n) + vmin

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    n = 100

    # For each set of style and range settings, plot n random points in the box
    # defined by x in [23, 32], y in [0, 100], z in [zlow, zhigh].
    for m, zlow, zhigh in [('o', -50, -25), ('^', -30, -5)]:
        xs = randrange(n, 23, 32)
        ys = randrange(n, 0, 100)
        zs = randrange(n, zlow, zhigh)
        ax.scatter(xs, ys, zs, marker=m)

    ax.set_xlabel('X Label')
    ax.set_ylabel('Y Label')
    ax.set_zlabel('Z Label')

    #plt.show()
    plt.savefig(outpath + r'\scatter3d.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\scatter3d.pdf', bbox_inches='tight')




# See also: https://matplotlib.org/stable/gallery/mplot3d/lines3d.html#sphx-glr-gallery-mplot3d-lines3d-py
def lines3d():

    ax = plt.figure().add_subplot(projection='3d')

    # Prepare arrays x, y, z
    theta = np.linspace(-4 * np.pi, 4 * np.pi, 100)
    z = np.linspace(-2, 2, 100)
    r = z**2 + 1
    x = r * np.sin(theta)
    y = r * np.cos(theta)

    ax.plot(x, y, z, label='parametric curve')
    ax.legend()

    #plt.show()
    plt.savefig(outpath + r'\lines3d.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\lines3d.pdf', bbox_inches='tight')



# See also: https://matplotlib.org/stable/gallery/mplot3d/contourf3d_2.html#sphx-glr-gallery-mplot3d-contourf3d-2-py
def contourf3d():

    from mpl_toolkits.mplot3d import axes3d

    ax = plt.figure().add_subplot(projection='3d')
    X, Y, Z = axes3d.get_test_data(0.05)

    # Plot the 3D surface
    ax.plot_surface(X, Y, Z, edgecolor='royalblue', lw=0.5, rstride=8, cstride=8,
                    alpha=0.3)

    # Plot projections of the contours for each dimension.  By choosing offsets
    # that match the appropriate axes limits, the projected contours will sit on
    # the 'walls' of the graph
    ax.contourf(X, Y, Z, zdir='z', offset=-100, cmap='coolwarm')
    ax.contourf(X, Y, Z, zdir='x', offset=-40, cmap='coolwarm')
    ax.contourf(X, Y, Z, zdir='y', offset=40, cmap='coolwarm')

    ax.set(xlim=(-40, 40), ylim=(-40, 40), zlim=(-100, 100),
           xlabel='X', ylabel='Y', zlabel='Z')

    #plt.show()
    plt.savefig(outpath + r'\contourf3d.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\contourf3d.pdf', bbox_inches='tight')



# See also: https://matplotlib.org/stable/gallery/mplot3d/contour3d_3.html#sphx-glr-gallery-mplot3d-contour3d-3-py
def contour3d():

    from mpl_toolkits.mplot3d import axes3d

    ax = plt.figure().add_subplot(projection='3d')
    X, Y, Z = axes3d.get_test_data(0.05)

    # Plot the 3D surface
    ax.plot_surface(X, Y, Z, edgecolor='royalblue', lw=0.5, rstride=8, cstride=8,
                    alpha=0.3)

    # Plot projections of the contours for each dimension.  By choosing offsets
    # that match the appropriate axes limits, the projected contours will sit on
    # the 'walls' of the graph.
    ax.contour(X, Y, Z, zdir='z', offset=-100, cmap='coolwarm')
    ax.contour(X, Y, Z, zdir='x', offset=-40, cmap='coolwarm')
    ax.contour(X, Y, Z, zdir='y', offset=40, cmap='coolwarm')

    ax.set(xlim=(-40, 40), ylim=(-40, 40), zlim=(-100, 100),
           xlabel='X', ylabel='Y', zlabel='Z')

    #plt.show()
    plt.savefig(outpath + r'\contour3d.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\contour3d.pdf', bbox_inches='tight')



# See also: https://jakevdp.github.io/PythonDataScienceHandbook/04.12-three-dimensional-plotting.html
def scatter3d_jakevdp():

    ax = plt.axes(projection='3d')

    # Data for a three-dimensional line
    zline = np.linspace(0, 15, 1000)
    xline = np.sin(zline)
    yline = np.cos(zline)
    ax.plot3D(xline, yline, zline, 'gray')

    # Data for three-dimensional scattered points
    zdata = 15 * np.random.random(100)
    xdata = np.sin(zdata) + 0.1 * np.random.randn(100)
    ydata = np.cos(zdata) + 0.1 * np.random.randn(100)
    ax.scatter3D(xdata, ydata, zdata, c=zdata, cmap='Greens');
    #plt.show()
    plt.savefig(outpath + r'\scatter3d_jakevdp.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\scatter3d_jakevdp.pdf', bbox_inches='tight')




# See also: https://jakevdp.github.io/PythonDataScienceHandbook/04.12-three-dimensional-plotting.html
def contour3D_jakevdp():

    def f(x, y):
        return np.sin(np.sqrt(x ** 2 + y ** 2))

    x = np.linspace(-6, 6, 30)
    y = np.linspace(-6, 6, 30)

    X, Y = np.meshgrid(x, y)
    Z = f(X, Y)

    fig = plt.figure()
    ax = plt.axes(projection='3d')
    ax.contour3D(X, Y, Z, 50, cmap='binary')
    ax.set_xlabel('x')
    ax.set_ylabel('y')
    ax.set_zlabel('z');
    #plt.show()
    plt.savefig(outpath + r'\contour3D_jakevdp.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\contour3D_jakevdp.pdf', bbox_inches='tight')


# See also: https://stackoverflow.com/questions/12287946/python-3d-plot-of-a-klein-bottle
def kleinbottle():

    cos = np.cos
    sin = np.sin
    sqrt = np.sqrt
    pi = np.pi

    def kleinsurface(u, v):
        """
        http://paulbourke.net/geometry/klein/
        """
        half = (0 <= u) & (u < pi)
        r = 4*(1 - cos(u)/2)
        x = 6*cos(u)*(1 + sin(u)) + r*cos(v + pi)
        x[half] = ( (6*cos(u)*(1 + sin(u)) + r*cos(u)*cos(v))[half])
        y = 16 * sin(u)
        y[half] = (16*sin(u) + r*sin(u)*cos(v))[half]
        z = r * sin(v)
        return x, y, z

    u, v = np.linspace(0, 2*pi, 40), np.linspace(0, 2*pi, 40)
    ux, vx =  np.meshgrid(u,v)
    x, y, z = kleinsurface(ux, vx)

    fig = plt.figure()
    ax = plt.axes(projection='3d')
    plot = ax.plot_surface(x, y, z, rstride = 1, cstride = 1, cmap = plt.get_cmap('jet'),
                           linewidth = 0, antialiased = True)
    plt.show()
##    plt.savefig(outpath + r'\kleinbottle.svg', bbox_inches='tight')
##    plt.savefig(outpath + r'\kleinbottle.pdf', bbox_inches='tight')



#scatter3d_jakevdp()
#contour3D_jakevdp()

#kleinbottle()

##scatter3d()
##lines3d()
##contourf3d()
##contour3d()


#polygon_3d()
#surface_moebius()
#voxel_3d()
#voxel_3d_numpy()
#voxel_3d_rgb()
#voxel_3d_cylindric()
#wireframe_3d_1direction()
#wireframe_3d()
#surface_solid()
#surface_checkerboard()



surface_colormap()
#surface_hillshading()
#surface_polar()
#stem_3d()
#demo_moebius_1()
#surface_triangular()




