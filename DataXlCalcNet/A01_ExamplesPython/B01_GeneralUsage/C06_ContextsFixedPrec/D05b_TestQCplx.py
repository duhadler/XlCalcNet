
import math
from xlcalcnet import qreal, qcplx
from decimal import Decimal
from fractions import Fraction
i = 2329456398453948563945639364827346384753984573984573


def main_tests():
    general_assignments()
    functions_with_argument_conversion()
    arithmetic_operators_with_qcplx()
    arithmetic_operators_with_qreal()
    arithmetic_operators_with_floats()
    arithmetic_operators_with_long_integers()
    arithmetic_operators_with_short_integers()
    arithmetic_operators_with_python_imaginary()
    arithmetic_operators_with_python_complex()
    arithmetic_comparisons_with_qcplx()
    arithmetic_comparisons_with_python_complex()

def general_assignments():
    print()
    print('<H1 Title="General assignments and conversions">')

    z = 4+5j
    print('z = 4+5j:', z)
    r = qcplx.t(z)
    print('r = qcplx.t(z):', r)

    z = qcplx.t("3", "4")
    print('z = qcplx.t("3", "4"):', z)
    z = qcplx.t(3.0, 4.0)
    print('z = qcplx.t(3.0, 4.0):', z)
    z = qcplx.t(3, 4)
    print('z = qcplx.t(3, 4):', z)
    z = qcplx.t(3+4j)
    print('z = qcplx.t(3+4j):', z)
    c = complex(3,4)
    print('c = complex(3,4):', c)
    z = qcplx.t(c)
    print('z = qcplx.t(c):', z)
    z = qcplx.t(1j)
    print('z = qcplx.t(1j):', z)
    z = qcplx.t(1)
    print('z = qcplx.t(1):', z)
    z = qcplx.t(1.1)
    print('z = qcplx.t(1.1):', z)
    print('</H1>')

def functions_with_argument_conversion():
    print()
    print('<H1 Title="Functions with argument conversion">')

    print()
    z = qcplx.t(3+4j)
    print('z = qcplx.t(3+4j):', z)
    z = qcplx.exp(z)
    print('z = qcplx.exp(z):', z)
    z = qcplx.exp(3+4j)
    print('z = qcplx.exp(3+4j):', z)
    z = qcplx.exp(5)
    print('z = qcplx.exp(5):', z)
    print('</H1>')


def arithmetic_operators_with_qcplx():
    print()
    print('<H1 Title="Arithmetic operators with qcplx">')
    z = qcplx.t(5.7, 6.3)
    print('z = qcplx.t(5.7, 6.3):', z)
    x = qcplx.t(3.9, 7.8)
    print('x = qcplx.t(3.9, 7.8):', x)
    y = x + z
    print('y = x + z:', y)
    y = z + x
    print('y = z + x:', y)

    y = x - z
    print('y = x - z:', y)
    y = z - x
    print('y = z - x:', y)

    y = x * z
    print('y = x * z:', y)
    y = z * x
    print('y = z * x:', y)

    y = x / z
    print('y = x / z:', y)
    y = z / x
    print('y = z / x:', y)
    print('</H1>')


def arithmetic_operators_with_qreal():
    print()
    print('<H1 Title="Arithmetic operators with qreal">')
    z = qcplx.t(5.7, 6.3)
    print('z = qcplx.t(5.7, 6.3):', z)
    x = qreal.t(3.9)
    print('x = qreal.t(3.9):', x)
    y = x + z
    print('y = x + z:', y)
    y = z + x
    print('y = z + x:', y)

    y = x - z
    print('y = x - z:', y)
    y = z - x
    print('y = z - x:', y)

    y = x * z
    print('y = x * z:', y)
    y = z * x
    print('y = z * x:', y)

    y = x / z
    print('y = x / z:', y)
    y = z / x
    print('y = z / x:', y)
    print('</H1>')


def arithmetic_operators_with_floats():
    print()
    print('<H1 Title="Arithmetic operators with float">')

    x = qcplx.t(5.7, 6.3)
    print('x = qcplx.t(5.7, 6.3):', x)
    y = x + 2.5
    print('y = x + 2.5:', y)
    y = 2.5 + x
    print('y = 2.5 + x:', y)

    y = x - 2.5
    print('y = x - 2.5:', y)
    y = 2.5 - x
    print('y = 2.5 - x:', y)

    y = x * 2.5
    print('y = x * 2.5:', y)
    y = 2.5 * x
    print('y = 2.5 * x:', y)

    y = x / 2.5
    print('y = x / 2.5:', y)
    y = 2.5 / x
    print('y = 2.5 / x:', y)
    print('</H1>')


