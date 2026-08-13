from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import networkx as nx


# see: https://networkx.org/documentation/stable/auto_examples/drawing/plot_rainbow_coloring.html#sphx-glr-auto-examples-drawing-plot-rainbow-coloring-py

# A rainbow color mapping using matplotlib's tableau colors
node_dist_to_color = {
    1: "tab:red",
    2: "tab:orange",
    3: "tab:olive",
    4: "tab:green",
    5: "tab:blue",
    6: "tab:purple",
}

# Create a complete graph with an odd number of nodes
nnodes = 13
G = nx.complete_graph(nnodes)

# A graph with (2n + 1) nodes requires n colors for the edges
n = (nnodes - 1) // 2
ndist_iter = list(range(1, n + 1))

# Take advantage of circular symmetry in determining node distances
ndist_iter += ndist_iter[::-1]


def cycle(nlist, n):
    return nlist[-n:] + nlist[:-n]


def RainbowColoring(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'RainbowColoring'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 8
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 8
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    # Rotate nodes around the circle and assign colors for each edge based on
    # node distance
    nodes = list(G.nodes())
    for i, nd in enumerate(ndist_iter):
        for u, v in zip(nodes, cycle(nodes, i + 1)):
            G[u][v]["color"] = node_dist_to_color[nd]

    pos = nx.circular_layout(G)

    # Create a figure with 1:1 aspect ratio to preserve the circle.
    fig, ax = plt.subplots(figsize=(8, 8))

    node_opts = {"node_size": 500, "node_color": "w", "edgecolors": "k", 
        "linewidths": 2.0}
    nx.draw_networkx_nodes(G, pos, **node_opts)
    nx.draw_networkx_labels(G, pos, font_size=14)
    # Extract color from edge data
    edge_colors = [edgedata["color"] for _, _, edgedata in G.edges(data=True)]
    nx.draw_networkx_edges(G, pos, width=2.0, edge_color=edge_colors)

    ax.set_axis_off()
    #fig.tight_layout()

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
        RainbowColoring()


except Exception:
    import traceback
    print(traceback.format_exc())



