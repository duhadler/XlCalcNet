
# See: https://python-graph-gallery.com/web-population-pyramid/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd



def MarketingFunnel(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MarketingFunnel'
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


    url = "https://raw.githubusercontent.com/holtzy/the-python-graph-gallery/master/static/data/email_campaign_funnel.csv"

    # Original url (to be used in case the above one does not work)
    url = "https://raw.githubusercontent.com/selva86/datasets/master/email_campaign_funnel.csv"
    df = pd.read_csv(url)


    # Create a figure and axis with a specific size
    fig, ax = plt.subplots(figsize=(12, 8))

    # Define the column in the dataframe that represents the groups/categories
    group_col = 'Gender'

    # Determine the order of bars on the y-axis by unique values in the 'Stage' column and reversing the order
    order_of_bars = df.Stage.unique()[::-1]

    # Generate a list of colors for each group, using the Spectral colormap
    colors = [plt.cm.Spectral(i / float(len(df[group_col].unique()) - 1)) for i in range(len(df[group_col].unique()))]

    # Iterate through each group and plot a bar for each stage within that group
    for color, group in zip(colors, df[group_col].unique()):
        
        # Create a bar plot using Seaborn's barplot function
        sns.barplot(x='Users',  # Data for the width of bars
                    y='Stage',  # Data for the y-axis (stages of purchase)
                    data=df.loc[df[group_col] == group, :],  # Filter data for the current group
                    order=order_of_bars,  # Specify the order of stages on the y-axis
                    color=color,  # Assign a color to the bar
                    label=group,  # Assign a label for the plot legend
                    ax=ax,  # Specify the axis to plot on (previously created)
                   )

    # Set labels and title for the axes
    ax.set_xlabel("Users")  # X-axis label
    ax.set_ylabel("Stage of Purchase")  # Y-axis label
    ax.set_title("Population Pyramid of the Marketing Funnel", fontsize=22) # Plot title

    # Display the legend, which shows labels for the groups
    ax.legend()


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
        MarketingFunnel()


except Exception:
    import traceback
    print(traceback.format_exc())







