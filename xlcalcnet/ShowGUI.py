# -*- coding: utf-8 -*-
"""
Spyder Editor
"""


import os
import ctypes
import ctypes.wintypes


class NoConvergence(Exception):
    pass



class gui():

    # %% General functions

    _has_gpm = False
    _has_apm = False
    _has_xlcalcnet2 = False
    _has_userfixedlib = False
    _has_userarblib = False

    _ArbPrec = None
    _ctxlist_real = []
    _ctxlist_cplx = []
    _ctxlist_pm_user = []
    _ctxlist_real_user = []
    _ctxlist_cplx_user = []

    def __init__(self):
        pass


    def _set_has_gpm(self, has_gpm):
        self._has_gpm = has_gpm

    @property
    def has_gpm(self):
        return self._has_gpm


    def _set_has_apm(self, has_apm):
        self._has_apm = has_apm

    @property
    def has_apm(self):
        return self._has_apm


    def _set_has_xlcalcnet2(self, has_xlcalcnet2):
        self._has_xlcalcnet2 = has_xlcalcnet2

    @property
    def has_xlcalcnet2(self):
        return self._has_xlcalcnet2


    def _set_has_userfixedlib(self, has_userfixedlib):
        self._has_userfixedlib = has_userfixedlib

    @property
    def has_userfixedlib(self):
        return self._has_userfixedlib


    def _set_has_userarblib(self, has_userarblib):
        self._has_userarblib = has_userarblib

    @property
    def has_userarblib(self):
        return self._has_userarblib


    def _set_ArbPrec(self, ArbPrec):
        self._ArbPrec = ArbPrec



    def _set_ctxlist_real(self, ctxlist_real):
        self._ctxlist_real = ctxlist_real

    @property
    def ctxlist_real(self):
        return self._ctxlist_real


    def _set_ctxlist_cplx(self, ctxlist_cplx):
        self._ctxlist_cplx = ctxlist_cplx

    @property
    def ctxlist_cplx(self):
        return self._ctxlist_cplx



    def _set_ctxlist_pm_user(self, ctxlist_pm_user):
        self._ctxlist_pm_user = ctxlist_pm_user

    @property
    def ctxlist_pm_user(self):
        return self._ctxlist_pm_user



    def _set_ctxlist_real_user(self, ctxlist_real_user):
        self._ctxlist_real_user = ctxlist_real_user

    @property
    def ctxlist_real_user(self):
        return self._ctxlist_real_user


    def _set_ctxlist_cplx_user(self, ctxlist_cplx_user):
        self._ctxlist_cplx_user = ctxlist_cplx_user

    @property
    def ctxlist_cplx_user(self):
        return self._ctxlist_cplx_user


    def setdps(self, dps):
        for ctx in self._ctxlist_real:
            if len(ctx.name)==3: ctx.dps=dps
        if self._ArbPrec is not None: self._ArbPrec.SetDps(dps)



    # adapted from userpaths
    # These constants are defined in the Windows API's shlobj.h.
    # For reference: MinGW-w64's mingw-w64-headers/include/shlobj.h

    # Constant special item ID list values for special folders
    CSIDL_APPDATA = 0x001a
    CSIDL_DESKTOPDIRECTORY = 0x0010
    CSIDL_LOCAL_APPDATA = 0x001c
    CSIDL_MYMUSIC = 0x000d
    CSIDL_MYPICTURES = 0x0027
    CSIDL_MYVIDEO = 0x000e
    CSIDL_PERSONAL = 0x0005
    CSIDL_PROFILE = 0x0028

    # Flags for SHGetFolderPath
    SHGFP_TYPE_CURRENT = 0
    SHGFP_TYPE_DEFAULT = 1

    # Convenient shorthand for this function
    SHGetFolderPathW = ctypes.windll.shell32.SHGetFolderPathW




    def _get_folder_path(self, csidl):
        """Get the path of a folder identified by a CSIDL value."""

        # Create a buffer to hold the return value from SHGetFolderPathW
        buf = ctypes.create_unicode_buffer(ctypes.wintypes.MAX_PATH)

        # Return the path as a string
        self.SHGetFolderPathW(None, csidl, None, self.SHGFP_TYPE_CURRENT, buf)
        return str(buf.value)


    def get_appdata(self):
        """Return the current user's roaming Application Data folder."""
        return self._get_folder_path(self.CSIDL_APPDATA)

    def get_desktop(self):
        """Return the current user's Desktop folder."""
        return self._get_folder_path(self.CSIDL_DESKTOPDIRECTORY)

    def get_downloads(self):
        """Return the current user's Downloads folder."""
        # There is no CSIDL value for this folder. The SHGetKnownFolderPath()
        # mechanism that replaces SHGetFolderPath() on Windows Vista and newer
        # provides FOLDERID_Downloads, but is not backwards-compatible.
        profile_downloads = os.path.join(get_profile(), "Downloads")
        my_docs_downloads = os.path.join(get_my_documents(), "Downloads")

        if os.path.exists(profile_downloads):
            # Windows Vista and newer
            return profile_downloads
        else:
            # Earlier versions of Windows
            return my_docs_downloads

    def get_local_appdata(self):
        """Return the current user's local Application Data folder."""
        return self._get_folder_path(self.CSIDL_LOCAL_APPDATA)

    def get_local_appdata_xlcalcnet(self):
        """Return the current user's local AppData/XlCalcNetIDE folder."""
        LocalAppData = self.get_local_appdata()
        return os.sep.join([LocalAppData, 'XlCalcNetIDE'])

    def get_my_documents(self):
        """Return the current user's My Documents folder."""
        return self._get_folder_path(self.CSIDL_PERSONAL)

    def get_my_music(self):
        """Return the current user's My Music folder."""
        return self._get_folder_path(self.CSIDL_MYMUSIC)

    def get_my_pictures(self):
        """Return the current user's My Pictures folder."""
        return self._get_folder_path(self.CSIDL_MYPICTURES)

    def get_my_videos(self):
        """Return the current user's My Videos folder."""
        return self._get_folder_path(self.CSIDL_MYVIDEO)

    def get_profile(self):
        """Return the current user's profile folder."""
        return self._get_folder_path(self.CSIDL_PROFILE)



    def info(self):
        from xlcalcnet import mpmath
        import platform
        import sys

        print("platform.system: ", platform.system())
        print("python version: ", sys.version)


        if (platform.system()=='Windows'):

            try:
                import clr
                print ("pythonnet version: ", clr.__version__)
            except:
                print("pythonnet is not available")

            try:
                import FixedPrecNet
                print ("FixedPrecNet version: ", "1.0.0")
            except:
                print("FixedPrecNet is not available")

            try:
                import ArbPrecNet
                print ("ArbPrecNet version: ", "1.0.0")
            except:
                print("ArbPrecNet is not available")



        try:
            import numpy
            print ("numpy version: ", numpy.version.version)
        except:
            print("numpy is not available")

        try:
            import matplotlib
            print ("matplotlib version: ", matplotlib.__version__)
        except:
            print("matplotlib is not available")

        try:
            import scipy
            print ("scipy version: ", scipy.version.version)
        except:
            print("scipy is not available")

        try:
            import gmpy2
            print ("gmpy2 version: ",gmpy2.version(), "(" + gmpy2.mp_version() \
                +", " + gmpy2.mpfr_version() + ", " + gmpy2.mpc_version() + ")")
        except:
            print("gmpy2 is not available")

        try:
            import flint
            print ("python-flint version: ", flint.__version__)
        except:
            print("flint is not available")






    def get_date_time_stamp(self):
        import time
        from datetime import datetime
        d = datetime.today().strftime('%Y_%m_%d__%H_%M_%S__')
        t = str(time.time_ns())
        return d + t



    def adduserpath(self, userpath=""):
        import sys
        import os

        if (userpath==""):
            MyDocs = self.get_my_documents()
            userpath = os.sep.join([MyDocs, 'DataXlCalcNet'])
        addpath = userpath.split(',')
        for newpath in addpath:
            if not newpath in sys.path:
                sys.path.insert(0, newpath)  # Add to search path



    def plot(self, fig, file, fname):
        import sys
        import pathlib
        import os
        import pickle
        import subprocess
        import warnings
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        LocalAppData = self.get_local_appdata()
        tempdir = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp'])
        if not os.path.exists(tempdir): os.makedirs(tempdir)
        fdumpname = os.sep.join([tempdir, self.get_date_time_stamp() + ".plt"])
        print("fdumpname: ", fdumpname)
        with open(fdumpname, 'wb') as file:
            pickle.dump(fig, file)
        PgmExe = sys.executable
        currentdirname = str(pathlib.Path(str(__file__)).parent.resolve())
        PgmPy = os.sep.join([currentdirname, 'ShowPlt2.py'])
        print("PgmExe: ", PgmExe)
        print("PgmPy: ", PgmPy)
        args = [PgmExe, PgmPy, fdumpname, fname]
        popen = Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)
        with warnings.catch_warnings():
            warnings.simplefilter("ignore")
            popen.returncode = 0
            del popen



    def getplt(self):
        import matplotlib.pyplot as plt
        return plt




