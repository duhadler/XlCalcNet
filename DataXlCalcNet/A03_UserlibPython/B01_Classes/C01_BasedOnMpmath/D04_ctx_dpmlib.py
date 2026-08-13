"""
Do not change the filename
Do not change the name of the class
"""

from xlcalcnet import dpm

class dpmlib():
    """ a numerical class in arbitrary precision """

    # %% General functions

    def __init__(self):
        pass

    @property
    def name(self):
        return "dpmlib"

    @property
    def fmtname(self):
        return " dpmlib"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        return dpm.fmt(z)


    def real(self, z):
        return dpm.real(z)


    def imag(self, z):
        return dpm.imag(z)



    def abs(self, z):
        return dpm.fabs(z)


    def sin(self, z):
        return dpm.sin(z)


