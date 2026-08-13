from xlcalcnet import oflib


def DemoOflintlib():
    res = oflib.test_add(1.2, 2.4)
    print('res = oflib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoOflintlib()



except Exception:
    import traceback
    print(traceback.format_exc())
