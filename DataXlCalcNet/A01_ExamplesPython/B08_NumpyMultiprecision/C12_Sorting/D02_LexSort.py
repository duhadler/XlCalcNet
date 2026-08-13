
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_lexsort()



def demo_lexsort():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([1, 5, 1, 4, 3, 4, 4], dtype=ctx); print('a: ', a)
        b = npm.array([9, 4, 0, 4, 0, 2, 1], dtype=ctx); print('b: ', b)

        # indices of : Sort by a, then by b
        ind = npm.lexsort((b, a))
        print('npm.lexsort((b, a)): \n', ind); 

        # tuples sorted according to indices
        sorted = [(a[i],b[i]) for i in ind]
        print('[(a[i],b[i]) for i in ind]: \n', sorted); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




