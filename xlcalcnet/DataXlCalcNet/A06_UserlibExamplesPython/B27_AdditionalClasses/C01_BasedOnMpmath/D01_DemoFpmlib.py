from xlcalcnet import fpm, fpmlib


def demofpmlib():
    res = fpmlib.sin(4)
    print('res = fpmlib.sin(4):', res)
    res = fpmlib.sin(4+5j)
    print('res = fpmlib.sin(4+5j):', res)

    res = fpmlib.abs(4)
    print('res = fpmlib.abs(4):', res)
    res = fpmlib.abs(4+5j)
    print('res = fpmlib.abs(4+5j):', res)


try:
    if __name__ == '__main__':
        demofpmlib()



except Exception:
    import traceback
    print(traceback.format_exc())
