from xlcalcnet import qflibc


def DemoQflintlibc():
    res = qflibc.test_add(1.2+3.1j, 2.4+1.7j)
    print('res = qflibc.test_add(1.2+3.1j, 2.4+1.7j):', res)


try:
    if __name__ == '__main__':
        DemoQflintlibc()



except Exception:
    import traceback
    print(traceback.format_exc())
