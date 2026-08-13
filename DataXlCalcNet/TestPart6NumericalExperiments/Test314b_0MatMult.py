# -*- coding: utf-8 -*-
"""
Spyder Editor


"""
#
#
#from xlcalcnet.mpUtilities import mpUtil
#from xlcalcnet.ivUtilities import ivUtil
#
#from mpmath import mp
#
#
#mptest = mpUtil()
#p = mptest.ndis(4)
#print(p, mp.sqrt(p))
#
#
#ivtest = ivUtil()
#p2 = ivtest.ndens(4)
#print(p2)
#
#



import time

from xlcalcnet import fp, gp, mp


n=4
show = False
##
##print("Real quadratic random matrix nxn, n: ", n)
##print()
##print("****************************")
##print()
##
##
##
##print("using fp:")
##fmatA = fp.randmatrix(n)
##start0a = time.time()
##
##fmatB = fmatA * fmatA
##
##end0a = time.time()
##Elapsed0a = end0a - start0a
##
##if show:
##    print("fmatB : ")
##    print(fmatB)
##
##print ("Elapsed0a: ", Elapsed0a)
##
##
##
##my_list = [ [0]*n for _ in range(n)]
##
###print("my_list: ", my_list)
##
##
##X = fmatA.tolist()
###print(X)
##
##
##Y = fmatA.tolist()
###print(Y)
##
##
##start0d = time.time()
##
##result_d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]
##
##end0d = time.time()
##Elapsed0d = end0d - start0d
##
##if show:
##    print("result_d : ")
##    print(result_d)
##
##print ("Elapsed0d: ", Elapsed0d)
##
##
##X = [[1.,2.], [3.,4.]]
##Y = [[10.,20.], [30.,40.]]
##
##
##
##result = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]
##print("Matrix Multiplication: ", result)
##
##
##
##result = [[a+b for a, b in zip(*t)] for t in zip(X, Y)]
##print("Addition, coeffwise: ", result)
##
##
##result = [[a-b for a, b in zip(*t)] for t in zip(X, Y)]
##print("Subtraction, coeffwise: ", result)
##
##
##result = [[a*b for a, b in zip(*t)] for t in zip(X, Y)]
##print("Multiplication, coeffwise: ", result)
##
##
##result = [[a/b for a, b in zip(*t)] for t in zip(X, Y)]
##print("Division, coeffwise: ", result)
##
##
##
###identity matrix:
##result=[[1 if item_idx == row_idx else 0 for item_idx in range(3) ] for row_idx in range(3)]
##print("identity matrix: ", result)
##
##
###transpose of a matrix:
##matZ = [[1, 2], [3,4], [5,6], [7,8]]
##c = len(X[0])
##transpose = [[row[i] for row in matZ] for i in range(c)]
##print ("transposed matrix: ", transpose)
##
##
### matrix of zeros
##cols=4
##rows=5
##result = [[0 for col in range(cols)] for row in range(rows)]
##print ("matrix of zeros: ", result)
##
##
### matrix of ones
##cols=4
##rows=5
##result = [[1 for col in range(cols)] for row in range(rows)]
##print ("matrix of ones: ", result)
##
##
##
### matrix of a constant
##cols=4
##rows=5
##c=4.5
##result = [[c for col in range(cols)] for row in range(rows)]
##print ("matrix of a constant: ", result)
##
##
##
##
###for s, t in zip(X, Y):
####    print(s)
####    print(t)
###    for a, b in zip(s,t):
####        print(a)
####        print(b)
###        print(a+b)
###
###
###for t in zip(X):
####    print(t)
###    for a, in zip(*t):
###        print(a)
##
##
##print(X)
##b = 4.5
##result = [[a+b for a, in zip(*t)] for t in zip(X)]
##print("Addition of a constant: ", result)
##
##result = [[a-b for a, in zip(*t)] for t in zip(X)]
##print("Subtraction of a constant: ", result)
##
##result = [[a*b for a, in zip(*t)] for t in zip(X)]
##print("Multiplication by a constant: ", result)
##
##result = [[a/b for a, in zip(*t)] for t in zip(X)]
##print("Division by a constant: ", result)
##
##Row0=result[0]
##print(Row0)
##Row1=result[1]
##print(Row0)
##
##answer = [[i*j for i in range(1, j+1)] for j in range(1, 8)]
##print("Triangular matrix: ", answer)
##
##
##
##def for_loop_matrix_multiplication4(A, B):
##    """Fourth version of a for loop matrix multiplication.
##
##    In this version, we replace B.T with zip(*B) in order to
##    transpose B without needing to convert it to a NumPy array first.
##    This means we can remove the opening np.array conversion lines too.
##    """
##    new_matrix = []
##
##    for i, row in enumerate(A):
##        new_row = []
##        for j, col in enumerate(zip(*B)):
##            dot_product = sum([x*y for (x, y) in zip(row, col)])
##            new_row.append(dot_product)
##        new_matrix.append(new_row)
##    return new_matrix
##


# Program to multiply two matrices using nested loops



print()
print()
print("multiply two matrices: fp")




