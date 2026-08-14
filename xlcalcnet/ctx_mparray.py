# TODO:
# Balancing for eigenvalues
# Levenberg-Marquardt
# Lbfgs
# covariance and correlation
# update norms with svd (matrix norm)
# pseudoinverse via svd
# vectorize scalar functions
# Lai & Crassidis 2007: Jacobi and Hessian matrix



import numpy as np
from xlcalcnet import npm


def zeros(ctx, shape):
    """Create array of zeros of the given shape with MP floating point
    numbers."""
    zero = ctx.t(0)
    return np.full(shape, zero)

def ones(ctx, shape):
    """Create array of ones of the given shape with MP floating point
    numbers."""
    one = ctx.t(1)
    return np.full(shape, one)


def hilbert(ctx, shape):
    """
    Create (pseudo) hilbert matrix m x n.
    The matrix is very ill-conditioned and symmetric, positive definite if
    square.
    """
    zero = ctx.t(0)
    A = np.full(shape, zero)
    for i in range(m):
        for j in range(n):
            A[i,j] = ctx.one / (i + j + 1)
    return A


def empty(ctx, shape):
    """Create array off the given shape suitable for holding MP floating
    point numbers."""
    return np.empty(shape, dtype=object)

def eye(ctx, n):
    """Create identity matrix of size `n` with MP floating point numbers."""
    I = zeros(ctx, (n, n))
    one =  ctx.t(1)
    np.fill_diagonal(I, one)
    return I


def rows(ctx, A):
        return np.shape(A)[0]


def cols(ctx, A):
        return np.shape(A)[1]



def matrix_power(ctx, A, n):
    from numpy.linalg import matrix_power as matpow
    res = None
    if (n==0):
        res = eye(ctx, rows(ctx, A))
    else:
        res = matpow(A, abs(n))
        if (n<0): res = inverse(ctx, res)
    return res




def arange(ctx, *args):
    if not len(args) <= 3:
        raise TypeError('arange expected at most 3 arguments, got %i' % len(args))
    if not len(args) >= 1:
        raise TypeError('arange expected at least 1 argument, got %i' % len(args))
    # set default
    a = 0
    dt = 1
    # interpret arguments
    if len(args) == 1:
        b = args[0]
    elif len(args) >= 2:
        a = args[0]
        b = args[1]
    if len(args) == 3:
        dt = args[2]
    a, b, dt = ctx.t(a), ctx.t(b), ctx.t(dt)
    x = np.arange(a, b, dt)



def linspace(ctx, start, stop, num, endpoint=True):
    """Return an array of evenly spaced multiprecision numbers over a
    specified interval.

    This behaves like the numpy version.
    """
    if endpoint:
        if num == 1:
            x = zeros(ctx, 1)
        x = np.arange(num) / ctx.t(num - 1)
    else:
        x = np.arange(num) / ctx.t(num)
    start, stop = ctx.t(start), ctx.t(stop)
    return (stop - start) * x + start





def norm(ctx, x, p=2):
    r"""
    Gives the entrywise `p`-norm of an iterable *x*, i.e. the vector norm
    `\left(\sum_k |x_k|^p\right)^{1/p}`, for any given `1 \le p \le \infty`.
    """
    x = to_mp(ctx, x)
    try:
        iter(x)
    except TypeError:
        return ctx.absmax(x)
    if type(p) is not int:
        p = ctx.convert(p)
    if p == ctx.inf:
        return max(ctx.absmax(i) for i in x)
    elif p == 1:
        return ctx.fsum(x, absolute=1)
    elif p == 2:
        return ctx.sqrt(ctx.fsum(x, absolute=1, squared=1))
    elif p > 1:
        return ctx.nthroot(ctx.fsum(abs(i)**p for i in x), p)
    else:
        raise ValueError('p has to be >= 1')

def mnorm(ctx, A, p=1):
    r"""
    Gives the matrix (operator) `p`-norm of A. Currently ``p=1`` and ``p=inf``
    are supported:
    """
    A = to_mp(ctx, A)
    if type(p) is not int:
        if type(p) is str and 'frobenius'.startswith(p.lower()):
            return norm(ctx, A.flatten(), 2)
        p = ctx.convert(p)
    m, n = rows(ctx, A), cols(ctx, A)
    if p == 1:
        return max(ctx.fsum((A[i,j] for i in range(m)), absolute=1) for j in range(n))
    elif p == ctx.inf:
        return max(ctx.fsum((A[i,j] for j in range(n)), absolute=1) for i in range(m))
    else:
        raise NotImplementedError("matrix p-norm for arbitrary p")





def swap_rows(A, i, j):
    """Swap rows i and j of 2D numpy array."""
    A[[i, j]] = A[[j, i]]




def vector_norm(ctx, x):
    """Compute Euclidean norm of vector `x`."""
    return ctx.sqrt(ctx.fsum((abs(x)**2).flat))

def _ctx_vectorize(func):
    # avoid having to call the function first to determine the dtype
    return np.vectorize(func, otypes=[object])


def contains_complex(ctx, A):
    """Return True if the array contains any (non-real) complex numbers."""
    return any(isinstance(x, ctx.complextype) and not isinstance(x, ctx.realtype)
            for x in A.flat)

def to_mp(ctx, A):
    """Ensures an array contains mpf or mpc numbers. Always copies the
    input."""
    _vectorized_real = _ctx_vectorize(ctx.realtype)
    _vectorized_complex = _ctx_vectorize(ctx.complextype)
    _vectorized_int_to_real = _ctx_vectorize(lambda x: ctx.t(int(x)))

    import numbers
    A = np.asanyarray(A)
    if issubclass(A.dtype.type, numbers.Integral):
        return _vectorized_int_to_real(A)
    if contains_complex(ctx, A):
        return _vectorized_complex(A)
    else:
        return _vectorized_real(A)




def to_mp_real(ctx, A):
    real_ = np.vectorize(ctx.re, otypes=[object])
    return real_(A)


def to_mp_imag(ctx, A):
    imag_ = np.vectorize(ctx.im, otypes=[object])
    return imag_(A)




def to_fp(A):
    return np.array(A, float)


def to_cpx(A):
    def conv2cpl_(z): return complex(z.real, z.imag)
    cplx_ = np.vectorize(conv2cpl_, otypes=[object])
    tempA = cplx_(A)
    return np.array(tempA, complex)
    #return cplx_(A)
    #return np.array(A, complex)



def LU_decomp(ctx, A, overwrite=False):
    """
    LU-factorization of a n*n matrix using the Gauss algorithm.
    Returns L and U in one matrix and the pivot indices.

    Use overwrite to specify whether A will be overwritten with L and U.
    """
    if not A.shape[0] == A.shape[1]:
        raise ValueError('need n*n matrix')

##    if not overwrite:
##        A = to_mp(ctx, A)

    if not overwrite:
        A = A.copy()


    # each pivot element has to be bigger
    tol = abs(np.linalg.norm(A, ord=1) * ctx.eps)
    n = A.shape[0]
    p = [None]*(n - 1)
    for j in range(n - 1):
        # pivoting, choose max(abs(reciprocal row sum)*abs(pivot element))
        biggest = ctx.t(0)
        for k in range(j, n):
            s = ctx.fsum([abs(A[k,l]) for l in range(j, n)])
            if abs(s) <= tol:
                raise ZeroDivisionError('matrix is numerically singular')
            elif ctx.isnan(s):
                raise ValueError('matrix contains nans')
            current = 1/s * abs(A[k,j])
            if ctx.mid(current) > ctx.mid(biggest):
                biggest = current
                p[j] = k
        # swap rows according to p
        swap_rows(A, j, p[j])
        if abs(A[j,j]) <= tol:
            raise ZeroDivisionError('matrix is numerically singular')
        # calculate elimination factors and add rows
        for i in range(j + 1, n):
            A[i,j] = A[i,j] / A[j,j]
            for k in range(j + 1, n):
                A[i,k] = A[i,k] - A[i,j]*A[j,k]

    if abs(A[n - 1, n - 1]) <= tol:
        raise ZeroDivisionError('matrix is numerically singular')
    return A, p

def L_solve(ctx, L, b, p=None, unit_diag=False):
    """
    Solve the lower part of a LU factorized matrix for y.
    If `unit_diag` is True, the diagonal of L is assumed to be 1.

    b may be a vector or matrix.
    """
    if L.shape[0] != L.shape[1]:
        raise RuntimeError("need n*n matrix")
    n = L.shape[0]
    if b.shape[0] != n:
        raise ValueError("vector b has incorrect shape")

    # Test for mpi
    #b = to_mp(ctx, b)
    b = b.copy()


    if p: # swap b according to p
        for k in range(len(p)):
            swap_rows(b, k, p[k])
    # solve
    for i in range(n):
        for j in range(i):
            b[i] -= L[i,j] * b[j]
        if not unit_diag:
            b[i] /= L[i,i]
    return b

def U_solve(ctx, U, y):
    """
    Solve the upper part of a LU factorized matrix for x.

    y may be a vector or matrix.
    """
    if U.shape[0] != U.shape[1]:
        raise RuntimeError("need n*n matrix")
    n = U.shape[0]
    if y.shape[0] != n:
        raise ValueError("vector y has incorrect shape")

    # Test for mpi
    #x = to_mp(ctx, y)
    #x = y * 1
    x = y.copy()

##    print("x: ", x)
    for i in range(n - 1, -1, -1):
        for j in range(i + 1, n):
            x[i] -= U[i,j] * x[j]
##            print("x[i], x[i] -= U[i,j] * x[j]: ", x[i])
        #x[i] /= U[i,i]
        x[i] = x[i] / U[i,i]


##        print("x[i], x[i] /= U[i,i]: ", x[i])
    return x

def lu_solve(ctx, A, b, real=False):
    """
    Ax = b => x

    b may be a vector or matrix.

    Solve a determined or overdetermined linear equations system.
    Fast LU decomposition is used, which is less accurate than QR decomposition
    (especially for overdetermined systems), but it's twice as efficient.
    Use qr_solve if you want more precision or have to solve a very ill-
    conditioned system.

    If you specify real=True, it does not check for overdetermined complex
    systems.
    """

    # Test for mpi
    # do not overwrite A nor b
    #A, b = to_mp(ctx, A), to_mp(ctx, b)
    A = A.copy()
    b = b.copy()


    if A.shape[0] != b.shape[0]:
        raise ValueError('right-hand side has incorrect size')
    if A.shape[0] < A.shape[1]:
        raise ValueError('cannot solve underdetermined system')
    if A.shape[0] > A.shape[1]:
        # use least-squares method if overdetermined
        # (this increases errors)
        #AH = A.T.conj()
        AH = npm.conj(ctx, A).T
        A = AH @ A
        b = AH @ b
##        if real or not contains_complex(ctx, A):
##            x = cholesky_solve(ctx, A, b)
##        else:
        x = lu_solve(ctx, A, b)
    else:
        # LU factorization
        A, p = LU_decomp(ctx, A)
        b = L_solve(ctx, A, b, p, unit_diag=True)
        x = U_solve(ctx, A, b)
    return x



##def lu_solve_mat(ctx, a, b):
##    """Solve a * x = b  where a and b are matrices."""
##    r = ctx.matrix(a.rows, b.cols)
##    for i in range(b.cols):
##        c = ctx.lu_solve(a, b.column(i))
##        for j in range(len(c)):
##            r[j, i] = c[j]
##    return r



def lu(ctx, A):
    """
    A -> P, L, U

    LU factorisation of a square matrix A. L is the lower, U the upper part.
    P is the permutation matrix indicating the row swaps.

    P*A = L*U

    If you need efficiency, use the low-level method LU_decomp instead, it's
    much more memory efficient.
    """
    # get factorization
    A, p = LU_decomp(ctx, A)
    #L = np.tril(A, -1)
    L = ctx.t(1) * np.tril(A, -1)
    np.fill_diagonal(L, ctx.mpf(1))
    #U = np.triu(A)
    U = ctx.t(1) * np.triu(A)
    # calculate permutation matrix
    P = eye(ctx, A.shape[0])
    for k in range(len(p)):
        swap_rows(P, k, p[k])
    return P, L, U

def unitvector(ctx, n, i):
    """
    Return the i-th n-dimensional unit vector.
    """
    assert 0 <= i < n, 'this unit vector does not exist'
    e = zeros(ctx, n)
    e[i] = ctx.mpf(1)
    return e

def inverse(ctx, A):
    """
    Calculate the inverse of a matrix.

    If you want to solve an equation system Ax = b, it's recommended to use
    solve(A, b) instead, it's about 3 times more efficient.
    """
    if A.shape[0] != A.shape[1]:
        raise ValueError('can only compute inverse of square matrix')
    # do not overwrite A

    # Test for mpi
    #A = to_mp(ctx, A)

    A = A.copy()


    # get LU factorisation
    A, p = LU_decomp(ctx, A)
##    print("A, p: ", A, p)
    B = empty(ctx, A.shape)
    # calculate unit vectors and solve corresponding system to get columns
    n = A.shape[0]
    for i in range(n):
        e = unitvector(ctx, n, i)
##        print("e: ", e)
        y = L_solve(ctx, A, e, p, unit_diag=True)
##        print("y: ", y)
        B[:, i] = U_solve(ctx, A, y)
##        print("B: ", B)
    return B

def householder(ctx, A, num_dofs):
    """
    (A|b) -> H, p, x, res

    (A|b) is the coefficient matrix with left hand side of an optionally
    overdetermined linear equation system.
    H and p contain all information about the transformation matrices.
    x is the solution, res the residual.
    """
    m, n = A.shape
    if m < num_dofs:
        raise RuntimeError("system is underdetermined")
    # calculate Householder matrix
    p = empty(ctx, num_dofs)
    eps = ctx.eps
    for j in range(num_dofs):
        #s = ctx.fsum(abs(A[i,j])**2 for i in range(j, m))
        s = ctx.fsum(abs(A[j:m,j])**2)
        if not abs(s) > eps:
            raise ValueError('matrix is numerically singular')
        p[j] = -ctx.sign(A[j,j].real) * ctx.sqrt(s)
        kappa = ctx.mpf(1) / (s - p[j] * A[j,j])
        A[j,j] -= p[j]
        for k in range(j+1, n):
            #y = ctx.fsum(A[i,j].conjugate() * A[i,k] for i in range(j, m)) * kappa
            y = ctx.fsum(ctx.conj(A[i,j]) * A[i,k] for i in range(j, m)) * kappa
            for i in range(j, m):
                A[i,k] -= A[i,j] * y
    # solve Rx = c1
    x = A[:num_dofs, num_dofs:].copy()      # collect all right-hand sides
    for k in range(A.shape[1] - num_dofs):
        for i in range(num_dofs - 1, -1, -1):
            x[i, k] -= ctx.fsum(A[i,j] * x[j, k] for j in range(i + 1, num_dofs))
            x[i, k] /= p[i]
    # calculate residual
    if m > num_dofs:        # overdetermined system
        r = np.array([A[m-1-i, num_dofs:] for i in range(m - num_dofs)])
    else:
        # determined system, residual should be 0
        r = zeros(ctx, m)
    return A, p, x, r

