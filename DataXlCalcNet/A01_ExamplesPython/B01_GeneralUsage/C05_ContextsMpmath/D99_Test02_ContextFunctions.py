# -*- coding: utf-8 -*-

import matplotlib.pyplot as plt
import numpy as np
path = r'C:\Users\dietrichhadler\Documents'


from xlcalcnet import  mpm, ipm, dpm, gpm #, apm
#ctxall = [mpm, ipm, dpm, gpm, apm]
ctxall = [mpm, ipm, dpm, gpm]


# 2.1 Contexts in xlcalcnet: common interface
def demo_2_1_common_interface(ctx):

# 2.1.2 Creating a real number
    def demo_mpf(ctx):
        print("demo_mpf")
        x1 = ctx.mpf('3.1')
        print("x1:", x1, type(x1))
        print()

# 2.1.3 Creating a complex number
    def demo_mpc(ctx):
        print("demo_mpc")
        x1 = ctx.mpc('3.1')
        print("x1:", x1, type(x1))
        z1 = ctx.mpc('3.1+4.6j')
        print("z1:", z1, type(z1))
        print()

# 2.1.4 Getting and setting the current precision (in bits)
    def demo_prec(ctx):
        print("demo_prec")

# 2.1.5 Getting and setting the current decimal precision (in digits)
    def demo_dps(ctx):
        print("demo_dps")
        ctx.dps = 70
        res = ctx.sqrt(2)
        print(res)

# 2.1.6 Using pretty printing (incl show)
    def demo_pretty(ctx):
        print("demo_pretty")

# 2.1.7 Using rounding modes
    def demo_rounding(ctx):
        print("demo_rounding")

# 2.1.8 Handling division by zero
    def demo_division_by_zero(ctx):
        print("demo_division_by_zero")

# 2.1.10 Arbitrary-precision floating-point (mp): special functions
    def demo_mpm(ctx):
        print("demo_mpm")

# 2.1.11 Arbitrary-precision interval arithmetic (iv)
    def demo_ivm(ctx):
        print("demo_ivm")

# 2.1.12 Fast arbitrary-precision decimal floating-point (dec)
    def demo_dec(ctx):
        print("demo_dec")

# 2.1.15 Operator overloading and type conversions
    def demo_operator_overloading(ctx):
        print("demo_operator_overloading")

    demo_mpf(ctx)
    demo_mpc(ctx)
    demo_prec(ctx)
    demo_dps(ctx)
    demo_pretty(ctx)
    demo_rounding(ctx)
    demo_division_by_zero(ctx)
    #demo_fpm(ctx)
    demo_mpm(ctx)
    demo_ivm(ctx)
    demo_dec(ctx)
    #demo_gmp(ctx)
    #demo_apm(ctx)
    demo_operator_overloading(ctx)
    print()




# 2.2 Arithmetic operations
def demo_2_2_arithmetic_operations(ctx):

# 2.2.1 Addition using a custom precision and rounding mode
    def demo_fadd(ctx):
        print("demo_fadd: " + ctx.name)

        res1 = ctx.fadd('2', '1e-20')
        print("ctx.fadd('2', '1e-20'):", res1)

        print("ctx.nprint(ctx.fadd(2, 1e-20, prec=100), 25):")
        ctx.nprint(ctx.fadd(2, 1e-20, prec=100), 25)

        print("ctx.nprint(ctx.fadd(2, 1e-20, dps=15), 25):")
        ctx.nprint(ctx.fadd(2, 1e-20, dps=15), 25)

        print("ctx.nprint(ctx.fadd(2, 1e-20, dps=25), 25):")
        ctx.nprint(ctx.fadd(2, 1e-20, dps=25), 25)

        print("ctx.nprint(ctx.fadd(2, 1e-20, exact=True), 25):")
        ctx.nprint(ctx.fadd(2, 1e-20, exact=True), 25)
        print()

