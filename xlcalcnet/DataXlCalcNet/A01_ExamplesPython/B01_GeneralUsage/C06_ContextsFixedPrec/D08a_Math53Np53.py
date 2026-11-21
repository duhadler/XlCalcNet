
from xlcalcnet import np53, math53
import numpy as np


def main_tests():

    scalar1()
    vec1()
    mat1()

    vec2()
    mat2()

    vec3()
    mat3()

    vec4()
    mat4()

    demo_broadcast_to()

def demo_broadcast_to():
    x = np.array([1, 2, 3])
    x = np.broadcast_to(x, (3, 3))
    print(x)


def scalar1():
    x0 = 1.5
    print('x0:', x0)
    Res0 = math53.sin(x0)
    print('Res0:', Res0)
    print()


def vec1():
    rows = 10
    #x = np.full([rows], 1.5, dtype='float64')
    x = 1.5
    print('x: \n', x)

    
    if isinstance(x, float) or isinstance(x, int) or isinstance(x, str):
        x = np.full([1], float(x), dtype='float64')
    print('x.shape:', x.shape, ', x[0]:', x[0])

    Res1 = np53.p1(math53.sin, x)
    print('Res1 = np53.p1(math53.sin, x): \n', Res1)

    Res1 = np.sin(x)
    print('Res1 = np.sin(x): \n', Res1)
    print()


def mat1():
    rows = 10
    cols = 6
    #x = np.full([rows,cols], 2.5, dtype='float64')
    x = 1.5
    print('x: \n', x)
    
    if isinstance(x, float) or isinstance(x, int) or isinstance(x, str):
        x = np.full([1,1], float(x), dtype='float64')
    print('x.shape:', x.shape, ', x[0, 0]:', x[0, 0])

    Res1 = np53.p1(math53.sin, x)
    print('Res1 = np53.p1(math53.sin, x): \n', Res1)

    Res1 = np.sin(x)
    print('Res1 = np.sin(x): \n', Res1)
    print()


def vec2():
    rows = 10
    x = np.full([rows], 1.5, dtype='float64')
    #x = 1.5
    print('x: \n', x)
    a = np.full([rows], 2.5, dtype='float64')
    print('a: \n', a)

    Res1 = np53.p2(math53.pow, x, a)
    print('Res1 = np53.p2(math53.pow, x, a): \n', Res1)

    Res4 = np.pow(x, a)
    print('Res4: \n', Res4)
    print()



def mat2():
    rows = 10
    cols = 6
    x = np.full([rows,cols], 1.5, dtype='float64')
    x = 1.5
    print('x: \n', x)
    a = np.full([rows,cols], 2.5, dtype='float64')
    print('a: \n', a)

    Res1 = np53.p2(math53.pow, x, a)
    print('Res1 = np53.p2(math53.pow, x, a): \n', Res1)

    Res4 = np.pow(x, a)
    print('Res4: \n', Res4)
    print()



def vec3():
    rows = 10
    x = np.full([rows], 0.5, dtype='float64')
    x = 1.5

    print('x: \n', x)
    a = np.full([rows], 0.6, dtype='float64')
    print('a: \n', a)
    b = np.full([rows], 0.7, dtype='float64')
    print('b: \n', b)

    Res1 = np53.p3(math53.elliptic_rf, x, a, b)
    print('Res1 = np53.p3(math53.elliptic_rf, x, a, b): \n', Res1)
    print()



def mat3():
    rows = 10
    cols = 6
    x = np.full([rows,cols], 0.5, dtype='float64')
    x = 1.5

    print('x: \n', x)
    a = np.full([rows,cols], 0.6, dtype='float64')
    print('a: \n', a)
    b = np.full([rows,cols], 0.7, dtype='float64')
    print('b: \n', b)

    Res1 = np53.p3(math53.elliptic_rf, x, a, b)
    print('Res1 = np53.p3(math53.elliptic_rf, x, a, b): \n', Res1)
    print()



def vec4():
    rows = 10
    x = np.full([rows], 0.5, dtype='float64')
    x = 1.5
    print('x: \n', x)
    a = np.full([rows], 0.6, dtype='float64')
    print('a: \n', a)
    b = np.full([rows], 0.7, dtype='float64')
    print('b: \n', b)
    c = np.full([rows], 0.8, dtype='float64')
    print('c: \n', c)


    Res1 = np53.p4(math53.elliptic_rj, x, a, b, c)
    print('Res1 = np53.p4(math53.elliptic_rj, x, a, b, c): \n', Res1)
    print()



def mat4():
    rows = 10
    cols = 6
    x = np.full([rows,cols], 0.5, dtype='float64')
    x = 1.5
    print('x: \n', x)
    a = np.full([rows,cols], 0.6, dtype='float64')
    print('a: \n', a)
    b = np.full([rows,cols], 0.7, dtype='float64')
    print('b: \n', b)
    c = np.full([rows,cols], 0.8, dtype='float64')
    print('c: \n', c)

    Res1 = np53.p4(math53.elliptic_rj, x, a, b, c)
    print('Res1 = np53.p4(math53.elliptic_rj, x, a, b, c): \n', Res1)
    print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











