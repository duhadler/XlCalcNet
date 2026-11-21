"""
Do not change the filename
Do not change the name of the class
"""

from xlcalcnet import mpm

class mpmlib():
    """ a numerical class in arbitrary precision """

    # %% General functions

    def __init__(self):
        pass

    @property
    def name(self):
        return "mpmlib"

    @property
    def fmtname(self):
        return " mpmlib"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        return mpm.fmt(z)


    def real(self, z):
        return mpm.real(z)


    def imag(self, z):
        return mpm.imag(z)


    def abs(self, z):
        return mpm.fabs(z)


    def sin(self, z):
        return mpm.sin(z)


