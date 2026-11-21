from xlcalcnet import sflibc


def DemoSflintlibc():
    res = sflibc.test_add(1.2+3.1j, 2.4+1.7j)
    print('res = sflibc.test_add(1.2+3.1j, 2.4+1.7j):', res)


try:
    if __name__ == '__main__':
        DemoSflintlibc()



except Exception:
    import traceback
    print(traceback.format_exc())