# 2.2.2 Subtraction using a custom precision and rounding mode
    def demo_fsub(ctx):
        print("demo_fsub: " + ctx.name)
        ctx.dps = 15; ctx.pretty = False

        res1 = ctx.fsub('2', '1e-20')
        print("ctx.sub('2', '1e-20'):", res1)

        res2 = ctx.fsub('2', '1e-20', rounding='d')
        print("ctx.fsub('2', '1e-20', rounding='d': ", res2)

        print("ctx.nprint(ctx.fsub(2, 1e-20, prec=100), 25):")
        ctx.nprint(ctx.fsub(2, 1e-20, prec=100), 25)

        print("ctx.nprint(ctx.fsub(2, 1e-20, dps=15), 25):")
        ctx.nprint(ctx.fsub(2, 1e-20, dps=15), 25)

        print("ctx.nprint(ctx.fsub(2, 1e-20, dps=25), 25):")
        ctx.nprint(ctx.fsub(2, 1e-20, dps=25), 25)

        print("ctx.nprint(ctx.fsub(2, 1e-20, exact=True), 25):")
        ctx.nprint(ctx.fsub(2, 1e-20, exact=True), 25)

        x, y = ctx.t(2), ctx.t('1e1000')
        print("x, y = ctx.t(2), ctx.t('1e1000'):")
        print(x - y + y)

        print("ctx.fsub(x, y, prec=ctx.inf) + y:")
        print(ctx.fsub(x, y, prec=ctx.inf) + y)

        print("ctx.fsub(x, y, exact=True) + y:")
        print(ctx.fsub(x, y, exact=True) + y)

        print()

# 2.2.3 Negation of a number using a custom precision and rounding mode
    def demo_fneg(ctx):
        print("demo_fneg")
        return

# 2.2.4 Multiplication using a custom precision and rounding mode
    def demo_fmul(ctx):
        print("demo_fmul")
        return

# 2.2.5 Division using a custom precision and rounding mode
    def demo_fdiv(ctx):
        print("demo_fdiv")
        return

# 2.2.6 Modular division (real numbers only)
    def demo_fmod(ctx):
        print("demo_fmod")
        return

# 2.2.7 Sum of a finite number of terms
    def demo_fsum(ctx):
        print("demo_fsum")
        return

# 2.2.8 Product of a finite number of factors
    def demo_fprod(ctx):
        print("demo_fprod")
        return

# 2.2.9 Dot product
    def demo_fdot(ctx):
        print("demo_fdot")
        return

    #demo_format(ctx)
    demo_fadd(ctx)
    demo_fsub(ctx)
    demo_fneg(ctx)
    demo_fmul(ctx)
    demo_fdiv(ctx)
    demo_fmod(ctx)
    demo_fsum(ctx)
    demo_fprod(ctx)
    demo_fdot(ctx)
    print()





# 2.3 Functions related to intervals and balls
def demo_2_3_functions_related_to_intervals(ctx):

# 2.3.1 Middle value of an interval or ball
    def demo_mid(ctx):
        print("demo_mid")
        return


# 2.3.2 Radius of an interval or ball
    def demo_radius(ctx):
        print("demo_radius")
        return


# 2.3.3 Left border of an interval or ball
    def demo_left(ctx):
        print("demo_radius")
        return


# 2.3.4 Left border of an interval or ball
    def demo_right(ctx):
        print("demo_radius")
        return


# 2.3.5 Absolute value of the left end of an interval
    def demo_absmin(ctx):
        print("demo_absmin")
        return


# 2.3.6 Absolute value of the right end of an interval
    def demo_absmax(ctx):
        print("demo_absmax")
        return

    demo_mid(ctx)
    demo_radius(ctx)
    demo_left(ctx)
    demo_right(ctx)
    demo_absmin(ctx)
    demo_absmax(ctx)





# 2.4 Complex components
def demo_2_4_complex_components(ctx):

# 2.4.1 Absolute value of a real or complex number
    def demo_fabs(ctx):
        print("demo_fabs")
        return


# 2.4.2 Sign of a real or complex number
    def demo_sign(ctx):
        print("demo_sign")
        return

# 2.4.3 Real part of a real or complex number
    def demo_re(ctx):
        print("demo_re")
        return