def qr_solve(ctx, A, b, norm=None, res=False):
    """
    Ax = b => x, ||Ax - b||

    Solve a determined or overdetermined linear equations system and
    calculate the norm of the residual (error).
    QR decomposition using Householder factorization is applied, which gives
    accurate results even for ill-conditioned matrices.
    """
    # NB: unclear what `res` does for overdetermined systems!
    if norm is None:
        norm = vector_norm
    # do not overwrite A nor b
    A, b = to_mp(ctx, A), to_mp(ctx, b)
    if A.shape[0] < A.shape[1]:
        raise ValueError('cannot solve underdetermined system')
    H, p, x, r = householder(ctx, np.column_stack((A, b)), A.shape[1])
    if b.ndim == 1:
        x = x.ravel()       # only one solution vector; x has shape (n,1)
    return (x, r) if res else x

def cholesky(ctx, A, tol=None):
    r"""
    Cholesky decomposition of a symmetric positive-definite matrix `A`.
    Returns a lower triangular matrix `L` such that `A = L \times L^T`.
    More generally, for a complex Hermitian positive-definite matrix,
    a Cholesky decomposition satisfying `A = L \times L^H` is returned.

    The Cholesky decomposition can be used to solve linear equation
    systems twice as efficiently as LU decomposition, or to
    test whether `A` is positive-definite.

    The optional parameter ``tol`` determines the tolerance for
    verifying positive-definiteness.

    **Examples**

    Cholesky decomposition of a positive-definite symmetric matrix::

        >>> from mpmath import *
        >>> mp.dps = 25; mp.pretty = True
        >>> A = eye(3) + hilbert(3)
        >>> nprint(A)
        [     2.0      0.5  0.333333]
        [     0.5  1.33333      0.25]
        [0.333333     0.25       1.2]
        >>> L = cholesky(A)
        >>> nprint(L)
        [ 1.41421      0.0      0.0]
        [0.353553  1.09924      0.0]
        [0.235702  0.15162  1.05899]
        >>> chop(A - L*L.T)
        [0.0  0.0  0.0]
        [0.0  0.0  0.0]
        [0.0  0.0  0.0]

    Cholesky decomposition of a Hermitian matrix::

        >>> A = eye(3) + matrix([[0,0.25j,-0.5j],[-0.25j,0,0],[0.5j,0,0]])
        >>> L = cholesky(A)
        >>> nprint(L)
        [          1.0                0.0                0.0]
        [(0.0 - 0.25j)  (0.968246 + 0.0j)                0.0]
        [ (0.0 + 0.5j)  (0.129099 + 0.0j)  (0.856349 + 0.0j)]
        >>> chop(A - L*L.H)
        [0.0  0.0  0.0]
        [0.0  0.0  0.0]
        [0.0  0.0  0.0]

    Attempted Cholesky decomposition of a matrix that is not positive
    definite::

        >>> A = -eye(3) + hilbert(3)
        >>> L = cholesky(A)
        Traceback (most recent call last):
          ...
        ValueError: matrix is not positive-definite

    **References**

    1. [Wikipedia]_ http://en.wikipedia.org/wiki/Cholesky_decomposition

    """
    IsArb = False
    scalar = A.item(0)
    print("scalar: ", scalar, type(scalar))
    if str(type(scalar)) == "<class 'flint.types.arb.arb'>": IsArb = True

    if not A.shape[0] == A.shape[1]:
        raise ValueError('need n*n matrix')
    if tol is None:
        tol = ctx.eps
    n = A.shape[0]

    L = zeros(ctx, (n, n))
    if str(type(scalar)) == "<class 'flint.types.acb.acb'>": L = L * ctx.j

    for j in range(n):
        c = A[j,j].real
##        if abs(c-A[j,j]) > tol:
        if ctx.mid(abs(c-A[j,j])) > tol:
            raise ValueError('matrix is not Hermitian')
        s = c - ctx.fsum((abs(L[j,k])**2 for k in range(j)))
        if s < tol:
            raise ValueError('matrix is not positive-definite')
        L[j,j] = ctx.sqrt(s)
        for i in range(j, n):
            #it1 = (L[i,k] for k in range(j))
            #it2 = (L[j,k] for k in range(j))
            #t = ctx.fdot(it1, it2, conjugate=True)
            if IsArb:
                t = np.sum(L[i,:j] * L[j,:j])
            else:
                t = np.sum(L[i,:j] * L[j,:j].conj())
            L[i,j] = (A[i,j] - t) / L[j,j]
    return L

def cholesky_solve(ctx, A, b):
    """
    Ax = b => x
    Solve a symmetric positive-definite linear equation system.
    """
    IsArb = False
    scalar = A.item(0)
    if str(type(scalar)) == "<class 'flint.types.arb.arb'>": IsArb = True


    # do not overwrite A nor b
    #A, b = to_mp(ctx, A), to_mp(ctx, b)
    A = A.copy()
    b = b.copy()

    if A.shape[0] != A.shape[1]:
        raise ValueError('can only solve determined system')
    # Cholesky factorization
    L = cholesky(ctx, A)
    # solve
    b = L_solve(ctx, L, b, unit_diag=False)
    if IsArb: return U_solve(ctx, L.T, b)
    else: return U_solve(ctx, L.conj().T, b)



def det(ctx, A):
    """
    Calculate the determinant of a matrix.
    """

    # do not overwrite A
    #A = to_mp(ctx, A)
    A = A.copy()

    # use LU factorization to calculate determinant
    try:
        R, p = LU_decomp(ctx, A)
    except ZeroDivisionError:
        return 0
    z = np.prod(np.diag(R))
    for i, e in enumerate(p):
        if i != e:
            z *= -1
    return z

def cond(ctx, A, norm=None):
    """
    Calculate the spectral condition number of a matrix using a specified matrix norm.

    The condition number estimates the sensitivity of a matrix to errors.
    Example: small input errors for ill-conditioned coefficient matrices
    alter the solution of the system dramatically.

    For ill-conditioned matrices it's recommended to use qr_solve() instead
    of lu_solve(). This does not help with input errors however, it just avoids
    to add additional errors.

    Definition:    cond(A) = ||A|| * ||A**-1||
    """
    if norm is None:
        norm = lambda x: np.linalg.norm(x, ord=1)
    return norm(A) * norm(inverse(ctx, A))


def qr(ctx, A, mode='full'):
    """
    Compute a QR factorization $A = QR$ where
    A is an m x n matrix of real or complex numbers where m >= n

    mode has following meanings:
    (1) mode = 'raw' returns two matrixes (A, tau) in the
        internal format used by LAPACK
    (2) mode = 'reduced' returns the leading n columns of Q
        and n rows of R
    (3) Any other value returns the leading m columns of Q
        and m rows of R
    """
    m, n = A.shape
    assert n >= 0
    assert m >= n

    # check for complex data type
    cmplx = contains_complex(ctx, A)

    tau = empty(ctx, n)
    A = A.copy()
    #A = to_mp(ctx, A)

    # ---------------
    # FACTOR MATRIX A
    # ---------------
    if cmplx:
        one = ctx.mpc(1)
        zero = ctx.mpc(0)
        rzero = ctx.mpf(0)

        # main loop to factor A (complex)
        for j in range(n):
            alpha = A[j,j]
            alphr, alphi = alpha.real, alpha.imag

            if (m-j) >= 2:
                #xnorm = ctx.fsum(A[i,j] * A[i,j].conjugate() for i in range(j+1, m))
                xnorm = sum(A[i,j] * A[i,j].conjugate() for i in range(j+1, m))
                xnorm = ctx.sqrt(xnorm).real
            else:
                xnorm = rzero

            if (xnorm == rzero) and (alphi == rzero):
                tau[j] = zero
                continue

            if alphr < rzero:
                beta = ctx.sqrt(alphr**2 + alphi**2 + xnorm**2)
            else:
                beta = -ctx.sqrt(alphr**2 + alphi**2 + xnorm**2)

            tau[j] = ctx.mpc((beta - alphr) / beta, -alphi / beta)
            t = -tau[j].conjugate()
            za = one / (alpha - beta)

            for i in range(j+1, m):
                A[i,j] *= za

            A[j,j] = one
            for k in range(j+1, n):
                #y = ctx.fsum(A[i,j] * A[i,k].conjugate() for i in range(j, m))
                y = sum(A[i,j] * A[i,k].conjugate() for i in range(j, m))
                temp = t * y.conjugate()
                for i in range(j, m):
                    A[i,k] += A[i,j] * temp

            A[j,j] = ctx.mpc(beta, 0)
    else:
        one = ctx.mpf(1)
        zero = ctx.mpf(0)

        # main loop to factor A (real)
        for j in range(n):
            alpha = A[j,j]

            if m - j > 2:
                xnorm = ctx.fsum(A[i,j]**2 for i in range(j+1, m))
                xnorm = ctx.sqrt(xnorm)
            elif m - j == 2:
                xnorm = abs(A[m-1,j])
            else:
                xnorm = zero

            if xnorm == zero:
                tau[j] = zero
                continue

            if alpha < zero:
                beta = ctx.hypot(alpha, xnorm)
            else:
                beta = -ctx.hypot(alpha, xnorm)

            tau[j] = (beta - alpha) / beta
            t = -tau[j]
            da = one / (alpha - beta)

            for i in range(j+1, m):
                A[i,j] *= da

            A[j,j] = one
            for k in range(j+1, n):
                y = ctx.fsum(A[i,j] * A[i,k] for i in range(j, m))
                temp = t * y
                for i in range(j,m):
                    A[i,k] += A[i,j] * temp

            A[j,j] = beta

    # return factorization in same internal format as LAPACK
    if mode == 'raw':
        return A, tau

    # ----------------------------------
    # FORM Q USING BACKWARD ACCUMULATION
    # ----------------------------------

    # form R before the values are overwritten
    R = A.copy()
    for j in range(n):
        for i in range(j+1, m):
            R[i,j] = zero

    # set the value of p (number of columns of Q to return)
    p = m
    if mode == 'reduced' or mode == 'r':
        p = n

    # add columns to A if needed and initialize
    A = np.hstack((A, zeros(ctx, (m, p - n))))
    for j in range(p):
        A[j,j] = one
        for i in range(j):
            A[i,j] = zero

    # main loop to form Q
    for j in range(n-1, -1, -1):
        t = -tau[j]
        A[j,j] += t

        for k in range(j+1, p):
            if cmplx:
                #y = ctx.fsum(A[i,j] * A[i,k].conjugate() for i in range(j+1, m))
                y = sum(A[i,j] * A[i,k].conjugate() for i in range(j+1, m))
                temp = t * y.conjugate()
            else:
                y = ctx.fsum(A[i,j] * A[i,k] for i in range(j+1, m))
                temp = t * y
            A[j,k] = temp
            for i in range(j+1, m):
                A[i,k] += A[i,j] * temp

        for i in range(j+1, m):
            A[i, j] *= t

    return A, R[0:p, 0:n]



##################################################################################################
#     module for the symmetric eigenvalue problem
#       Copyright 2013 Timo Hartmann (thartmann15 at gmail.com)
#
# todo:
#  - implement balancing
#
##################################################################################################
"""
The symmetric eigenvalue problem.
---------------------------------

This file contains routines for the symmetric eigenvalue problem.

high level routines:

  eigsy : real symmetric (ordinary) eigenvalue problem
  eighe : complex hermitian (ordinary) eigenvalue problem
  eigh  : unified interface for eigsy and eighe
  svd_r : singular value decomposition for real matrices
  svd_c : singular value decomposition for complex matrices
  svd   : unified interface for svd_r and svd_c


low level routines:

  r_sy_tridiag : reduction of real symmetric matrix to real symmetric tridiagonal matrix
  c_he_tridiag_0 : reduction of complex hermitian matrix to real symmetric tridiagonal matrix
  c_he_tridiag_1 : auxiliary routine to c_he_tridiag_0
  c_he_tridiag_2 : auxiliary routine to c_he_tridiag_0
  tridiag_eigen : solves the real symmetric tridiagonal matrix eigenvalue problem
  svd_r_raw : raw singular value decomposition for real matrices
  svd_c_raw : raw singular value decomposition for complex matrices
"""

#import numbers

def r_sy_tridiag(ctx, A, D, E, calc_ev=True):
    """
    This routine transforms a real symmetric matrix A to a real symmetric
    tridiagonal matrix T using an orthogonal similarity transformation:
          Q' * A * Q = T     (here ' denotes the matrix transpose).
    The orthogonal matrix Q is build up from Householder reflectors.

    parameters:
      A         (input/output) On input, A contains the real symmetric matrix of
                dimension (n,n). On output, if calc_ev is true, A contains the
                orthogonal matrix Q, otherwise A is destroyed.

      D         (output) real array of length n, contains the diagonal elements
                of the tridiagonal matrix

      E         (output) real array of length n, contains the offdiagonal elements
                of the tridiagonal matrix in E[0:(n-1)] where is the dimension of
                the matrix A. E[n-1] is undefined.

      calc_ev   (input) If calc_ev is true, this routine explicitly calculates the
                orthogonal matrix Q which is then returned in A. If calc_ev is
                false, Q is not explicitly calculated resulting in a shorter run time.

    This routine is a python translation of the fortran routine tred2.f in the
    software library EISPACK (see netlib.org) which itself is based on the algol
    procedure tred2 described in:
      - Num. Math. 11, p.181-195 (1968) by Martin, Reinsch and Wilkonson
      - Handbook for auto. comp., Vol II, Linear Algebra, p.212-226 (1971)

    For a good introduction to Householder reflections, see also
      Stoer, Bulirsch - Introduction to Numerical Analysis.
    """

    # note : the vector v of the i-th houshoulder reflector is stored in a[(i+1):,i]
    #        whereas v/<v,v> is stored in a[i,(i+1):]

    n = A.shape[0]
    for i in range(n - 1, 0, -1):
        # scale the vector

        scale = 0
        for k in range(i):
            scale += abs(A[k,i])

        scale_inv = 0
        if scale != 0:
            scale_inv = 1/scale

        # sadly there are floating point numbers not equal to zero whose reciprocal is infinity

        if i == 1 or scale == 0 or ctx.isinf(scale_inv):
            E[i] = A[i-1,i]        # nothing to do
            D[i] = 0
            continue

        # calculate parameters for housholder transformation

        H = 0
        for k in range(i):
            A[k,i] *= scale_inv
            H += A[k,i] * A[k,i]

        F = A[i-1,i]
        G = ctx.sqrt(H)
        if F > 0:
            G = -G
        E[i] = scale * G
        H -= F * G
        A[i-1,i] = F - G
        F = 0

        # apply housholder transformation

        for j in range(i):
            if calc_ev:
                A[i,j] = A[j,i] / H

            G = 0                  # calculate A*U
            for k in range(j + 1):
                G += A[k,j] * A[k,i]
            for k in range(j + 1, i):
                G += A[j,k] * A[k,i]

            E[j] = G / H           # calculate P
            F += E[j] * A[j,i]

        HH = F / (2 * H)

        for j in range(i):     # calculate reduced A
            F = A[j,i]
            G = E[j] - HH * F      # calculate Q
            E[j] = G

            for k in range(j + 1):
                A[k,j] -= F * E[k] + G * A[k,i]

        D[i] = H

    for i in range(1, n):         # better for compatibility
        E[i-1] = E[i]
    E[n-1] = 0

    if calc_ev:
        D[0] = 0
        for i in range(n):
            if D[i] != 0:
                for j in range(i):     # accumulate transformation matrices
                    G = 0
                    for k in range(i):
                        G += A[i,k] * A[k,j]
                    for k in range(i):
                        A[k,j] -= G * A[k,i]

            D[i] = A[i,i]
            A[i,i] = 1

            for j in range(i):
                A[j,i] = A[i,j] = 0
    else:
        for i in range(n):
            D[i] = A[i,i]





