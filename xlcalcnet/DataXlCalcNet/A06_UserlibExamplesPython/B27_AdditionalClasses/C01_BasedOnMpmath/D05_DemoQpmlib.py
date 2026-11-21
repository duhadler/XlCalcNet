from xlcalcnet import qpm, qpmlib


def demoqpmlib():

    res = qpmlib.abs(-4)
    print('res = qpmlib.abs(-4):', res)


try:
    if __name__ == '__main__':
        demoqpmlib()



except Exception:
    import traceback
    print(traceback.format_exc())
