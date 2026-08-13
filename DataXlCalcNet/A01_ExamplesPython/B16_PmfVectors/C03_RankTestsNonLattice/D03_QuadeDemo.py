
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    Quadedemo1()


def Quadedemo1():
    print("Quadedemo1()")
    k = 3
    n = 6
    Quade = 2
    Mode = 1
    Mode2 = 1
    pmfkruskal = mpm.pmfvec().ctxFriedman()
    pmfkruskal.friedman_s_pmf_vector(mpm, k, n, Quade, Mode, Mode2)




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




