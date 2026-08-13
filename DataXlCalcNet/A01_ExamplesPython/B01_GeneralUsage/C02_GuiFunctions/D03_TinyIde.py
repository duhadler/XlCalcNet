from xlcalcnet import gui


try:
    gui.tinyide()


except Exception:
    import traceback
    print(traceback.format_exc())


