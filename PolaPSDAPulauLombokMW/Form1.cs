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
        string projection;
        bool visibility;
       
        private void Form1_Load(object sender, EventArgs e)
        {

            MapWinGIS.Map map = (MapWinGIS.Map)axMap1.GetOcx();

            axMap1.Clear();
            
            string appDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string resourcesPath = Path.Combine(appDir, "Resources");
            string spatialPath = Path.Combine(resourcesPath, "database\\Spatial");
            string admSHPPath = Path.Combine(spatialPath, "Administrasi\\administrasi.shp");
            string geoSHPPath = Path.Combine(spatialPath, "Geologi\\geologi.shp");
            string mataAirSHPPath = Path.Combine(spatialPath, "SebaranMataAir\\sebaran_mata_air.shp");
            string sungaiSHPPath = Path.Combine(spatialPath, "Sungai\\sungai.shp");

            axMap1.AddLayer(admSHPPath, true);
            axMap1.ZoomToMaxExtents();
            axMap1.CreateControl();

            MapWinGIS.FileManager fileManager = new MapWinGIS.FileManager();
            // Define an array of shapefile paths
            string[] shapefilePaths = new string[] { admSHPPath, geoSHPPath, sungaiSHPPath, mataAirSHPPath };




            
            // Open the shapefile and create a Shapefile object
            MapWinGIS.Shapefile adminShapefile = fileManager.OpenShapefile(admSHPPath, null);
            MapWinGIS.Shapefile geoShapefile = fileManager.OpenShapefile(geoSHPPath, null);
            MapWinGIS.Shapefile sungaiShapefile = fileManager.OpenShapefile(sungaiSHPPath, null);
            MapWinGIS.Shapefile mataAirShapefile = fileManager.OpenShapefile(mataAirSHPPath, null);



            Table admTable = adminShapefile.Table;
            Table geoTable = geoShapefile.Table;
            Table SungaiTable = sungaiShapefile.Table;


            int admFieldIndex = admTable.FieldIndexByName["NAMOBJ"];
            int geoFieldIndex = geoTable.FieldIndexByName["NAMOBJ"];
            int sungaiFieldIndex = SungaiTable.FieldIndexByName["REMARK"];




           map.AddLayer(sungaiShapefile, true);

            // Check if the shapefile was opened successfully
            if (adminShapefile == null)
                {
                    // Handle the error
                    MessageBox.Show("Maaf data tidak di temukan");
                }

                else
                {

                //ADM Symbolization
                // create visualization categories
                adminShapefile.DefaultDrawingOptions.FillType = tkFillType.ftStandard;
                adminShapefile.Categories.Generate(admFieldIndex, tkClassificationType.ctUniqueValues, 5);
                adminShapefile.Categories.ApplyExpressions();

                // apply color scheme
                var scheme = new ColorScheme();
                scheme.SetColors2(tkMapColor.Red, tkMapColor.LightYellow);
                adminShapefile.Categories.ApplyColorScheme(tkColorSchemeType.ctSchemeRandom, scheme);

                // Add the shapefile to the map control
                map.AddLayer(adminShapefile, true);
                projection = adminShapefile.Projection;

                legend1.Map = map;
                admLayerHandle = legend1.Layers.Add(adminShapefile, true);
                    

                 // Set the layer's Name property to the name of the shapefile
                legend1.GetLayer(admLayerHandle).Name = Path.GetFileNameWithoutExtension(admSHPPath);
                legend1.Refresh();
                map.Redraw();
                }


            map.AddLayer(geoShapefile, true);
            // Check if the shapefile was opened successfully
            if (geoShapefile == null)
            {
                // Handle the error
                MessageBox.Show("Maaf data tidak di temukan");
            }

            else
            {

                //Geo Symbolization
                // create visualization categories
                geoShapefile.DefaultDrawingOptions.FillType = tkFillType.ftStandard;
                geoShapefile.Categories.Generate(geoFieldIndex, tkClassificationType.ctUniqueValues, 10);
                geoShapefile.Categories.ApplyExpressions();

                // apply color scheme
                var scheme2 = new ColorScheme();
                scheme2.SetColors2(tkMapColor.Blue, tkMapColor.Red);
                geoShapefile.Categories.ApplyColorScheme(tkColorSchemeType.ctSchemeRandom, scheme2);
                geoShapefile.Projection = projection;
                // Add the shapefile to the map control
                map.AddLayer(geoShapefile, true);


                legend1.Map = map;
                geoLayerHandle = legend1.Layers.Add(geoShapefile, true);


                // Set the layer's Name property to the name of the shapefile
                legend1.GetLayer(geoLayerHandle).Name = Path.GetFileNameWithoutExtension(geoSHPPath);
                legend1.Refresh();
                map.Redraw();
            }

            map.AddLayer(sungaiShapefile, true);



            // Check if the shapefile was opened successfully

            if (sungaiShapefile == null)
            {
                // Handle the error
                MessageBox.Show("Maaf data tidak di temukan");
            }

            else
            {

                //River Symbolization
                // create visualization categories
                sungaiShapefile.DefaultDrawingOptions.FillType = tkFillType.ftStandard;
                sungaiShapefile.Categories.ApplyExpressions();
                sungaiShapefile.Categories.Generate(sungaiFieldIndex, tkClassificationType.ctUniqueValues, 3);

                // apply color scheme
                var scheme3 = new ColorScheme();
                scheme3.SetColors2(tkMapColor.Blue, tkMapColor.LightBlue);
                sungaiShapefile.Categories.ApplyColorScheme(tkColorSchemeType.ctSchemeGraduated, scheme3);
                map.AddLayer(sungaiShapefile, true);
               
                


                // Add the shapefile to the map control


                legend1.Map = map;
                sungaiLayerHandle = legend1.Layers.Add(sungaiShapefile, true);
                map.AddLayer(sungaiShapefile, true);

                // Set the layer's Name property to the name of the shapefile
                legend1.GetLayer(sungaiLayerHandle).Name = Path.GetFileNameWithoutExtension(sungaiSHPPath);
                sungaiShapefile.Projection = projection;
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

        private void Basemap_OpenStreetMap_CheckedChanged(object sender, EventArgs e)
        {


            TileProviders providers = axMap1.Tiles.Providers;
            int providerId = (int)tkTileProvider.ProviderCustom + 1;    // (1024 + 1) should be unique across application runs in case disk caching is used
            providers.Add(providerId, "Custom TMS provider",
            "https://{s}.tile.openstreetmap.org/{zoom}/{x}/{y}.png",
            tkTileProjection.SphericalMercator, 0, 18);
            axMap1.Tiles.ProviderId = providerId;
           
            axMap1.Tiles.ProviderId = (int)tkTileProvider.OpenStreetMap;
            axMap1.TileProvider = tkTileProvider.ProviderCustom;

            
            
            int index = providers.get_IndexByProviderId(providerId);
            //MessageBox.Show("The recently added custom provider is: " + providers.get_Name(index));

            axMap1.Redraw();

        
            

        }

        private void Basemap_OpenCycleMap_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.OpenCycleMap;
            axMap1.Redraw();
        }

        private void Basemap_OpenTransportMap_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.OpenTransportMap;
            axMap1.Redraw();  
        }

        private void Basemap_BingMaps_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.BingMaps;
            axMap1.Redraw();
        }

        private void Basemap_BingSatellite_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.BingSatellite;
            axMap1.Redraw();
        }

        private void Basemap_BingHybrid_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.BingHybrid;
            axMap1.Redraw();
        }

        private void Basemap_GoogleMaps_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.GoogleMaps;
            axMap1.Redraw();
        }

        private void Basemap_GoogleSatellite_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.GoogleSatellite;
            axMap1.Redraw();
        }

        private void Basemap_GoogleHybrid_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.GoogleHybrid;
            axMap1.Redraw();
        }

        private void Basemap_GoogleTerrain_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.GoogleTerrain;
            axMap1.Redraw();
        }

        private void Basemap_HereMaps_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.HereMaps;
            axMap1.Redraw();
        }

        private void Basemap_MapQuestAerial_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = tkTileProvider.MapQuestAerial;
            axMap1.Redraw();
        }

       
        private void KryptonRibbonGroupButton_NormalMode_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupButton_ZoomInMode_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupButton_ZoomOutMode_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupButton_PanMode_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupButton_ZoomIn_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupButton_ZoomOut_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupButton_FullExtent_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupButton_Preview_Click(object sender, EventArgs e)
        {

        }
    }
}
