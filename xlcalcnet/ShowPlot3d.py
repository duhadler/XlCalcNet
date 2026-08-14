
import sys
import pathlib
import clr
clr.AddReference("System.Windows.Forms")
import System
import System.Windows.Forms as WinForms
from System.Threading import ApartmentState, Thread, ThreadStart
from ctypes import windll
windll.user32.SetProcessDPIAware()



class Plot3DApp(WinForms.Form):

    def __init__(self, WindowTitle, Width, Height):
        PyDir = str(pathlib.Path(sys.executable).parent.resolve())
        PathToBin = PyDir + r"\Lib\site-packages\xlcalcnet\Addin\NET48\Bin"
        clr.AddReference(PathToBin + r"\TinyPlot3DUserCtrl.dll")
        PathToIcon = PathToBin + r"\kuengreen_256_icon.ico"
        import TinyPlot3DCtrl
        super().__init__()
        self.components = System.ComponentModel.Container()
        self.AutoScaleDimensions = System.Drawing.SizeF(12.0, 12.0)
        self.AutoScaleMode = WinForms.AutoScaleMode.Dpi
        self.ClientSize = System.Drawing.Size(Width, Height)
        self.UserCtrl = TinyPlot3DCtrl.Plot3DCtrl(PyDir)
        self.UserCtrl.Dock = WinForms.DockStyle.Fill
        self.Controls.Add(self.UserCtrl)
        self.StartPosition = WinForms.FormStartPosition.CenterScreen
        self.Icon = System.Drawing.Icon(PathToIcon)
        self.Text = WindowTitle

    def Dispose(self):
        self.components.Dispose()
        WinForms.Form.Dispose(self)


class plot3D():

    def __init__(self, WindowTitle, Width, Height):
        self.WindowTitle = WindowTitle
        self.Width = Width
        self.Height = Height

    def app_thread(self):
        app = Plot3DApp(self.WindowTitle, self.Width, self.Height)
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


WindowTitle = "Interactive 3D Plots (xlcalcnet)"
Width = 1260;  Height = 1700
plt3D = plot3D(WindowTitle, Width, Height)
plt3D.show()




