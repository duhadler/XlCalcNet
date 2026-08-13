

from flint import arb, acb
from xlcalcnet import mathstr



def convert(x, y=None):
    return mathstr.t_apm(x, y)


def t(x, y=None):
    return mathstr.t_apm(x, y)


def show(items, aligned=True):
    #self.show2(items, aligned)
    mathstr.show(items, aligned)

def name():
    return "rpm2"



def get_conj(z):
    #z = self.t(z)
    return acb(z).conjugate()


def get_ldexp(z, k):
    #z = self.t(z)
    return arb.nan()

def get_frexp(z):
    #z = self.t(z)
    return arb.nan()

