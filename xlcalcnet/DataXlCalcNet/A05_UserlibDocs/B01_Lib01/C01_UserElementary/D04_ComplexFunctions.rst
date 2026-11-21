

.. |newpage| raw:: latex

   \newpage


.. |cr| raw:: latex

   \hspace{0.0mm}





|newpage|

Complex functions
===============================================================================




.. _rst_mpm_quadratic_equation_roots: 

Roots of a quadratic equation
-------------------------------------------------------------------------------

.. method:: ctx.quadratic_equation(A, B, C)

    Returns the roots `x_1, x_2`  of the quadratic equation `A x^2 + B x + C = 0`. See also Wikipedia :cite:p:`WikipediaAlg02`, :cite:t:`Press2007`.  

    See also: https://dlmf.nist.gov/1.11#iii


    .. math :: x_1 = \frac{Q}{A}, \quad x_2 = \frac{C}{Q}, \quad \text{where }  Q = -\frac{1}{2} \left(B + \sqrt{B^2 - 4AC}) \right)

    The sign of the square root is chosen so as to make `\displaystyle \Re(B^* \sqrt{B^2 - 4AC}) \ge 0`, where the asterisk denotes complex conjugation.




    An example with real input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, ipm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> \mathrm{d}x = dec.nthroot(x, n); mx = mpm.nthroot(x, n); ix = ipm.nthroot(x, n)
        >>> mpm.show([\mathrm{d}x, mx, ix])
        dec:  5.000000000000000000000000000000000000000E+0
        mpm:  5.000000000000000000000000000000000000000e+0
        ipm:  5.000000000000000000000000000000000000000e+0 (2.755e-39%)

        >>> from xlcalcnet import mpm, fpm, gmp, apm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> fx = fpm.nthroot(x, n); gx = gmp.nthroot(x, n); ax = apm.nthroot(x, n)
        >>> mpm.show([fx, gx, ax])
        fpm:  5.00000000000000E+00
        gmp:  5.000000000000000000000000000000000000000E+00
        apm:  5.000000000000000000000000000000000000002e+0 (3.673e-39%)








.. _rst_mpm_cubic_equation_monic_roots: 

Roots of a monic cubic equation
-------------------------------------------------------------------------------

.. method:: ctx.cubic_equation_monic(a, b, c)

    Returns the roots `x_1, x_2, x_3` of the monic cubic equation `x^3 + a x^2 + b x + c = 0`. See also Wikipedia :cite:p:`WikipediaAlg03`, :cite:t:`Press2007`. 

    See also: https://dlmf.nist.gov/1.11#iii


    .. math :: Q = \frac{a^2 - 3b}{9}, \quad R = \frac{2a^3 - 9ab + 27c}{54}.

    If `Q` and `R` are real *and* `R^2 < Q^3`, then the cubic equation has three real roots, with `\displaystyle \theta = \arccos \left( R  Q^{-3/2} \right)`:

    .. math :: x_1 = -2 \sqrt{Q} \cos \left( \frac{\theta}{3} \right) - \frac{a}{3}, \quad  x_2 = -2 \sqrt{Q} \cos \left( \frac{\theta + 2\pi}{3} \right) - \frac{a}{3}, \quad  x_3 = -2 \sqrt{Q} \cos \left( \frac{\theta - 2\pi}{3} \right) - \frac{a}{3}.

    Otherwise, `\displaystyle A = - \left(R + \sqrt{R^2 - Q^3}) \right)^{1/3}`, where the sign of the square root is chosen so as to make `\displaystyle \Re(R^* \sqrt{R^2 - Q^3}) \ge 0`, and the asterisk denotes complex conjugation. Define `B = 0` if `A = 0` and `B = Q / A` if `A \ne 0`. Then the three roots are given by

    .. math :: x_1 = (A + B) - \frac{a}{3}, \quad  x_2 = -\frac{1}{2} (A + B) - \frac{a}{3} + i \frac{\sqrt{3}}{2} (A - B), \quad   x_3 = -\frac{1}{2} (A + B) - \frac{a}{3} - i \frac{\sqrt{3}}{2} (A - B).

    Note that `x_1` is real if `a, b, c` are real.


    An example with real input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, ipm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> \mathrm{d}x = dec.nthroot(x, n); mx = mpm.nthroot(x, n); ix = ipm.nthroot(x, n)
        >>> mpm.show([\mathrm{d}x, mx, ix])
        dec:  5.000000000000000000000000000000000000000E+0
        mpm:  5.000000000000000000000000000000000000000e+0
        ipm:  5.000000000000000000000000000000000000000e+0 (2.755e-39%)

        >>> from xlcalcnet import mpm, fpm, gmp, apm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> fx = fpm.nthroot(x, n); gx = gmp.nthroot(x, n); ax = apm.nthroot(x, n)
        >>> mpm.show([fx, gx, ax])
        fpm:  5.00000000000000E+00
        gmp:  5.000000000000000000000000000000000000000E+00
        apm:  5.000000000000000000000000000000000000002e+0 (3.673e-39%)





