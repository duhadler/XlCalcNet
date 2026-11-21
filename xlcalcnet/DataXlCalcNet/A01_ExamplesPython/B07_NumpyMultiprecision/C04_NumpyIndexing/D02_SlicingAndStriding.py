
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_slicing_and_striding()
    demo_slicing_and_striding_2()


def demo_slicing_and_striding():
    print('demo_single_element_indexing:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], dtype=ctx); print('x: ', x)
        print('x[1:7:2] : ', x[1:7:2])

        print('x[-2:10] : ', x[-2:10])
        print('x[-3:3:-1] : ', x[-3:3:-1])

        print('x[5:] : ', x[5:])


def demo_slicing_and_striding_2():
    print('demo_single_element_indexing:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[[1],[2],[3]], [[4],[5],[6]]], dtype=ctx); print('x: ', x)
        print('x.shape : ', x.shape)
        print('x[1:2] : ', x[1:2])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




