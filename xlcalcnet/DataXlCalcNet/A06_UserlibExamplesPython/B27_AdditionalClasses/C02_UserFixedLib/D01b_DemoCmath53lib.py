from xlcalcnet import m53libc


def DemoCm53lib():
    res = m53libc.test_add(1.2+3.1j, 2.4+1.7j)
    print('res = m53libc.test_add(1.2+3.1j, 2.4+1.7j):', res)


try:
    if __name__ == '__main__':
        DemoCm53lib()



except Exception:
    import traceback
    print(traceback.format_exc())