## from xlcalcnet import gui; gui.idle()

    def idle(self):
        import sys
        import pathlib
        import os
        import subprocess
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        PgmExe = sys.executable
        TempPathName = str(pathlib.Path(str(PgmExe)).parent.resolve())
        PgmExe = os.sep.join([TempPathName, 'pythonw.exe'])
        PgmPy = os.sep.join([TempPathName, 'Lib', 'idlelib', 'idle.pyw'])
        LocalDir = self.get_my_documents()
        LocalDir = os.sep.join([LocalDir, 'DataXlCalcNet'])
##        print("PgmExe: ", PgmExe)
##        print("PgmPy: ", PgmPy)
##        print("LocalDir: ", LocalDir)
        args = [PgmExe, PgmPy]
        Popen(args, cwd=LocalDir, \
          creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)






## from xlcalcnet import gui; gui.tinyide()

    def tinyide(self):
        import sys
        import pathlib
        import os
        import subprocess
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        LocalAppData = self.get_local_appdata()
        tempdir = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp'])
        if not os.path.exists(tempdir): os.makedirs(tempdir)
        PgmExe = sys.executable
        currentdirname = str(pathlib.Path(str(__file__)).parent.resolve())
        PgmPy = os.sep.join([currentdirname, 'ShowEditor.py'])
