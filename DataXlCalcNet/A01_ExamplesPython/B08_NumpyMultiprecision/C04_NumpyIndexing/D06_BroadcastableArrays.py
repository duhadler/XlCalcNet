
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_broadcastable_arrays()
    demo_broadcastable_arrays_2()



def demo_broadcastable_arrays():
    print('demo_broadcastable_arrays:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([[ 0.0, 0.0, 0.0], [10.0, 10.0, 10.0], [20.0, 20.0, 20.0], [30.0, 30.0, 30.0]], dtype=ctx); print('a: ', a)
        b = npm.array([1.0, 2.0, 3.0], dtype=ctx); print('b: ', b)
        print('a + b : ', a + b)

        b = npm.array([1.0, 2.0, 3.0, 4.0], dtype=ctx); print('b: ', b)
        #print('a + b : ', a + b)   # ValueError



def demo_broadcastable_arrays_2():
    print('demo_broadcastable_arrays:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([0.0, 10.0, 20.0, 30.0], dtype=ctx); print('a: ', a)
        b = npm.array([1.0, 2.0, 3.0], dtype=ctx); print('b: ', b)
        print('a[:, np.newaxis] + b : \n', a[:, np.newaxis] + b)


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




