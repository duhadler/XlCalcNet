
#See https://medium.com/data-science/simple-little-tables-with-matplotlib-9780ef5d0bc4
from xlcalcnet import gui
import os
import matplotlib.pyplot as plt
import numpy as np


def DemoTable(**kwargs):
    Title = kwargs['Title'] if 'Title' in kwargs else 'Loss_by_Disaster'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    Resolution = kwargs['Resolution'] if 'Resolution' in kwargs else 300
    FigSizeX = kwargs['FigSizeX'] if 'FigSizeX' in kwargs else 4
    FigSizeY = kwargs['FigSizeY'] if 'FigSizeY' in kwargs else 4

    title_text = Title
    footer_text = 'June 24, 2020'
    fig_background_color = 'skyblue'
    fig_border = 'steelblue'
    data =  [
                [         'Freeze', 'Wind', 'Flood', 'Quake', 'Hail'],
                [ '5 year',  66386, 174296,   75131,  577908,  32015],
                ['10 year',  58230, 381139,   78045,   99308, 160454],
                ['20 year',  89135,  80552,  152558,  497981, 603535],
                ['30 year',  78415,  81858,  150656,  193263,  69638],
                ['40 year', 139361, 331509,  343164,  781380,  52269],
            ]
    # Pop the headers from the data array
    column_headers = data.pop(0)
    row_headers = [x.pop(0) for x in data]
    # Table data needs to be non-numeric text. Format the data
    # while I'm at it.
    cell_text = []
    for row in data:
        cell_text.append([f'{x/1000:1.1f}' for x in row])
    # Get some lists of color specs for row and column headers
    rcolors = plt.cm.BuPu(np.full(len(row_headers), 0.1))
    ccolors = plt.cm.BuPu(np.full(len(column_headers), 0.1))
    # Create the figure. Setting a small pad on tight_layout
    # seems to better regulate white space. Sometimes experimenting
    # with an explicit figsize here can produce better outcome.
    plt.figure(linewidth=2,
               edgecolor=fig_border,
               facecolor=fig_background_color,
               tight_layout={'pad':1},
               figsize=(5,2.5)
              )
    # Add a table at the bottom of the axes
    the_table = plt.table(cellText=cell_text,
                          rowLabels=row_headers,
                          rowColours=rcolors,
                          rowLoc='right',
                          colColours=ccolors,
                          colLabels=column_headers,
                          loc='center')
    # Scaling is the only influence we have over top and bottom cell padding.
    # Make the rows taller (i.e., make cell y scale larger).
    the_table.scale(1, 1.5)
    # Hide axes
    ax = plt.gca()
    ax.get_xaxis().set_visible(False)
    ax.get_yaxis().set_visible(False)
    # Hide axes border
    plt.box(on=None)
    # Add title
    plt.suptitle(title_text, y = 0.9)
    # Add footer
    plt.figtext(0.95, 0.05, footer_text, horizontalalignment='right', size=6, weight='light')
    # Force the figure to update, so backends center objects correctly within the figure.
    # Without plt.draw() here, the title will center on the axes and not the figure.
    plt.draw()
    # Create image. plt.savefig ignores figure edge and face colors, so map them.
    fig = plt.gcf()



    LocalAppData = gui.get_local_appdata()
    FName = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp', Title])

    print(FName)

    if (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    elif (OutputMode == 'svg'):
        plt.savefig(FName + '.svg', 
            bbox_inches='tight',
            edgecolor=fig.get_edgecolor(),
            facecolor=fig.get_facecolor(),
            dpi=150)
    elif (OutputMode == 'pdf'):
        plt.savefig(FName + '.pdf', 
            bbox_inches='tight',
            edgecolor=fig.get_edgecolor(),
            facecolor=fig.get_facecolor(),
            dpi=150)



try:
    #DemoTable(OutputMode = 'gui')
    #DemoTable(OutputMode = 'svg')
    DemoTable(OutputMode = 'pdf')


except Exception:
    import traceback
    print(traceback.format_exc())



