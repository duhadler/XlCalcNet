
import math
from xlcalcnet import qreal
from decimal import Decimal
from fractions import Fraction
i = 2329456398453948563945639364827346384753984573984573
print("ÄÄÖÖÜÜßß")


def main_tests():
    general_assignments()
    functions_with_argument_conversion()
    arithmetic_operators_with_qreal()
    arithmetic_operators_with_floats()
    arithmetic_operators_with_long_integers()
    arithmetic_operators_with_short_integers()
    arithmetic_comparisons_with_qreal()
    arithmetic_comparisons_with_floats()
    arithmetic_comparisons_with_long_integers()
    arithmetic_comparisons_with_short_integers()
    assignments_to_matrices()


def general_assignments():
    print()
    print('<H1 Title="General assignments and conversions">')

    x = qreal.t(i)
    print('x = qreal.t(i):', x)

    x = qreal.t(5.7)
    print('x = qrealT(5.7):', x)

    x = qreal.t(5.7)
    print('x = qrealT(5.7):', x)
    x0 = qreal.t(2329456398453948563945639364827346)
    print('x0 = qrealT(2329456398453948563945639364827346', x0)
    x1 = qreal.t("2329456398453948563945639364827346")
    print('x1 = qreal.t("2329456398453948563945639364827346"):', x1)
    x = qreal.t("5.5")
    print('x = qrealT("5.5"):', x)

    print()
    x = qreal.t(55)
    print('x = qreal.t(5):', x)
    y = qreal.exp(x)
    print('y = qreal.exp(x):', y)

    z = qreal.exp(5.5)
    print('z = qreal.exp(5.5):', z)
    z = qreal.exp(5)
    print('z = qreal.exp(5):', z)
    z = qreal.exp("5.5")
    print('z = qreal.exp("5.5"):', z)
    print('</H1>')


def functions_with_argument_conversion():
    print()
    print('<H1 Title="Functions with argument conversion">')
    dec = Decimal(1) / Decimal(7)
    print('dec = Decimal(1) / Decimal(7):', dec)
    z = qreal.exp(dec)
    print('z = qreal.exp(dec):', z)
    frac = Fraction("-3/7")
    print('frac = Fraction("-3/7:")', frac)
    z = qreal.exp(frac)
    print('z = qreal.exp(frac):', z)

    print()
    x = qreal.t(5.5)
    print('x = qreal.t(55):', x)
    y = qreal.t(3.3)
    print('y = qreal.t(33):', y)
    z = qreal.pow(x, y)
    print('z = qreal.pow(x, y):        ', z)
    z = qreal.pow(5.5, 3.3)
    print('z = qreal.pow(5.5, 3.3):    ', z)
    z = qreal.pow("5.5", "3.3")
    print('z = qreal.pow("5.5", "3.3"):', z)
    z = qreal.pow(5, 3)
    print('z = qreal.pow(5, 3):', z)

    t = z + 3
    print('t = z + 3:', t)
    print('</H1>')


def arithmetic_operators_with_qreal():
    print()
    print('<H1 Title="Arithmetic operators with qreal">')

    x = qreal.t(5.0)
    y = qreal.t(2.5)
    print('x: ', x)
    print('y: ', y)

    res = x + y
    print('res = x + y:', res)
    res = y + x
    print('res = y + x:', res)

    res = x - y
    print('res = x - y:', res)
    res = y - x
    print('res = y - x:', res)

    res = x * y
    print('res = x * y:', res)
    res = y * x
    print('res = y * x:', res)

    res = x / y
    print('res = x / y:', res)
    res = y / x
    print('res = y / x:', res)
    print('</H1>')


def arithmetic_operators_with_floats():
    print()
    print('<H1 Title="Arithmetic operators with floats">')
    x = qreal.t(5.7)
    print('x = qreal.t(5.7):', x)
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
    x = qreal.t(5.7)
    print('x = qreal.t(5.7):', x)
    print('i: ', i)
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
    print('<H1 Title="Arithmetic operators with (short) integers">')
    x = qreal.t(5.7)
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



