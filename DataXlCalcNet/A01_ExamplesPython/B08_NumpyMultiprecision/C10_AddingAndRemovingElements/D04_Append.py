
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_append()



def demo_append():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([1, 2, 3], dtype=ctx); print('x: ', x)
        y = npm.array([[4, 5, 6], [7, 8, 9]], dtype=ctx); print('y: ', y)
        print('npm.append(x, y): ')
        print(npm.append(x, y)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




