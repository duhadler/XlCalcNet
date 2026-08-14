# -*- coding: utf-8 -*-
"""
Spyder Editor

"""

import platform
import sys
import xlcalcnet.mpmath

def modulepath():
    import os
    PathToThisFile = os.path.dirname(os.path.realpath(__file__))
    mname = r"\xlcalcnet"
    pos = PathToThisFile.find(mname)
    return PathToThisFile[:pos]


if (sys.version_info < (3, 8)):
    raise("This library requires Python 3.8 or higher")


from xlcalcnet.ctx_ip import IPContext
from xlcalcnet.ctx_dp import DPContext
from xlcalcnet.ctx_qp import QPContext

from xlcalcnet import ctx_dpm, ctx_ipm, ctx_mpm, ctx_fpm, ctx_qpm

dpm = ctx_dpm.dpm()
ipm = ctx_ipm.ipm()
mpm = ctx_mpm.mpm()
fpm = ctx_fpm.fpm()
qpm = ctx_qpm.qpm()


mpm.dps = 15


dp = DPContext()
ip = IPContext()
qp = QPContext()
mp = xlcalcnet.mpmath.mp
iv = xlcalcnet.mpmath.iv
fp = xlcalcnet.mpmath.fp


import xlcalcnet.ShowGUI
gui = xlcalcnet.ShowGUI.gui()
gui.adduserpath()


use_gpm = True
use_apm = True
use_xlcalcnet2 = True
use_userfixedlib = True
use_userarblib = True
ArbPrec = None

try:
    from xlcalcnet import ctx_npm
    npm = ctx_npm.npm()
except:
    print("npm is not available")




try:
    from xlcalcnet.ctx_gp import GPContext
    from xlcalcnet import ctx_gpm
    gpm = ctx_gpm.gpm()
    gp = GPContext()
except:
    print("gpm is not available")
    use_gpm = False

gui._set_has_gpm(use_gpm)


try:
    from xlcalcnet.ctx_ap import APContext
    from xlcalcnet import ctx_apm
    apm = ctx_apm.apm()
    ap = APContext()
except:
    print("apm is not available")
    use_apm = False

gui._set_has_apm(use_apm)


try:
    from A03_UserlibPython.B01_Classes.C01_BasedOnMpmath import D01_ctx_fpmlib
    fpmlib = D01_ctx_fpmlib.fpmlib()
except:
    print("fpmlib is not available")


try:
    from A03_UserlibPython.B01_Classes.C01_BasedOnMpmath import D02_ctx_mpmlib
    mpmlib = D02_ctx_mpmlib.mpmlib()
except:
    print("mpmlib is not available")


try:
    from A03_UserlibPython.B01_Classes.C01_BasedOnMpmath import D03_ctx_ipmlib
    ipmlib = D03_ctx_ipmlib.ipmlib()
except:
    print("ipmlib is not available")


try:
    from A03_UserlibPython.B01_Classes.C01_BasedOnMpmath import D04_ctx_dpmlib
    dpmlib = D04_ctx_dpmlib.dpmlib()
except:
    print("dpmlib is not available")


try:
    from A03_UserlibPython.B01_Classes.C01_BasedOnMpmath import D05_ctx_qpmlib
    qpmlib = D05_ctx_qpmlib.qpmlib()
except:
    print("qpmlib is not available")


try:
    from A03_UserlibPython.B01_Classes.C01_BasedOnMpmath import D06_ctx_gpmlib
    gpmlib = D06_ctx_gpmlib.gpmlib()
except:
    print("gpmlib is not available")


try:
    from A03_UserlibPython.B01_Classes.C01_BasedOnMpmath import D07_ctx_apmlib
    apmlib = D07_ctx_apmlib.apmlib()
except:
    print("apmlib is not available")




