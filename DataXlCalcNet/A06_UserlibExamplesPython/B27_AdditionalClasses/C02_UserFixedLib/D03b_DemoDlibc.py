from xlcalcnet import dlibc


def DemoDlibc():
    res = dlibc.test_add(1.2+3.1j, 2.4+1.7j)
    print('res = dlibc.test_add(1.2+3.1j, 2.4+1.7j):', res)


try:
    if __name__ == '__main__':
        DemoDlibc()



except Exception:
    import traceback
    print(traceback.format_exc())
