from xlcalcnet import elib


def DemoElib():
    res = elib.test_add(1.2, 2.4)
    print('res = elib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoElib()



except Exception:
    import traceback
    print(traceback.format_exc())
