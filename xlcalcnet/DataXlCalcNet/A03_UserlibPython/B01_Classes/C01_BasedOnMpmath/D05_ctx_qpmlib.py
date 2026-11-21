"""
Do not change the filename
Do not change the name of the class
"""

from xlcalcnet import qpm

class qpmlib():
    """ a numerical class in arbitrary precision """

    # %% General functions

    def __init__(self):
        pass

    @property
    def name(self):
        return "qpmlib"

    @property
    def fmtname(self):
        return " qpmlib"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        return qpm.fmt(z)



    def abs(self, z):
        return qpm.fabs(z)