.. _rst_mpm_cubic_equation_roots: 

Roots of a cubic equation
-------------------------------------------------------------------------------

.. method:: ctx.cubic_equation(A, B, C, D)

    Returns the roots  `x_1, x_2, x_3` of the cubic equation `A x^3 + B x^2 + C x + D = 0`. See also Wikipedia :cite:p:`WikipediaAlg03`, :cite:t:`Press2007`.  

    See also: https://dlmf.nist.gov/1.11#iii


    This just calls :ref:`CubicEquationMonicRoots(z, a, b, c) <rst_mpm_cubic_equation_monic_roots>`   with `a = B / A, b = C / A, c = D / A`.





    An example with real input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, ipm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> \mathrm{d}x = dec.nthroot(x, n); mx = mpm.nthroot(x, n); ix = ipm.nthroot(x, n)
        >>> mpm.show([\mathrm{d}x, mx, ix])
        dec:  5.000000000000000000000000000000000000000E+0
        mpm:  5.000000000000000000000000000000000000000e+0
        ipm:  5.000000000000000000000000000000000000000e+0 (2.755e-39%)

        >>> from xlcalcnet import mpm, fpm, gmp, apm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> fx = fpm.nthroot(x, n); gx = gmp.nthroot(x, n); ax = apm.nthroot(x, n)
        >>> mpm.show([fx, gx, ax])
        fpm:  5.00000000000000E+00
        gmp:  5.000000000000000000000000000000000000000E+00
        apm:  5.000000000000000000000000000000000000002e+0 (3.673e-39%)







.. _rst_mpm_quartic_equation_roots: 

Roots of a quartic equation
-------------------------------------------------------------------------------

