### Welcome to XlCalcNet!
The main goal of XlCalcNet (an addin for MS E**x**ce**l** and LibreOffice **Calc**, based on Python**Net**) is to enable the use of functions written in CPython or C# within spreadsheet formulas.


The manual is available online in html format: [XlCalcNet.html](https://duhadler.github.io/XlCalcNetDocsOnline/); it can be downloaded as a folder for offline use.

The manual is also available separately as pdf file: [XlCalcNet.pdf](https://github.com/duhadler/DocsXlCalcNet/raw/master/pdf/xlcalcnet.pdf), which is intended to be downloaded for offline use with a proper pdf reader.




A few simple examples:

Example 1 (calling a function in double precision):

```
=APY0("result =  platform.processor()")
```


Example 2 (calling the sqrt function in arbitrary precision):

```
=APY0("from mpfunlab import mpm $n  mpm.dps=40 $n result = str(mpm.sqrt(2))")
```

Example 3 (array formula):

```
{=APY0("result = sys.path";1;0)}
```

Example 4: (a simple loop)

```
=APY0("from mpfunlab import mpm $n  mpm.dps=40 $n result = str(mpm.sqrt(2))")
```



### Quick start under Windows.

This is achieved by interacting with a socket server written in CPython. 

System requirements: Windows (Desktop) with [.NET Framework 4.x (Full)](http://www.microsoft.com/en-us/download/details.aspx?id=17718).

Download the .zip file and unzip it into a directory for which you have write access.
Within the unzipped directory double-click on `mpFormulaC.bat`. This will start the Python Console of the  [SharpDevelop](http://www.icsharpcode.net/OpenSource/SD/) IDE.
To confirm that mpFormulaC is working, type the following within the Python Console:




