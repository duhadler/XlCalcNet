from xlcalcnet import dlib


def DemoDlib():
    res = dlib.test_add(1.2, 2.4)
    print('res = dlib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoDlib()



except Exception:
    import traceback
    print(traceback.format_exc())
