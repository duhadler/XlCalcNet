
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    #Kruskaldemo1()
    Kruskaldemo2()


def Kruskaldemo1():
    print("Kruskaldemo1()")
    n = [6,6,6]  # works only with equal sample size
    pmfkruskal = mpm.pmfvec().ctxKruskal()
    pmfkruskal.kruskal_wallis_h_pmf_vector(mpm, n)



def Kruskaldemo2():
    print("Kruskaldemo2()")
    m = 1  # ' number of groups -1
    pmfkruskal = mpm.pmfvec().ctxKruskal()
    linear = False
    n = [0 for row in range(m+1)]
    v = [0 for row in range(m+1)]
    score = [0 for row in range(m+1)]
    for j in range(0, m+1):
        v[j] = j * 0 + 1
    for j in range(0, m+1):
        n[j] = 14
        print("n" + str(j) + ":", n[j])
    ng = 0
    for j in range(0, m+1):
        ng = ng + n[j]
    Rank = [0 for row in range(ng+1)]
    for j in range(0, ng+1):
        Rank[j] = j

    FinalSize, FinalX, FinalR = pmfkruskal.CalcRankSums(
        m, ng, n, v, Rank, linear, score)
    Mode = 1
    nlength, Prob, x = pmfkruskal.CalcStats(Mode, m, FinalSize, FinalX, FinalR)
    for i in range(0, nlength+1):
        print("i:", i, "x(i):", x[i], "Prob(i)", Prob[i])


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




