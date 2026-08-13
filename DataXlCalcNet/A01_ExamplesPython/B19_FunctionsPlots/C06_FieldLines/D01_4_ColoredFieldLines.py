from xlcalcnet import gui
import os, re
import math
import matplotlib.pyplot as plt
import matplotlib.collections as collections
import sys


class Vector:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def get_magnitude(self):
        return math.sqrt(self.x ** 2 + self.y ** 2)

    def get_angle(self):
        return math.atan2(self.y, self.x)

    def get_tuple(self):
        return self.x, self.y

    def add(self, vector):
        return Vector(self.x + vector.x, self.y + vector.y)

    def subtract(self, vector):
        return Vector(self.x - vector.x, self.y - vector.y)

    @staticmethod
    def create(magnitude, angle):
        return Vector(magnitude * math.cos(angle), magnitude * math.sin(angle))

    def __str__(self) -> str:
        return f"({self.x}, {self.y})"


class Item:
    def __init__(self, repels: bool, magnitude, position: Vector):
        self.repels = repels
        self.magnitude = magnitude
        self.position = position

    def get_radius(self):
        MAGNITUDE_TO_RADIUS_FACTOR = 0.2 / (1.602 * 10 ** (-19))
        return self.magnitude * MAGNITUDE_TO_RADIUS_FACTOR

    def is_position_inside_item(self, position: Vector) -> bool:
        return self.position.subtract(position).get_magnitude() < self.get_radius()


class Graph:

    @staticmethod
    def is_within_borders(end_vector: Vector):
        SIZE_OF_GRAPH = 5
        return -SIZE_OF_GRAPH < end_vector.x < SIZE_OF_GRAPH and -SIZE_OF_GRAPH < end_vector.y < SIZE_OF_GRAPH

    @staticmethod
    def setup():
        SIZE_OF_GRAPH = 5
        axis = plt.gca()
        axis.set_xlim((-SIZE_OF_GRAPH, SIZE_OF_GRAPH))
        axis.set_ylim((-SIZE_OF_GRAPH, SIZE_OF_GRAPH))
        axis.set_aspect('equal')

    @staticmethod
    def draw_lines(lines_to_draw, colors=None):
        axis = plt.gca()
        line_collection = collections.LineCollection(lines_to_draw, colors=colors)
        axis.add_collection(line_collection)

    @staticmethod
    def draw_item(item):
        axis = plt.gca()
        circle = plt.Circle(item.position.get_tuple(), item.get_radius(),
                            color="g" if item.repels else "r")
        axis.add_artist(circle)

    @staticmethod
    def get_fig():
        axis = plt.gca()
        return axis.get_figure()

