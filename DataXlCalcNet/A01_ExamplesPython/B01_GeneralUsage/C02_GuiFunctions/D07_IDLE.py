from xlcalcnet import gui


try:
    gui.idle()


except Exception:
    import traceback
    print(traceback.format_exc())


