from xlcalcnet import mpm, mpmlib


def demompmlib():
    mpm.dps=40

    res = mpmlib.sin(4)
    print('res = mpmlib.sin(4):', res)
    res = mpmlib.sin(4+5j)
    print('res = mpmlib.sin(4+5j):', res)

    res = mpmlib.abs(4)
    print('res = mpmlib.abs(4):', res)
    res = mpmlib.abs(4+5j)
    print('res = mpmlib.abs(4+5j):', res)


try:
    if __name__ == '__main__':
        demompmlib()



except Exception:
    import traceback
    print(traceback.format_exc())
