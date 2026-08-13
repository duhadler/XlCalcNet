from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
from matplotlib import colormaps
from matplotlib.colors import ListedColormap
import numpy as np
import pandas as pd
from operator import itemgetter

# See: https://github.com/szkics/arcplot
# See: https://python-graph-gallery.com/arc-diagram/


class ArcDiagram:
    def __init__(self, *args):

        if len(args) != 2:
            self.help()
            raise ValueError("ArcDiagram(node_list, title_string) takes 2 arguments.")

        self.__nodes = args[0]
        self.__title = args[1]
        self.__arc_coordinates = []
        self.__colors = plt.cm.viridis(np.linspace(0, 1, len(self.__nodes)))
        self.__background_color = "white"
        self.__label_rotation_degree = 0
        self.__legend_labels = []

    def connect(self, start_node, end_node, linewidth=0.1, arc_position="above"):
        start = self.__nodes.index(start_node)
        end = self.__nodes.index(end_node)

        arc_center = (start + end) / 2
        radius = abs(end - start) / 2

        if arc_position == "below":
            theta = np.linspace(180, 360, 100)
        else:
            theta = np.linspace(0, 180, 100)

        x = arc_center + radius * np.cos(np.radians(theta))
        y = radius * np.sin(np.radians(theta))
        self.__arc_coordinates.append((x, y, start, linewidth))

    def help(self):
        function_list = """
        ArcDiagram(node_list, title_string)
        .set_background_color(string)
        .set_color_map(string)
        .set_custom_colors(color_list)
        .set_label_rotation_degree(arc_degree)
        .set_legend_labels(list_of_labels)
        .connect(start, end, linewidth=100, arc_position="below")
        .show_plot(node_type="o", node_size=100, width=8, height=6)
        .save_plot_as(file_name, resolution="figure", node_type="o", node_size=100, width=8, height=6)
        """
        print(function_list)

    def set_background_color(self, color):
        self.__background_color = color

    def set_color_map(self, color_map_name):
        color_map = colormaps[color_map_name]
        self.__colors = color_map(np.linspace(0, 1, len(self.__nodes)))

    def set_custom_colors(self, color_list):
        self.__colors = ListedColormap(color_list).colors

    def set_label_rotation_degree(self, degree):
        self.__label_rotation_degree = degree

    def set_legend_labels(self, legend_labels):
        self.__legend_labels = legend_labels

    def save_plot_as(
        self,
        file_name,
        resolution="figure",
        node_type="o",
        node_size=100,
        width=8,
        height=6,
    ):
        fig, ax = self.__plot(node_type, node_size, width, height)
        plt.savefig(file_name, dpi=resolution, bbox_inches="tight")

    def show_plot(self, node_type="o", node_size=100, width=8, height=6, 
        OutputMode='gui', Title='Title', BottomShift=0.0):

        fig, ax = self.__plot(node_type, node_size, width, height)

        if BottomShift>0.0: 
            fig.subplots_adjust(bottom=0.33)  # 0.33

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


        #plt.show()

    def __label_color_distribution(self, colors, n):
        if n <= 0:
            return []

        step = (len(colors) - 1) / (n - 1)
        indices = [round(i * step) for i in range(n)]
        return [colors[i] for i in indices]

    def __plot(self, node_type="o", node_size=100, width=8, height=6):
        fig, ax = plt.subplots(figsize=(width, height))
        ax.set_facecolor(self.__background_color)

        # plot nodes as points
        node_positions = np.arange(len(self.__nodes))
        ax.scatter(
            node_positions,
            np.zeros_like(node_positions),
            color=self.__colors,
            marker=node_type,
            s=node_size,
        )

        max_value = max(self.__arc_coordinates, key=itemgetter(3))[3]
        # plot connections as arcs
        for x, y, index, raw_linewidth in self.__arc_coordinates:
            ax.plot(
                x,
                y,
                color=self.__colors[index],
                zorder=1,
                linewidth=self._map_to_linewidth(raw_linewidth, max_value),
            )

        plt.xticks(rotation=self.__label_rotation_degree)
        ax.set_xticks(node_positions)
        ax.set_xticklabels(self.__nodes)
        ax.set_yticks([])
        ax.set_title(self.__title)

        if self.__legend_labels != []:
            legend_labels = self.__legend_labels
            label_colors = self.__label_color_distribution(
                self.__colors, len(legend_labels)
            )
            ax.legend(
                handles=[
                    plt.Line2D(
                        [0],
                        [0],
                        marker="o",
                        color="w",
                        label=label,
                        markerfacecolor=label_colors[i],
                        markersize=10,
                    )
                    for i, label in enumerate(legend_labels)
                ],
                loc="upper right",
            )

        return fig, ax

    def _map_to_linewidth(self, value, max_value):
        if value < 1:
            return 1
        else:
            return (10 * value) / max_value


