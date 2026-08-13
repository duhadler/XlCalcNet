from xlcalcnet import qflib


def DemoQflintlib():
    res = qflib.test_add(1.2, 2.4)
    print('res = qflib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoQflintlib()



except Exception:
    import traceback
    print(traceback.format_exc())
