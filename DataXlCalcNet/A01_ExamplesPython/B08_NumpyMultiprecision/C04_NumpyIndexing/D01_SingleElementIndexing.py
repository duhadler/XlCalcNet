
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_single_element_indexing()



def demo_single_element_indexing():
    print('demo_single_element_indexing:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(10, dtype=ctx); print('x: ', x)
        print('x[2] : ', x[2])
        print('x[-2] : ', x[-2])

        x.shape = (2, 5); print('x: ', x)
        print('x[1, 3] : ', x[1, 3])
        print('x[1, -1] : ', x[1, -1])
        print('x[0] : ', x[0])
        print('x[0][2] : ', x[0][2])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




