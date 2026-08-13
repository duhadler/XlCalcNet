
# See: https://python-graph-gallery.com/pie-plot-matplotlib-basic/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt



def PieChart(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PieChart'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    plt.rcParams["figure.figsize"] = (5,5)
    # create random data
    values=[12,11,3,30]
    names='groupA', 'groupB', 'groupC', 'groupD',
    colors = ['#4F6272', '#B7C3F3', '#DD7596', '#8EB897']

     
    ## Create a pieplot
    #plt.pie(values);
    #plt.show();
    #
    ## create random data
    #values=[12,11,3,30]
    # 
    #
    ## Label distance: gives the space between labels and the center of the pie
    #plt.pie(values, labels=names, labeldistance=1.15);
    #plt.show();
    #
    # 
    #
    ## Same chart as above but with specific wedgeprops option:
    #plt.pie(values, labels=names, labeldistance=1.15, wedgeprops = { 'linewidth' : 3, 'edgecolor' : 'white' });
    #plt.show();
    #

    # Create a set of colors

    # Use it thanks to the color argument
    plt.pie(values, labels=names, labeldistance=1.15, wedgeprops = { 'linewidth' : 1, 'edgecolor' : 'white' }, colors=colors);
    fig = plt.gcf()


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
        PieChart()


except Exception:
    import traceback
    print(traceback.format_exc())