def create_arc_plot(
    df: pd.DataFrame,
    start_node: str,
    end_node: str,
    weights=None,
    positions=None,
    invert_positions: bool = False,
    bg_color="white",
    cmap="viridis",
    title="Diagram",
):
    """
    Wrapper for the ArcDiagram class, which creates diagrams from a pandas dataframe.
    Args:
        df (pd.DataFrame): The dataframe containing the data.
        start_node (str): The name of the column containing the start node.
        end_node (str): The name of the column containing the end node.
        weights (str, optional): The name of the column containing the weights. Defaults to None.
        positions (str, optional): The name of the column containing the positions. Defaults to None.
        invert_positions (bool, optional): Whether to invert the positions. Defaults to False.
        bg_color (str, optional): The background color. Defaults to 'white'.
        cmap (str, optional): The color map. Defaults to 'viridis'.
        title (str, optional): The title of the diagram. Defaults to 'Diagram'.
    Raises:
        ValueError: If start_node or end_node are not columns in the dataframe.
        ValueError: If start_node and end_node do not have the same length.
        ValueError: If positions is not a column in the dataframe.
        ValueError: If positions does not have 1 or 2 unique values.
        ValueError: If weights is not a column in the dataframe.
    """

    data = df.copy()

    if start_node not in data.columns or end_node not in data.columns:
        raise ValueError("start_node and end_node must be columns in the dataframe")

    if len(data[start_node]) != len(data[end_node]):
        raise ValueError("start_node and end_node must have the same length")

    # get all unique nodes
    nodes = data[start_node].unique().tolist() + data[end_node].unique().tolist()
    nodes = list(set(nodes))

    # initialize the diagram
    arcdiag = ArcDiagram(nodes, title)

    # get positions
    if positions:
        if positions not in data.columns:
            raise ValueError("positions must be a column in the dataframe")
        else:
            n_positions = data[positions].nunique()
            if n_positions not in [1, 2]:
                raise ValueError("positions must have 1 or 2 unique values")
            else:
                if n_positions == 1:
                    position_map = {data[positions].unique()[0]: "above"}
                else:
                    position_map = {
                        data[positions].unique()[0]: "above",
                        data[positions].unique()[1]: "below",
                    }
                data[positions] = data[positions].map(position_map)

                if invert_positions:
                    data[positions] = data[positions].map(
                        {"below": "above", "above": "below"}
                    )
    else:
        data[positions] = "above"

    # get weights
    if not weights:
        data[weights] = 0.1
    else:
        if weights not in data.columns:
            raise ValueError("weights must be a column in the dataframe")

    # connect the nodes
    for connection in data.iterrows():
        arcdiag.connect(
            connection[1][start_node],
            connection[1][end_node],
            linewidth=connection[1][weights],
            arc_position=connection[1][positions],
        )

    # custom colors
    arcdiag.set_background_color(bg_color)
    arcdiag.set_color_map(cmap)

    return arcdiag


