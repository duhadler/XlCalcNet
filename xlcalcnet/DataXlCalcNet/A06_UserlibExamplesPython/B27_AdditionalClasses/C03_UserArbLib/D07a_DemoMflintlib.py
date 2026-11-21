from xlcalcnet import mflib


def DemoMflintlib():
    res = mflib.test_add(1.2, 2.4)
    print('res = mflib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoMflintlib()



except Exception:
    import traceback
    print(traceback.format_exc())
