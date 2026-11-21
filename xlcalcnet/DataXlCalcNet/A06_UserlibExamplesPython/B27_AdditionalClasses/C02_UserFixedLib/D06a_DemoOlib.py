from xlcalcnet import olib


def DemoOlib():
    res = olib.test_add(1.2, 2.4)
    print('res = olib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoOlib()



except Exception:
    import traceback
    print(traceback.format_exc())
