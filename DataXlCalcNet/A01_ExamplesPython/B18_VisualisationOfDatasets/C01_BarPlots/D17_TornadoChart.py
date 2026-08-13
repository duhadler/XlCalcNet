
# See: https://python-graph-gallery.com/web-tornado-chart/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
from highlight_text import ax_text
import numpy as np
import pandas as pd

def tornado_chart(data, labels, midpoint, low_values, high_values, title="<Low> VS <High> values"):
    """
    Parameters
    ----------
    labels : np.array()
        List of label titles used to identify the variables, y-axis of bar
        chart. The lengh of labels is used to itereate through to generate
        the bar charts.
    midpoint : float
        Center value for bar charts to extend from. In sensitivity analysis
        this is often the 'neutral' or 'default' model output.
    low_values : np.array()
        An np.array of the model output resulting from the low variable
        selection. Same length and order as label_range.
    high_values : np.array()
        An np.array of the model output resulting from the high variable
        selection. Same length and order as label_range.
    """

    color_low = '#e1ceff'
    color_high = '#ff6262'

    ys = range(len(data['Labels']))[::1] # iterate through # of labels

    for y, low_value, high_value in zip(ys, low_values, high_values):

        low_width = midpoint - low_value
        high_width = high_value - midpoint

        plt.broken_barh(
            [
                (low_value, low_width),
                (midpoint, high_width)
            ],
            (y-0.4, 0.8), # thickness of bars and their offset
            facecolors = [color_low, color_high],
            edgecolors = ['black', 'black'],
            linewidth = 0.5
            )

        offset = 2 # offset value labels from end of bar


        if high_value > low_value:
            x_high = midpoint + high_width + offset
            x_low = midpoint - low_width - offset
        else:
            x_high = midpoint + high_width - offset
            x_low = midpoint - low_width + offset

        plt.text(x_high, y, str(high_value), va='center', ha='center')
        plt.text(x_low, y, str(low_value), va='center', ha='center')

    plt.axvline(midpoint, color='black', linewidth = 1)

    # set axis lines on or off
    ax = plt.gca()
    ax.spines[['right', 'left', 'top']].set_visible(False)
    ax.set_yticks([])

    # build legend
    ax_text(x = midpoint, y = len(labels),
            s=title,
            color='black',
            fontsize=15,
            va='center',
            ha='center',
            highlight_textprops=[{"color": color_low, "fontweight": 'bold'},
                                 {"color": color_high, "fontweight": 'bold'}],
            ax=ax)

    plt.xlabel('Model output')
    plt.yticks(ys, labels)
    plt.xlim(0,40)
    plt.ylim(-0.5, len(labels)-0.5)
    plt.tick_params(left = False)

    fig = plt.gcf()
    fig.tight_layout()

    # Show the graph
    #plt.show()

    return








def TornadoChart(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'TornadoChart'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    # data for chart
    labels = np.char.array([
        "Variable 1\n 1.0 - 5.0",
        "Variable 2\n 11% - 15%",
        "Variable 3\n $200 - $300",
        "Variable 4\n $12 - $14",
        "Variable 5\n Off - On",
        "Variable 6\n Low - High",
    ])

    midpoint = 20

    # data values
    low_values = np.array([ # value order corresponds to label order
        19.5,
        18,
        15.5,
        12,
        32.5,
        4
    ])

    high_values = np.array([
        20.5,
        22,
        24.5,
        28,
        7.5,
        36
    ])

    var_effect = np.abs(high_values - low_values)/midpoint

    data = pd.DataFrame({'Labels': labels,
                         'Low values': low_values,
                         'High values': high_values,
                         'Variable effect' : var_effect
                        })

    # sorts effect high to low (adjust to preference)
    data = data.sort_values(
        'Variable effect',
        ascending=True,
        inplace=False,
        ignore_index=False,
        key=None
    )


    tornado_chart(data, labels, midpoint, data['Low values'], data['High values'])


    fig = plt.gcf()
    fig.tight_layout()


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
        TornadoChart()


except Exception:
    import traceback
    print(traceback.format_exc())




