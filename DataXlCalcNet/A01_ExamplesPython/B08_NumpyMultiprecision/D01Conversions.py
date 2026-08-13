# -*- coding: utf-8 -*-

### Note: the arb data type is not supported for these functions

from xlcalcnet import gpm, mpm, dpm, fpm, ipm #, apm
import sqlite3



### 14 Matrices as dictionaries

class test14():



    def sqlite3_read_mat(self, ctx, dbpath, TName):
        conn = sqlite3.connect(dbpath)
        c = conn.cursor()
        c.execute("SELECT row, col, mpformula_value_re FROM " + TName)
        datalist =c.fetchall()
        conn.close()
        maxrow = 0; maxcol = 0;
        for item in datalist:
            if item[0] > maxrow: maxrow = item[0]
            if item[1] > maxcol: maxcol = item[1]
        matA =  ctx.mat_zeros(maxrow  + 1, maxcol + 1)
        for item in datalist:
            i = item[0]; j = item[1];
            value = item[2]
            matA[i,j] = value
        return matA



    def demo_sqlite3_read_mat(self, ctx):
        dbpath = r"C:\Extra\mpFormulaTDM\Data\WriteData.db3"
        TName = "DblTable16"
        matA = self.sqlite3_read_mat(ctx, dbpath, TName)
        print("Datatable: ", TName)
        print("rows:", matA.rows)
        print("cols:", matA.cols)
        for i in range(matA.rows):
            for j in range(matA.cols):
                print("matA[" + str(i) + ", " + str(j) + "]:", repr(matA[i,j]))






    def sqlite3_write_mat(self, ctx, dbpath, TName, matA):
        conn = sqlite3.connect(dbpath)
        c = conn.cursor()
        statement = "DROP TABLE IF EXISTS " + TName
        c.execute(statement)
        statement = ("CREATE TABLE " + TName
                    + "(id INTEGER PRIMARY KEY, row INTEGER, col INTEGER, "
                    + "stdvalue_re TEXT, stdvalue_im TEXT, mptype TEXT, "
                    + "mpformula_value_re TEXT, mpformula_value_im TEXT)");
        c.execute(statement)
        datalist = []
        id1 = 0
        for i in range(0, matA.rows):
            for j in range(0, matA.cols):
                id1 = id1 + 1
                svalue = str(matA.data[i][j])
                record = (id1, i, j, '', '', 'dbl_t',  svalue, '')
                datalist.append(record)
        c.executemany("INSERT INTO " + TName + " VALUES (?,?,?,?,?,?,?,?)", datalist)
        conn.commit()
        conn.close()




# %%  14.1 Basic methods



    def demo_matrix_creation_real(self, ctx):
        print()
        print("demo_matrix_creation_real")

    # 4.1.1 Creating a matrix as a dictionary (real mpmath matrix)

        #ctx.dps = 15
        A = ctx.matrix(2)
        print("A = ctx.matrix(2): \n", A)
        print()

        A = ctx.matrix(2,3)
        print("A = ctx.matrix(2,3): \n", A)
        print()

        A = ctx.matrix(3,2)
        print("A = ctx.matrix(3,2): \n", A)
        print()


        D = ctx.diag([1,2,3,4])
        print("D = ctx.diag([1,2,3,4]): \n", D)
        print()


    def demo_matrix_creation_complex(self, ctx):
        print()
        print("demo_matrix_creation_complex")

    # 4.1.1 Creating a matrix as a dictionary (complex mpmath matrix)

        #ctx.dps = 15
        a = 1+1j
        b = 2+2j
        c = 3+3j
        d = 4+4j

        a = 1+0j
        b = 2+2j
        c = 3+0j
        d = 4+4j

        res1 = a*b
        print("res1 = a*b:", res1)

        A = ctx.matrix([a,b,c,d])
        print("A = ctx.matrix([a,b,c,d]): \n", A)
        print()

        A = ctx.matrix([[a,b],[c,d]])
        print("A = ctx.matrix([[a,b],[c,d]]): \n", A)
        print()

        B = A + A
        print("B = A + A: \n", B)
        print()

        C = B * A * 1j
        print("C = B * A: \n", C)
        print()

