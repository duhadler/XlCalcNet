"""
Description of this CPython module
"""

import numpy as np
import matplotlib as mpl
import matplotlib.pyplot as plt


def test_scipy01():
    print('Hello from test_scipy01!')

    from scipy import special
    def drumhead_height(n, k, distance, angle, t):
        kth_zero = special.jn_zeros(n, k)[-1]
        return np.cos(t) * np.cos(n*angle) * special.jn(n, distance*kth_zero)

    theta = np.r_[0:2*np.pi:50j]
    radius = np.r_[0:1:50j]
    x = np.array([r * np.cos(theta) for r in radius])
    y = np.array([r * np.sin(theta) for r in radius])
    z = np.array([drumhead_height(1, 1, r, theta, 0.5) for r in radius])

    fig = plt.figure()
    ax = fig.add_axes(rect=(0, 0.05, 0.95, 0.95), projection='3d')
    ax.plot_surface(x, y, z, rstride=1, cstride=1, cmap='RdBu_r', vmin=-0.5, vmax=0.5)
    ax.set_xlabel('X')
    ax.set_ylabel('Y')
    ax.set_xticks(np.arange(-1, 1.1, 0.5))
    ax.set_yticks(np.arange(-1, 1.1, 0.5))
    ax.set_zlabel('Z')
    plt.show()



def test_scipy02():
    print('Hello from test_scipy02!')

    import scipy.integrate as integrate
    import scipy.special as special
    result = integrate.quad(lambda x: special.jv(2.5,x), 0, 4.5)
    print(result)

    from numpy import sqrt, sin, cos, pi
    I = sqrt(2/pi)*(18.0/27*sqrt(2)*cos(4.5) - 4.0/27*sqrt(2)*sin(4.5) +
        sqrt(2*pi) * special.fresnel(3/sqrt(pi))[0])
    print(I)
    print(abs(result[0]-I))




def test_scipy03():
    print('Hello from test_scipy03!')

    from scipy.integrate import quad
    def integrand(x, a, b): return a*x**2 + b

    a = 2; b = 1;
    I = quad(integrand, 0, 1, args=(a,b))
    print(I)


def test_scipy04():
    print('Hello from test_scipy04!')

    from scipy.integrate import quad
    def integrand(t, n, x):
        return np.exp(-x*t) / t**n

    def expint(n, x):
        return quad(integrand, 1, np.inf, args=(n, x))[0]

    vec_expint = np.vectorize(expint)
    print(vec_expint(3, np.arange(1.0, 4.0, 0.5)))

    import scipy.special as special
    print(special.expn(3, np.arange(1.0,4.0,0.5)))

    result = quad(lambda x: expint(3, x), 0, np.inf)
    print(result)
    I3 = 1.0/3.0
    print(I3)
    print(I3 - result[0])



def test_scipy05():
    print('Hello from test_scipy05!')

    from scipy.integrate import quad, dblquad
    def I(n):
        return dblquad(lambda t, x: np.exp(-x*t)/t**n, 0, np.inf, lambda x: 1, lambda x: np.inf)

    print(I(4))
    print(I(3))
    print(I(2))

    area = dblquad(lambda x, y: x*y, 0, 0.5, lambda x: 0, lambda x: 1-2*x)
    print(area)

    from scipy import integrate
    N = 5
    def f(t, x): return np.exp(-x*t) / t**N
    I7 = integrate.nquad(f, [[1, np.inf],[0, np.inf]])
    print(I7)



def test_scipy06():
    print('Hello from test_scipy06!')

    from scipy import integrate
    def f(x, y): return x*y
    def bounds_y(): return [0, 0.5]
    def bounds_x(y): return [0, 1-2*y]
    I8 = integrate.nquad(f, [bounds_x, bounds_y])
    print(I8)



def test_scipy07():
    print('Hello from test_scipy07!')
    from scipy import integrate

    def f1(x): return x**2
    def f2(x): return x**3

    x = np.array([1,3,4])

    y1 = f1(x)
    I1 = integrate.simpson(y1, x)
    print(I1)

    y2 = f2(x)
    I2 = integrate.simpson(y2, x)
    print(I2)


