
# See: https://python-graph-gallery.com/web-stacked-line-chart-with-labels/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import seaborn as sns
import pandas as pd
import matplotlib.pyplot as plt
from scipy.interpolate import make_interp_spline

 

def StackedAreaChart2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'StackedAreaChart2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    my_path = r'C:\Users\DUHad\Documents\DataXlCalcNet\DataExamples\MainExamples\Workbooks\wealth_data.xlsx'

    df = pd.read_excel(my_path)

    # Libraries
    import numpy as np
    # Create a pivot table to reshape the data for stacked area chart
    pivot_df = df.pivot(index='year', columns='country', values='total_wealth')

    # Define custom colors for the countries
    custom_colors = ["#003f5c","#2f4b7c","#665191","#a05195","#d45087","#f95d6a","#ff7c43","#ffa600"]

    # Smooth the lines using spline interpolation
    x_smooth = np.linspace(pivot_df.index.min(), pivot_df.index.max(), 300)
    pivot_smooth = pd.DataFrame({country: make_interp_spline(pivot_df.index, pivot_df[country])(x_smooth)
                                 for country in pivot_df.columns})

    # Plot the stacked area chart with smoothing and custom colors
    plt.figure(figsize=(6, 6))  # Set the figure size
    plt.stackplot(x_smooth,
                  pivot_smooth.values.T,
                  labels=pivot_smooth.columns,
                  colors=custom_colors)
    plt.xlabel('Year') # Add a label for the x-axis
    plt.ylabel('Total Wealth') # Add a label for the y-axis
    plt.title('Stacked Area Chart with Smoothing and Customized Colors') # Add a title
    plt.legend(loc='upper left') # Add a legend in the upper left corner of the plot
    fig = plt.gcf()
    fig.tight_layout()

    # Show the plot


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
        StackedAreaChart2()


except Exception:
    import traceback
    print(traceback.format_exc())


