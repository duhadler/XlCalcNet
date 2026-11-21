import os

import xlcalcnet.userpaths as userpaths
import numpy as np
from xlcalcnet import apm, dpm, fpm, gpm, ipm, mpm, npm, qpm
from xlcalcnet.ctx_mparray import (
##    L_solve,
    LU_decomp,
##    U_solve,
    balance_matrix,
    bfgs_c,
##    c_he_tridiag_0,
##    c_he_tridiag_1,
##    c_he_tridiag_2,
##    cholesky,
    cholesky_solve,
##    cols,
##    cond,
##    contains_complex,
    cosm,
    det,
    eig,
##    eig_tr_l,
    eig_tr_r,
    eigh,
##    eighe,
##    eigsy,
    empty,
    expm,
    eye,
    gauss_quadrature,
    gradient_c,
    hessenberg,
    hessenberg_qr,
##    hessenberg_reduce_0,
##    hessenberg_reduce_1,
##    householder,
    inv_ldl_precomp,
    inverse,
    jacobi_c,
    lbfgs_c,
    ldl_golub_and_van_loan,
    ldl_solve,
    levenberg_marquardt_c,
    linspace,
    logm,
    lu,
    lu_solve,
    matrix_power,
    mnorm,
    norm,
    ones,
    powm,
    qr,
    qr_solve,
##    qr_step,
##    r_sy_tridiag,
##    rows,
    schur,
    sinm,
    solve_ldl_precomp,
    sqrtm,
    svd,
    ##    svd_c,
    ##    svd_c_raw,
    ##    svd_r,
    ##    svd_r_raw,
    swap_rows,
    to_cpx,
    to_fp,
    to_mp,
##    tridiag_eigen,
##    unitvector,
    vector_norm,
    zeros,
)

## ******* Basic calculations without sqrt ******************


ctxall = [mpm, ipm, dpm, gpm, apm]





def demo_read_from_cvs(ctx):
    to_ctx = npm.vectorize(ctx.t, otypes=[object])

    csvpath = os.sep.join([userpaths.get_my_documents(), \
        'DataXlCalcNet', 'DataExamples', 'MainExamples', 'CSV'])
    csvfile = r'\Hald.csv'
    csvname = csvpath + csvfile

    with open(csvname) as f:
        header = f.readline().strip('\n')
    print(header)

    nd_data = npm.genfromtxt(csvname, dtype=np.float64, delimiter=",", \
    skip_header=1, usecols=(0,1,2,3,4))
    A = to_ctx(nd_data)
    N = len(A)
    print("N:", N)
    print("A: \n", A)



def demo_read_stats_cvs(ctx):
    to_ctx = npm.vectorize(ctx.t, otypes=[object])

    csvpath = os.sep.join([userpaths.get_my_documents(), \
        'DataXlCalcNet', 'DataExamples', 'MainExamples', 'CSV'])

##    csvfile = r'\ZBankNotes.csv'
    csvfile = r'\ZBankNotesEcht.csv'
##    csvfile = r'\ZBankNotesFalsch.csv'
##    csvfile = r'\ZBankNotesShort.csv'
    csvname = os.sep.join([csvpath, csvfile])

    with open(csvname) as f:
        header = f.readline().strip('\n')
    print(header)

    nd_data = npm.genfromtxt(csvname, dtype=np.float64, delimiter=",", skip_header=1, usecols=(0,1,2,3,4,5))
    A = to_ctx(nd_data)
    N = len(A)
    print("N:", N)
    #print("A: \n", A)

    Amean = npm.mean(A, axis=0)
    print("Amean:", Amean)

    Avar = npm.var(A, ddof=1, axis=0)
    print("Avar:", Avar)

    Acentered = A - Amean

    Acovar = (Acentered.T @ Acentered)/(N-1)
    print("Acovar:", Acovar)

    if ctx is not qpm:
        f = npm.vectorize(ctx.sqrt, otypes=[object])
        Astd = f(Avar)
        print("Astd:", Astd)

        Acorr = Acovar / (npm.outer(Astd, Astd))
        print("Acorr:", Acorr)




def demo_read_hald_cvs(ctx):
    to_ctx = npm.vectorize(ctx.t, otypes=[object])

    csvpath = os.sep.join([userpaths.get_my_documents(), \
        'DataXlCalcNet', 'DataExamples', 'MainExamples', 'CSV'])
    csvfile = r'\Hald.csv'
    csvname = os.sep.join([csvpath, csvfile])
    with open(csvname) as fname:
        header = fname.readline().strip('\n')
    print("header: ", header)

    x_data = npm.genfromtxt(csvname, dtype=np.float64, delimiter=",", \
        skip_header=1, usecols=(0,1,2,3))
    x_data = to_ctx(x_data)

    y_data = npm.genfromtxt(csvname, dtype=np.float64, delimiter=",", \
        skip_header=1, usecols=(-1))
    y_data = to_ctx(y_data)
    y = npm.atleast_2d(y_data).T

    #newcol = to_ctx(npm.ones((len(x_data), 1)))

    newcol = npm.ones(shape=(len(x_data),1), dtype=ctx)


    X = npm.hstack((newcol, x_data))
    print("X: \n",X)
    print("y: \n",y)

    XH = X.T
    #XH = X.T.conj()
    A = XH @ X
    b = XH @ y

    print("A: \n",A)
    print("b: \n",b)


    #beta = lu_solve(ctx, A, b)
    beta = ldl_solve(ctx, A, b)
    #beta = cholesky_solve(ctx, A, b)
    #beta = qr_solve(ctx, A, b)
    print("beta: \n",beta)
    #print("A@beta-b: \n", A@beta-b)

    y_est = X @ beta
    print("y_est: \n", y_est)

    e_est = y_est - y
    print("e_est: \n", e_est)

    s0 = npm.var(y) * len(y)
    print("s0:", repr(s0))

    smin = npm.dot(npm.atleast_2d(e_est).T, e_est).item(0)
    print("smin:", smin)


    N = len(x_data)
    print("N:", N)
    p = npm.shape(A)[1] - 1
    print("p:", p)
    q = ctx.t(0)
    print("q:", q)


    dferr = N - p - 1
    print("dferr:", dferr)

    dftreat= p - q
    print("dftreat:", dftreat)

    streat = (s0 - smin)
    print("streat:", streat)

    mstreat = (s0 - smin) / dftreat
    print("mstreat:", mstreat)



    serr = s0
    print("serr:", serr)

    mserr = smin / dferr
    print("mserr:", mserr)

    F = mstreat/mserr
    print("F:", F)

    R2 = (s0-smin) / (s0)
    print("R2:", R2)

    F_R2 = R2/(1-R2) * dferr/dftreat
    print("F_R2:", F_R2)

    R2_F = F * dftreat / (F * dftreat + dferr)
    print("R2_F:", R2_F)




