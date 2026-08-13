
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Size = System.Windows.Size;


namespace TinyPlot3DCtrl
{


    /// <summary>
    /// Interaction logic for Wpf3Control1.xaml
    /// </summary>
    public partial class Wpf3DCtrl : System.Windows.Controls.UserControl
    {
        private Model3DGroup MainModel3Dgroup = new Model3DGroup();
        private PerspectiveCamera myPCamera = new PerspectiveCamera();
        private OrthographicCamera myOCamera = new OrthographicCamera();
        private double CameraPhi = Math.PI / 10.0;
        private double CameraTheta = 120 * Math.PI / 180.0;
        private double CameraRStart = 4.0;
        private double CameraR = 4.0;
        private Boolean UseOrthographicCamera = false;

        public Wpf3DCtrl()
        {
            InitializeComponent();
            PositionCamera();
            DefineLights();
            ModelVisual3D model_visual = new ModelVisual3D();
            model_visual.Content = MainModel3Dgroup;
            MainViewport.Children.Add(model_visual);
        }



        public void ClearModel()
        {
            int n = MainModel3Dgroup.Children.Count - 1;

            for (int i = n; i > 2; i--)
            {
                MainModel3Dgroup.Children.RemoveAt(i);
            }
            //MainViewport.Opacity = 0.5;
        }



        #region Rotation