def c_he_tridiag_0(ctx, A, D, E, T):
    """
    This routine transforms a complex hermitian matrix A to a real symmetric
    tridiagonal matrix T using an unitary similarity transformation:
          Q' * A * Q = T     (here ' denotes the hermitian matrix transpose,
                              i.e. transposition und conjugation).
    The unitary matrix Q is build up from Householder reflectors and
    an unitary diagonal matrix.

    parameters:
      A         (input/output) On input, A contains the complex hermitian matrix
                of dimension (n,n). On output, A contains the unitary matrix Q
                in compressed form.

      D         (output) real array of length n, contains the diagonal elements
                of the tridiagonal matrix.

      E         (output) real array of length n, contains the offdiagonal elements
                of the tridiagonal matrix in E[0:(n-1)] where is the dimension of
                the matrix A. E[n-1] is undefined.

      T         (output) complex array of length n, contains a unitary diagonal
                matrix.

    This routine is a python translation (in slightly modified form) of the fortran
    routine htridi.f in the software library EISPACK (see netlib.org) which itself
    is a complex version of the algol procedure tred1 described in:
      - Num. Math. 11, p.181-195 (1968) by Martin, Reinsch and Wilkonson
      - Handbook for auto. comp., Vol II, Linear Algebra, p.212-226 (1971)

    For a good introduction to Householder reflections, see also
      Stoer, Bulirsch - Introduction to Numerical Analysis.
    """

    n = A.shape[0]
    T[n-1] = 1
    for i in range(n - 1, 0, -1):

        # scale the vector

        scale = 0
        for k in range(i):
            scale += abs(A[k,i].real) + abs(A[k,i].imag)

        scale_inv = 0
        if scale != 0:
            scale_inv = 1 / scale

        # sadly there are floating point numbers not equal to zero whose reciprocal is infinity

        if scale == 0 or ctx.isinf(scale_inv):
            E[i] = 0
            D[i] = 0
            T[i-1] = 1
            continue

        if i == 1:
            F = A[i-1,i]
            f = abs(F)
            E[i] = f
            D[i] = 0
            if f != 0:
                T[i-1] = T[i] * F / f
            else:
                T[i-1] = T[i]
            continue

        # calculate parameters for housholder transformation

        H = 0
        for k in range(i):
            A[k,i] *= scale_inv
            rr = A[k,i].real
            ii = A[k,i].imag
            H += rr * rr + ii * ii

        F = A[i-1,i]
        f = abs(F)
        G = ctx.sqrt(H)
        H += G * f
        E[i] = scale * G
        if f != 0:
            F = F / f
            TZ = - T[i] * F              # T[i-1]=-T[i]*F, but we need T[i-1] as temporary storage
            G *= F
        else:
            TZ = -T[i]                   # T[i-1]=-T[i]
        A[i-1,i] += G
        F = 0

        # apply housholder transformation

        for j in range(i):
            A[i,j] = A[j,i] / H

            G = 0                        # calculate A*U
            for k in range(j + 1):
                G += A[k,j].conjugate() * A[k,i]
            for k in range(j + 1, i):
                G += A[j,k] * A[k,i]

            T[j] = G / H                 # calculate P
            F += T[j].conjugate() * A[j,i]

        HH = F / (2 * H)

        for j in range(i):           # calculate reduced A
            F = A[j,i]
            G = T[j] - HH * F            # calculate Q
            T[j] = G

            for k in range(j + 1):
                A[k,j] -= F.conjugate() * T[k] + G.conjugate() * A[k,i]
                # as we use the lower left part for storage
                # we have to use the transpose of the normal formula

        T[i-1] = TZ
        D[i] = H

    for i in range(1, n):                # better for compatibility
        E[i-1] = E[i]
    E[n-1] = 0

    D[0] = 0
    for i in range(n):
        zw = D[i]
        D[i] = A[i,i].real
        A[i,i] = zw







def c_he_tridiag_1(ctx, A, T):
    """
    This routine forms the unitary matrix Q described in c_he_tridiag_0.

    parameters:
      A    (input/output) On input, A is the same matrix as delivered by
           c_he_tridiag_0. On output, A is set to Q.

      T    (input) On input, T is the same array as delivered by c_he_tridiag_0.

    """

    n = A.shape[0]

    for i in range(n):
        if A[i,i] != 0:
            for j in range(i):
                G = 0
                for k in range(i):
                    G += A[i,k].conjugate() * A[k,j]
                for k in range(i):
                    A[k,j] -= G * A[k,i]

        A[i,i] = 1

        for j in range(i):
            A[j,i] = A[i,j] = 0

    for i in range(n):
        for k in range(n):
            A[i,k] *= T[k]




def c_he_tridiag_2(ctx, A, T, B):
    """
    This routine applied the unitary matrix Q described in c_he_tridiag_0
    onto the the matrix B, i.e. it forms Q*B.

    parameters:
      A    (input) On input, A is the same matrix as delivered by c_he_tridiag_0.

      T    (input) On input, T is the same array as delivered by c_he_tridiag_0.

      B    (input/output) On input, B is a complex matrix. On output B is replaced
           by Q*B.

    This routine is a python translation of the fortran routine htribk.f in the
    software library EISPACK (see netlib.org). See c_he_tridiag_0 for more
    references.
    """

    n = A.shape[0]

    for i in range(n):
        for k in range(n):
            B[k,i] *= T[k]

    for i in range(n):
        if A[i,i] != 0:
            for j in range(n):
                G = 0
                for k in range(i):
                    G += A[i,k].conjugate() * B[k,j]
                for k in range(i):
                    B[k,j] -= G * A[k,i]





def tridiag_eigen(ctx, d, e, z=None):
    """
    This subroutine find the eigenvalues and the first components of the
    eigenvectors of a real symmetric tridiagonal matrix using the implicit
    QL method.

    parameters:

      d (input/output) real array of length n. on input, d contains the diagonal
        elements of the input matrix. on output, d contains the eigenvalues in
        ascending order.

      e (input) real array of length n. on input, e contains the offdiagonal
        elements of the input matrix in e[0:(n-1)]. On output, e has been
        destroyed.

      z (input/output) If z is equal to False, no eigenvectors will be computed.
        Otherwise on input z should have the format z[0:m,0:n] (i.e. a real or
        complex matrix of dimension (m,n) ). On output this matrix will be
        multiplied by the matrix of the eigenvectors (i.e. the columns of this
        matrix are the eigenvectors): z --> z*EV
        That means if z[i,j]={1 if j==j; 0 otherwise} on input, then on output
        z will contain the first m components of the eigenvectors. That means
        if m is equal to n, the i-th eigenvector will be z[:,i].

    This routine is a python translation (in slightly modified form) of the
    fortran routine imtql2.f in the software library EISPACK (see netlib.org)
    which itself is based on the algol procudure imtql2 desribed in:
     - num. math. 12, p. 377-383(1968) by matrin and wilkinson
     - modified in num. math. 15, p. 450(1970) by dubrulle
     - handbook for auto. comp., vol. II-linear algebra, p. 241-248 (1971)
    See also the routine gaussq.f in netlog.org or acm algorithm 726.
    """

    n = len(d)
    #e[n-1] = 0
    e[n-1] = ctx.t(0)

    #iterlim = ctx.precision()
    iterlim = ctx.prec

    for l in range(n):
        j = 0
        while 1:
            m = l
            while 1:
                # look for a small subdiagonal element
                if m + 1 == n:
                    break
                #if abs(e[m]) <= ctx.epsilon() * (abs(d[m]) + abs(d[m + 1])):
                if abs(e[m]) <= ctx.eps * (abs(d[m]) + abs(d[m + 1])):
                    break
                m = m + 1
            if m == l:
                break

            if j >= iterlim:
                raise RuntimeError("tridiag_eigen: no convergence to an eigenvalue after %d iterations" % iterlim)

            j += 1

            # form shift

            p = d[l]
            g = (d[l + 1] - p) / (2 * e[l])
            r = ctx.hypot(g, 1)

            if g < 0:
                s = g - r
            else:
                s = g + r

            g = d[m] - p + e[l] / s

            s, c, p = 1, 1, 0

            for i in range(m - 1, l - 1, -1):
                f = s * e[i]
                b = c * e[i]
                if abs(f) > abs(g):             # this here is a slight improvement also used in gaussq.f or acm algorithm 726.
                    c = g / f
                    r = ctx.hypot(c, 1)
                    e[i + 1] = f * r
                    s = 1 / r
                    c = c * s
                else:
                    s = f / g
                    r = ctx.hypot(s, 1)
                    e[i + 1] = g * r
                    c = 1 / r
                    s = s * c
                g = d[i + 1] - p
                r = (d[i] - g) * s + 2 * c * b
                p = s * r
                d[i + 1] = g + p
                g = c * r - b

                if z is not None:
                    # calculate eigenvectors
                    for w in range(z.shape[0]):
                        f = z[w,i+1]
                        z[w,i+1] = s * z[w,i] + c * f
                        z[w,i  ] = c * z[w,i] - s * f

            d[l] = d[l] - p
            e[l] = g
            #e[m] = 0
            e[m] = ctx.t(0)

    for ii in range(1, n):
        # sort eigenvalues and eigenvectors (bubble-sort)
        i = ii - 1
        k = i
        p = d[i]
        for j in range(ii, n):
            if d[j] >= p:
                continue
            k = j
            p = d[k]
        if k == i:
            continue
        d[k] = d[i]
        d[i] = p

        if z is not None:
            for w in range(z.shape[0]):
                p = z[w,i]
                z[w,i] = z[w,k]
                z[w,k] = p

########################################################################################

def eigsy(ctx, A, eigvals_only=False, overwrite_a=False):
    """
    This routine solves the (ordinary) eigenvalue problem for a real symmetric
    square matrix A. Given A, an orthogonal matrix Q is calculated which
    diagonalizes A:

          Q' A Q = diag(E)               and                Q Q' = Q' Q = 1

    Here diag(E) is a diagonal matrix whose diagonal is E.
    ' denotes the transpose.

    The columns of Q are the eigenvectors of A and E contains the eigenvalues:

          A Q[:,i] = E[i] Q[:,i]

    input:

      A: real matrix of format (n,n) which is symmetric
         (i.e. A=A' or A[i,j]=A[j,i])

      eigvals_only: if true, calculates only the eigenvalues E.
                    if false, calculates both eigenvectors and eigenvalues.

      overwrite_a: if true, allows modification of A which may improve
                   performance. if false, A is not modified.

    output:

      E: vector of format (n). contains the eigenvalues of A in ascending order.

      Q: orthogonal matrix of format (n,n). contains the eigenvectors
         of A as columns.

    return value:

          E          if eigvals_only is true
         (E, Q)      if eigvals_only is false
    see also: eighe, eigh, eig
    """

    if not overwrite_a:
        A = A.copy()

    d = zeros(ctx, A.shape[0])
    e = zeros(ctx, A.shape[0])

    if eigvals_only:
        r_sy_tridiag(ctx, A, d, e, calc_ev=False)
        tridiag_eigen(ctx, d, e, None)
        return d
    else:
        r_sy_tridiag(ctx, A, d, e, calc_ev=True)
        tridiag_eigen(ctx, d, e, A)
        return (d, A)


def eighe(ctx, A, eigvals_only=False, overwrite_a=False):
    """
    This routine solves the (ordinary) eigenvalue problem for a complex
    hermitian square matrix A. Given A, an unitary matrix Q is calculated which
    diagonalizes A:

        Q' A Q = diag(E)               and                Q Q' = Q' Q = 1

    Here diag(E) a is diagonal matrix whose diagonal is E.
    ' denotes the hermitian transpose (i.e. ordinary transposition and
    complex conjugation).

    The columns of Q are the eigenvectors of A and E contains the eigenvalues:

        A Q[:,i] = E[i] Q[:,i]

    input:

      A: complex matrix of format (n,n) which is hermitian
         (i.e. A=A' or A[i,j]=conj(A[j,i]))

      eigvals_only: if true, calculates only the eigenvalues E.
                    if false, calculates both eigenvectors and eigenvalues.

      overwrite_a: if true, allows modification of A which may improve
                   performance. if false, A is not modified.

    output:

      E: vector of format (n). contains the eigenvalues of A in ascending order.

      Q: unitary matrix of format (n,n). contains the eigenvectors
         of A as columns.

    return value:

           E         if eigvals_only is true
          (E, Q)     if eigvals_only is false
    see also: eigsy, eigh, eig
    """

    if not overwrite_a:
        A = A.copy()

    d = zeros(ctx, A.shape[0])
    e = zeros(ctx, A.shape[0])
    t = zeros(ctx, A.shape[0])

    if eigvals_only:
        c_he_tridiag_0(ctx, A, d, e, t)
        tridiag_eigen(ctx, d, e, None)
        return d
    else:
        c_he_tridiag_0(ctx, A, d, e, t)
        B = eye(ctx, A.shape[0])
        tridiag_eigen(ctx, d, e, B)
        c_he_tridiag_2(ctx, A, t, B)
        return (d, B)


