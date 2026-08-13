# userlib documentation build file

import sys
import shutil
import os
import pathlib
import subprocess
import webbrowser


def get_local_appdata_folder():
    """Returns the current user's local Application Data folder."""
    import ctypes, ctypes.wintypes
    buf = ctypes.create_unicode_buffer(ctypes.wintypes.MAX_PATH)
    ctypes.windll.shell32.SHGetFolderPathW(None, 0x001c, None, 0, buf)
    return str(buf.value)


#target = 'html'
target = 'latex'

# ʹaaaaʹ  Unicode: 02B9

currentfilename = os.path.realpath(__file__)
currentdirname = pathlib.Path(currentfilename).parent.resolve()
parentdirname = currentdirname.parent.absolute()
src = os.sep.join([str(currentdirname), 'conf.py'])
dst = os.sep.join([str(parentdirname), 'conf.py'])
shutil.copyfile(src, dst)
src = os.sep.join([str(currentdirname), 'index.txt'])
dst = os.sep.join([str(parentdirname), 'index.rst'])
shutil.copyfile(src, dst)

ladp = get_local_appdata_folder() 
outputdirname = os.sep.join([ladp, 'XlCalcNetIDE', target])
pythonexe = sys.executable
pythondir = pathlib.Path(pythonexe).parent.resolve()
sphinxexe = os.sep.join([str(pythondir), 'Scripts', 'sphinx-build.exe'])

my_env = os.environ.copy()
my_env['NO_COLOR'] = 'True'
subprocess.run([sphinxexe, '-b', target, parentdirname, outputdirname], env=my_env)

if (target=='html'):
    url = os.sep.join([str(outputdirname), 'index.html'])
    webbrowser.open(url)


if (target=='latex'):
    ladp2 = os.sep.join([ladp, 'XlCalcNetIDE'])
    src = os.sep.join([str(currentdirname), 'Copyright_And_Preface.tex'])
    dst = os.sep.join([ladp2, 'Copyright_And_Preface.tex'])
    shutil.copyfile(src, dst)
    src = os.sep.join([str(currentdirname), 'makelatex.bat'])
    dst = os.sep.join([ladp2, 'makelatex.bat'])
    shutil.copyfile(src, dst)
    src = os.sep.join([str(currentdirname), 'userlib_tex.py'])
    dst = os.sep.join([ladp2, 'userlib_tex.py'])
    shutil.copyfile(src, dst)
