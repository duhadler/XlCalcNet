
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_from_function()


# needs modification for ctx.t(i)
def demo_from_function():
    print()
    for ctx in ctx_all: 
        x = np.fromfunction(lambda i, j: i, (2, 2), dtype=object)
        print(ctx.name + ':\n', x)

    print()
    x = np.fromfunction(lambda i, j: j, (2, 2), dtype=float)
    print(x)

    print()
    x = np.fromfunction(lambda i, j: i == j, (3, 3), dtype=int)
    print(x)

    print()
    x = np.fromfunction(lambda i, j: i + j, (3, 3), dtype=int)
    print(x)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




