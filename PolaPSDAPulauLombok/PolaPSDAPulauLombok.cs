using DotSpatial.Data;
using DotSpatial.Symbology;
using Krypton.Ribbon;
using Krypton.Toolkit;
using PolaPSDAPulauLombok.Properties;
using System.Security.Policy;
using static DotSpatial.Data.AttributeCache;
using System.IO;
using System.Data;
using DotSpatial.Controls;

namespace PolaPSDAPulauLombok
{

    public partial class PolaPSDAPulauLombok : Form
    {

        string activeLayer;
        MapPolygonLayer stateLayer = default(MapPolygonLayer);

        public PolaPSDAPulauLombok()


        {
            String projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            String resourcesPath = projectPath + "\\resources";
            String database = resourcesPath + "\\database";
            String spatial = database + "\\Spatial";
           


            InitializeComponent();
            IMapLayer batasAdmin = map1.Layers.Add(spatial + "\\Administrasi\\administrasi.shp");
            IMapLayer geologi = map1.AddLayer(spatial + "\\geologi\\geologi.shp");
            activeLayer = geologi.DataSet.Name;
            int i = 0;
            while (i < map1.Layers.Count)
            {
                cmbAttributeTable.Items.Insert(i, map1.Layers[i].DataSet.Name);
                i++;
             }


            //Declare a datatable
            System.Data.DataTable dt = null;
       
            stateLayer = (MapPolygonLayer)map1.Layers[1];
            dt = stateLayer.DataSet.DataTable;
            //Set the datagridview datasource from datatable dt
            dataGridView1.DataSource = dt;

            /*  if (map1.Layers.Count > 0)
              {
                  MapPolygonLayer stateLayer = default(MapPolygonLayer);
                  stateLayer = (MapPolygonLayer)map1.Layers[1];
                  if (stateLayer == null)
                  {
                      MessageBox.Show("The layer is not a polygon layer.");
                  }
                  else
                  {
                      //Get the shapefile's attribute table to our datatable dt
                      dt = stateLayer.DataSet.DataTable;
                      //Set the datagridview datasource from datatable dt
                      dataGridView1.DataSource = dt;
                  }
              */
        }

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void map1_Load(object sender, EventArgs e)
        {

        }

        private void PolaPSDAPulauLombok_Load(object sender, EventArgs e)
        {

        }

        private void kryptonRibbon1_SelectedTabChanged_1(object sender, EventArgs e)
        {
        }

        private void map1_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataTable table = selectedLayer.Dataset.Datatable;

        }

        private void cmbAttributeTable_SelectedIndexChanged(object sender, EventArgs e)
        {
           stateLayer = (MapPolygonLayer)map1.Layers[cmbAttributeTable.SelectedIndex];
            DataTable dt = null;
            dt = stateLayer.DataSet.DataTable;
            dataGridView1.DataSource = dt;
        }
    }
}