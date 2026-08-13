

def demo_arb_series():
    from flint import arb, arb_series, ctx
    ctx.cap = 18
    x = arb(2)
    ser = arb_series([x,1]).sin()
    ser2 = arb_series([1,4,5,8])
    #ser3 = ser.compose(ser2)
    print("x:", x)
    print("x.sin():", x.sin())
    print("x.cos():", x.cos())
    print("ser :", ser)
    print("ser2:", ser2)

    for i in range(ctx.cap):
        print("i:", i, "ser[i]", ser[i], "der:", ser[i]*arb(i).fac())
    return



def demo_arb_series_arithmetic():
    from flint import arb, arb_series, ctx
    ctx.cap = 18
    x = arb(2)
    ser1 = arb_series([x,1]).sin()
    ser2 = arb_series([x,1]).cos()
    ser3 = ser1 + ser2
    ser4 = ser1 - ser2
    ser5 = ser1 * ser2
    ser6 = ser1 / ser2
    ser7 = ser1 * ser1
    ser8 = ser1 ** 2
    ser9 = ser1 ** ser2
    print("x:", x)
    print("ser1:", ser1)
    print("ser2:", ser2)
    print("ser3:", ser3)
    print("ser4:", ser4)
    print("ser5:", ser5)
    print("ser6:", ser6)
    print("ser7:", ser7)
    print("ser8:", ser8)
    print("ser9:", ser9)

def demo_arb_series_compose():
    from flint import arb, arb_series, ctx
    ctx.cap = 9
    x = arb(2.5)
    ser_g = arb_series([x,1]).sqrt()
    ser_h = ser_g.sin()
    print("x:", x)
    print("ser_g:", ser_g)
    print("ser_h:", ser_h)


def demo_arb_showgood_str():
    from flint import arb, showgood
    from io import StringIO
    import sys
    showgood(lambda: (arb(1)/3).gegenbauer_c(5, 0.25), dps=25)

    try:
        old_stdout = sys.stdout
        sys.stdout = mystdout = StringIO()

        # blah blah lots of code ...
        showgood(lambda: (arb(1)/3).gegenbauer_c(5, 0.25), dps=25)

    finally:
        sys.stdout = old_stdout
        s = mystdout.getvalue()
    print("s:", s)





def demo_acb_poly():
    from flint import acb_poly
    for c in acb_poly.from_roots([1,2,3,4,5]).roots(1e-10):
        print(c)
    return



def demo_arb_mat():
    from flint import arb_mat
    matA = arb_mat(3, 3, range(9))
    print("matA: \n", matA)
    res = matA.det()
    print("res = matA.det(): ", res)
    matA[2,2] = 10
    print("matA: \n", matA)
    res = matA.det()
    print("res = matA.det(): ", res)
    matA = matA * matA
    print("matA: \n", matA)
    res = matA.det()
    print("res = matA.det(): ", res)
    return



def demo_acb_mat():
    # see: https://python-flint.readthedocs.io/en/latest/acb_mat.html
    from flint import acb_mat
    print("characteristic polynomial")
    print(acb_mat(2, 2, [1, 1, 1, 0]).charpoly())

    print("matrix exponential")
    print(acb_mat(2, 2, [1, 4, -2, 1]).exp())


    print("matrix solve")
    A = acb_mat(2, 2, [1, 2, 3, 4])
    X = acb_mat(2, 3, range(6))
    B = A * X
    print(A.solve(B))


def demo_eigensystem():
    # see: https://python-flint.readthedocs.io/en/latest/acb_mat.html#flint.acb_mat.eig

    from flint import acb_mat

    print("eigenvalues, vdhoeven_mourrain")
    A = acb_mat([[2,3,5],[7,11,13],[17,19,23]])
    for c in A.eig(): print(c)

    print("eigenvalues, rump")
    A = acb_mat([[2,3,5],[7,11,13],[17,19,23]])
    for c in A.eig(algorithm="rump"): print(c)

    print("complete diagonalization")
    A = acb_mat([[2,3,5],[7,11,13],[17,19,23]])
    E, L, R = A.eig(left=True, right=True)
    D = acb_mat(3,3)
    for i in range(3): D[i,i] = E[i]
    print( (L*A*R - D).contains(acb_mat(3,3)) )
    print( (R*D*L - A).contains(acb_mat(3,3)) )



def demo_find_roots_arb():
    # see: https://python-flint.readthedocs.io/en/latest/arb_series.html#flint.arb_series.find_roots
    from flint import arb_series
    print("sin(x)")
    for c in arb_series.find_roots(lambda x: x.sin(), -8, 8): print(c)
    print("sin(riemann_siegel_z)")
    for c in arb_series.find_roots(lambda x: x.riemann_siegel_z(), 0, 30): print(c)



def demo_complex_roots_acb():
    # see: https://python-flint.readthedocs.io/en/latest/acb_poly.html#flint.acb_poly.from_roots
    # see: https://python-flint.readthedocs.io/en/latest/acb_poly.html#flint.acb_poly.roots

    from flint import acb_poly
    for c in acb_poly.from_roots([1,2,3,4,5]).roots(1e-10): print(float(c.real))




def demo_integral():
    # see: https://python-flint.readthedocs.io/en/latest/acb.html#flint.acb.integral
    from flint import arb, acb
    from flint import showgood

    print("integral: sin(x)")
    showgood(lambda: acb.integral(lambda x, _: x.sin(), 0, arb.pi()), dps=25)

    print("integral: x + gamma(sin(x))")
    showgood(lambda: acb.integral(lambda x, _: (x + x.sin()).gamma(), 1, 1+1j), dps=25)

    print("integral: sqrt(x)")
    showgood(lambda: acb.integral(lambda x, _: x.sqrt(), 1, 4), dps=25)  # WRONG!!!

    print("integral: sqrt(x), analytic")
    showgood(lambda: acb.integral(lambda x, a: x.sqrt(analytic=a), 1, 4), dps=25)  # correct

    print("integral: sech(x)")
    showgood(lambda: acb.integral(lambda x, _: x.sech(), -1000, 1000), dps=25)



def demo_arb_poly_2():
    from flint import acb_poly
    f = acb_poly([1,2,3])
    g = acb_poly([0,0,1])
    h = f.compose(g)  # no attribute 'compose'
    print(h)



def demo_dft_1():
    # See: https://python-flint.readthedocs.io/en/latest/acb.html#flint.acb.dft
    from flint import acb
    for c in acb.dft(acb.dft(range(1,12)), inverse=True):
        print(c)
    res = sum(acb.dft(acb.dft(range(1,10001)), inverse=True)).contains(50005000)
    print(res)

#demo_arb_series()

#demo_arb_series_arithmetic()

demo_arb_series_compose()

#demo_arb_showgood_str()

#demo_acb_poly()

#demo_arb_mat()

#demo_acb_mat()

#demo_eigensystem()

#demo_find_roots_arb()

#demo_complex_roots_acb()

#demo_integral()

#demo_arb_poly_2()

#demo_dft_1()



