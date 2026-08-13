
# See: https://python-graph-gallery.com/web-multiple-lines-and-panels/

from xlcalcnet import gui
from pathlib import Path
import os
from functools import reduce

import numpy as np
import matplotlib
import matplotlib.pyplot as plt

from flexitext import flexitext
from scipy.special import expit




def MultipleLinesAndPanels2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MultipleLinesAndPanels2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    class Probabilities:
        def __init__(self, grid, auth, responses, programs):
            self.grid = grid
            self.auth = auth
            self.responses = responses
            self.programs = programs

        def compute(self, j):
            eta = self.grid * self._auth_coef() + self._program_coef(j)
            n_responses = len(self.responses["mean"]) + 1
            probs = [0] * n_responses
            for i in range(n_responses):
                if i == 0:
                    response = self._response_coef(i)
                    probs[i] = expit(response - eta)
                elif i < n_responses - 1:
                    response = self._response_coef(i)
                    response_previous = self._response_coef(i - 1)
                    probs[i] = expit(response - eta) - \
                        expit(response_previous - eta)
                else:
                    probs[i] = 1 - reduce(lambda a, b: a + b, probs[:-1])

            return probs

        def _auth_coef(self):
            mean = self.auth["mean"]
            sd = self.auth["sd"]
            return np.random.normal(mean, sd)

        def _response_coef(self, idx):
            mean = self.responses["mean"][idx]
            sd = self.responses["sd"][idx]
            return np.random.normal(mean, sd)

        def _program_coef(self, idx):
            mean = self.programs["mean"][idx]
            sd = self.programs["sd"][idx]
            return np.random.normal(mean, sd)


    x = np.linspace(-3, 3, 500)

    auth = {
        "mean": 0.21,
        "sd": 0.06
    }

    responses = {
        "mean": [-0.71, 0.5, 1.28],
        "sd": [0.05] * 3
    }

    programs = {
        "mean": [0, 0.23, 0.39, 0.69, 0.97],
        "sd": [0] + [0.09] * 4
    }

    probabilities = Probabilities(x, auth, responses, programs)

    plasma_colormap = matplotlib.colormaps.get_cmap("plasma")
    COLORS = [plasma_colormap(x) for x in np.linspace(0.8, 0.15, num=4)]
    COLORS = [matplotlib.colors.to_hex(color) for color in COLORS]




    # This function is basically the code we wrote in the chunk above
    def adjust_axis_layout(ax, title):
        ax.tick_params(axis="both", which="both", length=0)

        ax.set_xticks([-2, 0, 2], minor=False)
        ax.set_xticklabels([-2, 0, 2], minor=False, size=11, color="0.3")
        ax.set_xticks([-3, -1, 1, 3], minor=True)
        ax.set_xlim(-3.1, 3.1)
        ax.xaxis.grid(True, which="both", color="#cccccc", alpha=0.8, lw=0.5)

        ax.set_yticks([0.2, 0.4, 0.6], minor=False)
        ax.set_yticklabels([0.2, 0.4, 0.6], minor=False, size=11, color="0.3")
        ax.set_yticks([0.1, 0.3, 0.5, 0.7], minor=True)
        ax.yaxis.grid(True, which="both", color="#cccccc", alpha=0.8, lw=0.5)

        for spine in ["top", "right", "bottom", "left"]:
            ax.spines[spine].set_visible(False)

        ax.set_title(title, weight=500, size=14, loc="left")

        return ax


    # Initialize layout. Note we're using 1 row and 5 columns.
    fig, axes = plt.subplots(1, 5, figsize=(14, 7), sharey=True)

    # Set figure background color
    fig.set_facecolor("white")

    # Iterate over panels (programs)
    for j in range(5):
        # Select axis corresponding to the program
        ax = axes[j]
        # Create 100 replicates for each group
        for _ in range(100):
            probs = probabilities.compute(j)
            for prob, color in zip(probs, COLORS):
                ax.plot(x, prob, color=color, alpha=0.2, lw=1.2)

        # Note the title is unique for each panel/program
        adjust_axis_layout(ax, f"Program {j + 1}")

    # Make room for the title on the top of the figure
    fig.subplots_adjust(top=0.75)

    # Create formatted string that is going to be passed to flexitext()
    title = (
        "<size:20, weight:bold>People high in authoritarianism see more fraud across the board</>\n\n"
        "<size:15>Lines are the predicted fraction of people saying fraud is "
        f"<color:{COLORS[3]}, weight:bold>very common</>, <color:{COLORS[2]}, weight:bold>somewhat common</>, "
        f"<color:{COLORS[1]}, weight:bold>not very\ncommon</>, and <color:{COLORS[0]}, weight:bold>not common at all</></>"
    )

    # Add text with flexitext()
    # xycoords="figure fraction" means the coordinates we pass (x=0.125 and y=0.825)
    # are specified in terms of the figure, not the axis.
    flexitext(0.125, 0.825, title, va="bottom",
              xycoords="figure fraction", ax=axes[0])

    #fig.tight_layout()


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
        MultipleLinesAndPanels2()


except Exception:
    import traceback
    print(traceback.format_exc())


