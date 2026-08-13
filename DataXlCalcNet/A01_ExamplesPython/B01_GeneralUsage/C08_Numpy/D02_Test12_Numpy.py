# see also: https://numpy.org/doc/stable/reference/routines.statistics.html


import numpy as np

from xlcalcnet import gpm, dpm, fpm, mpm, ipm   #, apm


def demo_fp():
    r = 8
    c = 2
    
    R = np.ndarray((r,c),dtype=float)
    d1 = 1.0
    for i in range(r):
        for j in range(c):
            R[i,j] = 10*(i+1) + d1/(j+7)

    print(R)
    res = np.mean(R)
    print("res = np.mean(R): \n", res, type(res))
    res = np.mean(R, axis=0)
    print("res = np.mean(R, axis=0): \n", res, type(res))
    res = np.mean(R, axis=1)
    print("res = np.mean(R, axis=1): \n", res, type(res))
    
    
    

def demo_mp():
    r = 8
    c = 2
    gpm.dps = 30
    
    R = np.ndarray((r,c),dtype=gpm.realtype)
    d1 = gpm.t(1.0)
    for i in range(r):
        for j in range(c):
            R[i,j] = 10*(i+1) + d1/(j+7)

    print(R)
    res = np.mean(R)
    print("res = np.mean(R): \n", res, type(res))
    res = np.mean(R, axis=0)
    print("res = np.mean(R, axis=0): \n", res, type(res))
    res = np.mean(R, axis=1)
    print("res = np.mean(R, axis=1): \n", res, type(res))


def demo_mp_poly(ctx):
    from numpy.polynomial import polynomial as P
    ctx.dps = 30
    d1 = ctx.t(1.0)
    c1 = (d1*1,d1*2,d1*3)
    c2 = (d1*3,d1*2,d1*1)
    
    sum1 = P.polyadd(c1,c2)
    d2 = ctx.t('2.001')
    print("sum1 = P.polyadd(c1,c2): \n", sum1)
    res = P.polyval(d2, sum1)
    print("P.polyval(d2, sum1): \n", res)
    
    prod1 = P.polymul(c1,c2)
    d2 = ctx.t('2.001')
    print("prod1 = P.polymul(c1,c2): \n", prod1)
    res = P.polyval(d2, prod1)
    print("P.polyval(d2, prod1): \n", res)
    
    quot1, remainder = P.polydiv(c2,c1)
    d2 = ctx.t('2.001')
    print("quot1, remainder  = P.polymul(c1,c2): \n", quot1, remainder)
    res = P.polyval(d2, quot1)
    print("P.polyval(d2, quot1): \n", quot1)







def demo_mp_dot(ctx):
    ctx.dps = 30
    d1 = ctx.t('1.1')
    c1 = [d1*1,d1*2,d1*3]
    c2 = [d1*3,d1*2,d1*1]
    res = np.dot(c1, c2)
    print("res = np.dot(c1, c2): \n", res)


def demo_all():

    #ctxm = fpm
    #ctxm = mpm
    # #### ctxm = apm
    #ctxm = ipm
    #ctxm = gpm
    ctxm = dpm

    ctxm.prec = 80
    

    demo_mp_poly(ctxm)
    demo_mp_dot(ctxm)

demo_all()





# demo_fp()

# demo_mp()

demo_all()