#        D = ctx.diag([1+1j,2+2j,3+3j,4+4j])
#        print("D = ctx.diag([1+1j,2+2j,3+3j,4+4j]): \n", D)
#        print()


    def demo_matrix_methods(self, ctx):
        print("demo_matrix_methods")

    #    Methods of a mpmath matrix
        A = ctx.randmatrix(2,3)
        print("A:: \n", A)
        print("A.rows", A.rows)
        print("A.cols", A.cols)
        print()

        A.rows=5
        A.cols=3
        print("A: (after A.rows=5, A.cols=3 \n", A)
        print()

        A = ctx.randmatrix(2,3)
        print("A:: \n", A)
        print("A.rows", A.rows)
        print("A.cols", A.cols)
        print()


        B = A.transpose()  # shortcut is A.T
        print("B = A.transpose(): \n", B)
        print()

        B = A.conjugate()
        print("B = A.conjugate(): \n", B)
        print()

        B = A.transpose_conj()  # shortcut is A.H
        print("B = A.transpose_conj(): \n", B)
        print()

        D = A.copy()
        print("D = A.copy(): \n", D)
        print()

        D = A.column(1)
        print("D = A.column(1): \n", D)
        print()


        C =ctx.randmatrix(2,1)
        print("C =ctx.randmatrix(2,1): \n", C)
        print()

        F = C.apply(ctx.exp)
        print("F = C.apply(ctx.exp): \n", F)
        print()

        L = F.tolist()
        print("L = F.tolist(): \n", L)
        print()

        # Getting and setting coefficients

        coeff = A[0,0]
        print("coeff = A[0,0]:", coeff)
        print()

        A[0,0] =  4+5j
        print("A: (after A[0,0] =  4+5j \n", A)
        print()



# %%  14.2 Methods and arithmetic operators of a mpmath matrix



    def demo_matrix_operators(self, ctx):
        print()
        print("demo_matrix_operators")

    #    mpmath matrix operators

        A =ctx.randmatrix(2,2)
        print("A =ctx.randmatrix(2,1) \n", A)
        print()

        B =ctx.randmatrix(2,2)
        print("B =ctx.randmatrix(2,1) \n", A)
        print()

        C = A + B
        print("C = A + B \n", C)
        print()

        C = A - B
        print("C = A - B \n", C)
        print()

        C = A * B
        print("C = A * B \n", C)
        print()





# %%  14.3 Norms


    def demo_norms(self, ctx):
        print()
        print("demo_norms")

        print("vector norms")
        x = ctx.matrix([-10, 2, 100])
        norm1 = ctx.norm(x, 1)
        print("norm1 = norm(x, 1):", norm1)

        norm2 = ctx.norm(x, 2)
        print("norm2 = norm(x, 2):", norm2)

        norm3 = ctx.norm(x, ctx.inf)
        print("norm3 = ctx.norm(x, ctx.inf):", norm3)

        print("matrix norms")
        A = ctx.matrix([[1, -1000], [100, 50]])
        norm4 = ctx.mnorm(A, 1)
        print("norm4 = ctx.mnorm(A, 1):", norm4)

        norm5 = ctx.mnorm(A, ctx.inf)
        print("norm5 = ctx.mnorm(A, ctx.inf):", norm5)

        norm6 = ctx.mnorm(A, 'F')
        print("norm6 = ctx.mnorm(A, 'F'):", norm6)



