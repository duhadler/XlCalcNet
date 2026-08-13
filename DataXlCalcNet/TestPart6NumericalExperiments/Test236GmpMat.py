

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix



import time

from xlcalcnet import fp, mp, gp, dp, ip #, mp14


n=60
mp.dps=33

show = False
showinput = False
invert = False
mult2 = True
gp.dps=mp.dps
dp.dps=mp.dps
ip.dps=mp.dps

print("Real quadratic random matrix nxn, n: ", n)
print("dps: ", mp.dps)
print()
print("****************************")
print()



print("using fp:")
fmatA = fp.randmatrix(n)
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

start0d = time.time()


if invert: fmatAInv = fmatA**-1
else: fmatAInv = fmatA


Y = fmatAInv.tolist()
#print(Y)


if mult2:
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


#show=True
print("using gp:")
gmatA = gp.randmatrix(n)

if show:
    print("gmatA : ")
    print(gmatA)

gmatA = gmatA.apply(gp.sqrt)


if showinput:
    print("gmatA, after gmatA.apply(gp.sqrt) : ")
    print(gmatA.tolist())

start1 = time.time()

gmatB = gmatA * gmatA


end1 = time.time()
Elapsed1 = end1 - start1

if show:
    print("gmatB : ")
    print(gmatB)
print ("Elapsed1a: ", Elapsed1)


X = gmatA.tolist()

if show:
    print("X : ")
    print(X)

start1d = time.time()


if invert: gmatAInv = gmatA**-1
else: gmatAInv = gmatA


Y = gmatAInv.tolist()
#print(Y)


if mult2:
    result_1d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

end1d = time.time()
Elapsed1d = end1d - start1d

if show:
    print("result_1d : ")
    #print(result_1d)

print ("Elapsed1d: ", Elapsed1d)





print()
print("****************************")
print()




#show=True
print("using dp:")
dmatA = dp.randmatrix(n)

if show:
    print("gmatA : ")
    print(dmatA)

dmatA = dmatA.apply(dp.sqrt)


if showinput:
    print("dmatA, after dmatA.apply(dp.sqrt) : ")
    print(dmatA.tolist())


start3 = time.time()

dmatB = dmatA * dmatA

end3 = time.time()
Elapsed3 = end3 - start3

if show:
    print("dmatB : ")
    print(dmatB)
print ("Elapsed3a: ", Elapsed3)




X = dmatA.tolist()
#print(X)
start3d = time.time()


if invert: dmatAInv = dmatA**-1
else: dmatAInv = dmatA

Y = dmatAInv.tolist()
#print(Y)


if mult2:
    result_3d = [[sum(a*b for a,b in zip(X_row,Y_col)) for Y_col in zip(*Y)] for X_row in X]

end3d = time.time()
Elapsed3d = end3d - start3d

if show:
    print("result_3d : ")
    print(result_3d)

print ("Elapsed3d: ", Elapsed3d)
#show=False




print()
print("****************************")
print()






print("using mp:")
mmatA = mp.randmatrix(n)

if show:
    print("mmatA : ")
    print(mmatA)

mmatA = mmatA.apply(mp.sqrt)


if showinput:
    print("mmatA, after mmatA.apply(mp.sqrt) : ")
    print(mmatA.tolist())




start2 = time.time()

mmatB = mmatA * mmatA


end2 = time.time()
Elapsed2 = end2 - start2


if show:
    print("mmatB : ")
    print(mmatB)

print ("Elapsed2a: ", Elapsed2)



X = mmatA.tolist()
#print(X)
start2d = time.time()

if invert: mmatAInv = mmatA**-1
else: mmatAInv = mmatA
Y = mmatAInv.tolist()
#print(Y)


if mult2:
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


print("using ip:")
imatA = ip.randmatrix(n)

if show:
    print("imatA : ")
    print(imatA)

imatA = imatA.apply(ip.sqrt)


if showinput:
    print("imatA, after imatA.apply(ip.sqrt) : ")
    print(imatA.tolist())




start6 = time.time()

imatB = imatA * imatA

print("imatB : ")
#print(imatB)

end6 = time.time()
Elapsed6 = end6 - start6


if show:
    print("imatB : ")
    print(imatB)

print ("Elapsed6: ", Elapsed6)



X = imatA.tolist()
#print(X)


#print(Y)
start6d = time.time()


if invert: imatAInv = imatA**-1
else: imatAInv = imatA
Y = imatAInv.tolist()

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



print("using xrf:")

mp4any = mp14.xrf()
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




print()
print("****************************")
print()



print("using mprf:")

mp4any = mp14.mprf()
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




print()
print("****************************")
print()



print("using drf:")

mp4any = mp14.drf()
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




print()
print("****************************")
print()



print("using arf:")

mp4any = mp14.arf()
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




print()
print("****************************")
print()



print("using arb:")

mp4any = mp14.arb()
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




print()
print("****************************")
print()









