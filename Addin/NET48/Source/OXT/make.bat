REM @echo off
:: Windows make-file for MpFunlab LibreOfffice Calc Add-in.
:: Based on work by jan@biochemfusion.com, April 2009, see http://biochemfusion.com/doc/Calc_addin_howto.html


SET OOO_HOME=C:\Program Files\LibreOffice
SET OOO_BIN_DIR=%OOO_HOME%\program
SET TOOLS_BIN_DIR=%OOO_HOME%\sdk\bin
SET PACKAGE_NAME=MpFunLab

:: The IDL tools rely on supporting files in the main LibreOffice installation.
PATH=%PATH%;%OOO_HOME%\program


:: Compile IDL file.
SET IDL_INCLUDE_DIR=%OOO_HOME%\sdk\idl
SET IDL_FILE=idl\X%PACKAGE_NAME%
"%TOOLS_BIN_DIR%\idlc.exe" -w -I "%IDL_INCLUDE_DIR%" %IDL_FILE%.idl


:: Convert compiled IDL to loadable type library file.
if exist %IDL_FILE%.rdb. (
del %IDL_FILE%.rdb
)
"%OOO_BIN_DIR%\regmerge.exe" %IDL_FILE%.rdb /UCR %IDL_FILE%.urd
del %IDL_FILE%.urd


:: Generate XML files.
"%OOO_BIN_DIR%\python.exe" src\generate_xml.py


:: Create .OXT file.
move manifest.xml %PACKAGE_NAME%\META-INF\
move description.xml %PACKAGE_NAME%\
move CalcAddIn.xcu %PACKAGE_NAME%\

move %IDL_FILE%.rdb %PACKAGE_NAME%\
copy src\mpfunlab.py %PACKAGE_NAME%\

del %PACKAGE_NAME%.oxt
cd %PACKAGE_NAME%\
"C:\program files\7-zip\7z.exe" a -r -tzip ..\%PACKAGE_NAME%.oxt *



Pause

REM mpformula: expand
REM mpformula: condense



