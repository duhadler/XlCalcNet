import cmath

from xlcalcnet.mpmath import mp
import time

import xlcalcnet.mpmath.libmp
print("mpmath.libmp.BACKEND: ", xlcalcnet.mpmath.libmp.BACKEND)

#op = "ln"; myiter=10000
#op = "exp"; myiter=10000
#op = "sqrt"; myiter=50000
#op = "divide"; myiter=100000
op = "multiply"; myiter=100000
#op = "add"; myiter=100000


#myprec=53; prectext=" (double precision mantissa)"
#myprec=113; prectext=" (quadruple precision mantissa)"
myprec=237 ; prectext=" (octuple precision mantissa)"

mydps = max(1, int(round(int(myprec)/3.3219280948873626)-1))
factor = "0.999999999900000"
factor = "1.0"

print("Operation: " + op)
print("prec: ", myprec, prectext, "   dps: ", mydps)
print("iterations: ", myiter)


print()
print("****************************")
print()


print("using system.math:")

start0 = time.time()
f0 = f1 = cmath.sqrt(2+3j)
f2 = complex(float(factor), 0.0)
s1 = f0
#print("f1 = cmath.sqrt(2+3j): ", f1)
#print("f2: ", f2)
#print("s1: ", s1)

if op=="ln":
    for i in range(myiter):
        #print("f0: ", f0)
        f1=cmath.log(f0)
        #print("f1: ", f1)
        f0=f0*f2
        s1=s1+f1

if op=="exp":
    for i in range(myiter):
        f1=cmath.exp(f0)
        f0=f0*f2
        s1=s1+f1

if op=="sqrt":
    for i in range(myiter):
        f1=cmath.sqrt(f0)
        f0=f0*f2
        s1=s1+f1

if op=="divide":
    for i in range(myiter):
        f1=f1/f2
        s1=s1+f1

if op=="multiply":
    for i in range(myiter):
        f1=f1*f2
        s1=s1+f1

if op=="add":
    for i in range(myiter):
        f1=f1+f2
        s1=s1+f1

#print("f1 : ", f1)
print("s1 : ", s1)
end0 = time.time()
Elapsed0 = end0 - start0
print ("Elapsed0: ", Elapsed0)


print()
print("****************************")
print()



print("using gmpy2:")
import gmpy2
#from gmpy2 import mpfr
gmpy2.get_context().precision=myprec

start1 = time.time()
x0 = x1 = gmpy2.sqrt(2+3j)
x2 = gmpy2.mpc(factor)
s1 = x0
#print("x1 = gmpy2.sqrt(2): ", x1)

if op=="ln":
    for i in range(myiter):
        x1=gmpy2.log(x0)
        x0=x0*x2
        s1=s1+x1

if op=="exp":
    for i in range(myiter):
        x1=gmpy2.exp(x0)
        x0=x0*x2
        s1=s1+x1


if op=="sqrt":
    for i in range(myiter):
        x1=gmpy2.sqrt(x0)
        x0=x0*x2
        s1=s1+x1

if op=="divide":
    for i in range(myiter):
        x1=x1/x2
        s1=s1+x1

if op=="multiply":
    for i in range(myiter):
        x1=x1*x2
        s1=s1+x1

if op=="add":
    for i in range(myiter):
        x1=x1+x2
        s1=s1+x1

#print("x1 : ", x1)
print("s1 : ", s1)
end1 = time.time()
Elapsed1 = end1 - start1

print ("Elapsed1: ", Elapsed1)
print ("Ratio/system.math: ", Elapsed1/Elapsed0)
#q1 = gmpy2.sqrt(2+4j)
#print("z1 = gmpy2.sqrt(22+4j): ", q1)


print()
print("****************************")
print()


print("using mpmath:")
mp.prec = myprec

start2 = time.time()
z0 =z1 = mp.sqrt(2+3j)
z2 = mp.mpc(factor)
s1 = z0
#print("z1 = mp.sqrt(2): ", z1)

if op=="ln":
    for i in range(myiter):
        z1=mp.ln(z0)
        z0=z0*z2
        s1=s1+z1
        #f1=mp.log(z1)

if op=="exp":
    for i in range(myiter):
        z1=mp.exp(z0)
        z0=z0*z2
        s1=s1+z1

if op=="sqrt":
    for i in range(myiter):
        z1=mp.sqrt(z0)
        z0=z0*z2
        s1=s1+z1

if op=="divide":
    for i in range(myiter):
        z1=z1/z2
        s1=s1+z1

if op=="multiply":
    for i in range(myiter):
        z1=z1*z2
        s1=s1+z1

if op=="add":
    for i in range(myiter):
        z1=z1+z2
        s1=s1+z1