def arithmetic_comparisons_with_qreal():
    print()
    print('<H1 Title="Arithmetic comparisons with qreal">')

    x = qreal.t(5.0)
    y = qreal.t(2.5)
    print('x: ', x)
    print('y: ', y)
    res = x < y
    print('res = x ˂ y:', res)
    res = y < x
    print('res = y ˂ x:', res)

    res = x > y
    print('res = x ˃ y:', res)
    res = y > x
    print('res = y ˃ x:', res)

    res = x >= y
    print('res = x ≥ y:', res)
    res = y >= x
    print('res = y ≥ x:', res)

    res = x <= y
    print('res = x ≤ y:', res)
    res = y <= x
    print('res = y ≤ x:', res)

    res = x == y
    print('res = x == y:', res)
    res = y == x
    print('res = y == x:', res)

    res = x != y
    print('res = x ≠ y:', res)
    res = y != x
    print('res = y ≠ x:', res)
    print('</H1>')


def arithmetic_comparisons_with_floats():
    print()
    print('<H1 Title="Arithmetic comparisons with floats">')

    x = qreal.t(5.0)
    print('x: ', x)
    res = x < 2.5
    print('res = x ˂ 2.5:', res)
    res = 2.5 < x
    print('res = 2.5 ˂ x:', res)

    res = x > 2.5
    print('res = x ˃ 2.5:', res)
    res = 2.5 > x
    print('res = 2.5 ˃ x', res)

    res = x >= 2.5
    print('res = x ≥ 2.5:', res)
    res = 2.5 >= x
    print('res = 2.5 ≥ x:', res)

    res = x <= 2.5
    print('res = x ≤ 2.5:', res)
    res = 2.5 <= x
    print('res = 2.5 ≤ x:', res)

    res = x == 2.5
    print('res = x == 2.5:', res)
    res = 2.5 == x
    print('res = 2.5 == x:', res)

    res = x != 2.5
    print('res = x ≠ 2.5:', res)
    res = 2.5 != x
    print('res = 2.5 ≠ x:', res)
    print('</H1>')

def arithmetic_comparisons_with_long_integers():
    print()
    print('<H1 Title="Arithmetic comparisons with (long) integers">')

    x = qreal.t(5.0)
    print('x: ', x)
    print('i: ', i)
    res = x < i
    print('res = x ˂ i:', res)
    res = i < x
    print('res = i ˂ x:', res)

    res = x > i
    print('res = x ˃ i:', res)
    res = i > x
    print('res = i ˃ x:', res)

    res = x >= i
    print('res = x ≥ i:', res)
    res = i >= x
    print('res = i ≥ x:', res)

    res = x <= i
    print('res = x ≤ i:', res)
    res = i <= x
    print('res = i ≤ x:', res)

    res = x == i
    print('res = x == i:', res)
    res = i == x
    print('res = i == x:', res)

    res = x != i
    print('res = x ≠ i:', res)
    res = i != x
    print('res = i ≠ x:', res)
    print('</H1>')





def arithmetic_comparisons_with_short_integers():
    print()
    print('<H1 Title="Arithmetic comparisons with (short) integers">')

    x = qreal.t(5.0)
    print('x: ', x)
    res = x < 25
    print('res = x ˂ 25:', res)
    res = 25 < x
    print('res = 25 ˂ x:', res)

    res = x > 25
    print('res = x ˃ 25:', res)
    res = 25 > x
    print('res = 25 ˃ x:', res)

    res = x >= 25
    print('res = x ≥ 25:', res)
    res = 25 >= x
    print('res = 25 ≥ x:', res)

    res = x <= 25
    print('res = x ≤ 25:', res)
    res = 25 <= x
    print('res = 25 ≤ x:', res)

    res = x == 25
    print('res = x == 25:', res)
    res = 25 == x
    print('res = 25 == x:', res)

    res = x != 25
    print('res = x ≠ 25:', res)
    res = 25 != x
    print('res = 25 ≠ x:', res)
    print('</H1>')



def assignments_to_matrices():
    print()
    print('<H1 Title="Assignments to matrices">')
#    xMat = qreal.Mat.Random(2,2)
#    print('xMat = qreal.Mat.Random(2,2): \n', xMat)
#
#    xcoeff = qreal.t(4.5)
#    print('xcoeff = qreal.t(4.5): ', xcoeff)
#
#    xMat[1,1] = xcoeff
#    print('xMat[1,1] = xcoeff: \n', xMat)
#    print('xMat[1,1]: ', xMat[1,1])
    print('</H1>')




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




