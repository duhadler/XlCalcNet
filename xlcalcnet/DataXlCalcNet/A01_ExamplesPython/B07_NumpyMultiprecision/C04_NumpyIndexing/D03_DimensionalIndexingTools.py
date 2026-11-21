
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_dimensional_indexing_tools()
    demo_dimensional_indexing_tools_2()



def demo_dimensional_indexing_tools():
    print('demo_dimensional_indexing_tools:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[[1],[2],[3]], [[4],[5],[6]]], dtype=ctx); print('x: ', x)
        print('x.shape : ', x.shape)
        print('x[..., 0]: \n ', x[..., 0])

        print('x[:, :, 0]: \n ', x[:, :, 0])

        print('x[:, np.newaxis, :, :].shape: \n ', x[:, np.newaxis, :, :].shape)



def demo_dimensional_indexing_tools_2():
    print('demo_dimensional_indexing_tools_2:')
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(5, dtype=ctx); print('x: ', x)
        print('x[:, np.newaxis] + x[np.newaxis, :] : \n', x[:, np.newaxis] + x[np.newaxis, :])


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