if (platform.system()=='Windows'):
    try:
        import clr
        clr.AddReference("System.Numerics")

    except:
        print("Pythonnet is not available")

    try:
        DllPath = modulepath() + r"\xlcalcnet\Addin\NET48\Bin\FixedPrecNet.dll"
        clr.AddReference(DllPath)
        import FixedPrecNet

        math53 = FixedPrecNet.math53
        cmath53 = FixedPrecNet.cmath53

        sreal = FixedPrecNet.sreal
        scplx = FixedPrecNet.scplx

        dreal = FixedPrecNet.dreal
        dcplx = FixedPrecNet.dcplx

        ereal = FixedPrecNet.ereal
        ecplx = FixedPrecNet.ecplx

        qreal = FixedPrecNet.qreal
        qcplx = FixedPrecNet.qcplx

        oreal = FixedPrecNet.oreal
        ocplx = FixedPrecNet.ocplx

    except:
        print("FixedPrecNet is not available")


    try:
        from xlcalcnet import ctx_math53
        import FixedPrecNet
        np53  = ctx_math53.NumpyMath53(FixedPrecNet)
        np53c = ctx_math53.NumpyMath53c(FixedPrecNet)
    except:
        print("np53/np53c is not available")




    try:
        DllPath = modulepath() + r"\xlcalcnet2\Addin\NET48\Bin\ArbPrecNet.dll"
        clr.AddReference(DllPath)
        import ArbPrecNet
        ArbPrec = ArbPrecNet.ArbPrec

        mreal = ArbPrecNet.mreal
        mcplx = ArbPrecNet.mcplx

        sflint   = ArbPrecNet.sflint
        sflintc  = ArbPrecNet.sflintc
        dflint   = ArbPrecNet.dflint
        dflintc  = ArbPrecNet.dflintc
        eflint   = ArbPrecNet.eflint
        eflintc  = ArbPrecNet.eflintc
        qflint   = ArbPrecNet.qflint
        qflintc  = ArbPrecNet.qflintc
        oflint   = ArbPrecNet.oflint
        oflintc  = ArbPrecNet.oflintc

        mflint   = ArbPrecNet.mflint
        mflintc  = ArbPrecNet.mflintc
        aflint   = ArbPrecNet.aflint
        aflintc  = ArbPrecNet.aflintc

    except:
        print("ArbPrecNet is not available")
        use_xlcalcnet2 = False
        ArbPrec = None

    gui._set_has_xlcalcnet2(use_xlcalcnet2)
    gui._set_ArbPrec(ArbPrec)


    try:
        #print("Start User")
        DllPath = gui.get_local_appdata_xlcalcnet() + r"\Bin\UserFixedPrecNet.dll"
        #print(DllPath)
        clr.AddReference(DllPath)
        import UserFixedPrecNet

        m53lib = UserFixedPrecNet.m53lib
        m53libc = UserFixedPrecNet.m53libc

        slib = UserFixedPrecNet.slib
        slibc = UserFixedPrecNet.slibc
        dlib = UserFixedPrecNet.dlib
        dlibc = UserFixedPrecNet.dlibc
        elib = UserFixedPrecNet.elib
        elibc = UserFixedPrecNet.elibc
        qlib = UserFixedPrecNet.qlib
        qlibc = UserFixedPrecNet.qlibc
        olib = UserFixedPrecNet.olib
        olibc = UserFixedPrecNet.olibc

    except:
        print("UserFixedPrecNet is not available")
        use_userfixedlib = False

    gui._set_has_userfixedlib(use_userfixedlib)




    try:
        #print("Start User")
        DllPath = gui.get_local_appdata_xlcalcnet() + r"\Bin\UserArbPrecNet.dll"
        #print(DllPath)
        clr.AddReference(DllPath)
        import UserArbPrecNet

        mlib = UserArbPrecNet.mlib
        mlibc = UserArbPrecNet.mlibc

        sflib = UserArbPrecNet.sflib
        sflibc = UserArbPrecNet.sflibc
        dflib = UserArbPrecNet.dflib
        dflibc = UserArbPrecNet.dflibc
        eflib = UserArbPrecNet.eflib
        eflibc = UserArbPrecNet.eflibc
        qflib = UserArbPrecNet.qflib
        qflibc = UserArbPrecNet.qflibc
        oflib = UserArbPrecNet.oflib
        oflibc = UserArbPrecNet.oflibc

        mflib = UserArbPrecNet.mflib
        mflibc = UserArbPrecNet.mflibc
        aflib = UserArbPrecNet.aflib
        aflibc = UserArbPrecNet.aflibc

    except:
        print("UserArbPrecNet is not available")
        use_userarblib = False

    gui._set_has_userarblib(use_userarblib)


    ctxlist_real = []
    try:
        ctxlist_real = [fpm, mpm, dpm, ipm]
        if use_gpm: ctxlist_real.append(gpm)
        if use_apm: ctxlist_real.append(apm)

        ctxlist_real += [math53, sreal, dreal, ereal, qreal, oreal]
        if use_xlcalcnet2: ctxlist_real += [mreal, sflint, dflint, eflint, qflint, oflint, \
            mflint, aflint]
    except:
        print("ctxlist_real is not available")

    gui._set_ctxlist_real(ctxlist_real)


    ctxlist_cplx = []
    try:
        ctxlist_cplx = [fpm, mpm, dpm, ipm]
        if use_gpm: ctxlist_cplx.append(gpm)
        if use_apm: ctxlist_cplx.append(apm)

        ctxlist_cplx += [cmath53, scplx, dcplx, ecplx, qcplx, ocplx]
        if use_xlcalcnet2: ctxlist_cplx += [mcplx, sflintc, dflintc, eflintc, qflintc, oflintc, \
            mflintc, aflintc]
    except:
        print("ctxlist_cplx is not available")

    gui._set_ctxlist_cplx(ctxlist_cplx)


    ctxlist_pm_user = []
    try:
        ctxlist_pm_user = [fpmlib, mpmlib, dpmlib, ipmlib]
        if use_gpm: ctxlist_pm_user.append(gpmlib)
        if use_apm: ctxlist_pm_user.append(apmlib)
    except:
        print("ctxlist_pm_user is not available")

    gui._set_ctxlist_pm_user(ctxlist_pm_user)


    ctxlist_real_user = []
    try:
        ctxlist_real_user = [m53lib, slib, dlib, elib, qlib, olib]
        if use_xlcalcnet2: ctxlist_real_user += [mlib, sflib, dflib, eflib, qflib, oflib, \
            mflib, aflib]
    except:
        print("ctxlist_real_user is not available")

    gui._set_ctxlist_real_user(ctxlist_real_user)


    ctxlist_cplx_user = []
    try:
        ctxlist_cplx_user += [m53libc, slibc, dlibc, elibc, qlibc, olibc]
        if use_xlcalcnet2: ctxlist_cplx_user += [mlibc, sflibc, dflibc, eflibc, qflibc, oflibc, \
            mflibc, aflibc]
    except:
        print("ctxlist_cplx_user is not available")

    gui._set_ctxlist_cplx_user(ctxlist_cplx_user)




    del use_apm, use_gpm, use_userarblib, use_userfixedlib, use_xlcalcnet2
    del ctxlist_real, ctxlist_cplx, ctxlist_pm_user, ctxlist_real_user, ctxlist_cplx_user




