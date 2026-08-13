
import math
from xlcalcnet import ipm
from decimal import Decimal
from fractions import Fraction
i = 2329456398453948563945639364827346384753984573984573
print("ÄÄÖÖÜÜßß")


def main_tests():
    general_assignments()
    functions_with_argument_conversion()
    arithmetic_operators_with_mpm()
    arithmetic_operators_with_floats()
    arithmetic_operators_with_long_integers()
    arithmetic_operators_with_short_integers()
    arithmetic_comparisons_with_mpm()
    arithmetic_comparisons_with_floats()
    arithmetic_comparisons_with_long_integers()
    arithmetic_comparisons_with_short_integers()
    assignments_to_matrices()


def general_assignments():
    print()
    print('<H1 Title="General assignments and conversions">')

    x = ipm.t(i)
    print('x = ipm.t(i):', x)

    x = ipm.t(5.7)
    print('x = ipm.t(5.7):', x)

    x = ipm.t(5.7)
    print('x = ipm.t(5.7):', x)
    x0 = ipm.t(2329456398453948563945639364827346)
    print('x0 = ipm.t(2329456398453948563945639364827346', x0)
    x1 = ipm.t("2329456398453948563945639364827346")
    print('x1 = ipm.t("2329456398453948563945639364827346"):', x1)
    x = ipm.t("5.5")
    print('x = ipm.t("5.5"):', x)

    print()
    x = ipm.t(55)
    print('x = ipm.t(5):', x)
    y = ipm.exp(x)
    print('y = ipm.exp(x):', y)

    z = ipm.exp(5.5)
    print('z = ipm.exp(5.5):', z)
    z = ipm.exp(5)
    print('z = ipm.exp(5):', z)
    z = ipm.exp("5.5")
    print('z = ipm.exp("5.5"):', z)
    print('</H1>')


def functions_with_argument_conversion():
    print()
    print('<H1 Title="Functions with argument conversion">')
    dec = Decimal(1) / Decimal(7)
    print('dec = Decimal(1) / Decimal(7):', dec)
#    z = ipm.exp(dec)
#    print('z = ipm.exp(dec):', z)
#    frac = Fraction("-3/7")
#    print('frac = Fraction("-3/7:")', frac)
#    z = ipm.exp(frac)
#    print('z = ipm.exp(frac):', z)

    print()
    x = ipm.t(5.5)
    print('x = ipm.t(55):', x)
    y = ipm.t(3.3)
    print('y = ipm.t(33):', y)
    z = ipm.pow(x, y)
    print('z = ipm.pow(x, y):        ', z)
    z = ipm.pow(5.5, 3.3)
    print('z = ipm.pow(5.5, 3.3):    ', z)
    z = ipm.pow("5.5", "3.3")
    print('z = ipm.pow("5.5", "3.3"):', z)
    z = ipm.pow(5, 3)
    print('z = ipm.pow(5, 3):', z)

    t = z + 3
    print('t = z + 3:', t)
    print('</H1>')


def arithmetic_operators_with_mpm():
    print()
    print('<H1 Title="Arithmetic operators with ipm">')

    x = ipm.t(5.0)
    y = ipm.t(2.5)
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
    x = ipm.t(5.7)
    print('x = ipm.t(5.7):', x)
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
    x = ipm.t(5.7)
    print('x = ipm.t(5.7):', x)
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
    x = ipm.t(5.7)
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



def arithmetic_comparisons_with_mpm():
    print()
    print('<H1 Title="Arithmetic comparisons with ipm">')

    x = ipm.t(5.0)
    y = ipm.t(2.5)
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

    x = ipm.t(5.0)
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

    x = ipm.t(5.0)
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

    x = ipm.t(5.0)
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
#    xMat = ipm.Mat.Random(2,2)
#    print('xMat = ipm.Mat.Random(2,2): \n', xMat)
#
#    xcoeff = ipm.t(4.5)
#    print('xcoeff = ipm.t(4.5): ', xcoeff)
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