# 2.4.4 Imaginary part of a real or complex number
    def demo_im(ctx):
        print("demo_im")
        return

# 2.4.5 Argument (or phase) of a real or complex number
    def demo_arg(ctx):
        print("demo_arg")
        return

    def demo_phase(ctx):
        print("demo_phase")
        return

# 2.4.6 Conjugate of a real or complex number
    def demo_conj(ctx):
        print("demo_conj")
        return

# 2.4.7 Polar representation of a real or complex number
    def demo_polar(ctx):
        print("demo_polar")
        return

# 2.4.8 Rectangular coordinates calculated from the polar representation of a real or complex number
    def demo_rect(ctx):
        print("demo_rect")
        return

    demo_fabs(ctx)
    demo_sign(ctx)
    demo_re(ctx)
    demo_im(ctx)
    demo_arg(ctx)
    demo_phase(ctx)
    demo_conj(ctx)
    demo_polar(ctx)
    demo_rect(ctx)
    print()




# 2.5 Integer and fractional parts
def demo_2_5_integer_and_fractional_parts(ctx):


# 2.5.1 Floor of a real or complex number
    def demo_floor(ctx):
        print("demo_floor")
        return

# 2.5.2 Ceiling of a real or complex number
    def demo_ceil(ctx):
        print("demo_ceil")
        return

# 2.5.3 Nearest integer(s) of a real or complex number
    def demo_nint(ctx):
        print("demo_nint")
        return

# 2.5.4 Fractional part of a real or complex number
    def demo_frac(ctx):
        print("demo_frac")
        return

    demo_floor(ctx)
    demo_ceil(ctx)
    demo_nint(ctx)
    demo_frac(ctx)
    print()





# 2.6 Tolerances and approximate comparisons
def demo_2_6_tolerances_and_approximate_comparisons(ctx):


# 2.6.1 Chopping off small real or imaginary parts
    def demo_chop(ctx):
        print("demo_chop")
        return

# 2.6.2 Testing if 2 numbers are almost equal
    def demo_almosteq(ctx):
        print("demo_almosteq")
        return


    demo_chop(ctx)
    demo_almosteq(ctx)
    print()






# 2.7 Properties of numbers
def demo_2_7_properties_of_numbers(ctx):

