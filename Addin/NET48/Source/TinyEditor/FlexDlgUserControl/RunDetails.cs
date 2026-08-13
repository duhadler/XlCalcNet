
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FlexDlgUserCtrl
{
    public partial class FlexDlgUserControl1 : UserControl
    {


        public string GetDataPath()
        {
            var mainItem = comboBoxLanguage.SelectedItem;
            if (mainItem == null)
            {
                mainItem = comboBoxLanguage.Items[0];
            }
            string mainItemStr = mainItem.ToString().Trim();
            string res = _WorkDir + @"\" + mainItemStr;
            //string res = _MyDocDir + @"\DataXlCalcNet" + @"\" + mainItemStr;
            //MessageBox.Show(res);
            return res;
        }


        public string GetBinPath()
        {
            string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(BinPath);
            return BinPath;
        }


        int RunCompiler()
        {
            string ScriptName = Path.GetFileNameWithoutExtension(ActiveFileName);

            //Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string FWDir = Environment.GetEnvironmentVariable("SystemRoot") + @"\Microsoft.NET\Framework64\v4.0.30319\";
            string CompilerPath = FWDir;
            string SpecArg = "  /Debug:full /utf8output /noconfig /nologo /platform:x64 ";

            if (ActiveFileName.EndsWith(".vb"))
            {
                SpecArg += @"  /optioninfer  /rootnamespace:" + ScriptName + " /main:" + ScriptName + ".MainModule ";
                CompilerPath += "vbc.exe";
                SpecArg += " /nowarn:42024,42025,42018 ";
            }
            else
            {
                SpecArg += " /preferreduilang:en-us ";
                CompilerPath += "csc.exe";
            }

            string MyArg = SpecArg;



            string[] FWarray = { "mscorlib.dll", "System.dll", "System.Core.dll", "System.Windows.Forms.dll", "System.Drawing.dll", "System.Numerics.dll", "System.Data.dll", "System.Data.Linq.dll", "Microsoft.CSharp.dll", "Microsoft.VisualBasic.dll", "netstandard.dll" };

            string[] Rootarray1 = { "FixedPrecNet.dll", "TinyPlot3DUserCtrl.dll", "System.Data.SQLite.dll" };

            string[] Rootarray2 = { "ArbPrecNet.dll" };

            string[] Rootarray3a = { "UserFixedPrecNet.dll" };

            string[] Rootarray3b = { "UserArbPrecNet.dll" };

            string MyArg1 = "";
            foreach (string s in FWarray)
            {
                MyArg1 += @" /reference:" + "\"" + FWDir + s + "\"";
            }

            string GetBinPath1 = GetBinPath();
            string GetBinPath2 = GetBinPath1.Replace("xlcalcnet", "xlcalcnet2");

            string RootDir1 = GetBinPath1 + @"\";
            string MyArg2 = "";
            foreach (string s in Rootarray1)
            {
                MyArg2 += @" /reference:" + "\"" + RootDir1 + s + "\"";
            }

            string ArbPath = GetBinPath2 + @"\ArbPrecNet.dll";
            //MessageBox.Show(ArbPath);
            bool hasArb = File.Exists(ArbPath);
            //MessageBox.Show(hasArb.ToString());
            string MyArg3 = "";
            if (hasArb)
            {
                string RootDir2 = GetBinPath2 + @"\";
                foreach (string s in Rootarray2)
                {
                    MyArg3 += @" /reference:" + "\"" + RootDir2 + s + "\"";
                }
            }



            string RootDir3 = _LocalAppDataDir + @"\XlCalcNetIDE\Bin\";

            string UserFixedLibPath = RootDir3 + @"UserFixedPrecNet.dll";
            //MessageBox.Show(UserFixedLibPath);
            bool hasUserFixedLib = File.Exists(UserFixedLibPath);
            //MessageBox.Show(hasUserFixedLib.ToString());

            string MyArg4a = "";
            if (hasUserFixedLib)
            {
                foreach (string s in Rootarray3a)
                {
                    MyArg4a += @" /reference:" + "\"" + RootDir3 + s + "\"";
                }
            }

            string UserArbLibPath = RootDir3 + @"UserArbPrecNet.dll";
            //MessageBox.Show(UserArbLibPath);
            bool hasUserArbLib = File.Exists(UserArbLibPath);
            //MessageBox.Show(hasUserArbLib.ToString());
            bool hasUserArbLibAll = hasUserArbLib && hasArb && hasUserFixedLib;
            //MessageBox.Show(hasUserArbLibAll.ToString());

            string MyArg4b = "";
            if (hasUserArbLibAll)
            {
                foreach (string s in Rootarray3b)
                {
                    MyArg4b += @" /reference:" + "\"" + RootDir3 + s + "\"";
                }
            }





            string MyArg5 = @" /reference:" + "\"" + _PythonRootDir + @"\Lib\site-packages\pythonnet\runtime\Python.Runtime.dll" + "\"";

            MyArg += MyArg1 + MyArg2 + MyArg3 + MyArg4a + MyArg4b + MyArg5;

            string Outputpath = _LocalAppDataDir + @"\XlCalcNetIDE\Bin";





            MyArg += @" /out:" + "\"" + Outputpath + @"\mpTempPrecNet.exe" + "\"";
            MyArg += @" /target:exe " + "\"" + ActiveFileName + "\"";


            LogScintilla.Text = "";

            LogScintilla.AppendText(DateTime.Now.ToString("F") + Environment.NewLine);
            LogScintilla.AppendText("Compiler: " + CompilerPath + Environment.NewLine);
            LogScintilla.AppendText("Compiler arguments: " + MyArg + Environment.NewLine);
            LogScintilla.AppendText(Environment.NewLine);

            Process process = new Process();
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.StartInfo.FileName = CompilerPath;
            process.StartInfo.Arguments = MyArg;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardOutput = true;
            string eOut = null;
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => { eOut += e.Data; });


            var stopWatch = new Stopwatch();
            stopWatch.Start();

            process.Start();
            process.BeginErrorReadLine();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            LogScintilla.AppendText("Compiler finished in " + elapsedTime + Environment.NewLine);


            if (eOut.Length > 0)
            {
                LogScintilla.AppendText("compiler error: " + eOut + Environment.NewLine);
            }

            if (output.Length > 0)
            {
                LogScintilla.AppendText("The following problems were encountered: " + Environment.NewLine + "/*" + Environment.NewLine);
                LogScintilla.AppendText(output + "*/");
            }
            else
            {
                LogScintilla.AppendText(Environment.NewLine + @"The file mpTempPrecNet.exe has been written to the Binary Output Folder" + Environment.NewLine);
            }



            return output.Length;
        }





        int RunVbCsExe()
        {
            LogScintilla.AppendText(Environment.NewLine);
            LogScintilla.AppendText("Program execution has started..." + Environment.NewLine);
            LogScintilla.Update();

            string Outputpath = _LocalAppDataDir + @"\XlCalcNetIDE\Bin";

            Process process = new Process();
            process.StartInfo.WorkingDirectory = Outputpath;
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            process.StartInfo.FileName = Outputpath + @"\mpTempPrecNet.exe";
            process.StartInfo.Arguments = "\"" + _PythonRootDir + "\"" + " " + "\"" + _PythonNetPyDll + "\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            string eOut = null;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => { eOut += e.Data; });

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            process.Start();
            process.BeginErrorReadLine();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit(15000);

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            LogScintilla.AppendText("Program execution finished in " + elapsedTime + Environment.NewLine);



            if (output.Length > 0)
            {
                TextDataScintilla.Text = output;
                tabControl1.SelectedTab = tabOutput;
                InitTextDataSyntaxColoring();
            }

            if (eOut.Length > 0)
            {
                LogScintilla.AppendText("The following problem was encountered:" + Environment.NewLine + "/*" + Environment.NewLine);
                string[] items = new string[1];
                items[0] = "$$";
                string[] res = eOut.Split(items, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string res_at = res[1];

                    string[] items_at = new string[1];
                    items_at[0] = " at ";
                    string[] res2 = res_at.Split(items_at, StringSplitOptions.RemoveEmptyEntries);

                    int rcount = 0;
                    for (int i = 0; i < res2.Length; i++)
                    {
                        string temp = res2[i];
                        int pos = temp.IndexOf(Path.GetFileName(ActiveFileName) + ":line");
                        if (pos > 10)
                        {
                            if (rcount == 0)
                            {
                                LogScintilla.AppendText(temp.Substring(pos) + " : runtime error: " + res[0] + Environment.NewLine);
                            }
                            else
                            {
                                LogScintilla.AppendText(temp.Substring(pos) + " : stacktrace: called from here" + Environment.NewLine);
                            }
                            rcount += 1;
                        }
                    }
                    LogScintilla.AppendText("/*");
                }
                catch (Exception)
                {
                    LogScintilla.AppendText(eOut);
                    LogScintilla.AppendText(Environment.NewLine + "*/");
                }



                tabControl1.SelectedTab = tabNewLog;
            }

            return output.Length;
        }



        int RunPythonExe()
        {

            tabControl1.SelectedTab = tabNewLog;
            string MainPath = _PythonRootDir;
            string CPythonExecutableName = MainPath + @"\python.exe";
            string PythonScript = "\"" + ActiveFileName + "\"";

            LogScintilla.Text = "";
            LogScintilla.AppendText(DateTime.Now.ToString("F") + Environment.NewLine);
            LogScintilla.AppendText("Python executable: " + CPythonExecutableName + Environment.NewLine);
            LogScintilla.AppendText("Python script: " + PythonScript + Environment.NewLine);
            LogScintilla.AppendText(Environment.NewLine);
            LogScintilla.AppendText("Python script execution has started..." + Environment.NewLine);
            LogScintilla.Update();



            Process process = new Process();
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(ActiveFileName);
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            process.StartInfo.FileName = CPythonExecutableName;
            process.StartInfo.Arguments = PythonScript;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.EnvironmentVariables["PYTHONIOENCODING"] = "utf-8";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardOutput = true;
            string eOut = null;
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => { eOut += e.Data; });

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            process.Start();
            process.BeginErrorReadLine();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit(15000);

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            LogScintilla.AppendText("Program execution finished in " + elapsedTime + Environment.NewLine);


            if (eOut.Length > 0)
            {
                if (ActiveFileName.Contains("builddoc.py"))
                {
                    //MessageBox.Show("In Contains");
                    string M = @"C:\Users\DUHad\Documents";
                    eOut = eOut.Replace(M, "\r\n\r\n" + "  File \"" + M);
                    eOut = eOut.Replace(".rst:", ".rst\", line ");
                    eOut = eOut.Replace("WARNING:", "\r\n" + "WARNING:");
                    eOut = eOut.Replace("n't", " not");
                    eOut = eOut.Replace(@"\Lib01\index.rst", @"\Lib01\static\index.txt");
                    eOut = eOut.Replace(@"\Lib01\conf.py", @"\Lib01\static\conf.py");

                }
                else
                {
                    eOut = eOut.Replace("^", "\r\n");
                    eOut = eOut.Replace("    ", "\r\n");
                    eOut = eOut.Replace(" File ", " \r\nFile ");
                    int count2 = eOut.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None).Length;
                    for (int i = 0; i < count2; i++)
                    {
                        eOut = eOut.Replace("\r\n\r\n", "\r\n");
                    }
                }

                if (output.Length > 0)
                {
                    TextDataScintilla.Text = output;
                    InitTextDataSyntaxColoring();
                    LogScintilla.AppendText("Some results have been written to Output" + Environment.NewLine + Environment.NewLine);
                }
                LogScintilla.AppendText("/*A runtime error occurred*/: " + Environment.NewLine + eOut + Environment.NewLine);
            }

            if ((output.Length > 0) && (eOut.Length == 0))
            {
                TextDataScintilla.Text = output;
                tabControl1.SelectedTab = tabOutput;
                InitTextDataSyntaxColoring();
                int startpos = output.IndexOf("Traceback (most recent call last)");
                if (startpos >= 0)
                {
                    LogScintilla.AppendText(Environment.NewLine + "/*An error occurred*/:" + Environment.NewLine + output.Substring(startpos));
                    string searchstring = ActiveFileName.Substring(0, ActiveFileName.Length - 5);
                    tabControl1.SelectedTab = tabNewLog;
                }
            }
            return output.Length;
        }


        int RunPythonExeBuildDoc()
        {
            string DocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string ActiveFileNameBuidDoc = DocDir + @"\DataXlCalcNet\A05_UserlibDocs\B01_Lib01\_static\builddoc.py";
            tabControl1.SelectedTab = tabNewLog;
            string MainPath = _PythonRootDir;
            string CPythonExecutableName = MainPath + @"\python.exe";
            string PythonScript = "\"" + ActiveFileNameBuidDoc + "\"";

            LogScintilla.Text = "";
            LogScintilla.AppendText(DateTime.Now.ToString("F") + Environment.NewLine);
            LogScintilla.AppendText("Python executable: " + CPythonExecutableName + Environment.NewLine);
            LogScintilla.AppendText("Python script: " + PythonScript + Environment.NewLine);
            LogScintilla.AppendText(Environment.NewLine);
            LogScintilla.AppendText("Python script execution has started..." + Environment.NewLine);
            LogScintilla.Update();



            Process process = new Process();
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(ActiveFileNameBuidDoc);
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            process.StartInfo.FileName = CPythonExecutableName;
            process.StartInfo.Arguments = PythonScript;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.EnvironmentVariables["PYTHONIOENCODING"] = "utf-8";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardOutput = true;
            string eOut = null;
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => { eOut += e.Data; });

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            process.Start();
            process.BeginErrorReadLine();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit(15000);

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            LogScintilla.AppendText("Program execution finished in " + elapsedTime + Environment.NewLine);


            if (eOut.Length > 0)
            {
                //if (ActiveFileNameBuidDoc.Contains("builddoc.py"))
                //{
                    //MessageBox.Show("In Contains");
                    string M = @"C:\Users\DUHad\Documents";
                    eOut = eOut.Replace(M, "\r\n\r\n" + "  File \"" + M);
                    eOut = eOut.Replace(".rst:", ".rst\", line ");
                    eOut = eOut.Replace("WARNING:", "\r\n" + "WARNING:");
                    eOut = eOut.Replace("n't", " not");
                    eOut = eOut.Replace(@"\Lib01\index.rst", @"\Lib01\static\index.txt");
                    eOut = eOut.Replace(@"\Lib01\conf.py", @"\Lib01\static\conf.py");

                //}
                //else
                //{
                //    eOut = eOut.Replace("^", "\r\n");
                //    eOut = eOut.Replace("    ", "\r\n");
                //    eOut = eOut.Replace(" File ", " \r\nFile ");
                //    int count2 = eOut.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None).Length;
                //    for (int i = 0; i < count2; i++)
                //    {
                //        eOut = eOut.Replace("\r\n\r\n", "\r\n");
                //    }
                //}

                if (output.Length > 0)
                {
                    TextDataScintilla.Text = output;
                    InitTextDataSyntaxColoring();
                    LogScintilla.AppendText("Some results have been written to Output" + Environment.NewLine + Environment.NewLine);
                }
                LogScintilla.AppendText("/*A runtime error occurred*/: " + Environment.NewLine + eOut + Environment.NewLine);
            }

            if ((output.Length > 0) && (eOut.Length == 0))
            {
                TextDataScintilla.Text = output;
                tabControl1.SelectedTab = tabOutput;
                InitTextDataSyntaxColoring();
                int startpos = output.IndexOf("Traceback (most recent call last)");
                if (startpos >= 0)
                {
                    LogScintilla.AppendText(Environment.NewLine + "/*An error occurred*/:" + Environment.NewLine + output.Substring(startpos));
                    string searchstring = ActiveFileNameBuidDoc.Substring(0, ActiveFileNameBuidDoc.Length - 5);
                    tabControl1.SelectedTab = tabNewLog;
                }
            }
            return output.Length;
        }





        int RunDLLCompiler()
        {
            string ScriptDir = Path.GetDirectoryName(ActiveFileName);
            string PrecNetDLLStr = "PrecNetDLL";
            int p = ScriptDir.IndexOf(PrecNetDLLStr);
            string DirectorytoSearch = ScriptDir.Substring(0, p + PrecNetDLLStr.Length) + @"\";

            string GetBinPath1 = GetBinPath();
            string RootDir = _LocalAppDataDir + @"\XlCalcNetIDE\Bin\";

            string FWDir = Environment.GetEnvironmentVariable("SystemRoot") + @"\Microsoft.NET\Framework64\v4.0.30319\";
            string CompilerPath = FWDir;
            string SpecArg = "  /Debug:full /utf8output /noconfig /nologo /platform:x64 ";
            string NameSpGen = "User";
            string NameSpExt = "";
            string OutputName = "";

            if (ScriptDir.Contains("UserFixedPrecNetDLL")) OutputName = "UserFixedPrecNet";
            if (ScriptDir.Contains("UserMpPrecNetDLL")) OutputName = "UserMpPrecNet";
            if (ScriptDir.Contains("UserArbPrecNetDLL")) OutputName = "UserArbPrecNet";

            NameSpExt += "CS";
            CompilerPath += "csc.exe";
            SpecArg += " /preferreduilang:en-us ";

            string NameSp = NameSpGen + NameSpExt;
            SpecArg += " /doc:" + RootDir + OutputName + ".xml";

            //warning CS1591: Missing XML comment for publicly visible type or member

            SpecArg += " /nowarn:1591 ";

            string[] FWarray = { "mscorlib.dll", "System.dll", "System.Core.dll", "System.Windows.Forms.dll", "System.Numerics.dll", "Microsoft.CSharp.dll", "Microsoft.VisualBasic.dll" };
            foreach (string s in FWarray) { SpecArg += @" /reference:" + "\"" + FWDir + s + "\""; }
            string[] Rootarray1 = { "FixedPrecNet.dll" };
            string[] Rootarray2 = { "ArbPrecNet.dll" };
            string GetBinPath2 = GetBinPath1.Replace("xlcalcnet", "xlcalcnet2");

            string RootDir1 = GetBinPath1 + @"\";
            string MyArg2 = "";
            foreach (string s in Rootarray1)
            {
                MyArg2 += @" /reference:" + "\"" + RootDir1 + s + "\"";
            }

            string RootDir2 = GetBinPath2 + @"\";
            string MyArg3 = "";
            foreach (string s in Rootarray2)
            {
                MyArg3 += @" /reference:" + "\"" + RootDir2 + s + "\"";
            }

            SpecArg += MyArg2 + MyArg3;



            SpecArg += @" /target:library ";
            SpecArg += " " + @" /out:" + "\"" + RootDir + OutputName + ".dll" + "\"";
            SpecArg += "  /recurse:*." + NameSpExt.ToLower() + " ";

            LogScintilla.Text = "";
            LogScintilla.AppendText(DateTime.Now.ToString("F") + Environment.NewLine);
            LogScintilla.AppendText(CompilerPath + Environment.NewLine);
            LogScintilla.AppendText(SpecArg + Environment.NewLine);
            LogScintilla.AppendText(Environment.NewLine);
            LogScintilla.AppendText("Compiler has started..." + Environment.NewLine);
            LogScintilla.Update();


            Process process = new Process();
            process.StartInfo.WorkingDirectory = DirectorytoSearch;
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.StartInfo.FileName = CompilerPath;
            process.StartInfo.Arguments = SpecArg;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardOutput = true;
            string eOut = null;
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => { eOut += e.Data; });

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            process.Start();
            process.BeginErrorReadLine();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit(5000);

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            LogScintilla.AppendText("Compiler finished in " + elapsedTime + Environment.NewLine);


            if (eOut.Length > 0)
            {
                LogScintilla.AppendText("compiler error: " + eOut + Environment.NewLine);
            }

            if (output.Length > 0)
            {
                LogScintilla.AppendText("The following problems were encountered: " + Environment.NewLine + Environment.NewLine);
                LogScintilla.AppendText(output);
            }
            else
            {
                LogScintilla.AppendText(Environment.NewLine + @"The files " + OutputName + ".dll and " + OutputName + ".xml have been written to the Binary Output Folder" + Environment.NewLine);
            }


            return output.Length;
        }



        private void RunScript()
        {
            if (IsBuildingUserLibDoc())
            {
                ClearAllAnnotations();
                SaveScript();
                RunPythonExeBuildDoc();
            }


            else if (Path.GetDirectoryName(ActiveFileName).Contains("PrecNetDLL"))
            {
                ClearAllAnnotations();
                SaveScript();
                int result = RunDLLCompiler();
                if (result == 0)
                {
                }
                else
                {
                    tabControl1.SelectedTab = tabNewLog;
                }
            }


            else if (ActiveFileName.EndsWith(".cs"))
            {
                ClearAllAnnotations();
                SaveScript();
                tabControl1.SelectedTab = tabNewLog;
                int result = RunCompiler();
                if (result == 0)
                {
                    RunVbCsExe();
                }
                else
                {
                    tabControl1.SelectedTab = tabNewLog;
                }
            }


            else if (ActiveFileName.EndsWith(".vb"))
            {
                ClearAllAnnotations();
                SaveScript();
                tabControl1.SelectedTab = tabNewLog;
                int result = RunCompiler();
                if (result == 0)
                {
                    RunVbCsExe();
                }
                else
                {
                    tabControl1.SelectedTab = tabNewLog;
                }
            }


            else if (ActiveFileName.EndsWith(".py"))
            {
                ClearAllAnnotations();
                SaveScript();
                var tpath = Path.GetDirectoryName(ActiveFileName);
                var ExternalFileName = tpath + @"\__external__.py";
                if (File.Exists(ExternalFileName))
                {
                    File.Delete(ExternalFileName);
                    ComboBoxProjectUpdate();
                }

                RunPythonExe();
            }


        }
    }
}
