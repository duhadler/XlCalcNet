
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_sort()



def demo_sort():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([[1,4],[3,1]], dtype=ctx); print('a: ', a)
        # sort along the last axis
        print('npm.sort(a): \n', npm.sort(a)); 

        # sort the flattened array
        print('npm.sort(a, axis=None): \n', npm.sort(a, axis=None)); 

        # sort along the first axis
        print('npm.sort(a, axis=0): \n', npm.sort(a, axis=0)); 






try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