def eigh(ctx, A, eigvals_only=False, overwrite_a=False):
    """
    "eigh" is a unified interface for "eigsy" and "eighe". Depending on
    whether A is real or complex the appropriate function is called.

    This routine solves the (ordinary) eigenvalue problem for a real symmetric
    or complex hermitian square matrix A. Given A, an orthogonal (A real) or
    unitary (A complex) matrix Q is calculated which diagonalizes A:

        Q' A Q = diag(E)               and                Q Q' = Q' Q = 1

    Here diag(E) a is diagonal matrix whose diagonal is E.
    ' denotes the hermitian transpose (i.e. ordinary transposition and
    complex conjugation).

    The columns of Q are the eigenvectors of A and E contains the eigenvalues:

        A Q[:,i] = E[i] Q[:,i]

    input:

      A: a real or complex square matrix of format (n,n) which is symmetric
         (i.e. A[i,j]=A[j,i]) or hermitian (i.e. A[i,j]=conj(A[j,i])).

      eigvals_only: if true, calculates only the eigenvalues E.
                    if false, calculates both eigenvectors and eigenvalues.

      overwrite_a: if true, allows modification of A which may improve
                   performance. if false, A is not modified.

    output:

      E: vector of format (n). contains the eigenvalues of A in ascending order.

      Q: an orthogonal or unitary matrix of format (n,n). contains the
         eigenvectors of A as columns.

    return value:

          E         if eigvals_only is true
         (E, Q)     if eigvals_only is false
    see also: eigsy, eighe, eig
    """

    # iscomplex = any(isinstance(x, numbers.Complex) and not isinstance(x, numbers.Real)
    #         for x in A.flat)

    iscomplex = contains_complex(ctx, A)

    if iscomplex:
        return eighe(ctx, A, eigvals_only=eigvals_only, overwrite_a=overwrite_a)
    else:
        return eigsy(ctx, A, eigvals_only=eigvals_only, overwrite_a=overwrite_a)


def gauss_quadrature(ctx, n, qtype="legendre", alpha=0, beta=0):
    """
    This routine calulates Gaussian quadrature rules for different
    families of orthogonal polynomials. Let (a, b) be an interval,
    W(x) a positive weight function and n a positive integer.
    Then the purpose of this routine is to calculate pairs (x_k, w_k)
    for k=0, 1, 2, ... (n-1) which give

      int(W(x) * F(x), x = a..b) = sum(w_k * F(x_k),k = 0..(n-1))

    exact for all polynomials F(x) of degree (strictly) less than 2*n. For all
    integrable functions F(x) the sum is a (more or less) good approximation to
    the integral. The x_k are called nodes (which are the zeros of the
    related orthogonal polynomials) and the w_k are called the weights.

    parameters
       n        (input) The degree of the quadrature rule, i.e. its number of
                nodes.

       qtype    (input) The family of orthogonal polynmomials for which to
                compute the quadrature rule. See the list below.

       alpha    (input) real number, used as parameter for some orthogonal
                polynomials

       beta     (input) real number, used as parameter for some orthogonal
                polynomials.

    return value

      (X, W)    a pair of two real arrays where x_k = X[k] and w_k = W[k].


    orthogonal polynomials:

      qtype           polynomial
      -----           ----------

      "legendre"      Legendre polynomials, W(x)=1 on the interval (-1, +1)
      "legendre01"    shifted Legendre polynomials, W(x)=1 on the interval (0, +1)
      "hermite"       Hermite polynomials, W(x)=exp(-x*x) on (-infinity,+infinity)
      "laguerre"      Laguerre polynomials, W(x)=exp(-x) on (0,+infinity)
      "glaguerre"     generalized Laguerre polynomials, W(x)=exp(-x)*x**alpha
                      on (0, +infinity)
      "chebyshev1"    Chebyshev polynomials of the first kind, W(x)=1/sqrt(1-x*x)
                      on (-1, +1)
      "chebyshev2"    Chebyshev polynomials of the second kind, W(x)=sqrt(1-x*x)
                      on (-1, +1)
      "jacobi"        Jacobi polynomials, W(x)=(1-x)**alpha * (1+x)**beta on (-1, +1)
                      with alpha>-1 and beta>-1

    examples:
      >>> from mpmath import mp
      >>> f = lambda x: x**8 + 2 * x**6 - 3 * x**4 + 5 * x**2 - 7
      >>> X, W = mp.gauss_quadrature(5, "hermite")
      >>> A = mp.fdot([(f(x), w) for x, w in zip(X, W)])
      >>> B = mp.sqrt(mp.pi) * 57 / 16
      >>> C = mp.quad(lambda x: mp.exp(- x * x) * f(x), [-mp.inf, +mp.inf])
      >>> print mp.chop(A-B, tol = 1e-10), mp.chop(A-C, tol = 1e-10)
      0.0 0.0

      >>> f = lambda x: x**5 - 2 * x**4 + 3 * x**3 - 5 * x**2 + 7 * x - 11
      >>> X, W = mp.gauss_quadrature(3, "laguerre")
      >>> A = mp.fdot([(f(x), w) for x, w in zip(X, W)])
      >>> B = 76
      >>> C = mp.quad(lambda x: mp.exp(-x) * f(x), [0, +mp.inf])
      >>> print mp.chop(A-B, tol = 1e-10), mp.chop(A-C, tol = 1e-10)
      0.0 0.0

      # orthogonality of the chebyshev polynomials:
      >>> f = lambda x: mp.chebyt(3, x) * mp.chebyt(2, x)
      >>> X, W = mp.gauss_quadrature(3, "chebyshev1")
      >>> A = mp.fdot([(f(x), w) for x, w in zip(X, W)])
      >>> print(mp.chop(A, tol = 1e-10))
      0.0

    references:
      - golub and welsch, "calculations of gaussian quadrature rules", mathematics of
        computation 23, p. 221-230 (1969)
      - golub, "some modified matrix eigenvalue problems", siam review 15, p. 318-334 (1973)
      - stroud and secrest, "gaussian quadrature formulas", prentice-hall (1966)

    See also the routine gaussq.f in netlog.org or ACM Transactions on
    Mathematical Software algorithm 726.
    """

    d = zeros(ctx, n)
    e = zeros(ctx, n)
    #z = zeros((ctx, 1, n))
    z = zeros(ctx, (1, n))

    z[0,0] = 1

    if qtype == "legendre":
        # legendre on the range -1 +1 , abramowitz, table 25.4, p.916
        w = 2
        for i in range(n):
            j = i + 1
            e[i] = ctx.sqrt(j * j / (4 * j * j - ctx.mpf(1)))
    elif qtype == "legendre01":
        # legendre shifted to 0 1        , abramowitz, table 25.8, p.921
        w = 1
        for i in range(n):
            d[i] = 1 / ctx.mpf(2)
            j = i + 1
            e[i] = ctx.sqrt(j * j / (16 * j * j - ctx.mpf(4)))
    elif qtype == "hermite":
        # hermite on the range -inf +inf , abramowitz, table 25.10,p.924
        #w = ctx.sqrt(ctx.const_pi())
        w = ctx.sqrt(ctx.pi)
        for i in range(n):
            j = i + 1
            e[i] = ctx.sqrt(j / ctx.mpf(2))
    elif qtype == "laguerre":
        # laguerre on the range 0 +inf , abramowitz, table 25.9, p. 923
        w = 1
        for i in range(n):
            j = i + 1
            d[i] = ctx.mpf(2 * j - 1)
            e[i] = ctx.mpf(j)
    elif qtype=="chebyshev1":
        # chebyshev polynimials of the first kind
        #w = ctx.const_pi()
        w = ctx.pi
        for i in range(n):
            e[i] = 1 / ctx.mpf(2)
        e[0] = ctx.sqrt(1 / ctx.mpf(2))
    elif qtype == "chebyshev2":
        # chebyshev polynimials of the second kind
        #w = ctx.const_pi() / 2
        w = ctx.pi / 2
        for i in range(n):
            e[i] = 1 / ctx.mpf(2)
    elif qtype == "glaguerre":
        # generalized laguerre on the range 0 +inf
        w = ctx.gamma(1 + alpha)
        for i in range(n):
            j = i + 1
            d[i] = ctx.mpf(2 * j - 1 + alpha)
            e[i] = ctx.sqrt(j * (j + alpha))
    elif qtype == "jacobi":
        # jacobi polynomials
        alpha = ctx.mpf(alpha)
        beta = ctx.mpf(beta)
        ab = alpha + beta
        abi = ab + 2
        w = (2**(ab+1)) * ctx.gamma(alpha + 1) * ctx.gamma(beta + 1) / ctx.gamma(abi)
        d[0] = (beta - alpha) / abi
        e[0] = ctx.sqrt(4 * (1 + alpha) * (1 + beta) / ((abi + 1) * (abi * abi)))
        a2b2 = beta * beta - alpha * alpha
        for i in range(1, n):
            j = i + 1
            abi = 2 * j + ab
            d[i] = a2b2 / ((abi - 2) * abi)
            e[i] = ctx.sqrt(4 * j * (j + alpha) * (j + beta) * (j + ab) / ((abi * abi - 1) * abi * abi))
    elif isinstance(qtype, str):
        raise ValueError("unknown quadrature rule \"%s\"" % qtype)
    elif not isinstance(qtype, str):
        w = qtype(d, e)
    else:
        assert 0

    tridiag_eigen(ctx, d, e, z)

    for i in range(len(z)):
        z[i] *= z[i]

    return (d, w * z[0, :])

##################################################################################################
##################################################################################################
##################################################################################################

def svd_r_raw(ctx, A, V=None, calc_u=False):
    """
    This routine computes the singular value decomposition of a matrix A.
    Given A, two orthogonal matrices U and V are calculated such that

                    A = U S V

    where S is a suitable shaped matrix whose off-diagonal elements are zero.
    The diagonal elements of S are the singular values of A, i.e. the
    squareroots of the eigenvalues of A' A or A A'. Here ' denotes the transpose.
    Householder bidiagonalization and a variant of the QR algorithm is used.

    overview of the matrices :

      A : m*n       A gets replaced by U
      U : m*n       U replaces A. If n>m then only the first m*m block of U is
                    non-zero. column-orthogonal: U' U = B
                    here B is a n*n matrix whose first min(m,n) diagonal
                    elements are 1 and all other elements are zero.
      S : n*n       diagonal matrix, only the diagonal elements are stored in
                    the array S. only the first min(m,n) diagonal elements are non-zero.
      V : n*n       orthogonal: V V' = V' V = 1

    parameters:
      A        (input/output) On input, A contains a real matrix of shape m*n.
               On output, if calc_u is true A contains the column-orthogonal
               matrix U; otherwise A is simply used as workspace and thus destroyed.

      V        (input/output) if None, the matrix V is not calculated. otherwise
               V must be a matrix of shape n*n.

      calc_u   (input) If true, the matrix U is calculated and replaces A.
               if false, U is not calculated and A is simply destroyed

    return value:
      S        an array of length n containing the singular values of A sorted by
               decreasing magnitude. only the first min(m,n) elements are non-zero.

    This routine is a python translation of the fortran routine svd.f in the
    software library EISPACK (see netlib.org) which itself is based on the
    algol procedure svd described in:
      - num. math. 14, 403-420(1970) by golub and reinsch.
      - wilkinson/reinsch: handbook for auto. comp., vol ii-linear algebra, 134-151(1971).

    """

    m, n = A.shape

    S = zeros(ctx, n)
    work = zeros(ctx, n)

    g = scale = anorm = 0
    #maxits = ctx.precision()
    maxits = ctx.prec

    for i in range(n):     # householder reduction to bidiagonal form
        work[i] = scale*g
        g = s = scale = 0
        if i < m:
            for k in range(i, m):
                scale += abs(A[k,i])
            if scale != 0:
                for k in range(i, m):
                    A[k,i] /= scale
                    s += A[k,i] * A[k,i]
                f = A[i,i]
                g = -ctx.sqrt(s)
                if f < 0:
                    g = -g
                h = f * g - s
                A[i,i] = f - g
                for j in range(i+1, n):
                    s = 0
                    for k in range(i, m):
                        s += A[k,i] * A[k,j]
                    f = s / h
                    for k in range(i, m):
                        A[k,j] += f * A[k,i]
                for k in range(i,m):
                    A[k,i] *= scale

        S[i] = scale * g
        g = s = scale = 0

        if i < m and i != n - 1:
            for k in range(i+1, n):
                scale += abs(A[i,k])
            if scale:
                for k in range(i+1, n):
                    A[i,k] /= scale
                    s += A[i,k] * A[i,k]
                f = A[i,i+1]
                g = -ctx.sqrt(s)
                if f < 0:
                    g = -g
                h = f * g - s
                A[i,i+1] = f - g

                for k in range(i+1, n):
                    work[k] = A[i,k] / h

                for j in range(i+1, m):
                    s = 0
                    for k in range(i+1, n):
                        s += A[j,k] * A[i,k]
                    for k in range(i+1, n):
                        A[j,k] += s * work[k]

                for k in range(i+1, n):
                    A[i,k] *= scale

        anorm = max(anorm, abs(S[i]) + abs(work[i]))

    if V is not None:
        for i in range(n-2, -1, -1):     # accumulation of right hand transformations
            V[i+1,i+1] = 1

            if work[i+1] != 0:
                for j in range(i+1, n):
                    V[i,j] = (A[i,j] / A[i,i+1]) / work[i+1]
                for j in range(i+1, n):
                    s = 0
                    for k in range(i+1, n):
                        s += A[i,k] * V[j,k]
                    for k in range(i+1, n):
                        V[j,k] += s * V[i,k]

            for j in range(i+1, n):
                V[j,i] = V[i,j] = 0

        V[0,0] = 1

    if m<n : minnm = m
    else   : minnm = n

    if calc_u:
        for i in range(minnm-1, -1, -1): # accumulation of left hand transformations
            g = S[i]
            for j in range(i+1, n):
                A[i,j] = 0
            if g != 0:
                g = 1 / g
                for j in range(i+1, n):
                    s = 0
                    for k in range(i+1, m):
                        s += A[k,i] * A[k,j]
                    f = (s / A[i,i]) * g
                    for k in range(i, m):
                        A[k,j] += f * A[k,i]
                for j in range(i, m):
                    A[j,i] *= g
            else:
                for j in range(i, m):
                    A[j,i] = 0
            A[i,i] += 1

    for k in range(n - 1, -1, -1):
        # diagonalization of the bidiagonal form:
        #   loop over singular values, and over allowed itations
        its = 0
        while 1:
            its += 1
            flag = True

            for l in range(k, -1, -1):
                nm = l-1

                if abs(work[l]) + anorm == anorm:
                    flag = False
                    break

                if abs(S[nm]) + anorm == anorm:
                    break

            if flag:
                c = 0
                s = 1
                for i in range(l, k + 1):
                    f = s * work[i]
                    work[i] *= c
                    if abs(f) + anorm == anorm:
                        break
                    g = S[i]
                    h = ctx.hypot(f, g)
                    S[i] = h
                    h = 1 / h
                    c = g * h
                    s = - f * h

                    if calc_u:
                        for j in range(m):
                            y = A[j,nm]
                            z = A[j,i]
                            A[j,nm] = y * c + z * s
                            A[j,i]  = z * c - y * s

            z = S[k]

            if l == k:               # convergence
                if z < 0:            # singular value is made nonnegative
                    S[k] = -z
                    if V is not None:
                        for j in range(n):
                            V[k,j] = -V[k,j]
                break

            if its >= maxits:
                raise RuntimeError("svd: no convergence to an eigenvalue after %d iterations" % its)

            x = S[l]         # shift from bottom 2 by 2 minor
            nm = k-1
            y = S[nm]
            g = work[nm]
            h = work[k]
            f = ((y - z) * (y + z) + (g - h) * (g + h))/(2 * h * y)
            g = ctx.hypot(f, 1)
            if f >= 0: f = ((x - z) * (x + z) + h * ((y / (f + g)) - h)) / x
            else:      f = ((x - z) * (x + z) + h * ((y / (f - g)) - h)) / x

            c = s = 1         # next qt transformation

            for j in range(l, nm + 1):
                g = work[j+1]
                y = S[j+1]
                h = s * g
                g = c * g
                z = ctx.hypot(f, h)
                work[j] = z
                c = f / z
                s = h / z
                f = x * c + g * s
                g = g * c - x * s
                h = y * s
                y *= c
                if V is not None:
                    for jj in range(n):
                        x = V[j  ,jj]
                        z = V[j+1,jj]
                        V[j    ,jj]= x * c + z * s
                        V[j+1  ,jj]= z * c - x * s
                z = ctx.hypot(f, h)
                S[j] = z
                if z != 0:            # rotation can be arbitray if z=0
                    z = 1 / z
                    c = f * z
                    s = h * z
                f = c * g + s * y
                x = c * y - s * g

                if calc_u:
                    for jj in range(m):
                        y = A[jj,j  ]
                        z = A[jj,j+1]
                        A[jj,j    ] = y * c + z * s
                        A[jj,j+1  ] = z * c - y * s

            work[l] = 0
            work[k] = f
            S[k] = x

    ##########################

    # Sort singular values into decreasing order (bubble-sort)

    for i in range(n):
        imax = i
        s = abs(S[i])         # s is the current maximal element

        for j in range(i + 1, n):
            c = abs(S[j])
            if c > s:
                s = c
                imax = j

        if imax != i:
            # swap singular values

            z = S[i]
            S[i] = S[imax]
            S[imax] = z

            if calc_u:
                for j in range(m):
                    z = A[j,i]
                    A[j,i] = A[j,imax]
                    A[j,imax] = z

            if V is not None:
                for j in range(n):
                    z = V[i,j]
                    V[i,j] = V[imax,j]
                    V[imax,j] = z

    return S

