from xlcalcnet import qlib


def DemoQlib():
    res = qlib.test_add(1.2, 2.4)
    print('res = qlib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoQlib()



except Exception:
    import traceback
    print(traceback.format_exc())
