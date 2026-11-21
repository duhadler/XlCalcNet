
import math
from xlcalcnet import dreal
from decimal import Decimal
from fractions import Fraction
i = 2329456398453948563945639364827346384753984573984573
print("ÄÄÖÖÜÜßß")


def main_tests():
    general_assignments()
    functions_with_argument_conversion()
    arithmetic_operators_with_dreal()
    arithmetic_operators_with_floats()
    arithmetic_operators_with_long_integers()
    arithmetic_operators_with_short_integers()
    arithmetic_comparisons_with_dreal()
    arithmetic_comparisons_with_floats()
    arithmetic_comparisons_with_long_integers()
    arithmetic_comparisons_with_short_integers()
    assignments_to_matrices()


def general_assignments():
    print()
    print('<H1 Title="General assignments and conversions">')

    x = dreal.t(i)
    print('x = dreal.t(i):', x)

    x = dreal.t(5.7)
    print('x = drealT(5.7):', x)

    x = dreal.t(5.7)
    print('x = drealT(5.7):', x)
    x0 = dreal.t(2329456398453948563945639364827346)
    print('x0 = drealT(2329456398453948563945639364827346', x0)
    x1 = dreal.t("2329456398453948563945639364827346")
    print('x1 = dreal.t("2329456398453948563945639364827346"):', x1)
    x = dreal.t("5.5")
    print('x = drealT("5.5"):', x)

    print()
    x = dreal.t(55)
    print('x = dreal.t(5):', x)
    y = dreal.exp(x)
    print('y = dreal.exp(x):', y)

    z = dreal.exp(5.5)
    print('z = dreal.exp(5.5):', z)
    z = dreal.exp(5)
    print('z = dreal.exp(5):', z)
    z = dreal.exp("5.5")
    print('z = dreal.exp("5.5"):', z)
    print('</H1>')


def functions_with_argument_conversion():
    print()
    print('<H1 Title="Functions with argument conversion">')
    dec = Decimal(1) / Decimal(7)
    print('dec = Decimal(1) / Decimal(7):', dec)
    z = dreal.exp(dec)
    print('z = dreal.exp(dec):', z)
    frac = Fraction("-3/7")
    print('frac = Fraction("-3/7:")', frac)
    z = dreal.exp(frac)
    print('z = dreal.exp(frac):', z)

    print()
    x = dreal.t(5.5)
    print('x = dreal.t(55):', x)
    y = dreal.t(3.3)
    print('y = dreal.t(33):', y)
    z = dreal.pow(x, y)
    print('z = dreal.pow(x, y):        ', z)
    z = dreal.pow(5.5, 3.3)
    print('z = dreal.pow(5.5, 3.3):    ', z)
    z = dreal.pow("5.5", "3.3")
    print('z = dreal.pow("5.5", "3.3"):', z)
    z = dreal.pow(5, 3)
    print('z = dreal.pow(5, 3):', z)

    t = z + 3
    print('t = z + 3:', t)
    print('</H1>')


def arithmetic_operators_with_dreal():
    print()
    print('<H1 Title="Arithmetic operators with dreal">')

    x = dreal.t(5.0)
    y = dreal.t(2.5)
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
    x = dreal.t(5.7)
    print('x = dreal.t(5.7):', x)
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
    x = dreal.t(5.7)
    print('x = dreal.t(5.7):', x)
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
    x = dreal.t(5.7)
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



def arithmetic_comparisons_with_dreal():
    print()
    print('<H1 Title="Arithmetic comparisons with dreal">')

    x = dreal.t(5.0)
    y = dreal.t(2.5)
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

    x = dreal.t(5.0)
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

    x = dreal.t(5.0)
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

    x = dreal.t(5.0)
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
#    xMat = dreal.Mat.Random(2,2)
#    print('xMat = dreal.Mat.Random(2,2): \n', xMat)
#
#    xcoeff = dreal.t(4.5)
#    print('xcoeff = dreal.t(4.5): ', xcoeff)
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




