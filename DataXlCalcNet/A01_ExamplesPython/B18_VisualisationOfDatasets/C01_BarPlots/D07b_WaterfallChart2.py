from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd

# See https://coderzcolumn.com/tutorials/data-science/waterfall-chart-using-matplotlib


def WaterfallChart2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'WaterfallChart2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 7
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))

    plt.style.use("ggplot");

    #fig = plt.figure(figsize=(12,8))



    labels = ["Q1", "Q2", "Q3", "Q4", "Total", "Q1", "Q2", "Q3", "Q4", "Total"]
    values = [60000, 80000, -40000, 30000, 0, -30000, 80000, -40000, 30000, 0]

    df = pd.DataFrame({"Labels": labels, "Vals": values})

    df["Cumulative"] = df["Vals"].cumsum()
    df["Cumulative"] =[cum-val if val<0 else cum for cum, val in df[["Cumulative", "Vals"]].values]

    df["Color"] = ["green" if val>0 else "red" if val<0 else "dodgerblue" for val in df["Vals"]]


    bottom = [0,]
    height = [values[0],]

    for i, val in enumerate(values[1:], start=1):
        if val==0: ## Current Value equal to 0
            bottom.append(0)
            height.append(df["Cumulative"][i])
        elif val > 0: ## Current Value greater than 0
            if values[i-1] >=0:
                bottom.append(df["Cumulative"][i-1])
            else:
                bottom.append(bottom[i-1])
            height.append(val)
        elif val < 0: ## Current Value less than 0
            if values[i-1] >=0:
                bottom.append(df["Cumulative"][i-1]+val)
            else:
                bottom.append(bottom[i-1]+val)
            height.append(-val)

    df["Bottom"] = bottom
    df["Height"] = height

    plt.bar(x=df.index, height=df["Height"], bottom=df["Bottom"], color=df["Color"]);
    #plt.step(df.index, df["Cumulative"], where="mid", color="black");

    plt.xticks(df.index, df["Labels"], fontdict=dict(fontsize=10));
    plt.yticks(range(0, 160001, 20000), ["{:,} $".format(val) for val in range(0, 160001, 20000)],
               fontdict=dict(fontsize=14)
              );

    for idx in range(len(df)):
        plt.text(x=df.index[idx], y=df["Cumulative"][idx],
                 s="{:,} $".format(df["Vals"][idx] if df["Vals"][idx]!=0 else df["Cumulative"][idx]),
                 ha="center", va="bottom", fontdict=dict(fontsize=12)
                );

    plt.xlabel("Earnings/Purchases", fontdict=dict(fontsize=12, fontweight="bold"))
    plt.ylabel("Cost ($)", fontdict=dict(fontsize=12, fontweight="bold"))
    plt.title("WaterFall Chart", loc="left", pad=10, fontdict=dict(fontsize=16, fontweight="bold"));
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
        WaterfallChart2()


except Exception:
    import traceback
    print(traceback.format_exc())


