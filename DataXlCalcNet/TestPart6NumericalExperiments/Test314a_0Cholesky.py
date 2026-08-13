# -*- coding: utf-8 -*-
"""
Spyder Editor


"""



import time

from copy import copy


from xlcalcnet import fp, gp, mp

def L_solve_old(L, b, p=None):
    """
    Solve the lower part of a LU factorized matrix for y.
    """
    if L.rows != L.cols:
        raise RuntimeError("need n*n matrix")
    n = L.rows
    if len(b) != n:
        raise ValueError("Value should be equal to n")
    b = copy(b)
    if p: # swap b according to p
        for k in range(0, len(p)):
            fp.swap_row(b, k, p[k])
    # solve
    for i in range(1, n):
        for j in range(i):
            b[i] -= L[i,j] * b[j]
    return b


def U_solve_old(U, y):
    """
    Solve the upper part of a LU factorized matrix for x.
    """
    if U.rows != U.cols:
        raise RuntimeError("need n*n matrix")
    n = U.rows
    if len(y) != n:
        raise ValueError("Value should be equal to n")
    x = copy(y)
    for i in range(n - 1, -1, -1):
        for j in range(i + 1, n):
            x[i] -= U[i,j] * x[j]
        x[i] /= U[i,i]
    return x


def cholesky_solve_old(A, b, **kwargs):
    prec = fp.prec
    try:
        fp.prec += 10
        # do not overwrite A nor b
        A, b = fp.matrix(A, **kwargs).copy(), fp.matrix(b, **kwargs).copy()
        if A.rows !=  A.cols:
            raise ValueError('can only solve determined system')
        # Cholesky factorization
        L = fp.cholesky(A)
        # solve
        n = L.rows
        if len(b) != n:
            raise ValueError("Value should be equal to n")
        for i in range(n):
            b[i] -= fp.fsum(L[i,j] * b[j] for j in range(i))
            b[i] /= L[i,i]
        x = fp.U_solve(L.T, b)
        return x
    finally:
        fp.prec = prec



def cholesky_old(A, tol=None):
#    if not isinstance(A, ctx.matrix):
#        raise RuntimeError("A should be a type of ctx.matrix")
#    if not A.rows == A.cols:
#        raise ValueError('need n*n matrix')
    if tol is None:
        tol = +fp.eps
    n = A.rows
    L = fp.matrix(n)
    for j in range(n):
        c = fp.re(A[j,j])
        if abs(c-A[j,j]) > tol:
            raise ValueError('matrix is not Hermitian')
        s = c - fp.fsum((L[j,k] for k in range(j)),
            absolute=True, squared=True)
        if s < tol:
            raise ValueError('matrix is not positive-definite')
        L[j,j] = fp.sqrt(s)
        for i in range(j, n):
            it1 = (L[i,k] for k in range(j))
            it2 = (L[j,k] for k in range(j))
            t = fp.fdot(it1, it2, conjugate=True)
            L[i,j] = (A[i,j] - t) / L[j,j]
    return L



def cholesky_new(A, tol=None):
#    if not isinstance(A, ctx.matrix):
#        raise RuntimeError("A should be a type of ctx.matrix")
#    if not A.rows == A.cols:
#        raise ValueError('need n*n matrix')
    if tol is None:
        tol = +fp.eps
    #n = A.rows
    n = len(A)
    #L = fp.matrix(n)
    L = [[0 for col in range(n)] for row in range(n)]
    for j in range(n):
        c = fp.re(A[j][j])
        if abs(c-A[j][j]) > tol:
            raise ValueError('matrix is not Hermitian')
        s = c - fp.fsum((L[j][k] for k in range(j)),
            absolute=True, squared=True)
        if s < tol:
            raise ValueError('matrix is not positive-definite')
        L[j][j] = fp.sqrt(s)
        for i in range(j, n):
            it1 = (L[i][k] for k in range(j))
            it2 = (L[j][k] for k in range(j))
            t = fp.fdot(it1, it2, conjugate=True)
            L[i][j] = (A[i][j] - t) / L[j][j]
    return L


def cholesky_new2(A, tol=None):
#    if not isinstance(A, ctx.matrix):
#        raise RuntimeError("A should be a type of ctx.matrix")
#    if not A.rows == A.cols:
#        raise ValueError('need n*n matrix')
    if tol is None:
        tol = +fp.eps
    n = len(A)
    L = [[0 for col in range(n)] for row in range(n)]
    for j in range(n):
        c = fp.re(A[j][j])
        if abs(c-A[j][j]) > tol:
            raise ValueError('matrix is not Hermitian')
        s = c - fp.fsum((L[j][k] for k in range(j)),
            absolute=True, squared=True)
        if s < tol:
            raise ValueError('matrix is not positive-definite')
        L[j][j] = fp.sqrt(s)
        for i in range(j, n):
            t = 0.0
            for k in range(j):
                t += L[i][k] * L[j][k]
            L[i][j] = (A[i][j] - t) / L[j][j]
    return L


n=50

A = fp.eye(n) + fp.hilbert(n)
b = fp.randmatrix(n,1)
#print(A)
#print()

start1 = time.time()
L = fp.cholesky(A)
end1 = time.time()
Elapsed1 = end1 - start1

print ("Elapsed1 : ", Elapsed1)
#print(L)
#print()
start1a = time.time()
x = cholesky_solve_old(A, b)
end1a = time.time()
Elapsed1a = end1a - start1a
print ("Elapsed1a: ", Elapsed1a)

#print(x)
#print("A*x-b")
#print(A*x-b)
#print()


start2 = time.time()
L_old = cholesky_old(A)
end2 = time.time()
Elapsed2 = end2 - start2
print ("Elapsed2 : ", Elapsed2)
#print(L_old)
print()

AList = A.tolist()
#print(AList)
start3 = time.time()
L_new = cholesky_new(AList)
end3 = time.time()
Elapsed3 = end3 - start3
print ("Elapsed3 : ", Elapsed3)

#print(L_new)
print()

start4 = time.time()
L_new2 = cholesky_new2(AList)
end4 = time.time()
Elapsed4 = end4 - start4
print ("Elapsed4 : ", Elapsed4)
if Elapsed4 > 0:
    print ("Ratio Elapsed1/Elapsed4: ", Elapsed1/Elapsed4)

#print(L_new2)
print()
























