from xlcalcnet import dpm, dpmlib


def demodpmlib():
    dpm.dps=40

    res = dpmlib.sin(4)
    print('res = dpmlib.sin(4):', res)
    res = dpmlib.sin(4+5j)
    print('res = dpmlib.sin(4+5j):', res)

    res = dpmlib.abs(4)
    print('res = dpmlib.abs(4):', res)
    res = dpmlib.abs(4+5j)
    print('res = dpmlib.abs(4+5j):', res)


try:
    if __name__ == '__main__':
        demodpmlib()



except Exception:
    import traceback
    print(traceback.format_exc())
