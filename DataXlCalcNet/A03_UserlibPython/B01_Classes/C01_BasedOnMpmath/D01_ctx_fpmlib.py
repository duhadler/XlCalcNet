"""
Do not change the filename
Do not change the name of the class
"""

from xlcalcnet import fpm

class fpmlib():
    """ a numerical class in arbitrary precision """

    # %% General functions

    def __init__(self):
        pass

    @property
    def name(self):
        return "fpmlib"

    @property
    def fmtname(self):
        return " fpmlib"
               #genlib1

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        return fpm.fmt(z)



    def real(self, z):
        return fpm.real(z)


    def imag(self, z):
        return fpm.imag(z)


    def abs(self, z):
        return fpm.fabs(z)


    def sin(self, z):
        return fpm.sin(z)