def demo_read_from_xlsm(ctx):
    import os

    import pandas as pd
    to_ctx = npm.vectorize(ctx.t, otypes=[object])

    workbookfilename = 'Datasets.xlsx'
    workbookpath = os.sep.join([userpaths.get_my_documents(), 'DataXlCalcNet', \
        'DataExamples', 'MainExamples', 'Workbooks', workbookfilename])

    df0 = pd.read_excel(workbookpath, sheet_name='banknotes' )
    df1 = df0[df0['Source'] == ' genuine']
    #df2 = df0[df0['Source'] == ' counterfeit']
    colnames = ['Length', 'Left', 'Right', 'Bottom', 'Top', 'Diagonal']
    nd_df1  = df1[colnames ].to_numpy()
    #nd_df2  = df2[colnames ].to_numpy()

    #matA = ctx.t1 * nd_df1

    matA = to_ctx(nd_df1)

    #x_data = to_ctx(x_data)

    print()
    print(matA)
    print

    res = npm.mean(matA, axis=0)
    print("mean:", res)

    res = npm.var(matA, axis=0)
    print("var:", res)

    res = npm.min(matA, axis=0)
    print("min:", res)

    res = npm.median(matA, axis=0)
    print("median:", res)

    res = npm.max(matA, axis=0)
    print("max:", res)








def demo_to_mp(ctx):
    x = to_mp(ctx, [3.4, 5.6])
    print("x: ", x)
    assert x.shape == (2,) and x.dtype == 'O' and np.allclose(to_fp(x), [3.4, 5.6])
    x = to_mp(ctx, np.arange(10))
    print("x: ", x)
    assert x.shape == (10,) and x.dtype == 'O' and x[4] == 4
    print("demo_to_mp(): passed")



def demo_linspace(ctx):
    x = linspace(ctx, 3, 5, 17)
    print("x: ", x)
    assert np.allclose(to_fp(x), np.linspace(3, 5, 17))
    x = linspace(ctx, 4.5, -3.8, 7, endpoint=False)
    print("x: ", x)
    assert np.allclose(to_fp(x), np.linspace(4.5, -3.8, 7, endpoint=False))
    print("test_linspace(): passed")




def demo_operators_real(ctx):
    d1 = ctx.t(1)
    d3 = ctx.t(3)
    print("d1:", d1)
    print("d3:", d3)

    R = np.ndarray((3,3),dtype=object)

    for i in range(3):
        for k in range(3):
            R[i,k] = 10+(i+1) + d1/(k+1)

    print("R: \n", R)
    print(type(R))
    print("R + R: \n", R + R)
    print("R - R: \n", R - R)
    print("R * R: \n", R * R)
    print("R / R: \n", R / R)
    print("R @ R: \n", R @ R)

    print("R: \n", R)
    print("d3 + R: \n", d3 + R)
    print("d3 - R: \n", d3 - R)
    print("d3 * R: \n", d3 * R)
    print("d3 / R: \n", d3 / R)

    print("R: \n", R)
    print("R + d3: \n", R + d3)
    print("R - d3: \n", R - d3)
    print("R * d3: \n", R * d3)
    print("R / d3: \n", R / d3)



def demo_operators_complex(ctx):
    z1 = ctx.t(1+1j)
    z3 = ctx.t(3+3j)
    print("z1:", z1)
    print("z3:", z3)

    Z = np.ndarray((3,3),dtype=ctx.complextype)

    for i in range(3):
        for j in range(3):
            Z[i,j] = 10+(i+1) + z1/(j+1)


    print("Z: \n", Z)
    print("Z + Z: \n", Z + Z)
    print("Z - Z: \n", Z - Z)
    print("Z * Z: \n", Z * Z)
    print("Z / Z: \n", Z / Z)
    print("Z @ Z: \n", Z @ Z)

    print("Z: \n", Z)
    print("z3 + Z: \n", z3 + Z)
    print("z3 - Z: \n", z3 - Z)
    print("z3 * Z: \n", z3 * Z)
    print("z3 / Z: \n", z3 / Z)

    print("Z: \n", Z)
    print("Z + z3: \n", Z + z3)
    print("Z - z3: \n", Z - z3)
    print("Z * z3: \n", Z * z3)
    print("Z / z3: \n", Z / z3)




def demo_basics(ctx):
    print("matA = zeros(ctx, (3,4))")
    matA = zeros(ctx, (3,4))
    print(matA)
    print()

    print("matA = ones(ctx, (3,4))")
    matA = ones(ctx, (3,4))
    print(matA)
    print()

    print("matA = empty(ctx, (3,4))")
    matA = empty(ctx, (3,4))
    print(matA)
    print()

    print("eye(ctx, 4)")
    matA = eye(ctx, 4)
    print(matA)
    print()

    print("linspace(ctx, 1, 4, 10)")
    matA = linspace(ctx, 1, 4, 10)
    print(matA)
    print()

    print("matA = np.random.rand(4, 10)")
    matA = np.random.rand(4, 10)
    #matA = ctx.t(1) * matA
    matA = npm.t(ctx, matA)
    print(matA)
    print()
    print("swap_rows(matA, 0, 1)")
    swap_rows(matA, 0, 1)
    print(matA)
    print()

    if ctx is not qpm:
        print("matA = np.random.rand(4, 10) + 1j * np.random.rand(4, 10)")
        matA = np.random.rand(4, 10) + 1j * np.random.rand(4, 10)
        #matA = ctx.t(1) * matA
        matA = npm.t(ctx, matA)
        print("matA:", matA)
        print()
        print("swap_rows(matA, 0, 1)")
        swap_rows(matA, 0, 1)
        print(matA)
        print()

        print("matA = np.random.rand(1, 10)")
        matA = np.random.rand(1, 10)
        matA = npm.t(ctx, matA)
        print(matA)
        print("vn = vector_norm(ctx, matA)")
        vn = vector_norm(ctx, matA)
        print("norm:", vn)
        print()





def demo_matrix_power(ctx):
    n = 2
    A = np.array([[ctx.t(0), ctx.t(1)/3], [ctx.t(-1)/6, ctx.t(0)]])
    print(A)
    res = matrix_power(ctx, A, n)
    print("res = matrix_power(ctx, A, n)")
    print(res)