.. method:: ctx.quartic_equation(A, B, C, D, E)

    Returns the roots `x_1, x_2, x_3, x_4` of the quartic equation `A x^4 + B x^3 + C x^2 + D x + E = 0`.  See also Wikipedia :cite:p:`WikipediaAlg04`.

    See also: https://dlmf.nist.gov/1.11#iii


    Define  `\displaystyle a = \frac{-3 B^2}{8 A^2} + \frac{C}{A}, \quad b =  \frac{ B^3}{8 A^3} - \frac{BC}{2 A^2} + \frac{D}{A}, \quad c =  \frac{-3 B^4}{256 A^4} + \frac{CB^2}{16 A^3}  - \frac{BD}{4 A^2} + \frac{E}{A}, \quad V = \frac{B}{4 A}`. 



    If `b = 0` then 

    `\displaystyle x_1 = V + Z_1, \quad  x_2 = V - Z_1, \quad  x_3 = V + Z_2, \quad  x_4 = V - Z_2`,

    where `\displaystyle W = \sqrt{a^2 - 4c}, \quad  Z_1 = \sqrt{\tfrac{1}{2}(-a + W)}, \quad  Z_2 = \sqrt{\tfrac{1}{2}(-a - W)}`. 



    If `b \ne 0` then 

    `\displaystyle x_1 = V + \tfrac{1}{2}(W + Z_1), \quad  x_2 = V + \tfrac{1}{2}(W - Z_1), \quad  x_3 = V - \tfrac{1}{2}(W + Z_2), \quad  x_4 = V -\tfrac{1}{2}(W - Z_2)`, 

    where `\displaystyle W = \sqrt{a + 2y}, \quad  Z_1 = \sqrt{-3a - 2y - \frac{2b}{W}}, \quad  Z_2 = \sqrt{-3a - 2y + \frac{2b}{W}}`, 

    and `y` is any root of the monic cubic equation `\displaystyle y^3 + ey^2+ fy + g =0`, with `\displaystyle e = \frac{5a}{2}, \quad  f = 2 a^2 -c, \quad  g = \frac{a^3}{2} - \frac{a c}{2} - \frac{b^2}{8}`;

    `y` is calculated as the first root returned by :ref:`CubicEquationMonicRoots(y, e, f, g) <rst_mpm_cubic_equation_monic_roots>`.



    An example with real input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, ipm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> \mathrm{d}x = dec.nthroot(x, n); mx = mpm.nthroot(x, n); ix = ipm.nthroot(x, n)
        >>> mpm.show([\mathrm{d}x, mx, ix])
        dec:  5.000000000000000000000000000000000000000E+0
        mpm:  5.000000000000000000000000000000000000000e+0
        ipm:  5.000000000000000000000000000000000000000e+0 (2.755e-39%)

        >>> from xlcalcnet import mpm, fpm, gmp, apm
        >>> mpm.dps = 40; x = '125'; n = '3'
        >>> fx = fpm.nthroot(x, n); gx = gmp.nthroot(x, n); ax = apm.nthroot(x, n)
        >>> mpm.show([fx, gx, ax])
        fpm:  5.00000000000000E+00
        gmp:  5.000000000000000000000000000000000000000E+00
        apm:  5.000000000000000000000000000000000000002e+0 (3.673e-39%)







Complex error function, `\mathrm{erf}(x)`
-------------------------------------------------------------------------------

.. method:: ctx.cplxerf(x)

    where ``ctx`` is ``math53``, ``mathc53``, ``ctxboost``, ``ctxflint``.


    Returns the real error function `\displaystyle \mathrm{erf}(x) = \frac{2}{\sqrt \pi} \int_0^x \exp(-t^2) \mathrm{d}t`. See also BoostMath :cite:p:`BoostFun84`, BoostMath :cite:p:`BoostFun07`, Wikipedia :cite:p:`WikipediaFun07`, MathWorld :cite:p:`WolframFun07a`, NIST :cite:p:`DLMFun07`, :cite:t:`Ehrhardt2018` (4.2.32), Flint :cite:p:`FlintFun07`, Flint :cite:p:`FlintFun08`, Mpmath :cite:p:`MpmathFun07`.


    See also: https://de.mathworks.com/matlabcentral/fileexchange/94785-faddeeva

    See also: https://github.com/sms03snc/Faddeeva

    See also: Al Azah, Changler-Wilde, 2021


    This function returns the value of the error function defined by

    .. math :: \text{erf}(z) = \frac{2}{\sqrt{\pi}} \int_0^x e^{-z^2} \mathrm{d}t,




    |08a_TestErf_re| `\quad` |08b_TestErf_im| `\quad` |08c_TestErf_abs|

    .. |08a_TestErf_re| image:: ../_static/UserPics/08a_TestErf_re.3D.xml.jpg
       :width: 30 %

    .. |08b_TestErf_im| image:: ../_static/UserPics/08b_TestErf_im.3D.xml.jpg
       :width: 30 %

    .. |08c_TestErf_abs| image:: ../_static/UserPics/08c_TestErf_abs.3D.xml.jpg
       :width: 30 %



    **Left figure**: real part of the Erf function. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.


    **Middle figure**: imaginary part of the Erf function. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.


    **Right figure**:  absolute value of the Erf function, with color-coded phase. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.





    An example in Python

    .. code-block:: pycon

        >>> from xlcalcnet import xreal
        >>> xreal.Dawson(0.5)
        xreal('5.2359877559829887307E-1')
        >>> xreal.Dawson('0.51')
        xreal('5.3518479027559984754E-1')


    An example in Visual Basic 

    .. code-block:: pycon

        >>> from xlcalcnet import Gpr
        >>> Gpr.Dawson(0.5)
        Gpr('5.2359877559829887307E-1')
        >>> Gpr.Dawson('0.51')
        Gpr('5.3518479027559984754E-1')


    An example with real input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, gmp, fpm, apm
        >>> mpm.dps = 40; x = 3.0
        >>> \mathrm{d}x = dec.erf(x); mx = mpm.erf(x); gx = gmp.erf(x)
        >>> fx = fpm.erf(x); ax = apm.erf(x)
        >>> mpm.show([\mathrm{d}x, mx, gx, fx, ax])
        dec:  9.999779095030014145586272238704176796201E-1
        mpm:  9.999779095030014145586272238704176796201e-1
        gmp:  9.999779095030014145586272238704176796201E-01
        fpm:  9.99977909503001E-01
        apm:  9.999779095030014145586272238704176796202e-1 (5.74e-40%)


    An example with complex input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, gmp, fpm, apm
        >>> mpm.dps = 20; z = '3.0 + 4.0j'
        >>> \mathrm{d}z = dec.erf(z); mz = mpm.erf(z); gz = gmp.erf(z)
        >>> fz = fpm.erf(z); az = apm.erf(z)
        >>> mpm.show([\mathrm{d}z, mz, gz, fz, az], aligned=True)
        dec: -1.2018699139507944410E+2               - 2.7750337293623902498E+1j
        mpm: -1.2018699139507944410e+2               - 2.7750337293623902498e+1j
        gmp: -1.2018699139507944410E+02              - 2.7750337293623902498E+01j
        fpm: -1.20186991395079E+02                   - 2.77503372936239E+01j
        apm: -1.2018699139507944410e+2 (-9.021e-20%) - 2.7750337293623902498e+1 (-4.884e-20%)j







Complex complementary error function, `\mathrm{erfc}(x)`
-------------------------------------------------------------------------------------

