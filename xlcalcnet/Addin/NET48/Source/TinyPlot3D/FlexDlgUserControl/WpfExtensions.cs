using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media.TextFormatting;
using System.Reflection.Emit;
using FixedPrecNet;
using System.Windows.Shapes;



//See also: https://github.com/WriterRod/WPF-3d-source

//See also: https://commons.wikimedia.org/wiki/File:Mercator-projection.jpg

//See also: https://docs.ambientcg.com/books/website-licensing/page/license-information




namespace TinyPlot3DCtrl
{


    #region Class Built-in


    public class BuiltIn
    {

        private static string SolidType = "";
        private static double a_;
        private static double b_;
        private static double c_;
        private static double height_;
        private static double cutheight_;
        private static double cutslope_;
        private static double cutslope1_;
        private static double cutslope2_;
        private static double xshift_;
        private static double yshift_;
        private static double alpha_;
        private static double beta_;
        private static double theta_;
        private static double starRadius_;
        private static double Radius_;
        private static double radius_;
        private static double factor1_;
        private static double factor2_;
        private static int numTheta_;
        private static int numPhi_;
        private static int numSides_;
        private static int numDiv_;



        public static double Add2(double x, double y)
        {
            return x + y;
        }

        public static int SetSphere(double radius, int numTheta, int numPhi)
        {
            SolidType = "Sphere";
            radius_ = radius;
            numTheta_ = numTheta;
            numPhi_ = numPhi;
            return 0;
        }

        public static int SetProlateSpheroid(double radius, double factor1, int numTheta, int numPhi)
        {
            SolidType = "ProlateSpheroid";
            radius_ = radius;
            factor1_ = factor1;
            numTheta_ = numTheta;
            numPhi_ = numPhi;
            return 0;
        }

        public static int SetOblateSpheroid(double radius, double factor2, int numTheta, int numPhi)
        {
            SolidType = "OblateSpheroid";
            radius_ = radius;
            factor2_ = factor2;
            numTheta_ = numTheta;
            numPhi_ = numPhi;
            return 0;
        }

        public static int SetEllipsoid(double radius, double factor1, double factor2, int numTheta, int numPhi)
        {
            SolidType = "Ellipsoid";
            radius_ = radius;
            factor1_ = factor1;
            factor2_ = factor2;
            numTheta_ = numTheta;
            numPhi_ = numPhi;
            return 0;
        }

        public static int SetTorus(double Radius, double radius, int numTheta, int numPhi)
        {
            SolidType = "Torus";
            Radius_ = Radius;
            radius_ = radius;
            numTheta_ = numTheta;
            numPhi_ = numPhi;
            return 0;
        }

        public static int SetCuboid(double a, double b, double c)
        {
            SolidType = "Cuboid";
            a_ = a;
            b_ = b;
            c_ = c;
            return 0;
        }

        public static int SetRhombohedron(double theta)
        {
            SolidType = "Rhombohedron";
            theta_ = theta;
            return 0;
        }

        public static int SetParallelepiped(double a, double b, double c, double alpha, double beta)
        {
            SolidType = "Parallelepiped";
            a_ = a;
            b_ = b;
            c_ = c;
            alpha_ = alpha;
            beta_ = beta;
            return 0;
        }

        public static int SetTriangularPrism(double a, double b, double height, double xshift, double yshift)
        {
            SolidType = "TriangularPrism";
            a_ = a;
            b_ = b;
            height_ = height;
            xshift_ = xshift;
            yshift_ = yshift;
            return 0;
        }

        public static int SetSquarePrism(double a, double b, double height, double xshift, double yshift)
        {
            SolidType = "SquarePrism";
            a_ = a;
            b_ = b;
            height_ = height;
            xshift_ = xshift;
            yshift_ = yshift;
            return 0;
        }

        public static int SetHexagonalPrism(double a, double b, double height, double xshift, double yshift)
        {
            SolidType = "HexagonalPrism";
            a_ = a;
            b_ = b;
            height_ = height;
            xshift_ = xshift;
            yshift_ = yshift;
            return 0;
        }

        public static int SetOctagonalPrism(double a, double b, double height, double xshift, double yshift)
        {
            SolidType = "OctagonalPrism";
            a_ = a;
            b_ = b;
            height_ = height;
            xshift_ = xshift;
            yshift_ = yshift;
            return 0;
        }

        public static int SetCylinder(int numSides, double a, double b, double height, double xshift, double yshift)
        {
            SolidType = "Cylinder";
            numSides_ = numSides;
            a_ = a;
            b_ = b;
            height_ = height;
            xshift_ = xshift;
            yshift_ = yshift;
            return 0;
        }

        public static int SetCylinder2CP(int numSides, double a, double b, double height, double cutslope1, double cutslope2)
        {
            SolidType = "Cylinder2CP";
            numSides_ = numSides;
            a_ = a;
            b_ = b;
            height_ = height;
            cutslope1_ = cutslope1;
            cutslope2_ = cutslope2;
            return 0;
        }

        public static int SetPyramid(int numSides, double a, double b, double height)
        {
            SolidType = "Pyramid";
            numSides_ = numSides;
            a_ = a;
            b_ = b;
            height_ = height;
            return 0;
        }

        public static int SetFrustum(int numSides, double a, double b, double height, double cutheight, double cutslope)
        {
            SolidType = "Frustum";
            numSides_ = numSides;
            a_ = a;
            b_ = b;
            height_ = height;
            cutheight_ = cutheight;
            cutslope_ = cutslope;
            return 0;
        }

        public static int SetCone(int numSides, double a, double b, double height)
        {
            SolidType = "Cone";
            numSides_ = numSides;
            a_ = a;
            b_ = b;
            height_ = height;
            return 0;
        }

        public static int SetConeFrustum(int numSides, double a, double b, double height, double cutheight, double cutslope)
        {
            SolidType = "ConeFrustum";
            numSides_ = numSides;
            a_ = a;
            b_ = b;
            height_ = height;
            cutheight_ = cutheight;
            cutslope_ = cutslope;
            return 0;
        }


        public static int SetTetrahedron()
        {
            SolidType = "Tetrahedron";
            return 0;
        }


        public static int SetCube()
        {
            SolidType = "Cube";
            return 0;
        }


        public static int SetOctahedron()
        {
            SolidType = "Octahedron";
            return 0;
        }


        public static int SetDodecahedron()
        {
            SolidType = "Dodecahedron";
            return 0;
        }


        public static int SetIcosahedron()
        {
            SolidType = "Icosahedron";
            return 0;
        }

        public static int SetGeodesicSphere(double radius, int numDiv)
        {
            SolidType = "GeodesicSphere";
            radius_ = radius;
            numDiv_ = numDiv;
            return 0;
        }

        public static int SetAugmentedOctahedron(double starRadius)
        {
            SolidType = "AugmentedOctahedron";
            starRadius_ = starRadius;
            return 0;
        }

        public static int SetAugmentedDodecahedron(double starRadius)
        {
            SolidType = "AugmentedDodecahedron";
            starRadius_ = starRadius;
            return 0;
        }

        public static int SetAugmentedIcosahedron(double starRadius)
        {
            SolidType = "AugmentedIcosahedron";
            starRadius_ = starRadius;
            return 0;
        }

        public static int SetAugmentedGeodesic(double starRadius, int numDiv)
        {
            SolidType = "AugmentedGeodesic";
            starRadius_ = starRadius;
            numDiv_ = numDiv;
            return 0;
        }



        public static void AddBuiltinSolid(MeshGeometry3D mesh,
        Point3D center, bool smooth = false,
        HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            switch (SolidType)
            {
                case "Sphere":
                    AddSphere(mesh, center, radius_, numTheta_, numPhi_, smooth, edges, thickness, texture);
                    break;

                case "ProlateSpheroid":
                    AddProlateSpheroid(mesh, center, radius_, factor1_, numTheta_, numPhi_, smooth, edges, thickness, texture);
                    break;

                case "OblateSpheroid":
                    AddOblateSpheroid(mesh, center, radius_, factor2_, numTheta_, numPhi_, smooth, edges, thickness, texture);
                    break;

                case "Ellipsoid":
                    AddEllipsoid(mesh, center, radius_, factor1_, factor2_, numTheta_, numPhi_, smooth, edges, thickness, texture);
                    break;

                case "Torus":
                    AddTorus(mesh, center, Radius_, radius_, numTheta_, numPhi_, smooth, edges, thickness, texture);
                    break;

                case "Cuboid":
                    AddCuboid(mesh, center + new Vector3D(-a_, -b_, -c_), D3.XVector(a_), D3.YVector(b_), D3.ZVector(c_), edges, thickness, texture);
                    break;

                case "Rhombohedron":
                    AddRhombohedron(mesh, center, theta_, edges, thickness, texture);
                    break;

                case "Parallelepiped":
                    AddParallelepiped(mesh, center + new Vector3D(-a_ / 2, -b_ / 2, -c_ / 2), new Vector3D(a_, 0.5, 0.5), D3.YVector(b_), D3.ZVector(c_), edges, thickness, texture);
                    break;

                case "TriangularPrism":
                    AddGenCylinder(mesh, center, a_, b_, height_, xshift_, yshift_, 3, smooth, edges, thickness);
                    break;

                case "SquarePrism":
                    AddGenCylinder(mesh, center, a_, b_, height_, xshift_, yshift_, 4, smooth, edges, thickness);
                    break;

                case "HexagonalPrism":
                    AddGenCylinder(mesh, center, a_, b_, height_, xshift_, yshift_, 6, smooth, edges, thickness);
                    break;

                case "OctagonalPrism":
                    AddGenCylinder(mesh, center, a_, b_, height_, xshift_, yshift_, 8, smooth, edges, thickness);
                    break;

                case "Cylinder":
                    AddGenCylinder(mesh, center, a_, b_, height_, xshift_, yshift_, numSides_, smooth, edges, thickness);
                    break;

                case "Cylinder2CP":
                    AddCylinder2CP(mesh, center, a_, b_, height_, cutslope1_, cutslope2_, numSides_, smooth, edges, thickness);
                    break;

                case "Pyramid":
                    AddGenPyramid(mesh, center, a_, b_, height_, numSides_, smooth, edges, thickness);
                    break;

                case "Frustum":
                    AddGenFrustum(mesh, center, a_, b_, height_, cutheight_, cutslope_, numSides_, smooth, edges, thickness);
                    break;

                case "Cone":
                    AddGenPyramid(mesh, center, a_, b_, height_, numSides_, true, edges, thickness);
                    break;

                case "ConeFrustum":
                    AddGenFrustum(mesh, center, a_, b_, height_, cutheight_, cutslope_, numSides_, true, edges, thickness);
                    break;

                case "Tetrahedron":
                    AddGenTetrahedron(mesh,  edges, thickness);
                    break;

                case "Cube":
                    AddGenCube(mesh, edges, thickness);
                    break;

                case "Octahedron":
                    AddGenOctahedron(mesh, edges, thickness);
                    break;

                case "Dodecahedron":
                    AddGenDodecahedron(mesh, edges, thickness);
                    break;

                case "Icosahedron":
                    AddGenIcosahedron(mesh, edges, thickness);
                    break;

                case "GeodesicSphere":
                    AddGenGeodesicSphere(mesh, center, radius_, numDiv_, edges, thickness);
                    break;

                case "AugmentedOctahedron":
                    AddAugmentedOctahedron(mesh, starRadius_, edges, thickness);
                    break;

                case "AugmentedDodecahedron":
                    AddAugmentedDodecahedron(mesh, starRadius_, edges, thickness);
                    break;

                case "AugmentedIcosahedron":
                    AddAugmentedIcosahedron(mesh, starRadius_, edges, thickness);
                    break;

                case "AugmentedGeodesic":
                    AddAugmentedGeodesic(mesh, starRadius_, numDiv_, edges, thickness);
                    break;


                default:
                    break;
            }
        }

        public static void AddSphere(MeshGeometry3D mesh,
        Point3D center, double radius, int numTheta, int numPhi, bool smooth = false,
        HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            {
                if (texture == "")
                {
                    mesh.AddSphere(center, radius, numTheta, numPhi, smooth,
                        edges, thickness);
                }
                else
                {
                    //double scale = 0.14;
                    mesh.AddTexturedSphere(center, radius, numTheta, numPhi, smooth);
                    mesh.Positions.Add(new Point3D());
                    mesh.TextureCoordinates.Add(new Point(1.01, 1.01));
                    //mesh.ApplyTransformation(new ScaleTransform3D(scale, scale, scale));
                    mesh.ApplyTransformation(new ScaleTransform3D(1, 1, 1));
                }
            }
        }



        public static void AddProlateSpheroid(MeshGeometry3D mesh,
            Point3D center, double radius, double factor1, int numTheta, int numPhi, bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            {
                if (texture == "")
                {
                    mesh.AddSphere(center, radius, numTheta, numPhi, smooth,
                        edges, thickness);
                    mesh.ApplyTransformation(new ScaleTransform3D(1, factor1, 1));
                }
                else
                {
                    //double scale = 0.14;
                    mesh.AddTexturedSphere(center, radius, numTheta, numPhi, smooth);
                    mesh.Positions.Add(new Point3D());
                    mesh.TextureCoordinates.Add(new Point(1.01, 1.01));
                    //mesh.ApplyTransformation(new ScaleTransform3D(scale, scale, scale));
                    mesh.ApplyTransformation(new ScaleTransform3D(1, factor1, 1));
                }
            }
        }

        public static void AddOblateSpheroid(MeshGeometry3D mesh,
            Point3D center, double radius, double factor2, int numTheta, int numPhi, bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            {
                if (texture == "")
                {
                    mesh.AddSphere(center, radius, numTheta, numPhi, smooth,
                        edges, thickness);
                    mesh.ApplyTransformation(new ScaleTransform3D(1, 1, factor2));
                }
                else
                {
                    //double scale = 0.14;
                    mesh.AddTexturedSphere(center, radius, numTheta, numPhi, smooth);
                    mesh.Positions.Add(new Point3D());
                    mesh.TextureCoordinates.Add(new Point(1.01, 1.01));
                    //mesh.ApplyTransformation(new ScaleTransform3D(scale, scale, scale));
                    mesh.ApplyTransformation(new ScaleTransform3D(1, 1, factor2));
                }
            }
        }


        public static void AddEllipsoid(MeshGeometry3D mesh,
            Point3D center, double radius, double factor1, double factor2, int numTheta, int numPhi, bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            {
                if (texture == "")
                {
                    mesh.AddSphere(center, radius, numTheta, numPhi, smooth,
                        edges, thickness);
                    mesh.ApplyTransformation(new ScaleTransform3D(1, factor1, factor2));
                }
                else
                {
                    //double scale = 0.14;
                    mesh.AddTexturedSphere(center, radius, numTheta, numPhi, smooth);
                    mesh.Positions.Add(new Point3D());
                    mesh.TextureCoordinates.Add(new Point(1.01, 1.01));
                    //mesh.ApplyTransformation(new ScaleTransform3D(scale, scale, scale));
                    mesh.ApplyTransformation(new ScaleTransform3D(1, factor1, factor2));
                }
            }
        }


        public static void AddTorus(MeshGeometry3D mesh,
            Point3D center, double R, double r, int numTheta, int numPhi, bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            {
                if (texture == "")
                {
                    mesh.AddTorus(center, R, r, numTheta, numPhi, smooth,
                        edges, thickness);
                }
                else
                {
                    mesh.AddTexturedTorus(center, R, r, numTheta, numPhi, smooth);
                    mesh.Positions.Add(new Point3D());
                    mesh.TextureCoordinates.Add(new Point(1.01, 1.01));
                }
            }
        }


        public static void AddCuboid(MeshGeometry3D mesh,
            Point3D corner, Vector3D vx, Vector3D vy, Vector3D vz,
            HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            if (texture == "")
            {
                mesh.AddBox(corner, vx, vy, vz,
                    null, null, null,
                    null, null, null,
                    edges, thickness);
            }
            else
            {
                mesh.AddBoxWrapped(corner, vx, vy, vz,
                edges, thickness);
            }
        }


        public static void AddRhombohedron(MeshGeometry3D mesh, Point3D corner, double theta1,
            HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            double theta = theta1 * Math.PI / 180;
            double c = Math.Cos(theta);
            double d = 1 - 3 * c * c + 2 * c * c * c;
            double e = math53.sign(d) * Math.Sqrt(Math.Abs(d));
            double s = Math.Sin(theta);
            AddParallelepiped(mesh, corner, new Vector3D(1, 0, 0), new Vector3D(c, s, 0), new Vector3D(c, (c - c * c) / s, e / s), edges: edges, thickness: thickness, texture: texture);
        }


