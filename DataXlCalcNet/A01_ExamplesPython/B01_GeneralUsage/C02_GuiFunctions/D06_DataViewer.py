from xlcalcnet import gui


try:
    gui.dataviewer()


except Exception:
    import traceback
    print(traceback.format_exc())