#######################

def svd_c_raw(ctx, A, V=None, calc_u=False):
    """
    This routine computes the singular value decomposition of a matrix A.
    Given A, two unitary matrices U and V are calculated such that

                    A = U S V

    where S is a suitable shaped matrix whose off-diagonal elements are zero.
    The diagonal elements of S are the singular values of A, i.e. the
    squareroots of the eigenvalues of A' A or A A'. Here ' denotes the hermitian
    transpose (i.e. transposition and conjugation). Householder bidiagonalization
    and a variant of the QR algorithm is used.

    overview of the matrices :

      A : m*n       A gets replaced by U
      U : m*n       U replaces A. If n>m then only the first m*m block of U is
                    non-zero. column-unitary: U' U = B
                    here B is a n*n matrix whose first min(m,n) diagonal
                    elements are 1 and all other elements are zero.
      S : n*n       diagonal matrix, only the diagonal elements are stored in
                    the array S. only the first min(m,n) diagonal elements are non-zero.
      V : n*n       unitary: V V' = V' V = 1

    parameters:
      A        (input/output) On input, A contains a complex matrix of shape m*n.
               On output, if calc_u is true A contains the column-unitary
               matrix U; otherwise A is simply used as workspace and thus destroyed.

      V        (input/output) if None, the matrix V is not calculated. otherwise
               V must be a matrix of shape n*n.

      calc_u   (input) If true, the matrix U is calculated and replaces A.
               if false, U is not calculated and A is simply destroyed

    return value:
      S        an array of length n containing the singular values of A sorted by
               decreasing magnitude. only the first min(m,n) elements are non-zero.

    This routine is a python translation of the fortran routine svd.f in the
    software library EISPACK (see netlib.org) which itself is based on the
    algol procedure svd described in:
      - num. math. 14, 403-420(1970) by golub and reinsch.
      - wilkinson/reinsch: handbook for auto. comp., vol ii-linear algebra, 134-151(1971).

    """

    m, n = A.shape

    S = zeros(ctx, n)

    # work is a temporary array of size n
    work  = zeros(ctx, n)
    lbeta = zeros(ctx, n)
    rbeta = zeros(ctx, n)
    dwork = zeros(ctx, n)

    g = scale = anorm = 0
    #maxits = ctx.precision()
    maxits = ctx.prec

    for i in range(n):         # householder reduction to bidiagonal form
        dwork[i] = scale * g    # dwork are the side-diagonal elements
        g = s = scale = 0
        if i < m:
            for k in range(i, m):
                scale += abs(A[k,i].real) + abs(A[k,i].imag)
            if scale != 0:
                for k in range(i, m):
                    A[k,i] /= scale
                    ar = A[k,i].real
                    ai = A[k,i].imag
                    s += ar * ar + ai * ai
                f = A[i,i]
                g = -ctx.sqrt(s)
                if f.real < 0:
                    beta = -g - f.conjugate()
                    g = -g
                else:
                    beta = -g + f.conjugate()
                beta /= beta.conjugate()
                beta += 1
                h = 2 * (f.real * g - s)
                A[i,i] = f - g
                beta /= h
                lbeta[i] = (beta / scale) / scale
                for j in range(i+1, n):
                    s = 0
                    for k in range(i, m):
                        s += A[k,i].conjugate() * A[k,j]
                    f = beta * s
                    for k in range(i, m):
                        A[k,j] += f * A[k,i]
                for k in range(i, m):
                    A[k,i] *= scale

        S[i] = scale * g     # S are the diagonal elements
        g = s = scale = 0

        if i < m and i != n - 1:
            for k in range(i+1, n):
                scale += abs(A[i,k].real) + abs(A[i,k].imag)
            if scale:
                for k in range(i+1, n):
                    A[i,k] /= scale
                    ar = A[i,k].real
                    ai = A[i,k].imag
                    s += ar * ar + ai * ai
                f = A[i,i+1]
                g = -ctx.sqrt(s)
                if f.real < 0:
                    beta = -g - f.conjugate()
                    g = -g
                else:
                    beta = -g + f.conjugate()

                beta /= beta.conjugate()
                beta += 1

                h = 2 * (f.real * g - s)
                A[i,i+1] = f - g

                beta /= h
                rbeta[i] = (beta / scale) / scale

                for k in range(i+1, n):
                    work[k] = A[i, k]

                for j in range(i+1, m):
                    s = 0
                    for k in range(i+1, n):
                        s += A[i,k].conjugate() * A[j,k]
                    f = s * beta
                    for k in range(i+1,n):
                        A[j,k] += f * work[k]

                for k in range(i+1, n):
                    A[i,k] *= scale

        anorm = max(anorm, abs(S[i]) + abs(dwork[i]))

    if V is not None:
        for i in range(n-2, -1, -1):     # accumulation of right hand transformations
            V[i+1,i+1] = 1

            if dwork[i+1] != 0:
                f = rbeta[i].conjugate()
                for j in range(i+1, n):
                    V[i,j] = A[i,j] * f
                for j in range(i+1, n):
                    s = 0
                    for k in range(i+1, n):
                        s += A[i,k].conjugate() * V[j,k]
                    for k in range(i+1, n):
                        V[j,k] += s * V[i,k]

            for j in range(i+1,n):
                V[j,i] = V[i,j] = 0

        V[0,0] = 1

    if m < n : minnm = m
    else     : minnm = n

    if calc_u:
        for i in range(minnm-1, -1, -1): # accumulation of left hand transformations
            g = S[i]
            for j in range(i+1, n):
                A[i,j] = 0
            if g != 0:
                g = 1 / g
                for j in range(i+1, n):
                    s = 0
                    for k in range(i+1, m):
                        s += A[k,i].conjugate() * A[k,j]
                    f = s * lbeta[i].conjugate()
                    for k in range(i, m):
                        A[k,j] += f * A[k,i]
                for j in range(i, m):
                    A[j,i] *= g
            else:
                for j in range(i, m):
                    A[j,i] = 0
            A[i,i] += 1

    for k in range(n-1, -1, -1):
        # diagonalization of the bidiagonal form:
        #   loop over singular values, and over allowed itations

        its = 0
        while 1:
            its += 1
            flag = True

            for l in range(k, -1, -1):
                nm = l - 1

                if abs(dwork[l]) + anorm == anorm:
                    flag = False
                    break

                if abs(S[nm]) + anorm == anorm:
                    break

            if flag:
                c = 0
                s = 1
                for i in range(l, k+1):
                    f = s * dwork[i]
                    dwork[i] *= c
                    if abs(f) + anorm == anorm:
                        break
                    g = S[i]
                    h = ctx.hypot(f, g)
                    S[i] = h
                    h = 1 / h
                    c = g * h
                    s = -f * h

                    if calc_u:
                        for j in range(m):
                            y = A[j,nm]
                            z = A[j,i]
                            A[j,nm]= y * c + z * s
                            A[j,i] = z * c - y * s

            z = S[k]

            if l == k:         # convergence
                if z < 0:    # singular value is made nonnegative
                    S[k] = -z
                    if V is not None:
                        for j in range(n):
                            V[k,j] = -V[k,j]
                break

            if its >= maxits:
                raise RuntimeError("svd: no convergence to an eigenvalue after %d iterations" % its)

            x = S[l]         # shift from bottom 2 by 2 minor
            nm = k-1
            y = S[nm]
            g = dwork[nm]
            h = dwork[k]
            f = ((y - z) * (y + z) + (g - h) * (g + h)) / (2 * h * y)
            g = ctx.hypot(f, 1)
            if f >=0: f = (( x - z) *( x + z) + h *((y / (f + g)) - h)) / x
            else:     f = (( x - z) *( x + z) + h *((y / (f - g)) - h)) / x

            c = s = 1         # next qt transformation

            for j in range(l, nm + 1):
                g = dwork[j+1]
                y = S[j+1]
                h = s * g
                g = c * g
                z = ctx.hypot(f, h)
                dwork[j] = z
                c = f / z
                s = h / z
                f = x * c + g * s
                g = g * c - x * s
                h = y * s
                y *= c
                if V is not None:
                    for jj in range(n):
                        x = V[j  ,jj]
                        z = V[j+1,jj]
                        V[j    ,jj]= x * c + z * s
                        V[j+1,jj  ]= z * c - x * s
                z = ctx.hypot(f, h)
                S[j] = z
                if z != 0:            # rotation can be arbitray if z=0
                    z = 1 / z
                    c = f * z
                    s = h * z
                f = c * g + s * y
                x = c * y - s * g
                if calc_u:
                    for jj in range(m):
                        y = A[jj,j  ]
                        z = A[jj,j+1]
                        A[jj,j    ]= y * c + z * s
                        A[jj,j+1  ]= z * c - y * s

            dwork[l] = 0
            dwork[k] = f
            S[k] = x

    ##########################

    # Sort singular values into decreasing order (bubble-sort)

    for i in range(n):
        imax = i
        s = abs(S[i])         # s is the current maximal element

        for j in range(i + 1, n):
            c = abs(S[j])
            if c > s:
                s = c
                imax = j

        if imax != i:
            # swap singular values

            z = S[i]
            S[i] = S[imax]
            S[imax] = z

            if calc_u:
                for j in range(m):
                    z = A[j,i]
                    A[j,i] = A[j,imax]
                    A[j,imax] = z

            if V is not None:
                for j in range(n):
                    z = V[i,j]
                    V[i,j] = V[imax,j]
                    V[imax,j] = z

    return S

##################################################################################################

def svd_r(ctx, A, full_matrices=False, compute_uv=True, overwrite_a=False):
    """
    This routine computes the singular value decomposition of a matrix A.
    Given A, two orthogonal matrices U and V are calculated such that

           A = U S V        and        U' U = 1         and         V V' = 1

    where S is a suitable shaped matrix whose off-diagonal elements are zero.
    Here ' denotes the transpose. The diagonal elements of S are the singular
    values of A, i.e. the squareroots of the eigenvalues of A' A or A A'.

    input:
      A             : a real matrix of shape (m, n)
      full_matrices : if true, U and V are of shape (m, m) and (n, n).
                      if false, U and V are of shape (m, min(m, n)) and (min(m, n), n).
      compute_uv    : if true, U and V are calculated. if false, only S is calculated.
      overwrite_a   : if true, allows modification of A which may improve
                      performance. if false, A is not modified.

    output:
      U : an orthogonal matrix: U' U = 1. if full_matrices is true, U is of
          shape (m, m). ortherwise it is of shape (m, min(m, n)).

      S : an array of length min(m, n) containing the singular values of A sorted by
          decreasing magnitude.

      V : an orthogonal matrix: V V' = 1. if full_matrices is true, V is of
          shape (n, n). ortherwise it is of shape (min(m, n), n).

    return value:

           S          if compute_uv is false
       (U, S, V)      if compute_uv is true

    overview of the matrices:

      full_matrices true:
        A           : m*n
        U           : m*m     U' U  = 1
        S as matrix : m*n
        V           : n*n     V  V' = 1

     full_matrices false:
        A           : m*n
        U           : m*min(n,m)             U' U  = 1
        S as matrix : min(m,n)*min(m,n)
        V           : min(m,n)*n             V  V' = 1
    see also: svd, svd_c
    """

    m, n = A.shape

    if not compute_uv:
        if not overwrite_a:
            A = A.copy()
        S = svd_r_raw(ctx, A, V=None, calc_u=False)
        return S[:min(m,n)]

    if full_matrices and n < m:
        V = zeros(ctx, (m, m))
        A0 = zeros(ctx, (m, m))
        A0[:,:n] = A
        S = svd_r_raw(ctx, A0, V, calc_u=True)
        return (A0, S[:n], V[:n,:n])
    else:
        if not overwrite_a:
            A = A.copy()
        V = zeros(ctx, (n, n))
        S = svd_r_raw(ctx, A, V, calc_u=True)

        if n > m:
            if full_matrices == False:
                V = V[:m,:]

            S = S[:m]
            A = A[:,:m]

        return (A, S, V)

##############################