        public static void AddParallelepiped(MeshGeometry3D mesh,
            Point3D corner, Vector3D vx, Vector3D vy, Vector3D vz,
            HashSet<Edge> edges = null, double thickness = 0.1, string texture = "")
        {
            if (texture == "")
            {
                mesh.AddBox(corner, vx, vy, vz,
                    null, null, null,
                    null, null, null,
                    edges, thickness);
            }
            else
            {
                mesh.AddBoxWrapped(corner, vx, vy, vz,
                edges, thickness);
            }
        }


        public static void AddGenCylinder(MeshGeometry3D mesh, Point3D corner,
            double a, double b, double height, double xshift, double yshift, int numSides,
            bool smoothSides = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            Point3D[] polygon2 = G3.MakePolygonPoints(numSides, corner, D3.XVector(Math.Abs(a)), D3.ZVector(-Math.Abs(b)));
            mesh.AddCylinder(polygon2, new Vector3D(xshift, height, yshift), smoothSides: smoothSides, edges: edges, thickness: thickness);
        }


        public static void AddCylinder2CP(MeshGeometry3D mesh, Point3D corner,
            double a, double b, double height, double cutslope1, double cutslope2, int numSides,
            bool smoothSides = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            Point3D[] polygon2 = G3.MakePolygonPoints(numSides, corner, D3.XVector(Math.Abs(a)), D3.ZVector(-Math.Abs(b)));
            mesh.AddCylinder(polygon2, new Vector3D(0, height, 0),
                corner + new Vector3D(0, height, 0), new Vector3D(0, 1, cutslope1),
                corner + new Vector3D(0, -height, 0), new Vector3D(0, -1, -cutslope2),
                smoothSides: smoothSides, edges: edges, thickness: thickness);
        }


        public static void AddGenPyramid(MeshGeometry3D mesh, Point3D corner,
            double a, double b, double height, int numSides,
            bool smoothSides = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            Point3D[] polygon2 = G3.MakePolygonPoints(numSides, corner, D3.XVector(Math.Abs(a)), D3.ZVector(-Math.Abs(b)));
            mesh.AddPyramid(corner, polygon2, D3.YVector(height),
                smoothSides: smoothSides, edges: edges, thickness: thickness);
        }


        public static void AddGenFrustum(MeshGeometry3D mesh, Point3D corner,
            double a, double b, double height, double cutheight, double cutslope, int numSides,
            bool smoothSides = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            Point3D[] polygon2 = G3.MakePolygonPoints(numSides, corner, D3.XVector(Math.Abs(a)), D3.ZVector(-Math.Abs(b)));

            mesh.AddFrustum(corner, polygon2, D3.YVector(height),
                 corner + new Vector3D(0, cutheight, 0), new Vector3D(0, 1, cutslope),
                smoothSides: smoothSides, edges: edges, thickness: thickness);
        }


        public static void AddGenTetrahedron(MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddTetrahedron(edges: edges, thickness: thickness);
        }


        public static void AddGenCube(MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddCube(edges: edges, thickness: thickness);
        }


        public static void AddGenOctahedron(MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddOctahedron(edges: edges, thickness: thickness);
        }


        public static void AddGenDodecahedron(MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddDodecahedron(edges: edges, thickness: thickness);
        }


        public static void AddGenIcosahedron(MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddIcosahedron(edges: edges, thickness: thickness);
        }


        public static void AddGenGeodesicSphere(MeshGeometry3D mesh, Point3D corner,
            double radius, int numDiv,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddGeodesicSphere(corner, radius, numDiv, edges: edges, thickness: thickness);
        }


        public static void AddAugmentedOctahedron(MeshGeometry3D mesh, double starRadius,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddStellateOctahedron(starRadius, edges: edges, thickness: thickness);
        }


        public static void AddAugmentedDodecahedron(MeshGeometry3D mesh, double starRadius,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddStellateDodecahedron(starRadius, edges: edges, thickness: thickness);
        }


        public static void AddAugmentedIcosahedron(MeshGeometry3D mesh, double starRadius,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddStellateGeodesicSphere(new Point3D(0, 0, 0), radius: 1, numDivisions: 1, starRadius: starRadius, edges: edges, thickness: thickness);
        }


        public static void AddAugmentedGeodesic(MeshGeometry3D mesh, double starRadius, int numDiv,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddStellateGeodesicSphere(new Point3D(0, 0, 0), radius: 1, numDivisions: numDiv, starRadius: starRadius, edges: edges, thickness: thickness);
        }



    }


    #endregion



    #region Class D3


    public static class D3
    {
        // Make a transformation for rotation around an arbitrary axis.
        public static RotateTransform3D Rotate(Vector3D axis, Point3D center, double angle)
        {
            Rotation3D rotation = new AxisAngleRotation3D(axis, angle);
            return new RotateTransform3D(rotation, center);
        }

        // Return the origin.
        public static Point3D Origin
        {
            get { return new Point3D(); }
        }

        // Return vectors along the coordinate axes.
        public static Vector3D XVector(double length = 1)
        {
            return new Vector3D(length, 0, 0);
        }
        public static Vector3D YVector(double length = 1)
        {
            return new Vector3D(0, length, 0);
        }
        public static Vector3D ZVector(double length = 1)
        {
            return new Vector3D(0, 0, length);
        }

        // Make texture coordinates for a polygon.
        // The first point is at the top.
        public static Point[] MakePolygonTextureCoords(int numSides)
        {
            double dtheta = 2 * Math.PI / numSides;
            double theta = Math.PI / 2;
            Point[] coords = new Point[numSides];
            for (int i = 0; i < numSides; i++)
            {
                coords[i] = new Point(
                    0.5 + Math.Cos(theta) / 2,
                    0.5 - Math.Sin(theta) / 2);
                theta += dtheta;
            }
            return coords;
        }

        // Return an array containing unit texture coordinates.
        // Points are ordered: LL, LR, UR, UL.
        public static Point[] UnitTextures
        {
            get
            {
                return new Point[]
                {
                    new Point(0, 1),
                    new Point(1, 1),
                    new Point(1, 0),
                    new Point(0, 0),
                };
            }
        }

