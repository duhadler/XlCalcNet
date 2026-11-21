"""
Do not change the filename
Do not change the name of the class
"""


from xlcalcnet import ipm

class ipmlib():
    """ a numerical class in arbitrary precision """

    # %% General functions

    def __init__(self):
        pass

    @property
    def name(self):
        return "ipmlib"

    @property
    def fmtname(self):
        return " ipmlib"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        return ipm.fmt(z)


    def real(self, z):
        return ipm.real(z)


    def imag(self, z):
        return ipm.imag(z)



    def abs(self, z):
        return ipm.fabs(z)


    def sin(self, z):
        return ipm.sin(z)