.. method:: ctx.cplxerfc(x)

    where ``ctx`` is ``math53``, ``mathc53``, ``ctxboost``, ``ctxflint``.


    Returns the complementary  error function `\displaystyle \mathrm{erfc}(x) = 1-\mathrm{erf}(x) = \frac{2}{\sqrt \pi} \int_x^{\infty} \exp(-t^2)\, \mathrm{d}t`. 

    See also BoostMath :cite:p:`BoostFun07`, Wikipedia :cite:p:`WikipediaFun07a`, MathWorld :cite:p:`WolframFun07b`, NIST :cite:p:`DLMFun07`, MathWorld :cite:p:`WolframFun187`, :cite:t:`Ehrhardt2018` (3.3.5), :cite:t:`Ehrhardt2018` (4.2.33), Mpmath :cite:p:`MpmathFun07e`.


    Returns the value of the complementary error function defined by

    .. math :: \text{erfc}(x) = 1-\text{erfc}(x) = \frac{2}{\sqrt{\pi}} \int_x^\infty e^{-x^2} \mathrm{d}t,




    |09a_TestErfc_re| `\quad` |09b_TestErfc_im| `\quad` |09c_TestErfc_abs|

    .. |09a_TestErfc_re| image:: ../_static/UserPics/09a_TestErfc_re.3D.xml.jpg
       :width: 30 %

    .. |09b_TestErfc_im| image:: ../_static/UserPics/09b_TestErfc_im.3D.xml.jpg
       :width: 30 %

    .. |09c_TestErfc_abs| image:: ../_static/UserPics/09c_TestErfc_abs.3D.xml.jpg
       :width: 30 %



    **Left figure**: real part of the Erfc function. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.


    **Middle figure**: imaginary part of the Erfc function. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.


    **Right figure**:  absolute value of the Erfc function, with color-coded phase. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.





    An example in Python

    .. code-block:: pycon

        >>> from xlcalcnet import xreal
        >>> xreal.Erfc(0.5)
        xreal('5.2359877559829887307E-1')
        >>> xreal.Erfc('0.51')
        xreal('5.3518479027559984754E-1')


    An example in Visual Basic 

    .. code-block:: pycon

        >>> from xlcalcnet import Gpr
        >>> Gpr.Erfc(0.5)
        Gpr('5.2359877559829887307E-1')
        >>> Gpr.Erfc('0.51')
        Gpr('5.3518479027559984754E-1')


    An example with real input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, gmp, fpm, apm
        >>> mpm.dps = 40; x = 3.0
        >>> \mathrm{d}x = dec.erfc(x); mx = mpm.erfc(x); gx = gmp.erfc(x)
        >>> fx = fpm.erfc(x); ax = apm.erfc(x)
        >>> mpm.show([\mathrm{d}x, mx, gx, fx, ax])
        dec:  2.209049699858544137277612958232037984771E-5
        mpm:  2.209049699858544137277612958232037984771e-5
        gmp:  2.209049699858544137277612958232037984771E-05
        fpm:  2.20904969985854E-05
        apm:  2.209049699858544137277612958232037984771e-5 (1.586e-39%)


    An example with complex input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, gmp, fpm, apm
        >>> mpm.dps = 20; z = '3.0 + 4.0j'
        >>> \mathrm{d}z = dec.erfc(z); mz = mpm.erfc(z); gz = gmp.erfc(z)
        >>> fz = fpm.erfc(z); az = apm.erfc(z)
        >>> mpm.show([\mathrm{d}z, mz, gz, fz, az], aligned=True)
        dec: 1.2118699139507944410E+2              + 2.7750337293623902498E+1j
        mpm: 1.2118699139507944410e+2              + 2.7750337293623902498e+1j
        gmp: 1.2118699139507944410E+02             + 2.7750337293623902498E+01j
        fpm: 1.21186991395079E+02                  + 2.77503372936239E+01j
        apm: 1.2118699139507944410e+2 (8.947e-20%) + 2.7750337293623902498e+1 (4.884e-20%)j








.. _rst_mpm_cplxgamma: 

Complex Gamma function, `\Gamma(x)`
-------------------------------------------------------------------------------

