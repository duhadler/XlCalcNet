
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_from_iter()
    demo_from_iter2()



def demo_from_iter():
    print()
    for ctx in ctx_all: 
        iterable = (ctx.square(x) for x in range(5))
        x = npm.fromiter(iterable, object)
        print(ctx.name + ':\n', x)




def demo_from_iter2():
    print()
    for ctx in ctx_all: 
        iterable = ((ctx.t(x), ctx.square(x)) for x in range(5))
        x = npm.fromiter(iterable, dtype=np.dtype((object, 2)))
        print(ctx.name + ':\n', x)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