def arithmetic_operators_with_long_integers():
    print()
    print('<H1 Title="Arithmetic operators with (long) integers">')

    x = qcplx.t(5.7, 6.3)
    print('x = qcplx.t(5.7, 6.3):', x)
    print('i:', i)
    y = x + i
    print('y = x + i:', y)
    y = i + x
    print('y = i + x:', y)

    y = x - i
    print('y = x - i:', y)
    y = i - x
    print('y = i - x:', y)

    y = x * i
    print('y = x * i:', y)
    y = i * x
    print('y = i * x:', y)

    y = x / i
    print('y = x / i:', y)
    y = i / x
    print('y = i / x:', y)
    print('</H1>')


def arithmetic_operators_with_short_integers():
    print()
    print('<H1 Title="Arithmetic comparisons with (short) integers">')

    x = qcplx.t(5.7, 6.3)
    print('x = qcplx.t(5.7, 6.3):', x)
    y = x + 25
    print('y = x + 25:', y)
    y = 25 + x
    print('y = 25 + x:', y)

    y = x - 25
    print('y = x - 25:', y)
    y = 25 - x
    print('y = 25 - x:', y)

    y = x * 25
    print('y = x * 25:', y)
    y = 25 * x
    print('y = 25 * x:', y)

    y = x / 25
    print('y = x / 25:', y)
    y = 25 / x
    print('y = 25 / x:', y)
    print('</H1>')


def arithmetic_operators_with_python_imaginary():
    print()
    print('<H1 Title="Arithmetic operators with python imaginary">')

    x = qcplx.t(5.7, 6.3)
    print('x = qcplx.t(5.7, 6.3):', x)
    y = x + 2.5j
    print('y = x + 2.5j:', y)
    y = 2.5j + x
    print('y = 2.5j + x:', y)

    y = x - 2.5j
    print('y = x - 2.5j:', y)
    y = 2.5j - x
    print('y = 2.5j - x:', y)

    y = x * 2.5j
    print('y = x * 2.5j:', y)
    y = 2.5j * x
    print('y = 2.5j * x:', y)

    y = x / 2.5j
    print('y = x / 2.5j:', y)
    y = 2.5j / x
    print('y = 2.5j / x:', y)
    print('</H1>')


def arithmetic_operators_with_python_complex():
    print()
    print('<H1 Title="Arithmetic operators with python complex">')

    x = qcplx.t(5.7, 6.3)
    print('x = qcplx.t(5.7, 6.3):', x)

    y = x + (4.4+2.5j)
    print('y = x + (4.4+2.5j):', y)
    y = (4.4+2.5j) + x
    print('y = (4.4+2.5j) + x:', y)

    y = x - (4.4+2.5j)
    print('y = x - (4.4+2.5j):', y)
    y = (4.4+2.5j) - x
    print('y = (4.4+2.5j) - x:', y)

    y = x * (4.4+2.5j)
    print('y = x * (4.4+2.5j):', y)
    y = (4.4+2.5j) * x
    print('y = (4.4+2.5j) * x', y)

    y = x / (4.4+2.5j)
    print('y = x / (4.4+2.5j):', y)
    y = (4.4+2.5j) / x
    print('y = (4.4+2.5j) / x', y)
    print('</H1>')




def arithmetic_comparisons_with_qcplx():
    print()
    print('<H1 Title="Arithmetic comparisons with qcplx">')

    x = qcplx.t(5.7, 6.3)
    y = qcplx.t(3.9, 7.8)
    print('x: ', x)
    print('y: ', y)

    res = x == y
    print('res = x == y:', res)
    res = y == x
    print('res = y == x:', res)

    res = x != y
    print('res = x ≠ y:', res)
    res = y != x
    print('res = y ≠ x:', res)

    x = qcplx.t(5.7, 6.3)
    y = qcplx.t(5.7, 6.3)
    print('x: ', x)
    print('y: ', y)

    res = x == y
    print('res = x == y:', res)
    res = y == x
    print('res = y == x:', res)

    res = x != y
    print('res = x ≠ y:', res)
    res = y != x
    print('res = y ≠ x:', res)

    print('</H1>')


def arithmetic_comparisons_with_python_complex():
    print()
    print('<H1 Title="Arithmetic comparisons with python_complex">')

    x = qcplx.t(4.5, 2.5)
    y = (4.5+2.5j)
    print('x: ', x)
    print('y: ', y)

    res = x == y
    print('res = x == y:', res)
    res = y == x
    print('res = y == x:', res)

    res = x != y
    print('res = x ≠ y:', res)
    res = y != x
    print('res = y ≠ x:', res)

    x = qcplx.t(4.5, 2.5)
    y = (4.4+2.2j)
    print('x: ', x)
    print('y: ', y)

    res = x == y
    print('res = x == y:', res)
    res = y == x
    print('res = y == x:', res)

    res = x != y
    print('res = x ≠ y:', res)
    res = y != x
    print('res = y ≠ x:', res)

    print('</H1>')



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())


