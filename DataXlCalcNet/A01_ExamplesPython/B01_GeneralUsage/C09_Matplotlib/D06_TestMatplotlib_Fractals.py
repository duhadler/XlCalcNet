
import numpy as np
import matplotlib.pyplot as plt

FPath = r"C:\Users\dietrichhadler\Documents\Jpg2D"

def demo_Sierpinski_carpet():
    """
    Sierpinski carpet
    https://en.wikipedia.org/wiki/Sierpi%C5%84ski_carpet
    https://medium.com/@mathcube7/visualizing-the-sierpinski-carpet-in-python-cec371847f3d
    """
    def sierpinski_carpet(depth):
        if depth == 0: return np.ones((1, 1))
        s = sierpinski_carpet(depth - 1)
        c = np.zeros_like(s)
        return np.block([[s, s, s], [s, c, s], [s, s, s]])

    n = 5
    fig, ax = plt.subplots(figsize=(6, 6))
    ax.set_aspect('equal')
    ax.set_axis_off()
    carpet = sierpinski_carpet(depth=n)
    plt.imshow(carpet, cmap='binary')

    fig.savefig(FPath + r'\Sierpinski_carpet.jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\Sierpinski_carpet.png', bbox_inches='tight')
    #plt.show()



def demo_Dragon_curve():
    """
    Dragon curve
    https://en.wikipedia.org/wiki/Dragon_curve
    """
    import random
    from math import sqrt, cos, sin, pi
    def f1(x, y): return (1 / sqrt(2)) * np.array([[cos(pi/4), -sin(pi/4)],
        [sin(pi/4), cos(pi/4)]]).dot(np.array([x, y]))

    def f2(x, y): return (1 / sqrt(2)) * np.array([[cos(3*pi/4), -sin(3*pi/4)],
        [sin(3*pi/4), cos(3*pi/4)]]).dot(np.array([x, y])) + np.array([1, 0])

    fig, ax = plt.subplots(figsize=(6, 6))
    n = 50000
    x, y = [0], [0]
    for _ in range(n):
        r = random.random()
        if r <= 0.5: dot = f1(x[-1], y[-1])
        else: dot = f2(x[-1], y[-1])
        x.append(dot[0])
        y.append(dot[1])
    plt.plot(x, y, '.', markersize=1, color='r')
    plt.title("Dragon curve")
    plt.tight_layout()

    fig.savefig(FPath + r'\SDragon_curve.jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\SDragon_curve.png', bbox_inches='tight')
    #plt.show()





def demo_Barnsley_fern():
    """
    Barnsley fern
    https://en.wikipedia.org/wiki/Barnsley_fern
    https://github.com/Quentin18/Matplotlib-fractals/tree/master
    """
    import random
    def f1(x, y): return np.array([[0, 0], [0, 0.16]]).dot(np.array([x, y]))

    def f2(x, y): return (np.array([[0.85, 0.04], [-0.04, 0.85]])
            .dot(np.array([x, y])) + np.array([0, 1.6]))

    def f3(x, y): return (np.array([[0.20, -0.26], [0.23, 0.22]])
            .dot(np.array([x, y])) + np.array([0, 1.6]))

    def f4(x, y): return (np.array([[-0.15, 0.28], [0.26, 0.24]])
            .dot(np.array([x, y])) + np.array([0, 0.44]))

    fig, ax = plt.subplots(figsize=(6, 6))
    n = 100000
    x, y = [0], [0]
    for _ in range(n):
        r = random.random()
        if r < 0.01: dot = f1(x[-1], y[-1])
        elif r < 0.86: dot = f2(x[-1], y[-1])
        elif r < 0.93: dot = f3(x[-1], y[-1])
        else: dot = f4(x[-1], y[-1])
        x.append(dot[0])
        y.append(dot[1])
    plt.plot(x, y, '.', markersize=2, color='g')
    plt.title("Barnsley fern")
    plt.tight_layout()

    fig.savefig(FPath + r'\Barnsley_fern.jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\Barnsley_fern.png', bbox_inches='tight')
    #plt.show()




