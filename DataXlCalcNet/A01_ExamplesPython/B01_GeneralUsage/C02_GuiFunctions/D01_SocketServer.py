from xlcalcnet import gui


try:
    gui.socketserver()


except Exception:
    import traceback
    print(traceback.format_exc())


