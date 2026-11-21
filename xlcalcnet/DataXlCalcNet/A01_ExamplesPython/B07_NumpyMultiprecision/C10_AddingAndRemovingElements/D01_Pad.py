
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_pad()



def demo_pad():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([1, 2, 3, 4, 5], dtype=ctx); print('x: ', x)
        print('npm.pad(x, pad_width=(2,3), mode="constant", constant_values=(4, 6): ')
        print(npm.pad(x, pad_width=(2,3), mode='constant', constant_values=(4, 6))); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




