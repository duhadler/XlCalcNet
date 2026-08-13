import matplotlib.pyplot as plt
from xlcalcnet import mp
import numpy as np

# Set precision for accurate differentiation
mp.dps = 25


# Define a vectorized function to compute the derivative of Hurwitz Zeta wrt s at s=-1
def d_hurwitz_zeta_ds_minus1(a):
    # s is the first argument, a is the second argument in mp.diff
    # We differentiate with respect to the first argument (s) evaluated at -1
    deriv = mp.diff(lambda s: mp.zeta(s, a), -1, n=1)
    return float(deriv.real)


# Generate a values for a > 0
a_values = np.linspace(-5.00001, 5.0, 200)
deriv_values = [d_hurwitz_zeta_ds_minus1(a) for a in a_values]

# Plot the graph
plt.figure(figsize=(10, 6))
plt.plot(a_values, deriv_values, label=r"$\frac{\partial}{\partial s}\zeta(s, a)$", color="blue", linewidth=2)
plt.axhline(0, color="black", linewidth=0.8, linestyle="--")
plt.title(
    r"Derivative of the Hurwitz Zeta Function with Respect to $s$ at $s = -1$"
)
plt.xlabel("Parameter $a$")
plt.ylabel(r"$\zeta'(-1, a)$")
plt.grid(True, alpha=0.3)
plt.legend()
plt.show()