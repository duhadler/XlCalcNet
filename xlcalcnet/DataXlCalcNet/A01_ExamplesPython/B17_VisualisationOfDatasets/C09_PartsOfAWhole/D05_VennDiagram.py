
# See: https://python-graph-gallery.com/171-basic-venn-diagram-with-3-groups/
# See: https://sphinx-github-docs.readthedocs.io/en/latest/


from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import matplotlib.pyplot as plt
from matplotlib_venn import venn2, venn3, venn2_circles, venn3_circles



def VennDiagram(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'VennDiagram'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments



    ## Make the diagram
    #venn3(subsets = (10, 8, 22, 6,9,4,2))
    #plt.show()
    #
    #venn2(subsets = (3, 2, 1))
    #plt.show()
    #
    #venn3(subsets = (1, 1, 1, 2, 1, 2, 2), set_labels = ('Set1', 'Set2', 'Set3'))
    #plt.show()


    #plt.figure(figsize=(4,4))
    #v = venn3(subsets=(1, 1, 1, 1, 1, 1, 1), set_labels = ('A', 'B', 'C'))
    #v.get_patch_by_id('100').set_alpha(1.0)
    #v.get_patch_by_id('100').set_color('white')
    #v.get_label_by_id('100').set_text('Unknown')
    #v.get_label_by_id('A').set_text('Set "A"')
    #c = venn3_circles(subsets=(1, 1, 1, 1, 1, 1, 1), linestyle='dashed')
    #c[0].set_lw(1.0)
    #c[0].set_ls('dotted')
    #plt.title("Sample Venn diagram")
    #plt.annotate('Unknown set', xy=v.get_label_by_id('100').get_position() - np.array([0, 0.05]), xytext=(-70,-70),
    #             ha='center', textcoords='offset points', bbox=dict(boxstyle='round,pad=0.5', fc='gray', alpha=0.1),
    #             arrowprops=dict(arrowstyle='->', connectionstyle='arc3,rad=0.5',color='gray'))
    #fig = plt.gcf()
    #fig.tight_layout()
    #plt.show()


    #figure, axes = plt.subplots(2, 2)
    #venn2(subsets={'10': 1, '01': 1, '11': 1}, set_labels = ('A', 'B'), ax=axes[0][0])
    #venn2_circles((1, 2, 3), ax=axes[0][1])
    #venn3(subsets=(1, 1, 1, 1, 1, 1, 1), set_labels = ('A', 'B', 'C'), ax=axes[1][0])
    #venn3_circles({'001': 10, '100': 20, '010': 21, '110': 13, '011': 14}, ax=axes[1][1])
    #plt.show()

    set1 = set(['A', 'B', 'C', 'D'])
    set2 = set(['B', 'C', 'D', 'E'])
    set3 = set(['C', 'D',' E', 'F', 'G'])

    venn3([set1, set2, set3], ('Set1', 'Set2', 'Set3'))
    fig = plt.gcf()


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
        VennDiagram()


except Exception:
    import traceback
    print(traceback.format_exc())