def svd_c(ctx, A, full_matrices=False, compute_uv=True, overwrite_a=False):
    """
    This routine computes the singular value decomposition of a matrix A.
    Given A, two unitary matrices U and V are calculated such that

           A = U S V        and        U' U = 1         and         V V' = 1

    where S is a suitable shaped matrix whose off-diagonal elements are zero.
    Here ' denotes the hermitian transpose (i.e. transposition and complex
    conjugation). The diagonal elements of S are the singular values of A,
    i.e. the squareroots of the eigenvalues of A' A or A A'.

    input:
      A             : a complex matrix of shape (m, n)
      full_matrices : if true, U and V are of shape (m, m) and (n, n).
                      if false, U and V are of shape (m, min(m, n)) and (min(m, n), n).
      compute_uv    : if true, U and V are calculated. if false, only S is calculated.
      overwrite_a   : if true, allows modification of A which may improve
                      performance. if false, A is not modified.

    output:
      U : an unitary matrix: U' U = 1. if full_matrices is true, U is of
          shape (m, m). ortherwise it is of shape (m, min(m, n)).

      S : an array of length min(m, n) containing the singular values of A sorted by
          decreasing magnitude.

      V : an unitary matrix: V V' = 1. if full_matrices is true, V is of
          shape (n, n). ortherwise it is of shape (min(m, n), n).

    return value:

           S          if compute_uv is false
       (U, S, V)      if compute_uv is true

    overview of the matrices:

      full_matrices true:
        A           : m*n
        U           : m*m     U' U  = 1
        S as matrix : m*n
        V           : n*n     V  V' = 1

     full_matrices false:
        A           : m*n
        U           : m*min(n,m)             U' U  = 1
        S as matrix : min(m,n)*min(m,n)
        V           : min(m,n)*n             V  V' = 1
    see also: svd, svd_r
    """

    m, n = A.shape

    if not compute_uv:
        if not overwrite_a:
            A = A.copy()
        S = svd_c_raw(ctx, A, V=None, calc_u=False)
        S = S[:min(m,n)]
        return S

    if full_matrices and n < m:
        V = zeros(ctx, (m, m))
        A0 = zeros(ctx, (m, m))
        A0[:,:n] = A
        S = svd_c_raw(ctx, A0, V, calc_u=True)

        S = S[:n]
        V = V[:n,:n]

        return (A0, S, V)
    else:
        if not overwrite_a:
            A = A.copy()
        V = zeros(ctx, (n, n))
        S = svd_c_raw(ctx, A, V, calc_u=True)

        if n > m:
            if full_matrices == False:
                V = V[:m,:]

            S = S[:m]
            A = A[:,:m]

        return (A, S, V)


def svd(ctx, A, full_matrices=False, compute_uv=True, overwrite_a=False):
    """
    "svd" is a unified interface for "svd_r" and "svd_c". Depending on
    whether A is real or complex the appropriate function is called.

    This routine computes the singular value decomposition of a matrix A.
    Given A, two orthogonal (A real) or unitary (A complex) matrices U and V
    are calculated such that

           A = U S V        and        U' U = 1         and         V V' = 1

    where S is a suitable shaped matrix whose off-diagonal elements are zero.
    Here ' denotes the hermitian transpose (i.e. transposition and complex
    conjugation). The diagonal elements of S are the singular values of A,
    i.e. the squareroots of the eigenvalues of A' A or A A'.

    input:
      A             : a real or complex matrix of shape (m, n)
      full_matrices : if true, U and V are of shape (m, m) and (n, n).
                      if false, U and V are of shape (m, min(m, n)) and (min(m, n), n).
      compute_uv    : if true, U and V are calculated. if false, only S is calculated.
      overwrite_a   : if true, allows modification of A which may improve
                      performance. if false, A is not modified.

    output:
      U : an orthogonal or unitary matrix: U' U = 1. if full_matrices is true, U is of
          shape (m, m). ortherwise it is of shape (m, min(m, n)).

      S : an array of length min(m, n) containing the singular values of A sorted by
          decreasing magnitude.

      V : an orthogonal or unitary matrix: V V' = 1. if full_matrices is true, V is of
          shape (n, n). ortherwise it is of shape (min(m, n), n).

    return value:

           S          if compute_uv is false
       (U, S, V)      if compute_uv is true

    overview of the matrices:

      full_matrices true:
        A           : m*n
        U           : m*m     U' U  = 1
        S as matrix : m*n
        V           : n*n     V  V' = 1

     full_matrices false:
        A           : m*n
        U           : m*min(n,m)             U' U  = 1
        S as matrix : min(m,n)*min(m,n)
        V           : min(m,n)*n             V  V' = 1
    see also: svd_r, svd_c
    """

    # iscomplex = any(isinstance(x, numbers.Complex) and not isinstance(x, numbers.Real)
    #         for x in A.flat)

    iscomplex = contains_complex(ctx, A)


    if iscomplex:
        return svd_c(ctx, A, full_matrices=full_matrices, compute_uv=compute_uv, overwrite_a=overwrite_a)
    else:
        return svd_r(ctx, A, full_matrices=full_matrices, compute_uv=compute_uv, overwrite_a=overwrite_a)




##################################################################################################
#     module for the eigenvalue problem
#       Copyright 2013 Timo Hartmann (thartmann15 at gmail.com)
#
# todo:
#  - implement balancing
#  - agressive early deflation
#
##################################################################################################


"""
The eigenvalue problem
----------------------

This file contains routines for the eigenvalue problem.

high level routines:

  hessenberg : reduction of a real or complex square matrix to upper Hessenberg form
  schur : reduction of a real or complex square matrix to upper Schur form
  eig : eigenvalues and eigenvectors of a real or complex square matrix

low level routines:

  hessenberg_reduce_0 : reduction of a real or complex square matrix to upper Hessenberg form
  hessenberg_reduce_1 : auxiliary routine to hessenberg_reduce_0
  qr_step : a single implicitly shifted QR step for an upper Hessenberg matrix
  hessenberg_qr : Schur decomposition of an upper Hessenberg matrix
  eig_tr_r : right eigenvectors of an upper triangular matrix
  eig_tr_l : left  eigenvectors of an upper triangular matrix
"""

def hessenberg_reduce_0(ctx, A, T):
    """
    This routine computes the (upper) Hessenberg decomposition of a square matrix A.
    Given A, an unitary matrix Q is calculated such that

               Q' A Q = H              and             Q' Q = Q Q' = 1

    where H is an upper Hessenberg matrix, meaning that it only contains zeros
    below the first subdiagonal. Here ' denotes the hermitian transpose (i.e.
    transposition and conjugation).

    parameters:
      A         (input/output) On input, A contains the square matrix A of
                dimension (n,n). On output, A contains a compressed representation
                of Q and H.
      T         (output) An array of length n containing the first elements of
                the Householder reflectors.
    """
    # internally we work with householder reflections from the right.
    # let u be a row vector (i.e. u[i]=A[i,:i]). then
    # Q is build up by reflectors of the type (1-v'v) where v is a suitable
    # modification of u. these reflectors are applyed to A from the right.
    # because we work with reflectors from the right we have to start with
    # the bottom row of A and work then upwards (this corresponds to
    # some kind of RQ decomposition).
    # the first part of the vectors v (i.e. A[i,:(i-1)]) are stored as row vectors
    # in the lower left part of A (excluding the diagonal and subdiagonal).
    # the last entry of v is stored in T.
    # the upper right part of A (including diagonal and subdiagonal) becomes H.

    n = A.shape[0]

    for i in range(n-1, 1, -1):
        # scale the vector
        scale = 0
        for k in range(i):
            scale += abs(A[i,k].real) + abs(A[i,k].imag)

        scale_inv = 0
        if scale != 0:
            scale_inv = 1 / scale

        if scale == 0 or ctx.isinf(scale_inv):
            # sadly there are floating point numbers not equal to zero whose reciprocal is infinity
            T[i] = 0
            A[i,i-1] = 0
            continue

        # calculate parameters for housholder transformation

        H = 0
        for k in range(i):
            A[i,k] *= scale_inv
            rr = A[i,k].real
            ii = A[i,k].imag
            H += rr * rr + ii * ii

        F = A[i,i-1]
        f = abs(F)
        G = ctx.sqrt(H)
        A[i,i-1] = -G * scale

        if f == 0:
            T[i] = G
        else:
            ff = F / f
            T[i] = F + G * ff
            A[i,i-1] *= ff

        H += G * f
        H = 1 / ctx.sqrt(H)

        T[i] *= H
        for k in range(i - 1):
            A[i,k] *= H

        for j in range(i):
            # apply housholder transformation (from right)
            G = T[i].conjugate() * A[j,i-1]
            for k in range(i-1):
                G += A[i,k].conjugate() * A[j,k]

            A[j,i-1] -= G * T[i]
            for k in range(i-1):
                A[j,k] -= G * A[i,k]

        for j in range(n):
            # apply housholder transformation (from left)
            G = T[i] * A[i-1,j]
            for k in range(i-1):
                G += A[i,k] * A[k,j]

            A[i-1,j] -= G * T[i].conjugate()
            for k in range(i-1):
                A[k,j] -= G * A[i,k].conjugate()


def hessenberg_reduce_1(ctx, A, T):
    """
    This routine forms the unitary matrix Q described in hessenberg_reduce_0.

    parameters:
      A    (input/output) On input, A is the same matrix as delivered by
           hessenberg_reduce_0. On output, A is set to Q.

      T    (input) On input, T is the same array as delivered by hessenberg_reduce_0.
    """

    n = A.shape[0]

    if n == 1:
        A[0,0] = 1
        return

    A[0,0] = A[1,1] = 1
    A[0,1] = A[1,0] = 0

    for i in range(2, n):
        if T[i] != 0:
            for j in range(i):
                G = T[i] * A[i-1,j]
                for k in range(i-1):
                    G += A[i,k] * A[k,j]

                A[i-1,j] -= G * T[i].conjugate()
                for k in range(i-1):
                    A[k,j] -= G * A[i,k].conjugate()

        A[i,i] = 1
        for j in range(i):
            A[j,i] = A[i,j] = 0


def hessenberg(ctx, A, overwrite_a=False):
    """
    This routine computes the Hessenberg decomposition of a square matrix A.
    Given A, an unitary matrix Q is determined such that

          Q' A Q = H                and               Q' Q = Q Q' = 1

    where H is an upper right Hessenberg matrix. Here ' denotes the hermitian
    transpose (i.e. transposition and conjugation).

    input:
      A            : a real or complex square matrix
      overwrite_a  : if true, allows modification of A which may improve
                     performance. if false, A is not modified.

    output:
      Q : an unitary matrix
      H : an upper right Hessenberg matrix
    return value:   (Q, H)
    """

    n = A.shape[0]

    if n == 1:
        return (ones(ctx, (1, 1)), A)

    if not overwrite_a:
        A = A.copy()

    T = np.empty(n, dtype=A.dtype)
    hessenberg_reduce_0(ctx, A, T)
    # reconstruct the matrix Q in the Hessenberg reduction
    Q = A.copy()
    hessenberg_reduce_1(ctx, Q, T)

    for x in range(n):
        for y in range(x+2, n):
            A[y,x] = 0

    return Q, A


###########################################################################


def qr_step(ctx, n0, n1, A, Q, shift):
    """
    This subroutine executes a single implicitly shifted QR step applied to an
    upper Hessenberg matrix A. Given A and shift as input, first an QR
    decomposition is calculated:

      Q R = A - shift * 1 .

    The output is then following matrix:

      R Q + shift * 1

    parameters:
      n0, n1    (input) Two integers which specify the submatrix A[n0:n1,n0:n1]
                on which this subroutine operators. The subdiagonal elements
                to the left and below this submatrix must be deflated (i.e. zero).
                following restriction is imposed: n1>=n0+2
      A         (input/output) On input, A is an upper Hessenberg matrix.
                On output, A is replaced by "R Q + shift * 1"
      Q         (input/output) The parameter Q is multiplied by the unitary matrix
                Q arising from the QR decomposition. Q can also be None, in which
                case the unitary matrix Q is not computated.
      shift     (input) a complex number specifying the shift. idealy close to an
                eigenvalue of the bottemmost part of the submatrix A[n0:n1,n0:n1].

    references:
      Stoer, Bulirsch - Introduction to Numerical Analysis.
      Kresser : Numerical Methods for General and Structured Eigenvaluge Problems
    """
    # implicitly shifted and bulge chasing is explained at p.398/399 in "Stoer, Bulirsch - Introduction to Numerical Analysis"
    # for bulge chasing see also "Watkins - The Matrix Eigenvalue Problem" sec.4.5,p.173

    # the Givens rotation we used is determined as follows: let c,s be two complex
    # numbers. then we have following relation:
    #
    #     v = sqrt(|c|^2 + |s|^2)
    #
    #     1/v [ c~  s~]  [c] = [v]
    #         [-s   c ]  [s]   [0]
    #
    # the matrix on the left is our Givens rotation.

    n = A.shape[0]

    # first step

    # calculate givens rotation
    c = A[n0  ,n0] - shift
    s = A[n0+1,n0]
    v = ctx.hypot(ctx.hypot(c.real, c.imag), ctx.hypot(s.real, s.imag))

    if v == 0:
        v = 1
        c = 1
        s = 0
    else:
        c /= v
        s /= v

    cc = c.conjugate()
    cs = s.conjugate()

    for k in range(n0, n):
        # apply givens rotation from the left
        x = A[n0  ,k]
        y = A[n0+1,k]
        A[n0  ,k] = cc * x + cs * y
        A[n0+1,k] = c * y - s * x

    for k in range(min(n1, n0+3)):
        # apply givens rotation from the right
        x = A[k,n0  ]
        y = A[k,n0+1]
        A[k,n0  ] = c * x + s * y
        A[k,n0+1] = cc * y - cs * x

    if Q is not None:
        for k in range(n):
            # eigenvectors
            x = Q[k,n0  ]
            y = Q[k,n0+1]
            Q[k,n0  ] = c * x + s * y
            Q[k,n0+1] = cc * y - cs * x

    # chase the bulge

    for j in range(n0, n1 - 2):
        # calculate givens rotation
        c = A[j+1,j]
        s = A[j+2,j]
        v = ctx.hypot(ctx.hypot(c.real, c.imag), ctx.hypot(s.real, s.imag))

        if v == 0:
            A[j+1,j] = 0
            v = 1
            c = 1
            s = 0
        else:
            A[j+1,j] = v
            c /= v
            s /= v

        A[j+2,j] = 0

        cc = c.conjugate()
        cs = s.conjugate()

        for k in range(j+1, n):
            # apply givens rotation from the left
            x = A[j+1,k]
            y = A[j+2,k]
            A[j+1,k] = cc * x + cs * y
            A[j+2,k] = c * y - s * x

        for k in range(min(n1, j+4)):
            # apply givens rotation from the right
            x = A[k,j+1]
            y = A[k,j+2]
            A[k,j+1] = c * x + s * y
            A[k,j+2] = cc * y - cs * x

        if Q is not None:
            for k in range(n):
                # eigenvectors
                x = Q[k,j+1]
                y = Q[k,j+2]
                Q[k,j+1] = c * x + s * y
                Q[k,j+2] = cc * y - cs * x