##        print("PgmExe: ", PgmExe)
##        print("PgmPy: ", PgmPy)
        args = [PgmExe, PgmPy]
        Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)




## from xlcalcnet import gui; gui.socketserver()

    def socketserver(self):
        import sys
        import pathlib
        import os
        import subprocess
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        LocalAppData = self.get_local_appdata()
        tempdir = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp'])
        if not os.path.exists(tempdir): os.makedirs(tempdir)
        PgmExe = sys.executable
        currentdirname = str(pathlib.Path(str(__file__)).parent.resolve())
        PgmPy = os.sep.join([currentdirname, 'Addin', 'NET48', 'Bin', 'socketspy.py'])
##        print("PgmExe: ", PgmExe)
##        print("PgmPy: ", PgmPy)
        args = [PgmExe, PgmPy]
        Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE, \
          shell=True)




## from xlcalcnet import gui; gui.output()

    def outputmonitor(self):
        import sys
        import pathlib
        import os
        import subprocess
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        LocalAppData = self.get_local_appdata()
        tempdir = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp'])
        if not os.path.exists(tempdir): os.makedirs(tempdir)
        PgmExe = sys.executable
        currentdirname = str(pathlib.Path(str(__file__)).parent.resolve())
        PgmPy = os.sep.join([currentdirname, 'ShowOutputMonitor.py'])
