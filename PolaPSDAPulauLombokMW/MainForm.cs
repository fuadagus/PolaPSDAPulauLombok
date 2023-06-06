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
using Krypton.Ribbon;
using System.IO;
using System.Text.RegularExpressions;

namespace PolaPSDAPulauLombokMW
{

    

    public partial class MainForm : Form
    {
        private const int CATEGORY_SELECTED = 0;
        private const int CATEGORY_HIDDEN = -1;


        public MainForm()
        {
            InitializeComponent();
<<<<<<< HEAD
            
=======
>>>>>>> de7ee50 (add project)
        }
        int admLayerHandle;
        int geoLayerHandle;
        int sungaiLayerHandle;
        public int mataAirLayerHandle;
        int layerSelected = -1;
        string projection;
        bool visibility;
        public MapWinGIS.Shapefile adminShapefile;
        public MapWinGIS.Shapefile geoShapefile;
        public MapWinGIS.Shapefile sungaiShapefile;
        public MapWinGIS.Shapefile mataAirShapefile;
        PopUpForm formPopUp;
        public int shapeIdentifiedIndex;
        public string appDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public int selectedFID;
<<<<<<< HEAD
=======
        string spatialPath;
>>>>>>> de7ee50 (add project)
        private void SetAllButtonsChecked(KryptonRibbon ribbon, bool isChecked)

        {
            // Iterate through all the tabs in the ribbon and call SetButtonsChecked for each one
            foreach (KryptonRibbonTab tab in ribbon.RibbonTabs)
            {
                SetButtonsChecked(tab, isChecked);
            }
        }
        Table admTable;
        Table geoTable;
        Table SungaiTable;
        Table mataAirTable;