#print("z1 : ", z1)
print("s1 : ", s1)
end2 = time.time()
Elapsed2 = end2 - start2
print ("Elapsed2: ", Elapsed2)
print ("Ratio/gmpy2: ", Elapsed2/Elapsed1)
#print ("mp.dps: ", mp.dps)



print()
print("****************************")
print()



print("using decimal:")
#from decimal import getcontext, Decimal as D
from xlcalcnet import dp

dp.dps = mp.dps
#gp.dps=mp.dps
start3 = time.time()
dd = dp.mpc(2+3j)
#print("dd: ", dd)
#d0 = d1 = dp.sqrt(2+3j)
d0 = d1 = dp.sqrt(dd)
#print("d1: ", d1)
d2 = dp.mpc(float(factor))
#print("d2: ", d2)
s1 = d0

if op=="ln":
    for i in range(myiter):
        d1=dp.ln(d0)
        d0=d0*d2
        s1=s1+d1

if op=="exp":
    for i in range(myiter):
        d1=dp.exp(d0)
        d0=d0*d2
        s1=s1+d1

if op=="sqrt":
    for i in range(myiter):
        d1=dp.sqrt(d0)
        d0=d0*d2
        s1=s1+d1


if op=="divide":
    for i in range(myiter):
        d1=d1/d2
        s1=s1+d1

if op=="multiply":
    for i in range(myiter):
        d1=d1*d2
        s1=s1+d1

if op=="add":
    for i in range(myiter):
        d1=d1+d2
        s1=s1+d1

#print("d1 : ", d1)
print("s1 : ", s1)
end3 = time.time()
Elapsed3 = end3 - start3
print ("Elapsed3: ", Elapsed3)
print ("Ratio/gmpy2: ", Elapsed3/Elapsed1)





print()
print("****************************")
print()




print("using ipm:")
from xlcalcnet import ip, iv

ip.dps = mp.dps
#mpm.prec = 53
#iv.prec=53

start4 = time.time()
a0 = a1 = ip.sqrt(2+3j)
#a0 = a1 = iv.mpc(iv.mpf(2), iv.mpf(3))


#print("a1: ", a1)
a2 = ip.mpc(factor, 0)
#a2 = iv.mpc(iv.mpf(factor), iv.mpf(0))
#print("a2: ", a2)
s1 = a0


if op=="ln":
    for i in range(myiter):
        a1=ip.ln(a0)
        a0=a0*a2
        s1=s1+a1

if op=="exp":
    for i in range(myiter):
        a1=ip.exp(a0)
        a0=a0*a2
        s1=s1+a1

if op=="sqrt":
    for i in range(myiter):
        a1=ip.sqrt(a0)
        a0=a0*a2
        s1=s1+a1


if op=="divide":
    for i in range(myiter):
        a1=a1/a2
        s1=s1+a1

if op=="multiply":
    for i in range(myiter):
        a1=a1*a2
        s1=s1+a1

if op=="add":
    for i in range(myiter):
        a1=a1+a2
        s1=s1+a1

#print("a1 : ", a1)
print("s1 : ", s1)
end4 = time.time()
Elapsed4 = end4 - start4
print ("Elapsed4: ", Elapsed4)
print ("Ratio/gmpy2: ", Elapsed4/Elapsed1)





print()
print("****************************")
print()


#
#
#print("using arb:")
#from xlcalcnet import arb
#
#mpm.dps = mp.dps
##mpm.prec = 53
##iv.prec=53
#
#start4 = time.time()
#a0 = a1 = arb.sqrt(2)
#
##print("a1: ", a1)
#a2 = arb.t(factor)
##print("a2: ", a2)
#s1 = a0
#
#
#if op=="ln":
#    for i in range(myiter):
#        a1=arb.ln(a0)
#        a0=a0*a2
#        s1=s1+a1
#
#if op=="exp":
#    for i in range(myiter):
#        a1=arb.exp(a0)
#        a0=a0*a2
#        s1=s1+a1
#
#if op=="sqrt":
#    for i in range(myiter):
#        a1=arb.sqrt(a1)
#        a1=a1*a2
#
#
#if op=="divide":
#    for i in range(myiter):
#        a1=a1/a2
#
#if op=="multiply":
#    for i in range(myiter):
#        a1=a1*a2
#
#if op=="add":
#    for i in range(myiter):
#        a1=a1+a2
#
#print("a1 : ", a1)
#print("s1 : ", s1)
#end4 = time.time()
#Elapsed4 = end4 - start4
#print ("Elapsed4: ", Elapsed4)
#print ("Ratio/gmpy2: ", Elapsed4/Elapsed1)
#


