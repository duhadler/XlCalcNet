library(reticulate)
use_python("C:\\Python313", required = TRUE)
py_config()
# this requires the full path
source_python("~/DataXlCalcNet/A01_ExamplesPython/B01_GeneralUsage/C12_RBasics/D01a_Example01.py")
p1 = py$p
s1 = py$s
print("py$p: ")
print(py$p)
print("py$s: ")
print(py$s)
print(py$dbl_p, digits = 15)
print(py$dbl_s, digits = 15)
print(py$str_p)