def show_arc_plot(
    df: pd.DataFrame,
    start_node: str,
    end_node: str,
    weights=None,
    positions=None,
    invert_positions: bool = False,
    bg_color="white",
    cmap="viridis",
    title="My Diagram",
    node_type="o",
    node_size=100,
    width=6,
    height=5,
):
    arc_diagram = create_arc_plot(
        df,
        start_node,
        end_node,
        weights,
        positions,
        invert_positions,
        bg_color,
        cmap,
        title,
    )

    # plot the diagram
    arc_diagram.show_plot(node_type, node_size, width, height)


def save_arc_plot_as(
    df: pd.DataFrame,
    start_node: str,
    end_node: str,
    file_name: str,
    weights=None,
    positions=None,
    invert_positions: bool = False,
    bg_color="white",
    cmap="viridis",
    title="My Diagram",
    resolution="figure",
    node_type="o",
    node_size=100,
    width=8,
    height=6,
):
    arc_diagram = create_arc_plot(
        df,
        start_node,
        end_node,
        weights,
        positions,
        invert_positions,
        bg_color,
        cmap,
        title,
    )

    arc_diagram.save_plot_as(file_name, resolution, node_type, node_size, width, height)


def Arcplot1(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Arcplot1'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    nodes = [
        "Rome",
        "Naples",
        "Florence",
        "Bari",
        "Taranto",
        "Verona",
        "Venice",
        "Bologna",
        "Bolzano",
        "Milan",
        "Turin",
        "Genoa",
    ]
    title = "Railway connections between Italian cities"
    arc_diagram = ArcDiagram(nodes, title)
    custom_colors = [
        "#386641",
        "#f2e8cf",
        "#8b3422",
        "#6f7714",
        "#ff9b54",
        "#e2d9c5",
        "#9a8237",
        "#dbab85",
        "#d64620",
        "#f6bd60",
        "#283618",
        "#a98467",
    ]
    arc_diagram.set_custom_colors(custom_colors)
    arc_diagram.set_background_color("#262522")
    arc_diagram.set_label_rotation_degree(45)
    arc_diagram.connect(
        "Milan", "Genoa", linewidth=119
    )  # passing the distance in km between the two cities as arc linewidth
    arc_diagram.connect("Milan", "Verona", linewidth=140)
    arc_diagram.connect("Milan", "Turin", linewidth=126)
    arc_diagram.connect("Milan", "Bologna", linewidth=201)
    arc_diagram.connect("Rome", "Genoa", linewidth=403)
    arc_diagram.connect("Rome", "Florence", linewidth=232)
    arc_diagram.connect("Rome", "Naples", linewidth=189)
    arc_diagram.connect("Rome", "Bari", linewidth=375)
    arc_diagram.connect("Florence", "Genoa", linewidth=200)
    arc_diagram.connect("Florence", "Bologna", linewidth=80)
    arc_diagram.connect("Naples", "Taranto", linewidth=252)
    arc_diagram.connect("Naples", "Bari", linewidth=219)
    arc_diagram.connect("Venice", "Verona", linewidth=120)
    arc_diagram.connect("Venice", "Bologna", linewidth=131)
    arc_diagram.connect("Bolzano", "Verona", linewidth=122)
    arc_diagram.connect("Bari", "Taranto", linewidth=78)
    arc_diagram.connect("Genoa", "Turin", linewidth=122)
    arc_diagram.show_plot()