# 2.7.1 Testing for a real number in a given context
    def demo_ismpf(ctx):
        print("demo_ismpf " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall: print(ctx.ismpf(ctx.inf), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpf(ctx.ninf), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpf(ctx.one), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpf(1.0), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpf(ctx.nan), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpf(ctx.j), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpf(1j), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpf(ctx.mpc(3,ctx.inf)), end=', ')
        print("\n")


# 2.7.2 Testing for a complex number in a given context
    def demo_ismpc(ctx):
        print("demo_ismpc " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall: print(ctx.ismpc(ctx.inf), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpc(ctx.ninf), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpc(ctx.one), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpc(1.0), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpc(ctx.nan), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpc(ctx.j), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpc(1j), end=', ')
        print()
        for ctx in ctxall: print(ctx.ismpc(ctx.mpc(3,ctx.inf)), end=', ')
        print("\n")


# 2.7.3 Testing if a real or complex number is infinite
    def demo_isinf(ctx):
        print("demo_isinf " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.isinf(ctx.inf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isinf(ctx.ninf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isinf(ctx.nan), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isinf(3), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isinf(3+4j), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isinf(ctx.mpc(3,ctx.inf)), end=', ')
        print("\n")

# 2.7.4 Testing if a real or complex number is NaN
    def demo_isnan(ctx):
        print("demo_isnan " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.isnan(ctx.nan), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(ctx.inf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(ctx.ninf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(3), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(3+4j), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(ctx.mpc(3,ctx.inf)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(ctx.mpc(ctx.inf,3)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(ctx.mpc(3,ctx.nan)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnan(ctx.mpc(ctx.nan,3)), end=', ')
        print()

        print("\n")

# 2.7.5 Testing if a real or complex number is “normal”
    def demo_isnormal(ctx):
        print("demo_isnormal " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.isnormal(ctx.nan), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(ctx.inf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(ctx.ninf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(3), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(3+4j), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(ctx.mpc(3,ctx.inf)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(ctx.mpc(ctx.inf,3)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(ctx.mpc(3,ctx.nan)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isnormal(ctx.mpc(ctx.nan,3)), end=', ')
        print()


# 2.7.6 Testing if a real or complex number is finite
    def demo_isfinite(ctx):
        print("demo_isfinite " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.isfinite(ctx.inf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(ctx.ninf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(ctx.nan), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(3), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(3+4j), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(ctx.mpc(3,ctx.inf)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(ctx.mpc(ctx.inf,3)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(ctx.mpc(3,ctx.nan)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isfinite(ctx.mpc(ctx.nan,3)), end=', ')
        print()


# 2.7.7 Testing if a real or complex number is integer-valued
    def demo_isint(ctx):
        print("demo_isint " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.isint(3), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isint(3.2), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isint(ctx.inf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isint(3+0j), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.isint(3+2j), end=', ')
        print("\n")


# 2.7.8 Calculating x*2^n efficiently for a real number
    def demo_ldexp(ctx):
        print("demo_ldexp " + ctx.name)

        print("\nExamples from manual:")
        for ctx in ctxall: print(repr(ctx.ldexp(1, 10)))
        print()

        for ctx in ctxall: print(repr(ctx.ldexp(1, -3)))
        print()


# 2.7.9 Calculating (y, n) such that x = y*2^n (real numbers only)
    def demo_frexp(ctx):
        print("demo_frexp " + ctx.name)

        print("ctx.frexp(7.5)")
        print(ctx.frexp(7.5))

        print("\nExamples from manual:")

        for ctx in ctxall: print(repr(ctx.frexp(7.5)))
        print()


# 2.7.10 Quick logarithmic magnitude estimate
    def demo_mag(ctx):
        print("demo_mag " + ctx.name)

        print("[ctx.mag(10), ctx.mag(10.0), ctx.mag(0.01)]")
        print([ctx.mag(10), ctx.mag(10.0), ctx.mag(0.01)])

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.mag(3), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.mag(3.2), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.mag(ctx.inf), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.mag(3+0j), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.mag(3+2j), end=', ')
        print("\n")

# 2.7.11 Nearest integer and distance estimate
    def demo_nint_distance(ctx):
        print("demo_nint_distance " + ctx.name)

        print("[ctx.nint_distance(ctx.mpf(5.00000001))]")
        print([ctx.nint_distance(ctx.mpf(5.00000001))])

        print("\nExamples from manual:")
        for ctx in ctxall:
            print([ctx.nint_distance(ctx.mpf(5))])
        print()
        for ctx in ctxall:
            print(ctx.nint_distance(ctx.mpf(5.00000001)), end=', ')
        print()
        for ctx in ctxall:
            print(ctx.nint_distance(ctx.mpf(4.99999999)), end=', ')
        print()
        # problem with iv:
#        for ctx in ctxall:
#            print(ctx.nint_distance(ctx.mpc(5,10)), end=', ')
#        print()
#        for ctx in ctxall:
#            print(ctx.nint_distance(ctx.mpc(5,0.000001)), end=', ')
#        print("\n")

    demo_ismpf(ctx)
    demo_ismpc(ctx)
    demo_isinf(ctx)
    demo_isnan(ctx)
    demo_isnormal(ctx)
    demo_isfinite(ctx)
    demo_isint(ctx)
    demo_ldexp(ctx)
    demo_frexp(ctx)
    demo_mag(ctx)
    demo_nint_distance(ctx)
    print()





# 2.8 Number generation
def demo_2_8_number_generation(ctx):

# 2.8.1 “Lazy” representation of a fraction
    def demo_fraction(ctx):
        print("demo_fraction")
        return

# 2.8.2 Generation of random numbers
    def demo_rand(ctx):
        print("demo_rand")
        return

# 2.8.3 Generation of a list of real numbers
    def demo_arange(ctx):
        print("demo_arange")
        return

# 2.8.4 Generation of a list of evenly spaced real numbers
    def demo_linspace(ctx):
        print("demo_linspace")
        return

    demo_fraction(ctx)
    demo_rand(ctx)
    demo_arange(ctx)
    demo_linspace(ctx)
    print()






# 2.9 Exact mathematical constants
def demo_2_9_exact_mathematical_constants(ctx):

# 2.9.1 Zero
    def demo_zero(ctx):
        print("demo_zero: " + ctx.name)
        print("for ctx in ctxall: print(repr(ctx.zero))")
        for ctx in ctxall: print(repr(ctx.zero))
        print()

# 2.9.2 One
    def demo_one(ctx):
        print("demo_one")
        print("for ctx in ctxall: print(repr(ctx.one))")
        for ctx in ctxall: print(repr(ctx.one))
        print()

# 2.9.3 Imaginary unit
    def demo_j(ctx):
        print("demo_j")
        print("for ctx in ctxall: print(repr(ctx.j))")
        for ctx in ctxall: print(repr(ctx.j))
        print()

# 2.9.4 Positive Infinity
    def demo_inf(ctx):
        print("demo_inf")
        print("for ctx in ctxall: print(repr(ctx.inf))")
        for ctx in ctxall: print(repr(ctx.inf))
        print()

# 2.9.5 Negative Infinity
    def demo_ninf(ctx):
        print("demo_ninf")
        print("for ctx in ctxall: print(repr(ctx.ninf))")
        for ctx in ctxall: print(repr(ctx.ninf))
        print()

# 2.9.6 Not-a-Number: NaN
    def demo_nan(ctx):
        print("demo_nan")
        print("for ctx in ctxall: print(repr(ctx.nan))")
        for ctx in ctxall: print(repr(ctx.nan))
        print()


    demo_zero(ctx)
    demo_one(ctx)
    demo_j(ctx)
    demo_inf(ctx)
    demo_ninf(ctx)
    demo_nan(ctx)
    print()




# 2.10 Approximate mathematical constants
def demo_2_10_approximate_mathematical_constants(ctx):

# 2.10.1 Machine Epsilon
    def demo_eps(ctx):
        print("demo_eps: " + ctx.name)
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.eps))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.eps))
        print()

# 2.10.2 Log2 (ln(2))
    def demo_ln2(ctx):
        print("demo_ln2")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.ln2))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.ln2))
        print()

# 2.10.3 Log10 (ln(10))
    def demo_ln10(ctx):
        print("demo_ln10")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.ln10))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.ln10))
        print()

# 2.10.4 Pi
    def demo_pi(ctx):
        print("demo_pi")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.pi))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.pi))
        print()

# 2.10.5 Euler e
    def demo_e(ctx):
        print("demo_e")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.e))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.e))
        print()

