
# see: https://networkx.org/documentation/stable/auto_examples/drawing/plot_tsp.html#sphx-glr-auto-examples-drawing-plot-tsp-py

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import networkx as nx
import networkx.algorithms.approximation as nx_app
import math


# see: https://networkx.org/documentation/stable/auto_examples/drawing/plot_multipartite_graph.html#sphx-glr-auto-examples-drawing-plot-multipartite-graph-py

def TravellingSalesman(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'TravellingSalesman'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
    # End of standard key word arguments

    G = nx.random_geometric_graph(20, radius=0.4, seed=3)
    pos = nx.get_node_attributes(G, "pos")

    # Depot should be at (0,0)
    pos[0] = (0.5, 0.5)

    H = G.copy()

    # Calculating the distances between the nodes as edge's weight.
    for i in range(len(pos)):
        for j in range(i + 1, len(pos)):
            dist = math.hypot(pos[i][0] - pos[j][0], pos[i][1] - pos[j][1])
            dist = dist
            G.add_edge(i, j, weight=dist)

    cycle = nx_app.christofides(G, weight="weight")
    edge_list = list(nx.utils.pairwise(cycle))
    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))

    # Draw closest edges on each node only
    nx.draw_networkx_edges(H, pos, edge_color="blue", width=0.5)

    # Draw the route
    nx.draw_networkx(
        G,
        pos,
        with_labels=True,
        edgelist=edge_list,
        edge_color="red",
        node_size=200,
        width=3,
    )

    print("The route of the traveller is:", cycle)
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
        TravellingSalesman()


except Exception:
    import traceback
    print(traceback.format_exc())