def Arcplot2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Arcplot2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    title = "Friendships Between Post-, Neo- and Impressionist Painters"
    nodes = [
        "Vincent van Gogh",
        "Paul Gauguin",
        "Eugène Boch",
        "Émile Bernard",
        "Louis Anquetin",
        "Henri de Toulouse-Lautrec",
        "Paul Cézanne",
        "Paul Signac",
        "Georges Seurat",
        "Camille Pissarro",
        "Edgar Degas",
        "Édouard Manet",
        "Claude Monet",
        "Pierre-Auguste Renoir",
    ]

    connections = [
        ("Vincent van Gogh", "Paul Gauguin"),
        ("Vincent van Gogh", "Émile Bernard"),
        ("Vincent van Gogh", "Eugène Boch"),
        ("Vincent van Gogh", "Paul Signac"),
        ("Vincent van Gogh", "Henri de Toulouse-Lautrec"),
        ("Vincent van Gogh", "Louis Anquetin"),
        ("Vincent van Gogh", "Paul Cézanne"),
        ("Paul Gauguin", "Émile Bernard"),
        ("Paul Gauguin", "Eugène Boch"),
        ("Émile Bernard", "Eugène Boch"),
        ("Émile Bernard", "Henri de Toulouse-Lautrec"),
        ("Émile Bernard", "Louis Anquetin"),
        ("Émile Bernard", "Paul Cézanne"),
        ("Henri de Toulouse-Lautrec", "Louis Anquetin"),
        ("Henri de Toulouse-Lautrec", "Paul Signac"),
        ("Paul Signac", "Georges Seurat"),
        ("Paul Signac", "Camille Pissarro"),
        ("Camille Pissarro", "Paul Cézanne"),
        ("Camille Pissarro", "Paul Gauguin"),
        ("Camille Pissarro", "Vincent van Gogh"),
        ("Camille Pissarro", "Georges Seurat"),
        ("Camille Pissarro", "Paul Signac"),
        ("Camille Pissarro", "Édouard Manet"),
        ("Camille Pissarro", "Claude Monet"),
        ("Camille Pissarro", "Pierre-Auguste Renoir"),
        ("Camille Pissarro", "Edgar Degas"),
        ("Claude Monet", "Paul Signac"),
        ("Claude Monet", "Pierre-Auguste Renoir"),
        ("Claude Monet", "Édouard Manet"),
        ("Édouard Manet", "Pierre-Auguste Renoir"),
        ("Édouard Manet", "Edgar Degas"),
    ]
    arc_diagram_painters = ArcDiagram(nodes, title)

    arc_diagram_painters.set_label_rotation_degree(90)
    arc_diagram_painters.set_legend_labels(
        ["Post-Impressionist", "Neo-Impressionist", "Impressionist"]
    )

    for connection in connections:
        arc_diagram_painters.connect(connection[0], connection[1])

    arc_diagram_painters.set_background_color("black")
    arc_diagram_painters.set_color_map("summer")

    #arc_diagram_painters.save_plot_as("painters.png")

    arc_diagram_painters.show_plot(BottomShift=0.33)



def Arcplot3(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Arcplot3'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    nodes = [
        "1885",
        "1955",
        "1985",
        "1985A",
        "2015",
    ]

    title = "Back To The Future Time Travels \n Top: Back To The Future \n Bottom: Back To The Past"
    arc_diagram = ArcDiagram(nodes, title)
    arc_diagram.set_background_color("#222124")
    arc_diagram.set_color_map("autumn")
    arc_diagram.connect("1885", "1985")
    arc_diagram.connect("1955", "1985")
    arc_diagram.connect("1985", "2015")
    arc_diagram.connect("2015", "1985A", arc_position="below")
    arc_diagram.connect("2015", "1955", arc_position="below")
    arc_diagram.connect("1985", "1955", arc_position="below")
    arc_diagram.connect("1985A", "1955", arc_position="below")
    arc_diagram.connect("1955", "1885", arc_position="below")

    #arc_diagram.save_plot_as("back_to_the_future.png")

    arc_diagram.show_plot()


def Arcplot4(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Connections'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 8
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'CSV', 'connections_dataset.csv'])

    df = pd.read_csv(DataPath)
    show_arc_plot(
        df,
        start_node="from",
        end_node="to",
        weights="weights",
        positions="position",
        title=Title,
        node_type="^",
        node_size=300,
        width=FigSizeX,
        height=FigSizeY,
    )







try:
    if __name__ == '__main__':
        Arcplot1()
        #Arcplot2()
        #Arcplot3()
        #Arcplot4() 

except Exception:
    import traceback
    print(traceback.format_exc())