##        print("PgmExe: ", PgmExe)
##        print("PgmPy: ", PgmPy)
        args = [PgmExe, PgmPy]
        Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)



## from xlcalcnet import gui; gui.dataviewer()

    def dataviewer(self):
        import sys
        import pathlib
        import os
        import subprocess
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        LocalAppData = self.get_local_appdata()
        tempdir = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp'])
        if not os.path.exists(tempdir): os.makedirs(tempdir)
        PgmExe = sys.executable
        currentdirname = str(pathlib.Path(str(__file__)).parent.resolve())
        PgmPy = os.sep.join([currentdirname, 'ShowDataViewer.py'])
##        print("PgmExe: ", PgmExe)
##        print("PgmPy: ", PgmPy)
        args = [PgmExe, PgmPy]
        Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)



## from xlcalcnet import gui; gui.plot2d()

    def plot2d(self):
        import sys
        import pathlib
        import os
        import subprocess
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        LocalAppData = self.get_local_appdata()
        tempdir = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp'])
        if not os.path.exists(tempdir): os.makedirs(tempdir)
        PgmExe = sys.executable
        currentdirname = str(pathlib.Path(str(__file__)).parent.resolve())
        PgmPy = os.sep.join([currentdirname, 'ShowPlot2d.py'])
##        print("PgmExe: ", PgmExe)
##        print("PgmPy: ", PgmPy)
        args = [PgmExe, PgmPy]
        Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)



## from xlcalcnet import gui; gui.plot3d()

    def plot3d(self):
        import sys
        import pathlib
        import os
        import subprocess
        from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen
        LocalAppData = self.get_local_appdata()
        tempdir = os.sep.join([LocalAppData, 'XlCalcNetIDE', 'Temp'])
        if not os.path.exists(tempdir): os.makedirs(tempdir)
        PgmExe = sys.executable
        currentdirname = str(pathlib.Path(str(__file__)).parent.resolve())
        PgmPy = os.sep.join([currentdirname, 'ShowPlot3d.py'])
##        print("PgmExe: ", PgmExe)
##        print("PgmPy: ", PgmPy)
        args = [PgmExe, PgmPy]
        Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
          stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)


