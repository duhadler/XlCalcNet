from xlcalcnet import gui


try:
    gui.plot2d()


except Exception:
    import traceback
    print(traceback.format_exc())