# %%  14.4 Cholesky Decomposition without Pivoting


    def demo_cholesky(self, ctx):
        print()
        print("demo_cholesky")

        #14.4.1 Cholesky decomposition

        print("Real symmetric matrix")
        A = ctx.eye(3) + ctx.hilbert(3)
        print("A = ctx.eye(3) + ctx.hilbert(3): \n", A)
        print()

        L = ctx.cholesky(A)
        print("L = ctx.cholesky(A): \n", L)
        print()

        chop1 = ctx.chop(A - L*L.T)
        print("chop1 = ctx.chop(A - L*L.T): \n", chop1)
        print()

        print("Hermitian matrix")
        A = ctx.eye(3) + ctx.matrix([[0,0.25j,-0.5j],[-0.25j,0,0],[0.5j,0,0]])
        print("A = ctx.eye(3) + ctx.matrix([[0,0.25j,-0.5j],[-0.25j,0,0],[0.5j,0,0]]): \n", A)
        print()

        L = ctx.cholesky(A)
        print("L = ctx.cholesky(A): \n", L)
        print()

        chop1 = ctx.chop(A - L*L.H)
        print("chop1 = ctx.chop(A - L*L.H): \n", chop1)
        print()

        #14.4.2 Cholesky decomposition, solve



# %%  14.5 LU Decomposition with partial Pivoting


    def demo_lu(self, ctx):
        print()
        print("demo_lu")

        #14.5.1 Matrix LU factorization
        A = ctx.matrix([[0,2,3],[4,5,6],[7,8,9]])
        print("A = ctx.matrix([[0,2,3],[4,5,6],[7,8,9]]): \n", A)
        print()

        P, L, U = ctx.lu(A)
        print("P, L, U = ctx.lu(A)")
        print("P: \n", P)
        print()
        print("L: \n", L)
        print()
        print("U: \n", U)
        print()


        #14.5.2 Determinant of a matrix, using LU decomposition


        #14.5.3 Inverse of a matrix, using the LU factorization


        #14.5.4 Linear equations: LU solve
        print("14.5.4 Linear equations: LU solve")
        A = ctx.matrix([[1, 2], [3, 4]])
        print("A = ctx.matrix([[1, 2], [3, 4]]): \n", A)
        print()

        b = ctx.matrix([-10, 10])
        print("b = ctx.matrix([-10, 10]): \n", b)
        print()

        x = ctx.lu_solve(A, b)
        print("x = ctx.lu_solve(A, b): \n", x)
        print()


        #14.5.5 Linear equations: residual of LU solve
        print("14.5.5 Linear equations: residual of LU solve")
        res1 = ctx.residual(A, x, b)
        print("res1 = ctx.residual(A, x, b): \n", res1)
        print()


        #14.5.6 ??? LU improve solution


        #14.5.7 mpmath: LU condition number




# %%  14.6 QR Decomposition without Pivoting


    def demo_qr_real(self, ctx):
        print()
        print("demo_qr")

        #14.6.1 QR factorization, real
        print("14.6.1 QR factorization, real")
        print("Real matrix")
        A = ctx.matrix([[1, 2], [3, 4], [1, 1]])
        print("A = ctx.matrix([[1, 2], [3, 4], [1, 1]]): \n", A)
        print()


#        Q, tau = ctx.qr(A, 'raw')
#        print("Q, R = ctx.qr(A)")
#        print("Q: \n", Q)
#        print()
#        print("tau: \n", tau)
#        print()

        Q, R = ctx.qr(A)
        print("Q, R = ctx.qr(A)")
