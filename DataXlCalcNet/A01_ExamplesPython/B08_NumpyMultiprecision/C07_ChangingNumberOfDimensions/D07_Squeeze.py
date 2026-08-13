
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_squeeze()



def demo_squeeze():
    print('npm.squeeze(x, axis=0): ')
    for ctx in ctx_all: 
        x = npm.array([[[0], [1], [2]]], dtype=ctx)
        print(ctx.name + ': ', npm.squeeze(x, axis=0)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




