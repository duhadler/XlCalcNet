from xlcalcnet import dflib


def DemoDflintlib():
    res = dflib.test_add(1.2, 2.4)
    print('res = dflib.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoDflintlib()



except Exception:
    import traceback
    print(traceback.format_exc())
