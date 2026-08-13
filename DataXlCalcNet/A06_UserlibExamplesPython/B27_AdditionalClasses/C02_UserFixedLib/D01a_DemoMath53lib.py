
import time
from xlcalcnet import m53lib



def main_tests():
    demo_arithmetic()
    demo_abs_sin()


def demo_arithmetic():
    res = m53lib.test_add(1.2, 2.4)
    print('res = m53lib.test_add(1.2, 2.4):', res)

    res = m53lib.test_sub(1.2, 2.4)
    print('res = m53lib.test_sub(1.2, 2.4):', res)

    res = m53lib.test_mul(1.2, 2.4)
    print('res = m53lib.test_mul(1.2, 2.4):', res)

    res = m53lib.test_div(1.2, 2.4)
    print('res = m53lib.test_div(1.2, 2.4):', res)


def demo_abs_sin():
    res = m53lib.abs(-1.2)
    print('res = m53lib.abs(-1.2):', res)

    res = m53lib.sin(-1.2)
    print('res = m53lib.sin(-1.2):', res)



try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())

