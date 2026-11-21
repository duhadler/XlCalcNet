from xlcalcnet import gui
from pathlib import Path
import os
import itertools
import matplotlib.pyplot as plt
import networkx as nx


# see: https://networkx.org/documentation/stable/auto_examples/drawing/plot_multipartite_graph.html#sphx-glr-auto-examples-drawing-plot-multipartite-graph-py

def multilayered_graph(*subset_sizes):
    extents = nx.utils.pairwise(itertools.accumulate((0,) + subset_sizes))
    layers = [range(start, end) for start, end in extents]
    G = nx.Graph()
    for i, layer in enumerate(layers):
        G.add_nodes_from(layer, layer=i)
    for layer1, layer2 in nx.utils.pairwise(layers):
        G.add_edges_from(itertools.product(layer1, layer2))
    return G



def NetworkMultipartite(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'NetworkMultipartite'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 8
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    subset_sizes = [5, 5, 4, 3, 2, 4, 4, 3]
    subset_color = [
        "gold",
        "violet",
        "violet",
        "violet",
        "violet",
        "limegreen",
        "limegreen",
        "darkorange",
    ]
# End of custom key word arguments

    plt.style.use(PlotStyle)


    G = multilayered_graph(*subset_sizes)
    color = [subset_color[data["layer"]] for v, data in G.nodes(data=True)]
    pos = nx.multipartite_layout(G, subset_key="layer")

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    fig.tight_layout()


#    plt.figure(figsize=(FigSizeX, FigSizeY))
    nx.draw(G, pos, node_color=color, with_labels=True)

    #ax.axis('equal')    # uncomment as needed
    ax.set_title(Title)

# Start of output choices
    if (OutputMode == 'plt'):
        plt.show()
    elif (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = (Path(__file__).stem)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName + '.' + OutputMode])
        plt.savefig(FullPath,  bbox_inches='tight')
        if OutputDir != 'Temp': print('Graphics written to: ', FullPath)
    plt.close('all')


try:
    if __name__ == '__main__':
        NetworkMultipartite()


except Exception:
    import traceback
    print(traceback.format_exc())