#        print("Q: \n", Q)
#        print()
#        print("R: \n", R)
#        print()

        res1 = Q * R
        print("res1 = Q * R: \n", res1)
        print()

        chop1 = ctx.chop(Q.T * Q)
        print("chop1 = ctx.chop(Q.T * Q): \n", chop1)
        print()



    def demo_qr_complex(self, ctx):
        print()
        print("demo_qr_complex")

        #14.6.1 QR factorization, complex
        print("14.6.1 QR factorization, complex")

        print("Complex matrix")
        c = '1.0+0.0j'
        c = 1.0+0.01j
        print("c:", c, type(c))
        B = ctx.matrix([[c, 2-3j], [3+1j, 4+5j]])
        #B = ctx.matrix([[1.0+0.0j, 2-3j], [3+1j, 4+5j]])
        for i in range(B.rows):
            for j in range(B.cols):
                print(B[i,j], type(B[i,j]))
        print("B = ctx.matrix([[1.0+0.0j, 2-3j], [3+1j, 4+5j]]): \n", B)
        print()

        Q, R = ctx.qr(B)
        print("Q, R = ctx.qr(B)")
        print("Q: \n", Q)
        print()
        print("R: \n", R)
        print()

        res1 = Q * R
        print("res1 = Q * R: \n", res1)
        print()

        res2 = Q.T
        print("res2 = Q.T \n", res2)

        res3 = Q.conjugate()
        print("res3 = Q.conjugate() \n", res3)

        res4 = Q.T * Q.conjugate()
        print("res4 = Q.T * Q.conjugate() \n", res4)

        chop1 = ctx.chop(Q.T * Q.conjugate())
        print("chop1 = ctx.chop(Q.T * Q.conjugate()): \n", chop1)
        print()


        #14.6.2 QR solve



# %%  14.7 Singular Value Decomposition, singular values and full singular vectors


    def demo_svd(self, ctx):
        print()
        print("demo_svd")


        #14.7.1 Real singular value decomposition of a matrix A
        print("14.7.1 Real singular value decomposition of a matrix A")
        print("Real matrix")
        A = ctx.matrix([[2, -2, -1], [3, 4, -2], [-2, -2, 0]])
        print("A = ctx.matrix([[2, -2, -1], [3, 4, -2], [-2, -2, 0]]): \n", A)
        print()

        S = ctx.svd_r(A, compute_uv = False)
        print("S = ctx.svd_r(A, compute_uv = False): \n", S)
        print()

        #14.7.2 Complex singular value decomposition of a matrix A
        print("14.7.2 Complex singular value decomposition of a matrix A")
        print("Complex matrix")
        A = ctx.matrix([[-2j, -1-3j, -2+2j], [2-2j, -1-3j, 1], [-3+1j,-2j,0]])
        print("A = ctx.matrix([[2, -2, -1], [3, 4, -2], [-2, -2, 0]]): \n", A)
        print()

        S = ctx.svd_c(A, compute_uv = False)
        print("S = ctx.svd_c(A, compute_uv = False): \n", S)
        print()

        res1 = ctx.chop(S - ctx.matrix([ctx.sqrt(34), ctx.sqrt(15), ctx.sqrt(6)]))
        print("res1 = ctx.chop(S - ctx.matrix([ctx.sqrt(34), ctx.sqrt(15), ctx.sqrt(6)])): \n", res1)
        print()

        U, S, V = ctx.svd_c(A)
        print("U, S, V = ctx.svd_c(A)")
        print("U: \n", U)
        print()
        print("S: \n", S)
        print()
        print("V: \n", V)
        print()

        res2 = ctx.chop(A - U * ctx.diag(S) * V)
        print("res2 = ctx.chop(A - U * ctx.diag(S) * V): \n", res2)
        print()

        #14.7.3 mpmath: Singular value decomposition of a matrix A (real or complex)
        print("14.7.3 mpmath: Singular value decomposition of a matrix A (real or complex)")
        print("General matrix")
        A = ctx.matrix([[2, -2, -1], [3, 4, -2], [-2, -2, 0]])
        print("A = ctx.matrix([[2, -2, -1], [3, 4, -2], [-2, -2, 0]]): \n", A)
        print()

        S = ctx.svd(A, compute_uv = False)
        print("S = ctx.svd(A, compute_uv = False): \n", S)
        print()

        U, S, V = ctx.svd_c(A)
        print("U, S, V = ctx.svd_c(A)")
        print("U: \n", U)
        print()
        print("S: \n", S)
        print()
        print("V: \n", V)
        print()

        res2 = ctx.chop(A - U * ctx.diag(S) * V)
        print("res2 = ctx.chop(A - U * ctx.diag(S) * V): \n", res2)
        print()



