
# See: https://python-graph-gallery.com/570-custom-streamchart/


from xlcalcnet import gui
from pathlib import Path
import os
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

from scipy.interpolate import interp1d



def Steamgraph4(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Steamgraph4'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    url = 'https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/master/static/data/mutant_moneyball.csv'
    df = pd.read_csv(url)

    def format_name(s):
        if " " in s:
            return s
        formatted_string = ""
        for i, char in enumerate(s):
            if char.isupper() and i != 0:
                formatted_string += " " + char
            else:
                formatted_string += char
        if formatted_string:
            formatted_string = formatted_string[0].upper() + formatted_string[1:]

        return formatted_string


    df['Member'] = df['Member'].apply(format_name)

    df = df[['Member', 'TotalIssues60s', 'TotalIssues70s',
             'TotalIssues80s', 'TotalIssues90s']]
    df.set_index('Member', inplace=True)

    # transpose the dataframe
    df_transposed = df.T

    decades = ['1960s', '1970s', '1980s', '1990s']  # values of the x-axis
    members = df_transposed.columns  # name of the x-mens for the legend
    issues_list = df_transposed.T.values.tolist()  # values of the x-men

    print(df_transposed)


    decades = ['1960s', '1970s', '1980s', '1990s']  # values of the x-axis
    members = df_transposed.columns  # name of the x-mens for the legend

    total_issues_per_member = np.sum(issues_list, axis=1)
    sorted_indices = np.argsort(total_issues_per_member)
    sorted_issues_list = np.array(issues_list)[sorted_indices]


    # instead of 4 date points, we will use 40
    decadesforsmooth = [1960, 1970, 1980, 1990]
    new_decades = np.linspace(min(decadesforsmooth), max(
        decadesforsmooth), len(decadesforsmooth) * 10)

    # interpolating each member's issues list for the new_decades
    smoothed_issues_list = []
    for issues in sorted_issues_list:
        interp_func = interp1d(
            decadesforsmooth,
            issues,
            kind='quadratic'
        )
        smoothed_issues = interp_func(new_decades)
        smoothed_issues_list.append(smoothed_issues)


    # calculate the normalized totals
    total_issues_per_member = np.sum(issues_list, axis=1)
    normalized_totals = total_issues_per_member / np.max(total_issues_per_member)
    cmap = plt.cm.Reds
    colors = cmap(normalized_totals)

    # sort the members by total issues
    sorted_indices = np.argsort(total_issues_per_member)
    sorted_issues_list = np.array(issues_list)[sorted_indices]
    sorted_members = np.array(members)[sorted_indices]
    sorted_colors = colors[sorted_indices]
    sorted_issues_list = [sublist[:-1] for sublist in sorted_issues_list]

    # create the chart
    fig, ax = plt.subplots(figsize=(8, 6))
    ax.stackplot(
        new_decades,
        smoothed_issues_list,
        labels=sorted_members,
        colors=sorted_colors,
        edgecolor='black',
        linewidth=0.2,
        #baseline='wiggle'
    )

    # setting the title and labels
    ax.set_title(
        'Evolution of Total Issues per X-Men Member per Decade (60s-90s), Sorted by Total Issues')
    ax.set_ylabel('Total Issues')
    ax.set_xlabel('Decade')
    ax.legend(loc='upper left', bbox_to_anchor=(1, 1))

    # plotting
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
        Steamgraph4()


except Exception:
    import traceback
    print(traceback.format_exc())





