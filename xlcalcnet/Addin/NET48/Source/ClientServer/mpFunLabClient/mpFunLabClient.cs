using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;

namespace MpFunLabClient
{


    public class MpFunLabSocketClientClass
    {



        //public const short SWP_NOMOVE = 0x2;
        //public const short SWP_NOSIZE = 1;
        //public const short SWP_NOZORDER = 0x4;
        //public const short SWP_SHOWWINDOW = 0x40;

        //public const int SW_SHOWNORMAL = 1;
        //public const int SW_SHOWMINIMIZED = 2;

        //private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        //[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        //public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        //[DllImport("user32.dll", EntryPoint = "ShowWindow")]
        //private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);


        //public static void HookWindow()
        //{

        //    Process[] Processes = Process.GetProcessesByName("Notepad");

        //    foreach (Process p in Processes)
        //    {

        //        var handle = p.MainWindowHandle;
        //        if (handle != IntPtr.Zero)
        //        {
        //            SetWindowPos(handle, HWND_BOTTOM, 200, 200, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
        //        }
        //    }

        //}


        //public string GetCPythonPath()
        //{
        //    string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    // MessageBox.Show(BinPath);
        //    bool found = false;
        //    while (!found)
        //    {
        //        try
        //        {
        //            BinPath = Directory.GetParent(BinPath).FullName;
        //            string Temp = BinPath + @"\python.exe";
        //            // MessageBox.Show(Temp);
        //            if (File.Exists(Temp))
        //                found = true;
        //        }
        //        catch (Exception)
        //        {
        //            found = true;
        //            BinPath = "";
        //            Interaction.MsgBox("Could not find path to python.exe");
        //        }
        //    }
        //    // MessageBox.Show(BinPath);
        //    return BinPath;
        //}


        //public void StartSocketServer()
        //{
        //    string AddInPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    string PyExe = GetCPythonPath() + @"\python.exe";
        //    if (File.Exists(PyExe))
        //    {
        //        var process = new Process();
        //        process.StartInfo.FileName = PyExe;
        //        process.StartInfo.Arguments = AddInPath + @"\socketspy.py";
        //        process.StartInfo.CreateNoWindow = false;
        //        // process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        //        // process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
        //        process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        //        process.StartInfo.UseShellExecute = true;
        //        process.Start();

        //        //var handle = IntPtr.Zero;
        //        //while (handle == IntPtr.Zero)
        //        //{
        //        //    handle = process.MainWindowHandle;
        //        //    Console.WriteLine("handle: {0}", handle);
        //        //}
        //        //SetWindowPos(handle, HWND_BOTTOM, 1400, 600, 900, 400, SWP_NOZORDER | SWP_SHOWWINDOW);

        //        //string Result = CallSocketServer("StartingSocketServer");
        //        //ShowWindow(handle, SW_SHOWMINIMIZED);
        //    }
        //    // Console.WriteLine(Result)
        //    else
        //    {
        //        Interaction.MsgBox("Could not find: " + PyExe);
        //    }
        //}


        //public bool SocketServerIsRunning()
        //{
        //    bool Found = false;
        //    Process[] aProc1 = Process.GetProcessesByName("python");
        //    for (int i = 0, loopTo = aProc1.Length - 1; i <= loopTo; i++)
        //    {
        //        string Title = aProc1[i].MainWindowTitle;
        //        Console.WriteLine(Title);
        //        // Dim ProcName As String = aProc1(i).ProcessName
        //        // Console.WriteLine(ProcName)
        //        //Found = Title.Contains("mpfunlab socket server 64 bit on port 11958");
        //        Found = Title.Contains("mpfunlab socket server 64 bit");
        //        if (Found)
        //        {
        //            Found = true;
        //            break;
        //        }
        //    }
        //    return Found;
        //}

        //public void SocketServerShow()
        //{
        //    Process[] aProc1 = Process.GetProcessesByName("python");
        //    for (int i = 0, loopTo = aProc1.Length - 1; i <= loopTo; i++)
        //    {
        //        string Title = aProc1[i].MainWindowTitle;
        //        Console.WriteLine(Title);
        //        //bool Found = Title.Contains("mpfunlab socket server 64 bit on port 11958");
        //        bool Found = Title.Contains("mpfunlab socket server 64 bit");
        //        if (Found)
        //        {
        //            var handle = aProc1[i].MainWindowHandle;
        //            ShowWindow(handle, SW_SHOWNORMAL);
        //            break;
        //        }
        //    }
        //}


        public string CallSocketServer(string Code)
        {
            //if (Code != "StartingSocketServer")
            //{
            //    if (!SocketServerIsRunning())
            //        StartSocketServer();
            //}

            string Result = "";
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];
            try
            {
                // Establish the endpoint for the socket, using port 11958 on the local computer. 
                var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                var ipAddress = ipHostInfo.AddressList[1];
                var remoteEP = new IPEndPoint(ipAddress, 11958);
                // Create a TCP/IP  socket.  
                var sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);
                    byte[] msg = Encoding.UTF8.GetBytes(Code);
                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);
                    Console.WriteLine("bytesSent: {0}", bytesSent);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Result = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Result = "ArgumentNullException: " + ane.ToString();
                }
                catch (SocketException se)
                {
                    Result = "SocketException: " + se.ToString();
                }
                catch (Exception e)
                {
                    Result = "Exception: " + e.ToString();
                }
            }
            catch (Exception e)
            {
                Result = "Exception: " + e.ToString();
            }
            return Result;
        }

    }
}