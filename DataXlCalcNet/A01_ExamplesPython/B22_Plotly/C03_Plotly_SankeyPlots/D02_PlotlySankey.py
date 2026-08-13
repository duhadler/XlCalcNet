
# See https://medium.com/@twelsh37/further-adventures-in-plotly-sankey-diagrams-fdba9ff08af6
from xlcalcnet import gui
import os, re

import plotly.graph_objects as go


def Sankey2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Sankey2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 10
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments



    # Setup our colours
    color_link = ['#000000', '#FFFF00', '#1CE6FF', '#FF34FF', '#FF4A46',
                 '#008941', '#006FA6', '#A30059','#FFDBE5', '#7A4900', 
                 '#0000A6', '#63FFAC', '#B79762', '#004D43', '#8FB0FF',
                 '#997D87', '#5A0007', '#809693', '#FEFFE6', '#1B4400', 
                 '#4FC601', '#3B5DFF', '#4A3B53', '#FF2F80', '#61615A',
                 '#BA0900', '#6B7900', '#00C2A0', '#FFAA92', '#FF90C9',
                 '#B903AA', '#D16100', '#DDEFFF', '#000035', '#7B4F4B',                
                 '#A1C299', '#300018', '#0AA6D8', '#013349', '#00846F',
                 '#372101', '#FFB500', '#C2FFED', '#A079BF', '#CC0744',
                 '#C0B9B2', '#C2FF99', '#001E09', '#00489C', '#6F0062', 
                 '#0CBD66', '#EEC3FF', '#456D75', '#B77B68', '#7A87A1',
                 '#788D66', '#885578', '#FAD09F', '#FF8A9A', '#D157A0',
                 '#BEC459', '#456648', '#0086ED', '#886F4C', '#34362D', 
                 '#B4A8BD', '#00A6AA', '#452C2C', '#636375', '#A3C8C9', 
                 '#FF913F', '#938A81', '#575329', '#00FECF', '#B05B6F',
                 '#8CD0FF', '#3B9700', '#04F757', '#C8A1A1', '#1E6E00',
                 '#7900D7', '#A77500', '#6367A9', '#A05837', '#6B002C',
                 '#772600', '#D790FF', '#9B9700', '#549E79', '#FFF69F', 
                 '#201625', '#72418F', '#BC23FF', '#99ADC0', '#3A2465',
                 '#922329', '#5B4534', '#FDE8DC', '#404E55', '#0089A3',
                 '#CB7E98', '#A4E804', '#324E72', '#6A3A4C'
                 ]

    label = ['Google Search', 
             'YouTube',
             'AdMob',
             'Google Play',
             'Google Cloud',
             'Other',
             'Ad Revenue',
             'Revenue',
             'Gross Profit',
             'Cost of Revenues',
             'Operating Profit',
             'Operating Expenses',
             'TAC',
             'Others',
             'Net Profit',
             'Tax',
             'Other',
             'R&D',
             'S&M',
             'G&A'
            ]

    # Node Colors - From CSS Colors - https://www.quackit.com/css/css_color_codes.cfm
    color_for_nodes =['steelblue', 'steelblue', 'steelblue', 'gold', 'gold', 'gold', 'steelblue','steelblue','green', 'firebrick',
                      'green', 'firebrick', 'firebrick','firebrick', 'green', 'firebrick','firebrick', 'firebrick', 'firebrick',
                      'firebrick', 'firebrick']

    # Link Colours
    color_for_links =['LightSkyBlue', 'LightSkyBlue', 'LightSkyBlue', 'goldenrod', 'goldenrod', 'goldenrod', 'LightSkyBlue',
                      'lightgreen', 'PaleVioletRed', 'lightgreen', 'PaleVioletRed', 'PaleVioletRed', 'PaleVioletRed', 'lightgreen', 
                      'PaleVioletRed', 'PaleVioletRed', 'PaleVioletRed', 'PaleVioletRed', 'PaleVioletRed']

    # Data 
    source = [0, 1, 2, 3, 4, 5, 6, 7, 7, 8, 8, 9, 9, 10, 10, 10, 11, 11, 11] 
    target = [6, 6, 6, 7, 7, 7, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
    value = [39.5, 7.1, 7.9, 6.9, 6.9, 0.88, 54.5, 37.9, 31.2, 17.1, 20.8, 11.8,
              19.3, 13.9, 2.3, 0.9, 10.3, 6.9, 3.6 ]

    link = dict(source=source, target=target, value=value, color=color_link)
    node = dict(label = label, pad=35, thickness=20)
    data = go.Sankey(link=link, node=node)


    # Set our X and Y co-ords - https://stackoverflow.com/questions/71099380/plotly-sankey-diagram-how-to-set-position-of-nodes-explicit-x-and-y-values-don
    x = [0.12, 0.12, 0.12, 0.25, 0.30, 0.35, 0.35, 0.5, 0.6, 0.6,  0.7, 0.7, 0.7, 0.7, 0.90, 0.90, 0.90, 0.90, 0.90, 0.90]
    y = [0.20, 0.42, 0.55, 0.70, 0.85, 0.95, 0.30, 0.40, 0.25, 0.70, 0.1, 0.40, 0.75, 0.90, 0.0, 0.15, 0.30, 0.45, 0.60, 0.75]
    x = [.001 if v==0 else .999 if v==1 else v for v in x]
    y = [.001 if v==0 else .999 if v==1 else v for v in y]

    fig = go.Figure(data=[go.Sankey(
        # This makes the labels invisible but keeps the text in the hovertemplate 
        # https://stackoverflow.com/questions/68276322/remove-text-labels-in-plotly-sankey-diagram-but-keep-the-data-when-hovering-pl
        textfont=dict(color="rgba(0,0,0,0)", size=1),
        node = dict(
            pad = 35,
            line = dict(color = "white", width = 1),
            label = label,
            x = x,
            y = y
        ),
        link = dict(
            source = source,
            target = target,
            value = value
            ))])





    # Apply node and link colour choices
    fig.update_traces(node_color = color_for_nodes,
                      link_color = color_for_links)

    # Add annotations to our chart - https://stackoverflow.com/questions/69724212/plotly-sankey-diagram-positioning
    # Google Search
    fig.add_annotation(dict(font=dict(color="black",size=12), x=0.01, y=0.85, showarrow=False, text='<b>Search<br>advertising</b>'))
    fig.add_annotation(dict(font=dict(color="steelblue",size=12), x=0.1, y=1, showarrow=False, text='<b>$39.5B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.1, y=0.95, showarrow=False, text='+4% Y/Y'))

    # Youtube
    fig.add_annotation(dict(font=dict(color="black",size=12), x=0.01, y=0.58, showarrow=False, text='<b>YouTube</b>'))
    fig.add_annotation(dict(font=dict(color="steelblue",size=12), x=0.1, y=0.70, showarrow=False, text='<b>$7.1B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.1, y=0.63, showarrow=False, text='(2%)Y/Y'))

    # Google AdMob
    fig.add_annotation(dict(font=dict(color="black",size=12), x=0.01, y=0.45, showarrow=False, text='<b>Google<br>AdMob</b>'))
    fig.add_annotation(dict(font=dict(color="steelblue",size=12), x=0.1, y=0.53, showarrow=False, text='<b>$7.9B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.1, y=0.49, showarrow=False, text='(2%)Y/Y'))

    # Google play
    fig.add_annotation(dict(font=dict(color="black",size=12), x=0.17, y=0.26, showarrow=False, text='<b>Google<br>Play</b>'))
    fig.add_annotation(dict(font=dict(color="goldenrod",size=12), x=0.23, y=0.40, showarrow=False, text='<b>$6.9B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.23, y=0.36, showarrow=False, text='+2% Y/Y'))

    # Google Cloud
    fig.add_annotation(dict(font=dict(color="black",size=12), x=0.21, y=0.10, showarrow=False, text='<b>Google<br>Cloud</b>'))
    fig.add_annotation(dict(font=dict(color="goldenrod",size=12), x=0.29, y=0.20, showarrow=False, text='<b>$6.9B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.29, y=0.17, showarrow=False, text='+38% Y/Y'))

    # Google Cloud
    fig.add_annotation(dict(font=dict(color="black",size=12), x=0.28, y=0.03, showarrow=False, text='<b>Other</b>'))
    fig.add_annotation(dict(font=dict(color="goldenrod",size=12), x=0.33, y=0.07, showarrow=False, text='<b>$0.8B</b>'))

    # Ad Revenue
    fig.add_annotation(dict(font=dict(color="steelblue",size=12), x=0.3, y=0.96, showarrow=False, text='<b>Ad Revenue</b>'))
    fig.add_annotation(dict(font=dict(color="steelblue",size=12), x=0.35, y=0.92, showarrow=False, text='<b>$54.5B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.35, y=0.88, showarrow=False, text='+3% Y/Y'))

    # Revenue
    fig.add_annotation(dict(font=dict(color="steelblue",size=12), x=0.5, y=0.90, showarrow=False, text='<b>Revenue</b>'))
    fig.add_annotation(dict(font=dict(color="steelblue",size=12), x=0.5, y=0.86, showarrow=False, text='<b>$69.1B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.5, y=0.82, showarrow=False, text='+6% Y/Y'))

    # Gross Profit
    fig.add_annotation(dict(font=dict(color="green",size=12), x=0.6, y=0.98, showarrow=False, text='<b>Gross Profit</b>'))
    fig.add_annotation(dict(font=dict(color="green",size=12), x=0.6, y=0.94, showarrow=False, text='<b>$69.1B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.6, y=0.90, showarrow=False, text='+6% Y/Y'))

    # Operating Profit
    fig.add_annotation(dict(font=dict(color="green",size=12), x=0.77, y=1.1, showarrow=False, text='<b>Operating Profit</b>'))
    fig.add_annotation(dict(font=dict(color="green",size=12), x=0.73, y=1.05, showarrow=False, text='<b>$69.1B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.73, y=1.0, showarrow=False, text='+6% Y/Y'))

    # Net Profit
    fig.add_annotation(dict(font=dict(color="green",size=12), x=0.99, y=1.09, showarrow=False, text='<b>Net Profit</b>'))
    fig.add_annotation(dict(font=dict(color="green",size=12), x=0.98, y=1.05, showarrow=False, text='<b>$13.9B</b>'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.98, y=1.0, showarrow=False, text='20% Margin'))
    fig.add_annotation(dict(font=dict(color="black",size=8), x=0.98, y=0.97, showarrow=False, text='(9pp) Y/Y'))

    # Operating Profit Tax
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.97, y=0.9, showarrow=False, text='<b>Tax</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.98, y=0.85, showarrow=False, text='<b>$2.3B</b>'))

    # Operating Profit Other
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.98, y=0.75, showarrow=False, text='<b>Other</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.98, y=0.70, showarrow=False, text='<b>$0.9B</b>'))

    # Operating Profit R&D
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.98, y=0.58, showarrow=False, text='<b>R&D</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.99, y=0.53, showarrow=False, text='<b>$10.3B</b>'))

    # Operating Profit S&M
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.98, y=0.43, showarrow=False, text='<b>S&M</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.985, y=0.38, showarrow=False, text='<b>$6.9B</b>'))

    # Operating Profit G&A
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.98, y=0.25, showarrow=False, text='<b>G&A</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.985, y=0.20, showarrow=False, text='<b>$3.6B</b>'))

    # Operating Expenses
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.74, y=0.49, showarrow=False, text='<b>Operating<br>expenses</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.732, y=0.42, showarrow=False, text='<b>$20.8B</b>'))

    # Cost of Revenues
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.6, y=0.12, showarrow=False, text='<b>Cost of<br>Revenues</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.6, y=0.07, showarrow=False, text='<b>$31.2B</b>'))

    # TAC
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.765, y=0.25, showarrow=False, text='<b>TAC</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.78, y=0.21, showarrow=False, text='<b>$11.8B</b>'))

    # Cost of Revenues - Others
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.78, y=0.10, showarrow=False, text='<b>Others</b>'))
    fig.add_annotation(dict(font=dict(color="maroon",size=12), x=0.78, y=0.06, showarrow=False, text='<b>$19.3B</b>'))

#    fig.show()

    # Update our chart
    fig.update_layout(
        hovermode='x',
        width=FigSizeX * 100, height=FigSizeY * 100,
        title="<span style='font-size:16px;color:steelblue;'><b>Alphabet Q3 FY22 Income Statement</b></span>",
        font=dict(size=10, color='white'),
        paper_bgcolor='#F8F8FF'
    )


# Start of output choices
    if (OutputMode == 'gui'):
        fig.show()
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        fig.write_image(FullPath + '.' + OutputMode)


try:
    if __name__ == '__main__':
        Sankey2()


except Exception:
    import traceback
    print(traceback.format_exc())






