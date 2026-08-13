from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import mplfinance as mpf
import pandas as pd


def MplOhclMav369Vol(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MplOhclMav369Vol'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1.0
# End of custom key word arguments

    plt.style.use(PlotStyle)

    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'CSV', 'SP500_NOV2019_Hist.csv'])

    daily = pd.read_csv(DataPath, index_col=0, parse_dates=True)
    daily.index.name = 'Date'

    fig, axlist = mpf.plot(daily, type='candle', mav=(3,6,9), volume=True, returnfig=True)


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
        MplOhclMav369Vol()


except Exception:
    import traceback
    print(traceback.format_exc())



