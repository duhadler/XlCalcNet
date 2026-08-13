from xlcalcnet import aflibc


def DemoAflintlibc():
    res = aflibc.test_add(1.2, 2.4)
    print('res = aflibc.test_add(1.2, 2.4):', res)


try:
    if __name__ == '__main__':
        DemoAflintlibc()



except Exception:
    import traceback
    print(traceback.format_exc())