# 2.10.6 Euler-Mascheroni constant
    def demo_euler(ctx):
        print("demo_euler_gamma")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.euler))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.euler))
        print()

# 2.10.7 Golden ratio phi
    def demo_phi(ctx):
        print("demo_phi")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.phi))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.phi))
        print()

# 2.10.8 Catalan’s constant
    def demo_catalan(ctx):
        print("demo_catalan")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.catalan))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.catalan))
        print()

# 2.10.9 Khinchin’s constant
    def demo_khinchin(ctx):
        print("demo_khinchin")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.khinchin))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.khinchin))
        print()

# 2.10.10 Glaisher’s constant
    def demo_glaisher(ctx):
        print("demo_glaisher")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.glaisher))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.glaisher))
        print()

# 2.10.11 Apéry’s constant
    def demo_apery(ctx):
        print("demo_apery")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.apery))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.apery))
        print()

# 2.10.12 Degree
    def demo_degree(ctx):
        print("demo_degree")
        print("for ctx in ctxall: ctx.dps = 35; print(repr(ctx.degree))")
        for ctx in ctxall: ctx.dps = 35; print(repr(ctx.degree))
        print()


    demo_eps(ctx)
    demo_ln2(ctx)
    demo_ln10(ctx)
    demo_pi(ctx)
    demo_e(ctx)
    demo_euler(ctx)
    demo_phi(ctx)
    demo_catalan(ctx)
    demo_khinchin(ctx)
    demo_glaisher(ctx)
    demo_apery(ctx)
    demo_degree(ctx)
    print()





