
import math
from xlcalcnet import ArbPrec, aflint
from decimal import Decimal
from fractions import Fraction
i = 2329456398453948563945639364827346384753984573984573
ArbPrec.SetDps(40)


def main_tests():
    general_assignments()
    functions_with_argument_conversion()
    arithmetic_operators_with_aflint()
    arithmetic_operators_with_floats()
    arithmetic_operators_with_long_integers()
    arithmetic_operators_with_short_integers()
    arithmetic_comparisons_with_aflint()
    arithmetic_comparisons_with_floats()
    arithmetic_comparisons_with_long_integers()
    arithmetic_comparisons_with_short_integers()
    assignments_to_matrices()


def general_assignments():
    print()
    print('<H1 Title="General assignments and conversions">')

    x = aflint.t(i)
    print('x = aflint.t(i):', x)

    x = aflint.t(5.7)
    print('x = aflintT(5.7):', x)

    x = aflint.t(5.7)
    print('x = aflintT(5.7):', x)
    x0 = aflint.t(2329456398453948563945639364827346)
    print('x0 = aflintT(2329456398453948563945639364827346', x0)
    x1 = aflint.t("2329456398453948563945639364827346")
    print('x1 = aflint.t("2329456398453948563945639364827346"):', x1)
    x = aflint.t("5.5")
    print('x = aflintT("5.5"):', x)

    print()
    x = aflint.t(55)
    print('x = aflint.t(5):', x)
    y = aflint.exp(x)
    print('y = aflint.exp(x):', y)

    z = aflint.exp(5.5)
    print('z = aflint.exp(5.5):', z)
    z = aflint.exp(5)
    print('z = aflint.exp(5):', z)
    z = aflint.exp("5.5")
    print('z = aflint.exp("5.5"):', z)
    print('</H1>')


def functions_with_argument_conversion():
    print()
    print('<H1 Title="Functions with argument conversion">')
    dec = Decimal(1) / Decimal(7)
    print('dec = Decimal(1) / Decimal(7):', dec)
    z = aflint.exp(dec)
    print('z = aflint.exp(dec):', z)
    frac = Fraction("-3/7")
    print('frac = Fraction("-3/7:")', frac)
#    z = aflint.exp(frac)
#    print('z = aflint.exp(frac):', z)

    print()
    x = aflint.t(5.5)
    print('x = aflint.t(55):', x)
    y = aflint.t(3.3)
    print('y = aflint.t(33):', y)
    z = aflint.pow(x, y)
    print('z = aflint.pow(x, y):        ', z)
    z = aflint.pow(5.5, 3.3)
    print('z = aflint.pow(5.5, 3.3):    ', z)
    z = aflint.pow("5.5", "3.3")
    print('z = aflint.pow("5.5", "3.3"):', z)
    z = aflint.pow(5, 3)
    print('z = aflint.pow(5, 3):', z)

    t = z + 3
    print('t = z + 3:', t)
    print('</H1>')


def arithmetic_operators_with_aflint():
    print()
    print('<H1 Title="Arithmetic operators with aflint">')

    x = aflint.t(5.0)
    y = aflint.t(2.5)
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
    x = aflint.t(5.7)
    print('x = aflint.t(5.7):', x)
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
    x = aflint.t(5.7)
    print('x = aflint.t(5.7):', x)
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
    x = aflint.t(5.7)
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



def arithmetic_comparisons_with_aflint():
    print()
    print('<H1 Title="Arithmetic comparisons with aflint">')

    x = aflint.t(5.0)
    y = aflint.t(2.5)
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

    x = aflint.t(5.0)
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

    x = aflint.t(5.0)
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

    x = aflint.t(5.0)
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
    xMat = aflint.mat_random(2,2)
    print('xMat = aflint.mat_random(2,2): \n', xMat)

    xcoeff = aflint.t(4.5)
    print('xcoeff = aflint.t(4.5): ', xcoeff)

    xMat[1,1] = xcoeff
    print('xMat[1,1] = xcoeff: \n', xMat)
    print('xMat[1,1]: ', xMat[1,1])
    print('</H1>')




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




