
from xlcalcnet import np53c, cmath53
import numpy as np


def main_tests():
    scalar1(3+4j)
    scalar1(-3+0j)

    vec1()
    mat1()

    vec2()
    mat2()

    vec3()
    mat3()

    vec4()
    mat4()


def scalar1(z):
    y = cmath53.sqrt(z)
    print('z:', z, '; y = cmath53.sqrt(z):', y)
    y = np.sqrt(z)
    print('z:', z, '; y = np.sqrt(z):', y)

    print()


def vec1():
    rows = 10
    #x = np.full([rows], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j
    print('x: \n', x)


    Res1 = np53c.p1(cmath53.sin, x)
    print('Res1 = np53c.p1(cmath53.sin, x): \n', Res1, type(Res1))
    Res2 = np.sin(x)
    print('Res2 = np.sin(x): \n', Res2, type(Res2))

    print()


def mat1():
    rows = 10
    cols = 6
    #x = np.full([rows,cols], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j
    print('x: \n', x)

    if isinstance(x, float) or isinstance(x, int) or isinstance(x, str) or isinstance(x, complex):
        x = np.full([1,1], complex(x), dtype='complex128')
    print('x.shape:', x.shape, ', x[0,0]:', x[0,0], len(x.shape))

    Res1 = np53c.p1(cmath53.sin, x)
    print('Res1 = np53c.p1(cmath53.sin, x): \n', Res1, type(Res1), type(Res1[0,0]))
    Res2 = np.sin(x)
    print('Res2 = np.sin(x): \n', Res2, type(Res2), type(Res2[0,0]))

    print()



def vec2():
    rows = 10
    x = np.full([rows], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j
    print('x: \n', x)
    a = np.full([rows], 3.5+4.5j, dtype='complex128')
    print('a: \n', a)

    Res1 = np53c.p2(cmath53.pow, x, a)
    print('Res1 = np53c.p2(cmath53.pow, x, a): \n', Res1)
    Res2 = np.pow(x, a)
    print('Res2 = np.pow(x, a): \n', Res2)
    print()

    print()



def mat2():
    rows = 10
    cols = 6
    x = np.full([rows,cols], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j
    print('x: \n', x)
    a = np.full([rows,cols], 3.5+4.5j, dtype='complex128')
    print('a: \n', a)

    Res1 = np53c.p2(cmath53.pow, x, a)
    print('Res1 = np53c.p2(cmath53.pow, x, a): \n', Res1)
    Res2 = np.pow(x, a)
    print('Res2 = np.pow(x, a): \n', Res2)
    print()

    print()



def vec3():
    rows = 10
    x = np.full([rows], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j

    print('x: \n', x)
    a = np.full([rows], 3.5+4.5j, dtype='complex128')
    print('a: \n', a)
    b = np.full([rows], 5.5+6.5j, dtype='complex128')
    print('b: \n', b)
    Res1 = np53c.p3(cmath53.elliptic_rf, x, a, b)
    print('Res1 = np53c.p3(cmath53.elliptic_rf, x, a, b): \n', Res1)
    print()



def mat3():
    rows = 10
    cols = 6
    x = np.full([rows,cols], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j

    print('x: \n', x)
    a = np.full([rows,cols], 3.5+4.5j, dtype='complex128')
    print('a: \n', a)
    b = np.full([rows,cols], 5.5+6.5j, dtype='complex128')
    print('b: \n', b)
    Res1 = np53c.p3(cmath53.elliptic_rf, x, a, b)
    print('Res1 = np53c.p3(cmath53.elliptic_rf, x, a, b): \n', Res1)
    print()




def vec4():
    rows = 10
    x = np.full([rows], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j

    print('x: \n', x)
    a = np.full([rows], 3.5+4.5j, dtype='complex128')
    print('a: \n', a)
    b = np.full([rows], 5.5+6.5j, dtype='complex128')
    print('b: \n', b)
    c = np.full([rows], 7.5+8.5j, dtype='complex128')
    print('c: \n', c)
    Res1 = np53c.p4(cmath53.elliptic_rj, x, a, b, c)
    print('Res1 = np53c.p4(cmath53.elliptic_rj, x, a, b, c): \n', Res1)
    print()



def mat4():
    rows = 10
    cols = 6
    x = np.full([rows,cols], 1.5+2.5j, dtype='complex128')
    x = 1.5+2.5j

    print('x: \n', x)
    a = np.full([rows,cols], 3.5+4.5j, dtype='complex128')
    print('a: \n', a)
    b = np.full([rows,cols], 5.5+6.5j, dtype='complex128')
    print('b: \n', b)
    c = np.full([rows,cols], 7.5+8.5j, dtype='complex128')
    print('c: \n', c)
    Res1 = np53c.p4(cmath53.elliptic_rj, x, a, b, c)
    print('Res1 = np53c.p4(cmath53.elliptic_rj, x, a, b, c): \n', Res1)
    print()


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











