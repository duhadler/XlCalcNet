
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




def MultipleLinesAndPanels1(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MultipleLinesAndPanels1'
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


    # Initialize chart
    fig, ax = plt.subplots(figsize=(8, 6))

    # Create 100 lines for each group. We don't care about the loop value, so we use the underscore.
    for _ in range(100):
        # The 0 means we create values for the first panel
        probs = probabilities.compute(0)
        # Now loop over the arrays in 'y', using a different color for each group.
        for prob, color in zip(probs, COLORS):
            ax.plot(x, prob, color=color, alpha=0.2, lw=1.5)


    # Remove major and minor tick marks on both axis
    ax.tick_params(axis="both", which="both", length=0)

    # Set major and minor ticks for the x axis.
    # These are used to draw the grid lines.
    # Only the major ticks have a tick label.
    ax.set_xticks([-2, 0, 2], minor=False)
    ax.set_xticklabels([-2, 0, 2], minor=False, size=11, color="0.3")
    ax.set_xticks([-3, -1, 1, 3], minor=True)

    # Set custom limit for x axis
    ax.set_xlim(-3.1, 3.1)

    # Add grid lines for x axis
    ax.xaxis.grid(True, which="both", color="#cccccc", alpha=0.8, lw=0.5)


    # Set major and minor ticks for the y axis.
    # The same logic than above.
    ax.set_yticks([0.2, 0.4, 0.6], minor=False)
    ax.set_yticklabels([0.2, 0.4, 0.6], minor=False, size=11, color="0.3")
    ax.set_yticks([0.1, 0.3, 0.5, 0.7], minor=True)

    # Add grid lines for x axis
    ax.yaxis.grid(True, which="both", color="#cccccc", alpha=0.8, lw=0.5)


    # Remove all the spines
    for spine in ["top", "right", "bottom", "left"]:
        ax.spines[spine].set_visible(False)

    # Add title
    # Note this does not use the `.set_title()` method, but just a normal `.text()`
    # This is to gain more control of the position.
    # `transform=ax.transAxes` means the coordintes are in terms of the Axis and not the data
    ax.text(0, 1.025, "Program 1", weight="bold", size=18, transform=ax.transAxes)




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
        MultipleLinesAndPanels1()


except Exception:
    import traceback
    print(traceback.format_exc())