# %%  14.8 Symmetric/Hermitian Eigensystem


    def demo_sym_her(self, ctx):
        print()
        print("demo_sym_her")

        #14.8.1 Eigenvalue problem for a real symmetric square matrix A
        print("Real matrix")
        A = ctx.matrix([[3, 2], [2, 0]])
        print("A = ctx.matrix([[3, 2], [2, 0]]): \n", A)
        print()

        E = ctx.eigsy(A, eigvals_only = True)
        print("E = ctx.eigsy(A, eigvals_only = True): \n", E)
        print()

        A = ctx.matrix([[1, 2], [2, 3]])
        print("A = ctx.matrix([[1, 2], [2, 3]]): \n", A)
        print()

        E, Q = ctx.eigsy(A)
        print("E, Q = ctx.eigsy(A)")
        print("E: \n", E)
        print()
        print("Q: \n", Q)
        print()

        res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0])
        print("res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0]): \n", res1)
        print()



        #14.8.2 Eigenvalue problem for a complex hermitian square matrix A
        print("Hermitian matrix")
        A = ctx.matrix([[1, -3 - 1j], [-3 + 1j, -2]])
        print("A = ctx.matrix([[1, -3 - 1j], [-3 + 1j, -2]]): \n", A)
        print()

        E = ctx.eighe(A, eigvals_only = True)
        print("E = ctx.eighe(A, eigvals_only = True): \n", E)
        print()

        A = ctx.matrix([[1, 2 + 5j], [2 - 5j, 3]])
        print("A = ctx.matrix([[1, 2 + 5j], [2 - 5j, 3]]): \n", A)
        print()

        E, Q = ctx.eighe(A)
        print("E, Q = ctx.eighe(A)")
        print("E: \n", E)
        print()
        print("Q: \n", Q)
        print()

        res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0])
        print("res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0]): \n", res1)
        print()



        #14.8.3 mpmath: Eigenvalue problem for a selfadjoint square matrix A
        print("Selfadjoint square matrix")
        A = ctx.matrix([[3, 2], [2, 0]])
        print("A = ctx.mp.matrix([[3, 2], [2, 0]]): \n", A)
        print()

        E = ctx.eigh(A, eigvals_only = True)
        print("E = ctx.eighe(A, eigvals_only = True): \n", E)
        print()

        A = ctx.matrix([[1, 2], [2, 3]])
        print("A = ctx.matrix([[1, 2], [2, 3]]): \n", A)
        print()

        E, Q = ctx.eigh(A)
        print("E, Q = ctx.eigsy(A)")
        print("E: \n", E)
        print()
        print("Q: \n", Q)
        print()

        res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0])
        print("res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0]): \n", res1)
        print()

        A = ctx.matrix([[1, 2 + 5j], [2 - 5j, 3]])
        print("A = ctx.matrix([[1, 2 + 5j], [2 - 5j, 3]]): \n", A)
        print()

        E, Q = ctx.eigh(A)
        print("E, Q = ctx.eighe(A)")
        print("E: \n", E)
        print()
        print("Q: \n", Q)
        print()

        res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0])
        print("res1 = ctx.chop(A * Q[:,0] - E[0] * Q[:,0]): \n", res1)
        print()


# %%  14.9 TODO: Tridiagonalization


    def demo_triag(self, ctx):
        print()
        print("demo_triag")


