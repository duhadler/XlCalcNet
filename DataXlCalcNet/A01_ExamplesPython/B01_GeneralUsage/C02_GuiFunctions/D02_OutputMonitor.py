from xlcalcnet import gui


try:
    gui.outputmonitor()


except Exception:
    import traceback
    print(traceback.format_exc())


