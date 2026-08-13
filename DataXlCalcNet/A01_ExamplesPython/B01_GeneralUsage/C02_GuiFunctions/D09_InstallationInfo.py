from xlcalcnet import gui


def demo_installation_info():
    gui.info()
    print()
    print('has_gpm: ', gui.has_gpm)
    print('has_apm: ', gui.has_apm)
    print('has_xlcalcnet2: ', gui.has_xlcalcnet2)



try:
    demo_installation_info()


except Exception:
    import traceback
    print(traceback.format_exc())


