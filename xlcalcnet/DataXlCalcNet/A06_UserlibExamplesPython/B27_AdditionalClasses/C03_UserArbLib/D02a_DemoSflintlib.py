from xlcalcnet import sflib


def DemoSflintlib():
    res = sflib.test_add(1.2, 2.4)
    print('res = sflib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoSflintlib()



except Exception:
    import traceback
    print(traceback.format_exc())