def demo_newton():
    """
    Newton fractal
    https://stackoverflow.com/questions/17393592/how-do-i-speed-up-fractal-generation-with-numpy-arrays
    """
    def newton(i, guess):
        a = np.empty(guess.shape,dtype=int)
        a[:] = i
        j = np.abs(f(guess))>.00001
        if np.any(j):
            a[j] = newton(i+1, guess[j] - np.divide(f(guess[j]),fp(guess[j])))
        return a

    fig, ax = plt.subplots(figsize=(6, 6))
    f = np.poly1d([1,0,0,-1]) # x^3 - 1
    fp = np.polyder(f)
    npts = 1000
    x = np.linspace(-10,10,npts)
    y = np.linspace(-10,10,npts)
    xx, yy = np.meshgrid(x, y)
    pic = np.reshape(newton(0,np.ravel(xx+yy*1j)),[npts,npts])
    plt.imshow(pic)
    plt.show()

    fig.savefig(FPath + r'\newton.jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\newton.png', bbox_inches='tight')
    #plt.show()



def demo_Mandelbrot():
    """
    Mandelbrot set
    https://gist.github.com/jfpuget/60e07a82dece69b011bb
    """
    from matplotlib import colors

    def mandelbrot_image(xmin,xmax,ymin,ymax,width=6,height=6,maxiter=80,cmap='hot'):
        dpi = 96 * 1
        r1 = np.linspace(xmin, xmax, dpi * width, dtype=np.float32)
        r2 = np.linspace(ymin, ymax, dpi * height, dtype=np.float32)
        c = r1 + r2[:,None]*1j
        output = np.zeros(c.shape)
        z = np.zeros(c.shape, np.complex64)
        for it in range(maxiter):
            notdone = np.less(z.real*z.real + z.imag*z.imag, 4.0)
            output[notdone] = it
            z[notdone] = z[notdone]**2 + c[notdone]
        output[output == maxiter-1] = 0
        fig, ax = plt.subplots(figsize=(width, height))
        norm = colors.PowerNorm(0.3)
        ax.imshow(output,cmap=cmap,origin='lower',norm=norm)

        fig.savefig(FPath + r'\Mandelbrot.jpg', bbox_inches='tight')
##        fig.savefig(FPath + r'\Mandelbrot.png', bbox_inches='tight')
        #plt.show()

    mandelbrot_image(-2.0,0.5,-1.25,1.25,maxiter=80,cmap='gnuplot2')



def demo_julia_set():
    """
    Julia set
    https://www.rosettacode.org/wiki/Julia_set#Vectorized
    """
    def f(z): return z ** 2 + (-0.7 + 0.27015j)
    minc = -1.5 - 1j
    maxc = 1.5 + 1j
    width = 800 * 1
    height = 800 * 1
    iterations_count = 256
    threshold = 2.0

    im, re = np.ogrid[minc.imag: maxc.imag: height * 1j,
                      minc.real: maxc.real: width * 1j]
    z = (re + 1j * im).flatten()
    live = np.indices(z.shape)
    iterations = np.empty_like(z, dtype=int)

    for i in range(iterations_count):
        z_live = z[live] = f(z[live])
        escaped = abs(z_live) > threshold
        iterations[live[escaped]] = i
        live = live[~escaped]
        if live.size == 0: break
    else: iterations[live] = iterations_count

    fig, ax = plt.subplots(figsize=(6, 6))
    image = iterations.reshape((height, width))
    plt.axis('off')
    plt.imshow(image, cmap='nipy_spectral_r', origin='lower')

    fig.savefig(FPath + r'\julia_set.jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\julia_set.png', bbox_inches='tight')
    #plt.show()



#demo_Sierpinski_carpet()
#demo_Dragon_curve()
#demo_Barnsley_fern()

#demo_newton()
#demo_Mandelbrot()
demo_julia_set()

