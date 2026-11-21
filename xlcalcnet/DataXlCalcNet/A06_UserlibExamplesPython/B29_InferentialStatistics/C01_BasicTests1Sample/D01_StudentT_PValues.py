from xlcalcnet import gui, mpm, mpmlib
import os


def stats_student_t_1sample_test(n, mu0, mean, std, alpha, **kwargs):
    from xlcalcnet import gui, mpm, fpm, mp
    from xlcalcnet.ctx07StatDataAnalysis import table
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'csv'
    ctx = mpm
    ctx.dps=10;
    res = ctx.student_t_1sample_test(n, mu0, mean, std, alpha, **kwargs);
    tbl = table(ctx, res)

    # Add as OutputMode: ListWithDoubles

    if OutputMode == 'list':
        #print(tbl.to_list())
        return tbl.to_list()
    elif OutputMode == 'text':
        print(tbl)
        return str(tbl)
    else:
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, 'OutputMonitor', 'TTest1External.' + OutputMode])
        #print(FullPath)
        if OutputMode == 'csv': tbl.to_csv(FullPath)
        if OutputMode == 'xlsx': tbl.to_xlsx(FullPath)


try:

    stats_student_t_1sample_test(n=[15, 20, 30], mu0=1.0, mean=[4.5,4.6], std=[1,2,3,4], \
        alpha=0.015, I=True, D=True, T=True, C=True, \
        Onesided=True, Twosided = True, OutputMode='xlsx')

# Outputmode: 'csv', 'xlsx', 'text', 'list'

except Exception:
    import traceback
    print(traceback.format_exc())





