# %%  14.10 Eigensystem of a general square matrix


    def demo_eig(self, ctx):
        print()
        print("demo_eig")

        #14.10.1 Eigensystem decomposition of a matrix A (real or complex)
        print("General matrix")
        A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]])
        print("A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]]): \n", A)
        print()

        E, ER = ctx.eig(A)
        print("E, ER = ctx.eig(A)")
        print("E: \n", E)
        print()
        print("ER: \n", ER)
        print()

        res1 = ctx.chop(A * ER[:,0] - E[0] * ER[:,0])
        print("res1 = ctx.chop(A * ER[:,0] - E[0] * ER[:,0]): \n", res1)
        print()


        E, EL, ER = ctx.eig(A,left = True, right = True)
        print("E, EL, ER = ctx.eig(A,left = True, right = True)")
        print("E: \n", E)
        print()
        print("EL: \n", EL)
        print()
        print("ER: \n", ER)
        print()

        res2 = ctx.chop(A * ER[:,0] - E[0] * ER[:,0])
        print("res2 = ctx.chop(A * ER[:,0] - E[0] * ER[:,0]): \n", res2)
        print()

        res3 = ctx.chop( EL[0,:] * A - EL[0,:] * E[0])
        print("res3 = ctx.chop( EL[0,:] * A - EL[0,:] * E[0]): \n", res3)
        print()


        #14.10.2 Sorting Eigenvalues
        print("Sorting Eigenvalues, general matrix")
        A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]])
        print("A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]]): \n", A)
        print()

        E, EL, ER = ctx.eig(A,left = True, right = True)
        E, EL, ER = ctx.eig_sort(E, EL, ER)
        print("E: \n", E)
        print()

        E, EL, ER = ctx.eig_sort(E, EL, ER,f = lambda x: -ctx.real(x))
        print("E: \n", E)
        print()


        res4 = ctx.chop(A * ER[:,0] - E[0] * ER[:,0])
        print("res4 = ctx.chop(A * ER[:,0] - E[0] * ER[:,0]): \n", res4)
        print()

        res5 = ctx.chop( EL[0,:] * A - EL[0,:] * E[0])
        print("res5 = ctx.chop( EL[0,:] * A - EL[0,:] * E[0]): \n", res5)
        print()



# %%  14.11 Hessenberg and Schur decompositions


    def demo_hessenberg(self, ctx):
        print()
        print("demo_hessenberg")


        #14.11.1 mpmath: Hessenberg decomposition of a matrix A (real or complex)
        print("Hessenberg decomposition")
        A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]])
        print("A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]]): \n", A)
        print()

        Q, H = ctx.hessenberg(A)
        print("Q, H = ctx.hessenberg(A)")
        print("Q: \n", Q)
        print()
        print("H: \n", H)
        print()

        res1 = ctx.chop(A - Q * H * Q.transpose_conj())
        print("res1 = ctx.chop(A - Q * H * Q.transpose_conj()): \n", res1)
        print()



        #14.11.2 Schur decomposition of a matrix A (real or complex)
        print("Schur decomposition")
        A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]])
        print("A = ctx.matrix([[3, -1, 2], [2, 5, -5], [-2, -3, 7]]): \n", A)
        print()

        Q, R = ctx.schur(A)
        print("Q, H = ctx.schur(A)")
        print("Q: \n", Q)
        print()
        print("R: \n", R)
        print()

        res1 = ctx.chop(A - Q * R * Q.transpose_conj())
        print("res1 = ctx.chop(A - Q * H * Q.transpose_conj()): \n", res1)
        print()



# %%  14.12 Analytic functions of a matrix (using mpmath or Arb)


    def demo_matrix_exp(self, ctx):
        print()
        print("demo_matrix_exp")

        res1 = ctx.expm(ctx.zeros(3))
        print("res1 = ctx.expm(ctx.zeros(3)): \n", res1)
        print()

        res2 = ctx.expm(ctx.eye(3))
        print("res1 = ctx.expm(ctx.eye(3)): \n", res2)
        print()

        res3 = ctx.expm([[1,1,0],[1,0,1],[0,1,0]])
        print("res3 = ctx.expm([[1,1,0],[1,0,1],[0,1,0]]): \n", res3)
        print()

        res4 = ctx.expm([[1+1j, 0], [1+1j,1]])
        print("res4 = ctx.expm([[1+1j, 0], [1+1j,1]]): \n", res4)
        print()

