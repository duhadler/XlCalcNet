

.. |newpage| raw:: latex

   \newpage


.. |begin_flushleft| raw:: latex

   \begin{flushleft}


.. |end_flushleft| raw:: latex

   \end{flushleft}


.. |br| raw:: html

   <br />




|newpage|



Basic discrete (lattice) distribution functions
========================================================================================




Poisson distribution, pmf vector
-------------------------------------------------------------------------------


.. method:: Math53.PoissonPmfVector(x, n, lambda)

Returns the vector of all pmf values of the Poisson distribution. The vector is returned as a nested list of Decimals or as a mp.matrix or as a iv.matrix. See also   Wikipedia :cite:p:`WikipediaDis32`, MathWorld :cite:p:`WolframDis32`,  BoostMath :cite:p:`BoostDis32`.


`\text{pmf}(x)`, the probability mass function (pmf) of a random variable `X`, following a Poisson distribution is given by:

.. math:: \text{pmf}(x) = \frac{\mu^k}{k!} e^{-\mu}.


The following recursions are used for the pmf:

.. math:: \text{Pr}(X=k+1 |n) = \frac{\lambda}{k+1} \text{Pr}(X=k |n)

.. math:: \text{Pr}(X=k-1 |n) = \frac{k}{\lambda} \text{Pr}(X=k |n)





Binomial distribution, pmf vector
-------------------------------------------------------------------------------

.. method:: Math53.BinomialPmfVector(x, n, lambda)

Returns the vector of all pmf values of the binomial distribution. The vector is returned as a nested list of Decimals or as a mp.matrix or as a iv.matrix. See also   Wikipedia :cite:p:`WikipediaDis33`, MathWorld :cite:p:`WolframDis33`,  BoostMath :cite:p:`BoostDis33`.


`\text{pmf}(x)`, the probability mass function (pmf) of a random variable `X`, following an binomial distribution is given by:

.. math:: \text{pmf}(x) = \binom{n}{k} p^k (1-p)^{n-k} = f_{\text{Beta}}(k+1,n-k+1,p)/(n+1).


and `f_{\text{Beta}}(\cdot)`  denote the pdf of the central beta distribution. The following recursions are used for the pmf:

.. math:: \text{Pr}(X=k+1 |n) = \frac{(n-k)P}{(k+1)Q} \text{Pr}(X=k |n),

.. math:: \text{Pr}(X=k-1 |n) = \frac{kQ}{(n-k+1)P} \text{Pr}(X=k |n).





Negative binomial distribution, pmf vector
-------------------------------------------------------------------------------

.. method:: Math53.NegativeBinomialPmfVector(x, n, lambda)

Returns the vector of all pmf values of the negative binomial distribution. The vector is returned as a nested list of Decimals or as a mp.matrix or as a iv.matrix. See also   Wikipedia :cite:p:`WikipediaDis34`, MathWorld :cite:p:`WolframDis34`,  BoostMath :cite:p:`BoostDis34`.

`\text{pmf}(x)`, the probability mass function (pmf) of a random variable `X`, following an negative binomial distribution is given by:

   .. math:: \text{pmf}(x) = \frac{\Gamma(n+k)}{K! \Gamma(n)} P^n (1-P)^k.

and `f_{\text{Beta}}(\cdot)`  denotes the pdf  of the central beta distribution. The following recursions are used for the pmf:

.. math:: \text{Pr}(X=k+1 |n) = \frac{(n+k) (1-P)}{(k+1) } \text{Pr}(X=k |n)

.. math:: \text{Pr}(X=k-1 |n) = \frac{k}{(n-k+1)(1-P)} \text{Pr}(X=k |n)




Hypergeometric distribution, pmf vector
-------------------------------------------------------------------------------

.. method:: Math53.HypergeometricPmfVector(x, n, lambda)

Returns the vector of all pmf values of the hypergeometric distribution. The vector is returned as a nested list of Decimals or as a mp.matrix or as a iv.matrix. 

See also   Wikipedia :cite:p:`WikipediaDis35`, MathWorld :cite:p:`WolframDis35`,  BoostMath :cite:p:`BoostDis35`, :cite:t:`Berkopec2007`.


`\text{pmf}(x)`, the probability mass function (pmf) of a random variable `X`, following an hypergeometric distribution is given by:

   .. math:: \text{pmf}(x) = \frac{\binom{n_1}{k} \binom{n_2}{n-k}}{\binom{n_1+n_2}{n}}, \quad (n,n_1,n_2 \geq 0; n \leq n_1+n_2).


The following recursions are used for the pmf:

.. math:: f(k+1)= \frac{(n_1 - k)(n-k)}{(k+1)(n_2 - n+k+1} f(k)

.. math:: f(k-1)= \frac{k(n_2 - n + k)}{(n_1 - k+1)(n-k+1} f(k)




Noncentral hypergeometric distribution (Fisher), pmf vector
-------------------------------------------------------------------------------

.. method:: Math53.HypergeoNcPmfVector(x, n, lambda)

Returns the vector of all pmf values of the noncentral hypergeometric distribution (Fisher). The vector is returned as a nested list of Decimals or as a mp.matrix or as a iv.matrix. See also:  Wikipedia :cite:p:`WikipediaDis102`, :cite:t:`Johnson2005` page 293.


.. math:: \text{pmf}(x) = \text{h}(x; n_1, m_1, N, \theta) = \frac{\binom{n_1}{x} \binom{n_2}{m_1-x}\theta^x}{\binom{n_2}{m_1} {}_2F_1(-n_1, -m_1;n_2+1-m_1; \theta)}, 

where `\theta = p_1 q_2 /(q_1p_2)` and `\text{max}(0, m_1-n_2 )\le x \le \text{min}(n_1,m_1)`. 

The following recursions are used for the PMF (see Wikipedia):

.. math:: \text{h}(x; n_1, m_1, N, \theta)= \frac{(m_1-x+1)(n_1-x+1) \theta}{x(m_2-n_1+x)} \text{h}(x-1; n_1, m_1, N, \theta)




