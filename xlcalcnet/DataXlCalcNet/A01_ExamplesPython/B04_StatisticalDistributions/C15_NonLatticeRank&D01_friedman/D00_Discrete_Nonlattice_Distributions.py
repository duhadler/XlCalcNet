# -*- coding: utf-8 -*-

from xlcalcnet import mpm


def demo_rv_friedman_MISSING():
    print("Test demo_rv_friedman_MISSING")
    mpm.dps = 10
    What = 0  # ' not just titles
    k = 3  # ' number of groups
    n = 5  # ' Number of blocks
    Quade = 2  # ' 1=friedman 2=quade
    Mode = 1  # ' 1=anova 2=page
    Mode2 = 1  # '1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
    print("in DemoFriedman()")
    mpm.friedman_s_pmf_vector(What, k, n, Quade, Mode, Mode2)



def demo_rv_kruskal_wallis_MISSING():
    print("Test demo_rv_kruskal_wallis_MISSING")
    n = [3, 3, 3, 3]
    #n = [3,3,3]
    #n = [5,5,5]
    m = len(n)-1
    print("m:", m)

    mpm.kruskal_wallis_h_pmf_vector(n)
    return



def Demomilton_pmf():
    print("Test demo_rv_kruskal_wallis_MISSING")
    n = [1, 2, 3]
    delta = [0, 1, 2]
    #fpm.milton_pmf(n, delta)
    mpm.milton_pmf(n, delta)


#demo_rv_friedman_MISSING()

#demo_rv_kruskal_wallis_MISSING()

Demomilton_pmf()