# 2.11 Utility functions
def demo_2_11_utility_functions(ctx):

# 2.11.1 Convertion of scalars
    def demo_t(ctx):
        print("demo_t")
        x1 = ctx.t('3.1')
        print("x1:", x1, type(x1))

        z1 = ctx.t('3.1 + 4.6j')
        print("z1:", z1, type(z1))


        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.name)
            ctx.dps = 10; print([ctx.t(3.5), ctx.t(2+3j)])
            ctx.dps = 10; print([ctx.t('3.1'), ctx.t('3.1 + 4.6j')])
            print()
        print()

    def demo_convert(ctx):
        print("demo_convert")

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.name)
            ctx.dps = 15
            x1 = ctx.convert('3.1')
            print("x1:", x1, type(x1))
            z1 = ctx.convert('3.1 + 4.6j')
            print("z1:", z1, type(z1))
            print()

    def demo_mpmathify(ctx):
        print("demo_mpmathify")
        x1 = ctx.mpmathify('3.1')
        print("x1:", x1, type(x1))

        z1 = ctx.mpmathify('3.1 + 4.6j')
        print("z1:", z1, type(z1))

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.name)
            ctx.dps = 15
            x1 = ctx.mpmathify('3.1')
            print("x1:", x1, type(x1))
            z1 = ctx.mpmathify('3.1 + 4.6j')
            print("z1:", z1, type(z1))
            print()
        print()


# 2.11.2 Decimal string literals with n significant digits (scalars, lists,
# tuples, matrices)
    def demo_nstr(ctx):
        print("demo_nstr")

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.name); ctx.dps = 20
            print(ctx.nstr([+ctx.pi, ctx.ldexp(1,-500)]))
            print(ctx.nstr(ctx.mpf("5e-10"), 5))
            print(ctx.nstr(ctx.mpf("5e-10"), 15, strip_zeros=False))
            print(ctx.nstr(ctx.mpf("5e-10"), 5, strip_zeros=False, min_fixed=-11))
            print(ctx.nstr(ctx.mpf(0), 5, show_zero_exponent=True))
            print()
        print()



# 2.11.3 Printing with n significant digits (scalars, lists, tuples, matrices)
    def demo_nprint(ctx):
        print("demo_nprint")

        print("\nExamples from manual:")
        for ctx in ctxall:
            print(ctx.name); ctx.dps = 20
            ctx.nprint([+ctx.pi, ctx.ldexp(1,-500)])
            ctx.nprint(ctx.mpf("5e-10"), 5)
            ctx.nprint(ctx.mpf("5e-10"), 15, strip_zeros=False)
            ctx.nprint(ctx.mpf("5e-10"), 5, strip_zeros=False, min_fixed=-11)
            ctx.nprint(ctx.mpf(0), 5, show_zero_exponent=True)
            print()
        print()


    demo_t(ctx)
    demo_convert(ctx)
    demo_mpmathify(ctx)
    demo_nstr(ctx)
    demo_nprint(ctx)
    print()





# 2.12 Precision management
def demo_2_12_precision_management(ctx):

# 2.12.1 Automatic precision management
    def demo_autoprec(ctx):
        print("demo_autoprec")
        print()
        print("****************************")
        print("Test autoprec")
        x = ctx.t("1e-10")
        print("ctx.exp(x)-1   : ", ctx.exp(x)-1)
        print("ctx.expm1(x)   : ", ctx.expm1(x))
#        result = ctx.autoprec(lambda t: ctx.exp(t)-1)(x)
#        print("result autoprec: ", result)
        return

# 2.12.2 Temporarily setting the working precision (prec)
    def demo_workprec(ctx):
        print("demo_workprec")
        return

# 2.12.3 Temporarily setting the decimal precision (dps)
    def demo_workdps(ctx):
        print("demo_workdps")
        return