        // Divide the unit texture coordinates into even sections.
        public static Point[][] SectionTextureCoords(int numRows, int numCols)
        {
            int numTotal = numRows * numCols;
            Point[][] result = new Point[numTotal][];

            double dr = 1.0 / numRows;
            double dc = 1.0 / numCols;
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    int i = r * numCols + c;
                    result[i] = new Point[4];
                    result[i][0] = new Point(c * dc, (r + 1) * dr);
                    result[i][1] = new Point((c + 1) * dc, (r + 1) * dr);
                    result[i][2] = new Point((c + 1) * dc, r * dr);
                    result[i][3] = new Point(c * dc, r * dr);
                }
            }
            return result;
        }

        // Make a MaterialGroup from a list of materials.
        public static MaterialGroup MakeMaterialGroup(params Material[] materials)
        {
            MaterialGroup group = new MaterialGroup();
            foreach (Material material in materials)
                group.Children.Add(material);
            return group;
        }
    }


    #endregion Class D3



    #region Class Edge

    // An object to prevent duplicate wireframe edges.
    public class Edge : IEquatable<Edge>, IComparable<Edge>
    {
        public Point3D Point1, Point2;
        public Edge(Point3D point1, Point3D point2)
        {
            // Put them in order so Point1 <= Point2.
            bool p1smaller =
                (point1.X < point2.X) ||
                ((point1.X == point2.X) && (point1.Y < point2.Y)) ||
                ((point1.X == point2.X) && (point1.Y == point2.Y) && (point1.Z < point2.Z));
            if (p1smaller)
            {
                Point1 = point1;
                Point2 = point2;
            }
            else
            {
                Point1 = point2;
                Point2 = point1;
            }
        }

        public bool Equals(Edge other)
        {
            if (ReferenceEquals(other, null)) return false;
            if ((Point1 == other.Point1) && (Point2 == other.Point2)) return true;
            return false;
        }
        public static bool operator ==(Edge edge1, Edge edge2)
        {
            if (ReferenceEquals(edge1, edge2)) return true;
            if ((edge1 == null)) return false;
            return edge1.Equals(edge2);
        }
        public static bool operator !=(Edge edge1, Edge edge2)
        {
            return !(edge1 == edge2);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Edge)) return false;
            return Equals(obj as Edge);
        }

        public override int GetHashCode()
        {
            return Point1.GetHashCode() ^ Point2.GetHashCode();
        }

        public override string ToString()
        {
            return Point1.ToString() + " --> " + Point2.ToString();
        }

        // Return:
        //      -1 if Point1 < Point2
        //       0 if Point1 == Point2
        //       1 if Point1 > Point2
        public int CompareTo(Edge other)
        {
            if (Point1.X < Point2.X) return -1;
            if (Point1.X > Point2.X) return 1;
            if (Point1.Y < Point2.Y) return -1;
            if (Point1.Y > Point2.Y) return 1;
            if (Point1.Z < Point2.Z) return -1;
            if (Point1.Z > Point2.Z) return 1;
            return 0;
        }
    }

    #endregion Class Edge



    #region Class G3

    public static class G3
    {
        #region Polygons


        // Make points to define a regular polygon.
        public static Point3D[] MakePolygonPoints(int numSides,
            Point3D center, Vector3D vx, Vector3D vy)
        {
            // Generate the points.
            Point3D[] points = new Point3D[numSides];
            double dtheta = 2 * Math.PI / numSides;
            double theta = Math.PI / 2;
            for (int i = 0; i < numSides; i++)
            {
                points[i] = center + vx * Math.Cos(theta) + vy * Math.Sin(theta);
                theta += dtheta;
            }
            return points;
        }

        #endregion Polygons

        #region Spheres

        // Return a point on a sphere.
        public static Point3D SpherePoint(Point3D center, double r, double theta, double phi)
        {
            double y = r * Math.Cos(phi);
            double h = r * Math.Sin(phi);
            double x = h * Math.Sin(theta);
            double z = h * Math.Cos(theta);
            return center + new Vector3D(x, y, z);
        }

        #endregion Spheres

        #region Tori

        // Return a point on a torus.
        public static Point3D TorusPoint(Point3D center, double R, double r, double theta, double phi)
        {
            return new Point3D(
                center.X + (R + r * Math.Cos(theta)) * Math.Cos(phi),
                center.Y + r * Math.Sin(theta),
                center.Z + (R + r * Math.Cos(theta)) * Math.Sin(phi));
        }

        // Return a normal on a torus.
        public static Vector3D TorusNormal(Point3D center, double R, double r, double theta, double phi)
        {
            return (Vector3D)TorusPoint(center, 0, r, theta, phi);
        }

        #endregion Tori

        #region Platonic Solids

        // Verify that the points are the same distance from the origin.
        public static void VerifyPoints(params Point3D[] points)
        {
            double d0 = (points[0] - D3.Origin).Length;
            for (int i = 1; i < points.Length; i++)
            {
                double d1 = (points[i] - D3.Origin).Length;
                if (Math.Abs(d1 - d0) > 0.001)
                    throw new Exception("VerifyPoints: Distance " +
                        d1 + " not close enough to " + d0);
            }
        }

        // Verify that the points in a polygon are the same distance apart.
        public static void VerifyPolygon(params Point3D[] points)
        {
            double d0 = (points[points.Length - 1] - points[0]).Length;
            for (int i = 1; i < points.Length; i++)
            {
                double d1 = (points[i] - points[i - 1]).Length;
                if (Math.Abs(d1 - d0) > 0.001)
                    throw new Exception("VerifyPolygon: Distance " +
                        d1 + " not close enough to " + d0);
            }
        }

        // Tetrahedron.
        public static void TetrahedronPoints(
            out Point3D A, out Point3D B, out Point3D C, out Point3D D,
            bool centered)
        {
            double dy = 0;
            if (centered) dy = 0.25 * Math.Sqrt(2.0 / 3.0);

            A = new Point3D(0, Math.Sqrt(2.0 / 3.0) - dy, 0);
            B = new Point3D(1.0 / Math.Sqrt(3.0), -dy, 0);
            C = new Point3D(-1.0 / (2 * Math.Sqrt(3.0)), -dy, -1.0 / 2.0);
            D = new Point3D(-1.0 / (2 * Math.Sqrt(3.0)), -dy, 1.0 / 2.0);
        }
        public static double TetrahedronCircumradius()
        {
            return Math.Sqrt(2.0 / 3.0) * 0.75;
        }
        public static double TetrahedronInradius()
        {
            return Math.Sqrt(2.0 / 3.0) * 0.25;
        }

        // Cube.
        public static void CubePoints(
            out Point3D A, out Point3D B, out Point3D C, out Point3D D,
            out Point3D E, out Point3D F, out Point3D G, out Point3D H)
        {
            A = new Point3D(-1, +1, +1);
            B = new Point3D(+1, +1, +1);
            C = new Point3D(+1, +1, -1);
            D = new Point3D(-1, +1, -1);
            E = new Point3D(-1, -1, +1);
            F = new Point3D(+1, -1, +1);
            G = new Point3D(+1, -1, -1);
            H = new Point3D(-1, -1, -1);
        }
        public static double CubeCircumradius()
        {
            return Math.Sqrt(3.0);
        }
        public static double CubeInradius()
        {
            return 1;
        }

        // Octahedron.
        public static void OctahedronPoints(out Point3D A, out Point3D B,
            out Point3D C, out Point3D D, out Point3D E, out Point3D F)
        {
            A = new Point3D(0, 1, 0);
            B = new Point3D(1, 0, 0);
            C = new Point3D(0, 0, -1);
            D = new Point3D(-1, 0, 0);
            E = new Point3D(0, 0, 1);
            F = new Point3D(0, -1, 0);
        }
        public static double OctahedronCircumradius()
        {
            return 1;
        }
        public static double OctahedronInradius()
        {
            return Math.Sqrt(1.0 / 3.0);
        }

        // Dodecahedron.
        // Dodecahedron intermediate values.
        private static double ds = 2;
        //private static double dt1 = 2 * Math.PI / 5;    // Not actually used.
        private static double dt2 = Math.PI / 10;
        private static double dt3 = 3 * Math.PI / 10;
        private static double dt4 = Math.PI / 5;
        private static double dd1 = ds / 2 / Math.Sin(dt4);
        private static double dd2 = dd1 * Math.Cos(dt4);
        private static double dd3 = dd1 * Math.Cos(dt2);
        private static double dd4 = dd1 * Math.Sin(dt2);
        private static double dFx =
            (ds * ds - (2 * dd3) * (2 * dd3) -
                (dd1 * dd1 - dd3 * dd3 - dd4 * dd4)) /
            (2 * (dd4 - dd1));
        private static double dd5 = Math.Sqrt(
            0.5 * (ds * ds + (2 * dd3) * (2 * dd3) -
                (dd1 - dFx) * (dd1 - dFx) -
                (dd4 - dFx) * (dd4 - dFx) - dd3 * dd3));
        private static double dFy = (dFx * dFx - dd1 * dd1 -
            dd5 * dd5) / (2 * dd5);
        private static double dAy = dd5 + dFy;

        // Calculate the dodecahedron vertices.
        public static void DodecahedronPoints(
            out Point3D A, out Point3D B, out Point3D C, out Point3D D,
            out Point3D E, out Point3D F, out Point3D G, out Point3D H,
            out Point3D I, out Point3D J, out Point3D K, out Point3D L,
            out Point3D M, out Point3D N, out Point3D O, out Point3D P,
            out Point3D Q, out Point3D R, out Point3D S, out Point3D T)
        {
            // Make the points.
            A = new Point3D(dd1, dAy, 0);
            B = new Point3D(dd4, dAy, dd3);
            C = new Point3D(-dd2, dAy, ds / 2);
            D = new Point3D(-dd2, dAy, -ds / 2);
            E = new Point3D(dd4, dAy, -dd3);
            F = new Point3D(dFx, dFy, 0);
            G = new Point3D(dFx * Math.Sin(dt2), dFy, dFx * Math.Cos(dt2));
            H = new Point3D(-dFx * Math.Sin(dt3), dFy, dFx * Math.Cos(dt3));
            I = new Point3D(-dFx * Math.Sin(dt3), dFy, -dFx * Math.Cos(dt3));
            J = new Point3D(dFx * Math.Sin(dt2), dFy, -dFx * Math.Cos(dt2));
            K = new Point3D(dFx * Math.Sin(dt3), -dFy, dFx * Math.Cos(dt3));
            L = new Point3D(-dFx * Math.Sin(dt2), -dFy, dFx * Math.Cos(dt2));
            M = new Point3D(-dFx, -dFy, 0);
            N = new Point3D(-dFx * Math.Sin(dt2), -dFy, -dFx * Math.Cos(dt2));
            O = new Point3D(dFx * Math.Sin(dt3), -dFy, -dFx * Math.Cos(dt3));
            P = new Point3D(dd2, -dAy, ds / 2);
            Q = new Point3D(-dd4, -dAy, dd3);
            R = new Point3D(-dd1, -dAy, 0);
            S = new Point3D(-dd4, -dAy, -dd3);
            T = new Point3D(dd2, -dAy, -ds / 2);
        }
        public static double DodecahedronCircumradius()
        {
            // Get intermediate values.
            return Math.Sqrt(dd1 * dd1 + dAy * dAy);
        }
        public static double DodecahedronInradius()
        {
            return dAy;
        }

        // Icosahedron.
        // Icosahedron intermediate values.
        private static double s = 2;
        //private static double t1 = 2 * Math.PI / 5;     // Not actually used.
        private static double t2 = Math.PI / 10;
        private static double t4 = Math.PI / 5;
        //private static double t3 = -3 * Math.PI / 10;   // Not actually used.
        private static double r = (s / 2) / Math.Sin(t4);
        private static double h = r * Math.Cos(t4);
        private static double h1 = Math.Sqrt(s * s - r * r);
        private static double h2 = Math.Sqrt((h + r) * (h + r) - h * h);
        private static double cx = r * Math.Sin(t2);
        private static double cz = r * Math.Cos(t2);
        private static double y2 = (h2 - h1) / 2;
        private static double y1 = y2 + h1;

        // Calculate the icosahedron vertices.
        public static void IcosahedronPoints(
            out Point3D A, out Point3D B, out Point3D C, out Point3D D,
            out Point3D E, out Point3D F, out Point3D G, out Point3D H,
            out Point3D I, out Point3D J, out Point3D K, out Point3D L)
        {
            // Make the points.

            A = new Point3D(0, y1, 0);
            B = new Point3D(r, y2, 0);
            C = new Point3D(cx, y2, cz);
            D = new Point3D(-h, y2, s / 2);
            E = new Point3D(-h, y2, -s / 2);
            F = new Point3D(cx, y2, -cz);
            G = new Point3D(-r, -y2, 0);
            H = new Point3D(-cx, -y2, -cz);
            I = new Point3D(h, -y2, -s / 2);
            J = new Point3D(h, -y2, s / 2);
            K = new Point3D(-cx, -y2, cz);
            L = new Point3D(0, -y1, 0);
        }
        public static double IcosahedronCircumradius()
        {
            // Get intermediate values.
            return y1;
        }
        public static double IcosahedronInradius()
        {
            return 1.0 / 3.0 * Math.Sqrt(
                (r + cx) * (r + cx) +
                (y1 + y2 + y2) * (y1 + y2 + y2) +
                (cz) * (cz));
        }

        #endregion Platonic Solids

        #region Planes

        // Find the intersection between three planes defined by three points on each.
        public static Point3D Intersect3Planes(
            Point3D p1a, Point3D p1b, Point3D p1c,
            Point3D p2a, Point3D p2b, Point3D p2c,
            Point3D p3a, Point3D p3b, Point3D p3c)
        {
            // Get the plane equations.
            double
                A1, B1, C1, D1,
                A2, B2, C2, D2,
                A3, B3, C3, D3;
            GetPlaneEquation(out A1, out B1, out C1, out D1, p1a, p1b, p1c);
            GetPlaneEquation(out A2, out B2, out C2, out D2, p2a, p2b, p2c);
            GetPlaneEquation(out A3, out B3, out C3, out D3, p3a, p3b, p3c);

            // Find the point of intersection.
            return Intersect3Planes(
                A1, B1, C1, D1,
                A2, B2, C2, D2,
                A3, B3, C3, D3);
        }

        // Find the equation of plane through the three points.
        private static void GetPlaneEquation(
            out double A, out double B, out double C, out double D,
            Point3D p1, Point3D p2, Point3D p3)
        {
            // Find two vectors in the plane.
            Vector3D v12 = p2 - p1;
            Vector3D v23 = p3 - p2;

            // Take the cross product to get a normal vector.
            Vector3D n = Vector3D.CrossProduct(v12, v23);
            n.Normalize();

            // Calculate the plane equation's coefficients.
            A = n.X;
            B = n.Y;
            C = n.Z;
            D = -(A * p1.X + B * p1.Y + C * p1.Z);
        }

        // Find the intersection between three planes defined by plane equations.
        private static Point3D Intersect3Planes(
            double A1, double B1, double C1, double D1,
            double A2, double B2, double C2, double D2,
            double A3, double B3, double C3, double D3)
        {
            return Gaussian(
                A1, B1, C1, -D1,
                A2, B2, C2, -D2,
                A3, B3, C3, -D3);
        }

        // Use Gaussian elimination to solve three equations with three unknowns.
        private static Point3D Gaussian(
            double A1, double B1, double C1, double D1,
            double A2, double B2, double C2, double D2,
            double A3, double B3, double C3, double D3)
        {
            // Build the array.
            double[,] arr =
            {
                {A1, B1, C1, D1, 0},
                {A2, B2, C2, D2, 0},
                {A3, B3, C3, D3, 0},
            };

            // Solve.
            const double tiny = 0.00001;
            const int numRows = 3;
            const int numCols = 3;
            for (int r = 0; r < numRows - 1; r++)
            {
                // Zero out all entries in column r after this row.
                // See if this row has a non-zero entry in column r.
                if (Math.Abs(arr[r, r]) < tiny)
                {
                    // Too close to zero. Try to swap with a later row.
                    for (int r2 = r + 1; r2 < numRows; r2++)
                    {
                        if (Math.Abs(arr[r2, r]) > tiny)
                        {
                            // This row will work. Swap them.
                            for (int c = 0; c <= numCols; c++)
                            {
                                double tmp = arr[r, c];
                                arr[r, c] = arr[r2, c];
                                arr[r2, c] = tmp;
                            }
                            break;
                        }
                    }
                }

                // If this row has a non-zero entry in column r, use it.
                if (Math.Abs(arr[r, r]) > tiny)
                {
                    // Zero out this column in later rows.
                    for (int r2 = r + 1; r2 < numRows; r2++)
                    {
                        double factor = -arr[r2, r] / arr[r, r];
                        for (int c = r; c <= numCols; c++)
                        {
                            arr[r2, c] = arr[r2, c] + factor * arr[r, c];
                        }
                    }
                }
            }

            // Backsolve.
            for (int r = numRows - 1; r >= 0; r--)
            {
                double tmp = arr[r, numCols];
                for (int r2 = r + 1; r2 < numRows; r2++)
                {
                    tmp -= arr[r, r2] * arr[r2, numCols + 1];
                }
                arr[r, numCols + 1] = tmp / arr[r, r];
            }

            // Return the result.
            return new Point3D(arr[0, numCols + 1], arr[1, numCols + 1], arr[2, numCols + 1]);
        }

        #endregion Planes


        #region Surfaces

        // Initialize points to define a flat surface with a given Y value.
        // Values numX and numZ give the number of points not the number of sections between points.
        public static Point3D[,] InitSurface(double y,
            int numX, double xmin, double xmax,
            int numZ, double zmin, double zmax)
        {
            double dx = (xmax - xmin) / (numX - 1);
            double dz = (zmax - zmin) / (numZ - 1);
            Point3D[,] surface = new Point3D[numX, numZ];
            for (int ix = 0; ix < numX; ix++)
            {
                double x = xmin + ix * dx;
                for (int iz = 0; iz < numX; iz++)
                {
                    double z = zmin + iz * dz;
                    surface[ix, iz] = new Point3D(x, y, z);
                }
            }
            return surface;
        }

        // Fractalize the surface by using midpoint displacement.
        public static Point3D[,] FractalizeSurface(Point3D[,] surface, int iterations,
            int seed, double minDy, double maxDy)
        {
            // Initialize the random number generator with the seed.
            Random rand;
            if (seed < 0) rand = new Random();
            else rand = new Random(seed);

            // Get the middle dy value.
            double midDy = (minDy + maxDy) / 2;
            double dySpread = maxDy - minDy;

            // Repeat for the desired number of iterations.
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                // Get the array's current and new size.
                int numX1 = surface.GetUpperBound(0) + 1;
                int numZ1 = surface.GetUpperBound(1) + 1;
                int numX2 = numX1 * 2 - 1;
                int numZ2 = numZ1 * 2 - 1;

                // Expand the array.
                Point3D[,] surface2 = new Point3D[numX2, numZ2];

                // Copy the old values into the new array.
                for (int ix = 0; ix < numX1; ix++)
                    for (int iz = 0; iz < numZ1; iz++)
                        surface2[ix * 2, iz * 2] = surface[ix, iz];

                // Position midpoints.
                for (int ix = 1; ix < numX2; ix += 2)
                {
                    for (int iz = 0; iz < numZ2; iz += 2)
                    {
                        double x = surface2[ix - 1, iz].X + surface2[ix + 1, iz].X;
                        double y = surface2[ix - 1, iz].Y + surface2[ix + 1, iz].Y +
                            rand.NextDouble(minDy, maxDy);
                        double z = surface2[ix - 1, iz].Z + surface2[ix + 1, iz].Z;
                        surface2[ix, iz] = new Point3D(x / 2, y / 2, z / 2);
                    }
                }
                for (int iz = 1; iz < numZ2; iz += 2)
                {
                    for (int ix = 0; ix < numX2; ix += 2)
                    {
                        double x = surface2[ix, iz - 1].X + surface2[ix, iz + 1].X;
                        double y = surface2[ix, iz - 1].Y + surface2[ix, iz + 1].Y +
                            rand.NextDouble(minDy, maxDy);
                        double z = surface2[ix, iz - 1].Z + surface2[ix, iz + 1].Z;
                        surface2[ix, iz] = new Point3D(x / 2, y / 2, z / 2);
                    }
                }

                // Position center points.
                for (int ix = 1; ix < numX2; ix += 2)
                {
                    for (int iz = 1; iz < numZ2; iz += 2)
                    {
                        double x =
                            surface2[ix, iz - 1].X + surface2[ix, iz + 1].X +
                            surface2[ix - 1, iz].X + surface2[ix + 1, iz].X;
                        double y =
                            surface2[ix, iz - 1].Y + surface2[ix, iz + 1].Y +
                            surface2[ix - 1, iz].Y + surface2[ix + 1, iz].Y +
                                rand.NextDouble(minDy, maxDy);
                        double z =
                            surface2[ix, iz - 1].Z + surface2[ix, iz + 1].Z +
                            surface2[ix - 1, iz].Z + surface2[ix + 1, iz].Z;
                        surface2[ix, iz] = new Point3D(x / 4, y / 4, z / 4);
                    }
                }

                // Replace surface with surface2.
                surface = surface2;

                // Reduce the spread of random values.
                dySpread /= 2;
                minDy = midDy - dySpread / 2;
                maxDy = midDy + dySpread / 2;
            } // End looping for iterations.

            // Return the latest surface.
            return surface;
        }

        // Ensure that the surface's Y coordinates are within the given bounds.
        public static void LimitY(Point3D[,] surface,
            double minY = double.MinValue, double maxY = double.MaxValue)
        {
            int numX = surface.GetUpperBound(0) + 1;
            int numZ = surface.GetUpperBound(1) + 1;
            for (int ix = 0; ix < numX; ix++)
            {
                for (int iz = 0; iz < numZ; iz++)
                {
                    double y = surface[ix, iz].Y;
                    if (y < minY) y = minY;
                    if (y > maxY) y = maxY;
                    surface[ix, iz].Y = y;
                }
            }
        }

        #endregion Surfaces



        #region Trefoil Knot

        // Make points to define a trefoil knot.
        public static Point3D[] MakeTrefoilPoints(int numPoints,
            Point3D center, Vector3D vx, Vector3D vy)
        {
            // Generate the points.
            Point3D[] points = new Point3D[numPoints];
            double dt = 2 * Math.PI / numPoints;
            double t = 0;
            for (int i = 0; i < numPoints; i++)
            {
                // Normal version.
                double x = Math.Sin(t) + 2 * Math.Sin(2 * t);
                double y = Math.Cos(t) - 2 * Math.Cos(2 * t);
                double z = -Math.Sin(3 * t);

                // Extra wiggly version.
                //double x = (2 + Math.Cos(3 * t)) * Math.Cos(2 * t);
                //double y = (2 + Math.Cos(3 * t)) * Math.Sin(2 * t);
                //double z = Math.Sin(3 * t);

                points[i] = center + new Vector3D(x, y, z);
                t += dt;
            }
            return points;
        }

        #endregion Trefoil Knot


    }

    #endregion Class G3



    #region Supporting classes 


    public static class Point3DExtensions
    {
        // Return a rounded Point3D so close points match.
        public static Point3D Round(this Point3D point, int decimals = 3)
        {
            double x = Math.Round(point.X, decimals);
            double y = Math.Round(point.Y, decimals);
            double z = Math.Round(point.Z, decimals);
            return new Point3D(x, y, z);
        }

        // Move this point along the vector to the center
        // so it has the given distance from the center.
        public static Point3D SetDistanceFrom(this Point3D point, Point3D center, double distance)
        {
            Vector3D v = point - center;
            return center + v / v.Length * distance;
        }
    }



    public static class RandomExtensions
    {
        // Return a double between min inclusive and max exclusive.
        public static double NextDouble(this Random rand, double min, double max)
        {
            return min + rand.NextDouble() * (max - min);
        }
    }



    // Hold three points that make up a triangle.
    public class Triangle
    {
        public List<Point3D> Points = null;

        // Copy the points into the Points list.
        public Triangle(params Point3D[] points)
        {
            Points = new List<Point3D>(points);
        }

        // Divide this triangle into triangles for use in geodesic spheres.
        public List<Triangle> DivideGeodesic(Point3D center, double radius, int numRows)
        {
            // Make vectors 1/numDivisions of the length along the triangle's edges.
            Vector3D vAB = (Points[1] - Points[0]) / numRows;
            Vector3D vBC = (Points[2] - Points[1]) / numRows;

            // Use vector arithmetic to create the points.
            List<Triangle> triangles = new List<Triangle>();
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    // Make the points we will need.
                    Point3D p0 = Points[0] + row * vAB + col * vBC;
                    Point3D p1 = p0 + vAB;
                    Point3D p2 = p1 + vBC;
                    Point3D p3 = p0 + vBC;

                    // Project the points onto the sphere.
                    p0 = p0.SetDistanceFrom(center, radius);
                    p1 = p1.SetDistanceFrom(center, radius);
                    p2 = p2.SetDistanceFrom(center, radius);
                    p3 = p3.SetDistanceFrom(center, radius);

                    // Make the lower triangle.
                    triangles.Add(new Triangle(p0, p1, p2));
                    if (col == row) break;

                    // Make the upper triangle.
                    triangles.Add(new Triangle(p0, p2, p3));
                }
            }
            return triangles;
        }

        // Return the triangle's angles, sorted.
        public List<double> Angles()
        {
            int numPoints = Points.Count;
            List<double> angles = new List<double>();
            for (int i = 0; i < numPoints; i++)
            {
                int i1 = (i + 1) % numPoints;
                int i2 = (i + 2) % numPoints;
                Vector3D v1 = Points[i1] - Points[i];
                Vector3D v2 = Points[i1] - Points[i2];
                angles.Add(Vector3D.AngleBetween(v1, v2));
            }

            angles.Sort();
            return angles;
        }
    }



    // Hold points that make up a polygon.
    public class Polygon
    {
        public List<Point3D> Points = null;

        // Copy the points into the Points list.
        public Polygon(params Point3D[] points)
        {
            Points = new List<Point3D>(points);
        }

        // Create triangles for stellation.
        public List<Triangle> MakeStellateTriangles(Point3D center, double radius)
        {
            // Find the polygon's center.
            Point3D pgonCenter = Center;

            // Find the unit vector from the stellar center to the polygon's center.
            Vector3D v = pgonCenter - center;

            // Find the pyramid's apex.
            Point3D apex = center + v / v.Length * radius;

            // Make a pyramid with this polygon as its base and the calculated apex.
            List<Triangle> triangles = new List<Triangle>();
            int numPoints = Points.Count;
            for (int i = 0; i < numPoints; i++)
            {
                int i1 = (i + 1) % numPoints;
                triangles.Add(new Triangle(Points[i], Points[i1], apex));
            }
            return triangles;
        }

        // Find the polygon's center by averaging its vertices.
        public Point3D Center
        {
            get
            {
                Point3D center = new Point3D();
                foreach (Point3D point in Points)
                {
                    center.X += point.X;
                    center.Y += point.Y;
                    center.Z += point.Z;
                }
                int numPoints = Points.Count;
                center.X /= numPoints;
                center.Y /= numPoints;
                center.Z /= numPoints;
                return center;
            }
        }
    }


    #endregion Supporting classes 




    #region Class MeshExtensions


    public static class MeshExtensions
    {
        #region Transformation

        // Apply a transformation Matrix3D or transformation class.
        public static void ApplyTransformation(this MeshGeometry3D mesh, Matrix3D transformation)
        {
            Point3D[] points = mesh.Positions.ToArray();
            transformation.Transform(points);
            mesh.Positions = new Point3DCollection(points);

            Vector3D[] normals = mesh.Normals.ToArray();
            transformation.Transform(normals);
            mesh.Normals = new Vector3DCollection(normals);
        }

        public static void ApplyTransformation(this MeshGeometry3D mesh, Transform3D transformation)
        {
            Point3D[] points = mesh.Positions.ToArray();
            transformation.Transform(points);
            mesh.Positions = new Point3DCollection(points);

            Vector3D[] normals = mesh.Normals.ToArray();
            transformation.Transform(normals);
            mesh.Normals = new Vector3DCollection(normals);
        }

        #endregion Transformation

        #region Merging

        // Merge a mesh into this one.
        // Do not copy texture coordinates or normals.
        public static void Merge(this MeshGeometry3D mesh, MeshGeometry3D other)
        {
            // Copy the positions. Save their new indices in an indices array.
            int index = mesh.Positions.Count;
            int[] indices = new int[other.Positions.Count];
            for (int i = 0; i < other.Positions.Count; i++)
            {
                mesh.Positions.Add(other.Positions[i]);
                indices[i] = index++;
            }

            // Copy the triangles.
            for (int t = 0; t < other.TriangleIndices.Count; t++)
            {
                int i = other.TriangleIndices[t];
                mesh.TriangleIndices.Add(indices[i]);
            }
        }

        #endregion Merging

        #region PointSharing

        // If the point is already in the dictionary, return its index in the mesh.
        // If the point isn't in the dictionary, create it in the mesh and add its
        // index to the dictionary.
        private static int PointIndex(this MeshGeometry3D mesh,
            Point3D point, Dictionary<Point3D, int> pointDict = null)
        {
            // See if the point already exists.
            if ((pointDict != null) && (pointDict.ContainsKey(point)))
            {
                // The point is already in the dictionary. Return its index.
                return pointDict[point];
            }

            // Create the point.
            int index = mesh.Positions.Count;
            mesh.Positions.Add(point);

            // Add the point's index to the dictionary.
            if (pointDict != null) pointDict.Add(point, index);

            // Return the index.
            return index;
        }

        // If the point is already in the dictionary, return its index in the mesh.
        // If the point isn't in the dictionary, create it and its texture coordinates
        // in the mesh and add its index to the dictionary.
        private static int PointIndex(this MeshGeometry3D mesh,
            Point3D point, Point textureCoord,
            Dictionary<Point3D, int> pointDict = null)
        {
            // See if the point already exists.
            if ((pointDict != null) && (pointDict.ContainsKey(point)))
            {
                // The point is already in the dictionary. Return its index.
                return pointDict[point];
            }

            // Create the point.
            int index = mesh.Positions.Count;
            mesh.Positions.Add(point);

            // Add the point's texture coordinates.
            mesh.TextureCoordinates.Add(textureCoord);

            // Add the point's index to the dictionary.
            if (pointDict != null) pointDict.Add(point, index);

            // Return the index.
            return index;
        }

        #endregion PointSharing

        #region Polygon

        // Add a simple polygon with no texture coordinates, smoothing, or wireframe.
        public static void AddPolygon(this MeshGeometry3D mesh,
            HashSet<Edge> edges, double thickness, params Point3D[] points)
        {
            mesh.AddPolygon(pointDict: null, points: points, edges: edges, thickness: thickness);
        }
        public static void AddPolygon(this MeshGeometry3D mesh, params Point3D[] points)
        {
            mesh.AddPolygon(pointDict: null, points: points);
        }

        // Add a polygon.
        public static void AddPolygon(this MeshGeometry3D mesh,
            Dictionary<Point3D, int> pointDict = null,
            HashSet<Edge> edges = null, double thickness = 0.1,
            Point[] textureCoords = null, params Point3D[] points)
        {
            if (edges != null)
            {
                // Make a wireframe polygon.
                mesh.AddPolygonEdges(edges, thickness, points);
            }
            else
            {
                // Make a wireframe polygon.
                mesh.AddPolygonTriangles(pointDict, textureCoords, points);
            }
        }

        // Make a polygon's triangles.
        public static void AddPolygonTriangles(this MeshGeometry3D mesh,
            Dictionary<Point3D, int> pointDict = null,
            Point[] textureCoords = null, params Point3D[] points)
        {
            // Make a point dictionary.
            if (pointDict == null) pointDict = new Dictionary<Point3D, int>();

            // Get the first two point indices.
            int indexA, indexB, indexC;

            Point3D roundedA = points[0].Round();
            if (textureCoords == null)
                indexA = mesh.PointIndex(roundedA, pointDict);
            else
                indexA = mesh.PointIndex(roundedA, textureCoords[0], pointDict);

            Point3D roundedC = points[1].Round();
            if (textureCoords == null)
                indexC = mesh.PointIndex(roundedC, pointDict);
            else
                indexC = mesh.PointIndex(roundedC, textureCoords[1], pointDict);

            // Make triangles.
            Point3D roundedB;
            for (int i = 2; i < points.Length; i++)
            {
                indexB = indexC;
                roundedB = roundedC;

                // Get the next point.
                roundedC = points[i].Round();
                if (textureCoords == null)
                    indexC = mesh.PointIndex(points[i].Round(), pointDict);
                else
                    indexC = mesh.PointIndex(points[i].Round(), textureCoords[i], pointDict);

                // If two of the points are the same, skip this triangle.
                if ((roundedA != roundedB) &&
                    (roundedB != roundedC) &&
                    (roundedC != roundedA))
                {
                    mesh.TriangleIndices.Add(indexA);
                    mesh.TriangleIndices.Add(indexB);
                    mesh.TriangleIndices.Add(indexC);
                }
            }
        }

        // Add a regular polygon with optional texture coordinates.
        public static void AddRegularPolygon(this MeshGeometry3D mesh,
            int numSides, Point3D center, Vector3D vx, Vector3D vy,
            Dictionary<Point3D, int> pointDict = null,
            HashSet<Edge> edges = null, double thickness = 0.1,
            Point[] textureCoords = null)
        {
            // Generate the points.
            Point3D[] points = G3.MakePolygonPoints(numSides, center, vx, vy);

            // Make the polygon.
            mesh.AddPolygon(pointDict, edges, thickness, textureCoords, points);
        }

        #endregion Polygon

        #region Models

        // Make a model with a diffuse brush.
        public static GeometryModel3D MakeModel(this MeshGeometry3D mesh, Brush brush)
        {
            Material material = new DiffuseMaterial(brush);
            return new GeometryModel3D(mesh, material);
        }


        // Make a model with a material group.
        public static GeometryModel3D MakeModel(this MeshGeometry3D mesh, MaterialGroup material)
        {
            return new GeometryModel3D(mesh, material);
        }

        #endregion Models

        #region Parallelogram

        // Add a parallelogram defined by a corner point and two edge vectors.
        // Texture coordinates and the point dictionary are optional.
        public static void AddParallelogram(this MeshGeometry3D mesh,
            Point3D corner, Vector3D v1, Vector3D v2,
            Point[] textureCoords = null,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Find the parallelogram's corners.
            Point3D[] points =
            {
                corner,
                corner + v1,
                corner + v1 + v2,
                corner + v2,
            };

            // Make it.
            mesh.AddPolygon(points: points, textureCoords: textureCoords,
                edges: edges, thickness: thickness);
        }

        #endregion Parallelogram

        #region Boxes

        // Add a parallelepiped defined by a corner point and three edge vectors.
        // The vectors should have more or less the orientation of the X, Y, and Z axes.
        // The corner point should be the back, lower, left corner
        // analogous to the smallest X, Y, and Z coordinates.
        // Texture coordinates are optional.
        // Points are shared on each face and not between faces.
        public static void AddBox(this MeshGeometry3D mesh,
            Point3D corner, Vector3D vx, Vector3D vy, Vector3D vz,
            Point[] textureCoords = null,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddBox(corner, vx, vy, vz,
                textureCoords, textureCoords, textureCoords,
                textureCoords, textureCoords, textureCoords,
                edges, thickness);
        }

        // Add a parallelepiped with different texture coordinates for each face.
        public static void AddBox(this MeshGeometry3D mesh,
            Point3D corner, Vector3D vx, Vector3D vy, Vector3D vz,
            Point[] frontCoords, Point[] leftCoords, Point[] rightCoords,
            Point[] backCoords, Point[] topCoords, Point[] bottomCoords,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddParallelogram(corner + vz, vx, vy, frontCoords, edges, thickness);        // Front
            mesh.AddParallelogram(corner, vz, vy, leftCoords, edges, thickness);              // Left
            mesh.AddParallelogram(corner + vx + vz, -vz, vy, rightCoords, edges, thickness);  // Right
            mesh.AddParallelogram(corner + vx, -vx, vy, backCoords, edges, thickness);        // Back
            mesh.AddParallelogram(corner + vy + vz, vx, -vz, topCoords, edges, thickness);    // Top
            mesh.AddParallelogram(corner, vx, vz, bottomCoords, edges, thickness);            // Bottom
        }

        // Add a parallelepiped with wrapped texture coordinates.
        public static void AddBoxWrapped(this MeshGeometry3D mesh,
            Point3D corner, Vector3D vx, Vector3D vy, Vector3D vz,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get texture coordinates for the pieces.
            Point[] frontCoords =
            {
                new Point(0.25, 0.75),
                new Point(0.50, 0.75),
                new Point(0.50, 0.50),
                new Point(0.25, 0.50),
            };
            Point[] leftCoords =
            {
                new Point(0.00, 0.25),
                new Point(0.00, 0.50),
                new Point(0.25, 0.50),
                new Point(0.25, 0.25),
            };
            Point[] rightCoords =
            {
                new Point(0.75, 0.50),
                new Point(0.75, 0.25),
                new Point(0.50, 0.25),
                new Point(0.50, 0.50),
            };
            Point[] backCoords =
            {
                new Point(0.50, 0.00),
                new Point(0.25, 0.00),
                new Point(0.25, 0.25),
                new Point(0.50, 0.25),
            };
            Point[] topCoords =
            {
                new Point(0.25, 0.50),
                new Point(0.50, 0.50),
                new Point(0.50, 0.25),
                new Point(0.25, 0.25),
            };
            Point[] bottomCoords =
            {
                new Point(0.25, 1.00),
                new Point(0.50, 1.00),
                new Point(0.50, 0.75),
                new Point(0.25, 0.75),
            };

            // Add a point to use all texture coordinates in the area (0, 0) - (1, 1).
            mesh.Positions.Add(new Point3D());
            mesh.TextureCoordinates.Add(new Point(1, 1));

            // Add the box.
            mesh.AddBox(corner, vx, vy, vz,
                frontCoords, leftCoords, rightCoords,
                backCoords, topCoords, bottomCoords,
                edges, thickness);
        }

        #endregion Boxes

        #region Axes

        // Make models for the coordinate axes.
        public static void AddXAxis(Model3DGroup group,
            double length = 4, double thickness = 0.1)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D origin = D3.Origin -
                D3.XVector(thickness / 2) -
                D3.YVector(thickness / 2) -
                D3.ZVector(thickness / 2);
            mesh.AddBox(origin,
                D3.XVector(length), D3.YVector(thickness), D3.ZVector(thickness));
            group.Children.Add(mesh.MakeModel(Brushes.Red));
        }

        public static void AddYAxis(Model3DGroup group,
            double length = 4, double thickness = 0.1)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D origin = D3.Origin -
                D3.XVector(thickness / 2) -
                D3.YVector(thickness / 2) -
                D3.ZVector(thickness / 2);
            mesh.AddBox(origin,
                D3.XVector(thickness), D3.YVector(length), D3.ZVector(thickness));
            group.Children.Add(mesh.MakeModel(Brushes.Green));
        }

        public static void AddZAxis(Model3DGroup group,
            double length = 4, double thickness = 0.1)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D origin = D3.Origin -
                D3.XVector(thickness / 2) -
                D3.YVector(thickness / 2) -
                D3.ZVector(thickness / 2);
            mesh.AddBox(origin,
                D3.XVector(thickness), D3.YVector(thickness), D3.ZVector(length));
            group.Children.Add(mesh.MakeModel(Brushes.Blue));
        }

        // Make a cube at the origin.
        public static void AddOrigin(Model3DGroup group,
            double cubeThickness = 0.102)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D origin = D3.Origin -
                D3.XVector(cubeThickness / 2) -
                D3.YVector(cubeThickness / 2) -
                D3.ZVector(cubeThickness / 2);
            mesh.AddBox(origin,
                D3.XVector(cubeThickness),
                D3.YVector(cubeThickness),
                D3.ZVector(cubeThickness));
            group.Children.Add(mesh.MakeModel(Brushes.Black));
        }

        // Make X, Y, and Z axes, and the origin cube.
        public static void AddAxes(Model3DGroup group,
            double length = 4, double thickness = 0.1,
            double cubeThickness = 0.102)
        {
            AddXAxis(group, length, thickness);
            AddYAxis(group, length, thickness);
            AddZAxis(group, length, thickness);
            AddOrigin(group, cubeThickness);
        }

        #endregion Axes

        #region Pyramids

        // Add a pyramid defined by a center point, a polygon, and an axis vector.
        // The polygon should be oriented toward its axis.
        public static void AddPyramid(this MeshGeometry3D mesh,
            Point3D center, Point3D[] polygon, Vector3D axis,
            bool smoothSides = false, HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Find the apex.
            Point3D apex = center + axis;

            // If we should smooth the sides, make the point dictionary.
            Dictionary<Point3D, int> pointDict = null;
            if (smoothSides) pointDict = new Dictionary<Point3D, int>();

            // Make the sides.
            int numPoints = polygon.Length;
            for (int i = 0; i < numPoints; i++)
            {
                int i1 = (i + 1) % numPoints;
                mesh.AddPolygon(pointDict, edges, thickness, null,
                    polygon[i], polygon[i1], apex);
            }

            // Make the bottom.
            Point3D[] bottom = new Point3D[numPoints];
            Array.Copy(polygon, bottom, numPoints);
            Array.Reverse(bottom);
            mesh.AddPolygon(pointDict, edges, thickness, null, bottom);
        }

        // Add a frustum.
        // Length is the length measured along the axis.
        public static void AddFrustum(this MeshGeometry3D mesh,
            Point3D center, Point3D[] polygon, Vector3D axis, double length,
            bool smoothSides = false, HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Find the length ratio.
            double ratio = length / axis.Length;

            // See where the apex would be.
            Point3D apex = center + axis;

            // Make the top.
            int numPoints = polygon.Length;
            Point3D[] top = new Point3D[numPoints];
            for (int i = 0; i < polygon.Length; i++)
            {
                Vector3D vector = apex - polygon[i];
                vector *= ratio;
                top[i] = polygon[i] + vector;
            }
            mesh.AddPolygon(points: top, edges: edges, thickness: thickness);

            // If we should smooth the sides, make the point dictionary.
            Dictionary<Point3D, int> pointDict = null;
            if (smoothSides) pointDict = new Dictionary<Point3D, int>();

            // Make the sides.
            for (int i = 0; i < polygon.Length; i++)
            {
                int i1 = (i + 1) % numPoints;
                mesh.AddPolygon(pointDict, edges, thickness, null,
                    polygon[i], polygon[i1], top[i1], top[i]);
            }

            // Make the bottom.
            Point3D[] bottom = new Point3D[numPoints];
            Array.Copy(polygon, bottom, numPoints);
            Array.Reverse(bottom);
            mesh.AddPolygon(points: bottom, edges: edges, thickness: thickness);
        }

        // Add a frustum where the top is determined by a plane of intersection.
        // The plane is determined by the point planePt and the normal vector n.
        public static void AddFrustum(this MeshGeometry3D mesh,
            Point3D center, Point3D[] polygon, Vector3D axis,
            Point3D planePt, Vector3D n, bool smoothSides = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // See where the apex would be.
            Point3D apex = center + axis;

            // Make the top.
            int numPoints = polygon.Length;
            Point3D[] top = new Point3D[numPoints];
            for (int i = 0; i < polygon.Length; i++)
            {
                // Get the vector from the point to the apex.
                Vector3D vector = apex - polygon[i];

                // See where this vector intersects the plane.
                top[i] = IntersectPlaneLine(polygon[i], vector, planePt, n);
            }
            mesh.AddPolygon(points: top, edges: edges, thickness: thickness);

            // If we should smooth the sides, make the point dictionary.
            Dictionary<Point3D, int> pointDict = null;
            if (smoothSides) pointDict = new Dictionary<Point3D, int>();

            // Make the sides.
            for (int i = 0; i < polygon.Length; i++)
            {
                int i1 = (i + 1) % numPoints;
                mesh.AddPolygon(pointDict, edges, thickness, null,
                    polygon[i], polygon[i1], top[i1], top[i]);
            }

            // Make the bottom.
            Point3D[] bottom = new Point3D[numPoints];
            Array.Copy(polygon, bottom, numPoints);
            Array.Reverse(bottom);
            mesh.AddPolygon(points: bottom, edges: edges, thickness: thickness);
        }

        // Find the intersection of a plane and a line.
        // The line is given by point linePt and vector v.
        // The plane is given by point planePt and normal vector n.
        private static Point3D IntersectPlaneLine(Point3D linePt, Vector3D v,
            Point3D planePt, Vector3D n, bool smoothSides = false)
        {
            // Get the equation for the plane.
            // For information on getting the plane equation, see:
            // http://www.songho.ca/math/plane/plane.html
            double A = n.X;
            double B = n.Y;
            double C = n.Z;
            double D = -(A * planePt.X + B * planePt.Y + C * planePt.Z);

            // Find the intersection parameter t.
            // For information on finding the intersection, see:
            // http://www.ambrsoft.com/TrigoCalc/Plan3D/PlaneLineIntersection_.htm
            double t = -(A * linePt.X + B * linePt.Y + C * linePt.Z + D) /
                (A * v.X + B * v.Y + C * v.Z);

            // Find the point of intersection.
            return linePt + t * v;
        }

        #endregion Pyramids

        #region Cones

        // These methods delegate their work to pyramid and frustum methods.
        public static void AddCone(this MeshGeometry3D mesh,
            Point3D center, Point3D[] polygon, Vector3D axis,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddPyramid(center, polygon, axis, true, edges, thickness);
        }
        public static void AddConeFrustum(this MeshGeometry3D mesh,
            Point3D center, Point3D[] polygon, Vector3D axis, double length,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddFrustum(center, polygon, axis, length, true, edges, thickness);
        }
        public static void AddConeFrustum(this MeshGeometry3D mesh,
            Point3D center, Point3D[] polygon, Vector3D axis,
            Point3D planePt, Vector3D n,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            mesh.AddFrustum(center, polygon, axis, planePt, n, true, edges, thickness);
        }

        #endregion Cones

        #region Cylinders

        // Add a cylinder defined by a center point, a polygon, and an axis vector.
        // The cylinder should be oriented toward its axis.
        public static void AddCylinder(this MeshGeometry3D mesh,
            Point3D[] polygon, Vector3D axis, bool smoothSides = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // If we should smooth the sides, make the point dictionary.
            Dictionary<Point3D, int> pointDict = null;
            if (smoothSides) pointDict = new Dictionary<Point3D, int>();

            // Make the top.
            int numPoints = polygon.Length;
            Point3D[] top = new Point3D[numPoints];
            for (int i = 0; i < polygon.Length; i++)
            {
                top[i] = polygon[i] + axis;
            }
            mesh.AddPolygon(points: top, edges: edges, thickness: thickness);

            // Make the sides.
            for (int i = 0; i < polygon.Length; i++)
            {
                int i1 = (i + 1) % numPoints;
                mesh.AddPolygon(pointDict, edges, thickness, null,
                    polygon[i], polygon[i1], top[i1], top[i]);
            }

            // Make the bottom.
            Point3D[] bottom = new Point3D[numPoints];
            Array.Copy(polygon, bottom, numPoints);
            Array.Reverse(bottom);
            mesh.AddPolygon(points: bottom, edges: edges, thickness: thickness);
        }

        // Add a cylinder defined by a polygon, two axis, and two cutting planes.
        public static void AddCylinder(this MeshGeometry3D mesh,
            Point3D[] polygon, Vector3D axis,
            Point3D topPlanePt, Vector3D topN,
            Point3D bottomPlanePt, Vector3D bottomN,
            bool smoothSides = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Make the top.
            int numPoints = polygon.Length;
            Point3D[] top = new Point3D[numPoints];
            for (int i = 0; i < polygon.Length; i++)
            {
                // See where this vector intersects the top cutting plane.
                top[i] = IntersectPlaneLine(polygon[i], axis, topPlanePt, topN);
            }
            mesh.AddPolygon(points: top, edges: edges, thickness: thickness);

            // Make the bottom.
            Point3D[] bottom = new Point3D[numPoints];
            for (int i = 0; i < polygon.Length; i++)
            {
                // See where this vector intersects the bottom cutting plane.
                bottom[i] = IntersectPlaneLine(polygon[i], axis, bottomPlanePt, bottomN);
            }

            // If we should smooth the sides, make the point dictionary.
            Dictionary<Point3D, int> pointDict = null;
            if (smoothSides) pointDict = new Dictionary<Point3D, int>();

            // Make the sides.
            for (int i = 0; i < polygon.Length; i++)
            {
                int i1 = (i + 1) % numPoints;
                mesh.AddPolygon(pointDict, edges, thickness, null,
                    bottom[i], bottom[i1], top[i1], top[i]);
            }

            // Make the bottom.
            Array.Reverse(bottom);
            mesh.AddPolygon(points: bottom, edges: edges, thickness: thickness);
        }

        #endregion Cylinders

        #region Spheres

        // Add a sphere without texture coordinates.
        public static void AddSphere(this MeshGeometry3D mesh,
            Point3D center, double radius, int numTheta, int numPhi,
            bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Make a point dictionary if needed.
            Dictionary<Point3D, int> pointDict = null;
            if (smooth) pointDict = new Dictionary<Point3D, int>();

            // Generate the points.
            double dtheta = 2 * Math.PI / numTheta;
            double dphi = Math.PI / numPhi;
            double theta = 0;
            for (int t = 0; t < numTheta; t++)
            {
                double phi = 0;
                for (int p = 0; p < numPhi; p++)
                {
                    // Find this piece's points.
                    Point3D[] points =
                    {
                        G3.SpherePoint(center, radius, theta, phi),
                        G3.SpherePoint(center, radius, theta, phi + dphi),
                        G3.SpherePoint(center, radius, theta + dtheta, phi + dphi),
                        G3.SpherePoint(center, radius, theta + dtheta, phi),
                    };

                    // Make the polygon.
                    mesh.AddPolygon(pointDict: pointDict,
                        edges: edges, thickness: thickness, points: points);
                    //@mesh.AddPolygon(pointDict: pointDict, points: points);

                    phi += dphi;
                }
                theta += dtheta;
            }
        }

        // Add a sphere with texture coordinates.
        public static void AddTexturedSphere(this MeshGeometry3D mesh,
            Point3D center, double radius, int numTheta, int numPhi,
            bool smooth = false)
        {
            double dtheta = 2 * Math.PI / numTheta;
            double dphi = Math.PI / numPhi;
            double theta = 0;
            for (int t = 0; t < numTheta; t++)
            {
                double phi = 0;
                for (int p = 0; p < numPhi; p++)
                {
                    // Find this piece's points.
                    Point3D point1 = G3.SpherePoint(center, radius, theta, phi).Round();
                    Point3D point2 = G3.SpherePoint(center, radius, theta, phi + dphi).Round();
                    Point3D point3 = G3.SpherePoint(center, radius, theta + dtheta, phi + dphi).Round();
                    Point3D point4 = G3.SpherePoint(center, radius, theta + dtheta, phi).Round();

                    // Find this piece's texture coordinates.
                    Point coords1 = new Point((double)t / numTheta, (double)p / numPhi);
                    Point coords2 = new Point((double)t / numTheta, (double)(p + 1) / numPhi);
                    Point coords3 = new Point((double)(t + 1) / numTheta, (double)(p + 1) / numPhi);
                    Point coords4 = new Point((double)(t + 1) / numTheta, (double)p / numPhi);

                    // Find this piece's normals.
                    Vector3D normal1 = (Vector3D)G3.SpherePoint(D3.Origin, 1, theta, phi).Round();
                    Vector3D normal2 = (Vector3D)G3.SpherePoint(D3.Origin, 1, theta, phi + dphi).Round();
                    Vector3D normal3 = (Vector3D)G3.SpherePoint(D3.Origin, 1, theta + dtheta, phi + dphi).Round();
                    Vector3D normal4 = (Vector3D)G3.SpherePoint(D3.Origin, 1, theta + dtheta, phi).Round();

                    // Make the first triangle.
                    int index = mesh.Positions.Count;
                    mesh.Positions.Add(point1);
                    if (smooth) mesh.Normals.Add(normal1);
                    mesh.TextureCoordinates.Add(coords1);

                    mesh.Positions.Add(point2);
                    if (smooth) mesh.Normals.Add(normal2);
                    mesh.TextureCoordinates.Add(coords2);

                    mesh.Positions.Add(point3);
                    if (smooth) mesh.Normals.Add(normal3);
                    mesh.TextureCoordinates.Add(coords3);

                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);

                    // Make the second triangle.
                    mesh.Positions.Add(point1);
                    if (smooth) mesh.Normals.Add(normal1);
                    mesh.TextureCoordinates.Add(coords1);

                    mesh.Positions.Add(point3);
                    if (smooth) mesh.Normals.Add(normal3);
                    mesh.TextureCoordinates.Add(coords3);

                    mesh.Positions.Add(point4);
                    if (smooth) mesh.Normals.Add(normal4);
                    mesh.TextureCoordinates.Add(coords4);

                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);

                    phi += dphi;
                }
                theta += dtheta;
            }
        }

        #endregion Spheres

        #region Tori

        // Make a torus without texture coordinates.
        public static void AddTorus(this MeshGeometry3D mesh,
            Point3D center, double R, double r, int numTheta, int numPhi,
            bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Make a point dictionary if needed.
            Dictionary<Point3D, int> pointDict = null;
            if (smooth) pointDict = new Dictionary<Point3D, int>();

            // Generate the points.
            double dtheta = 2 * Math.PI / numTheta;
            double dphi = 2 * Math.PI / numPhi;
            double theta = 0;
            for (int t = 0; t < numTheta; t++)
            {
                double phi = 0;
                for (int p = 0; p < numPhi; p++)
                {
                    // Find this piece's points.
                    Point3D[] points =
                    {
                        G3.TorusPoint(center, R, r, theta + dtheta, phi),
                        G3.TorusPoint(center, R, r, theta + dtheta, phi + dphi),
                        G3.TorusPoint(center, R, r, theta, phi + dphi),
                        G3.TorusPoint(center, R, r, theta, phi),
                    };

                    // Make the polygon.
                    mesh.AddPolygon(pointDict: pointDict, points: points,
                        edges: edges, thickness: thickness);

                    phi += dphi;
                }
                theta += dtheta;
            }
        }

        // Add a textured torus.
        public static void AddTexturedTorus(this MeshGeometry3D mesh,
            Point3D center, double R, double r, int numTheta, int numPhi,
            bool smooth = false)
        {
            double dtheta = 2 * Math.PI / numTheta;
            double dphi = 2 * Math.PI / numPhi;
            double theta = Math.PI;         // Puts the texture's top/bottom on the inside.
            for (int t = 0; t < numTheta; t++)
            {
                double phi = 0;
                for (int p = 0; p < numPhi; p++)
                {
                    // Find this piece's points.
                    Point3D point1 = G3.TorusPoint(center, R, r, theta, phi).Round();
                    Point3D point2 = G3.TorusPoint(center, R, r, theta + dtheta, phi).Round();
                    Point3D point3 = G3.TorusPoint(center, R, r, theta + dtheta, phi + dphi).Round();
                    Point3D point4 = G3.TorusPoint(center, R, r, theta, phi + dphi).Round();

                    // Find this piece's normals.
                    Vector3D normal1 = G3.TorusNormal(D3.Origin, R, r, theta, phi);
                    Vector3D normal2 = G3.TorusNormal(D3.Origin, R, r, theta + dtheta, phi);
                    Vector3D normal3 = G3.TorusNormal(D3.Origin, R, r, theta + dtheta, phi + dphi);
                    Vector3D normal4 = G3.TorusNormal(D3.Origin, R, r, theta, phi + dphi);

                    // Find this piece's texture coordinates.
                    Point coords1 = new Point(1 - (double)p / numPhi, 1 - (double)t / numTheta);
                    Point coords2 = new Point(1 - (double)p / numPhi, 1 - (double)(t + 1) / numTheta);
                    Point coords3 = new Point(1 - (double)(p + 1) / numPhi, 1 - (double)(t + 1) / numTheta);
                    Point coords4 = new Point(1 - (double)(p + 1) / numPhi, 1 - (double)t / numTheta);

                    // Make the first triangle.
                    int index = mesh.Positions.Count;
                    mesh.Positions.Add(point1);
                    if (smooth) mesh.Normals.Add(normal1);
                    mesh.TextureCoordinates.Add(coords1);

                    mesh.Positions.Add(point2);
                    if (smooth) mesh.Normals.Add(normal2);
                    mesh.TextureCoordinates.Add(coords2);

                    mesh.Positions.Add(point3);
                    if (smooth) mesh.Normals.Add(normal3);
                    mesh.TextureCoordinates.Add(coords3);

                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);

                    // Make the second triangle.
                    mesh.Positions.Add(point1);
                    if (smooth) mesh.Normals.Add(normal1);
                    mesh.TextureCoordinates.Add(coords1);

                    mesh.Positions.Add(point3);
                    if (smooth) mesh.Normals.Add(normal3);
                    mesh.TextureCoordinates.Add(coords3);

                    mesh.Positions.Add(point4);
                    if (smooth) mesh.Normals.Add(normal4);
                    mesh.TextureCoordinates.Add(coords4);

                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);
                    mesh.TriangleIndices.Add(index++);

                    phi += dphi;
                }
                theta += dtheta;
            }

            // Add texture coordinates 1.01 to prevent "seams."
            mesh.Positions.Add(new Point3D());
            mesh.TextureCoordinates.Add(new Point(1.01, 1.01));
        }

        #endregion Tori

        #region Platonic Solids

        // Make a tetrahedron without texture coordinates or smoothing.
        public static void AddTetrahedron(this MeshGeometry3D mesh, bool centered = true,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get the points.
            Point3D A, B, C, D;
            G3.TetrahedronPoints(out A, out B, out C, out D, centered);

            // Make the faces.
            mesh.AddPolygon(edges, thickness, A, B, C);
            mesh.AddPolygon(edges, thickness, A, C, D);
            mesh.AddPolygon(edges, thickness, A, D, B);
            mesh.AddPolygon(edges, thickness, D, C, B);
        }
        public static void VerifyTetrahedron()
        {
            // Get the points.
            Point3D A, B, C, D;
            G3.TetrahedronPoints(out A, out B, out C, out D, true);

            // Verify the points.
            G3.VerifyPoints(A, B, C, D);

            // Verify the faces.
            G3.VerifyPolygon(A, B, C);
            G3.VerifyPolygon(A, C, D);
            G3.VerifyPolygon(A, D, B);
            G3.VerifyPolygon(D, C, B);
        }

        // Make a cube without texture coordinates or smoothing.
        public static void AddCube(this MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get the points.
            Point3D A, B, C, D, E, F, G, H;
            G3.CubePoints(out A, out B, out C, out D, out E, out F, out G, out H);

            // Make the faces.
            mesh.AddPolygon(edges, thickness, A, B, C, D);
            mesh.AddPolygon(edges, thickness, A, D, H, E);
            mesh.AddPolygon(edges, thickness, A, E, F, B);
            mesh.AddPolygon(edges, thickness, G, C, B, F);
            mesh.AddPolygon(edges, thickness, G, F, E, H);
            mesh.AddPolygon(edges, thickness, G, H, D, C);
        }
        public static void VerifyCube()
        {
            // Get the points.
            Point3D A, B, C, D, E, F, G, H;
            G3.CubePoints(out A, out B, out C, out D, out E, out F, out G, out H);

            // Verify the points.
            G3.VerifyPoints(A, B, C, D, E, F, G, H);

            // Verify the faces.
            G3.VerifyPolygon(A, B, C, D);
            G3.VerifyPolygon(A, D, H, E);
            G3.VerifyPolygon(A, E, F, B);
            G3.VerifyPolygon(G, C, B, F);
            G3.VerifyPolygon(G, F, E, H);
            G3.VerifyPolygon(G, H, D, C);
        }

        // Make an octahedron without texture coordinates or smoothing.
        public static void AddOctahedron(this MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get the points.
            Point3D A, B, C, D, E, F;
            G3.OctahedronPoints(out A, out B, out C, out D, out E, out F);

            // Make the faces.
            mesh.AddPolygon(edges, thickness, A, B, C);
            mesh.AddPolygon(edges, thickness, A, C, D);
            mesh.AddPolygon(edges, thickness, A, D, E);
            mesh.AddPolygon(edges, thickness, A, E, B);
            mesh.AddPolygon(edges, thickness, F, B, E);
            mesh.AddPolygon(edges, thickness, F, C, B);
            mesh.AddPolygon(edges, thickness, F, D, C);
            mesh.AddPolygon(edges, thickness, F, E, D);
        }
        public static void VerifyOctahedron()
        {
            // Get the points.
            Point3D A, B, C, D, E, F;
            G3.OctahedronPoints(out A, out B, out C, out D, out E, out F);

            // Verify the points.
            G3.VerifyPoints(A, B, C, D);

            // Verify the faces.
            G3.VerifyPolygon(A, B, C);
            G3.VerifyPolygon(A, C, D);
            G3.VerifyPolygon(A, D, E);
            G3.VerifyPolygon(A, E, B);
            G3.VerifyPolygon(F, B, E);
            G3.VerifyPolygon(F, C, B);
            G3.VerifyPolygon(F, D, C);
            G3.VerifyPolygon(F, E, D);
        }

        // Make a dodecahedron without texture coordinates or smoothing.
        public static void AddDodecahedron(this MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get the points.
            Point3D A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T;
            G3.DodecahedronPoints(
                out A, out B, out C, out D, out E,
                out F, out G, out H, out I, out J,
                out K, out L, out M, out N, out O,
                out P, out Q, out R, out S, out T);

            // Make the faces.
            mesh.AddPolygon(edges, thickness, E, D, C, B, A);
            mesh.AddPolygon(edges, thickness, A, B, G, K, F);
            mesh.AddPolygon(edges, thickness, A, F, O, J, E);
            mesh.AddPolygon(edges, thickness, E, J, N, I, D);
            mesh.AddPolygon(edges, thickness, D, I, M, H, C);
            mesh.AddPolygon(edges, thickness, C, H, L, G, B);
            mesh.AddPolygon(edges, thickness, K, P, T, O, F);
            mesh.AddPolygon(edges, thickness, O, T, S, N, J);
            mesh.AddPolygon(edges, thickness, N, S, R, M, I);
            mesh.AddPolygon(edges, thickness, M, R, Q, L, H);
            mesh.AddPolygon(edges, thickness, L, Q, P, K, G);
            mesh.AddPolygon(edges, thickness, P, Q, R, S, T);
        }
        public static void VerifyDodecahedron()
        {
            // Get the points.
            Point3D A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T;
            G3.DodecahedronPoints(
                out A, out B, out C, out D, out E,
                out F, out G, out H, out I, out J,
                out K, out L, out M, out N, out O,
                out P, out Q, out R, out S, out T);

            // Verify the points.
            G3.VerifyPoints(A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T);

            // Verify the faces.
            G3.VerifyPolygon(E, D, C, B, A);
            G3.VerifyPolygon(A, B, G, K, F);
            G3.VerifyPolygon(A, F, O, J, E);
            G3.VerifyPolygon(E, J, N, I, D);
            G3.VerifyPolygon(D, I, M, H, C);
            G3.VerifyPolygon(C, H, L, G, B);
            G3.VerifyPolygon(K, P, T, O, F);
            G3.VerifyPolygon(O, T, S, N, J);
            G3.VerifyPolygon(N, S, R, M, I);
            G3.VerifyPolygon(M, R, Q, L, H);
            G3.VerifyPolygon(L, Q, P, K, G);
            G3.VerifyPolygon(P, Q, R, S, T);
        }

        // Make an icosahedron without texture coordinates or smoothing.
        public static void AddIcosahedron(this MeshGeometry3D mesh,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get the points.
            Point3D A, B, C, D, E, F, G, H, I, J, K, L;
            G3.IcosahedronPoints(
                out A, out B, out C, out D, out E, out F,
                out G, out H, out I, out J, out K, out L);

            // Make the faces.
            mesh.AddPolygon(edges, thickness, A, C, B);
            mesh.AddPolygon(edges, thickness, A, D, C);
            mesh.AddPolygon(edges, thickness, A, E, D);
            mesh.AddPolygon(edges, thickness, A, F, E);
            mesh.AddPolygon(edges, thickness, A, B, F);
            mesh.AddPolygon(edges, thickness, D, K, C);
            mesh.AddPolygon(edges, thickness, C, K, J);
            mesh.AddPolygon(edges, thickness, C, J, B);
            mesh.AddPolygon(edges, thickness, B, J, I);
            mesh.AddPolygon(edges, thickness, B, I, F);
            mesh.AddPolygon(edges, thickness, F, I, H);
            mesh.AddPolygon(edges, thickness, F, H, E);
            mesh.AddPolygon(edges, thickness, E, H, G);
            mesh.AddPolygon(edges, thickness, E, G, D);
            mesh.AddPolygon(edges, thickness, D, G, K);
            mesh.AddPolygon(edges, thickness, L, J, K);
            mesh.AddPolygon(edges, thickness, L, I, J);
            mesh.AddPolygon(edges, thickness, L, H, I);
            mesh.AddPolygon(edges, thickness, L, G, H);
            mesh.AddPolygon(edges, thickness, L, K, G);
        }
        public static void VerifyIcosahedron()
        {
            // Get the points.
            Point3D A, B, C, D, E, F, G, H, I, J, K, L;
            G3.IcosahedronPoints(
                out A, out B, out C, out D, out E, out F,
                out G, out H, out I, out J, out K, out L);

            // Verify the points.
            G3.VerifyPoints(A, B, C, D, E, F, G, H, I, J, K, L);

            // Verify the faces.
            G3.VerifyPolygon(A, C, B);
            G3.VerifyPolygon(A, D, C);
            G3.VerifyPolygon(A, E, D);
            G3.VerifyPolygon(A, F, E);
            G3.VerifyPolygon(A, B, F);
            G3.VerifyPolygon(D, K, C);
            G3.VerifyPolygon(C, K, J);
            G3.VerifyPolygon(C, J, B);
            G3.VerifyPolygon(B, J, I);
            G3.VerifyPolygon(B, I, F);
            G3.VerifyPolygon(F, I, H);
            G3.VerifyPolygon(F, H, E);
            G3.VerifyPolygon(E, H, G);
            G3.VerifyPolygon(E, G, D);
            G3.VerifyPolygon(D, G, K);
            G3.VerifyPolygon(L, J, K);
            G3.VerifyPolygon(L, I, J);
            G3.VerifyPolygon(L, H, I);
            G3.VerifyPolygon(L, G, H);
            G3.VerifyPolygon(L, K, G);
        }

        #endregion Platonic Solids

        #region Wireframe

        // Make a thin line segment.
        public static void AddSegment(this MeshGeometry3D mesh,
            double thickness, Point3D point1, Point3D point2)
        {
            // Get a vector between the points.
            Vector3D v = point2 - point1;

            // Get perpendicular vectors.
            Vector3D vz, vx;
            double angle = Vector3D.AngleBetween(v, D3.YVector());
            if ((angle > 10) && (angle < 170))
                vz = Vector3D.CrossProduct(v, D3.YVector());
            else
                vz = Vector3D.CrossProduct(v, D3.ZVector());
            vx = Vector3D.CrossProduct(v, vz);

            // Give the perpendicular vectors length thickness.
            vx *= thickness / vx.Length;
            vz *= thickness / vz.Length;

            // Make the box.
            mesh.AddBox(point1 - vx / 2 - vz / 2, vx, v, vz);
        }

        // Add a wireframe edge to this mesh.
        public static void AddEdge(this MeshGeometry3D mesh,
            HashSet<Edge> edges, double thickness, Point3D point1, Point3D point2)
        {
            // If the points are the same, skip it.
            if (point1 == point2) return;

            // See if the edge is already in the HashSet.
            Edge edge = new Edge(point1, point2);
            if (edges.Contains(edge)) return;

            // Add the edge.
            edges.Add(edge);
            mesh.AddSegment(thickness, point1, point2);
        }

        // Add a polygon's wireframe to this mesh.
        public static void AddPolygonEdges(this MeshGeometry3D mesh,
            HashSet<Edge> edges, double thickness, params Point3D[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                int i1 = (i + 1) % points.Length;
                mesh.AddEdge(edges, thickness, points[i], points[i1]);
            }
        }

        // Convert a mesh into a new mesh containing a wireframe.
        public static MeshGeometry3D ToWireframe(this MeshGeometry3D mesh, double thickness)
        {
            // Make a dictionary of edges.
            HashSet<Edge> edges = new HashSet<Edge>();

            // Make the wireframe pieces.
            MeshGeometry3D result = new MeshGeometry3D();
            for (int i = 0; i < mesh.TriangleIndices.Count; i += 3)
            {
                Point3D point1 = mesh.Positions[mesh.TriangleIndices[i]];
                Point3D point2 = mesh.Positions[mesh.TriangleIndices[i + 1]];
                Point3D point3 = mesh.Positions[mesh.TriangleIndices[i + 2]];
                result.AddPolygonEdges(edges, thickness, point1, point2, point3);
            }
            return result;
        }

        #endregion Wireframe

        #region Geodesic Sphere

        // Add a geodesic sphere.
        public static void AddGeodesicSphere(this MeshGeometry3D mesh,
            Point3D center, double radius, int numDivisions,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Create an icosahedron.
            // Get the points.
            Point3D A, B, C, D, E, F, G, H, I, J, K, L;
            G3.IcosahedronPoints(
                out A, out B, out C, out D, out E, out F,
                out G, out H, out I, out J, out K, out L);

            // Scale the icosahedron to the proper radius and center it.
            double scale = radius / G3.IcosahedronCircumradius();
            ScaleTransform3D scaleT = new ScaleTransform3D(scale, scale, scale);
            TranslateTransform3D translateT = new TranslateTransform3D(center.X, center.Y, center.Z);
            Transform3DGroup groupT = new Transform3DGroup();
            groupT.Children.Add(scaleT);
            groupT.Children.Add(translateT);
            A = groupT.Transform(A);
            B = groupT.Transform(B);
            C = groupT.Transform(C);
            D = groupT.Transform(D);
            E = groupT.Transform(E);
            F = groupT.Transform(F);
            G = groupT.Transform(G);
            H = groupT.Transform(H);
            I = groupT.Transform(I);
            J = groupT.Transform(J);
            K = groupT.Transform(K);
            L = groupT.Transform(L);

            // Make the icosahedron's faces.
            List<Triangle> triangles = new List<Triangle>();
            triangles.Add(new Triangle(A, C, B));
            triangles.Add(new Triangle(A, D, C));
            triangles.Add(new Triangle(A, E, D));
            triangles.Add(new Triangle(A, F, E));
            triangles.Add(new Triangle(A, B, F));
            triangles.Add(new Triangle(D, K, C));
            triangles.Add(new Triangle(C, K, J));
            triangles.Add(new Triangle(C, J, B));
            triangles.Add(new Triangle(B, J, I));
            triangles.Add(new Triangle(B, I, F));
            triangles.Add(new Triangle(F, I, H));
            triangles.Add(new Triangle(F, H, E));
            triangles.Add(new Triangle(E, H, G));
            triangles.Add(new Triangle(E, G, D));
            triangles.Add(new Triangle(D, G, K));
            triangles.Add(new Triangle(L, J, K));
            triangles.Add(new Triangle(L, I, J));
            triangles.Add(new Triangle(L, H, I));
            triangles.Add(new Triangle(L, G, H));
            triangles.Add(new Triangle(L, K, G));

            // Subdivide the faces as desired.
            List<Triangle> newTriangles = new List<Triangle>();
            foreach (Triangle triangle in triangles)
            {
                // Subdivide this triangle and add the results to newTriangles.
                newTriangles.AddRange(triangle.DivideGeodesic(center, radius, numDivisions));
            }

            // Create the geodesic sphere.
            foreach (Triangle triangle in newTriangles)
            {
                mesh.AddPolygon(edges, thickness, triangle.Points.ToArray());
            }

            //// Analysis.
            //Console.WriteLine("# Triangles: " + newTriangles.Count);
            //List<double> angles = new List<double>();
            //foreach (Triangle triangle in newTriangles) angles.AddRange(triangle.Angles());
            //var anglesQuery =
            //    from double angle in angles
            //    orderby angle
            //    select Math.Round(angle, 5);
            //Console.Write("Angles:");
            //foreach (double angle in anglesQuery.Distinct())
            //    Console.Write(" " + angle);
            //Console.WriteLine();
        }

        #endregion Geodesic Sphere

        #region Stellate Polyhedrons

        // Make a stellate octahedron without texture coordinates or smoothing.
        public static void AddStellateOctahedron(this MeshGeometry3D mesh,
            double starRadius, HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get the octahedron's points.
            Point3D A, B, C, D, E, F;
            G3.OctahedronPoints(out A, out B, out C, out D, out E, out F);

            // Make face polygons.
            List<Polygon> polygons = new List<Polygon>();
            polygons.Add(new Polygon(A, B, C));
            polygons.Add(new Polygon(A, C, D));
            polygons.Add(new Polygon(A, D, E));
            polygons.Add(new Polygon(A, E, B));
            polygons.Add(new Polygon(F, B, E));
            polygons.Add(new Polygon(F, C, B));
            polygons.Add(new Polygon(F, D, C));
            polygons.Add(new Polygon(F, E, D));

            // Stellify the faces.
            List<Triangle> triangles = new List<Triangle>();
            foreach (Polygon polygon in polygons)
            {
                triangles.AddRange(polygon.MakeStellateTriangles(D3.Origin, starRadius));
            }

            // Add triangles to the mesh.
            foreach (Triangle triangle in triangles)
                mesh.AddPolygon(edges, thickness, triangle.Points.ToArray());
        }

        // Make a stellate dodecahedron without texture coordinates or smoothing.
        public static void AddStellateDodecahedron(this MeshGeometry3D mesh,
            double starRadius, HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Get the points.
            Point3D A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T;
            G3.DodecahedronPoints(
                out A, out B, out C, out D, out E,
                out F, out G, out H, out I, out J,
                out K, out L, out M, out N, out O,
                out P, out Q, out R, out S, out T);

            // Make face polygons.
            List<Polygon> polygons = new List<Polygon>();
            polygons.Add(new Polygon(E, D, C, B, A));
            polygons.Add(new Polygon(A, B, G, K, F));
            polygons.Add(new Polygon(A, F, O, J, E));
            polygons.Add(new Polygon(E, J, N, I, D));
            polygons.Add(new Polygon(D, I, M, H, C));
            polygons.Add(new Polygon(C, H, L, G, B));
            polygons.Add(new Polygon(K, P, T, O, F));
            polygons.Add(new Polygon(O, T, S, N, J));
            polygons.Add(new Polygon(N, S, R, M, I));
            polygons.Add(new Polygon(M, R, Q, L, H));
            polygons.Add(new Polygon(L, Q, P, K, G));
            polygons.Add(new Polygon(P, Q, R, S, T));

            // Stellify the faces.
            List<Triangle> triangles = new List<Triangle>();
            foreach (Polygon polygon in polygons)
            {
                triangles.AddRange(polygon.MakeStellateTriangles(D3.Origin, starRadius));
            }

            // Add triangles to the mesh.
            foreach (Triangle triangle in triangles)
                mesh.AddPolygon(edges, thickness, triangle.Points.ToArray());
        }

        // Make a stellate geodesic sphere without texture coordinates or smoothing.
        public static void AddStellateGeodesicSphere(this MeshGeometry3D mesh,
            Point3D center, double radius, int numDivisions, double starRadius,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Create an icosahedron.
            // Get the points.
            Point3D A, B, C, D, E, F, G, H, I, J, K, L;
            G3.IcosahedronPoints(
                out A, out B, out C, out D, out E, out F,
                out G, out H, out I, out J, out K, out L);

            // Scale the icosahedron to the proper radius and center it.
            double scale = radius / G3.IcosahedronCircumradius();
            ScaleTransform3D scaleT = new ScaleTransform3D(scale, scale, scale);
            TranslateTransform3D translateT = new TranslateTransform3D(center.X, center.Y, center.Z);
            Transform3DGroup groupT = new Transform3DGroup();
            groupT.Children.Add(scaleT);
            groupT.Children.Add(translateT);
            A = groupT.Transform(A);
            B = groupT.Transform(B);
            C = groupT.Transform(C);
            D = groupT.Transform(D);
            E = groupT.Transform(E);
            F = groupT.Transform(F);
            G = groupT.Transform(G);
            H = groupT.Transform(H);
            I = groupT.Transform(I);
            J = groupT.Transform(J);
            K = groupT.Transform(K);
            L = groupT.Transform(L);

            // Make the icosahedron's faces.
            List<Triangle> triangles = new List<Triangle>();
            triangles.Add(new Triangle(A, C, B));
            triangles.Add(new Triangle(A, D, C));
            triangles.Add(new Triangle(A, E, D));
            triangles.Add(new Triangle(A, F, E));
            triangles.Add(new Triangle(A, B, F));
            triangles.Add(new Triangle(D, K, C));
            triangles.Add(new Triangle(C, K, J));
            triangles.Add(new Triangle(C, J, B));
            triangles.Add(new Triangle(B, J, I));
            triangles.Add(new Triangle(B, I, F));
            triangles.Add(new Triangle(F, I, H));
            triangles.Add(new Triangle(F, H, E));
            triangles.Add(new Triangle(E, H, G));
            triangles.Add(new Triangle(E, G, D));
            triangles.Add(new Triangle(D, G, K));
            triangles.Add(new Triangle(L, J, K));
            triangles.Add(new Triangle(L, I, J));
            triangles.Add(new Triangle(L, H, I));
            triangles.Add(new Triangle(L, G, H));
            triangles.Add(new Triangle(L, K, G));

            // Subdivide the faces as desired.
            List<Triangle> newTriangles = new List<Triangle>();
            foreach (Triangle triangle in triangles)
            {
                // Subdivide this triangle and add the results to newTriangles.
                newTriangles.AddRange(triangle.DivideGeodesic(center, radius, numDivisions));
            }

            // Convert the triangles into polygons.
            List<Polygon> polygons = new List<Polygon>();
            foreach (Triangle triangle in newTriangles)
                polygons.Add(new Polygon(triangle.Points.ToArray()));

            // Stellify the triangles.
            List<Triangle> stellateTriangles = new List<Triangle>();
            foreach (Polygon polygon in polygons)
            {
                stellateTriangles.AddRange(polygon.MakeStellateTriangles(center, starRadius));
            }

            // Add triangles to the mesh.
            foreach (Triangle triangle in stellateTriangles)
                mesh.AddPolygon(edges, thickness, triangle.Points.ToArray());
        }

        #endregion Stellate Polyhedrons

        #region Surfaces

        // Make a surface y = F(x, z).
        public static void AddSurface(this MeshGeometry3D mesh,
            Func<double, double, Point3D> F,
            double xmin, double xmax, int numX,
            double zmin, double zmax, int numZ,
            bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1,
            Point[] textureCoords = null)
        {
            // Make a point dictionary if desired.
            Dictionary<Point3D, int> pointDict = null;
            if (smooth) pointDict = new Dictionary<Point3D, int>();

            // Generate the surface's points.
            double dx = (xmax - xmin) / numX;
            double dz = (zmax - zmin) / numZ;
            double x = xmin;
            for (int ix = 0; ix < numX; ix++)
            {
                double z = zmin;
                for (int iz = 0; iz < numZ; iz++)
                {
                    Point3D p1 = F(x, z);
                    Point3D p2 = F(x, z + dz);
                    Point3D p3 = F(x + dx, z + dz);
                    Point3D p4 = F(x + dx, z);
                    mesh.AddPolygon(pointDict, edges, thickness, textureCoords, p1, p2, p3, p4);
                    z += dz;
                }
                x += dx;
            }
        }

        // Make a surface defined by a 2D array of points.
        public static void AddSurface(this MeshGeometry3D mesh,
            Point3D[,] points,
            bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1,
            Point[] textureCoords = null)
        {
            // Make a point dictionary if desired.
            Dictionary<Point3D, int> pointDict = null;
            if (smooth) pointDict = new Dictionary<Point3D, int>();

            // See how many pieces there are.
            int numX = points.GetUpperBound(0);
            int numZ = points.GetUpperBound(1);

            // Build the pieces.
            for (int ix = 0; ix < numX; ix++)
            {
                for (int iz = 0; iz < numZ; iz++)
                {
                    Point3D p1 = points[ix, iz];
                    Point3D p2 = points[ix, iz + 1];
                    Point3D p3 = points[ix + 1, iz + 1];
                    Point3D p4 = points[ix + 1, iz];
                    mesh.AddPolygon(pointDict, edges, thickness, textureCoords, p1, p2, p3, p4);
                }
            }
        }




        #endregion Surfaces


        #region Surfaces of Transformation

        // Add a surface of transformation.
        //
        // The trans parameter can be a specific transformation such as
        // TranslateTransform3D or it can be a Transform3D.
        //
        // To treat the points as a closed figure, repeat the first point at the end.
        //
        // Points must be oriented properly for the given transformation.
        //
        // If closeStart, make a polygon out of the generating polygon.
        //
        // If closeEnd, make a polygon out of the final transformed version
        // of the generating polygon.
        //
        // If closeFirst, make a polygon by transforming the first point.
        // The points must be oriented so that polygon is inwardly oriented.
        //
        // If closeLast, make a polygon by transforming the last point.
        // The points must be oriented so that polygon is inwardly oriented.
        public static void AddTransformSurface(this MeshGeometry3D mesh,
            Point3D[] generator, Transform3D trans, int num,
            bool closeTransStart = false, bool closeTransEnd = false,
            bool closeRotStart = false, bool closeRotEnd = false,
            bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Make a point dictionary if needed.
            Dictionary<Point3D, int> pointDict = null;
            if (smooth) pointDict = new Dictionary<Point3D, int>();

            // Make two working arrays.
            int numPoints = generator.Length;
            Point3D[] pts1 = new Point3D[generator.Length];
            Point3D[] pts2 = new Point3D[generator.Length];

            // Copy the original points into pts2.
            Array.Copy(generator, pts2, numPoints);

            // Apply the transformation.
            for (int i = 0; i < num; i++)
            {
                // Copy the last batch of points into pts1.
                Array.Copy(pts2, pts1, numPoints);

                // Transform the points in pts2.
                trans.Transform(pts2);

                // Build the edges.
                for (int p = 1; p < numPoints; p++)
                {
                    Point3D[] sidePts =
                    {
                        pts1[p - 1], pts1[p], pts2[p], pts2[p - 1],
                    };
                    mesh.AddPolygon(pointDict: pointDict,
                        edges: edges, thickness: thickness, points: sidePts);
                }
            }

            // Close the ends of a surface of translation if desired.
            if (closeTransStart)
            {
                Point3D[] pts = new Point3D[numPoints];
                Array.Copy(generator, pts, numPoints);
                Array.Reverse(pts);
                mesh.AddPolygon(pointDict: pointDict,
                    edges: edges, thickness: thickness, points: pts);
            }
            if (closeTransEnd)
            {
                mesh.AddPolygon(pointDict: pointDict,
                    edges: edges, thickness: thickness, points: pts2);
            }

            // Close the ends of a surface of rotation if desired.
            if (closeRotStart)
            {
                Point3D[] pts = GetTransformPolygon(generator[0], trans, num);
                mesh.AddPolygon(pointDict: pointDict,
                    edges: edges, thickness: thickness, points: pts);
            }
            if (closeRotEnd)
            {
                Point3D[] pts = GetTransformPolygon(generator[numPoints - 1], trans, num);
                Array.Reverse(pts);
                mesh.AddPolygon(pointDict: pointDict,
                    edges: edges, thickness: thickness, points: pts);
            }
        }

        // Return an array containing a point and its transformed versions.
        public static Point3D[] GetTransformPolygon(
            Point3D point, Transform3D trans, int num)
        {
            // Make an array to hold the point and its transformations.
            Point3D[] points = new Point3D[num];

            // Transform the point.
            for (int i = 0; i < num; i++)
            {
                points[i] = point;
                point = trans.Transform(point);
            }

            // Return the points.
            return points;
        }

        // Add a surface defined by a polygon and a path that it should follow.
        // The generator should be laid out in the XZ plane with its top in the X direction.
        public static void AddPathSurface(this MeshGeometry3D mesh,
            Point3D[] generator, Point3D[] path, Vector3D up,
            bool closeStart = false, bool closeEnd = false,
            bool smooth = false,
            HashSet<Edge> edges = null, double thickness = 0.1)
        {
            // Make a point dictionary if needed.
            Dictionary<Point3D, int> pointDict = null;
            if (smooth) pointDict = new Dictionary<Point3D, int>();

            // Make two work arrays.
            int numGen = generator.Length;
            Point3D[] pts1 = new Point3D[numGen];
            Point3D[] pts2 = new Point3D[numGen];

            // Get the first set of points.
            GetPathPolygonPoints(pts1, path, 1, generator, up);

            // Loop through the path points.
            int numPath = path.Length;
            for (int p = 2; p <= numPath - 2; p++)
            {
                // Get the set of points at point p.
                GetPathPolygonPoints(pts2, path, p, generator, up);

                // Make a ring between the two sets of points.
                mesh.MakePathRing(pts1, pts2, pointDict, edges, thickness);

                // Switch the arrays.
                Point3D[] temp = pts1;
                pts1 = pts2;
                pts2 = temp;
            }

            // Cap the ends if desired.
            if (closeStart)
            {
                GetPathPolygonPoints(pts1, path, 1, generator, up);
                mesh.AddPolygon(edges, thickness, pts1);
            }
            if (closeEnd)
            {
                GetPathPolygonPoints(pts1, path, numPath - 2, generator, up);
                Array.Reverse(pts1);
                mesh.AddPolygon(edges, thickness, pts1);
            }
        }

        // Return the generator's points centered at point path[p]
        // and perpendicular to the path and up.
        private static void GetPathPolygonPoints(Point3D[] pts,
            Point3D[] path, int p1, Point3D[] generator, Vector3D up)
        {
            // Find the indices of the adjacent points on the path.
            int numPath = path.Length;
            int p0 = p1 - 1;
            int p2 = p1 + 1;

            // Find the path vector.
            Vector3D v1 = path[p1] - path[p0];
            Vector3D v2 = path[p2] - path[p1];
            Vector3D va = (v1 + v2) / 2;

            // Find the polygon's plane vectors.
            Vector3D vz = Vector3D.CrossProduct(va, up);
            Vector3D vx = Vector3D.CrossProduct(va, vz);
            vz.Normalize();
            vx.Normalize();

            // Fill in the points.
            for (int i = 0; i < generator.Length; i++)
            {
                pts[i] = path[p1] + vx * generator[i].X + vz * generator[i].Z;
            }
        }

        // Make a "ring" to connect the sets of points.
        private static void MakePathRing(this MeshGeometry3D mesh,
            Point3D[] pts1, Point3D[] pts2,
            Dictionary<Point3D, int> pointDict,
            HashSet<Edge> edges, double thickness)
        {
            // Loop through the points.
            for (int i = 0; i < pts1.Length - 1; i++)
            {
                Point3D[] points =
                {
                    pts1[i], pts2[i],
                    pts2[i + 1], pts1[i + 1],
                };

                mesh.AddPolygon(pointDict: pointDict, edges: edges,
                    thickness: thickness, points: points);
            }
        }

        #endregion Surfaces of Transformation


        #region Heightmaps

        // Map Y values (minY <= y <= maxY) to texture coordinates (minV <= y <= maxV).
        // Removes any previous texture coordinates.
        public static void ApplyHeightMap(this MeshGeometry3D mesh,
            double minV, double maxV, double minY, double maxY)
        {
            double ydiff = maxY - minY;
            double vdiff = maxV - minV;
            mesh.TextureCoordinates.Clear();
            for (int i = 0; i < mesh.Positions.Count; i++)
            {
                double v = minV + (mesh.Positions[i].Y - minY) * vdiff / ydiff;
                mesh.TextureCoordinates.Add(new Point(0, v));
            }
        }



        // Map Y values (minY <= y <= maxY) to texture coordinates (minV <= y <= maxV).
        // Removes any previous texture coordinates.
        public static void ApplySequenceMap(this MeshGeometry3D mesh,
            double minV, double maxV)
        {
            double ydiff = mesh.Positions.Count;
            double vdiff = maxV - minV;
            mesh.TextureCoordinates.Clear();
            for (int i = 0; i < mesh.Positions.Count; i++)
            {
                double v = minV + (i - 0.0) * vdiff / ydiff;
                mesh.TextureCoordinates.Add(new Point(0, v));

                //double v = minV + (mesh.Positions[i].Y - minY) * vdiff / ydiff;
                //mesh.TextureCoordinates.Add(new Point(0, v));
            }
        }



        #endregion Heightmaps


        #region Text

        // Draw text in a rectangle, uniformly sizing the text to fit.
        public static GeometryModel3D AddFittedText(this MeshGeometry3D mesh,
            string text, Point3D ll, Point3D lr, Point3D ur, Point3D ul,
            Brush bgBrush, Brush fgBrush, TextAlignment textAlign = TextAlignment.Center,
            FontFamily fontFamily = null)
        {
            Point3D[] points = { ll, lr, ur, ul };
            Point[] textureCoords =
            {
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 0),
                new Point(0, 0),
            };
            mesh.AddPolygon(points: points, textureCoords: textureCoords);

            // Make a material holding the text.
            double width = (ur - ul).Length;
            double height = (ul - ll).Length;
            Material material = mesh.MakeFittedTextMaterial(text,
                width, height, bgBrush, fgBrush, textAlign, fontFamily);

            // Make a model and return it.
            return new GeometryModel3D(mesh, material);
        }

        // Make a material with the given dimensions and
        // containing the text sized to fill it.
        public static Material MakeFittedTextMaterial(this MeshGeometry3D mesh,
            string text, double width, double height, Brush bgBrush, Brush fgBrush,
            TextAlignment textAlign = TextAlignment.Center,
            FontFamily fontFamily = null)
        {
            // Make a grid to hold everything and display the background.
            Grid grid = new Grid();
            grid.Background = bgBrush;
            grid.Width = width;         // Size to fit the area.
            grid.Height = height;

            // Make a viewbox to scale the text to fit.
            Viewbox box = new Viewbox();
            grid.Children.Add(box);
            box.Width = grid.Width;     // Size to fit the area.
            box.Height = grid.Height;

            // Make a TextBlock to display the text.
            TextBlock block = new TextBlock();
            box.Child = block;
            block.Text = text;
            block.Foreground = fgBrush;
            block.TextAlignment = textAlign;
            if (fontFamily != null) block.FontFamily = fontFamily;
            block.Margin = new Thickness(block.FontSize / 10);    // Needed to prevent a gap along the edge.

            // Make a brush.
            VisualBrush brush = new VisualBrush(grid);
            brush.Stretch = Stretch.Fill;

            // Make the brush into a material and return it.
            return new DiffuseMaterial(brush);
        }

        // Draw text with a specified font size in a rectangle.
        public static GeometryModel3D AddSizedText(this MeshGeometry3D mesh, string text,
            double fontSize, double matWidth, double matHeight,
            Point3D ll, Point3D lr, Point3D ur, Point3D ul,
            Brush bgBrush, Brush fgBrush,
            HorizontalAlignment hAlign = HorizontalAlignment.Center,
            VerticalAlignment vAlign = VerticalAlignment.Center,
            FontFamily fontFamily = null)
        {
            Point3D[] points = { ll, lr, ur, ul };
            Point[] textureCoords =
            {
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 0),
                new Point(0, 0),
            };
            mesh.AddPolygon(points: points, textureCoords: textureCoords);

            // Make a material holding the text.
            double width = (ur - ul).Length;
            double height = (ul - ll).Length;
            Material material = mesh.MakeSizedTextMaterial(text,
                fontSize, matWidth, matHeight,
                bgBrush, fgBrush, hAlign, vAlign, fontFamily);

            // Make a model and return it.
            //return new GeometryModel3D(mesh, material);

            var res1 = new GeometryModel3D(mesh, material);
            res1.BackMaterial = material;

            return res1;
        }

        // Make a material with the given dimensions and
        // containing the text with a given size.
        public static Material MakeSizedTextMaterial(this MeshGeometry3D mesh, string text,
            double fontSize, double matWidth, double matHeight,
            Brush bgBrush, Brush fgBrush,
            HorizontalAlignment hAlign = HorizontalAlignment.Center,
            VerticalAlignment vAlign = VerticalAlignment.Center,
            FontFamily fontFamily = null)
        {
            // Make a grid to hold everything and display the background.
            Grid grid = new Grid();
            grid.Background = bgBrush;
            grid.Width = matWidth;          // Size to fit the area.
            grid.Height = matHeight;

            // Make a TextBlock to display the text.
            TextBlock block = new TextBlock();
            grid.Children.Add(block);
            block.FontSize = fontSize;
            block.Text = text;
            block.Foreground = fgBrush;
            if (fontFamily != null) block.FontFamily = fontFamily;
            block.HorizontalAlignment = hAlign;
            block.VerticalAlignment = vAlign;
            block.Margin = new Thickness(fontSize / 10);    // Needed to prevent a gap along the edge.

            // Make a brush.
            VisualBrush brush = new VisualBrush(grid);
            brush.Stretch = Stretch.Fill;

            // Make the brush into a material and return it.
            return new DiffuseMaterial(brush);
        }

        #endregion Text


        #region General support functions for ScatterPlot and LineGraph       


        // Make a line graph.
        public static void MakeLineGraph(Model3DGroup group,
            double[,] values, Brush[] valuesBrushes,
            Point3D corner, double xLength, double yLength, double zLength,
            double boxThickness, double lineThickness, double curveThickness,
            Brush boxBrush, Brush lineBrush, Brush tickBrush,
            double labelWid, double labelHgt, double labelGap, double labelFontSize, Brush labelBrush,
            double titleHgt, double titleFontSize, Brush titleBrush,
            double xmin, double xmax, double tickDx, double labelDx, string xtitle, string[] xlabels,
            double ymin, double ymax, double tickDy, double labelDy, string ytitle, string[] ylabels,
            double zmin, double zmax, double tickDz, double labelDz, string ztitle, string[] zlabels)
        {
            // Make and label the plot box.
            MakePlotBox(group,
                corner, xLength, yLength, zLength,
                boxThickness, lineThickness,
                boxBrush, lineBrush, tickBrush,
                labelWid, labelHgt, labelGap, labelFontSize, labelBrush,
                titleHgt, titleFontSize, titleBrush,
                xmin, xmax, tickDx, labelDx, xtitle, xlabels,
                ymin, ymax, tickDy, labelDy, ytitle, ylabels,
                zmin, zmax, tickDz, labelDz, ztitle, zlabels);

            // Minimum X, Y, and Z values, and scales.
            double px1 = corner.X;
            double py1 = corner.Y;
            double pz1 = corner.Z;
            double xScale = xLength / (xmax - xmin);
            double yScale = yLength / (ymax - ymin);
            double zScale = zLength / (zmax - zmin);

            // Plot the data values.
            int numItems = values.GetUpperBound(0) + 1;
            int numEntries = values.GetUpperBound(1) + 1;
            Point3D point1;
            Point3D point2 = new Point3D();
            double radius = 2 * curveThickness;
            for (int iz = 0; iz < numItems; iz++)
            {
                double pz = pz1 + iz * zScale;
                MeshGeometry3D mesh = new MeshGeometry3D();
                for (int ix = 0; ix < numEntries; ix++)
                {
                    // Save the previous point.
                    point1 = point2;

                    // Find the new point.
                    double px = px1 + ix * xScale;
                    double py = py1 + (values[iz, ix] - ymin) * yScale;
                    point2 = new Point3D(px, py, pz);

                    // Plot the point.
                    mesh.AddSphere(point2, radius, 10, 5, true);

                    // Draw the line.
                    if (ix > 0)
                        mesh.AddSegment(curveThickness, point1, point2);
                }
                group.Children.Add(mesh.MakeModel(valuesBrushes[iz]));
            }
        }



        // Make a scatter plot.
        public static void MakeScatterPlot(Model3DGroup group,
            Point3D corner, double xLength, double yLength, double zLength,
            Point3D[] values, Brush valuesBrush,
            double boxThickness, double lineThickness,
            Brush boxBrush, Brush lineBrush, Brush tickBrush,
            double labelWid, double labelHgt, double labelGap, double labelFontSize, Brush labelBrush,
            double titleHgt, double titleFontSize, Brush titleBrush,
            double xmin, double xmax, double tickDx, double labelDx, string xtitle, string[] xlabels,
            double ymin, double ymax, double tickDy, double labelDy, string ytitle, string[] ylabels,
            double zmin, double zmax, double tickDz, double labelDz, string ztitle, string[] zlabels)
        {
            // Make and label the plot box.
            MakePlotBox(group, corner, xLength, yLength, zLength,
                boxThickness, lineThickness,
                boxBrush, lineBrush, tickBrush,
                labelWid, labelHgt, labelGap, labelFontSize, labelBrush,
                titleHgt, titleFontSize, titleBrush,
                xmin, xmax, tickDx, labelDx, xtitle, xlabels,
                ymin, ymax, tickDy, labelDy, ytitle, ylabels,
                zmin, zmax, tickDz, labelDz, ztitle, zlabels);

            // Minimum X, Y, and Z values, and scales.
            double px1 = corner.X;
            double py1 = corner.Y;
            double pz1 = corner.Z;
            double xScale = xLength / (xmax - xmin);
            double yScale = yLength / (ymax - ymin);
            double zScale = zLength / (zmax - zmin);

            // Plot the data values.
            MeshGeometry3D valuesMesh = new MeshGeometry3D();
            foreach (Point3D value in values)
            {
                Point3D p = new Point3D(
                    px1 + (value.X - xmin) * xScale,
                    py1 + (value.Y - ymin) * yScale,
                    pz1 + (value.Z - zmin) * zScale);
                valuesMesh.AddSphere(p, 0.2, 10, 5, true);
            }
            group.Children.Add(valuesMesh.MakeModel(valuesBrush));
        }





        // Make a label.
        public static void MakeLabel(string text, Point3D ll,
            Vector3D vRight, Vector3D vUp,
            Brush bgBrush, Brush fgBrush,
            double fontSize, FontFamily fontFamily,
            HorizontalAlignment hAlign, VerticalAlignment vAlign,
            Model3DGroup group)
        {
            double wid = vRight.Length;
            double hgt = vUp.Length;
            MeshGeometry3D mesh = new MeshGeometry3D();
            group.Children.Add(
                mesh.AddSizedText(text,
                    fontSize, wid, hgt,
                    ll, ll + vRight, ll + vRight + vUp, ll + vUp,
                    bgBrush, fgBrush, hAlign, vAlign, fontFamily));
        }






        // Make a box with the back XY, YZ, and ZX planes labeled with lines,
        // tick marks, and labels every 1 unit.
        public static void MakePlotBox(Model3DGroup group,
            Point3D corner, double xLength, double yLength, double zLength,
            double boxThickness, double lineThickness,
            Brush boxBrush, Brush lineBrush, Brush tickBrush,
            double labelWid, double labelHgt, double labelGap, double labelFontSize, Brush labelBrush,
            double titleHgt, double titleFontSize, Brush titleBrush,
            double xmin, double xmax, double tickDx, double labelDx, string xtitle, string[] xlabels,
            double ymin, double ymax, double tickDy, double labelDy, string ytitle, string[] ylabels,
            double zmin, double zmax, double tickDz, double labelDz, string ztitle, string[] zlabels)
        {
            const double tickWid = 0.2;
            FontFamily ff = new FontFamily("Franklin Gothic Demi");

            // Draw the box outline.
            Vector3D vx = D3.XVector(xLength);
            Vector3D vy = D3.YVector(yLength);
            Vector3D vz = D3.ZVector(zLength);
            MeshGeometry3D boxMesh = new MeshGeometry3D();
            boxMesh.AddSegment(boxThickness, corner, corner + vx);
            boxMesh.AddSegment(boxThickness, corner, corner + vy);
            boxMesh.AddSegment(boxThickness, corner, corner + vz);
            boxMesh.AddSegment(boxThickness, corner + vy, corner + vy + vx);
            boxMesh.AddSegment(boxThickness, corner + vy, corner + vy + vz);
            boxMesh.AddSegment(boxThickness, corner + vx, corner + vx + vy);
            boxMesh.AddSegment(boxThickness, corner + vx, corner + vx + vz);
            boxMesh.AddSegment(boxThickness, corner + vz, corner + vz + vx);
            boxMesh.AddSegment(boxThickness, corner + vz, corner + vz + vy);
            group.Children.Add(boxMesh.MakeModel(boxBrush));

            // Minimum X, Y, and Z values, and scales.
            double px1 = corner.X;
            double px2 = corner.X + xLength;
            double py1 = corner.Y;
            double py2 = corner.Y + yLength;
            double pz1 = corner.Z;
            double pz2 = corner.Z + zLength;
            double xScale = xLength / (xmax - xmin);
            double yScale = yLength / (ymax - ymin);
            double zScale = zLength / (zmax - zmin);

            // Lines and labels.
            MeshGeometry3D lineMesh = new MeshGeometry3D();

            // Lines with different X values.
            Point3D ll;
            int i = 0;
            for (double x = xmin; x < xmax + labelDx / 2; x += labelDx)
            {
                double px = px1 + (x - xmin) * xScale;

                // Label the line.
                ll = new Point3D(px + labelHgt / 2, py1, pz2 + labelWid + labelGap);
                MakeLabel(xlabels[i++], ll, D3.ZVector(-labelWid), D3.XVector(-labelHgt),
                    Brushes.Transparent, labelBrush, labelFontSize, ff,
                    HorizontalAlignment.Right, VerticalAlignment.Center, group);

                // Draw the line.
                if ((x > xmin) && (x < xmax - labelDx / 2))
                {
                    lineMesh.AddSegment(lineThickness,
                        new Point3D(px, py1, pz1),
                        new Point3D(px, py2, pz1));
                    lineMesh.AddSegment(lineThickness,
                        new Point3D(px, py1, pz1),
                        new Point3D(px, py1, pz2));
                }
            }

            // Lines with different Y values.
            i = 0;
            for (double y = ymin; y < ymax + labelDy / 2; y += labelDy)
            {
                double py = py1 + (y - ymin) * yScale;

                // Label the line.
                if (y > ymin)
                {
                    ll = new Point3D(px1, py - labelHgt / 2, pz2 + labelWid + labelGap);
                    MakeLabel(ylabels[i], ll, D3.ZVector(-labelWid), D3.YVector(labelHgt),
                        Brushes.Transparent, labelBrush, labelFontSize, ff,
                        HorizontalAlignment.Right, VerticalAlignment.Center, group);
                }
                i++;

                // Draw the line.
                if ((y > ymin) && (y < ymax - labelDy / 2))
                {
                    lineMesh.AddSegment(lineThickness,
                        new Point3D(px1, py, pz1),
                        new Point3D(px2, py, pz1));
                    lineMesh.AddSegment(lineThickness,
                        new Point3D(px1, py, pz1),
                        new Point3D(px1, py, pz2));
                }
            }

            // Lines with different Z values.
            i = 0;
            for (double z = zmin; z < zmax + labelDz / 2; z += labelDz)
            {
                double pz = pz1 + (z - zmin) * zScale;

                // Label the line.
                ll = new Point3D(px2 + labelGap, py1, pz + labelHgt / 2);
                MakeLabel(zlabels[i++], ll, D3.XVector(labelWid), D3.ZVector(-labelHgt),
                    Brushes.Transparent, labelBrush, labelFontSize, ff,
                    HorizontalAlignment.Left, VerticalAlignment.Center, group);

                // Draw the line.
                if ((z > zmin) && (z < zmax - labelDz / 2))
                {
                    lineMesh.AddSegment(lineThickness,
                        new Point3D(px1, py1, pz),
                        new Point3D(px2, py1, pz));
                    lineMesh.AddSegment(lineThickness,
                        new Point3D(px1, py1, pz),
                        new Point3D(px1, py2, pz));
                }
            }
            group.Children.Add(lineMesh.MakeModel(lineBrush));

            // Tick marks.
            MeshGeometry3D tickMesh = new MeshGeometry3D();

            // Lines with different X values.
            for (double x = xmin + tickDx; x < xmax + tickDx / 2; x += tickDx)
            {
                double px = px1 + (x - xmin) * xScale;
                tickMesh.AddSegment(lineThickness,
                    new Point3D(px, py1, pz2 - tickWid),
                    new Point3D(px, py1, pz2 + tickWid));
            }

            // Lines with different Y values.
            for (double y = ymin + tickDy; y < ymax + tickDy / 2; y += tickDy)
            {
                double py = py1 + (y - ymin) * yScale;
                tickMesh.AddSegment(lineThickness,
                    new Point3D(px1, py, pz2 - tickWid),
                    new Point3D(px1, py, pz2 + tickWid));
            }

            // Lines with different Z values.
            for (double z = zmin; z < zmax + tickDz / 2; z += tickDz)
            {
                double pz = pz1 + (z - zmin) * zScale;
                tickMesh.AddSegment(lineThickness,
                    new Point3D(px2 - tickWid, py1, pz),
                    new Point3D(px2 + tickWid, py1, pz));
            }
            group.Children.Add(tickMesh.MakeModel(lineBrush));

            // Draw titles.
            ll = new Point3D(
                px1,
                py1,
                pz2 + labelWid + labelGap + titleHgt);
            MakeLabel(xtitle, ll, D3.XVector(xLength), D3.ZVector(-titleHgt),
                Brushes.Transparent, titleBrush, titleFontSize, ff,
                HorizontalAlignment.Center, VerticalAlignment.Top, group);

            ll = new Point3D(
                px1,
                py2,
                pz2 + labelWid + labelGap + titleHgt);
            MakeLabel(ytitle, ll, D3.YVector(-yLength), D3.ZVector(-titleHgt),
                Brushes.Transparent, titleBrush, titleFontSize, ff,
                HorizontalAlignment.Center, VerticalAlignment.Top, group);

            ll = new Point3D(
                px2 + labelWid + labelGap + titleHgt,
                py1,
                pz2);
            MakeLabel(ztitle, ll, D3.ZVector(-zLength), D3.XVector(-titleHgt),
                Brushes.Transparent, titleBrush, titleFontSize, ff,
                HorizontalAlignment.Center, VerticalAlignment.Top, group);
        }

        // Load data. Coordinates are (combined mpg, cost, horsepower).
        // Source: https://www.edmunds.com/car-reviews/consumers-most-popular.html
        // Don't use for actual comparison because features may vary widely.
        public static Point3D[] LoadData4Scatterplot()
        {
            return new Point3D[]
            {
                new Point3D(34, 19640, 158),   // Honda Civic
                new Point3D(29, 28095, 190),   // Honda CR-V
                new Point3D(33, 23570, 192),   // Honda Accord
                new Point3D(32, 25200, 203),   // Toyota Camry
                new Point3D(20, 32025, 282),   // Ford F-150
                new Point3D(18, 27895, 285),   // Jeep Wrangler
                new Point3D(22, 39980, 295),   // Toyota Highlander
                new Point3D(21, 39995, 295),   // Jeep Grand Cherokee
                new Point3D(25, 25810, 176),   // Toyota RAV4
                new Point3D(21, 38255, 280),   // Honda Pilot
                new Point3D(21, 24575, 159),   // Toyota Tacoma
                new Point3D(26, 30695, 187),   // Mazda CX-5
                new Point3D(28, 32695, 175),   // Subaru Outback
                new Point3D(23, 26995, 305),   // Dodge Challenger
                new Point3D(23, 25895, 184),   // Jeep Cherokee
                new Point3D(28, 26195, 170),   // Subaru Forester
                new Point3D(26, 28500, 170),   // Chevrolet Equinox
                new Point3D(21, 44240, 280),   // Ford Explorer
                new Point3D(20, 34100, 290),   // Kia Sorento
                new Point3D(25, 25585, 300),   // Ford Mustang
                new Point3D(25, 26800, 275),   // Chevrolet Camaro
                new Point3D(29, 23595, 152),   // Subaru Crosstrek
                new Point3D(20, 31495, 305),   // Ram 1500
                new Point3D(22, 44200, 290),   // Acura MDX
                new Point3D(27, 26590, 170),   // Nissan Rogue
                new Point3D(28, 25200, 185),   // Hyundai Sonata
                new Point3D(26, 22700, 164),   // Hyundai Tucson
                new Point3D(22, 37360, 280),   // Honda Odyssey
                new Point3D(25, 42450, 248),   // BMW X3
                new Point3D(25, 24295, 180),   // Jeep Compass
                new Point3D(30, 24195, 184),   // Mazda 3
                new Point3D(25, 45500, 252),   // Audi Q5
                new Point3D(19, 34550, 285),   // Chevrolet Silverado 1500
                new Point3D(22, 44620, 295),   // Lexus RX 350
                new Point3D(26, 25605, 179),   // Ford Escape
                new Point3D(18, 39495, 270),   // Toyota 4Runner
                new Point3D(29, 23720, 141),   // Honda HR-V
                new Point3D(19, 32050, 305),   // Chevrolet Traverse
                new Point3D(23, 54050, 316),   // Volvo XC90
                new Point3D(22, 23480, 200),   // Chevrolet Colorado
                new Point3D(21, 30800, 290),   // Hyundai Santa Fe
                new Point3D(32, 18985, 132),   // Toyota Corolla
                new Point3D(20, 58900, 300),   // BMW X5
                new Point3D(24, 29220, 245),   // Ford Edge
                new Point3D(21, 37980, 280),   // Honda Ridgeline
                new Point3D(19, 62130, 355),   // Chevrolet Tahoe
                new Point3D(22, 35495, 287),   // Chrysler Pacifica
                new Point3D(20, 47020, 310),   // GMC Acadia
                new Point3D(25, 23250, 175),   // Ford Fusion
                new Point3D(21, 35495, 292),   // Dodge Charger
            };
        }


        // Load data.
        // Source: Made up.
        // Values hold sales for [item, month].
        public static double[,] LoadData4LineGraph()
        {
            return new double[,]
            {
                { 90, 85, 79, 55, 72, },
                { 67, 72, 64, 67, 63, },
                { 55, 58, 56, 50, 48, },
                { 50, 42, 38, 27, 30, },
            };
        }



        #endregion General support functions for ScatterPlot and LineGraph       





    }

    #endregion Class MeshExtensions





}