## from xlcalcnet import gui;gui.showdist_xlist(Title, xlist, distlist, funclist)

    def showdist_xlist(self, Title, xlist, distlist, funclist):
        print()
        print('<H1 Title="x argument: ' + Title + '">')
        for x in xlist:
            print("x: ", x)
            if ('pdf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': pdf(x=' +  str(x) + ') = ' \
                        + dist.ctx.fmt(dist.pdf(x)))
                print()
            if ('pmf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': pmf(x=' +  str(x) + ') = ' \
                        + dist.ctx.fmt(dist.pmf(x)))
                print()
            if ('cdf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': cdf(x=' +  str(x) + ') = ' \
                        + dist.ctx.fmt(dist.cdf(x)))
                print()
            if ('sf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': sf(x=' +  str(x) + ') = ' \
                        + dist.ctx.fmt(dist.sf(x)))
                print()
            if ('hf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': hf(x=' +  str(x) + ') = ' \
                        + dist.ctx.fmt(dist.hf(x)))
                print()
            if ('chf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': chf(x=' +  str(x) + ') = ' \
                        + dist.ctx.fmt(dist.chf(x)))
                print()
        print('</H1>')



    def showdist_qlist(self, Title, qlist, distlist, funclist):
        print()
        print('<H1 Title="q argument: ' + Title + '">')
        for q in qlist:
            print('q: ', q)
            if ('qtf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': qtf(x=' +  str(q) + ') = ' \
                        + dist.ctx.fmt(dist.qtf(q)))
                print()
            if ('isf' in funclist):
                for dist in distlist:
                    print(dist.ctx.name + ': isf(x=' +  str(q) + ') = ' \
                        + dist.ctx.fmt(dist.isf(q)))
        print('</H1>')



    def showdist_list(self, Title, distlist, funclist):
        print()
        print('<H1 Title="no argument: ' + Title + '">')
        if ('mean' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': mean = '  + dist.ctx.fmt(dist.mean()))
            print()
        if ('median' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': median = '  + dist.ctx.fmt(dist.median()))
            print()
        if ('mode' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': mode = '  + dist.ctx.fmt(dist.mode()))
            print()
        if ('variance' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': variance = '  \
                    + dist.ctx.fmt(dist.variance()))
            print()
        if ('stdev' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': stdev = '  \
                    + dist.ctx.fmt(dist.stdev()))
            print()
        if ('skewness' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': skewness = '  \
                    + dist.ctx.fmt(dist.skewness()))
            print()
        if ('kurtosis' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': kurtosis = '  \
                    + dist.ctx.fmt(dist.kurtosis()))
            print()
        if ('kurtosis_excess' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': kurtosis_excess = '  \
                    + dist.ctx.fmt(dist.kurtosis_excess()))
            print()
        if ('supportleft' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': supportleft = '  \
                    + dist.ctx.fmt(dist.supportleft()))
            print()
        if ('supportright' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': supportright = '  \
                    + dist.ctx.fmt(dist.supportright()))
            print()
        if ('rangeleft' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': rangeleft = '  \
                    + dist.ctx.fmt(dist.rangeleft()))
            print()
        if ('rangeright' in funclist):
            for dist in distlist:
                print(dist.ctx.name + ': rangeright = '  \
                    + dist.ctx.fmt(dist.rangeright()))
            print('</H1>')



    def funcplot2d(self, ctx, f, xlim=[-5,5], ylim=None, points=200, dpi=None, singularities=[], axes=None):
        import matplotlib.pyplot as plt
        from xlcalcnet import fpm
        plot_ignore = (ValueError, ArithmeticError, ZeroDivisionError, NoConvergence)
        fig = None
        if not axes:
            fig = plt.figure()
            axes = fig.add_subplot(111)
        if not isinstance(f, (tuple, list)):
            f = [f]
        a, b = xlim
        colors = ['b', 'r', 'g', 'm', 'k']
        for n, func in enumerate(f):
            #x = ctx.arange(a, b, (b-a)/float(points))
            x = fpm.arange(a, b, (b-a)/float(points))
            segments = []
            segment = []
            in_complex = False
            for i in range(len(x)):
                try:
                    if i != 0:
                        for sing in singularities:
                            if x[i-1] <= sing and x[i] >= sing:
                                raise ValueError
                    v = func(x[i])
                    if ctx.isnan(v) or abs(v) > 1e300:
                        raise ValueError
                    if hasattr(v, "imag") and v.imag:
                        re = float(v.real)
                        im = float(v.imag)
                        if not in_complex:
                            in_complex = True
                            segments.append(segment)
                            segment = []
                        segment.append((float(x[i]), re, im))
                    else:
                        if in_complex:
                            in_complex = False
                            segments.append(segment)
                            segment = []
                        if hasattr(v, "real"):
                            v = v.real
                        segment.append((float(x[i]), v))
                except plot_ignore:
                    if segment:
                        segments.append(segment)
                    segment = []
            if segment:
                segments.append(segment)
            for segment in segments:
                x = [s[0] for s in segment]
                y = [s[1] for s in segment]
                if not x:
                    continue
                c = colors[n % len(colors)]
                if len(segment[0]) == 3:
                    z = [s[2] for s in segment]
                    axes.plot(x, y, '--'+c, linewidth=3)
                    axes.plot(x, z, ':'+c, linewidth=3)
                else:
                    axes.plot(x, y, c, linewidth=3)
        axes.set_xlim([float(_) for _ in xlim])
        if ylim:
            axes.set_ylim([float(_) for _ in ylim])
        axes.set_xlabel('x')
        axes.set_ylabel('f(x)')
        axes.grid(True)

        plt.show()
        #self.plot(self, fig, __file__, 'Function Plot 2D')
        #self.plot(fig, __file__, 'Function Plot 2D')
        plt.close("all")