def hessenberg_qr(ctx, A, Q):
    """
    This routine computes the Schur decomposition of an upper Hessenberg matrix A.
    Given A, an unitary matrix Q is determined such that

          Q' A Q = R                   and                  Q' Q = Q Q' = 1

    where R is an upper right triangular matrix. Here ' denotes the hermitian
    transpose (i.e. transposition and conjugation).

    parameters:
      A         (input/output) On input, A contains an upper Hessenberg matrix.
                On output, A is replace by the upper right triangluar matrix R.

      Q         (input/output) The parameter Q is multiplied by the unitary
                matrix Q arising from the Schur decomposition. Q can also be
                None, in which case the unitary matrix Q is not computated.
    """

    n = A.shape[0]

    norm = 0
    for x in range(n):
        for y in range(min(x+2, n)):
            norm += A[y,x].real ** 2 + A[y,x].imag ** 2
    norm = ctx.sqrt(norm) / n

    if norm == 0:
        return

    n0 = 0
    n1 = n

    #eps = ctx.epsilon() / (100 * n)
    eps = ctx.eps / (100 * n)

    #maxits = ctx.dps * 4   # old mpmath code
    #maxits = ctx.precision()
    maxits = ctx.prec

    its = totalits = 0

    while 1:
        # kressner p.32 algo 3
        # the active submatrix is A[n0:n1,n0:n1]
        k = n0

        while k + 1 < n1:
            s = abs(A[k,k].real) + abs(A[k,k].imag) + abs(A[k+1,k+1].real) + abs(A[k+1,k+1].imag)
            if s < eps * norm:
                s = norm
            if abs(A[k+1,k]) < eps * s:
                break
            k += 1

        if k + 1 < n1:
            # deflation found at position (k+1, k)
            A[k+1,k] = 0
            n0 = k + 1

            its = 0

            if n0 + 1 >= n1:
                # block of size at most two has converged
                n0 = 0
                n1 = k + 1
                if n1 < 2:
                    # QR algorithm has converged
                    return
        else:
            if (its % 30) == 10:
                # exceptional shift
                shift = A[n1-1,n1-2]
            elif (its % 30) == 20:
                # exceptional shift
                shift = abs(A[n1-1,n1-2])
            elif (its % 30) == 29:
                # exceptional shift
                shift = norm
            else:
                #    A = [ a b ]       det(x-A)=x*x-x*tr(A)+det(A)
                #        [ c d ]
                #
                # eigenvalues bad:   (tr(A)+sqrt((tr(A))**2-4*det(A)))/2
                #     bad because of cancellation if |c| is small and |a-d| is small, too.
                #
                # eigenvalues good:     (a+d+sqrt((a-d)**2+4*b*c))/2

                t =  A[n1-2,n1-2] + A[n1-1,n1-1]
                s = (A[n1-1,n1-1] - A[n1-2,n1-2]) ** 2 + 4 * A[n1-1,n1-2] * A[n1-2,n1-1]
                if s.real > 0:
                    s = ctx.sqrt(s)
                else:
                    s = ctx.sqrt(-s) * 1j
                a = (t + s) / 2
                b = (t - s) / 2
                if abs(A[n1-1,n1-1] - a) > abs(A[n1-1,n1-1] - b):
                    shift = b
                else:
                    shift = a

            its += 1
            totalits += 1

            qr_step(ctx, n0, n1, A, Q, shift)

            if its > maxits:
                raise RuntimeError("qr: failed to converge after %d steps" % its)


def schur(ctx, A, overwrite_a=False):
    """
    This routine computes the Schur decomposition of a square matrix A.
    Given A, an unitary matrix Q is determined such that

          Q' A Q = R                and               Q' Q = Q Q' = 1

    where R is an upper right triangular matrix. Here ' denotes the
    hermitian transpose (i.e. transposition and conjugation).

    input:
      A            : a real or complex square matrix
      overwrite_a  : if true, allows modification of A which may improve
                     performance. if false, A is not modified.

    output:
      Q : an unitary matrix
      R : an upper right triangular matrix

    return value:   (Q, R)
    warning: The Schur decomposition is not unique.
    """

    n = A.shape[0]

    if n == 1:
        return (ones(ctx, (1, 1)), A)

    if not overwrite_a:
        A = A.copy()

    T = np.empty(n, dtype=A.dtype)
    hessenberg_reduce_0(ctx, A, T)
    Q = A.copy()
    hessenberg_reduce_1(ctx, Q, T)

    for x in range(n):
        for y in range(x + 2, n):
            A[y,x] = 0

    hessenberg_qr(ctx, A, Q)

    return Q, A


def eig_tr_r(ctx, A):
    """
    This routine calculates the right eigenvectors of an upper right triangular matrix.

    input:
      A      an upper right triangular matrix

    output:
      ER     a matrix whose columns form the right eigenvectors of A

    return value: ER
    """
    # this subroutine is inspired by the lapack routines ctrevc.f,clatrs.f
    n = A.shape[0]
    ER = eye(ctx, n)
    #eps = ctx.epsilon()
    eps = ctx.eps

    # since mpmath effectively has no limits on the exponent, we simply scale doubles up
    # original double has prec*20
    #unfl = ctx.ldexp(ctx.mpf(1), -ctx.precision() * 30)
    unfl = ctx.ldexp(ctx.mpf(1), -ctx.prec * 30)
    smlnum = unfl * (n / eps)
    simin = 1 / ctx.sqrt(eps)

    rmax = 1

    for i in range(1, n):
        s = A[i,i]
        smin = max(eps * abs(s), smlnum)

        for j in range(i - 1, -1, -1):
            r = 0
            for k in range(j + 1, i + 1):
                r += A[j,k] * ER[k,i]

            t = A[j,j] - s
            if abs(t) < smin:
                t = smin

            r = -r / t
            ER[j,i] = r

            rmax = max(rmax, abs(r))
            if rmax > simin:
                for k in range(j, i + 1):
                    ER[k,i] /= rmax
                rmax = 1

        if rmax != 1:
            for k in range(i + 1):
                ER[k,i] /= rmax

    return ER

def eig_tr_l(ctx, A):
    """
    This routine calculates the left eigenvectors of an upper right triangular matrix.

    input:
      A      an upper right triangular matrix

    output:
      EL     a matrix whose rows form the left eigenvectors of A

    return value:  EL
    """
    n = A.shape[0]
    EL = eye(ctx, n)
    #eps = ctx.epsilon()
    eps = ctx.eps

    # since mpmath effectively has no limits on the exponent, we simply scale doubles up
    # original double has prec*20
    #unfl = ctx.ldexp(ctx.mpf(1), -ctx.precision() * 30)
    unfl = ctx.ldexp(ctx.mpf(1), -ctx.prec * 30)
    smlnum = unfl * (n / eps)
    simin = 1 / ctx.sqrt(eps)

    rmax = 1

    for i in range(n - 1):
        s = A[i,i]
        smin = max(eps * abs(s), smlnum)

        for j in range(i + 1, n):
            r = 0
            for k in range(i, j):
                r += EL[i,k] * A[k,j]

            t = A[j,j] - s
            if abs(t) < smin:
                t = smin

            r = -r / t
            EL[i,j] = r

            rmax = max(rmax, abs(r))
            if rmax > simin:
                for k in range(i, j + 1):
                    EL[i,k] /= rmax
                rmax = 1

        if rmax != 1:
            for k in range(i, n):
                EL[i,k] /= rmax

    return EL


def eig(ctx, A, left=False, right=True, overwrite_a=False):
    """
    This routine computes the eigenvalues and optionally the left and right
    eigenvectors of a square matrix A. Given A, a vector E and matrices ER
    and EL are calculated such that

                        A ER[:,i] =         E[i] ER[:,i]
                EL[i,:] A         = EL[i,:] E[i]

    E contains the eigenvalues of A. The columns of ER contain the right eigenvectors
    of A whereas the rows of EL contain the left eigenvectors.

    input:
      A           : a real or complex square matrix of shape (n, n)
      left        : if true, the left eigenvectors are calulated.
      right       : if true, the right eigenvectors are calculated.
      overwrite_a : if true, allows modification of A which may improve
                    performance. if false, A is not modified.

    output:
      E    : a list of length n containing the eigenvalues of A.
      ER   : a matrix whose columns contain the right eigenvectors of A.
      EL   : a matrix whose rows contain the left eigenvectors of A.

    return values:
       E            if left and right are both false.
      (E, ER)       if right is true and left is false.
      (E, EL)       if left is true and right is false.
      (E, EL, ER)   if left and right are true.

    warning:
     - If there are multiple eigenvalues, the eigenvectors do not necessarily
       span the whole vectorspace, i.e. ER and EL may have not full rank.
       Furthermore in that case the eigenvectors are numerical ill-conditioned.
     - In the general case the eigenvalues have no natural order.

    see also:
      - eigh (or eigsy, eighe) for the symmetric eigenvalue problem.
    """

    n = A.shape[0]

    if n == 1:
        if left and (not right):
            return ([A[0]], ones(ctx, (1, 1)))

        if right and (not left):
            return ([A[0]], ones(ctx, (1, 1)))

        return ([A[0]], ones(ctx, (1, 1)), ones(ctx, (1, 1)))

    if not overwrite_a:
        A = A.copy()

    T = np.empty(n, dtype=A.dtype)
    hessenberg_reduce_0(ctx, A, T)

    if left or right:
        # reconstruct the matrix Q in the Hessenberg reduction
        Q = A.copy()
        hessenberg_reduce_1(ctx, Q, T)
    else:
        Q = None

    for x in range(n):
        for y in range(x + 2, n):
            A[y,x] = 0

    hessenberg_qr(ctx, A, Q)

    E = np.diag(A)

    if not (left or right):
        return E

    result = (E,)

    if left:
        EL = eig_tr_l(ctx, A) @ Q.T.conj()
        result = result + (EL,)

    if right:
        ER = Q @ eig_tr_r(ctx, A)
        result = result + (ER,)

    return result


##############################################################



def _exp_pade(ctx, a):
    """
    Exponential of a matrix using Pade approximants.
    See G. H. Golub, C. F. van Loan 'Matrix Computations',
    third Ed., page 572
    """
    def eps_pade(p):
        return ctx.mpf(2)**(3-2*p) * \
            ctx.factorial(p)**2/(ctx.factorial(2*p)**2 * (2*p + 1))
    q = 4
    extraq = 8
    while 1:
        if eps_pade(q) < ctx.eps:
            break
        q += 1
    q += extraq
    j = int(max(1, ctx.mag(mnorm(ctx, a,'inf'))))
    extra = q
    prec = ctx.prec
    ctx.dps += extra + 3
    try:
        a = a/2**j
        na = rows(ctx, a)
        den = eye(ctx, na)
        num = eye(ctx, na)
        x = eye(ctx, na)
        c = ctx.mpf(1)
        print("q:", q)
        for k in range(1, q+1):
            c *= ctx.mpf(q - k + 1)/((2*q - k + 1) * k)
            #print("type(c):", type(c))
            x = a @ x
            #print("type(x[0,0]:", type(x[0,0]))
            cx = c*x
            #print("type(num[0,0]:", type(num[0,0]))
            num += cx    # error
            den += (-1)**k * cx
        f = lu_solve(ctx, den, num)
        for k in range(j):
            f = f @ f
    finally:
        ctx.prec = prec
    return f*1

def expm(ctx, A, method='taylor'):
    r"""
    Computes the matrix exponential of a square matrix `A`.
    With method='taylor', the matrix exponential is computed
    using the Taylor series. With method='pade', Pade approximants
    are used instead.
    """

    A = to_mp(ctx, A)
    r = rows(ctx, A)
    if method == 'pade':
        prec = ctx.prec
        try:
            ctx.prec += 2*r
            res = _exp_pade(ctx, A)
        finally:
            ctx.prec = prec
        return res

    prec = ctx.prec
    j = int(max(1, ctx.mag(mnorm(ctx, A,'inf'))))
    j += int(0.5*prec**0.5)

    try:
        ctx.prec += 10 + 2*j
        tol = +ctx.eps
        A = A/2**j
        T = +A
        Y = eye(ctx, r) + A
        k = 2
        while 1:
            T = T @ A * (1/ctx.mpf(k))
            if mnorm(ctx, T, 'inf') < tol:
                break
            Y += T
            k += 1
        for k in range(j):
            Y = Y @ Y
    finally:
        ctx.prec = prec
    Y *= 1
    return Y

def cosm(ctx, A):
    r"""
    Gives the cosine of a square matrix `A`, defined in analogy
    with the matrix exponential.
    """
    A = to_mp(ctx, A)
    B = (expm(ctx, A*ctx.j) + expm(ctx, A*(-ctx.j))) / 2
    #C = np.real_if_close(B)  # does not work
    #C = np.real(B)  # does not work

##    if not sum(A.apply(ctx.im).apply(abs)):
##        B = B.apply(ctx.re)
    return B

def sinm(ctx, A):
    r"""
    Gives the sine of a square matrix `A`, defined in analogy
    with the matrix exponential.
    """
    A = to_mp(ctx, A)
    #c = ctx.convert(-0.5j)
    c = ctx.convert(-0.5)
    print("c:", c, type(c))
    B = (expm(ctx, A*ctx.j) - expm(ctx, A*(-ctx.j))) * c * ctx.t(1j)
##    if not sum(A.apply(ctx.im).apply(abs)):
##        B = B.apply(ctx.re)
    return B


def _sqrtm_rot(ctx, A, _may_rotate):
    u = ctx.j** ctx.convert('0.3')
    return sqrtm(ctx, A*u, _may_rotate) / ctx.sqrt(u)

def sqrtm(ctx, A, _may_rotate=2):
    r"""
    Computes a square root of the square matrix `A`, i.e. returns
    a matrix `B = A^{1/2}` such that `B^2 = A`. The square root
    of a matrix, if it exists, is not unique.
    """
    A = to_mp(ctx, A)
    # Trivial
    if np.array_equal(A*0, A):
        return A
    prec = ctx.prec
    if _may_rotate:
        d = det(ctx, A)
        if abs(ctx.im(d)) < 16*ctx.eps and ctx.re(d) < 0:
            return _sqrtm_rot(ctx, A, _may_rotate-1)
    try:
        ctx.prec += 10
        tol = ctx.eps * 128
        Y = A
        r = rows(ctx, A)
        Z = I = eye(ctx, r)

        k = 0
        # Denman-Beavers iteration
        while 1:
            Yprev = Y
            try:
                Y, Z = (Y+inverse(ctx, Z))/2, (Z+inverse(ctx, Y))/2
            except ZeroDivisionError:
                if _may_rotate:
                    Y = _sqrtm_rot(ctx, A, _may_rotate-1)
                    break
                else:
                    raise
            mag1 = mnorm(ctx, Y-Yprev, 'inf')
            mag2 = mnorm(ctx, Y, 'inf')
            if mag1 <= mag2*tol:
                break
            if _may_rotate and k > 6 and not mag1 < mag2 /1000:
                return _sqrtm_rot(ctx, A, _may_rotate-1)
            k += 1
            if k > ctx.prec:
                raise ctx.NoConvergence
    finally:
        ctx.prec = prec
    Y *= 1
    return Y

