using FixedPrecNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TinyPlot3DCtrl
{




    public class Data3DNew
    {

        public double[,] yvalues = null;
        public double[,] y2values = null;
        public double[,] yvalues_re = null;
        public double[,] yvalues_im = null;

        public double[,] xvalues = null;
        public double[,] zvalues = null;
        public BitmapImage MyBitmapImage = null;
        public int xResolution = 0;
        public int zResolution = 0;
        public double ScaledXmin = 0;
        public double ScaledZmin = 0;

        private double xmin = 0;
        private double xmax = 0;
        private double zmin = 0;
        private double zmax = 0;
        public double ymin = 0;
        public double ymax = 0;
        private double ytruncate = 0;

        private string RenderStyle = "";
        private string CplxResultType = "";
        private string FullWorkPath = "";


        public Data3DNew(Plot3DCtrl FlexDlg)
        {
            WpfGraphicsSettings _wpfSettings1 = Plot3DCtrl.wpfSettings1;
            FullWorkPath = FlexDlg.GetFullWorkPath();
            RenderStyle = _wpfSettings1.SurfaceColorMap1;
            CplxResultType = _wpfSettings1.ComplexType;


            //xResolution = _wpfSettings1.Resolution;
            //zResolution = _wpfSettings1.Resolution;

            xResolution = _wpfSettings1.Resolution;
            zResolution = _wpfSettings1.Resolution;
            if (_wpfSettings1.Resolution2 > 0)
                zResolution = _wpfSettings1.Resolution2;


            xmin = FlexDlg.Eval(_wpfSettings1.xmin);
            if (double.IsNaN(xmin)) return;

            xmax = FlexDlg.Eval(_wpfSettings1.xmax);
            if (double.IsNaN(xmax)) return;

            zmin = FlexDlg.Eval(_wpfSettings1.zmin);
            if (double.IsNaN(zmin)) return;

            zmax = FlexDlg.Eval(_wpfSettings1.zmax);
            if (double.IsNaN(zmax)) return;



            ytruncate = _wpfSettings1.Truncate;
            yvalues = new double[xResolution + 1, zResolution + 1];
            y2values = new double[xResolution + 1, zResolution + 1];
            yvalues_re = new double[xResolution + 1, zResolution + 1];
            yvalues_im = new double[xResolution + 1, zResolution + 1];

            xvalues = new double[xResolution + 1, zResolution + 1];
            zvalues = new double[xResolution + 1, zResolution + 1];
            CreateMap(FlexDlg, _wpfSettings1.SameScale, _wpfSettings1.Branchcuts, _wpfSettings1.LogLogTransform, out ymin, out ymax);
        }



        private void ReadData(string FName, out double[,] ResultDoubles)
        {
            byte[] ResultBytes = File.ReadAllBytes(FName);
            ResultDoubles = new double[xResolution + 1, zResolution + 1];
            Buffer.BlockCopy(ResultBytes, 0, ResultDoubles, 0, ResultBytes.Length);
        }

        private void StartAppWithWaitForExit3D(string FName, string Args)
        {
            Process process = new Process();
            process.StartInfo.FileName = FName;
            process.StartInfo.Arguments = Args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit(120000);
        }



        private void CreateMap(Plot3DCtrl FlexDlg, string SameScale, string BranchCuts, bool LogLogTransform, out double ymin_out, out double ymax_out)
        {
            WpfGraphicsSettings wpfSettings = Plot3DCtrl.wpfSettings1;
            string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if ((wpfSettings.Plot3DType1 == "Parametric surface"))
            {
                ymin_out = 0;
                ymax_out = 0;

                string FName = FlexDlg.GetTemplatePath() + "CodeTest.txt";
                string s1 = wpfSettings.Code;
                string Code = FlexDlg.GetCodeParams(s1, xResolution, zResolution, xmin, xmax, zmin, zmax);
                File.WriteAllText(FName, Code);

                string Proc;
                dynamic Result;
                try
                {
                    Console.WriteLine(FName);
                    Proc = "test4";
                    Result = FlexDlg.RunScriptFromFile(FName, Proc);
                    string RS = Result.ToString();
                    Console.WriteLine(RS);
                    if (RS.StartsWith("System.Double"))
                        for (int ix = 0; ix < xResolution + 1; ix++)
                        {
                            for (int iz = 0; iz < zResolution + 1; iz++)
                            {
                                xvalues[ix, zResolution - iz] = Result[0, ix, iz];
                                yvalues[ix, zResolution - iz] = Result[1, ix, iz];
                                zvalues[ix, zResolution - iz] = Result[2, ix, iz];
                            }
                        }
                    else
                    {
                        MessageBox.Show(RS);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }



                xmin = double.PositiveInfinity;
                xmax = double.NegativeInfinity;
                zmin = double.PositiveInfinity;
                zmax = double.NegativeInfinity;
                for (int ix = 0; ix < xResolution + 1; ix++)
                {
                    for (int iz = 0; iz < zResolution + 1; iz++)
                    {
                        double ResultY = yvalues[ix, iz];
                        if (ymax < ResultY) ymax = ResultY;
                        if (ymin > ResultY) ymin = ResultY;
                        double ResultX = xvalues[ix, iz];
                        double ResultZ = zvalues[ix, iz];
                        if (xmax < ResultX) xmax = ResultX;
                        if (xmin > ResultX) xmin = ResultX;
                        if (zmax < ResultZ) zmax = ResultZ;
                        if (zmin > ResultZ) zmin = ResultZ;
                    }
                }
            }
            else
            {
                if ((wpfSettings.Plot3DType1 == "Altitude surface, complex function"))
                {
                    ymin_out = 0;
                    ymax_out = 0;

                    string FName = FlexDlg.GetTemplatePath() + "CodeTest.txt";
                    string s1 = wpfSettings.Code;
                    string Code = FlexDlg.GetCodeComplex(s1, xResolution, zResolution, xmin, xmax, zmin, zmax);
                    File.WriteAllText(FName, Code);

                    string Proc;
                    dynamic Result;
                    try
                    {
                        Console.WriteLine(FName);
                        Proc = "test4";
                        Result = FlexDlg.RunScriptFromFile(FName, Proc);
                        string RS = Result.ToString();
                        Console.WriteLine(RS);
                        if (RS.StartsWith("System.Double"))
                            for (int ix = 0; ix < xResolution + 1; ix++)
                            {
                                for (int iz = 0; iz < zResolution + 1; iz++)
                                {
                                    yvalues_re[ix, zResolution - iz] = Result[2, ix, iz];
                                    yvalues_im[ix, zResolution - iz] = Result[3, ix, iz];
                                }
                            }
                        else
                        {
                            MessageBox.Show(RS);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }




                    double dx = (xmax - xmin) / xResolution;
                    double dz = (zmax - zmin) / zResolution;
                    for (int ix = 0; ix < xResolution + 1; ix++)
                    {
                        for (int iz = 0; iz < zResolution + 1; iz++)
                        {
                            double z = zmin + iz * dz;
                            double x = xmin + ix * dx;

                            if (string.IsNullOrEmpty(BranchCuts) || (BranchCuts == "None"))
                            {
                                xvalues[ix, iz] = xmin + ix * dx;
                                zvalues[ix, iz] = zmin + iz * dz;
                            }

                            else if ((BranchCuts == "-inf to 0"))
                            {
                                if ((Math.Abs(z) < 1E-4) && (x < 0))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "-inf to +1"))
                            {
                                if ((Math.Abs(z) < 1E-4) && (x < 1))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "+1 to +inf"))
                            {
                                if ((Math.Abs(z) < 1E-4) && (x > 1))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "-1 to +1"))
                            {
                                if ((Math.Abs(z) < 1E-4) && (x > -1) && (x < 1))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "-inf to 0; +1 to +inf"))
                            {
                                if ((Math.Abs(z) < 1E-4) && ((x < 0) || (x > +1)))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "-inf to -1; +1 to +inf"))
                            {
                                if ((Math.Abs(z) < 1E-4) && ((x < -1) || (x > +1)))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "-1i to +1i"))
                            {
                                if ((Math.Abs(x) < 1E-4) && (z > -1) && (z < 1))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "-i inf to 0; +1i to +i inf"))
                            {
                                if ((Math.Abs(x) < 1E-4) && ((z < 0) || (z > +1)))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }

                            else if ((BranchCuts == "-i inf to -1i; +1i to +i inf"))
                            {
                                if ((Math.Abs(x) < 1E-4) && ((z < -1) || (z > +1)))
                                {
                                    xvalues[ix, iz] = double.NaN;
                                    zvalues[ix, iz] = double.NaN;
                                }
                                else
                                {
                                    xvalues[ix, iz] = xmin + ix * dx;
                                    zvalues[ix, iz] = zmin + iz * dz;
                                }
                            }




                            double ResultY = 0.0;
                            y2values[ix, iz] = new Complex(yvalues_re[ix, iz], yvalues_im[ix, iz]).Phase;
                            switch (CplxResultType)
                            {
                                case "REAL": ResultY = yvalues_re[ix, iz]; break;
                                case "IMAGINARY": ResultY = yvalues_im[ix, iz]; break;
                                case "MAGNITUDE": ResultY = new Complex(yvalues_re[ix, iz], yvalues_im[ix, iz]).Magnitude; break;
                                default: ResultY = 0.0; break;
                            }
                            if (double.IsNaN(ResultY)) { ResultY = ytruncate; }


                            if (LogLogTransform)
                            {
                                ResultY = math53.log1p(Math.Abs(ResultY)) * math53.sign(ResultY);
                                ResultY = math53.log1p(Math.Abs(ResultY)) * math53.sign(ResultY);
                            }
                            if (Math.Abs(ResultY) > ytruncate)
                            {
                                ResultY = ytruncate * Math.Sign(ResultY);
                            }
                            yvalues[ix, iz] = ResultY;
                            if (ymax < ResultY) ymax = ResultY;
                            if (ymin > ResultY) ymin = ResultY;



                        }
                    }
                }




                else if (wpfSettings.Plot3DType1 == "Altitude surface, real function")
                {
                    //ReadData(FullWorkPath + @"\yvalues.bytes", out yvalues);
                    ymin_out = 0;
                    ymax_out = 0;

                    string FName = FlexDlg.GetTemplatePath() + "CodeTest.txt";
                    string s1 = wpfSettings.Code;
                    string Code = FlexDlg.GetCodeReal(s1, xResolution, zResolution, xmin, xmax, zmin, zmax);
                    File.WriteAllText(FName, Code);

                    string Proc;
                    dynamic Result;
                    try
                    {
                        Console.WriteLine(FName);
                        Proc = "test4";
                        Result = FlexDlg.RunScriptFromFile(FName, Proc);
                        string RS = Result.ToString();
                        Console.WriteLine(RS);
                        if (RS.StartsWith("System.Double"))
                            for (int ix = 0; ix < xResolution + 1; ix++)
                            {
                                for (int iz = 0; iz < zResolution + 1; iz++)
                                {
                                    yvalues[ix, zResolution - iz] = Result[2, ix, iz];
                                }
                            }
                        else
                        {
                            MessageBox.Show(RS);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                    double dx = (xmax - xmin) / xResolution;
                    double dz = (zmax - zmin) / zResolution;
                    for (int ix = 0; ix < xResolution + 1; ix++)
                    {
                        for (int iz = 0; iz < zResolution + 1; iz++)
                        {
                            xvalues[ix, iz] = xmin + ix * dx;
                            zvalues[ix, iz] = zmin + iz * dz;
                            double ResultY = yvalues[ix, iz];
                            if (double.IsNaN(ResultY)) { ResultY = ytruncate; }


                            if (LogLogTransform)
                            {
                                ResultY = math53.log1p(Math.Abs(ResultY)) * math53.sign(ResultY);
                                ResultY = math53.log1p(Math.Abs(ResultY)) * math53.sign(ResultY);
                            }
                            if (Math.Abs(ResultY) > ytruncate)
                            {
                                ResultY = ytruncate * Math.Sign(ResultY);
                            }
                            yvalues[ix, iz] = ResultY;


                            if (ymax < ResultY) ymax = ResultY;
                            if (ymin > ResultY) ymin = ResultY;
                        }
                    }
                }





            }



            double xFactor = 1 / (xmax - xmin);
            double zFactor = 1 / (zmax - zmin);
            double yFactor = 1 / (ymax - ymin);

            if (SameScale == "All")
            {
                double minscalefactor = xFactor;
                if (minscalefactor > yFactor) { minscalefactor = yFactor; }
                if (minscalefactor > zFactor) { minscalefactor = zFactor; }

                xFactor = minscalefactor;
                zFactor = minscalefactor;
                yFactor = minscalefactor;
            }

            if (SameScale == "X, Y")
            {
                double minscalefactor = xFactor;
                if (minscalefactor > zFactor) { minscalefactor = zFactor; }

                xFactor = minscalefactor;
                zFactor = minscalefactor;
            }


            double xmean = (xmin + xmax) / 2;
            double zmean = (zmin + zmax) / 2;
            double ymean = (ymin + ymax) / 2;
            for (int ix = 0; ix < xResolution + 1; ix++)
            {
                for (int iz = 0; iz < zResolution + 1; iz++)
                {
                    xvalues[ix, iz] = (xvalues[ix, iz] - xmean) * xFactor;
                    zvalues[ix, iz] = (zvalues[ix, iz] - zmean) * zFactor;
                    yvalues[ix, iz] = (yvalues[ix, iz] - ymean) * yFactor;
                }
            }

            ymin_out = ymin;
            ymax_out = ymax;


            ymin = (ymin - ymean) * yFactor;
            ymax = (ymax - ymean) * yFactor;

            ScaledXmin = xmin * xFactor;
            ScaledZmin = zmin * zFactor;

            double ytruncate2 = (ytruncate - ymin) * yFactor;


            if ((RenderStyle == "ALTITUDEMAP") || (RenderStyle == "ALTITUDEMAP2") || (RenderStyle == "ARGUMENTMAP"))
            {
                BitmapPixelMaker bm_maker = new BitmapPixelMaker(xResolution, zResolution);
                for (int ix = 0; ix < xResolution; ix++)
                {
                    for (int iz = 0; iz < zResolution; iz++)
                    {
                        byte red, green, blue;
                        if (RenderStyle == "ARGUMENTMAP")
                        {
                            MapColorWheel(y2values[ix, iz], -3.14159, 3.14159, out red, out green, out blue);
                        }
                        else
                        {
                            MapRainbowColor(yvalues[ix, iz], ymin, ymax, out red, out green, out blue);
                        }
                        //bm_maker.SetPixel(ix, iz, red, green, blue, 1);
                        bm_maker.SetPixel(ix, iz, red, green, blue, 255);
                    }
                }
                WriteableBitmap wbitmap = bm_maker.MakeBitmap(96, 96);
                MyBitmapImage = ConvertWriteableBitmapToBitmapImage(wbitmap);
            }
        }

        public BitmapImage ConvertWriteableBitmapToBitmapImage(WriteableBitmap wbm)
        {
            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();
            }
            return bmImage;
        }


        // Map a value to a rainbow color.
        private void MapRainbowColor(double value, double min_value, double max_value,
            out byte red, out byte green, out byte blue)
        {
            // Convert into a value between 0 and 1023.
            int int_value = (int)(1023 * (value - min_value) / (max_value - min_value));
            if (RenderStyle == "ALTITUDEMAP")
            {
                int_value = Math.Abs(int_value - 1023);
            }
            // Map different color bands.
            if (int_value < 256)
            {
                // Red to yellow. (255, 0, 0) to (255, 255, 0).
                red = 255;
                green = (byte)int_value;
                blue = 0;
            }
            else if (int_value < 512)
            {
                // Yellow to green. (255, 255, 0) to (0, 255, 0).
                int_value -= 256;
                red = (byte)(255 - int_value);
                green = 255;
                blue = 0;
            }
            else if (int_value < 768)
            {
                // Green to aqua. (0, 255, 0) to (0, 255, 255).
                int_value -= 512;
                red = 0;
                green = 255;
                blue = (byte)int_value;
            }
            else
            {
                // Aqua to blue. (0, 255, 255) to (0, 0, 255).
                int_value -= 768;
                red = 0;
                green = (byte)(255 - int_value);
                blue = 255;
            }
        }


        // Map a value to a rainbow color.
        private void MapColorWheel(double value, double min_value, double max_value,
            out byte red, out byte green, out byte blue)
        {
            if (Double.IsNaN(value)) value = 0.0;
            // Convert into a value between 0 and 1023.
            int int_value = (int)((1023 + 512) * (value - min_value) / (max_value - min_value));
            int_value = Math.Abs(int_value - (1023 + 512));

            // Map different color bands.
            if (int_value < 256)
            {
                // Red to yellow. (255, 0, 0) to (255, 255, 0).
                red = 255;
                green = (byte)int_value;
                blue = 0;
            }
            else if (int_value < 512)
            {
                // Yellow to green. (255, 255, 0) to (0, 255, 0).
                int_value -= 256;
                red = (byte)(255 - int_value);
                green = 255;
                blue = 0;
            }
            else if (int_value < 768)
            {
                // Green to aqua. (0, 255, 0) to (0, 255, 255).
                int_value -= 512;
                red = 0;
                green = 255;
                blue = (byte)int_value;
            }
            else if (int_value < 1024)
            {
                // Aqua to blue. (0, 255, 255) to (0, 0, 255).
                int_value -= 768;
                red = 0;
                green = (byte)(255 - int_value);
                blue = 255;
            }
            else if (int_value < 1280)
            {
                // Blue  to violet. (0, 0, 255) to (255, 0, 255).
                int_value -= 1024;
                red = (byte)int_value;
                green = 0;
                blue = 255;
            }
            else
            {
                // Blue  to violet. (255, 0, 255) to (255, 0, 0).
                int_value -= 1280;
                red = 255;
                green = 0;
                blue = (byte)(255 - int_value);
            }
        }






    }



    // A class to represent WriteableBitmap pixels in Bgra32 format.
    public class BitmapPixelMaker
    {
        // The bitmap's size.
        private int Width, Height;

        // The pixel array.
        private byte[] Pixels;

        // The number of bytes per row.
        private int Stride;

        // Constructor. Width and height required.
        public BitmapPixelMaker(int width, int height)
        {
            // Save the width and height.
            Width = width;
            Height = height;

            // Create the pixel array.
            Pixels = new byte[width * height * 4];

            // Calculate the stride.
            Stride = width * 4;
        }

        // Get a pixel's value.
        public void GetPixel(int x, int y, out byte red, out byte green, out byte blue, out byte alpha)
        {
            int index = y * Stride + x * 4;
            blue = Pixels[index++];
            green = Pixels[index++];
            red = Pixels[index++];
            alpha = Pixels[index];
        }
        public byte GetBlue(int x, int y)
        {
            return Pixels[y * Stride + x * 4];
        }
        public byte GetGreen(int x, int y)
        {
            return Pixels[y * Stride + x * 4 + 1];
        }
        public byte GetRed(int x, int y)
        {
            return Pixels[y * Stride + x * 4 + 2];
        }
        public byte GetAlpha(int x, int y)
        {
            return Pixels[y * Stride + x * 4 + 3];
        }

        // Set a pixel's value.
        public void SetPixel(int x, int y, byte red, byte green, byte blue, byte alpha)
        {
            int index = y * Stride + x * 4;
            Pixels[index++] = blue;
            Pixels[index++] = green;
            Pixels[index++] = red;
            Pixels[index++] = alpha;
        }
        public void SetBlue(int x, int y, byte blue)
        {
            Pixels[y * Stride + x * 4] = blue;
        }
        public void SetGreen(int x, int y, byte green)
        {
            Pixels[y * Stride + x * 4 + 1] = green;
        }
        public void SetRed(int x, int y, byte red)
        {
            Pixels[y * Stride + x * 4 + 2] = red;
        }
        public void SetAlpha(int x, int y, byte alpha)
        {
            Pixels[y * Stride + x * 4 + 3] = alpha;
        }

        // Set all pixels to a specific color.
        public void SetColor(byte red, byte green, byte blue, byte alpha)
        {
            int num_bytes = Width * Height * 4;
            int index = 0;
            while (index < num_bytes)
            {
                Pixels[index++] = blue;
                Pixels[index++] = green;
                Pixels[index++] = red;
                Pixels[index++] = alpha;
            }
        }

        // Set all pixels to a specific opaque color.
        public void SetColor(byte red, byte green, byte blue)
        {
            SetColor(red, green, blue, 255);
        }

        // Use the pixel data to create a WriteableBitmap.
        public WriteableBitmap MakeBitmap(double dpiX, double dpiY)
        {
            // Create the WriteableBitmap.
            WriteableBitmap wbitmap = new WriteableBitmap(
                Width, Height, dpiX, dpiY,
                PixelFormats.Bgra32, null);

            // Load the pixel data.
            Int32Rect rect = new Int32Rect(0, 0, Width, Height);
            wbitmap.WritePixels(rect, Pixels, Stride, 0);

            // Return the bitmap.
            return wbitmap;
        }






    }

    //   }



}
