"""
Do not change the filename
Do not change the name of the class
The python-flint library needs to be installed
"""

from xlcalcnet import apm

class apmlib():
    """ a numerical class in arbitrary precision """

    # %% General functions

    def __init__(self):
        pass

    @property
    def name(self):
        return "apmlib"

    @property
    def fmtname(self):
        return " apmlib"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        return apm.fmt(z)


    def real(self, z):
        return apm.real(z)


    def imag(self, z):
        return apm.imag(z)



    def abs(self, z):
        return apm.fabs(z)


    def sin(self, z):
        return apm.sin(z)

