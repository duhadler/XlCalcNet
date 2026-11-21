from xlcalcnet import oflibc


def DemoOflintlibc():
    res = oflibc.test_add(1.2+3.1j, 2.4+1.7j)
    print('res = oflibc.test_add(1.2+3.1j, 2.4+1.7j):', res)


try:
    if __name__ == '__main__':
        DemoOflintlibc()



except Exception:
    import traceback
    print(traceback.format_exc())
