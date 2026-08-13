
import sys
import pathlib
import clr
clr.AddReference("System.Windows.Forms")
import System
import System.Windows.Forms as WinForms
from System.Threading import ApartmentState, Thread, ThreadStart
from ctypes import windll
windll.user32.SetProcessDPIAware()



class EditorApp(WinForms.Form):

    def __init__(self, WindowTitle, Width, Height, FileToOpen):
        PyDir = str(pathlib.Path(sys.executable).parent.resolve())
        PyDll = 'Python' + str(sys.version_info.major)  \
          + str(sys.version_info.minor) + '.dll'
        PathToBin = PyDir + r"\Lib\site-packages\xlcalcnet\Addin\NET48\Bin"
        clr.AddReference(PathToBin + r"\TinyIDEUserCtrl.dll")
        PathToIcon = PathToBin + r"\kuengreen_256_icon.ico"
        import FlexDlgUserCtrl
        super().__init__()
        self.components = System.ComponentModel.Container()
        self.AutoScaleDimensions = System.Drawing.SizeF(12.0, 12.0)
        self.AutoScaleMode = WinForms.AutoScaleMode.Dpi
        self.ClientSize = System.Drawing.Size(Width, Height)
        self.UserCtrl = FlexDlgUserCtrl.FlexDlgUserControl1(PyDir, PyDll, FileToOpen)
        self.UserCtrl.Dock = WinForms.DockStyle.Fill
        self.Controls.Add(self.UserCtrl)
        self.StartPosition = WinForms.FormStartPosition.CenterScreen
        self.Icon = System.Drawing.Icon(PathToIcon)
        self.Text = WindowTitle

    def Dispose(self):
        self.components.Dispose()
        WinForms.Form.Dispose(self)



class editor():

    def __init__(self, WindowTitle, Width, Height, FileToOpen):
        self.WindowTitle = WindowTitle
        self.Width = Width
        self.Height = Height
        self.FileToOpen = FileToOpen

    def app_thread(self):
        app = EditorApp(self.WindowTitle, self.Width, self.Height, self.FileToOpen)
        WinForms.Application.Run(app)
        app.Dispose()

    def show(self):
        try:
            thread = Thread(ThreadStart(self.app_thread))
            thread.SetApartmentState(ApartmentState.STA)
            thread.Start()
            thread.Join()
        except Exception as error:
            print("An error occurred:", error)


WindowTitle = "Tiny C#/Python IDE (xlcalcnet)"
Width = 1380;  Height = 1600
FileToOpen = ""
edt = editor(WindowTitle, Width, Height, FileToOpen)
edt.show()

