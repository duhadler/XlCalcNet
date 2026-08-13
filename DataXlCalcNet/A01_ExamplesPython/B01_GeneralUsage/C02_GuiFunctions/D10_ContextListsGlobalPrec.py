from xlcalcnet import gui


def demo_context_lists():
    print('ctxlistreal:')
    for ctx in gui.ctxlistreal:
        print(ctx.name)
    print()
    print('ctxlistcplx:')
    for ctx in gui.ctxlistcplx:
        print(ctx.name)

def demo_global_prec():
    from xlcalcnet import mpm, dpm
    dps = 40
    print('dps:', dps)
    gui.setdps(dps)
    print('mpm.sqrt(2)', mpm.sqrt(2))
    print('dpm.sqrt(2)', dpm.sqrt(2))


try:
    #demo_context_lists()
    demo_global_prec()

except Exception:
    import traceback
    print(traceback.format_exc())


