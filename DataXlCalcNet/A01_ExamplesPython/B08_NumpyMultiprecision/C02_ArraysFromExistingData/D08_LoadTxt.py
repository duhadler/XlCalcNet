
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_loadtxt()



def demo_loadtxt():
    import os
    import xlcalcnet.userpaths as userpaths
    for ctx in ctx_all:
        to_ctx = npm.vectorize(ctx.t, otypes=[object])

        csvpath = os.sep.join([userpaths.get_my_documents(), \
            'DataXlCalcNet', 'DataExamples', 'MainExamples', 'CSV'])
        csvfile = 'Hald.csv'
        csvname = os.sep.join([csvpath, csvfile])

        with open(csvname) as f: header = f.readline().strip('\n')
        print('Header: ', header)

        nd_data = npm.loadtxt(csvname, dtype=np.float64, delimiter=',', \
        skiprows=1, usecols=(0,1,2,3,4))
        A = to_ctx(nd_data)
        N = len(A)
        print('N:', N)
        print('A: \n', A)
        print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