#        res5 = ctx.expm(ctx.matrix([[1,2],[2,3]])**25)
#        print("res4 = ctx.expm([[1+1j, 0], [1+1j,1]]): \n", res5)
#        print()

        # checking exp(A + B) = exp(A) exp(B)
        A = ctx.hilbert(3)
        B = A + ctx.eye(3)
        res6 = ctx.chop(ctx.mnorm(A*B - B*A))
        print("res6 = ctx.chop(ctx.mnorm(A*B - B*A)): ", res6)
        print()

        B = A + ctx.ones(3)
        res7 = ctx.mnorm(A*B - B*A)
        print("res7 = ctx.mnorm(A*B - B*A): ", res7)
        print()

        res8 = ctx.mnorm(ctx.expm(A+B) - ctx.expm(A)*ctx.expm(B))
        print("res7 = ctx.mnorm(A*B - B*A): ", res8)
        print()




    def demo_matrix_sin(self, ctx):
        print()
        print("demo_matrix_sin")

        X = ctx.eye(3)
        res1 = ctx.sinm(X)
        print("res1 = ctx.sinm(X): ", res1)
        print()

        X = ctx.hilbert(3)
        res1 = ctx.sinm(X)
        print("res1 = ctx.sinm(X): ", res1)
        print()

        X = ctx.matrix([[1+1j,-2],[0,-1j]])
        res1 = ctx.sinm(X)
        print("res1 = ctx.sinm(X): ", res1)
        print()



    def demo_matrix_cos(self, ctx):
        print()
        print("demo_matrix_cos")

        X = ctx.eye(3)
        res1 = ctx.cosm(X)
        print("res1 = ctx.sinm(X): ", res1)
        print()

        X = ctx.hilbert(3)
        res1 = ctx.cosm(X)
        print("res1 = ctx.sinm(X): ", res1)
        print()

        X = ctx.matrix([[1+1j,-2],[0,-1j]])
        res1 = ctx.cosm(X)
        print("res1 = ctx.sinm(X): ", res1)
        print()


    def demo_matrix_sinh(self, ctx):
        print()
        print("demo_matrix_sinh")


    def demo_matrix_cosh(self, ctx):
        print()
        print("demo_matrix_cosh")



    def demo_matrix_sqrt(self, ctx):
        print()
        print("demo_matrix_sqrt")

        res1 = ctx.sqrtm([[1,0], [0,1]])
        print("res1 = ctx.sqrtm([[1,0], [0,1]]):  \n", res1)
        print()

        res2 = ctx.sqrtm([[0,0], [0,0]])
        print("res2 = ctx.sqrtm([[0,0], [0,0]]):  \n", res2)
        print()

        res3 = ctx.sqrtm([[2,0],[0,1]])
        print("res3 = ctx.sqrtm([[2,0],[0,1]]):  \n", res3)
        print()

        res4 = ctx.sqrtm([[1,1],[1,0]])
        print("res4 = ctx.sqrtm([[1,1],[1,0]]):  \n", res4)
        print()

        res5 = ctx.sqrtm([[1j,0],[0,1j]])
        print("res5 = ctx.sqrtm([[1j,0],[0,1j]]):  \n", res5)
        print()




    def demo_matrix_log(self, ctx):
        print()
        print("demo_matrix_log")

        X = ctx.eye(3)
        res1 = ctx.logm(X)
        print("res1 = ctx.logm(X): \n", res1)
        print()

        X = ctx.matrix([[2+1j, 1, 3], [1-1j, 1-2*1j, 1], [-4, -5, 1j]])
        B = ctx.logm(X)
        print("B = ctx.logm(X): \n", B)
        print()

        res2 = ctx.chop(ctx.expm(B))
        print("res2 = ctx.chop(ctx.expm(B)):  \n", res2)
        print()



    def demo_matrix_pow(self, ctx):
        print()
        print("demo_matrix_pow")

        A = ctx.matrix([[4,1,4],[7,8,9],[10,2,11]])
        res1 = ctx.powm(A, 2)
        print("res1 = ctx.powm(A, 2):  \n", res1)
        print()

        x = ctx.t('1+0.5j')
        print("x:", x, type(x))
        print()
        res2 = ctx.chop(ctx.powm(ctx.powm(A, x), 1/x))
        print("x = ctx.t('1+0.5j')")
        print("res2 = ctx.chop(ctx.powm(ctx.powm(A, x), 1/x)):  \n", res2)
        print()


