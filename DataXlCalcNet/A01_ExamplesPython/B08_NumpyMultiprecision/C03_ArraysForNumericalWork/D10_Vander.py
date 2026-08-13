
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_vander()
#    demo_vander2()
    demo_vander3()


def demo_vander():
    print()
    print('demo_vander')
    
    for ctx in ctx_all: 
        print()
        x = npm.array([1, 2, 3, 5], dtype=ctx)        
        N = 3
        print(npm.vander(x, N))


def demo_vander2():
    print()
    print('demo_vander2')
    
    for ctx in ctx_all: 
        print()
        x = npm.array([1, 2, 3, 5], dtype=ctx)        
        N = 3
        print(npm.vander(x))


def demo_vander3():
    print()
    print('demo_vander2')
    
    for ctx in ctx_all: 
        print()
        x = npm.array([1, 2, 3, 5], dtype=ctx)        
        N = 3
        print(npm.vander(x, increasing=True))


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




