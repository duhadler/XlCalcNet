

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix



import time

from xlcalcnet import fp, mp, gp, dp, ip

from xlcalcnet import mp14

#import gmpy2


n=40
mp.dps=70
show = False
gp.dps=mp.dps
dp.dps=mp.dps
ip.dps=mp.dps

print("Complex quadratic random matrix nxn, n: ", n)
print("dps: ", mp.dps)
print()
print("****************************")
print()



print("using fp:")
fmatA = fp.randmatrix(n) + fp.randmatrix(n) * 1j
start0a = time.time()

fmatB = fmatA * fmatA

end0a = time.time()
Elapsed0a = end0a - start0a

if show:
    print("fmatB : ")
    print(fmatB)

print ("Elapsed0a: ", Elapsed0a)



my_list = [ [0]*n for _ in range(n)]

#print("my_list: ", my_list)


X = fmatA.tolist()
#print(X)


Y = fmatA.tolist()
#print(Y)


start0d = time.time()

result_d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

end0d = time.time()
Elapsed0d = end0d - start0d

if show:
    print("result_d : ")
    print(result_d)

print ("Elapsed0d: ", Elapsed0d)




print()
print("****************************")
print()

def mult(a,b):
    #return gmpy2.mul(a,b)
    return a*b
    #return(a.real*b.real)
    #return a+b
    #return gmpy2.mpc(0)
#    print(repr(a))
#    print(repr(b))

show=False
print("using gp:")

gmatA = gp.randmatrix(n) + gp.randmatrix(n) * gp.j
start1 = time.time()

gmatB = gmatA * gmatA


end1 = time.time()
Elapsed1 = end1 - start1

if show:
    print("gmatB : ")
    print(gmatB)
print ("Elapsed1 : ", Elapsed1)



X = gmatA.tolist()
if show:
    print("X : ")
    print(X)



Y = gmatA.tolist()
if show:
    print("Y : ")
    print(Y)


start1d = time.time()

result_1d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

#result_1d = [[sum(mult(a,b) for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]


end1d = time.time()
Elapsed1d = end1d - start1d

if show:
    print("result_1d : ")
    print(result_1d)

print ("Elapsed1d: ", Elapsed1d)





print()
print("****************************")
print()




#show=True
print("using dp:")


dmatA = dp.randmatrix(n) + dp.randmatrix(n) * dp.j


if show:
    print("dmatA : ")
    print(dmatA)
    print(repr(dmatA[1,1]))


start3 = time.time()

dmatB = dmatA * dmatA

end3 = time.time()
Elapsed3 = end3 - start3

if show:
    print("dmatB : ")
    print(dmatB)
print ("Elapsed3 : ", Elapsed3)
#print ("Ratio/gmpy2: ", Elapsed3/Elapsed1)





X = dmatA.tolist()
#print(X)


Y = dmatA.tolist()
#print(Y)


start3d = time.time()

result_3d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

end3d = time.time()
Elapsed3d = end3d - start3d

if show:
    print("result_3d : ")
    print(result_3d)

print ("Elapsed3d: ", Elapsed3d)





print()
print("****************************")
print()





#show=False
print("using mp:")
mmatA = mp.randmatrix(n) + mp.randmatrix(n) *1j
start2 = time.time()

mmatB = mmatA * mmatA


#print("mmatB : ")
#print(mmatB)

end2 = time.time()
Elapsed2 = end2 - start2


if show:
    print("mmatB : ")
    print(mmatB)

print ("Elapsed2 : ", Elapsed2)



X = mmatA.tolist()
#print(X)


Y = mmatA.tolist()
#print(Y)


start2d = time.time()

result_2d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

end2d = time.time()
Elapsed2d = end2d - start2d

if show:
    print("result_2d : ")
    print(result_2d)

print ("Elapsed2d: ", Elapsed2d)




print()
print("****************************")
print()



#show=False
print("using ip:")
imatA = ip.randmatrix(n) + ip.randmatrix(n) * 1j
start6 = time.time()

imatB = imatA * imatA

print("imatB : ")
#print(imatB)

end6 = time.time()
Elapsed6 = end6 - start6


if show:
    print("imatB : ")
    print(imatB)

print ("Elapsed6 : ", Elapsed6)



X = imatA.tolist()
#print(X)


Y = imatA.tolist()
#print(Y)


start6d = time.time()

result_6d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

end6d = time.time()
Elapsed6d = end6d - start6d

if show:
    print("result_6d : ")
    print(result_6d)

print ("Elapsed6d: ", Elapsed6d)




print()
print("****************************")
print()


print("using arb:")
    
mp4any = mp14.acb()
matA = mp4any.mat_random(n, n)
print("matA :")
#print(matA)
print("size, rows, cols: ", matA.size, matA.rows, matA.cols)

start0 = time.time()

#    matA.show("matA")

k = matA[1,3]
print("k: ", k)

  
matB = matA * matA
print("matB = matA * matA :")

end0 = time.time()
Elapsed0 = end0 - start0
print ("Elapsed0: ", Elapsed0)

if show:
    matB.show("matB")



#def DemoMatrixAll():
#    mp14.setdps(33)
#    
#
#    #DemoBasicMat("Demo arb_mat()", mp14.arb())   
#    DemoBasicMat("Demo acb_mat()", mp14.acb())   
#    
#
#DemoMatrixAll()













