from xlcalcnet import mpTK
import sys
import os

import ctypes   


def showtable(fname, title):
    #ctypes.windll.user32.MessageBoxW(0, fname, title, 1)

    app = mpTK.readwritecsv(fname, title)

    #gui.showcsvtable(fname, title)

    #os.remove(fname)

    app.mainloop()



try:
    print()
    #ctypes.windll.user32.MessageBoxW(0, sys.argv[1], sys.argv[2], 1)
    showtable(sys.argv[1], sys.argv[2])


except Exception:
    import traceback

    print(traceback.format_exc())


