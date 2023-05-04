using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinGIS;
using AxMapWinGIS;

using System.IO;

namespace PolaPSDAPulauLombokMW
{

    

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
        }
        int admLayerHandle;
        int geoLayerHandle;
        int sungaiLayerHandle;
        int mataAirLayerHandle;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            axMap1.Clear();
            MapWinGIS.Map map = (MapWinGIS.Map)axMap1.GetOcx();
            string appDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string resourcesPath = Path.Combine(appDir, "Resources");
            string spatialPath = Path.Combine(resourcesPath, "database\\Spatial");
            string admSHPPath = Path.Combine(spatialPath, "Administrasi\\administrasi.shp");
            string geoSHPPath = Path.Combine(spatialPath, "Geologi\\geologi.shp");
            string mataAirSHPPath = Path.Combine(spatialPath, "SebaranMataAir\\sebaran_mata_air.shp");
            string sungaiSHPPath = Path.Combine(spatialPath, "Sungai\\sungai.shp");

            MessageBox.Show(admSHPPath);
            axMap1.AddLayer(admSHPPath, true);
            axMap1.ZoomToMaxExtents();

            MapWinGIS.FileManager fileManager = new MapWinGIS.FileManager();
            // Define an array of shapefile paths
            string[] shapefilePaths = new string[] { admSHPPath, geoSHPPath, sungaiSHPPath, mataAirSHPPath };





            // Open the shapefile and create a Shapefile object
            MapWinGIS.Shapefile adminShapefile = fileManager.OpenShapefile(admSHPPath, null);



            Table table = adminShapefile.Table;

            int fieldIndex = table.FieldIndexByName["NAMOBJ"];

            // create visualization categories
            adminShapefile.DefaultDrawingOptions.FillType = tkFillType.ftStandard;
            adminShapefile.Categories.Generate(fieldIndex, tkClassificationType.ctUniqueValues, 5);
            adminShapefile.Categories.ApplyExpressions();

            // apply color scheme
            var scheme = new ColorScheme();
            scheme.SetColors2(tkMapColor.Red, tkMapColor.LightYellow);
            adminShapefile.Categories.ApplyColorScheme(tkColorSchemeType.ctSchemeRandom, scheme);


            map.AddLayer(adminShapefile, true);
            // Check if the shapefile was opened successfully
            if (adminShapefile == null)
                {
                    // Handle the error
                    MessageBox.Show("Maaf data tidak di temukan");
                }

                else
                {
                    // Add the shapefile to the map control
                    map.AddLayer(adminShapefile, true);

                    
                    legend1.Map = map;
                    admLayerHandle = legend1.Layers.Add(adminShapefile, true);
                    

                    // Set the layer's Name property to the name of the shapefile
                    legend1.GetLayer(admLayerHandle).Name = Path.GetFileNameWithoutExtension(admSHPPath);
                    legend1.Refresh();
                    map.Redraw();
                }

                


            

            

          


        }



        private void KryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }

        private void legend1_VisibleChanged(object sender, EventArgs e)
        {
           
        }
    }
}
