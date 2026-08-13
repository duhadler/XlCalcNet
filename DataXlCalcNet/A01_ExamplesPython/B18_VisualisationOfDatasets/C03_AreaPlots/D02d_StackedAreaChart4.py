
# See: https://python-graph-gallery.com/web-stacked-line-chart-with-labels/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import seaborn as sns
import pandas as pd
import matplotlib.pyplot as plt
from scipy.interpolate import make_interp_spline
from PIL import Image # Open the image
import matplotlib.cm as cm # Add annotations (lines and points)



def StackedAreaChart4(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'StackedAreaChart4'
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

    # Create a pivot table to reshape the data for stacked area chart
    pivot_df = df.pivot(index='year', columns='country', values='total_wealth')

    # Define custom colors for the countries
    custom_colors = ["#003f5c","#2f4b7c","#665191","#a05195","#d45087","#f95d6a","#ff7c43","#ffa600"]

    # Define the desired order of countries
    desired_order = ["United States", "China", "Japan", "Germany", "United Kingdom", "France", "India", "Other"]

    # Reorder the columns of the pivot_df and custom_colors list
    pivot_df = pivot_df[desired_order]

    # Smooth the lines using spline interpolation
    x_smooth = np.linspace(pivot_df.index.min(), pivot_df.index.max(), 300)
    pivot_smooth = pd.DataFrame({country: make_interp_spline(pivot_df.index, pivot_df[country])(x_smooth)
                                 for country in pivot_df.columns})

    # Plot the stacked area chart with smoothing and custom colors
    plt.figure(figsize=(8, 8))  # Set the figure size
    plt.stackplot(x_smooth, pivot_smooth.values.T, labels=pivot_smooth.columns, colors=custom_colors)

    # `plt.gca()` function is used to obtain a reference to the current axes on which you plot your data
    ax = plt.gca()

    # Annotations for the values per year
    def add_annotations_year(year):
        """
        Input: a year
        Apply: add to the graph the total wealth of all countries at a given date
               and a line from the bottom of the graph to the total value of wealth
        """
        
        # Calculate total amount of wealth at a given year
        y_end = df[df["year"]==year]["total_wealth"].sum()
        
        # Set values in areas where the graph does not appear
        # Special case for 2021: we put it on the left instead of upper the line
        if year==2021:
            modif_xaxis = -3.3
            modif_yaxis = 20000
        else:
            modif_xaxis = -1.5
            modif_yaxis = 26000
        
        # Add the values, with a specific position, in bold, black and a fontsize of 10
        plt.text(year+modif_xaxis,
                 y_end+modif_yaxis,
                 f'${y_end}M',
                 fontsize=10,
                 color='black',
                 fontweight = 'bold')
        
        # Add line 
        ax.plot([year, year], # x-axis position
                [0, y_end*1.05], # y-axis position (*1.05 is used to make a it little bit longer)
                color='black', # Color
                linewidth=1) # Width of the line
        
        # Add a point at the top of the line
        ax.plot(year, # x-axis position
                y_end*1.05, # y-axis position (*1.05 is used to make a it little bit longer)
                marker='o', # Style of the point
                markersize=5, # Size of the point
                color='black') # Color

    # Add the line and the values for each of the following years
    for year in [2000,2005,2010,2015,2021]:
        add_annotations_year(year)
        
    # Annotations for the values per country
    def add_annotations_country(country, value_placement, amount, color):
        """
        Adds an annotation to a plot at a specific location with information about a country's amount in millions.

        Parameters:
            country (str): The name of the country for which the annotation is being added.
            value_placement (float): The vertical position where the annotation will be placed on the plot.
            amount (float): The amount in millions that will be displayed in the annotation.
            color (str): The color of the annotation text.
        """
        plt.text(2021.5, value_placement, f'{country} ${amount}M', fontsize=10, color=color, fontweight='bold')

    # We manually define the labels, values and position that will be displayed on the right of the graph
    countries = ['Rest of the world', 'India', 'France', 'UK', 'Germany', 'Japan', 'China', 'USA']
    values_placement = [400000, 310000, 295000, 275000, 260000, 240000, 180000, 70000]
    amounts = [142841, 14225, 16159, 16261, 17489, 25692, 85107, 145793]
    custom_colors.reverse() # Makes sure the colors match the country concerned

    # Iterate over all countries and add the name with the right value and color
    for country, value, amount, color in zip(countries, values_placement, amounts, custom_colors):
        add_annotations_country(country, value, amount, color)

    # Title of our graph 
    plt.text(2000, 320000,
             'Aggregated \nHousehold \nWealth', # Title ('\n' allows you to go to the line)
             fontsize=40, # High font size for style
             color='black',
             fontweight = 'bold')

    # Credits and data information
    plt.text(2000, -50000, 'Data:', fontsize=8, color='black', fontweight = 'bold')
    plt.text(2001.4, -50000, 'James Davies, Rodrigo Lluberas and Anthony Shorrocks, Credit Suisse Global Wealth Databook 2022', fontsize=8, color='black')
    plt.text(2000, -63000, 'Design:', fontsize=8, color='black', fontweight = 'bold')
    plt.text(2001.9, -63000, 'Gilbert Fontana', fontsize=8, color='black')


    ## Add github and twitter credentials
    #add_logo("github.png", "gilbertfontana", 0.155, -0.03, 0.03)
    #add_logo("twitter.png", "GilbertFontana", 0.16, -0.06, 0.02)

    # Remove the y-axis frame (left, right and top spines)
    ax.spines['left'].set_visible(False)
    ax.spines['right'].set_visible(False)
    ax.spines['top'].set_visible(False)

    # Remove the ticks and labels on the y-axis
    ax.tick_params(left=False, labelleft=False)
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
        StackedAreaChart4()


except Exception:
    import traceback
    print(traceback.format_exc())



