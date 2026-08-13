from xlcalcnet import gui
from pathlib import Path
import os
import networkx as nx
import pandas as pd
import matplotlib.pyplot as plt

# see: https://networkx.org/documentation/stable/auto_examples/graph/plot_napoleon_russian_campaign.html#sphx-glr-auto-examples-graph-plot-napoleon-russian-campaign-py


# function to create node colour list
def create_community_node_colors(graph, communities):
    number_of_colors = len(communities)
    colors = ["#D4FCB1", "#CDC5FC", "#FFC2C4", "#F2D140", "#BCC6C8"][:number_of_colors]
    node_colors = []
    for node in graph:
        current_community_index = 0
        for community in communities:
            if node in community:
                node_colors.append(colors[current_community_index])
                break
            current_community_index += 1
    return node_colors


# function to plot graph with node colouring based on communities
def visualize_communities(graph, communities, i):
    node_colors = create_community_node_colors(graph, communities)
    modularity = round(nx.community.modularity(graph, communities), 6)
    title = f"Community Visualization of {len(communities)} communities with modularity of {modularity}"
    pos = nx.spring_layout(graph, k=0.3, iterations=50, seed=2)
    plt.subplot(2, 1, i)
    plt.title(title)
    nx.draw(
        graph,
        pos=pos,
        #node_size=800,
        node_size=500,
        node_color=node_colors,
        with_labels=True,
        #font_size=15,
        font_color="black",
    )



def CommunityVisualization(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CommunityVisualization'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 7
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 7
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    #Community Visualization of 2 communities with modularity of 0.34766, 
    #Community Visualization of 5 communities with modularity of 0.384972, 
    #Modularity Trend for Girvan-Newman Community Detection

    # Load karate graph and find communities using Girvan-Newman
    G = nx.karate_club_graph()
    communities = list(nx.community.girvan_newman(G))

    # Modularity -> measures the strength of division of a network into modules
    #modularity_df = pd.DataFrame(
    #    [
    #        [k + 1, nx.community.modularity(G, communities[k])]
    #        for k in range(len(communities))
    #    ],
    #    columns=["k", "modularity"],
    #)


    fig, ax = plt.subplots(2, figsize=(FigSizeX, FigSizeY))

    # Plot graph with colouring based on communities
    visualize_communities(G, communities[0], 1)
    visualize_communities(G, communities[3], 2)

    # Plot change in modularity as the important edges are removed
    #modularity_df.plot.bar(
    #    x="k",
    #    ax=ax[2],
    #    color="#F2D140",
    #    title="Modularity Trend for Girvan-Newman Community Detection",
    #)
    plt.tight_layout()


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
        CommunityVisualization()


except Exception:
    import traceback
    print(traceback.format_exc())