        private void RotateMesh(MeshGeometry3D Mesh, string RotationOrder, double XRotation, double YRotation, double ZRotation)
        {
            if ((RotationOrder == "X-Y-Z") || (RotationOrder == "X-Z-Y"))
            {
                if (XRotation != 0.0)
                    Mesh.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), XRotation));
                if (RotationOrder == "X-Y-Z")
                {
                    if (YRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.ZVector(), new Point3D(0, 0, 0), YRotation));
                    if (ZRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.YVector(), new Point3D(0, 0, 0), ZRotation));
                }
                else
                {
                    if (ZRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.YVector(), new Point3D(0, 0, 0), ZRotation));
                    if (YRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.ZVector(), new Point3D(0, 0, 0), YRotation));
                }
            }
            else if ((RotationOrder == "Y-X-Z") || (RotationOrder == "Y-Z-X"))
            {
                if (YRotation != 0.0)
                    Mesh.ApplyTransformation(D3.Rotate(D3.ZVector(), new Point3D(0, 0, 0), YRotation));
                if (RotationOrder == "Y-X-Z")
                {
                    if (XRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), XRotation));
                    if (ZRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.YVector(), new Point3D(0, 0, 0), ZRotation));
                }
                else
                {
                    if (ZRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.YVector(), new Point3D(0, 0, 0), ZRotation));
                    if (XRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), XRotation));
                }
            }
            else if ((RotationOrder == "Z-X-Y") || (RotationOrder == "Z-Y-X"))
            {
                if (ZRotation != 0.0)
                    Mesh.ApplyTransformation(D3.Rotate(D3.YVector(), new Point3D(0, 0, 0), ZRotation));
                if (RotationOrder == "Z-X-Y")
                {
                    if (XRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), XRotation));
                    if (YRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.ZVector(), new Point3D(0, 0, 0), YRotation));
                }
                else
                {
                    if (YRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.ZVector(), new Point3D(0, 0, 0), YRotation));
                    if (XRotation != 0.0)
                        Mesh.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), XRotation));
                }
            }

        }





        #endregion













        #region Explicit or parametric surface definitions


        private void AddTriangle(Dictionary<Point3D, int> PointDictionary, MeshGeometry3D mesh, Point3D point1, Point3D point2, Point3D point3, double xmin, double zmin)
        {

            int index1 = AddPoint(PointDictionary, mesh.Positions, mesh.TextureCoordinates, point1, xmin, zmin);
            int index2 = AddPoint(PointDictionary, mesh.Positions, mesh.TextureCoordinates, point2, xmin, zmin);
            int index3 = AddPoint(PointDictionary, mesh.Positions, mesh.TextureCoordinates, point3, xmin, zmin);
            mesh.TriangleIndices.Add(index1);
            mesh.TriangleIndices.Add(index2);
            mesh.TriangleIndices.Add(index3);
        }


        private int AddPoint(Dictionary<Point3D, int> PointDictionary, Point3DCollection points, PointCollection texture_coords, Point3D point, double xmin, double zmin)
        {
            // If the point is in the point dictionary, return its saved index.
            if (PointDictionary.ContainsKey(point))
                return PointDictionary[point];

            // If not, create it, and return the new point's index.
            points.Add(point);
            PointDictionary.Add(point, points.Count - 1);
            double texture_xscale = 1.0;
            double texture_zscale = 1.0;
            //double texture_zscale = 1.0;
            texture_coords.Add(new Point(
                    (point.X - xmin) * texture_xscale,
                    (point.Z - zmin) * texture_zscale));
            return points.Count - 1;
        }

        public void DefineExplicitOrParametricModel(Plot3DCtrl FlexDlg, Data3DNew D)
        {
            WpfGraphicsSettings wpfGraphicsSettings = Plot3DCtrl.wpfSettings1;

            if (wpfGraphicsSettings.ShowAxes) AddAxes(wpfGraphicsSettings);

            int Opacity = (255 - wpfGraphicsSettings.Transparency);

            string SurfaceMaterial1 = wpfGraphicsSettings.SurfaceMaterial1;
            bool ShowF = SurfaceMaterial1 != "None";
            bool ShowB = wpfGraphicsSettings.BackMaterial1 != "None";

            string SurfaceColorMap1 = "";
            if (!string.IsNullOrEmpty(wpfGraphicsSettings.SurfaceColorMap1)) { SurfaceColorMap1 = wpfGraphicsSettings.SurfaceColorMap1; }

            string BackMaterial1 = "";
            if (!string.IsNullOrEmpty(wpfGraphicsSettings.BackMaterial1)) { BackMaterial1 = wpfGraphicsSettings.BackMaterial1; }

            Dictionary<Point3D, int> PointDictionary = new Dictionary<Point3D, int>();
            MeshGeometry3D mesh = new MeshGeometry3D();

            int xResolution = wpfGraphicsSettings.Resolution;
            int zResolution = wpfGraphicsSettings.Resolution;
            if (wpfGraphicsSettings.Resolution2 > 0)
                zResolution = wpfGraphicsSettings.Resolution2;
            int izStart = 0;
            int izStop = zResolution;


            string RotationOrder = wpfGraphicsSettings.FinalRotationOrder;
            if (string.IsNullOrEmpty(RotationOrder)) RotationOrder = "X-Y-Z";

            double XRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalXRotation);
            if (double.IsNaN(XRotation)) return;

            double YRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalYRotation);
            if (double.IsNaN(YRotation)) return;

            double ZRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalZRotation);
            if (double.IsNaN(ZRotation)) return;


            if (wpfGraphicsSettings.HighlightVertices)
            {
                var colv = wpfGraphicsSettings.VerticesColor;
                Brush Vbrush = new SolidColorBrush(Color.FromArgb(colv.A, colv.R, colv.G, colv.B));

                double size = wpfGraphicsSettings.VerticesThickness;
                MeshGeometry3D verticesMesh = new MeshGeometry3D();
                for (int ix = 0; ix <= (xResolution - 0); ix++)
                {
                    for (int iz = izStart; iz <= izStop; iz++)
                    {
                        Point3D p = new Point3D(D.xvalues[ix, iz], D.yvalues[ix, iz], D.zvalues[ix, iz]);
                        verticesMesh.AddSphere(p, size, 10, 5, false);
                    }
                }
                MainModel3Dgroup.Children.Add(verticesMesh.MakeModel(Vbrush));
                RotateMesh(verticesMesh, RotationOrder, XRotation, YRotation, ZRotation);
            }


            if (wpfGraphicsSettings.ShowWireframe)
            {
                var col = wpfGraphicsSettings.WireframeColor;
                Brush Wbrush = new SolidColorBrush(Color.FromArgb(col.A, col.R, col.G, col.B));
                Point3D[,] points = new Point3D[xResolution + 1, zResolution + 1];
                for (int ix = 0; ix <= (xResolution - 0); ix++)
                {
                    for (int iz = izStart; iz <= izStop; iz++)
                    {
                        points[ix, iz] = new Point3D(D.xvalues[ix, iz], D.yvalues[ix, iz], D.zvalues[ix, iz]);
                    }
                }
                MeshGeometry3D mesh1 = new MeshGeometry3D();
                GeometryModel3D model = new GeometryModel3D(mesh1, null);
                HashSet<Edge> edges = new HashSet<Edge>();
                MeshGeometry3D wireframeMesh = new MeshGeometry3D();
                wireframeMesh.AddSurface(points, wpfGraphicsSettings.SurfaceSmoothing, edges, wpfGraphicsSettings.WireframeThickness);
                MainModel3Dgroup.Children.Add(wireframeMesh.MakeModel(Wbrush));
                RotateMesh(wireframeMesh, RotationOrder, XRotation, YRotation, ZRotation);
            }



            if (ShowF && ((SurfaceMaterial1 == "PlainColor") || (SurfaceMaterial1 == "GlossyColor")) && !wpfGraphicsSettings.SurfaceSmoothing)
            {
                Material material = null;
                Material materialSurface = null;

                Point3D[,] points = new Point3D[xResolution + 1, zResolution + 1];
                for (int ix = 0; ix <= (xResolution - 0); ix++)
                {
                    for (int iz = izStart; iz <= izStop; iz++)
                    {
                        points[ix, iz] = new Point3D(D.xvalues[ix, iz], D.yvalues[ix, iz], D.zvalues[ix, iz]);
                    }
                }
                MeshGeometry3D plainMesh = new MeshGeometry3D();
                plainMesh.AddSurface(points, wpfGraphicsSettings.SurfaceSmoothing);

                var col = wpfGraphicsSettings.SurfaceColor;
                Brush brush = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                brush.Opacity = 1.0 * Opacity / 255.0;

                MaterialGroup materialGroup = new MaterialGroup();
                materialSurface = new DiffuseMaterial(brush);
                materialGroup.Children.Add(materialSurface);
                if (wpfGraphicsSettings.SurfaceMaterial1 == "GlossyColor")
                {
                    Material materialSpec = new SpecularMaterial(Brushes.White, 100);
                    materialGroup.Children.Add(materialSpec);
                }
                material = materialGroup;


                GeometryModel3D model = new GeometryModel3D(plainMesh, material);

                if (BackMaterial1 == "SameAsForeground")
                {
                    model.BackMaterial = material;
                }
                else
                {
                    var backcol = wpfGraphicsSettings.BackColor;
                    Brush brush2 = new SolidColorBrush(Color.FromArgb((byte)Opacity, backcol.R, backcol.G, backcol.B));
                    model.BackMaterial = new DiffuseMaterial(brush2);
                }
                MainModel3Dgroup.Children.Add(model);
                RotateMesh(plainMesh, RotationOrder, XRotation, YRotation, ZRotation);
            }






            else if (ShowF && (SurfaceMaterial1 == "Gradient"))
            {
                MeshGeometry3D gradientMesh = new MeshGeometry3D();
                Point3D[,] points;


                if (wpfGraphicsSettings.SurfaceSmoothing)
                {
                    points = new Point3D[xResolution + 2, zResolution + 2];
                    for (int ix = 0; ix <= (xResolution - 0 - 1); ix++)
                    {
                        for (int iz = izStart; iz <= izStop - 1; iz++)
                        {
                            int ix_1 = ix + 1;
                            int iz_1 = iz + 1;

                            Point3D p00 = new Point3D(D.xvalues[ix, iz], D.yvalues[ix, iz], D.zvalues[ix, iz]);
                            Point3D p10 = new Point3D(D.xvalues[ix_1, iz], D.yvalues[ix_1, iz], D.zvalues[ix_1, iz]);
                            Point3D p01 = new Point3D(D.xvalues[ix, iz_1], D.yvalues[ix, iz_1], D.zvalues[ix, iz_1]);
                            Point3D p11 = new Point3D(D.xvalues[ix_1, iz_1], D.yvalues[ix_1, iz_1], D.zvalues[ix_1, iz_1]);
                            AddTriangle(PointDictionary, gradientMesh, p00, p01, p11, D.ScaledXmin, D.ScaledZmin);
                            AddTriangle(PointDictionary, gradientMesh, p00, p11, p10, D.ScaledXmin, D.ScaledZmin);
                        }
                    }
                }
                else
                {
                    points = new Point3D[xResolution + 1, zResolution + 1];
                    for (int ix = 0; ix <= (xResolution ); ix++)
                    {
                        for (int iz = izStart; iz <= izStop ; iz++)
                        {
                            points[ix, iz] = new Point3D(D.xvalues[ix, iz], D.yvalues[ix, iz], D.zvalues[ix, iz]);
                        }
                    }
                }

                gradientMesh.AddSurface(points, wpfGraphicsSettings.SurfaceSmoothing);


                LinearGradientBrush brush = null;
                if (wpfGraphicsSettings.SurfaceGradient1.Contains("Gradient"))
                {



                    if (wpfGraphicsSettings.SurfaceGradient1.Contains("Height"))
                    {
                        // Apply a height map.
                        double minY = points[0, 0].Y;
                        double maxY = minY;
                        if (wpfGraphicsSettings.SurfaceSmoothing)
                        {
                            for (int i = 0; i < gradientMesh.Positions.Count; i++)
                            {

                                if (minY > gradientMesh.Positions[i].Y) minY = gradientMesh.Positions[i].Y;
                                if (maxY < gradientMesh.Positions[i].Y) maxY = gradientMesh.Positions[i].Y;
                            }
                        }
                        else
                        {
                            foreach (Point3D point in points)
                            {
                                if (minY > point.Y) minY = point.Y;
                                if (maxY < point.Y) maxY = point.Y;
                            }
                        }
                        gradientMesh.ApplyHeightMap(0, 1, minY, maxY);
                    }
                    else
                    {
                        // Apply a sequence map.
                        gradientMesh.ApplySequenceMap(0, 1);
                    }


                    GradientStopCollection stops = new GradientStopCollection();

                    if (wpfGraphicsSettings.SurfaceGradient1.Contains("0"))
                    {
                        stops.Add(new GradientStop(Colors.Red, 0));
                        stops.Add(new GradientStop(Colors.Red, 0.1));
                        stops.Add(new GradientStop(Colors.DarkOrange, 0.2));
                        stops.Add(new GradientStop(Colors.Orange, 0.3));
                        stops.Add(new GradientStop(Colors.Yellow, 0.4));
                        stops.Add(new GradientStop(Colors.GreenYellow, 0.5));
                        stops.Add(new GradientStop(Colors.Green, 0.6));
                        stops.Add(new GradientStop(Colors.Cyan, 0.7));
                        stops.Add(new GradientStop(Colors.Blue, 0.8));
                        stops.Add(new GradientStop(Colors.MediumPurple, 0.90));
                        stops.Add(new GradientStop(Colors.Fuchsia, 1));
                    }
                    else
                    {
                        stops.Add(new GradientStop(Colors.Fuchsia, 0));
                        stops.Add(new GradientStop(Colors.MediumPurple, 0.1));
                        stops.Add(new GradientStop(Colors.Blue, 0.2));
                        stops.Add(new GradientStop(Colors.Cyan, 0.3));
                        stops.Add(new GradientStop(Colors.Green, 0.4));
                        stops.Add(new GradientStop(Colors.GreenYellow, 0.5));
                        stops.Add(new GradientStop(Colors.Yellow, 0.6));
                        stops.Add(new GradientStop(Colors.Orange, 0.7));
                        stops.Add(new GradientStop(Colors.DarkOrange, 0.8));
                        stops.Add(new GradientStop(Colors.Red, 0.90));
                        stops.Add(new GradientStop(Colors.Red, 1));
                    }

                    brush = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 1));
                }

                brush.Opacity = 1.0 * Opacity / 255.0;
                Material surface_material = new DiffuseMaterial(brush);
                GeometryModel3D surface_model = new GeometryModel3D(gradientMesh, surface_material);

                if (BackMaterial1 == "SameAsForeground")
                {
                    surface_model.BackMaterial = surface_material;
                }
                else
                {
                    var col = wpfGraphicsSettings.BackColor;
                    Brush brush2 = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                    surface_model.BackMaterial = new DiffuseMaterial(brush2);
                }
                MainModel3Dgroup.Children.Add(surface_model);

                RotateMesh(gradientMesh, RotationOrder, XRotation, YRotation, ZRotation);
            }




            else
            {
                MeshGeometry3D valuesMesh = new MeshGeometry3D();

                string Texture1 = wpfGraphicsSettings.SurfaceTexture1;

                //if (((SurfaceMaterial1 == "Texture")) || (wpfGraphicsSettings.SurfaceSmoothing))
                //{
                for (int ix = 0; ix < (xResolution - 0); ix++)
                {
                    for (int iz = izStart; iz < izStop; iz++)
                    {
                        int ix_1 = ix + 1;
                        int iz_1 = iz + 1;

                        Point3D p00 = new Point3D(D.xvalues[ix, iz], D.yvalues[ix, iz], D.zvalues[ix, iz]);
                        Point3D p10 = new Point3D(D.xvalues[ix_1, iz], D.yvalues[ix_1, iz], D.zvalues[ix_1, iz]);
                        Point3D p01 = new Point3D(D.xvalues[ix, iz_1], D.yvalues[ix, iz_1], D.zvalues[ix, iz_1]);
                        Point3D p11 = new Point3D(D.xvalues[ix_1, iz_1], D.yvalues[ix_1, iz_1], D.zvalues[ix_1, iz_1]);
                        AddTriangle(PointDictionary, valuesMesh, p00, p01, p11, D.ScaledXmin, D.ScaledZmin);
                        AddTriangle(PointDictionary, valuesMesh, p00, p11, p10, D.ScaledXmin, D.ScaledZmin);
                    }
                }
                //}

                if (ShowF || ShowB)
                {
                    Material material = null;

                    GeometryModel3D model = null;
                    Material materialSurface = null;
                    if (ShowF)
                    {
                        if (SurfaceMaterial1 == "Texture")
                        {
                            string TexturePath = Plot3DCtrl._TexturePath + @"\" + Texture1;
                            ImageBrush texture_brush = new ImageBrush();
                            texture_brush.ImageSource = new BitmapImage(new Uri(TexturePath, UriKind.Absolute));
                            //texture_brush.Opacity = Opacity / 255;
                            texture_brush.Opacity = 1.0 * Opacity / 255.0;
                            material = new DiffuseMaterial(texture_brush);
                        }
                        else if (SurfaceMaterial1 == "ColorMap")
                        {
                            ImageBrush texture_brush = new ImageBrush();
                            texture_brush.ImageSource = D.MyBitmapImage;
                            //texture_brush.Opacity = 1.0 - (1.0 * wpfGraphicsSettings.Transparency / 255.0);
                            material = new DiffuseMaterial(texture_brush);
                        }

                        else
                        {
                            var col = wpfGraphicsSettings.SurfaceColor;
                            Brush brush = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                            MaterialGroup materialGroup = new MaterialGroup();
                            materialSurface = new DiffuseMaterial(brush);
                            materialGroup.Children.Add(materialSurface);
                            if (wpfGraphicsSettings.SurfaceMaterial1 == "GlossyColor")
                            {
                                Material materialSpec = new SpecularMaterial(Brushes.White, 100);
                                materialGroup.Children.Add(materialSpec);
                            }
                            material = materialGroup;
                        }
                        model = new GeometryModel3D(valuesMesh, material);

                        RotateMesh(valuesMesh, RotationOrder, XRotation, YRotation, ZRotation);
                    }
                    if (ShowB)
                    {
                        if (BackMaterial1 == "SameAsForeground")
                        {
                            model.BackMaterial = material;
                        }
                        else
                        {
                            var col = wpfGraphicsSettings.BackColor;
                            Brush brush2 = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                            model.BackMaterial = new DiffuseMaterial(brush2);
                        }
                    }
                    MainModel3Dgroup.Children.Add((model));
                }
            }









        }




        #endregion







        #region Path surface definitions


        // Apply rotation if a sequence other than "SequenceX" has been used to build the mesh.
        void RotatePathMeshOrder(MeshGeometry3D PathMesh, string sequence)
        {
            if (sequence == "SequenceY")
            {
                PathMesh.ApplyTransformation(D3.Rotate(D3.YVector(), new Point3D(0, 0, 0), -90));
                PathMesh.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), 180));
            }

            else if (sequence == "SequenceZ")
            {
                PathMesh.ApplyTransformation(D3.Rotate(D3.ZVector(), new Point3D(0, 0, 0), -90));
                PathMesh.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), -90));
            }

        }


        // Make points to define a D surface.
        Point3D[] MakePathSurfacePoints2(Plot3DCtrl FlexDlg, double tMin, double tMax, int numPoints, Point3D center, int ExtraDt = 3, bool samescale = false, bool centeredxy = false)
        {
            WpfGraphicsSettings wpfGraphicsSettings = Plot3DCtrl.wpfSettings1;


            string PathEvalOrder = wpfGraphicsSettings.PathEvalOrder;

            // Generate the points.
            Point3D[] points = new Point3D[numPoints + ExtraDt];

            string FName = FlexDlg.GetTemplatePath() + "CodeTest.txt";
            string s1 = wpfGraphicsSettings.Code;
            string Code = FlexDlg.GetCodePath(s1, numPoints, ExtraDt, tMin, tMax);
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
                    for (int i = 0; i < numPoints + ExtraDt; i++)
                    {
                        points[i] = center + new Vector3D(Result[0, i], Result[1, i], Result[2, i]);
                    }
                else
                {
                    MessageBox.Show(RS);
                    return points;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return points;
            }


            int n = numPoints + ExtraDt;
            double[] xa = new double[n];
            double[] ya = new double[n];
            double[] za = new double[n];

            for (int i = 0; i < n; i++)
            {
                xa[i] = points[i].X;
                ya[i] = points[i].Y;   // this is the height
                za[i] = points[i].Z;
            }


            double xmax1 = double.NegativeInfinity;
            double xmin1 = double.PositiveInfinity;
            double ymax1 = double.NegativeInfinity;
            double ymin1 = double.PositiveInfinity;
            double zmax1 = double.NegativeInfinity;
            double zmin1 = double.PositiveInfinity;
            for (int i = 0; i < n; i++)
            {
                if (xa[i] > xmax1) xmax1 = xa[i];
                if (xa[i] < xmin1) xmin1 = xa[i];
                if (ya[i] > ymax1) ymax1 = ya[i];
                if (ya[i] < ymin1) ymin1 = ya[i];
                if (za[i] > zmax1) zmax1 = za[i];
                if (za[i] < zmin1) zmin1 = za[i];
            }


            if (samescale)
            {
                double amax1 = xmax1;
                if (amax1 < ymax1) amax1 = ymax1;
                if (amax1 < zmax1) amax1 = zmax1;
                double amin1 = xmin1;
                if (amin1 > ymin1) amin1 = ymin1;
                if (amin1 > zmin1) amin1 = zmin1;
                xmax1 = amax1;
                ymax1 = amax1;
                zmax1 = amax1;
                xmin1 = amin1;
                ymin1 = amin1;
                zmin1 = amin1;
            }


            if (centeredxy)
            {
                double amax1;
                double amin1;
                if (PathEvalOrder == "SequenceZ")
                {
                    amax1 = xmax1;
                    if (amax1 < ymax1) amax1 = ymax1;
                    amin1 = xmin1;
                    if (amin1 > ymin1) amin1 = ymin1;
                    if (Math.Abs(amin1) < amax1) { amin1 = -amax1; }
                    if (Math.Abs(amin1) > amax1) { amax1 = -amin1; }
                    xmax1 = amax1;
                    ymax1 = amax1;
                    xmin1 = amin1;
                    ymin1 = amin1;
                }
                else
                {
                    amax1 = xmax1;
                    if (amax1 < zmax1) amax1 = zmax1;
                    amin1 = xmin1;
                    if (amin1 > zmin1) amin1 = zmin1;
                    if (Math.Abs(amin1) < amax1) { amin1 = -amax1; }
                    if (Math.Abs(amin1) > amax1) { amax1 = -amin1; }
                    xmax1 = amax1;
                    zmax1 = amax1;
                    xmin1 = amin1;
                    zmin1 = amin1;
                }
            }



            double xrange = (xmax1 - xmin1);
            double yrange = (ymax1 - ymin1);
            double zrange = (zmax1 - zmin1);
            double xcenter = xmin1 + xrange / 2;
            double ycenter = ymin1 + yrange / 2;
            double zcenter = zmin1 + zrange / 2;

            for (int i = 0; i < n; i++)
            {
                if (xrange != 0.0) { xa[i] = (xa[i] - xcenter) / xrange; }
                if (yrange != 0.0) { ya[i] = (ya[i] - ycenter) / yrange; }
                if (zrange != 0.0) { za[i] = (za[i] - zcenter) / zrange; }
            }

            Point3D[] path = new Point3D[n];
            for (int i = 0; i < n; i++)
            {
                path[i] = D3.Origin + new Vector3D(xa[i], ya[i], za[i]);
            }

            return path;

        }


        public void Define3DPathModel(Plot3DCtrl FlexDlg)
        {
            WpfGraphicsSettings wpfGraphicsSettings = Plot3DCtrl.wpfSettings1;
            if (wpfGraphicsSettings.ShowAxes) AddAxes(wpfGraphicsSettings);

            bool SameScale = wpfGraphicsSettings.SameScale == "All";

            bool CenteredXY = wpfGraphicsSettings.CenteredXY;

            string SolidType = "None";
            if (!string.IsNullOrEmpty(wpfGraphicsSettings.SolidType))
                SolidType = wpfGraphicsSettings.SolidType;

            bool ShowW = wpfGraphicsSettings.ShowWireframe;
            string SurfaceMaterial1 = wpfGraphicsSettings.SurfaceMaterial1;
            bool ShowF = SurfaceMaterial1 != "None";
            bool ShowB = wpfGraphicsSettings.BackMaterial1 != "None";
            bool Smooth = wpfGraphicsSettings.SurfaceSmoothing;
            double WThickness = wpfGraphicsSettings.WireframeThickness;

            string RotationOrder = wpfGraphicsSettings.FinalRotationOrder;
            if (string.IsNullOrEmpty(RotationOrder)) RotationOrder = "X-Y-Z";

            double XRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalXRotation);
            if (double.IsNaN(XRotation)) return;

            double YRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalYRotation);
            if (double.IsNaN(YRotation)) return;

            double ZRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalZRotation);
            if (double.IsNaN(ZRotation)) return;

            string Texture1 = wpfGraphicsSettings.SurfaceTexture1;

            int Opacity = (255 - wpfGraphicsSettings.Transparency);
            if (Opacity < 0) Opacity = 0;
            if (Opacity > 255) Opacity = 255;

            int BackgroundSolidOpacity = (255 - wpfGraphicsSettings.BackgroundSolidTransparency);
            if (BackgroundSolidOpacity < 0) BackgroundSolidOpacity = 0;
            if (BackgroundSolidOpacity > 255) BackgroundSolidOpacity = 255;


            string BackMaterial1 = "";
            if (!string.IsNullOrEmpty(wpfGraphicsSettings.BackMaterial1)) { BackMaterial1 = wpfGraphicsSettings.BackMaterial1; }

            int numPoints = wpfGraphicsSettings.Resolution;

            double tmin = FlexDlg.Eval(wpfGraphicsSettings.xmin);
            if (double.IsNaN(tmin)) return;

            double tmax = FlexDlg.Eval(wpfGraphicsSettings.xmax);
            if (double.IsNaN(tmax)) return;

            double Radius = FlexDlg.Eval(wpfGraphicsSettings.zmax);
            if (double.IsNaN(Radius)) return;

            int PolygonPoints = wpfGraphicsSettings.Resolution2;
            int PathPoints = numPoints;
            double tMin = tmin;
            double tMax = tmax;
            int ExtraDt = 0;
            if (wpfGraphicsSettings.RepeatStart) ExtraDt = 3;
            else ExtraDt = 2;


            Point3D[] generator = G3.MakePolygonPoints(PolygonPoints, D3.Origin, D3.XVector(Radius), D3.ZVector(Radius));

            int numGen = generator.Length + 1;  // this closes the generator path (may be open)
            Array.Resize(ref generator, numGen);
            generator[numGen - 1] = generator[0];

            Point3D[] D = MakePathSurfacePoints2(FlexDlg, tMin, tMax, PathPoints, D3.Origin, ExtraDt, SameScale, CenteredXY);




            MeshGeometry3D valuesMesh = new MeshGeometry3D();
            MeshGeometry3D wireframeMesh = new MeshGeometry3D();

            if (ShowF || ShowB)
            {
                valuesMesh.AddPathSurface(generator, D, D3.ZVector(), false, false, Smooth);
            }

            if (ShowW)
            {
                HashSet<Edge> edges = new HashSet<Edge>();
                wireframeMesh.AddPathSurface(generator, D, D3.ZVector(), false, false, smooth: Smooth, edges: edges, thickness: WThickness);
            }



            if (wpfGraphicsSettings.HighlightVertices)
            {
                MeshGeometry3D verticesMesh = new MeshGeometry3D();
                var colv = wpfGraphicsSettings.VerticesColor;
                Brush Vbrush = new SolidColorBrush(Color.FromArgb(colv.A, colv.R, colv.G, colv.B));
                foreach (Point3D point in valuesMesh.Positions)
                    verticesMesh.AddSphere(point, wpfGraphicsSettings.VerticesThickness, 10, 5, false, thickness: wpfGraphicsSettings.VerticesThickness / 2.0);
                MainModel3Dgroup.Children.Add(verticesMesh.MakeModel(Vbrush));

                RotatePathMeshOrder(verticesMesh, wpfGraphicsSettings.PathEvalOrder);

                RotateMesh(verticesMesh, RotationOrder, XRotation, YRotation, ZRotation);
            }

            if (ShowW)
            {
                var col = wpfGraphicsSettings.WireframeColor;
                Brush Wbrush = new SolidColorBrush(Color.FromArgb(col.A, col.R, col.G, col.B));
                MainModel3Dgroup.Children.Add(wireframeMesh.MakeModel(Wbrush));

                RotatePathMeshOrder(wireframeMesh, wpfGraphicsSettings.PathEvalOrder);

                RotateMesh(wireframeMesh, RotationOrder, XRotation, YRotation, ZRotation);
            }



            if (ShowF && (SurfaceMaterial1 == "Gradient"))
            {
                MeshGeometry3D gradientMesh = new MeshGeometry3D();
                Material surface_material = null;
                gradientMesh.AddPathSurface(generator, D, D3.ZVector(), false, false, Smooth);

                RotatePathMeshOrder(gradientMesh, wpfGraphicsSettings.PathEvalOrder);
                RotateMesh(gradientMesh, RotationOrder, XRotation, YRotation, ZRotation);


                if (wpfGraphicsSettings.SurfaceGradient1.Contains("Gradient"))
                {
                    if (wpfGraphicsSettings.SurfaceGradient1.Contains("Height"))
                    {
                        // Apply a height map.
                        double minY = D[0].Y;
                        double maxY = minY;
                        foreach (Point3D point in D)
                        {
                            if (minY > point.Y) minY = point.Y;
                            if (maxY < point.Y) maxY = point.Y;
                        }
                        gradientMesh.ApplyHeightMap(0, 1, minY, maxY);
                    }
                    else
                    {
                        // Apply a sequence map.
                        gradientMesh.ApplySequenceMap(0, 1);
                    }


                    GradientStopCollection stops = new GradientStopCollection();

                    if (wpfGraphicsSettings.SurfaceGradient1.Contains("0"))
                    {
                        stops.Add(new GradientStop(Colors.Red, 0));
                        stops.Add(new GradientStop(Colors.Red, 0.1));
                        stops.Add(new GradientStop(Colors.DarkOrange, 0.2));
                        stops.Add(new GradientStop(Colors.Orange, 0.3));
                        stops.Add(new GradientStop(Colors.Yellow, 0.4));
                        stops.Add(new GradientStop(Colors.GreenYellow, 0.5));
                        stops.Add(new GradientStop(Colors.Green, 0.6));
                        stops.Add(new GradientStop(Colors.Cyan, 0.7));
                        stops.Add(new GradientStop(Colors.Blue, 0.8));
                        stops.Add(new GradientStop(Colors.MediumPurple, 0.90));
                        stops.Add(new GradientStop(Colors.Fuchsia, 1));
                    }
                    else
                    {
                        stops.Add(new GradientStop(Colors.Fuchsia, 0));
                        stops.Add(new GradientStop(Colors.MediumPurple, 0.1));
                        stops.Add(new GradientStop(Colors.Blue, 0.2));
                        stops.Add(new GradientStop(Colors.Cyan, 0.3));
                        stops.Add(new GradientStop(Colors.Green, 0.4));
                        stops.Add(new GradientStop(Colors.GreenYellow, 0.5));
                        stops.Add(new GradientStop(Colors.Yellow, 0.6));
                        stops.Add(new GradientStop(Colors.Orange, 0.7));
                        stops.Add(new GradientStop(Colors.DarkOrange, 0.8));
                        stops.Add(new GradientStop(Colors.Red, 0.90));
                        stops.Add(new GradientStop(Colors.Red, 1));
                    }

                    LinearGradientBrush brush = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 1));
                    brush.Opacity = 1.0 * Opacity / 255.0;
                    surface_material = new DiffuseMaterial(brush);
                }
                GeometryModel3D surface_model = new GeometryModel3D(gradientMesh, surface_material);

                surface_model.BackMaterial = surface_material;
                MainModel3Dgroup.Children.Add(surface_model);

                if (BackMaterial1 == "SameAsForeground")
                {
                    surface_model.BackMaterial = surface_material;
                }
                else
                {
                    var col = wpfGraphicsSettings.BackColor;
                    Brush brush2 = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                    surface_model.BackMaterial = new DiffuseMaterial(brush2);
                }
                MainModel3Dgroup.Children.Add(surface_model);

                //RotatePathMeshOrder(gradientMesh, wpfGraphicsSettings.PathEvalOrder);

                //RotateMesh(gradientMesh, RotationOrder, XRotation, YRotation, ZRotation);
            }





            else if (ShowF || ShowB)
            {
                GeometryModel3D model = null;
                if (ShowF)
                {
                    Material material = null;
                    {
                        var col = wpfGraphicsSettings.SurfaceColor;
                        Brush brush = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                        MaterialGroup materialGroup = new MaterialGroup();
                        Material materialBack = new DiffuseMaterial(brush);
                        materialGroup.Children.Add(materialBack);
                        if (wpfGraphicsSettings.SurfaceMaterial1 == "GlossyColor")
                        {
                            Material materialSpec = new SpecularMaterial(Brushes.White, 100);
                            materialGroup.Children.Add(materialSpec);
                        }
                        material = materialGroup;
                    }
                    model = new GeometryModel3D(valuesMesh, material);

                    RotatePathMeshOrder(valuesMesh, wpfGraphicsSettings.PathEvalOrder);

                    RotateMesh(valuesMesh, RotationOrder, XRotation, YRotation, ZRotation);
                }
                if (ShowB)
                {
                    var col = wpfGraphicsSettings.BackColor;
                    Brush brush2 = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                    model.BackMaterial = new DiffuseMaterial(brush2);
                }
                MainModel3Dgroup.Children.Add((model));
            }




            if (SolidType == "Column")
            {
                MeshGeometry3D mesh11 = new MeshGeometry3D();
                double size1 = 0.99;
                double a = 0.5;
                double b = 0.5;
                double c = 1.0;
                Point3D p1con = new Point3D(0, 0, 0);
                p1con.Y = -0.5 * c * size1;
                Point3D[] circle1 = G3.MakePolygonPoints(64, p1con, D3.XVector(a * size1), D3.ZVector(-b * size1));
                mesh11.AddCylinder(circle1, D3.YVector(c * size1), true);

                var col = wpfGraphicsSettings.BackgroundSolidColor;
                Brush brush = new SolidColorBrush(Color.FromArgb((byte)BackgroundSolidOpacity, col.R, col.G, col.B));
                MainModel3Dgroup.Children.Add(mesh11.MakeModel(brush));
            }

            if (SolidType == "Cone")
            {
                MeshGeometry3D mesh11 = new MeshGeometry3D();
                double size1 = 0.99;
                double a = 0.5;
                double b = 0.5;
                double c = 1.0;
                Point3D p1con = new Point3D(0, 0, 0);
                p1con.Y = -0.5 * c * size1;
                Point3D[] circle1 = G3.MakePolygonPoints(64, p1con, D3.XVector(a * size1), D3.ZVector(-b * size1));
                mesh11.AddCone(p1con, circle1, D3.YVector(c * size1));

                var col = wpfGraphicsSettings.BackgroundSolidColor;
                Brush brush = new SolidColorBrush(Color.FromArgb((byte)BackgroundSolidOpacity, col.R, col.G, col.B));
                MainModel3Dgroup.Children.Add(mesh11.MakeModel(brush));
            }

            if (SolidType == "Sphere")
            {
                // Make a smooth sphere.
                double scale = 0.28;
                MeshGeometry3D mesh11 = new MeshGeometry3D();
                mesh11.AddSphere(new Point3D(0, 0, 0), 1.75, 200, 100, true);
                mesh11.ApplyTransformation(new ScaleTransform3D(scale, scale, scale));

                var col = wpfGraphicsSettings.BackgroundSolidColor;
                Brush brush = new SolidColorBrush(Color.FromArgb((byte)BackgroundSolidOpacity, col.R, col.G, col.B));
                MainModel3Dgroup.Children.Add(mesh11.MakeModel(brush));
            }

            if (SolidType == "Torus")
            {
                // Make a smooth torus.
                double scale = 0.29;
                double R = 1.40;
                double r = 0.3;
                MeshGeometry3D mesh11 = new MeshGeometry3D();
                mesh11.AddTorus(new Point3D(0, 0, 0), R, r, 200, 100, true);
                mesh11.ApplyTransformation(D3.Rotate(D3.XVector(), new Point3D(0, 0, 0), 90));
                mesh11.ApplyTransformation(new ScaleTransform3D(scale, scale, scale));

                var col = wpfGraphicsSettings.BackgroundSolidColor;
                Brush brush = new SolidColorBrush(Color.FromArgb((byte)BackgroundSolidOpacity, col.R, col.G, col.B));
                MainModel3Dgroup.Children.Add(mesh11.MakeModel(brush));
            }




        }



        #endregion






        #region Builtin surface definitions



        public void DefineBuiltInModel(Plot3DCtrl FlexDlg)
        {
            WpfGraphicsSettings wpfGraphicsSettings = Plot3DCtrl.wpfSettings1;

            if (wpfGraphicsSettings.ShowAxes) AddAxes(wpfGraphicsSettings);

            MeshGeometry3D mesh2 = new MeshGeometry3D();
            MeshGeometry3D mesh4 = new MeshGeometry3D();
            HashSet<Edge> edges = new HashSet<Edge>();

            MeshGeometry3D valuesMesh = new MeshGeometry3D();
            MeshGeometry3D wireframeMesh = new MeshGeometry3D();




            bool ShowW = wpfGraphicsSettings.ShowWireframe;
            string SurfaceMaterial1 = wpfGraphicsSettings.SurfaceMaterial1;
            bool ShowF = SurfaceMaterial1 != "None";
            bool ShowB = wpfGraphicsSettings.BackMaterial1 != "None";
            bool Smooth = wpfGraphicsSettings.SurfaceSmoothing;
            double WThickness = wpfGraphicsSettings.WireframeThickness;

            string BackMaterial1 = "";
            if (!string.IsNullOrEmpty(wpfGraphicsSettings.BackMaterial1)) { BackMaterial1 = wpfGraphicsSettings.BackMaterial1; }

            string RotationOrder = wpfGraphicsSettings.FinalRotationOrder;
            if (string.IsNullOrEmpty(RotationOrder)) RotationOrder = "X-Y-Z";

            double XRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalXRotation);
            if (double.IsNaN(XRotation)) return;

            double YRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalYRotation);
            if (double.IsNaN(YRotation)) return;

            double ZRotation = FlexDlg.Eval(wpfGraphicsSettings.FinalZRotation);
            if (double.IsNaN(ZRotation)) return;


            int Opacity = (255 - wpfGraphicsSettings.Transparency);
            string Texture1 = wpfGraphicsSettings.SurfaceTexture1;
            if (Opacity < 0) Opacity = 0;
            if (Opacity > 255) Opacity = 255;


            Point3D p = new Point3D(0, 0, 0);
            Transform3DGroup transGroup2 = new Transform3DGroup();
            Transform3DGroup transGroup3 = new Transform3DGroup();



            if ((RotationOrder == "X-Y-Z") || (RotationOrder == "X-Z-Y"))
            {
                if (XRotation != 0.0)
                    transGroup3.Children.Add(D3.Rotate(D3.XVector(), D3.Origin, XRotation));
                if (RotationOrder == "X-Y-Z")
                {
                    if (YRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.ZVector(), D3.Origin, YRotation));
                    if (ZRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.YVector(), D3.Origin, ZRotation));
                }
                else
                {
                    if (ZRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.YVector(), D3.Origin, ZRotation));
                    if (YRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.ZVector(), D3.Origin, YRotation));
                }
            }
            else if ((RotationOrder == "Y-X-Z") || (RotationOrder == "Y-Z-X"))
            {
                if (YRotation != 0.0)
                    transGroup3.Children.Add(D3.Rotate(D3.ZVector(), D3.Origin, YRotation));
                if (RotationOrder == "Y-X-Z")
                {
                    if (XRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.XVector(), D3.Origin, XRotation));
                    if (ZRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.YVector(), D3.Origin, ZRotation));
                }
                else
                {
                    if (ZRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.YVector(), D3.Origin, ZRotation));
                    if (XRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.XVector(), D3.Origin, XRotation));
                }
            }
            else if ((RotationOrder == "Z-X-Y") || (RotationOrder == "Z-Y-X"))
            {
                if (ZRotation != 0.0)
                    transGroup3.Children.Add(D3.Rotate(D3.YVector(), D3.Origin, ZRotation));
                if (RotationOrder == "Z-X-Y")
                {
                    if (XRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.XVector(), D3.Origin, XRotation));
                    if (YRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.ZVector(), D3.Origin, YRotation));
                }
                else
                {
                    if (YRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.ZVector(), D3.Origin, YRotation));
                    if (XRotation != 0.0)
                        transGroup3.Children.Add(D3.Rotate(D3.XVector(), D3.Origin, XRotation));
                }
            }


            if (ShowF || ShowB)
            {
                string Code = wpfGraphicsSettings.Code;
                FlexDlg.ScriptEval(Code);
                BuiltIn.AddBuiltinSolid(valuesMesh, new Point3D(0, 0, 0), Smooth, texture: Texture1);
            }
            if (ShowW)
            {
                string Code = wpfGraphicsSettings.Code;
                FlexDlg.ScriptEval(Code);
                BuiltIn.AddBuiltinSolid(wireframeMesh, new Point3D(0, 0, 0), Smooth, edges: edges, thickness: WThickness);
                var col = wpfGraphicsSettings.WireframeColor;
                Brush Wbrush = new SolidColorBrush(Color.FromArgb(col.A, col.R, col.G, col.B));
                MainModel3Dgroup.Children.Add(wireframeMesh.MakeModel(Wbrush));
            }




            if (ShowF || ShowB)
            {

                valuesMesh.ApplyTransformation(transGroup3);

                double xmax1 = double.NegativeInfinity;
                double xmin1 = double.PositiveInfinity;
                double ymax1 = double.NegativeInfinity;
                double ymin1 = double.PositiveInfinity;
                double zmax1 = double.NegativeInfinity;
                double zmin1 = double.PositiveInfinity;
                foreach (Point3D point in valuesMesh.Positions)
                {
                    if (point.X > xmax1) xmax1 = point.X;
                    if (point.X < xmin1) xmin1 = point.X;
                    if (point.Y > ymax1) ymax1 = point.Y;
                    if (point.Y < ymin1) ymin1 = point.Y;
                    if (point.Z > zmax1) zmax1 = point.Z;
                    if (point.Z < zmin1) zmin1 = point.Z;
                }
                if (wpfGraphicsSettings.CenteredXY)
                {
                    double amax1 = xmax1;
                    if (amax1 < ymax1) amax1 = ymax1;
                    double amin1 = xmin1;
                    if (amin1 > ymin1) amin1 = ymin1;
                    if (Math.Abs(amin1) < amax1) { amin1 = -amax1; }
                    if (Math.Abs(amin1) > amax1) { amax1 = -amin1; }
                    xmax1 = amax1;
                    ymax1 = amax1;
                    xmin1 = amin1;
                    ymin1 = amin1;
                }
                if (wpfGraphicsSettings.SameScale == "All")
                {
                    double amax1 = xmax1;
                    if (amax1 < ymax1) amax1 = ymax1;
                    if (amax1 < zmax1) amax1 = zmax1;
                    double amin1 = xmin1;
                    if (amin1 > ymin1) amin1 = ymin1;
                    if (amin1 > zmin1) amin1 = zmin1;
                    xmax1 = amax1;
                    ymax1 = amax1;
                    zmax1 = amax1;
                    xmin1 = amin1;
                    ymin1 = amin1;
                    zmin1 = amin1;
                }
                double xrange = (xmax1 - xmin1);
                double yrange = (ymax1 - ymin1);
                double zrange = (zmax1 - zmin1);
                double xcenter = xmin1 + xrange / 2;
                double ycenter = ymin1 + yrange / 2;
                double zcenter = zmin1 + zrange / 2;

                transGroup2.Children.Add(new TranslateTransform3D(-xcenter, -ycenter, -zcenter));
                transGroup2.Children.Add(new ScaleTransform3D(1 / xrange, 1 / yrange, 1 / zrange));
            }


            if (ShowW)
            {
                wireframeMesh.ApplyTransformation(transGroup3);
                wireframeMesh.ApplyTransformation(transGroup2);
            }

            if (ShowF || ShowB)
            {
                valuesMesh.ApplyTransformation(transGroup2);

                GeometryModel3D model = null;
                Material material = null;
                material = null;
                if (ShowF)
                {
                    if (SurfaceMaterial1 == "Texture")
                    {
                        string TexturePath = Plot3DCtrl._TexturePath + @"\" + Texture1;
                        ImageBrush texture_brush = new ImageBrush();
                        texture_brush.ImageSource = new BitmapImage(new Uri(TexturePath, UriKind.Absolute));
                        texture_brush.Opacity = 1.0 * Opacity / 255.0;
                        //texture_brush.Opacity = 0.5;
                        material = new DiffuseMaterial(texture_brush);
                    }
                    else
                    {
                        var col = wpfGraphicsSettings.SurfaceColor;
                        Brush brush = new SolidColorBrush(Color.FromArgb((byte)Opacity, col.R, col.G, col.B));
                        MaterialGroup materialGroup = new MaterialGroup();
                        Material materialBack = new DiffuseMaterial(brush);
                        materialGroup.Children.Add(materialBack);
                        if (wpfGraphicsSettings.SurfaceMaterial1 == "GlossyColor")
                        {
                            Material materialSpec = new SpecularMaterial(Brushes.White, 100);
                            materialGroup.Children.Add(materialSpec);
                        }
                        material = materialGroup;
                    }
                    model = new GeometryModel3D(valuesMesh, material);
                }
                if (ShowB)
                {
                    if (BackMaterial1 == "SameAsForeground")
                    {
                        model.BackMaterial = material;
                    }
                    else
                    {
                        var col3 = wpfGraphicsSettings.BackColor;
                        Brush brush3 = new SolidColorBrush(Color.FromArgb((byte)Opacity, col3.R, col3.G, col3.B));
                        model.BackMaterial = new DiffuseMaterial(brush3);
                    }
                }


                // Highlight vertices.
                if (wpfGraphicsSettings.HighlightVertices)
                {
                    MeshGeometry3D verticesMesh = new MeshGeometry3D();
                    var colv = wpfGraphicsSettings.VerticesColor;
                    Brush Vbrush = new SolidColorBrush(Color.FromArgb(colv.A, colv.R, colv.G, colv.B));
                    foreach (Point3D point in valuesMesh.Positions)
                        verticesMesh.AddSphere(point, wpfGraphicsSettings.VerticesThickness, 10, 5, false, thickness: wpfGraphicsSettings.VerticesThickness / 2.0);
                    MainModel3Dgroup.Children.Add(verticesMesh.MakeModel(Vbrush));
                }

                MainModel3Dgroup.Children.Add((model));


            }

        }




        #endregion






        #region Add Axes of Coordinate System 


        public void AddCorner(int Axis, double Thickness, double L, double LOffset, double WOffset, double HOffset)
        {
            //          double LOffset;   // X-Axis, more positive means moving right
            //          double WOffsetL;   // Z-Axis, more positive means moving forward
            //          double HOffsetL;   // Y-Axis, more positive means moving up

            var mesh = new MeshGeometry3D();

            double Length = Thickness;
            double Height = Thickness;
            double Width = Thickness;

            switch (Axis)
            {
                case 1:
                    mesh.TextureCoordinates = new PointCollection(new Point[] { new Point(0.5, 0), new Point(0.5, 1), new Point(0.5, 0), new Point(0.5, 1), new Point(0.5, 0), new Point(0.5, 1), new Point(0.5, 0), new Point(0.5, 1) });
                    Length = 2 * L;
                    break;
                case 2:
                    mesh.TextureCoordinates = new PointCollection(new Point[] { new Point(0, 0.5), new Point(1.0, 0.5), new Point(0, 0.5), new Point(1.0, 0.5) });
                    Width = 2 * L;
                    break;
                case 3:
                    mesh.TextureCoordinates = new PointCollection(new Point[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1), new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) });
                    Height = 2 * L;
                    break;
            }

            Point3D p0 = new Point3D(LOffset, HOffset, WOffset);
            Point3D p1 = new Point3D(LOffset + Length, HOffset, WOffset);
            Point3D p2 = new Point3D(LOffset, HOffset + Height, WOffset);
            Point3D p3 = new Point3D(LOffset + Length, HOffset + Height, WOffset);
            Point3D p4 = new Point3D(LOffset, HOffset, Width + WOffset);
            Point3D p5 = new Point3D(LOffset + Length, HOffset, Width + WOffset);
            Point3D p6 = new Point3D(LOffset, HOffset + Height, Width + WOffset);
            Point3D p7 = new Point3D(LOffset + Length, HOffset + Height, Width + WOffset);

            mesh.Positions = new Point3DCollection { p0, p1, p2, p3, p4, p5, p6, p7 };
            mesh.TriangleIndices = new Int32Collection(new int[] { 2, 7, 3, 2, 6, 7, 0, 1, 5, 0, 5, 4, 2, 3, 1, 2, 1, 0, 7, 1, 3, 7, 5, 1, 6, 5, 7, 6, 4, 5, 6, 2, 0, 6, 4, 0 });
            DiffuseMaterial surface_material = null;
            if (Axis == 4) surface_material = new DiffuseMaterial(Brushes.Gray);
            else surface_material = new DiffuseMaterial(GetMyBrush(Axis + 0));

            GeometryModel3D surface_model = new GeometryModel3D(mesh, surface_material);
            surface_model.BackMaterial = surface_material;
            surface_model.Material = surface_material;
            MainModel3Dgroup.Children.Add(surface_model);
        }



        private LinearGradientBrush GetMyBrush(int ColorChoice)
        {
            LinearGradientBrush LGB = new LinearGradientBrush();
            LGB.StartPoint = new Point(0.5, 0);
            LGB.EndPoint = new Point(0.5, 1);
            GradientStop startGS = new GradientStop();
            startGS.Color = Colors.LightGray;
            startGS.Offset = 0.0;
            LGB.GradientStops.Add(startGS);
            GradientStop stopGS = new GradientStop();
            //if (ColorChoice == 1) stopGS.Color = Colors.Blue;    // Blue -> Red
            //if (ColorChoice == 2) stopGS.Color = Colors.Red;   //  Red -> DarkGreen
            //if (ColorChoice == 3) stopGS.Color = Colors.DarkGreen;   // DarkGreen -> Blue
            if (ColorChoice == 1) stopGS.Color = Colors.Red;    // Blue -> Red
            if (ColorChoice == 2) stopGS.Color = Colors.DarkGreen;   //  Red -> DarkGreen
            if (ColorChoice == 3) stopGS.Color = Colors.Blue;   // DarkGreen -> Blue
            stopGS.Offset = 1.0;
            LGB.GradientStops.Add(stopGS);
            return LGB;
        }



        public void AddAxes(WpfGraphicsSettings wpfGraphicsSettings)
        {
            string StyleOfAxes = wpfGraphicsSettings.StyleOfAxes;
            double T = 0.01;  // Thickness of cube
            double L = 0.5;  // Longest part of cube, also determines distance from main mesh

            AddCorner(1, T, L, -L, -L - T, -L - T); // X-Axis Bottom Rear
            AddCorner(1, T, L, -L, -L - T, L);   // X-Axis Top Rear
            AddCorner(1, T, L, -L, L, -L - T);   // X-Axis Bottom Front
            if (StyleOfAxes.Contains("FullCage")) AddCorner(1, T, L, -L, L, L);   // X-Axis Top Front

            AddCorner(2, T, L, -L - T, -L, -L - T);   // Z-Axis Bottom Left
            if (StyleOfAxes.Contains("FullCage")) AddCorner(2, T, L, -L - T, -L, L);   // Z-Axis Top Left
            AddCorner(2, T, L, L, -L, -L - T);   // Z-Axis Bottom Right
            AddCorner(2, T, L, L, -L, L);   // Z-Axis Top Right

            AddCorner(3, T, L, -L - T, -L - T, -L);   // Y-Axis Left Rear
            if (StyleOfAxes.Contains("FullCage")) AddCorner(3, T, L, -L - T, L, -L);   // Y-Axis Left Front
            AddCorner(3, T, L, L, -L - T, -L);   // Y-Axis Right Rear
            AddCorner(3, T, L, L, L, -L);   // Y-Axis Right Front

            AddCorner(4, T, L, -L - T, -L - T, -L - T);   // Connector Left Bottom Rear
            AddCorner(4, T, L, -L - T, -L - T, L);   // Connector Left Top Rear
            AddCorner(4, T, L, -L - T, L, -L - T);   // Connector Left Bottom Front
            if (StyleOfAxes.Contains("FullCage")) AddCorner(4, T, L, -L - T, L, L);   // Connector Left Top Front

            AddCorner(4, T, L, L, -L - T, -L - T);   // Connector Right Bottom Rear
            AddCorner(4, T, L, L, -L - T, L);   // Connector Right Top Rear
            AddCorner(4, T, L, L, L, -L - T);   // Connector Right Bottom Front
            AddCorner(4, T, L, L, L, L);   // Connector Right Top Front

        }


        #endregion




        #region Camera and lights



        private void DefineLights()
        {
            AmbientLight ambient_light = new AmbientLight(Colors.Gray);
            DirectionalLight directional_light = new DirectionalLight(Colors.Gray, new Vector3D(-1.0, -3.0, -2.0));
            DirectionalLight directional_light2 = new DirectionalLight(Colors.Gray, new Vector3D(1.0, 3.0, 2.0));

            MainModel3Dgroup.Children.Add(ambient_light);
            MainModel3Dgroup.Children.Add(directional_light);
            MainModel3Dgroup.Children.Add(directional_light2);
        }


        public void SetCameraType(bool _UseOrthographicCamera)
        {
            UseOrthographicCamera = _UseOrthographicCamera;
            PositionCamera();
        }



        public void SetCameraPhi(double NewPhi)
        {
            CameraPhi = NewPhi;
            if (CameraPhi > Math.PI / 2.0) CameraPhi = Math.PI / 2.0;
            if (CameraPhi < -Math.PI / 2.0) CameraPhi = -Math.PI / 2.0;
            PositionCamera();
        }

        public void SetCameraTheta(double NewTheta)
        {
            CameraTheta = NewTheta * Math.PI / 180.0;
            PositionCamera();
        }


        public void SetCameraFactor(double factor)
        {
            CameraR = CameraRStart * factor;
            PositionCamera();
        }



        private void PositionCamera()
        {
            // Calculate the camera's position in Cartesian coordinates.
            double y = CameraR * Math.Sin(CameraPhi);
            double hyp = CameraR * Math.Cos(CameraPhi);
            double x = hyp * Math.Cos(CameraTheta);
            double z = hyp * Math.Sin(CameraTheta);

            if ((bool)UseOrthographicCamera)
            {
                myOCamera.Position = new Point3D(x, y, z);
                // Look toward the origin.
                myOCamera.LookDirection = new Vector3D(-x, -y, -z);
                // Set the Up direction.
                myOCamera.UpDirection = new Vector3D(0, 1, 0);
                MainViewport.Camera = myOCamera;
            }
            else
            {
                myPCamera.Position = new Point3D(x, y, z);
                // Look toward the origin.
                myPCamera.LookDirection = new Vector3D(-x, -y, -z);
                // Set the Up direction.
                myPCamera.UpDirection = new Vector3D(0, 1, 0);
                //	          myPCamera.UpDirection = new Vector3D(0, -1, 0);  //flip upside down 
                myPCamera.FieldOfView = 30.0;
                MainViewport.Camera = myPCamera;
            }
        }


        #endregion




        #region Export bitmap


        public void Save3DBitmap(String FileName, String Extension, Boolean WhiteBackground)
        {
            //  RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;

            double scale = 600 / 96;

            Rect bounds = VisualTreeHelper.GetDescendantBounds(MainViewport);
            if (bounds.IsEmpty) return;

            RenderTargetBitmap rtb = new RenderTargetBitmap((Int32)(scale * (bounds.Width)), (Int32)(scale * (bounds.Height)), scale * 96, scale * 96, PixelFormats.Pbgra32);

            //string boundsWidth = bounds.Width.ToString();
            //string boundsHeight = bounds.Height.ToString();
            //string boundsWidthScaled = (scale * bounds.Width).ToString();
            //string boundsHeightScaled = (scale * bounds.Height).ToString();

            //MessageBox.Show(boundsWidth + " " + boundsHeight + " " + boundsWidthScaled + " " + boundsHeightScaled);


            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                if (WhiteBackground)
                {
                    Size MySize = new Size();
                    MySize.Height = bounds.Height + 10;
                    MySize.Width = bounds.Width + 10;
                    dc.DrawRectangle(Brushes.White, null, new Rect(new Point(), MySize));
                }
                VisualBrush vb = new VisualBrush(MainViewport);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
            rtb.Render(dv);

            BitmapEncoder Encoder = null;
            if (Extension == "jpg") Encoder = new JpegBitmapEncoder();
            else Encoder = new PngBitmapEncoder();

            Encoder.Frames.Add(BitmapFrame.Create(rtb));
            using (Stream stm = File.Create(FileName))
            {
                Encoder.Save(stm);
            }
        }




        public void Save3DBitmapReduced(String FileName, String Extension, Boolean WhiteBackground)
        {
            Save3DBitmap2(FileName, Extension, WhiteBackground);



        }

        public void Save3DBitmap2(String FileName, String Extension, Boolean WhiteBackground)
        {
            //  RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;

            double scale = 600 / 96;

            Rect bounds = VisualTreeHelper.GetDescendantBounds(MainViewport);
            if (bounds.IsEmpty) return;

            RenderTargetBitmap rtb = new RenderTargetBitmap((Int32)(scale * (bounds.Width)), (Int32)(scale * (bounds.Height)), scale * 96, scale * 96, PixelFormats.Pbgra32);

            string boundsWidth = bounds.Width.ToString();
            string boundsHeight = bounds.Height.ToString();
            string boundsWidthScaled = (scale * bounds.Width).ToString();
            string boundsHeightScaled = (scale * bounds.Height).ToString();

            System.Windows.Forms.MessageBox.Show(boundsWidth + " " + boundsHeight + " " + boundsWidthScaled + " " + boundsHeightScaled);


            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                if (WhiteBackground)
                {
                    Size MySize = new Size();
                    MySize.Height = bounds.Height + 10;
                    MySize.Width = bounds.Width + 10;
                    dc.DrawRectangle(Brushes.White, null, new Rect(new Point(), MySize));
                }
                VisualBrush vb = new VisualBrush(MainViewport);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
            rtb.Render(dv);

            BitmapEncoder Encoder = null;
            if (Extension == "jpg") Encoder = new JpegBitmapEncoder();
            else Encoder = new PngBitmapEncoder();

            Encoder.Frames.Add(BitmapFrame.Create(rtb));
            using (Stream stm = File.Create(FileName))
            {
                Encoder.Save(stm);
            }
        }


        public string GetBinPath()
        {
            string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(BinPath);
            return BinPath;
        }


        #endregion





    }
}