.. method:: ctx.cplxgamma(x)

    where ``ctx`` is ``math53``, ``mathc53``, ``ctxboost``, ``ctxflint``.

    Returns the gamma function `\displaystyle \Gamma(x) = \int_0^{\infty} t^{x-1} e^{-t} \, \mathrm{d}t`, for any real or complex `x` with `\Re(x) > 0` and for `\Re(x) < 0` by analytic continuation.

    See also  Wikipedia :cite:p:`WikipediaFun75`, MathWorld :cite:p:`WolframFun75`, NIST :cite:p:`DLMFun75`,  BoostMath :cite:p:`BoostFun75`, :cite:t:`Ehrhardt2018` (3.5.1.1), :cite:t:`Ehrhardt2018` (4.2.38), Flint :cite:p:`FlintFun70`, Flint :cite:p:`FlintFun71`.


    This uses the implementation in Pugh, p. 125


    |03a_TestGamma_re| `\quad` |03b_TestGamma_im| `\quad` |03c_TestGamma_abs|

    .. |03a_TestGamma_re| image:: ../_static/UserPics/03a_TestGamma_re.3D.xml.jpg
       :width: 30 %

    .. |03b_TestGamma_im| image:: ../_static/UserPics/03b_TestGamma_im.3D.xml.jpg
       :width: 30 %

    .. |03c_TestGamma_abs| image:: ../_static/UserPics/03c_TestGamma_abs.3D.xml.jpg
       :width: 30 %



    **Left figure**: real part of the Gamma function. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.


    **Middle figure**: imaginary part of the Gamma function. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.


    **Right figure**:  absolute value of the Gamma function, with color-coded phase. Camera angles are `\theta=135^\circ` and `\phi = -12^\circ`, camera radius is -2.




    An example in Python

    .. code-block:: pycon

        >>> from xlcalcnet import xreal
        >>> xreal.Gamma(0.5)
        xreal('5.2359877559829887307E-1')
        >>> xreal.Gamma('0.51')
        xreal('5.3518479027559984754E-1')


    An example in Visual Basic 

    .. code-block:: pycon

        >>> from xlcalcnet import Gpr
        >>> Gpr.Gamma(0.5)
        Gpr('5.2359877559829887307E-1')
        >>> Gpr.Gamma('0.51')
        Gpr('5.3518479027559984754E-1')


    An example with real input:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, ipm
        >>> mpm.dps = 40; x = '10.5'
        >>> \mathrm{d}x = dec.gamma(x); mx = mpm.gamma(x); ix = ipm.gamma(x)
        >>> mpm.show([\mathrm{d}x, mx, ix])
        dec:  1.133278388948785567334574165588892475560E+6
        mpm:  1.133278388948785567334574165588892475560e+6
        ipm:  1.133278388948785567334574165588892475560e+6 (1.062e-39%)

        >>> from xlcalcnet import mpm, fpm, gmp, apm
        >>> mpm.dps = 40; x = '10.5'
        >>> fx = fpm.gamma(x); gx = gmp.gamma(x); ax = apm.gamma(x)
        >>> mpm.show([fx, gx, ax])
        fpm:  1.13327838894879E+06
        gmp:  1.133278388948785567334574165588892475560E+06
        apm:  1.133278388948785567334574165588892475560e+6 (1.062e-39%)


    The following example with complex input shows that the relative error can be high in double precision:

    .. code-block:: pycon

        >>> from xlcalcnet import dec, mpm, ipm
        >>> mpm.dps = 20; z = '10.2 + 1.5E-2j'
        >>> \mathrm{d}z = dec.gamma(z); mz = mpm.gamma(z); iz = ipm.gamma(z)
        >>> mpm.show([\mathrm{d}z, mz, iz], aligned=True)
        dec: 5.7016098526432799845E+5              + 1.9443478604345155482E+4j
        mpm: 5.7016098526432799845e+5              + 1.9443478604345155482e+4j
        ipm: 5.7016098526432799844e+5 (1.558e-18%) + 1.9443478604345155482e+4 (1.713e-18%)j

        >>> from xlcalcnet import mpm, fpm, gmp, apm
        >>> mpm.dps = 20; z = '10.2 + 1.5E-2j'
        >>> fz = fpm.gamma(z); gz = gmp.gamma(z); az = apm.gamma(z)
        >>> mpm.show([fz, gz, az], aligned=True)
        fpm: 5.70160985264316E+05                  + 1.94434786043447E+04j
        gmp: 5.7016098526432799845E+05             + 1.9443478604345155482E+04j
        apm: 5.7016098526432799845e+5 (4.284e-18%) + 1.9443478604345155482e+4 (8.065e-18%)j



    Arguments can also be large. Note that the gamma function grows very quickly:

    .. code-block:: pycon

        >>> from xlcalcnet import mp
        >>> mp.dps = 25; mp.pretty = True
        >>> mp.dps = 15
        >>> gamma(10**20)
        1.9328495143101e+1956570551809674817225