### Main Run


    # 14.1 Basic methods
    def demo_14_1(self, ctx):
#        print("demo_14_1")
#        self.demo_sqlite3_read_mat(ctx)
#        self.demo_matrix_creation_real(ctx)
        self.demo_matrix_creation_complex(ctx)
        print()


    # 14.2 Methods and arithmetic operators of a mpmath matrix
    def demo_14_2(self, ctx):
        print("demo_14_2")
        self.demo_matrix_methods(ctx)
        self.demo_matrix_operators(ctx)
        print()


    # 14.3 Norms
    def demo_14_3(self, ctx):
        print("demo_14_3")
        self.demo_norms(ctx)
        print()


    # 14.4 Cholesky Decomposition without Pivoting
    def demo_14_4(self, ctx):
        print("demo_14_4")
        self.demo_cholesky(ctx)
        print()


    # 14.5 LU Decomposition with partial Pivoting
    def demo_14_5(self, ctx):
        print("demo_14_5")
        self.demo_lu(ctx)
        print()


    # 14.6 QR Decomposition without Pivoting
    def demo_14_6(self, ctx):
        print("demo_14_6")
        #self.demo_qr_real(ctx)
        self.demo_qr_complex(ctx)
        print()


    # 14.7 Singular Value Decomposition, singular values and full singular vectors
    def demo_14_7(self, ctx):
        print("demo_14_7")
        self.demo_svd(ctx)
        print()


    # 14.8 Symmetric/Hermitian Eigensystem
    def demo_14_8(self, ctx):
        print("demo_14_8")
        self.demo_sym_her(ctx)
        print()


    # 14.9 TODO: Tridiagonalization
    def demo_14_9(self, ctx):
        print("demo_14_9")
        self.demo_triag(ctx)
        print()


    # 14.10 Eigensystem of a general square matrix
    def demo_14_10(self, ctx):
        print("demo_14_10")
        self.demo_eig(ctx)
        print()


    # 14.11 Hessenberg and Schur decompositions
    def demo_14_11(self, ctx):
        print("demo_14_11")
        self.demo_hessenberg(ctx)
        print()


    # 14.12 Analytic functions of a matrix (using mpmath or Arb)
    def demo_14_12(self, ctx):
        print("demo_14_12")
        self.demo_matrix_exp(ctx)
        self.demo_matrix_sin(ctx)
        self.demo_matrix_cos(ctx)
        self.demo_matrix_sinh(ctx)
        self.demo_matrix_cosh(ctx)
        self.demo_matrix_sqrt(ctx)
        self.demo_matrix_log(ctx)
        self.demo_matrix_pow(ctx)
        print()


    def demo_14(self, ctx):
        self.demo_14_1(ctx)
        self.demo_14_2(ctx)
        self.demo_14_3(ctx)
        self.demo_14_4(ctx)
        self.demo_14_5(ctx)
        self.demo_14_6(ctx)
        if (ctx != ipm):
            self.demo_14_7(ctx)
            self.demo_14_8(ctx)
            self.demo_14_9(ctx)
            self.demo_14_10(ctx)
            self.demo_14_11(ctx)
            self.demo_14_12(ctx)
        print()


mpm.dps=15
fpm.dps=mpm.dps
gpm.dps=mpm.dps
dpm.dps=mpm.dps
ipm.dps=mpm.dps

print("dps: ", mpm.dps)


ctxm = ipm
ctxm = fpm
ctxm = dpm
ctxm = gpm
ctxm = mpm
test14().demo_14(ctxm)






