        Table selectedTable;
        Shapefile selectedShapefile;
        string selectedColumn;
        public void changeAttributeToShow(int layerSelected)
        {
            Table table = mataAirTable;
            switch (layerSelected)
            {
                case 0:
                    table = admTable;
                    break;
                case 1:
                    table = geoTable;
                    break;
                case 2:
                    table = SungaiTable;
                    break;
                case 3:
                    table = mataAirTable;
                    break;

            }
            if (table != null)
            {
                for (int i = 0; i < table.NumFields; i++)
                {
                    dataGridView1.Columns.Add(table.Field[i].Name, table.Field[i].Name);
                }

                for (int i = 0; i < table.NumRows - 1; i++)
                {
                    string[] attributeValue = new string[table.NumFields];
                    for (int j = 0; j < table.NumFields; j++)
                    {
                        attributeValue[j] = table.CellValue[j, i].ToString();
                    }

                    dataGridView1.Rows.Insert(i, attributeValue);
                    var hScrollBar = dataGridView1.GetType().GetField("horizontalScrollBar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(dataGridView1) as ScrollBar;
                    if (hScrollBar != null)
                    {
                        hScrollBar.Visible = true;
                    }





                }


            }
        }

        private void SetButtonsChecked(KryptonRibbonTab tab, bool isChecked)
        {
            // Iterate through all the buttons in the tab and set their Checked property
            foreach (KryptonRibbonGroup group in tab.Groups)
            {
              
                foreach (KryptonRibbonGroupItem triple in group.Items)
                {

                  
                    if(triple is KryptonRibbonGroupTriple) {

                        foreach (KryptonRibbonGroupItem item in (triple as KryptonRibbonGroupTriple).Items)
                        if (item is KryptonRibbonGroupButton button)
                        {
                               
                            button.Checked = isChecked;
                        }
                    }
                    
                }
            }
        }


     

        private void labelConfigure(_DMapEvents_SelectBoxFinalEvent e)
        {
            Shapefile mataAirShapefile = axMap1.get_Shapefile(mataAirLayerHandle);
            if (mataAirShapefile != null)
            {

                object labels = null;
                object parts = null;

                var ext = new Extents();
                ext.SetBounds(e.left, e.bottom, 0.0, e.right, e.top, 0.0);

                if (mataAirShapefile.Labels.Select(ext, 0, SelectMode.INTERSECTION, ref labels, ref parts))
                {
                    double sum = 0;
                    int[] labelIndices = labels as int[];
                    int[] partIndices = parts as int[];
                    for (int i = 0; i < labelIndices.Count(); i++)
                    {
                        MapWinGIS.Label label = mataAirShapefile.Labels.Label[labelIndices[i], partIndices[i]];
                        if (label.Category == -1)
                        {
                            // selection will be appliedonly to the labels without category, so that hidden

                            //labels preserve their state

                            // Get the shape index associated with the label
                            int shapeIndex = 0;
                            mataAirShapefile.PointInShape(shapeIndex, (int)label.x, label.y);

                            // Select the shape
                            if (shapeIndex >= 0)
                            {
                                
                                mataAirShapefile.ShapeSelected[shapeIndex] = true;


                                int debitFieldIndex = mataAirShapefile.Table.FieldIndexByName["debit"];

                                // Calculate the sum of all debit values

                                for (int j = 0; j < mataAirShapefile.NumShapes; j++)
                                {
                                    // Get the debit value for the current shape
                                    double debit = Convert.ToDouble(mataAirShapefile.Table.CellValue[debitFieldIndex, i]);

                                    // Add the debit value to the sum
                                    sum += debit;



                                }
                                label.Category = CATEGORY_SELECTED;








                                // Refresh the map to show the selected shape
                                axMap1.Redraw();
                            }

                        }
                        kryptonRibbonGroupRichTextBox_AnlResult.Text = sum.ToString() + " L/Detik";
                    }
                    axMap1.Redraw();
                    int dbtFieldIndex = mataAirShapefile.FieldIndexByName["debit"];
                    //kryptonRibbonGroupRichTextBox_AnlResult.Text = mataAirShapefile.CellValue[dbtFieldIndex,mataAirShapefile.Shap]

                }
            }
        }


        private void addLabelCategory()
        {
            // now let's add categories

            Utils utils = new Utils();  // to specify colors

            LabelCategory ct = mataAirShapefile.Labels.AddCategory("Selected");
            ct.FrameBackColor = utils.ColorByName(tkMapColor.Yellow);

            ct = mataAirShapefile.Labels.AddCategory("Hidden");
            ct.Visible = false;
        }

        public void RefreshMap()
        {
            
            axMap1.Redraw();
            axMap1.Redraw2(tkRedrawType.RedrawAll);
            axMap1.Redraw2(tkRedrawType.RedrawSkipDataLayers);
            axMap1.Refresh();
          
            legend1.RedrawLegendAndMap();
            legend1.Refresh();
            Refresh();
            axMap1.Redraw();
        }

<<<<<<< HEAD
=======

        public void minimalDistance(AxMap axMap1, string dataPath, ToolStripStatusLabel label)
        {
            axMap1.Projection = tkMapProjection.PROJECTION_NONE;
            axMap1.GrabProjectionFromData = true;

            string filename1 = dataPath + "Sungai\\Sungai.shp";
            string filename2 = dataPath + "Sungai\\Bangunan.shp";

            if (!File.Exists(filename1) || !File.Exists(filename2))
            {
                MessageBox.Show("The necessary files (waterways.shp, building.shp) are missing: " + dataPath);
            }
            else
            {
                Shapefile sfRivers = new Shapefile();
                sfRivers.Open(filename1, null);

                Utils utils = new Utils();
                sfRivers.DefaultDrawingOptions.LineColor = utils.ColorByName(tkMapColor.Blue);
                sfRivers.DefaultDrawingOptions.LineWidth = 5.0f;

                Shapefile sfBuildings = new Shapefile();
                sfBuildings.Open(filename2, null);

                // adds a field in the table
                Field field = new Field();
                field.Name = "RiverDist";
                field.Type = FieldType.DOUBLE_FIELD;
                field.Precision = 10;

                int fieldIndex = sfBuildings.NumFields;
                sfBuildings.StartEditingShapes(true, null);
                sfBuildings.EditInsertField(field, ref fieldIndex, null);

                ShapefileCategory ct = sfBuildings.Categories.Add("Named buildings");
                ct.Expression = "[Name] <> \"\"";
                sfBuildings.Categories.ApplyExpressions();

                sfRivers.StartEditingShapes(false, null);
                for (int i = 0; i < sfBuildings.NumShapes; i++)
                {
                    if (sfBuildings.ShapeCategory[i] == 0)
                    {
                        label.Text = "Processing building: " + (i + 1) + " / " + sfBuildings.NumShapes;
                        Application.DoEvents();

                        Shape shp = sfBuildings.Shape[i];
                        double minDist = Double.MaxValue;

                        for (int j = 0; j < sfRivers.NumShapes; j++)
                        {
                            Shape shp2 = sfRivers.Shape[j];
                            double distance = shp.Distance(shp2);
                            if (distance < minDist)
                                minDist = distance;
                        }

                        if (minDist != Double.MaxValue)
                            sfBuildings.EditCellValue(fieldIndex, i, minDist);
                    }
                    else
                    {
                        sfBuildings.EditCellValue(fieldIndex, i, 0.0);
                    }
                }
                sfRivers.StopEditingShapes(false, true, null);

                sfBuildings.Categories.Generate(fieldIndex, tkClassificationType.ctNaturalBreaks, 8);
                ColorScheme scheme = new ColorScheme();
                scheme.SetColors2(tkMapColor.Blue, tkMapColor.Yellow);
                sfBuildings.Categories.ApplyColorScheme(tkColorSchemeType.ctSchemeGraduated, scheme);

                sfBuildings.Labels.Generate("[Name] + \"\n\" + [RiverDist] + \" m\"", tkLabelPositioning.lpCentroid, true);
                sfBuildings.Labels.TextRenderingHint = tkTextRenderingHint.SystemDefault;

                sfBuildings.VisibilityExpression = "[Name] <> \"\"";

                axMap1.AddLayer(sfRivers, true);
                axMap1.AddLayer(sfBuildings, true);

                label.Text = "";
            }
        }

>>>>>>> de7ee50 (add project)
        private void Form1_Load(object sender, EventArgs e)
        {
            axMap1.Clear();
            MapWinGIS.Map map = (MapWinGIS.Map)axMap1.GetOcx();
            map.TileProvider = tkTileProvider.GoogleTerrain;
            map.Redraw();
            layerSelected = 3; 
            
           

            string resourcesPath = Path.Combine(appDir, "Resources");
            string DBPath = Path.Combine(resourcesPath, "database");
<<<<<<< HEAD
            string spatialPath = Path.Combine(resourcesPath, "database\\Spatial");
=======
            spatialPath = Path.Combine(resourcesPath, "database\\Spatial");
>>>>>>> de7ee50 (add project)
            string admSHPPath = Path.Combine(spatialPath, "Administrasi\\administrasi.shp");
            string geoSHPPath = Path.Combine(spatialPath, "Geologi\\geologi.shp");
            string mataAirSHPPath = Path.Combine(spatialPath, "SebaranMataAir\\sebaran_mata_air.shp");
            string sungaiSHPPath = Path.Combine(spatialPath, "Sungai\\sungai.shp");

            
            axMap1.ZoomToMaxExtents();
            axMap1.CreateControl();

            MapWinGIS.FileManager fileManager = new MapWinGIS.FileManager();
            




            
            // Open the shapefile and create a Shapefile object
            adminShapefile = fileManager.OpenShapefile(admSHPPath, null);
            geoShapefile = fileManager.OpenShapefile(geoSHPPath, null);
            sungaiShapefile = fileManager.OpenShapefile(sungaiSHPPath, null);
            mataAirShapefile = fileManager.OpenShapefile(mataAirSHPPath, null);



            admTable = adminShapefile.Table;
            geoTable = geoShapefile.Table;
            SungaiTable = sungaiShapefile.Table;
            mataAirTable = mataAirShapefile.Table;


            int admFieldIndex = admTable.FieldIndexByName["NAMOBJ"];
            int geoFieldIndex = geoTable.FieldIndexByName["NAMOBJ"];
            int sungaiFieldIndex = SungaiTable.FieldIndexByName["REMARK"];
            int mataAirFieldIndex = mataAirTable.FieldIndexByName["nm_dat_das"];
            



            changeAttributeToShow(layerSelected);
            
    


            // Check if the shapefile was opened succesmataAirShapefileully
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

                
                projection = adminShapefile.Projection;

                legend1.Map = map;
                admLayerHandle = legend1.Layers.Add(adminShapefile, true);
                    

                 // Set the layer's Name property to the name of the shapefile
                legend1.GetLayer(admLayerHandle).Name = Path.GetFileNameWithoutExtension(admSHPPath);
                legend1.Refresh();
                map.Redraw();
                }


           
            // Check if the shapefile was opened succesmataAirShapefileully
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
                


                legend1.Map = map;
                geoLayerHandle = legend1.Layers.Add(geoShapefile, true);


                // Set the layer's Name property to the name of the shapefile
                legend1.GetLayer(geoLayerHandle).Name = Path.GetFileNameWithoutExtension(geoSHPPath);
                legend1.Refresh();
                map.Redraw();
            }