def demo_sort(ctx):
    a = np.array([[1,4],[3,1]])
    print("a = np.array([[1,4],[3,1]])")
    a = ctx.t(1) * a
    # return sorted array
    res = np.sort(a)
    print(res)
    print()
    res = np.sort(a, axis=None)
    print(res)
    print()
    res = np.sort(a, axis=0)
    print(res)
    print()
    # in place sort : see https://numpy.org/doc/stable/reference/generated/numpy.ndarray.sort.html
    res = a.tolist()
    print(res)
    print()







def demo_statistic(ctx):
    matA = np.random.rand(2, 10)
    matA = npm.t(ctx, matA)
    print("matA", matA, "\n")

    # see: C:\Users\dietrichhadler\Documents\Python310\Lib\site-packages\numpy\lib\function_base.py

##    res = np.ptp(matA, axis=1)
##    print("ptp:", res)
##
##    res = np.percentile(matA, 75, axis=1)
##    print("percentile:", res)
##
##    res = np.nanpercentile(matA, 75, axis=1)
##    print("nanpercentile:", res)
##
##    res = np.quantile(matA, 0.75, axis=1)
##    print("quantile:", res)
##
##    res = np.nanquantile(matA, 0.75, axis=1)
##    print("nanquantile:", res)

    res = npm.median(matA, axis=1)
    print("median:", res)

    res = npm.average(matA, axis=1)
    print("average:", res)

    res = npm.mean(matA, axis=1)
    print("mean:", res)

    res = npm.var(matA, axis=1)
    print("var:", res)


    res = npm.max(matA, axis=0)   # amax is an alias
    print("max, axis=0:", res, "\n")

    res = npm.max(matA, axis=1)
    print("max, axis=1:", res, "\n")


    res = npm.min(matA, axis=0)   # amin is an alias
    print("min, axis=1:", res, "\n")

    res = npm.min(matA, axis=1)
    print("min, axis=1:", res, "\n")



    res = npm.prod(matA, axis=0)
    print("prod, axis=0:", res, "\n")

    res = npm.prod(matA, axis=1)
    print("prod, axis=1:", res, "\n")


    res = npm.sum(matA, axis=0)
    print("sum, axis=0:", res, "\n")

    res = npm.sum(matA, axis=1)
    print("sum, axis=1:", res, "\n")



    res = npm.cumprod(matA, axis=0)
    print("cumprod, axis=0:", res, "\n")

    res = npm.cumprod(matA, axis=1)
    print("cumprod, axis=1:", res, "\n")


    res = npm.cumsum(matA, axis=0)
    print("cumsum, axis=0:", res, "\n")

    res = npm.cumsum(matA, axis=1)
    print("cumsum, axis=1:", res, "\n")

    res = npm.diff(matA, axis=0)
    print("diff, axis=0:", res, "\n")

    res = npm.diff(matA, axis=1)
    print("diff, axis=1:", res, "\n")

    res = npm.ediff1d(matA)
    print("ediff1d:", res, "\n")

    res = npm.ediff1d(matA)
    print("ediff1d:", res, "\n")


    x = ctx.t(1) * np.array([1, 2, 3])
    y = ctx.t(1) * np.array([4, 5, 6])
    res = npm.cross(x, y)
    print("np.cross(x, y):", res, "\n")


    x = (np.array([1, 2, 3]) * 1)
    x = npm.t(ctx, x)
    res = npm.conj(ctx, x)
    print("npm.conj(ctx, x):", res, "\n")

    if ctx is not qpm:
        x = (np.array([1, 2, 3]) * 1j)
        x = npm.t(ctx, x)
        res = npm.conj(ctx, x)
        print("npm.conj(ctx, x):", res, "\n")


    x = ctx.t(1) * np.array([1, 2, 3])
    res = npm.square(x)
    print("npm.square(x, y):", res, "\n")

##    currrently converts to double precision
##    x = ctx.t(1) * np.array([-1+1j, 2, -3])
##    res = np.absolute(x)
##    print("npm.absolute(x, y):", res, "\n")

    x = ctx.t(1) * np.array([-1, 2, -3])
    res = npm.sign(x)
    print("np.sign(x):", res, "\n")

    x = np.array([-1.1, 2.1, -3.6])
    x = npm.t(ctx, x)
    res = npm.floor(x)
    print("npm.floor(x):", res, "\n")

    x = np.array([-1.1, 2.1, -3.6])
    x = npm.t(ctx, x)
    res = npm.ceil(x)
    print("npm.ceil(x):", res, "\n")

    x = np.array([-1.1, 2.1, -3.6])
    x = npm.t(ctx, x)
    res = npm.reciprocal(x)
    print("npm.reciprocal(x):", res, "\n")

    x = np.array([-1.1, 2.1, -3.6])
    x = npm.t(ctx, x)
    res = npm.positive(x)
    print("npm.positive(x):", res, "\n")

    x = np.array([-1.1, 2.1, -3.6])
    x = npm.t(ctx, x)
    res = npm.negative(x)
    print("npm.negative(x):", res, "\n")

    x = np.array([-1.1, 2.1, -3.6])
    x = npm.t(ctx, x)
    res = npm.fix(x)
    print("npm.fix(x):", res, "\n")




    matB = np.random.rand(2, 10)
    matB = npm.t(ctx, matB)
    matB = matB * ctx.t(1.5)
    #matB[1,1] = ctx.nan # nan causes crash with decimal
    print("matB", matB, "\n")



    res = npm.maximum(matA, matB)
    print("maximum:", res, "\n")

    res = npm.minimum(matA, matB)
    print("minimum:", res, "\n")

    # not working for decimal: gradient and cross (no arithmetic with double)

##    res = np.gradient(matA)
##    print("gradient:", res, "\n")
##    x = ctx.t1 * np.array([1, 2, 3])
##    res = np.trapz(x)
##    print("np.trapz(x, y):", res, "\n")

    # not working for mpm or ipm: trunc: trunc not defined

##    x = ctx.t1 * np.array([-1.1, 2.1, -3.6])
##    res = np.trunc(x)
##    print("np.trunc(x, y):", res, "\n")



    #Note: nan functions etc not working


    #Note: corr, covar etc not working

    print()