# 2.12.4 Temporarily adding working precision (prec)
    def demo_extraprec(ctx):
        print("demo_extraprec")
        return

# 2.12.5 Temporarily adding decimal precision (dps)
    def demo_extradps(ctx):
        print("demo_extradps")
        return


    demo_autoprec(ctx)
    demo_workprec(ctx)
    demo_workdps(ctx)
    demo_extraprec(ctx)
    demo_extradps(ctx)
    print()




# 2.13 Performance and debugging
def demo_2_13_performance_and_debugging(ctx):

# 2.13.1 Reusing computed values, given a minimal precision
    def demo_memoize(ctx):
        print("demo_memoize")
        return

# 2.13.2 Setting the maximal number of function calls
    def demo_maxcalls(ctx):
        print("demo_maxcalls")
        return

# 2.13.3 Monitoring function calls
    def demo_monitor(ctx):
        print("demo_monitor")
        return

# 2.13.4 Measuring the execution time of function calls
    def demo_timing(ctx):
        print("demo_timing")
        return


    demo_memoize(ctx)
    demo_maxcalls(ctx)
    demo_monitor(ctx)
    demo_timing(ctx)
    print()





# 2.14 Additional required functions
def demo_2_14_additional_required_functions(ctx):

    def demo_singleplot(ctx):
        # Some example data to display
        x = np.linspace(0, 2 * np.pi, 400)
        y = np.sin(x ** 2)
        fig, ax = plt.subplots(figsize=(10, 4.5))
        ax.plot(x, y)
        ax.set_title('A single plot')
        #fig.savefig("foo_0.pdf", bbox_inches='tight')
        fig.savefig(path + r"\foo_0.svg", bbox_inches='tight')


    def demo_stacked_2_plot(ctx):
        # Some example data to display
        x = np.linspace(0, 2 * np.pi, 400)
        y = np.sin(x ** 2)
        fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(10, 4.5))
        fig.suptitle('Horizontally stacked subplots')
        ax1.plot(x, y)
        ax2.plot(x, -y)
        #fig.savefig("foo_2.pdf", bbox_inches='tight')
        fig.savefig(path + r"\foo_2.svg", bbox_inches='tight')


    def demo_stacked_4_plot(ctx):
        # Some example data to display
        x = np.linspace(0, 2 * np.pi, 400)
        y = np.sin(x ** 2)
        fig, ((ax1, ax2), (ax3, ax4)) = plt.subplots(2, 2, figsize=(10, 5))
        fig.suptitle('Sharing x per column, y per row')
        ax1.plot(x, y)
        ax2.plot(x, y**2, 'tab:orange')
        ax3.plot(x, -y, 'tab:green')
        ax4.plot(x, -y**2, 'tab:red')
        for ax in fig.get_axes():
            ax.label_outer()

        #fig.savefig("foo_4.pdf", bbox_inches='tight')
        fig.savefig(path + r"\foo_4.svg", bbox_inches='tight')

    demo_singleplot(ctx)
    demo_stacked_2_plot(ctx)
    demo_stacked_4_plot(ctx)
    print()



def demo_2(ctx):
    demo_2_1_common_interface(ctx)
    demo_2_2_arithmetic_operations(ctx)
    demo_2_3_functions_related_to_intervals(ctx)
    demo_2_4_complex_components(ctx)
    demo_2_5_integer_and_fractional_parts(ctx)
    demo_2_6_tolerances_and_approximate_comparisons(ctx)
    demo_2_7_properties_of_numbers(ctx)
    demo_2_8_number_generation(ctx)
    demo_2_9_exact_mathematical_constants(ctx)
    demo_2_10_approximate_mathematical_constants(ctx)
    demo_2_11_utility_functions(ctx)
    demo_2_12_precision_management(ctx)
    demo_2_13_performance_and_debugging(ctx)
    #demo_2_14_additional_required_functions(ctx)
    print()


mpm.dps=35
dpm.dps=mpm.dps
ipm.dps=mpm.dps
gpm.dps=mpm.dps
#apm.dps=mpm.dps

print("mpm.dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dec
ctxm = mpm
demo_2(ctxm)