def logm(ctx, A):
    r"""
    Computes a logarithm of the square matrix `A`, i.e. returns
    a matrix `B = \log(A)` such that `\exp(B) = A`. The logarithm
    of a matrix, if it exists, is not unique.
    """
    A = to_mp(ctx, A)
    r = rows(ctx, A)
    prec = ctx.prec
    try:
        ctx.prec += 10
        tol = ctx.eps * 128
        I = eye(ctx, r)
        B = A
        n = 0
        while 1:
            B = sqrtm(ctx, B)
            n += 1
            if mnorm(ctx, B-I, 'inf') < 0.125:
                break
        T = X = B-I
        L = X*0
        k = 1
        while 1:
            if k & 1:
                L += T / k
            else:
                L -= T / k
            T = T @ X
            if mnorm(ctx, T, 'inf') < tol:
                break
            k += 1
            if k > ctx.prec:
                raise ctx.NoConvergence
    finally:
        ctx.prec = prec
    L *= 2**n
    return L

def powm(ctx, A, r):
    r"""
    Computes `A^r = \exp(A \log r)` for a matrix `A` and complex
    number `r`.
    """
    A = to_mp(ctx, A)
    r = ctx.convert(r)
    prec = ctx.prec
    try:
        ctx.prec += 10
        if ctx.isint(r):
            #v = A ** int(r)
            v = matrix_power(ctx, A, int(r))

        elif ctx.isint(r*2):
            y = int(r*2)
            #v = ctx.sqrtm(A) ** y
            v = sqrtm(ctx, A)
            v = matrix_power(ctx, v, y)
        else:
            #v = ctx.expm(ctx.logm(A)*r)
            v = expm(ctx, logm(ctx, A)*r)
    finally:
        ctx.prec = prec
    v *= 1
    return v


def balance_matrix(ctx, A):
    # https://arxiv.org/pdf/1401.5766.pdf (Algorithm #3)
    # https://de.mathworks.com/help/matlab/ref/balance.html
    Aprime = to_mp(ctx, A)
    p = ctx.convert(2)
    beta = ctx.convert(2)
    n = rows(ctx, Aprime)
    D = eye(ctx, n)
    converged = False
    while (converged == False):
        converged = True
        for i in range(n):
            c = vector_norm(ctx, Aprime[:, i])
            r = vector_norm(ctx, Aprime[i, :])
            s = ctx.pow(c, p) + ctx.pow(r, p)
            f = ctx.convert(1)
            while (c < r / beta):
                c *= beta
                r /= beta
                f *= beta
            while (c >= r * beta):
                c /= beta
                r *= beta
                f /= beta
            if (pow(c, p) + pow(r, p) < (95 * s / 100)):
                converged = False
                D[i, i] *= f
                Aprime[:, i] *= f
                Aprime[i, :] /= f
    return Aprime, D




def jacobi_c(ctx, f, params, x):
    params = to_mp(ctx, params)
    x = to_mp(ctx, x)
    h = ctx.convert(1.0e-30)
    n = len(params)
    J = empty(ctx, shape = (n,)+x.shape)
    for i in range(n):
        p = []
        for j in range(n):
            if (i==j): p.append(params[j] + h*ctx.t(1j))
            else: p.append(params[j])
        J[i] = (1/h) * to_mp_imag(ctx, f(ctx, p, x))
    return J





##def levenberg_marquardt_c(ctx, f0, params, x, y,
##       tau = 1e-2, eps1 = 1e-6, eps2 = 1e-6, kmax = 20,
##       verbose = False, full_output = False):
def levenberg_marquardt_c(ctx, f0, params, x, y,
       tau = 1e-4, eps1 = 1e-12, eps2 = 1e-12, kmax = 20,
       verbose = False, full_output = False):
    """
    Implementation of the Levenberg-Marquardt algorithm in pure
    Python. Solves the normal equations.
    """
    p = to_mp(ctx, params)
    x = to_mp(ctx, x)
    y = to_mp(ctx, y)

    tau = ctx.convert(tau)
    eps1 = ctx.convert(eps1)
    eps2 = ctx.convert(eps2)

    f = f0(ctx, p, x) - y
    J = jacobi_c(ctx, f0, p, x)

    A = np.inner(J,J)
    g = np.inner(J,f)

    I = eye(ctx, len(p))

    k = 0; nu = 2
    mu = tau * max(np.diag(A))
    stop = norm(ctx, g, ctx.inf) < eps1
    while not stop and k < kmax:
        k += 1

        try:
            d = lu_solve(ctx, A + mu*I, -g)
        except np.linalg.LinAlgError:
            print ("Singular matrix encountered in LM")
            stop = True
            reason = 'singular matrix'
            break

        if norm(ctx, d) < eps2*(norm(ctx, p) + eps2):
            stop = True
            reason = 'small step'
            break

        pnew = p + d
        fnew = f0(ctx, pnew, x) - y
        Jnew = jacobi_c(ctx, f0, pnew, x)

        rho = (norm(ctx, f)**2 - norm(ctx, fnew)**2)/np.inner(d, mu*d - g)

        if rho > 0:
            p = pnew
            A = np.inner(Jnew, Jnew)
            g = np.inner(Jnew, fnew)
            f = fnew
            J = Jnew
            if (norm(ctx, g, ctx.inf) < eps1): # or norm(ctx, fnew) < eps3):
                stop = True
                reason = "small gradient"
                break
            mu = mu * max([ctx.t(1)/3, ctx.t(1) - (2*rho - 1)**3])
            nu = ctx.t(2)
        else:
            mu = mu * nu
            nu = 2*nu

        if verbose:
            print ("step %2d: |f|: %9.6g mu: %8.3g rho: %8.3g"%(k, norm(ctx, f), mu, rho))

    else:
        reason = "max iter reached"

    if verbose:
        print (reason)

    if not full_output:
        return p
    else:
        return p, J, f







def gradient_c(ctx, f, x):
    x = to_mp(ctx, x)
    h = ctx.convert(1.0e-30)
    n = len(x)
    nabla = zeros(ctx, n)
    for i in range(n):
        p = []
        for j in range(n):
            if (i==j): p.append(x[j] + h*ctx.t(1j))
            else: p.append(x[j])
        nabla[i] = (1/h) * to_mp_imag(ctx, f(ctx, p))
    return nabla





def line_search(ctx, f, x, p, nabla):
    '''
    BACKTRACK LINE SEARCH WITH WOLFE CONDITIONS
    '''
    a = ctx.t(1)
    c1 = ctx.t(1e-4)
    c2 = ctx.t(0.9)
    fx = f(ctx, x)
    x_new = x + a * p
    nabla_new = gradient_c(ctx, f, x_new)
    while f(ctx, x_new) >= fx + (c1*a*nabla.T@p) or nabla_new.T@p <= c2*nabla.T@p :
        a = a * ctx.t(0.9)
        x_new = x + a * p
        nabla_new = gradient_c(ctx, f, x_new)
    return a





def bfgs_c(ctx, f, x0, max_it):
    '''
    DESCRIPTION
    BFGS Quasi-Newton Method, implemented as described in Nocedal:
    Numerical Optimisation.
    INPUTS:
    f:      function to be optimised
    x0:     intial guess
    max_it: maximum iterations
    plot:   if the problem is 2 dimensional, returns
            a trajectory plot of the optimisation scheme.
    OUTPUTS:
    x:      the optimal solution of the function f
    '''
    x0 = to_mp(ctx, x0)
    d = len(x0) # dimension of problem
    nabla = gradient_c(ctx, f, x0) # initial gradient
    H = eye(ctx, d) # initial hessian
    x = x0[:]
    it = 2
    x_store =  np.array([np.zeros(d)])

    while norm(ctx, nabla) > 1e-5: # while gradient is positive
    #while norm(ctx, nabla) > 1e-20: # while gradient is positive
        if it > max_it:
            print('Maximum iterations reached!')
            break
        it += 1
        #print("it:", it)
        p = -H@nabla # search direction (Newton Method)
        a = line_search(ctx, f, x,p , nabla) # line search
        s = a * p
        x_new = x + a * p
        nabla_new = gradient_c(ctx, f, x_new)
        y = nabla_new - nabla
        y = np.array([y])
        s = np.array([s])
        y = np.reshape(y,(d,1))
        s = np.reshape(s,(d,1))
        r = 1/(y.T@s)
        li = (eye(ctx, d)-(r*((s@(y.T))))) #updating matrix of H_k left side
        ri = (eye(ctx, d)-(r*((y@(s.T))))) #updating matrix of H_k right side
        hess_inter = li@H@ri
        H = hess_inter + (r*((s@(s.T)))) # BFGS Update
        nabla = nabla_new[:]
        x = x_new[:]
        x_store = np.append(x_store, [x_new], axis = 0)

    return x, x_store





def recursion_two_loop(ctx, gradient, s_stored, y_stored, m):
    q = gradient
    length = len(q)
    a = zeros(ctx, m)
    rou = np.array([1/np.dot(y_stored[j, :], s_stored[j, :]) for j in range(m)])
    for i in range(m):
        a[m - 1 - i] = rou[m - 1 - i] * np.dot(s_stored[m - 1 - i, :], q)
        q = q - a[m - 1 - i]*y_stored[m - 1 - i, :]

    H_k0 = (np.dot(s_stored[m - 1], y_stored[m - 1])/np.dot(y_stored[m - 1], y_stored[m - 1]))
    r = H_k0 * q

    for i in range(m):
        beta = rou[i] * np.dot(y_stored[i, :], r)
        r = r + (a[i] - beta) * s_stored[i]
    return r




def lbfgs_c(ctx, f, x0, max_it, m):
    '''
    INPUTS:
    f:      function to be optimised
    x0:     intial guess
    max_it: maximum iterations
    OUTPUTS:
    x:      the optimal solution of the function f
    '''
    x0 = to_mp(ctx, x0)
    d = len(x0) # dimension of problem
    nabla = gradient_c(ctx, f, x0) # initial gradient
    x = x0[:]
    x_store = np.array([x0])

    '''
    Store the {y_i, s_i}
    '''
    y_stored = []
    s_stored = []
    p = - nabla
    alpha = line_search(ctx, f, x, p, nabla)
    s_stored.append(alpha * p)
    grad_old = nabla[:]
    x = x + alpha * p
    nabla = gradient_c(ctx, f, x)
    y_stored.append(nabla - grad_old)
    m_ = 1
    it = 1
    x_store = np.append(x_store, [x], axis = 0)

    while norm(ctx, nabla) > 1e-5: # while gradient is positive
    #while norm(ctx, nabla) > 1e-20: # while gradient is positive
        #print("it:", it)
        if it > max_it:
            print('Maximum iterations reached!')
            break

        if 0 < it and it < m :
            p = - recursion_two_loop(ctx, nabla, np.array(s_stored), np.array(y_stored), m_)
            alpha = line_search(ctx, f, x, p, nabla)
            s_stored.append(alpha * p)
            grad_old = nabla[:]
            x = x + alpha * p
            nabla = gradient_c(ctx, f, x)
            y_stored.append(nabla - grad_old)
            m_ = m_ + 1
            it = it + 1
            x_store = np.append(x_store, [x], axis = 0)

        else:
            p = - recursion_two_loop(ctx, nabla, np.array(s_stored), np.array(y_stored), m)
            alpha = line_search(ctx, f, x, p, nabla)

            #append the s_k+1
            s_stored.append(alpha * p)

            #discard the s_(k-m)
            s_stored.pop(0)
            grad_old = nabla[:]
            x = x + alpha * p
            nabla = gradient_c(ctx, f, x)

            #append the y_k+1
            y_stored.append(nabla - grad_old)

            #discard the y_k-m
            y_stored.pop(0)
            it = it + 1

            x_store = np.append(x_store, [x], axis = 0)

    return x, x_store





def ldl_golub_and_van_loan(ctx, A):
    A = to_mp(ctx, A)
    #print("A:", A)
    n = rows(ctx, A)
    #print("n:", n)
    v = zeros(ctx, (n))
    #print("v:", v)
    for j in range(n):
        for i in range(j):
            v[i] = A[j,i] * A[i,i]
        v[j] = A[j,j]
        for i in range(j):
            v[j] = v[j] - A[j,i] * v[i]
        if v[j] <= 0:
            print("Error: v[j] <= 0")
            return
        A[j,j] = v[j]
        for i in range(j+1, n):
            for k in range(j):
                A[i,j] = A[i,j] - A[i,k] * v[k]
            A[i,j] = A[i,j] / v[j]
    A = ctx.t(1) * np.tril(A)
    #A = npm.tril(A)
    return A



def inv_ldl_precomp(ctx, L):
    L = to_mp(ctx, L)
    #print("L:", L)
    n = rows(ctx, L)
    #print("n:", n)
    s = zeros(ctx, (n))
    #print("s:", s)
    X = zeros(ctx, (n, n))
    #print("X:", X)
    for i in range(n):
        s[i] = 1/L[i,i]
    for j in range(n-1, -1, -1):
        for i in range(j, -1, -1):
            #print(i, j)
            if (i == j):
                X[i,j] = s[i]
            else:
                X[i,j] = ctx.t(0)
            for k in range(i+1, n):
                X[i,j] = X[i,j] - L[k,i] * X[k,j]
            X[j,i] = X[i,j]
    return X



def solve_ldl_precomp(ctx, L, B):
    L = to_mp(ctx, L)
    #print("L:", L)
    B = to_mp(ctx, B)
    #print("B:", B)
    n = rows(ctx, B)
    #print("n:", n)
    m = cols(ctx, B)
    #print("m:", m)
    X = +B
    #print("X:", X)

    for c in range(m):
    # solve Lz = b
        for i in range(n):
            for j in range(i):
                X[i,c] = X[i,c] - L[i,j] * X[j,c]
    # solve Dy = z
        for i in range(n):
            X[i,c] = X[i,c] / L[i,i]
    # solve Ux = y
        for i in range(n-1, -1, -1):
            for j in range(i+1, n):
                X[i,c] = X[i,c] - L[j,i] * X[j,c]
    return X



def ldl_solve(ctx, A, b):
    L = ldl_golub_and_van_loan(ctx, A)
    X = solve_ldl_precomp(ctx, L, b)
    return X




