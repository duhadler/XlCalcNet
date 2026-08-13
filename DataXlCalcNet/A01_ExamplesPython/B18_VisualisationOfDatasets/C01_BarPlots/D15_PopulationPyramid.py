from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd

# See https://coderzcolumn.com/tutorials/data-science/population-pyramid-chart-using-matplotlib


def PopulationPyramid(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PopulationPyramid'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 7
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))


    age = ["0-4", "5-9", "10-14", "15-19", "20-24", "25-29", "30-34", "35-39", "40-44", "45-49", "50-54", "55-59",
           "60-64", "65-69", "70-74", "75-79", "80-84", "85-89", "90+"]
    male = [3, 3.3, 3.4, 3.2, 3, 3.3, 3.7, 3.9, 3.5, 3.1, 3.4, 2.8, 2.4, 2.1, 1.8, 1.4, 0.8, 0.4, 0.1]
    female = [2.9, 3.1, 3.2, 3, 3, 3.4, 3.9, 4, 3.6, 3.2, 3.5, 2.9, 2.5, 2.3, 2.2, 2, 1.4, 0.9, 0.5]

    population_df = pd.DataFrame({"Age": age, "Male": male, "Female": female})

    population_df["Female_Left"] = 0
    population_df["Female_Width"] = population_df["Female"]

    population_df["Male_Left"] = -population_df["Male"]
    population_df["Male_Width"] = population_df["Male"]

    female_color = "#ee7a87"
    male_color = "#4682b4"


    plt.barh(y=population_df["Age"], width=population_df["Female_Width"], color="#ee7a87", label="Female");
    plt.barh(y=population_df["Age"], width=population_df["Male_Width"], left=population_df["Male_Left"],
             color="#4682b4", label="Male");

    plt.text(-5, 17, "Male", fontsize=12.5, fontweight="bold");
    plt.text(4, 17, "Female", fontsize=12.5, fontweight="bold");

    for idx in range(len(population_df)):
        plt.text(x=population_df["Male_Left"][idx]-0.1, y=idx, s="{} %".format(population_df["Male"][idx]),
                 ha="right", va="center",
                 fontsize=7.5, color="#4682b4");
        plt.text(x=population_df["Female_Width"][idx]+0.1, y=idx, s="{} %".format(population_df["Female"][idx]),
                 ha="left", va="center",
                 fontsize=7.5, color="#ee7a87");

    plt.xlim(-7,7);
    #plt.xticks(range(-7,8), ["{} %".format(i) for i in range(-7,8)]);
    plt.xticks(range(-7,8), ["{}".format(abs(i)) for i in range(-7,8)]);

    plt.legend(loc="best");

    plt.xlabel("Percent (%)", fontsize=8, fontweight="bold")
    plt.ylabel("Age Range", fontsize=8, fontweight="bold")
    plt.title("US Population Pyramid Chart", loc="left", pad=20, fontsize=12.5, fontweight="bold");

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
        PopulationPyramid()


except Exception:
    import traceback
    print(traceback.format_exc())


