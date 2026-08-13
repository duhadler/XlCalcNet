from xlcalcnet import mflibc


def DemoMflintlibc():
    res = mflibc.test_add(1.2+3.1j, 2.4+1.7j)
    print('res = mflibc.test_add(1.2+3.1j, 2.4+1.7j):', res)


try:
    if __name__ == '__main__':
        DemoMflintlibc()



except Exception:
    import traceback
    print(traceback.format_exc())