def test_scipy08():
    print('Hello from test_scipy08!')

    from scipy.integrate import solve_ivp
    from scipy.special import gamma, airy
    y1_0 = +1 / 3**(2/3) / gamma(2/3)
    y0_0 = -1 / 3**(1/3) / gamma(1/3)
    y0 = [y0_0, y1_0]

    def func(t, y): return [t*y[1],y[0]]

    t_span = [0, 4]
    sol1 = solve_ivp(func, t_span, y0)
    print("sol1.t: {}".format(sol1.t))
    print("sol1.y[1]: {}".format(sol1.y[1]))
    print("airy(sol.t)[0]:  {}".format(airy(sol1.t)[0]))

    rtol, atol = (1e-8, 1e-8)
    sol2 = solve_ivp(func, t_span, y0, rtol=rtol, atol=atol)
    print("sol2.y[1][::6]: {}".format(sol2.y[1][0::6]))
    print("airy(sol2.t)[0][::6]: {}".format(airy(sol2.t)[0][::6]))

    t = np.linspace(0, 4, 100)
    sol3 = solve_ivp(func, t_span, y0, t_eval=t)
    print(sol3)

    def gradient(t, y): return [[0,t], [1,0]]
    sol4 = solve_ivp(func, t_span, y0, method='Radau', jac=gradient)
    print(sol4)




def test_scipy10():
    print('Hello from test_scipy10!')
    from scipy.optimize import minimize

    def rosen(x): return sum(100.0*(x[1:]-x[:-1]**2.0)**2.0 + (1-x[:-1])**2.0)

    def rosen_der(x):
        xm = x[1:-1]
        xm_m1 = x[:-2]
        xm_p1 = x[2:]
        der = np.zeros_like(x)
        der[1:-1] = 200*(xm-xm_m1**2) - 400*(xm_p1 - xm**2)*xm - 2*(1-xm)
        der[0] = -400*x[0]*(x[1]-x[0]**2) - 2*(1-x[0])
        der[-1] = 200*(x[-1]-x[-2]**2)
        return der

    def rosen_hess(x):
        x = np.asarray(x)
        H = np.diag(-400*x[:-1],1) - np.diag(400*x[:-1],-1)
        diagonal = np.zeros_like(x)
        diagonal[0] = 1200*x[0]**2-400*x[1]+2
        diagonal[-1] = 200
        diagonal[1:-1] = 202 + 1200*x[1:-1]**2 - 400*x[2:]
        H = H + np.diag(diagonal)
        return H

    def rosen_hess_p(x, p):
        x = np.asarray(x)
        Hp = np.zeros_like(x)
        Hp[0] = (1200*x[0]**2 - 400*x[1] + 2)*p[0] - 400*x[0]*p[1]
        Hp[1:-1] = -400*x[:-2]*p[:-2]+(202+1200*x[1:-1]**2-400*x[2:])*p[1:-1] \
                   -400*x[1:-1]*p[2:]
        Hp[-1] = -400*x[-2]*p[-2] + 200*p[-1]
        return Hp


    print("Nelder-Mead")
    x0 = np.array([1.3, 0.7, 0.8, 1.9, 1.2])
    res = minimize(rosen, x0, method='nelder-mead', options={'xatol': 1e-8, 'disp': True})
    print(res.x)

    print()
    print("Broyden-Fletcher-Goldfarb-Shanno algorithm (BFGS)")
    res = minimize(rosen, x0, method='BFGS', jac=rosen_der, options={'disp': True})
    print(res.x)


    print()
    print("Trust-Region Newton-Conjugate-Gradient Algorithm")
    res = minimize(rosen, x0, method='Newton-CG',
           jac=rosen_der, hessp=rosen_hess_p,
           options={'xtol': 1e-8, 'disp': True})
    print(res.x)


    print()
    print("Trust-Region Newton-Conjugate-Gradient Algorithm")
    res = minimize(rosen, x0, method='trust-ncg',
           jac=rosen_der, hess=rosen_hess,
           options={'gtol': 1e-8, 'disp': True})
    print(res.x)


    print()
    print("Trust-Region Truncated Generalized Lanczos")
    res = minimize(rosen, x0, method='trust-krylov',
           jac=rosen_der, hess=rosen_hess,
           options={'gtol': 1e-8, 'disp': True})
    print(res.x)


    print()
    print("Trust-Region Nearly Exact Algorithm")
    res = minimize(rosen, x0, method='trust-exact',
               jac=rosen_der, hess=rosen_hess,
               options={'gtol': 1e-8, 'disp': True})
    print(res.x)



