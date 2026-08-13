"""
Do not change the filename
Do not change the name of the class
The gmpy2 library needs to be installed
"""

from xlcalcnet import gpm

class gpmlib():
    """ a numerical class in arbitrary precision """

    # %% General functions

    def __init__(self):
        pass

    @property
    def name(self):
        return "gpmlib"

    @property
    def fmtname(self):
        return " gpmlib"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        return gpm.fmt(z)


    def real(self, z):
        return gpm.real(z)


    def imag(self, z):
        return gpm.imag(z)



    def abs(self, z):
        return gpm.fabs(z)


    def sin(self, z):
        return gpm.sin(z)