def demo_lu_solve_real(ctx):
    n = 5
    A, b = np.random.rand(n, n), np.random.rand(n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t(1) * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = lu_solve(ctx, A, b)
    print("x = lu_solve(ctx, A, b)")
    print(x)
    print(x.shape)
    print()
    print(" A @ x - b", A @ x - b)
    print()
    assert x.shape == (n,)
    print("Passed: assert x.shape == (n,)")
    assert np.allclose(to_fp(A @ x), to_fp(b))
    print("Passed: assert np.allclose(to_fp(A @ x), to_fp(b))")


def demo_lu_solve_real_block(ctx):
    n = 5
    A, b = np.random.rand(n, n), np.random.rand(n, 3)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t(1) * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = lu_solve(ctx, A, b)
    print("x = lu_solve(ctx, A, b)")
    print(x)
    print()
    print(" A @ x - b", A @ x - b)
    print()
    assert x.shape == (n,3)
    print("Passed: assert x.shape == (n,3)")
    assert np.allclose(to_fp(A @ x), to_fp(b))
    print("Passed: assert np.allclose(to_fp(A @ x), to_fp(b))")


def demo_lu_solve_complex(ctx):
    n = 5
    A, b = np.random.rand(n, n) + 1j * np.random.rand(n, n), np.random.rand(n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t(1) * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = lu_solve(ctx, A, b)
    print("x = lu_solve(ctx, A, b)")
    print(x)
    print()
    res = A @ x - b
    print("res = A @ x - b")
    print(res)
    print()
    assert x.shape == (n,)
    print("Passed: assert x.shape == (n,)")
    assert np.allclose(to_cpx(A @ x), to_cpx(b))
    print("Passed: assert np.allclose(to_cpx(A @ x), to_cpx(b))")


def demo_lu_real(ctx):
    n = 5
    A = np.random.rand(n, n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    P, L, U = lu(ctx, A)
    print("P:")
    print(P)
    print()
    print("L:")
    print(L)
    print()
    print("U:")
    print(U)
    print()
    print("P @ A - L @ U:", P @ A - L @ U)

    assert np.allclose(to_fp(P @ A), to_fp(L @ U))
    print("test_lu(): passed")


def demo_lu_complex(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    P, L, U = lu(ctx, A)
    print("P:")
    print(P)
    print()
    print("L:")
    print(L)
    print()
    print("U:")
    print(U)
    print()
##    assert np.allclose(to_cpx(P @ A), to_cpx(L @ U))
    print("test_lu(): passed")





def demo_inverse_real(ctx):
    n = 5
    A = np.random.rand(n, n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    print("Ainv = inverse(ctx, A)")
    Ainv = inverse(ctx, A)
    print(Ainv)
    print()
    print("C = A @ Ainv")
    C = A @ Ainv
    print(C)
    assert A.shape == (n, n)
    print("Passed: assert A.shape == (n, n)")
    assert np.allclose(to_fp(Ainv @ A), np.eye(n))
    print("Passed: assert np.allclose(to_fp(Ainv @ A), np.eye(n))")
    print()


def demo_inverse_complex(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)

##    A = np.array([[0.681+0.459j, 0.508 + 0.044j], [0.969 + 0.136j, 0.021 + 0.096j]])

    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    print("Ainv = inverse(ctx, A)")
    Ainv = inverse(ctx, A)
    print(Ainv)
    print()
    print("matC = C = A @ Ainv")
    C = A @ Ainv
    print(C)
    assert A.shape == (n, n)
    print("Passed: assert A.shape == (n, n)")

    nc = to_cpx(C)
    print("nc = to_cpx(C)")
    print(nc)
    npe = to_cpx(np.eye(n))
    print("npe = to_cpx(np.eye(n))")
    print(npe)
    assert np.allclose(nc, npe)
    print("Passed: assert np.allclose(C), npe")
    print()

def demo_det(ctx):
    n = 5
    E = np.random.rand(n)   # random eigenvalues
    #E =  ctx.t(1) * E
    E = npm.t(ctx, E)
    print("E:", E)
    print()
    detE = np.prod(E)
    print("detE = np.prod(E)")
    print(detE)
    Ediag = np.diag(E)
    print("Ediag = np.diag(E)")
    print(Ediag)
    print()
    #U = set_random_real(ctx, n, n)
    U = np.random.rand(n, n)
    U = npm.t(ctx, U)

    Uinv = inverse(ctx, U)
    A = U @ np.diag(E) @ Uinv
    det1 = det(ctx, A)
    print("det1= det(ctx, A):", det1)
    det2 = np.prod(E)
    print("det2 = np.prod(E):", det2)
    print("det1 - det2:", det1 - det2)
    assert np.allclose(to_fp(det1), to_fp(det2))
    print("demo_det(): passed")



def demo_ldl_golub_and_van_loan(ctx):
    A = [[10,20,30],[20,45,80],[30,80,171]]
    B = np.array([[8,7,19]]).T
    print("A = [[10,20,30],[20,45,80],[30,80,171]]")
    print("B = np.array([[8,7,19]]).T")
    L = ldl_golub_and_van_loan(ctx, A)
    print("L:", L)
    Ainv = inv_ldl_precomp(ctx, L)
    print("Ainv:", Ainv)
    print("A@Ainv", A@Ainv)
    X = solve_ldl_precomp(ctx, L, B)
    print("X:", X)
    print("A@X-B:", A@X-B)





## ******* Linalg with sqrt ******************



def demo_norm(ctx):
    x = np.array([-10, 2, 100])
    print(x)
    x = to_mp(ctx, x)
    print(x)
    res = norm(ctx, x, 1)
    print("res = norm(ctx, x, 1): ", repr(res))
    res = norm(ctx, x, 2)
    print("res = norm(ctx, x, 2): ", repr(res))
    res = norm(ctx, x, ctx.inf)
    print("res = norm(ctx, x, ctx.inf): ", repr(res))



def demo_mnorm(ctx):
    A = np.array([[1, -1000], [100, 50]])
    print(A)
    A = to_mp(ctx, A)
    print(A)
    res = mnorm(ctx, A, 1)
    print("res = mnorm(ctx, A, 1): ", repr(res))
    res = mnorm(ctx, A, ctx.inf)
    print("res = mnorm(ctx, A, ctx.inf): ", repr(res))
    res = mnorm(ctx, A, 'F')
    print("res = mnorm(ctx, A, 'F'): ", repr(res))





def demo_cholesky_solve_real(ctx):
    n = 5
    A, b = np.random.rand(n, n), np.random.rand(n)
    A = A.T @ A
    #A = ctx.t1 * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t1 * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = cholesky_solve(ctx, A, b)
    print("x = cholesky_solve(ctx, A, b)")
    print(x)
    print()
    res = A @ x - b
    print("res = A @ x - b")
    print(res)
    print(x.shape)
    assert x.shape == (n,)
    print("Passed: assert x.shape == (n,)")
    assert np.allclose(to_fp(A @ x), to_fp(b))
    print("Passed: assert np.allclose(to_fp(A @ x), fp(b))")




def demo_cholesky_solve_cplx(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    b = np.random.rand(n) + 1j * np.random.rand(n)
    #A, b = np.random.rand(n, n), np.random.rand(n)
    A = A.conj().T @ A
    #A = ctx.t1 * A
    A = npm.t(ctx, A)
    ##A = npm.force_complex(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t1 * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = cholesky_solve(ctx, A, b)
    print("x = cholesky_solve(ctx, A, b)")
    print(x)
    print()
    res = A @ x - b
    print("res = A @ x - b")
    print(res)
    print(x.shape)
    assert x.shape == (n,)
    print("Passed: assert x.shape == (n,)")
    assert np.allclose(to_cpx(A @ x), to_cpx(b))
    print("Passed: assert np.allclose(to_cplx(A @ x), to_cplx(b))")



def demo_cholesky_solve_cplx_block(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    b = np.random.rand(n, 3) + 1j * np.random.rand(n, 3)
    #A, b = np.random.rand(n, n), np.random.rand(n, 3)
    A = A.conj().T @ A
    #A = ctx.t1 * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t1 * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = cholesky_solve(ctx, A, b)
    print("x = cholesky_solve(ctx, A, b)")
    print(x)
    print()
    res = A @ x - b
    print("res = A @ x - b")
    print(res)
    print()
    assert x.shape == (n,3)
    print("Passed: assert x.shape == (n,3)")
    assert np.allclose(to_cpx(A @ x), to_cpx(b))
    print("Passed: assert np.allclose(to_cplx(A @ x), to_cplx(b))")



def demo_cholesky_solve_real_block(ctx):
    n = 5
    A, b = np.random.rand(n, n), np.random.rand(n, 3)
    A = A.T @ A
    #A = ctx.t1 * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t1 * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = cholesky_solve(ctx, A, b)
    print("x = cholesky_solve(ctx, A, b)")
    print(x)
    print()
    res = A @ x - b
    print("res = A @ x - b")
    print(res)
    print()
    assert x.shape == (n,3)
    print("Passed: assert x.shape == (n,3)")
    assert np.allclose(to_fp(A @ x), to_fp(b))
    print("Passed: assert np.allclose(to_fp(A @ x), fp(b))")




def demo_qr_real(ctx):
    n = 5
    A = np.random.rand(n, n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()

    print("Q, R = qr(ctx, matA)")
    Q, R = qr(ctx, A)
    print("Q:", Q)
    print("R:", R)
    assert Q.shape == (n, n) and R.shape == (n, n)
    print("Passed: assert Q.shape == (n, n) and R.shape == (n, n)")
    assert np.allclose(to_fp(Q.T @ Q), np.eye(n))
    print("Passed: assert np.allclose(to_fp(Q.T @ Q), np.eye(n))")
    assert np.allclose(to_fp(Q @ R), to_fp(A))
    print("Passed: assert np.allclose(to_fp(Q @ R), to_fp(A))")
    assert np.all(np.tril(R, -1) == 0)
    print("Passed: assert np.all(np.tril(R, -1) == 0)")
    print()





def demo_qr_complex(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    print("Q, R = qr(ctx, matA)")
    Q, R = qr(ctx, A)
    print("Q:", Q)
    print("R:", R)
    assert Q.shape == (n, n) and R.shape == (n, n)
    print("Passed: assert Q.shape == (n, n) and R.shape == (n, n)")
    print("Q.item(0): ", Q.item(0))
    z = Q.item(0)
    print("z: ", z)

    cz = complex(z.real, z.imag)
    print("cz: ", cz)

    temp = to_cpx(Q.T.conj() @ Q)
    print("temp: ", temp)

    temp = to_cpx(Q @ R)
    print("temp: ", temp)

    temp = to_cpx(A)
    print("temp: ", temp)


    assert np.allclose(to_cpx(Q.T.conj() @ Q), np.eye(n))
    print("Passed: assert np.allclose(to_cpx(Q.T.conj() @ Q), np.eye(n))")
    assert np.allclose(to_cpx(Q @ R), to_cpx(A))
    print("Passed: assert np.allclose(to_cpx(Q @ R), to_cpx(A))")
    assert np.all(np.tril(R, -1) == 0)
    print("Passed: assert np.all(np.tril(R, -1) == 0)")

    print()



def demo_qr_solve_real_block(ctx):
    n = 5
    A, b = np.random.rand(n, n), np.random.rand(n, 3)
    A = A.T @ A
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t(1) * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = qr_solve(ctx, A, b)
    print("x = lu_solve(ctx, A, b)")
    print(x)
    print()
    assert x.shape == (n,1)
    print("Passed: assert x.shape == (n,)")
    assert np.allclose(to_fp(A @ x), to_fp(b))
    print("Passed: assert np.allclose(to_fp(A @ x), to_fp(b))")



def demo_qr_solve_real(ctx):
    n = 5
    A, b = np.random.rand(n, n), np.random.rand(n)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    #b = ctx.t(1) * b
    b = npm.t(ctx, b)
    print("b:", b)
    print()
    x = qr_solve(ctx, A, b)
    print("x = lu_solve(ctx, A, b)")
    print(x)
    print()
    assert x.shape == (n,)
    print("Passed: assert x.shape == (n,)")
    assert np.allclose(to_fp(A @ x), to_fp(b))
    print("Passed: assert np.allclose(to_fp(A @ x), to_fp(b))")




def demo_qr_solve_real_overdet(ctx):
    n = 5
    A, b = np.random.rand(n + 2, n), np.random.rand(n + 2, 3)
    #A = ctx.t(1) * A
    A = npm.t(ctx, A)
    print("A:", A)
    #b = ctx.t(1) * b
    b = npm.t(ctx, b)
    print()
    x = qr_solve(ctx, A, b)
    x2 = lu_solve(ctx, A, b)
    print("x = lu_solve(ctx, A, b)")
    print(x)
    print()
    res = A @ x - b
    print("res = A @ x - b")
    print(res)
    print()
    assert x.shape == (n,3)
    print("Passed: assert x.shape == (n,)")
    assert np.allclose(to_fp(x), to_fp(x2))
    print("Passed: assert np.allclose(to_fp(x), to_fp(x2))")




def demo_eigh_real(ctx):
    n = 5
    A = np.random.rand(n, n)
    A = A + A.T
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    print("AA: ", AA)
    E, Q = eigh(ctx, AA)
    assert np.allclose(to_fp(Q.T @ Q), np.eye(n))
    assert E.shape == (n,)
    assert np.allclose(to_fp(Q @ np.diag(E) @ Q.T), A)
    # compute only eigenvalues
    E2 = eigh(ctx, AA, eigvals_only=True)
    assert np.all(E == E2)
    print("demo_eigh_real(): passed")



def demo_eigh_complex(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    A = A + A.T.conj()
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    print("AA: ", AA)
    E, Q = eigh(ctx, AA)
    assert np.allclose(to_cpx(Q.T.conj() @ Q), np.eye(n))
    assert E.shape == (n,)
    assert np.allclose(to_cpx(Q @ np.diag(E) @ Q.T.conj()), A)
    # compute only eigenvalues
    E2 = eigh(ctx, AA, eigvals_only=True)
    assert np.all(E == E2)
    print("demo_eigh_complex(): passed")



def demo_svd_real(ctx):
    n = 5
    A = np.random.rand(n, n)
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    U, S, V = svd(ctx, AA)
    assert np.allclose(to_fp(U.T @ U), np.eye(n))
    assert np.allclose(to_fp(V.T @ V), np.eye(n))
    assert S.shape == (n,)
    assert np.allclose(to_fp((U * S[None, :]) @ V), A)
    # compute only singular values
    S2 = svd(ctx, AA, compute_uv=False)
    assert np.all(S == S2)
    print("demo_svd_real(): passed")



def demo_svd_complex(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    U, S, V = svd(ctx, AA)
    assert np.allclose(to_cpx(U.T.conj() @ U), np.eye(n))
    assert np.allclose(to_cpx(V.T.conj() @ V), np.eye(n))
    assert S.shape == (n,)
    assert np.allclose(to_cpx((U * S[None, :]) @ V), A)
    # compute only singular values
    S2 = svd(ctx, AA, compute_uv=False)
    assert np.all(S == S2)
    print("demo_svd_complex(): passed")





def demo_balance_matrix(ctx):
    A = [[1, 100, 10000], [0.01, 1, 100], [0.0001, 0.01, 1]]
    print("A:", A)
    print()
    Aprime, D = balance_matrix(ctx, A)
    print("Aprime:", Aprime)
    print()
    print("D:", D)
    print()




def demo_eig_real(ctx):
    A = ctx.t(1) * np.arange(9).reshape((3, 3))
    E, UL, UR = eig(ctx, A, left=True, right=True)
    assert np.allclose(to_cpx(A @ UR), to_cpx(E[None, :] * UR))
    assert np.allclose(to_cpx(UL @ A), to_cpx(E[:, None] * UL))
    # compute only eigenvalues
    E2 = eig(ctx, A, left=False, right=False)
    assert np.all(E == E2)
    print("demo_eig_real(): passed")



def demo_eig_complex(ctx):
    A = (np.random.rand(5, 5) + 1j * np.random.rand(5, 5))
    A = npm.t(ctx, A)
    E, UL, UR = eig(ctx, A, left=True, right=True)
    assert np.allclose(to_cpx(A @ UR), to_cpx(E[None, :] * UR))
    assert np.allclose(to_cpx(UL @ A), to_cpx(E[:, None] * UL))
    # compute only eigenvalues
    E2 = eig(ctx, A, left=False, right=False)
    assert np.all(E == E2)
    print("demo_eig_complex(): passed")



def demo_hessenberg_real(ctx):
    n = 5
    A = np.random.rand(n, n)
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    Q, H = hessenberg(ctx, AA)
    assert Q.shape == (n, n) and H.shape == (n, n)
    assert np.allclose(to_fp(Q.T @ Q), np.eye(n))
    assert np.allclose(to_fp(Q @ H @ Q.T), A)
    assert np.all(np.tril(H, -2) == 0)
    print("demo_hessenberg_real(): passed")



def demo_hessenberg_complex(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    Q, H = hessenberg(ctx, AA)
    assert Q.shape == (n, n) and H.shape == (n, n)
    assert np.allclose(to_cpx(Q.T.conj() @ Q), np.eye(n))
    assert np.allclose(to_cpx(Q @ H @ Q.T.conj()), A)
    assert np.all(np.tril(H, -2) == 0)
    print("demo_hessenberg_complex(): passed")



def demo_schur(ctx):
    n = 5
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    Q, R = schur(ctx, AA)
    assert Q.shape == (n, n) and R.shape == (n, n)
    assert np.allclose(to_cpx(Q.T.conj() @ Q), np.eye(n))
    assert np.allclose(to_cpx(Q @ R @ Q.T.conj()), A)
    assert np.all(np.tril(R, -1) == 0)
    print("demo_schur(): passed")



def demo_hessenberg_qr(ctx):
    A = np.triu(np.ones((3, 3)), -1)
    #AA = ctx.t(1) * A
    AA = npm.t(ctx, A)
    Q = eye(ctx, 3)
    hessenberg_qr(ctx, AA, Q)
    assert np.allclose(to_fp(Q.T @ Q), np.eye(3))
    assert np.allclose(to_fp(Q @ AA @ Q.T), A)
    print("demo_hessenberg_qr(): passed")



def demo_eig_tr_r(ctx):
    R = np.triu(np.ones((3, 3)))
    R = npm.t(ctx, R)
    U = eig_tr_r(ctx, R)
    assert np.allclose(to_fp(U), [[1, -1, 1], [0, 0, 0], [0, 0, 0]])
    print("demo_eig_tr_r(): passed")





def demo_expm_mp():
    from xlcalcnet.mpmath import mp
    mp.prec = 80
    mp.pretty = True

    z = [[1,1,0],[1,0,1],[0,1,0]]
    print("z = [[1,1,0],[1,0,1],[0,1,0]]")
    res = mp.expm(z, method='pade')
    print("res = mp.expm(z)")
    print(res)
    print()



def demo_expm(ctx):

    z = [[1,1,0],[1,0,1],[0,1,0]]
    print("z = [[1,1,0],[1,0,1],[0,1,0]]")
    res = expm(ctx, z, method='pade') # casting issues with fpm
    #res = expm(ctx, z)
    print("res = expm(ctx, z)")
    print(res)
    print(type(res))



def demo_sqrtm_mp():
    from xlcalcnet.mpmath import mp
    mp.prec = 80
    mp.pretty = True
    z = [[2,0],[0,1]]
    print("z = [[2,0],[0,1]]")
    res = mp.sqrtm(z)
    print("res = mp.sqrtm(z)")
    print(res)
    print()

    z = [[1,1],[1,0]]
    print("z = [[1,1],[1,0]]")
    res = mp.sqrtm(z)
    print("res = mp.sqrtm(z)")
    print(res)
    print()



def demo_sqrtm(ctx):
    z = [2,0],[0,1]
    print("z = [2,0],[0,1]")
    res = sqrtm(ctx, z)
    print("res = sqrtm(ctx, z)")
    print(res)
    print(type(res))

    z = [[1,1],[1,0]]
    print("z = [[1,1],[1,0]]")
    res = sqrtm(ctx, z)
    print("res = sqrtm(ctx, z)")
    print(res)
    print(type(res))



def demo_logm_mp():
    from xlcalcnet.mpmath import mp
    mp.prec = 80
    mp.pretty = True
    z = mp.eye(3)
    print("z = mp.eye(3)")
    res = mp.logm(z)
    print("res = mp.logm(z)")
    print(res)
    print()

    res = mp.logm(2*z)
    print("res = mp.logm(2*z)")
    print(res)
    print()



def demo_logm(ctx):
    z = eye(ctx, 3)
    print("z = eye(ctx, 3)")
    res = logm(ctx, z)
    print("res = logm(ctx, z)")
    print(res)
    print(type(res))

    res = logm(ctx, 2*z)
    print("res = logm(ctx, 2*z)")
    print(res)
    print(type(res))



def demo_powm_mp():
    from xlcalcnet.mpmath import mp
    mp.prec = 80
    mp.pretty = True
    A = [[4,1,4],[7,8,9],[10,2,11]]
    print("A = [[4,1,4],[7,8,9],[10,2,11]]")
    res = mp.powm(A, 2)
    print("res = mp.powm(A, 2)")
    print(res)
    print()




def demo_powm(ctx):
    A = [[4,1,4],[7,8,9],[10,2,11]]
    print("A = [[4,1,4],[7,8,9],[10,2,11]]")
    res = powm(ctx, A, 2)
    print("res = powm(ctx, A, 2)")
    print(res)
    print(type(res))



def demo_cosm_mp():
    from xlcalcnet.mpmath import mp
    mp.prec = 80
    mp.pretty = True
    z = mp.eye(3)
    print("z = mp.eye(3)")
    res = mp.cosm(z)
    print("res = mp.cosm(z)")
    print(res)
    print()



def demo_cosm(ctx):
    z = eye(ctx, 3)
    print("z = eye(ctx, 3)")
    res = cosm(ctx, z)
    print("res = cosm(ctx, z)")
    print(res)
    print(type(res))



def demo_sinm_mp():
    from xlcalcnet.mpmath import mp
    mp.prec = 80
    mp.pretty = True
    z = mp.eye(3)
    print("z = mp.eye(3)")
    res = mp.sinm(z)
    print("res = mp.sinm(z)")
    print(res)
    print()



def demo_sinm(ctx):
    z = eye(ctx, 3)
    print("z = eye(ctx, 3)")
    res = sinm(ctx, z)
    print("res = sinm(ctx, z)")
    print(res)
    print(type(res))




## ******* Mathematical functions ******************



def demo_vectorize(ctx):
    a = np.array([[1,2,3], [4,5,6]])
    #b = np.array([[1,2,3], [4,5,6]])
    #b = np.array([2])
    b = 2
    #f = np.vectorize(ctx.exp, otypes=[object])
    #f = np.vectorize(lambda x: ctx.exp(x), otypes=[object])
    #f = np.vectorize(lambda x: ctx.pow(x, 2), otypes=[object])
    f = np.vectorize(ctx.pow, otypes=[object])
    #res = f(a)
    res = f(a, b)
    print(res)




## ******* Numerical calculus ******************



def f1(ctx, x):
    x = to_mp(ctx, x)
    n = len(x)
    return sum(100*(x[i+1]-x[i]**2)**2 + (x[i]-1)**2 for i in range(n-1))



def f2(ctx, params, x):
    A, m, s, offs = params[0:4]
    exp_ = np.vectorize(ctx.exp, otypes=[object])
    res1 = A * exp_(- (x-m)**2 / (2*s**2)) + offs
    return res1



def demo_gradient_c(ctx):
    x0 = [-1.5,2.5]
    res = gradient_c(ctx, f1, x0)
    print("res:", res)



# see also: https://en.wikipedia.org/wiki/Newton%27s_method#Systems_of_equations
def demo_jacobi_c(ctx):
    params = [1, 0.1, 1, 0.5]
    x = linspace(ctx, -3,3,11)
    res = jacobi_c(ctx, f2, params, x)
    print("res:", res)



def demo_levenberg_marquardt_c(ctx):
    params = np.array([1, 0.1, 1, 0.5])
    params = npm.t(ctx, params)
    x = linspace(ctx, -3,3,11)
    y = f2(ctx, params, x)
    startparams = [1*2, 0.5, 2, 0.5]
    startparams = npm.t(ctx, startparams)
    res = levenberg_marquardt_c(ctx, f2, startparams, x, y, verbose = True, tau = 1e-4)
    print("res:", res)




def demo_bfgs_c(ctx):
    x0 = [-1.5,2.5]
    res = gradient_c(ctx, f1, x0)
    print("res:", res)

    x_opt, xstore= bfgs_c(ctx, f1, x0, 100)
    print('optimal value, BFGS:  ', x_opt)



def demo_lbfgs_c(ctx):
    x0 = [-1.5,2.5]
    res = gradient_c(ctx, f1, x0)
    print("res:", res)

    x_opt, xstore= lbfgs_c(ctx, f1, x0, 100, 10)
    print('optimal value, BFGS:  ', x_opt)





def demo_gauss_quadrature_hermite_mp():
    from xlcalcnet.mpmath import mp
    def f(x):
        return x**8 + 2 * x**6 - 3 * x**4 + 5 * x**2 - 7
    X, W = mp.gauss_quadrature(5, "hermite")
    A = mp.fdot([(f(x), w) for x, w in zip(X, W)])
    B = mp.sqrt(mp.pi) * 57 / 16
    C = mp.quad(lambda x: mp.exp(- x * x) * f(x), [-mp.inf, +mp.inf])
    print("A:", A)
    print("B:", B)
    print("C:", C)
    print(mp.chop(A-B, tol = 1e-10), mp.chop(A-C, tol = 1e-10))



def demo_gauss_quadrature_hermite(ctx):
    def f(x):
        return x**8 + 2 * x**6 - 3 * x**4 + 5 * x**2 - 7
    X, W = gauss_quadrature(ctx, 5, "hermite")
    print("X:", X)
    print("W:", W)
    A = ctx.fdot([(f(x), w) for x, w in zip(X, W)])
    B = ctx.sqrt(ctx.pi) * 57 / 16
    C = ctx.quad(lambda x: ctx.exp(- x * x) * f(x), [-ctx.inf, +ctx.inf])
    print("A:", A)
    print("B:", B)
    print("C:", C)
    print(ctx.chop(A-B, tol = 1e-10), ctx.chop(A-C, tol = 1e-10))



def demo_gauss_hermite_coeff(ctx):
    X, W = gauss_quadrature(ctx, 30, "hermite")
    print("X:", X)
    print("W:", W)




def demo_gauss_quadrature_laguerre_mp():
    from xlcalcnet.mpmath import mp
    def f(x):
        return x**5 - 2 * x**4 + 3 * x**3 - 5 * x**2 + 7 * x - 11
    X, W = mp.gauss_quadrature(3, "laguerre")
    A = mp.fdot([(f(x), w) for x, w in zip(X, W)])
    B = 76
    C = mp.quad(lambda x: mp.exp(-x) * f(x), [0, +mp.inf])
    print("A:", A)
    print("B:", B)
    print("C:", C)
    print(mp.chop(A-B, tol = 1e-10), mp.chop(A-C, tol = 1e-10))



def demo_gauss_quadrature_laguerre(ctx):
    def f(x):
        return x**5 - 2 * x**4 + 3 * x**3 - 5 * x**2 + 7 * x - 11
    X, W = gauss_quadrature(ctx, 3, "laguerre")
    A = ctx.fdot([(f(x), w) for x, w in zip(X, W)])
    B = 76
    C = ctx.quad(lambda x: ctx.exp(-x) * f(x), [0, +ctx.inf])
    print("A:", A)
    print("B:", B)
    print("C:", C)
    print(ctx.chop(A-B, tol = 1e-10), ctx.chop(A-C, tol = 1e-10))




def test1():
    print("Hello test1!")
    z = dpm.t(1)
    print("z: ", z, "; repr(z): ", repr(z))
    z = dpm.t(1+2j)
    print("z: ", z, "; repr(z): ", repr(z))
    z = dpm.t(1,2)
    print("z: ", z, "; repr(z): ", repr(z))



def demo_lu_decomp_complex(ctx):
    n = 2
    A = np.random.rand(n, n) + 1j * np.random.rand(n, n)
    A = npm.t(ctx, A)
    print("A:", A)
    print()
    LU, p = LU_decomp(ctx, A)
    print("LU", LU)
    print()
    print("p: ", p)
    print()
    print("A:", A)


def demo_all():

    #ctxm = fpm
    ctxm = mpm
    #ctxm = ipm
    #ctxm = dpm
    #ctxm = gpm
    #ctxm = apm

    #ctxm = qpm

    ctxm.prec = 80
    #ctxm.prec = 150

    ##test1()



 #******* Basic calculations without sqrt ******************

##
##
##    demo_read_from_cvs(ctxm)
##
##    demo_read_stats_cvs(ctxm)
##    demo_read_hald_cvs(ctxm)
##    demo_read_from_xlsm(ctxm)
##
##    demo_to_mp(ctxm)
##    demo_linspace(ctxm)
##
##    demo_operators_real(ctxm)
##
##    demo_basics(ctxm)
##    demo_sort(ctxm)
##
##
## #******* Descriptive statistic without sqrt ******************
##
##    demo_statistic(ctxm)
##
##    #TODO: centered matrix
##    #TODO: covariance matrix
##
##
## #******* Linalg without sqrt, real ******************
##
##
##
##    demo_lu_solve_real(ctxm)
##    demo_lu_solve_real_block(ctxm)
##    demo_lu_real(ctxm)
##    demo_inverse_real(ctxm)
##    demo_det(ctxm)
##
##    demo_ldl_golub_and_van_loan(ctxm)
##
##
##
## #******* Linalg without sqrt, complex ******************
##
##
##    if ((ctxm is not qpm)):
##        demo_lu_solve_complex(ctxm)
##        demo_lu_complex(ctxm)
##        demo_inverse_complex(ctxm)
##        demo_lu_decomp_complex(ctxm)
##
##
##
##
##
##
## #******* Descriptive statistic with sqrt ******************
##
##
##    #TODO: standardized matrix
##    #TODO: correlation matrix
##
##
##    if (ctxm is not qpm):
##        demo_operators_complex(ctxm) # complex not implemented for qpm
##        demo_matrix_power(ctxm) # complex not implemented for qpm
##        demo_vectorize(ctxm)
##
##
##
##
## #******* Linalg with sqrt ******************
##
##
##        demo_norm(ctxm)
##        demo_mnorm(ctxm)
##
##
##        demo_cholesky_solve_real(ctxm)
##        demo_cholesky_solve_real_block(ctxm)
##
##        if (ctxm is not fpm):
##            demo_cholesky_solve_cplx(ctxm)   # not working for fpm
##            demo_cholesky_solve_cplx_block(ctxm)   # not working for fpm
##
##        demo_qr_real(ctxm)
##        demo_qr_complex(ctxm)
##        demo_qr_solve_real(ctxm)
##        demo_qr_solve_real_overdet(ctxm)
##
##
##
##    if ((ctxm is not ipm) and (ctxm is not qpm) and (ctxm is not apm)):
## #******* SVD and Eigensystems ******************
##
##        demo_eigh_real(ctxm)
##        if ctxm is not fpm:
##            demo_eigh_complex(ctxm)   # not working for fpm
##        demo_svd_real(ctxm)
##        if ctxm is not fpm:
##            demo_svd_complex(ctxm)   # not working for fpm
##
##
##        demo_balance_matrix(ctxm)
##        demo_eig_real(ctxm)
##
##        if ctxm is not fpm:
##            demo_eig_complex(ctxm)   # not working for fpm
##        demo_hessenberg_real(ctxm)
##        demo_hessenberg_complex(ctxm)
##        demo_schur(ctxm)
##        demo_hessenberg_qr(ctxm)
##        demo_eig_tr_r(ctxm)
##
##
##        demo_expm_mp()
##        if ctxm is not fpm:
##            demo_expm(ctxm)   # not working for fpm
##
##        demo_sqrtm_mp()
##        demo_sqrtm(ctxm)
##
##        demo_logm_mp()
##        demo_logm(ctxm)
##
##        demo_powm_mp()
##        demo_powm(ctxm)
##
##        demo_cosm_mp()
##        demo_cosm(ctxm)
##
##        demo_sinm_mp()
##        demo_sinm(ctxm)
##
##        #TODO: general formula via eigen decomposition
##
##
##
##
##     #******* Numerical calculus ******************
##
##        demo_gradient_c(ctxm)
##        demo_jacobi_c(ctxm)
##
##        demo_levenberg_marquardt_c(ctxm)
##
##        demo_bfgs_c(ctxm)
##        demo_lbfgs_c(ctxm)
##

    demo_gauss_hermite_coeff(ctxm)

##    demo_gauss_quadrature_hermite_mp()
##    demo_gauss_quadrature_hermite(ctxm)

##    demo_gauss_quadrature_laguerre_mp()
##    demo_gauss_quadrature_laguerre(ctxm)



demo_all()