def test_scipy11():
    print('Hello from test_scipy11!')
    from scipy.optimize import minimize


    def rosen(x): return sum(100.0*(x[1:]-x[:-1]**2.0)**2.0 + (1-x[:-1])**2.0)

    def rosen_der(x):
        xm = x[1:-1]
        xm_m1 = x[:-2]
        xm_p1 = x[2:]
        der = np.zeros_like(x)
        der[1:-1] = 200*(xm-xm_m1**2) - 400*(xm_p1 - xm**2)*xm - 2*(1-xm)
        der[0] = -400*x[0]*(x[1]-x[0]**2) - 2*(1-x[0])
        der[-1] = 200*(x[-1]-x[-2]**2)
        return der

    def rosen_hess(x):
        x = np.asarray(x)
        H = np.diag(-400*x[:-1],1) - np.diag(400*x[:-1],-1)
        diagonal = np.zeros_like(x)
        diagonal[0] = 1200*x[0]**2-400*x[1]+2
        diagonal[-1] = 200
        diagonal[1:-1] = 202 + 1200*x[1:-1]**2 - 400*x[2:]
        H = H + np.diag(diagonal)
        return H


    from scipy.optimize import Bounds
    bounds = Bounds([0, -0.5], [1.0, 2.0])

    from scipy.optimize import LinearConstraint
    linear_constraint = LinearConstraint([[1, 2], [2, 1]], [-np.inf, 1], [1, 1])

    def cons_f(x):
        return [x[0]**2 + x[1], x[0]**2 - x[1]]

    def cons_J(x):
        return [[2*x[0], 1], [2*x[0], -1]]

    def cons_H(x, v):
        return v[0]*np.array([[2, 0], [0, 0]]) + v[1]*np.array([[2, 0], [0, 0]])

    from scipy.optimize import NonlinearConstraint
    nonlinear_constraint1 = NonlinearConstraint(cons_f, -np.inf, 1, jac=cons_J, hess=cons_H)

    from scipy.sparse import csc_matrix

    def cons_H_sparse(x, v):
        return v[0]*csc_matrix([[2, 0], [0, 0]]) + v[1]*csc_matrix([[2, 0], [0, 0]])

    nonlinear_constraint2 = NonlinearConstraint(cons_f, -np.inf, 1, jac=cons_J, hess=cons_H_sparse)

    from scipy.sparse.linalg import LinearOperator

    def cons_H_linear_operator(x, v):
        def matvec(p):
            return np.array([p[0]*2*(v[0]+v[1]), 0])
        return LinearOperator((2, 2), matvec=matvec)

    nonlinear_constraint3 = NonlinearConstraint(cons_f, -np.inf, 1, jac=cons_J, hess=cons_H_linear_operator)

    from scipy.optimize import BFGS
    nonlinear_constraint4 = NonlinearConstraint(cons_f, -np.inf, 1, jac=cons_J, hess=BFGS())

    nonlinear_constraint5 = NonlinearConstraint(cons_f, -np.inf, 1, jac=cons_J, hess='2-point')

    nonlinear_constraint6 = NonlinearConstraint(cons_f, -np.inf, 1, jac='2-point', hess=BFGS())


    #Solving the Optimization Problem:
    x0 = np.array([0.5, 0])
    res = minimize(rosen, x0, method='trust-constr', jac=rosen_der, hess=rosen_hess,
                   constraints=[linear_constraint, nonlinear_constraint1],
                   options={'verbose': 1}, bounds=bounds)
    print(res.x)





try:
    print()
    test_scipy01()
    #test_scipy02()
    #test_scipy03()
    #test_scipy04()
    #test_scipy05()
    #test_scipy06()
    #test_scipy07()
    #test_scipy08()

    #test_scipy10()
    #test_scipy11()





except Exception:
    import traceback
    print(traceback.format_exc())

