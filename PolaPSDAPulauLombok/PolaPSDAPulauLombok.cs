using DotSpatial.Data;
using DotSpatial.Symbology;
using Krypton.Ribbon;
using Krypton.Toolkit;
using PolaPSDAPulauLombok.Properties;
using System.Security.Policy;
using static DotSpatial.Data.AttributeCache;
using System.IO;
using System.Data;

namespace PolaPSDAPulauLombok
{

    public partial class PolaPSDAPulauLombok : Form
    {



        public PolaPSDAPulauLombok()


        {
            String projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            String resourcesPath = projectPath + "\\resources";
            String database = resourcesPath + "\\database";
            String spatial = database + "\\Spatial";
            //  MessageBox.Show(resourcesPath);
            InitializeComponent();
            ILayer batasAdmin = map1.AddLayer(spatial + "\\Administrasi\\pulau_lombok.shp");
            ILayer geologi = map1.AddLayer(spatial + "\\geologi\\pulau_lombok.shp");
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
    }
}