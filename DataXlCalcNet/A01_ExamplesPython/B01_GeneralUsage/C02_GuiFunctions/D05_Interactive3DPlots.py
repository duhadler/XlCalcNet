from xlcalcnet import gui


try:
    gui.plot3d()


except Exception:
    import traceback
    print(traceback.format_exc())