            // Check if the shapefile was opened succesmataAirShapefileully

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
              
               
                


                // Add the shapefile to the map control


                legend1.Map = map;
                sungaiLayerHandle = legend1.Layers.Add(sungaiShapefile, true);

                // Set the layer's Name property to the name of the shapefile
                legend1.GetLayer(sungaiLayerHandle).Name = Path.GetFileNameWithoutExtension(sungaiSHPPath);
                sungaiShapefile.Projection = projection;
                legend1.Refresh();
                map.Redraw();
            }


            // Check if the shapefile was opened succesmataAirShapefileully

            if (mataAirShapefile == null)
            {
                // Handle the error
                MessageBox.Show("Maaf data tidak di temukan");
            }

            else
            {

                //mataAir Symbolization
                // create visualization categories
                mataAirShapefile.DefaultDrawingOptions.FillType = tkFillType.ftStandard;
                mataAirShapefile.Categories.ApplyExpressions();
             
                

                // apply color scheme
                var scheme4 = new ColorScheme();
                scheme4.SetColors2(tkMapColor.White, tkMapColor.White);

                for (int i= 0; i <mataAirShapefile.NumFields -1; i++) {
                    
                    mataAirShapefile.Categories.Caption = mataAirShapefile.CellValue[mataAirFieldIndex, i].ToString();
                    axMap1.Redraw();
                   
                }
                
                mataAirShapefile.Categories.ApplyColorScheme(tkColorSchemeType.ctSchemeRandom, scheme4);
               


                // let's add labels consisting of Name and type of building on a separate lines
                mataAirShapefile.Labels.Generate("[nm_dat_das]", tkLabelPositioning.lpCenter, false);
                mataAirShapefile.Labels.FrameVisible = true;
                mataAirShapefile.Labels.FrameType = tkLabelFrameType.lfPointedRectangle;

                addLabelCategory();

                axMap1.SendSelectBoxFinal = true;
                axMap1.SendMouseDown = true;
                
             





                // Add the shapefile to the map control


                legend1.Map = map;
                mataAirLayerHandle = legend1.Layers.Add(mataAirShapefile, true);
                

                // Set the layer's Name property to the name of the shapefile
                legend1.GetLayer(mataAirLayerHandle).Name = Path.GetFileNameWithoutExtension(mataAirSHPPath);
                mataAirShapefile.Projection = projection;
                legend1.Refresh();
                map.Redraw();
            }
            
