
# See: https://python-graph-gallery.com/web-stacked-line-chart-with-labels/

from xlcalcnet import gui
from pathlib import Path
import os, time
import numpy as np
import seaborn as sns
import pandas as pd
 


def StackedAreaChart1(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'StackedAreaChart1'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    

    # Choose 'Agg' as backend unless we want to display the graphics
    if (OutputMode != 'gui'):
        import matplotlib
        matplotlib.use('Agg')
    import matplotlib.pyplot as plt
    plt.style.use(PlotStyle)

    # Load the dataset from the worksheet 'wealth' in the workbook 'Datasets'
    fn = gui.get_dataxlcalcnet()
    fn += r'\DataExamples\MainExamples\Workbooks\Datasets.xlsx'
    datasets = pd.ExcelFile(fn)
    df = pd.read_excel(datasets, 'wealth')


    # Create a pivot table to reshape the data for stacked area chart
    pivot_df = df.pivot(index='year', columns='country', values='total_wealth')

    # Plot the stacked area chart with smoothing and custom colors
    plt.figure(figsize=(6, 6))  # Set the figure size
    plt.stackplot(pivot_df.index,
                  pivot_df.values.T,
                  labels=pivot_df.columns)
    plt.xlabel('Year') # Add a label for the x-axis
    plt.ylabel('Total Wealth') # Add a label for the y-axis
    plt.title('A Simple Stacked Area Chart') # Add a title
    plt.legend(loc='upper left') # Add a legend in the upper left corner of the plot
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
        start0 = time.time()
        StackedAreaChart1(OutputMode = 'gui')
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())


