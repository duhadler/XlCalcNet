
import sys
import os
import matplotlib.pyplot as plt
import pickle
import ctypes

def showplot(fdumpname, fname):

    try:
        fig = pickle.load(open(fdumpname, 'rb'))
    except Exception:
        import traceback
        ctypes.windll.user32.MessageBoxW(0, traceback.format_exc(), "traceback", 1)

    os.remove(fdumpname)
    fig.canvas.manager.set_window_title(fname)
    plt.show()




try:
    print("START ShowPlt2")
##    ctypes.windll.user32.MessageBoxW(0, sys.argv[2], "Your title", 1)
    showplot(sys.argv[1], sys.argv[2])


except Exception:
    import traceback
    print(traceback.format_exc())


