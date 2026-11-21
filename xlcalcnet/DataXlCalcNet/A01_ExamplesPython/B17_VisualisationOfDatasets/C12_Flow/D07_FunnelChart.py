from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd

# See https://coderzcolumn.com/tutorials/data-science/sales-funnel-chart-using-matplotlib


def FunnelChart(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FunnelChart'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
#    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
#    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 10
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 7
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))

    labels = ["Leads", "Sales Call", "Follow Up", "Conversion", "Sale"]
    vals = [975, 779, 584, 397, 250]
    colors = ["#a9d18e", "#ffc000", "#ed7d31", "#5b9bd5", "#4472c4"]

    df = pd.DataFrame({"Labels": labels, "Values": vals})

    plt.fill_betweenx(y=[1, 3.8], x1=[10,12], x2=[8,6], color=colors[0]);
    plt.fill_betweenx(y=[4, 6.8], x1=[12,14], x2=[6,4], color=colors[1]);
    #plt.fill_betweenx(y=[7, 9.8], x1=[14,16], x2=[4,2], color=colors[2]);
    plt.fill_betweenx(y=[7, 9.8], x1=[14,16], x2=[4,2], facecolor=colors[2], edgecolor="black", linewidth=5);
    plt.fill_betweenx(y=[10, 12.8], x1=[16,18], x2=[2,0], color=colors[3]);
    plt.fill_betweenx(y=[13, 15.8], x1=[18,20], x2=[0,-2], color=colors[4]);

    plt.xticks([],[]);
    plt.yticks([2,5,8,11,14], df["Labels"][::-1]);

    for y, value in zip([2,5,8,11,14], df["Values"][::-1]):
        plt.text(9, y, value, fontsize=16, fontweight="bold", color="white", ha="center");

    plt.ylabel("Stages");

    plt.title("Sales Funnel", loc="center", fontsize=25, fontweight="bold");
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
        FunnelChart()


except Exception:
    import traceback
    print(traceback.format_exc())


