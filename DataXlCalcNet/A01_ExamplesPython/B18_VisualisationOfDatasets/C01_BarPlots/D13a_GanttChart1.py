from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
from datetime import date

# See https://coderzcolumn.com/tutorials/data-science/gauge-chart-using-matplotlib
#Also: https://github.com/Mona-Arami/python-guage-chart/blob/master/gauge-chart.ipynb


def GanttChart1(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'GanttChart1'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 8
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))

    plt.style.use("ggplot");

    #fig = plt.figure(figsize=(12,8))


    task = ["Planning", "Research", "Design", "Implementation", "Testing", "QA", "UAT", "Followup"]
    start_date =["2023-1-15", "2023-2-15", "2023-3-1", "2023-4-1", "2023-6-15", "2023-7-1", "2023-7-1", "2023-6-15"]
    end_date = ["2023-3-15", "2023-3-15", "2023-4-15", "2023-7-1", "2023-7-15", "2023-7-15", "2023-7-15", "2023-7-25"]

    df = pd.DataFrame(data={"Task": task, "Start": start_date, "End": end_date})

    df["Start"] = pd.to_datetime(df.Start)
    df["End"] = pd.to_datetime(df.End)

    df["Days"] = df["End"] - df["Start"]
    df["Color"] = plt.cm.Set1.colors[:len(df)]

    plt.barh(y=df["Task"], left=df["Start"], width=df["Days"], color=df["Color"]);

    plt.vlines(x=date(2023,2,20), ymin=-1, ymax=8, color="dodgerblue", linewidth=5.0, linestyle="dashed");
    plt.text(x=date(2023,2,25), y=7.1, s="Today", fontsize=20, fontweight="bold", color="black");

    plt.xlim(date(2023,1,1), date(2023, 7,30));
    plt.ylim(-0.5, 7.5);

    dt_rng = pd.date_range(start="2023-1-1", end="2023-8-30", freq="MS")
    plt.xticks(dt_rng, [dt.month_name() for dt in dt_rng], fontsize=15);
    plt.yticks(fontsize=15);


    plt.xlabel("Date", fontsize=20, fontweight="bold");
    plt.ylabel("Task", fontsize=20, fontweight="bold");
    plt.title("Project Roadmap", loc="left", pad=20, fontsize=30, fontweight="bold");

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
        GanttChart1()


except Exception:
    import traceback
    print(traceback.format_exc())


