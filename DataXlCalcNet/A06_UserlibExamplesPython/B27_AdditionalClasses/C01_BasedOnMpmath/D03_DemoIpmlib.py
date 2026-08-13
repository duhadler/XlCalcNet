from xlcalcnet import ipm, ipmlib


def demoipmlib():
    ipm.dps=20

    res = ipmlib.sin(4)
    print('res = ipmlib.sin(4):', res)
    res = ipmlib.sin(4+5j)
    print('res = ipmlib.sin(4+5j):', res)

    res = ipmlib.abs(4)
    print('res = ipmlib.abs(4):', res)
    res = ipmlib.abs(4+5j)
    print('res = ipmlib.abs(4+5j):', res)


try:
    if __name__ == '__main__':
        demoipmlib()



except Exception:
    import traceback
    print(traceback.format_exc())
