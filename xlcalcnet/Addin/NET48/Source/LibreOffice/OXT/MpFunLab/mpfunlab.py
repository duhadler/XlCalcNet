# -*- coding: utf-8 -*-
import sys
import os
import platform
import math 
from itertools import zip_longest
import uno
import unohelper
from com.duhadler.release.MpFunlab import XMpFunlab 


def reformat(Formula):
    FinalString = ""
    FLines = Formula.split(r"$n")
    for FLine in FLines:
        FLineList = FLine.split(r"$t")
        FLen = len(FLineList) - 1
        FLine = FLineList[FLen]
        FLine = FLine.strip()
        if FLen > 0:
            for i in range(FLen):
                FinalString += '\t'
        FinalString += FLine + '\n'
    return FinalString



def maketuple_old(P1):
    if isinstance(P1, str):
        return tuple([[P1]])
    if hasattr(P1, '__iter__'):
        if isinstance(P1[0], str):
            return tuple([P1])
        elif hasattr(P1[0], '__iter__'):
            return tuple(P1)
        else:
            return tuple([P1])
    else:
        return tuple([[P1]])
    return tuple([["Error: returned value needs to be a scalar, a vector, or a matrix"]])



def rxc(P1):
    if isinstance(P1, str):
        return 'R1xC1'
    if hasattr(P1, '__iter__'):
        if isinstance(P1[0], str):
            return 'R1xC' + str(len(P1))
        elif hasattr(P1[0], '__iter__'):
            return 'R' + str(len(P1)) + 'xC' + str(len(P1[0]))
        else:
            return 'R1xC' + str(len(P1))
    else:
        return 'R1xC1'
    return "Error: input is not a scalar, a vector, or a matrix"



def maketuple(P1, Transposed_, ShowShape_):
    Transposed = False
    ShowShape = False
    if isinstance(Transposed, bool): Transposed = Transposed_
    if isinstance(ShowShape_, bool): ShowShape = ShowShape_
    if isinstance(Transposed_, float):
        if Transposed_ == 0:
            #print("Transposed_")
            Transposed = False
        else: Transposed = True
    if isinstance(ShowShape_, float):
        if ShowShape_ == 0:
            #print("ShowShape_")
            ShowShape = False
        else: ShowShape = True
    res = None
    if isinstance(P1, str):
        res = [[P1]]
    elif hasattr(P1, '__iter__'):
        if isinstance(P1[0], str):
            res = [P1]
        elif hasattr(P1[0], '__iter__'):
            res = P1
        else:
            res = [P1]
    else:
        res = [[P1]]
    if Transposed:
        tt = zip_longest(*res, fillvalue=None)
        ttl = list(tt)
        res = [list(sublist) for sublist in ttl]
    if ShowShape:
        ShapeStr = rxc(res) + '| '
        res[0][0] = ShapeStr + str(res[0][0])
    return tuple(res)




class MpFunlabImpl(unohelper.Base, XMpFunlab):
    def __init__(self, ctx):
        self.ctx = ctx
        self.smgr = ctx.getServiceManager()
        self.mspf = self.smgr.createInstanceWithContext('com.sun.star.script.provider.MasterScriptProviderFactory', ctx)
        self.scriptPro = self.mspf.createScriptProvider('')
        self.scriptName = 'vnd.sun.star.script:MpFunLabWin.Module1.BasicFromPython?language=Basic&location=application'
        self.script = self.scriptPro.getScript(self.scriptName)
        
        args = ("path", "path")
        res = self.script.invoke(args, (), ())[0]
        GetPythonPath = str(res)
        addpath = GetPythonPath.split(',')	
        for newpath in addpath:
            if not newpath in sys.path:
                sys.path.insert(0, newpath)  # Add to search path



    def asdouble(self, MpString):
        try:
            Formula = "result = float(" + MpString + ")"
            Formula = reformat(Formula)
            localdict = dict()
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'])
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy0(self, Formula, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict()
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy1(self, Formula, Param1, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy2(self, Formula, Param1, Param2, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy3(self, Formula, Param1, Param2, Param3, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2), ('P3', Param3)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy4(self, Formula, Param1, Param2, Param3, Param4, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2), ('P3', Param3), ('P4', Param4)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy5(self, Formula, Param1, Param2, Param3, Param4, Param5, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2), ('P3', Param3), ('P4', Param4), ('P5', Param5)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy6(self, Formula, Param1, Param2, Param3, Param4, Param5, Param6, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2), ('P3', Param3), ('P4', Param4), ('P5', Param5), ('P6', Param6)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy7(self, Formula, Param1, Param2, Param3, Param4, Param5, Param6, Param7, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2), ('P3', Param3), ('P4', Param4), ('P5', Param5), ('P6', Param6), ('P7', Param7)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy8(self, Formula, Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2), ('P3', Param3), ('P4', Param4), ('P5', Param5), ('P6', Param6), ('P7', Param7), ('P8', Param8)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])


    def apy9(self, Formula, Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Transposed, ShowShape):
        try:
            Formula = reformat(Formula)
            localdict = dict([('P1', Param1), ('P2', Param2), ('P3', Param3), ('P4', Param4), ('P5', Param5), ('P6', Param6), ('P7', Param7), ('P8', Param8), ('P9', Param9)])
            exec(Formula, globals(), localdict)
            return maketuple(localdict['result'], Transposed, ShowShape)
        except Exception as e:
            return  tuple([['Exception: ' + str(e)]])













def createInstance(ctx):
    return MpFunlabImpl(ctx)

g_ImplementationHelper = unohelper.ImplementationHelper()
g_ImplementationHelper.addImplementation(\
    createInstance,"com.duhadler.release.MpFunlab.python.MpFunlabImpl",
        ("com.sun.star.sheet.AddIn",),)


