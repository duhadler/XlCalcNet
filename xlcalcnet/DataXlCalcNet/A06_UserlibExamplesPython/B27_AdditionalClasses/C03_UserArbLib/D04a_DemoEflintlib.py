from xlcalcnet import eflib


def DemoEflintlib():
    res = eflib.test_add(1.2, 2.4)
    print('res = eflib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoEflintlib()



except Exception:
    import traceback
    print(traceback.format_exc())
