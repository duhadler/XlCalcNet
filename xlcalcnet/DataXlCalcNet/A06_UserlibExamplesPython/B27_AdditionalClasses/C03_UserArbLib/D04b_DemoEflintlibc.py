from xlcalcnet import eflibc


def DemoEflintlibc():
    res = eflibc.test_add(1.2+3.1j, 2.4+1.7j)
    print('res = eflibc.test_add(1.2+3.1j, 2.4+1.7j):', res)


try:
    if __name__ == '__main__':
        DemoEflintlibc()



except Exception:
    import traceback
    print(traceback.format_exc())
