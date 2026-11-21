from xlcalcnet import mlib


def DemoMlib():
    res = mlib.test_add(1.2, 2.4)
    print('res = mlib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoMlib()



except Exception:
    import traceback
    print(traceback.format_exc())
