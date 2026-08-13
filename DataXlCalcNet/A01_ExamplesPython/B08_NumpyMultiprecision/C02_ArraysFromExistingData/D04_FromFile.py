
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_from_file()



def demo_from_file():
    print()

    # Construct an ndarray:
    dt = np.dtype([('time', [('min', np.int64), ('sec', np.int64)]), ('temp', float)])
    x = np.zeros((1,), dtype=dt)
    x['time']['min'] = 10; x['temp'] = 98.25
    print(x)

    # Save the raw data to disk:
    import tempfile
    fname = tempfile.mkstemp()[1]
    x.tofile(fname)

    # Read the raw data from disk:
    res = np.fromfile(fname, dtype=dt)
    print(res)

    # The recommended way to store and load data:
    np.save(fname, x)
    res = np.load(fname + '.npy')
    print(res)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