def convert_to_rgba(minval, maxval, val, colors):
    # Modified from:
    # https://stackoverflow.com/questions/20792445/calculate-rgb-value-for-a-range-of-values-to-create-heat-map
    # "colors" is a series of RGB colors delineating a series of
    # adjacent linear color gradients between each pair.
    # Determine where the given value falls proportionality within
    # the range from minval->maxval and scale that fractional value
    # by the total number in the "colors" pallette.
    i_f = float(val - minval) / float(maxval - minval) * (len(colors) - 1)
    # Determine the lower index of the pair of color indices this
    # value corresponds and its fractional distance between the lower
    # and the upper colors.
    i, f = int(i_f // 1), i_f % 1  # Split into whole & fractional parts.
    # Does it fall exactly on one of the color points?
    if f < sys.float_info.epsilon:
        (r, g, b) = colors[i]
        return r / 255, g / 255, b / 255, 1
    else:  # Otherwise return a color within the range between them.
        (r1, g1, b1), (r2, g2, b2) = colors[i], colors[i + 1]
        return int(r1 + f * (r2 - r1)) / 255, int(g1 + f * (g2 - g1)) / 255, int(b1 + f * (b2 - b1)) / 255, 1


def convert_magnitudes_to_colors(magnitudes):
    def magnitude_to_radius(magnitude_to_convert):
        return math.sqrt(1 / magnitude_to_convert)

    max_radius = magnitude_to_radius(min(magnitudes))
    min_radius = magnitude_to_radius(max(magnitudes))

    color_code = [(255, 0, 0), (0, 0, 255), (0, 255, 0)]
    colors = []
    for magnitude in magnitudes:
        colors.append(convert_to_rgba(min_radius, max_radius, magnitude_to_radius(magnitude), color_code))
    return colors



def get_points_around_item(item):
    STARTING_POINTS_PER_CHARGE = 16 / (1.602 * 10 ** (-19))
    starting_vectors = []

    radius = item.get_radius()

    step = 2 * math.pi / (item.magnitude * STARTING_POINTS_PER_CHARGE)
    offset = step / 2
    angle = offset
    while angle < 2 * math.pi:
        starting_vectors.append(item.position.add(Vector.create(radius, angle)))
        angle += step

    return starting_vectors


def calculate_field(items, position):
    K_CONSTANT = 9 * 10 ** 9
    net_field = Vector(0, 0)

    for item in items:
        if item.repels:
            vector = position.subtract(item.position)
        else:
            vector = item.position.subtract(position)
        magnitude = K_CONSTANT * item.magnitude / (vector.get_magnitude() ** 2)
        angle = vector.get_angle()

        net_field = net_field.add(Vector.create(magnitude, angle))

    return net_field


def is_valid_end(end_vector, items):
    for item in items:
        if item.is_position_inside_item(end_vector):
            return False
    return True


def generate_lines_for_starting_point(starting_point, items, reverse_follow=False):
    LINE_SEGMENT_LENGTH = 0.01
    next_start = starting_point
    lines = []
    magnitudes = []
    for i in range(10000):
        field = calculate_field(items, next_start)

        short_vector = Vector.create(LINE_SEGMENT_LENGTH, field.get_angle())

        if reverse_follow:
            end = next_start.subtract(short_vector)
        else:
            end = next_start.add(short_vector)

        if not is_valid_end(end, items):
            break

        if Graph.is_within_borders(end):
            lines.append([next_start.get_tuple(), end.get_tuple()])
            magnitudes.append(field.get_magnitude())

        next_start = end
    return lines, magnitudes


def flip_items(items):
    for item in items:
        item.repels = not item.repels


def get_field_lines(items):
    lines = []
    magnitudes = []
    for index, item in enumerate(items):
        #print(f"Calculating field for item ({index} of {len(items)})...", end="")

        if item.repels:
            for starting_point in get_points_around_item(item):
                (a, b) = generate_lines_for_starting_point(starting_point, items)
                lines += a
                magnitudes += b

        #print("Done.")
    return lines, magnitudes


def ColoredFieldLines(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ColoredFieldLines'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'ggplot'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 64
# End of standard key word arguments

    USE_COLORS = kwargs['UseColors'] if 'UseColors' in kwargs else False
    ChargePositionModel = kwargs['Model'] if 'Model' in kwargs else 1
    #ChargePositionModel: 1, 2, 3, 4


    # charges and positions
    Q_CONSTANT = 1.602 * 10 ** (-19)
    if ChargePositionModel == 1:
        items = [
            Item(True, Q_CONSTANT, Vector(0, 1)),
            Item(False, Q_CONSTANT, Vector(0, -1)),
        ]

    if ChargePositionModel == 2:
        items = [
            Item(True, 3*Q_CONSTANT, Vector(0, 1)),
            Item(False, Q_CONSTANT, Vector(0, -1)),
        ]

    if ChargePositionModel == 3:
        items = [
            Item(True, 3*Q_CONSTANT, Vector(0, 1)),
            Item(True, Q_CONSTANT, Vector(0, -1)),
        ]

    if ChargePositionModel == 4:
        items = [
            Item(True, Q_CONSTANT, Vector(0, 2)),
            Item(True, 2 * Q_CONSTANT, Vector(0, -2)),
            Item(False, Q_CONSTANT, Vector(-2, -2)),
            Item(False, Q_CONSTANT, Vector(2, -2))
        ]

# End of custom key word arguments

    plt.style.use(PlotStyle)

    Graph.setup()
    [Graph.draw_item(item) for item in items]

    # Check if at least one item repels. If not we need to flip all the items 
    # to get some starting points
    has_repels = False
    for item in items:
        if item.repels:
            has_repels = True
            break

    if not has_repels:
        flip_items(items)

    line_segments, magnitudes = get_field_lines(items)
    Graph.draw_lines(line_segments, convert_magnitudes_to_colors(magnitudes) 
        if USE_COLORS else None)

    fig = Graph.get_fig()
    fig.set_size_inches(FigSizeX, FigSizeY)
    ax = plt.gca()
    ax.set_title(Title)

# Start of output choices
    if (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        plt.savefig(FullPath + '.' + OutputMode,  bbox_inches='tight')
    plt.close('all')


try:
    if __name__ == '__main__':
        ColoredFieldLines(UseColors=True, Model=4)

except Exception:
    import traceback
    print(traceback.format_exc())

