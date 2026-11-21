from xlcalcnet import aflib


def DemoAflintlib():
    res = aflib.test_add(1.2, 2.4)
    print('res = aflib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoAflintlib()



except Exception:
    import traceback
    print(traceback.format_exc())
