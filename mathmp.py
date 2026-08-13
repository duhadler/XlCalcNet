

#from xlcalcnet.mpmath import mp
from xlcalcnet import mathstr

def convert(x, y=None):
    return mathstr.t_mpm(x, y)


def show(items, aligned=True):
    mathstr.show(items, aligned)



def name():
    return "mpm2"


