from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt

#See also: https://en.wikipedia.org/wiki/Sierpi%C5%84ski_carpet
#See also: https://medium.com/@mathcube7/visualizing-the-sierpinski-carpet-in-python-cec371847f3d


def SierpinskiCarpet(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SierpinskiCarpet'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    def sierpinski_carpet(depth):
        if depth == 0: return np.ones((1, 1))
        s = sierpinski_carpet(depth - 1)
        c = np.zeros_like(s)
        return np.block([[s, s, s], [s, c, s], [s, s, s]])

    #n = 3
    n = 5
    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeX))
    ax.set_axis_off()
    carpet = sierpinski_carpet(depth=n)
    plt.imshow(carpet, cmap='binary')
    ax.set_title(Title)

# Start of output choices
    if (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        plt.savefig(FullPath + '.' + OutputMode,  bbox_inches='tight')
    plt.close('all')


try:
    if __name__ == '__main__':
        SierpinskiCarpet()

except Exception:
    import traceback
    print(traceback.format_exc())


