using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace MpFunLabClient
{


    public class MpFunLabSocketClientClass
    {

        public static string CallSocketServer(string Code)
        {

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
                    //Console.WriteLine("bytesSent: {0}", bytesSent);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Result = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    //Result = "ArgumentNullException: " + ane.ToString();
                    Result = "ArgumentNullException: " + ane.Message;
                }
                catch (SocketException se)
                {
                    //Result = "SocketException: " + se.ToString();
                    Result = "SocketException: " + se.Message;
                }
                catch (Exception e)
                {
                    Result = "Exception: " + e.Message;
                }
            }
            catch (Exception e)
            {
                Result = "Exception: " + e.Message;
            }
            return Result;
        }


        private static string GetXlcalcnetLocalAppDataTempFolder()
        {
            string _LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string rootPath = _LocalAppDataDir + @"\XlCalcNetIDE\Temp";
            string retValue = rootPath;

            //If the folder does not exist, it will be created.
            try
            {
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Unable to create the folder: " + rootPath, "Folder Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retValue;
        }



        private static dynamic GetTypedData(string Result2)
        {
            dynamic ResultFinal;
            if (Result2.StartsWith("$float$"))
            {
                string ResultTemp = Result2.Substring(7);
                ResultFinal = double.Parse(ResultTemp);
            }
            else if (Result2.StartsWith("$bool$"))
            {
                string ResultTemp = Result2.Substring(6);
                ResultFinal = bool.Parse(ResultTemp);
            }
            else if (Result2.StartsWith("$datetime$"))
            {
                string ResultTemp = Result2.Substring(10);
                ResultFinal = double.Parse(ResultTemp);
            }
            else
            {
                ResultFinal = Result2;
            }
            return ResultFinal;
        }


        private static dynamic ResultStringTodynamic(string Result, bool Transpose, bool ShowShape)
        {
            if (Result.StartsWith("$list$"))
            {
                dynamic[,] oTable;
                string[] ResArray = Strings.Split(Result, "§__§");
                int NoOfRows = ResArray.Length;
                string Row = ResArray[1];
                string[] RowArray = Strings.Split(Row, "§_§");
                int NoOfCols = RowArray.Length;
                if (Transpose)
                {
                    oTable = new dynamic[NoOfCols, NoOfRows - 2 + 1];
                }
                else
                {
                    oTable = new dynamic[NoOfRows - 2 + 1, NoOfCols];
                }
                for (int i = 0, loopTo = NoOfRows - 2; i <= loopTo; i++)
                {
                    Row = ResArray[i + 1];
                    // Console.WriteLine(Row)
                    RowArray = Strings.Split(Row, "§_§");
                    for (int j = 0, loopTo1 = RowArray.Length - 1; j <= loopTo1; j++)
                    {
                        string Val = RowArray[j];
                        if (Transpose)
                        {
                            oTable[j, i] = GetTypedData(Val);
                        }
                        else
                        {
                            oTable[i, j] = GetTypedData(Val);
                        }
                        // Console.WriteLine("i:{0}, j:{1}, val:{2}", i, j, Val)
                    }
                }
                if (ShowShape)
                {
                    string RxC;
                    if (Transpose)
                    {
                        RxC = "R" + NoOfCols.ToString().Trim() + "xC" + (NoOfRows - 1).ToString().Trim() + "| ";
                    }
                    else
                    {
                        RxC = "R" + (NoOfRows - 1).ToString().Trim() + "xC" + NoOfCols.ToString().Trim() + "| ";
                    }
                    oTable[0, 0] = RxC + oTable[0, 0].ToString();
                }
                return oTable;
            }
            else
            {
                return GetTypedData(Result);
            }
        }



        public static string MakeParam(dynamic P)
        {
            string PStr = "";
            if (P is Array)
            {
                dynamic[,] oTable = (dynamic[,])P;
                int NoOfRows, NoOfCols;
                NoOfRows = oTable.GetUpperBound(0);
                NoOfCols = oTable.GetUpperBound(1);
                var RowsJoined = new string[NoOfRows + 1 + 1];
                RowsJoined[0] = "||" + "$list$";
                for (int i = 0, loopTo = NoOfRows - 0; i <= loopTo; i++)
                {
                    var ColsJoined = new string[NoOfCols + 1];
                    for (int j = 0, loopTo1 = NoOfCols - 0; j <= loopTo1; j++)
                    {
                        if (oTable[i, j] is double)
                        {
                            ColsJoined[j] = "$float$" + oTable[i, j].ToString();
                        }
                        else if (oTable[i, j] is bool)
                        {
                            ColsJoined[j] = "$bool$" + oTable[i, j].ToString();
                        }
                        else
                        {
                            ColsJoined[j] = oTable[i, j].ToString();
                        }
                    }
                    RowsJoined[i + 1] = string.Join("§_§", ColsJoined);
                }
                PStr = string.Join("§__§", RowsJoined);
            }
            else if (P is double)
            {
                PStr = "||" + "$float$" + P.ToString();
            }
            else if (P is bool)
            {
                PStr = "||" + "$bool$" + P.ToString();
            }
            return PStr;
        }



        public static dynamic CallSocketServer0(string Code, bool Transpose, bool ShowShape)
        {
            int TotalBytesThreshold = 1000;
            //var scc = new MpFunLabSocketClientClass();
            var utf8WithoutBOM = new UTF8Encoding(false);
            string InputPath = "";
            string ResultStr = "";
            //Console.WriteLine("Code1.Length(): {0}", Code.Length);
            int TotalBytes = Encoding.UTF8.GetBytes(Code).Length;
            //Console.WriteLine("Code2.Length(): {0}", TotalBytes);
            if (TotalBytes > TotalBytesThreshold)
            {
                //Console.WriteLine("C#: write to file");

                string UniqueFileName = string.Format(@"{0}.txt", DateTime.Now.Ticks);
                InputPath = GetXlcalcnetLocalAppDataTempFolder() + @"\" + UniqueFileName;
                //Console.WriteLine("InputPath: {0}", InputPath);

                File.WriteAllText(InputPath, Code, utf8WithoutBOM);
                string Code2 = "$file:$" + InputPath;
                ResultStr = CallSocketServer(Code2);
            }
            else
            {
                //Console.WriteLine("C#: no write to file");
                ResultStr = CallSocketServer(Code);
            }

            if (InputPath != "") File.Delete(InputPath);
            if (ResultStr.StartsWith("$file:$"))
            {
                //Console.WriteLine("C#: read from file");
                string ResultPath = ResultStr.Substring(7);
                ResultStr = File.ReadAllText(ResultPath, utf8WithoutBOM);
                //Console.WriteLine("ResultStr: {0}", ResultStr);
                File.Delete(ResultPath);
            }
            else
            {
                //Console.WriteLine("C#: no read from file");
            }

            if (ResultStr.StartsWith("$list$"))
            {
                dynamic[,] oTable;
                string[] ResArray = Strings.Split(ResultStr, "§__§");
                //string[] ResArray = string.Split(ResultStr, "§__§");
                int NoOfRows = ResArray.Length;
                string Row = ResArray[1];
                string[] RowArray = Strings.Split(Row, "§_§");
                int NoOfCols = RowArray.Length;
                if (Transpose)
                {
                    oTable = new dynamic[NoOfCols, NoOfRows - 2 + 1];
                }
                else
                {
                    oTable = new dynamic[NoOfRows - 2 + 1, NoOfCols];
                }
                for (int i = 0, loopTo = NoOfRows - 2; i <= loopTo; i++)
                {
                    Row = ResArray[i + 1];
                    RowArray = Strings.Split(Row, "§_§");
                    for (int j = 0, loopTo1 = RowArray.Length - 1; j <= loopTo1; j++)
                    {
                        string Val = RowArray[j];
                        if (Transpose)
                        {
                            oTable[j, i] = GetTypedData(Val);
                        }
                        else
                        {
                            oTable[i, j] = GetTypedData(Val);
                        }
                    }
                }
                if (ShowShape)
                {
                    string RxC;
                    if (Transpose)
                    {
                        RxC = "R" + NoOfCols.ToString().Trim() + "xC" + (NoOfRows - 1).ToString().Trim() + "| ";
                    }
                    else
                    {
                        RxC = "R" + (NoOfRows - 1).ToString().Trim() + "xC" + NoOfCols.ToString().Trim() + "| ";
                    }
                    oTable[0, 0] = RxC + oTable[0, 0].ToString();
                }
                return oTable;
            }
            else
            {
                return GetTypedData(ResultStr);
            }
        }




    }
}