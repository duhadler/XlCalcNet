

def list_ctx(ctxstr):
    from inspect import signature
    
    def getprop(ctx, ctxstr, prop):
        s = 'type(ctx).' + prop        
        return eval(s)

    if ctxstr == 'fpm': from xlcalcnet import fpm; ctx = fpm
    if ctxstr == 'mpm': from xlcalcnet import mpm; ctx = mpm
    if ctxstr == 'ipm': from xlcalcnet import ipm; ctx = ipm
    if ctxstr == 'dpm': from xlcalcnet import dpm; ctx = dpm
    if ctxstr == 'qpm': from xlcalcnet import qpm; ctx = qpm

    if ctxstr == 'gpm': from xlcalcnet import gpm; ctx = gpm
    if ctxstr == 'apm': from xlcalcnet import apm; ctx = apm
    if ctxstr == 'npm': from xlcalcnet import npm; ctx = npm
    
    rlist = dir(ctx)
    print('len(rlist): ', len(rlist))
    for name in rlist:
        if not (name.startswith('_') or name.endswith('_')):
            func = getattr(ctx, name)
            if callable(func):
                # relevant only for gpm and apm
                if (name != 'complextype') and (name != 'realtype'):
                    sig = signature(func)
                    print(name+'§M§', sig, func.__doc__)
                else:
                    print(name+'§M§', None, func.__doc__)
            else:
                res = getprop(ctx, ctxstr, name)
                print(name+'§P§', None, res.__doc__)


#list_ctx('fpm')

#list_ctx('mpm')

list_ctx('ipm')

#list_ctx('dpm')

#list_ctx('qpm')

#list_ctx('gpm')

#list_ctx('apm')

#list_ctx('npm')

#rv = mpm.dist_arcsine(0,1)
#help(rv)

