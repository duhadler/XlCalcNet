using System;
using System.Windows.Forms.Integration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Numerics;
using System.Windows.Media.Media3D;




namespace FlexDlgUserCtrl
{

    public partial class FlexDlgUserControl1 : UserControl
    {
      
        private void DefineModel(Model3DGroup group)
        {

            // Add the selected surface.
            HashSet<Edge> edges = new HashSet<Edge>();
            MeshGeometry3D mesh1 = new MeshGeometry3D();
            MeshGeometry3D mesh1a = new MeshGeometry3D();
            double pi = Math.PI;
            
            mesh1.AddSurface(Quadratic, -3, 3, 20, -3, 3, 20, true);
            mesh1a.AddSurface(Quadratic, -3, 3, 20, -3, 3, 20, false, edges, 0.02);
            
            GeometryModel3D model = new GeometryModel3D(mesh1, null);
//            if (frontfacesCheckBox.IsChecked.Value)
                model.Material = new DiffuseMaterial(Brushes.LightBlue);
//            if (backfacesCheckBox.IsChecked.Value)
                model.BackMaterial = new DiffuseMaterial(Brushes.Gray);
            ModelGroup.Children.Add(model);
            

//            if (wireframeCheckBox.IsChecked.Value)
                ModelGroup.Children.Add(mesh1a.MakeModel(Brushes.Blue));
            
            
        }

        
        
    }
}