            for (int i= 0;i < axMap1.NumLayers; i++)
            {
                
                string item = axMap1.get_LayerName(i);
                kryptonRibbonGroupComboBoxQueryLayer1.Items.Insert(i,item);
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
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_NormalMode.Checked = true;
            axMap1.CursorMode = tkCursorMode.cmNone;
        }

        private void KryptonRibbonGroupButton_ZoomInMode_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_ZoomInMode.Checked = true;
            axMap1.CursorMode = tkCursorMode.cmZoomIn;

        }

        private void KryptonRibbonGroupButton_ZoomOutMode_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_ZoomOutMode.Checked = true;
            axMap1.CursorMode = tkCursorMode.cmZoomOut;
        }

        private void KryptonRibbonGroupButton_PanMode_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_PanMode.Checked = true;
            axMap1.CursorMode = tkCursorMode.cmPan;
        }

        private void KryptonRibbonGroupButton_ZoomIn_Click(object sender, EventArgs e)
        {
            axMap1.ZoomIn(10);
        }

        private void KryptonRibbonGroupButton_ZoomOut_Click(object sender, EventArgs e)
        {
            axMap1.ZoomOut(0.5);
        }

        private void KryptonRibbonGroupButton_FullExtent_Click(object sender, EventArgs e)
        {
            axMap1.ZoomToMaxExtents();
        }

        private void KryptonRibbonGroupButton_Preview_Click(object sender, EventArgs e)
        {
            axMap1.ZoomToPrev();
        }

        private void KryptonRibbonGroupButton_Identify_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_Identify.Checked = true;
            axMap1.CursorMode = tkCursorMode.cmIdentify;
        }

        private void KryptonRibbonGroupButton_Length_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_Length.Checked = true;
            axMap1.Measuring.MeasuringType = tkMeasuringType.MeasureDistance;
            axMap1.CursorMode = tkCursorMode.cmMeasure;
            
        }

        private void KryptonRibbonGroupButton_Area_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_Length.Checked = true;
            axMap1.Measuring.MeasuringType = tkMeasuringType.MeasureArea;
            axMap1.CursorMode = tkCursorMode.cmMeasure;
            
        }

        private void kryptonRibbonGroupButton_AddData_Click(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton_RemoveData_Click(object sender, EventArgs e)
        {

        }

        private void KryptonRibbonGroupComboBoxQueryKecamatan_DropDown(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton23_DropDown(object sender, Krypton.Toolkit.ContextMenuArgs e)
        {

        }

        private void legend1_LayerVisibleChanged(int Handle, bool NewState, ref bool Cancel)
        {


        }

        private void legend1_LayerSelected(int Handle)
        {
         
           
           
            dataGridView1.Columns.Clear();
            if (legend1.SelectedLayer == 0)
            {
                
                changeAttributeToShow(0);
                
            }
            else if (legend1.SelectedLayer == 1)
            {
              
                changeAttributeToShow(1);
                
            }
            else if (legend1.SelectedLayer == 2) {
               
                changeAttributeToShow(2);
               
            }
            else
            {
                layerSelected = 3;
                changeAttributeToShow(3
                    );
            }
                
        }

        private void legend1_Load(object sender, EventArgs e)
        {

        }

        private void axMap1_SelectBoxFinal(object sender, _DMapEvents_SelectBoxFinalEvent e)
        {
            labelConfigure(e);
            
        }

        private void kryptonRibbonGroupButton_Vol_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            kryptonRibbonGroupButton_Vol.Checked = true;
            axMap1.CursorMode = tkCursorMode.cmSelection;
        }

        private void axMap1_DblClick(object sender, EventArgs e)
        {
            
<<<<<<< HEAD
=======
            
>>>>>>> de7ee50 (add project)
            if (axMap1.CursorMode == tkCursorMode.cmAddShape)
            {
                MapWinGIS.Shapefile pointShapefile = new MapWinGIS.Shapefile();
                pointShapefile.CreateNew("", MapWinGIS.ShpfileType.SHP_POINT);

                // add a new point to the shapefile
                MapWinGIS.Point point = new MapWinGIS.Point();

                point.x = axMap1.Longitude; // longitude
                point.y = axMap1.Latitude;  // latitude
                MessageBox.Show("posisi: " + point.x + " " + point.y);
                MapWinGIS.Shape shape = new MapWinGIS.Shape();
                shape.InsertPoint(point, 0);
                int pointIndex = pointShapefile.EditAddShape(shape);

                // set the point's attributes (optional)
                pointShapefile.EditCellValue(0, 0, "Point 1");

                // add the point shapefile to the map
                axMap1.AddLayer(pointShapefile, true);
                

<<<<<<< HEAD
                AddPointForm addPointForm = new AddPointForm(axMap1.Longitude, axMap1.Latitude);
=======
                AddPointForm addPointForm = new AddPointForm(this, axMap1.Longitude, axMap1.Latitude);
>>>>>>> de7ee50 (add project)
                addPointForm.SavePoint += AddPointForm_SavePoint;
                addPointForm.Show();
              
                
            }
        }
        private void AddPointForm_SavePoint()
        {
            // Call the RefreshMap method to refresh the map in MainForm
            RefreshMap();
        }

        private void axMap1_ShapeIdentified(object sender, _DMapEvents_ShapeIdentifiedEvent e)
        {
            int layerHandle = e.layerHandle;
            shapeIdentifiedIndex = e.shapeIndex;
            formPopUp = new PopUpForm(this);
            
            formPopUp.Show();
        }

        private void kryptonRibbonGroupButton_Clear_Click(object sender, EventArgs e)
        {
            mataAirShapefile.Labels.ClearCategories();
            addLabelCategory();
            kryptonRibbonGroupRichTextBox_AnlResult.Text = "Sudah direstart, silahkan..";
            axMap1.Redraw();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KryptonRibbonGroupComboBoxQueryLayer(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupComboBoxQueryLayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KryptonRibbonGroupComboBoxQueryFilter.Items.Clear();
            Table table = mataAirTable;
            dataGridView1.Columns.Clear();
            layerSelected = kryptonRibbonGroupComboBoxQueryLayer1.SelectedIndex;
            
            changeAttributeToShow(layerSelected);
            switch (layerSelected)
            {
                case 0:
                    table = admTable;
                    selectedTable = admTable;
                    selectedShapefile = adminShapefile;
                    break;
                case 1:
                    table = geoTable;
                    selectedTable = geoTable;
                    selectedShapefile = geoShapefile;
                    break;
                case 2:
                    table = SungaiTable;
                    selectedTable = SungaiTable;
                    selectedShapefile = sungaiShapefile;
                    break;
                case 3:
                    table = mataAirTable;
                    selectedTable = mataAirTable;
                    selectedShapefile = mataAirShapefile;
                    break;
            }
            for (int i=0; i < table.NumFields; i++)
            {
                KryptonRibbonGroupComboBoxQueryFilter.Items.Insert(i, table.Field[i].Name);
            }

            


        }

        private void KryptonRibbonGroupComboBoxQueryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            KryptonRibbonGroupComboBoxQueryObjek.Items.Clear();

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle = null;
            }

            string columnName = kryptonRibbonGroupComboBoxQueryLayer1.Text;
            int fieldIndex = selectedTable.FieldIndexByName[KryptonRibbonGroupComboBoxQueryFilter.Text];
            int FIDfieldIndex = selectedTable.FieldIndexByName["FID"];
            selectedColumn = dataGridView1.Columns[fieldIndex].Name;
            dataGridView1.Columns[fieldIndex].DefaultCellStyle.BackColor = Color.Aqua;
            int FID;
            
           
            string[] items = new string[selectedTable.NumRows];
            for(int i = 0; i < selectedTable.NumRows; i++)
                {
                FID = Convert.ToInt32((selectedTable.CellValue[FIDfieldIndex, i]));
                items[i] = "FID: " + FID.ToString() + " " + selectedTable.CellValue[fieldIndex, i].ToString();
                }

            string[] uniqueItems = items.Distinct().ToArray();
            for(int i=0; i < uniqueItems.Count(); i++)
            {
                KryptonRibbonGroupComboBoxQueryObjek.Items.Insert(i, uniqueItems[i]);
            }
           
        }

        private void KryptonRibbonGroupComboBoxQueryObjek_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pattern = @"\d+"; // match one or more digits
            Match match = Regex.Match(KryptonRibbonGroupComboBoxQueryObjek.Text, pattern);
            selectedShapefile.SelectNone();
            int FIDfieldIndex = selectedTable.FieldIndexByName["FID"];
            for (int i =0; i<selectedTable.NumRows; i++)
            {
                if (Convert.ToInt32(selectedTable.CellValue[FIDfieldIndex, i]) == int.Parse(match.Value))
                {
                    selectedFID = int.Parse(match.Value);
                    selectedShapefile.ShapeSelected[selectedFID] = true;
                }
            }

            selectedShapefile.SelectionColor = (uint)Color.Blue.ToArgb();
            selectedShapefile.SelectionTransparency = 50;
           
            axMap1.ZoomToSelected(layerSelected);
        }

        private void KryptonRibbonGroupButton_AddPoint_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_AddPoint.Checked = true;
            axMap1.CursorMode = tkCursorMode.cmAddShape;

           
        }

        private void axMap1_MouseDownEvent(object sender, _DMapEvents_MouseDownEvent e)
        {
           
        }
<<<<<<< HEAD
=======

        private void kryptonRibbonGroupButton_WaterConsumtion_Click(object sender, EventArgs e)
        {
            SetAllButtonsChecked(KryptonRibbon1, false);
            KryptonRibbonGroupButton_AddPoint.Checked = true;
            minimalDistance(axMap1, spatialPath, lblXY);
        }
>>>>>>> de7ee50 (add project)
    }
}
