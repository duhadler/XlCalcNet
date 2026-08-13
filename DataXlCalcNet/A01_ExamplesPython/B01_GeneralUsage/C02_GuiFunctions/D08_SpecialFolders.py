from xlcalcnet import gui

def demo_folders():
    s = gui.get_local_appdata()
    print('Local AppData: ', s)
    s = gui.get_local_appdata_xlcalcnet()
    print('Local AppData XlCalcNet: ', s)
    s = gui.get_my_documents()
    print('Documents: ', s)



try:
    demo_folders()


except Exception:
    import traceback
    print(traceback.format_exc())