n=100
X = [[fp.mpf(4.5) for col in range(n)] for row in range(n)]
Y = [[fp.mpf(7.3) for col in range(n)] for row in range(n)]

print(len(X))



start0d = time.time()

result_d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

end0d = time.time()
Elapsed0d = end0d - start0d

print ("Elapsed0: ", Elapsed0d)





result = [[fp.mpf(0.0) for col in range(n)] for row in range(n)]



start1 = time.time()

for i in range(n):
   # iterate through columns of Y
   for j in range(n):
       # iterate through rows of Y
       for k in range(n):
           result[i][j] += X[i][k] * Y[k][j]

end1 = time.time()
Elapsed1 = end1 - start1
print ("Elapsed1: ", Elapsed1)

###for r in result:
###   print(r)
##
##
##R = [[fp.mpf(0.0) for col in range(n)] for row in range(n)]
##
##
##X1=fp.matrix(X)
##Y1=fp.matrix(Y)
##result1=fp.matrix(R)
##
##
##start6 = time.time()
##
##for i in range(n):
##   # iterate through columns of Y
##   for j in range(n):
##       # iterate through rows of Y
##       for k in range(n):
##           result1[i, j] += X1[i, k] * Y1[k, j]
##
##end6 = time.time()
##Elapsed6 = end6 - start6
##print ("Elapsed6: ", Elapsed6)
##print ("Ratio: ", Elapsed6/Elapsed1)
##
##
##
##
##
##






print("multiply two matrices: gp")
#print(result1)

n=100
gp.dps=70
X = [[gp.mpf('4.5') for col in range(n)] for row in range(n)]
Y = [[gp.mpf('7.3') for col in range(n)] for row in range(n)]

print(len(X))



start0d = time.time()

result_d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]
#print(result_d)

end0d = time.time()
Elapsed0d = end0d - start0d



print ("Elapsed0: ", Elapsed0d)





result = [[gp.mpf(0.0) for col in range(n)] for row in range(n)]



start1 = time.time()

for i in range(n):
   # iterate through columns of Y
   for j in range(n):
       # iterate through rows of Y
       for k in range(n):
           result[i][j] += X[i][k] * Y[k][j]

end1 = time.time()
Elapsed1 = end1 - start1
print ("Elapsed1: ", Elapsed1)

#for r in result:
#   print(r)
##
##
##R = [[gp.mpf(0.0) for col in range(n)] for row in range(n)]
##
##
##X1=gp.matrix(X)
##Y1=gp.matrix(Y)
##result1=gp.matrix(R)
##
##
##start6 = time.time()
##
##for i in range(n):
##   # iterate through columns of Y
##   for j in range(n):
##       # iterate through rows of Y
##       for k in range(n):
##           result1[i, j] += X1[i, k] * Y1[k, j]
##
##end6 = time.time()
##Elapsed6 = end6 - start6
##print ("Elapsed6: ", Elapsed6)
##if Elapsed1>0:
##    print ("Ratio: ", Elapsed6/Elapsed1)
##
##
###print("multiply two matrices")
###print(result1)
##
##
##
##
##
##
##
##
##
##
##
##
##
##
##
##
##
##print("multiply two matrices: mp")
##
##n=100
##mp.dps=70
##X = [[mp.mpf('4.5') for col in range(n)] for row in range(n)]
##Y = [[mp.mpf('7.3') for col in range(n)] for row in range(n)]
##
##print(len(X))
##
##
##
##start0d = time.time()
##
##result_d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]
###print(result_d)
##
##end0d = time.time()
##Elapsed0d = end0d - start0d
##
##
##
##print ("Elapsed0: ", Elapsed0d)
##
##
##result = [[mp.mpf(0.0) for col in range(n)] for row in range(n)]
##
##start1 = time.time()
##
##for i in range(n):
##   # iterate through columns of Y
##   for j in range(n):
##       # iterate through rows of Y
##       for k in range(n):
##           result[i][j] += X[i][k] * Y[k][j]
##
##end1 = time.time()
##Elapsed1 = end1 - start1
##print ("Elapsed1: ", Elapsed1)
##
###for r in result:
###   print(r)
##
##
##R = [[mp.mpf(0.0) for col in range(n)] for row in range(n)]
##
##
##X1=mp.matrix(X)
##Y1=mp.matrix(Y)
##result1=mp.matrix(R)
##
##
##start6 = time.time()
##
##for i in range(n):
##   # iterate through columns of Y
##   for j in range(n):
##       # iterate through rows of Y
##       for k in range(n):
##           result1[i, j] += X1[i, k] * Y1[k, j]
##
##end6 = time.time()
##Elapsed6 = end6 - start6
##print ("Elapsed6: ", Elapsed6)
##if Elapsed1>0:
##    print ("Ratio: ", Elapsed6/Elapsed1)
##
##
##start7 = time.time()
##
##result1 = X1 * Y1
##end7 = time.time()
##Elapsed7 = end7 - start7
##print ("Elapsed7: ", Elapsed7)
##if Elapsed1>0:
##    print ("Ratio: ", Elapsed7/Elapsed1)
##
##
##
###print("multiply two matrices")
###print(repr(result1[0,0]))
##
##
##
##
##
##
##
##
##
##
##
##
##
