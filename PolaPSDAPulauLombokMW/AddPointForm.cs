using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD

=======
using MapWinGIS;
using AxMapWinGIS;
>>>>>>> de7ee50 (add project)
namespace PolaPSDAPulauLombokMW
{
    
    public partial class AddPointForm : Form
    {
        private double _x;
        private double _y;
<<<<<<< HEAD
        public AddPointForm(double x, double y)
        {
            InitializeComponent();
=======
        MainForm mainFormObject;
        public AddPointForm(MainForm mainFormInitialized, double x, double y)
        {
            InitializeComponent();
            mainFormObject = mainFormInitialized;
>>>>>>> de7ee50 (add project)
            _x = x;
            _y = y;

            
        }

        public delegate void SavePointEventHandler();
        public event SavePointEventHandler SavePoint;


        private void AddPointForm_Load(object sender, EventArgs e)
        {
            txtTitik_X.Text = _x.ToString();
            txtTitik_Y.Text = _y.ToString();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            // create an open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.Title = "Select an image file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // get the selected file path
                 string filePath = openFileDialog.FileName;

                // create a new image object from the file
                System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);

                // display the image in a picture box
                pictureBox1.Image = image;
               
                
                // save the image to a local file in your application

            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
           

            SavePoint?.Invoke();
<<<<<<< HEAD
=======
            CreatePointShapefile(mainFormObject.axMap1, _x, _y);
            mainFormObject.axMap1.Redraw();
            mainFormObject.axMap1.Refresh();


        }

        public void CreatePointShapefile(AxMap axMap1, double X, double Y)
        {
            //axMap1.Projection = tkMapProjection.PROJECTION_NONE;

            var sf = new Shapefile();

            // MWShapeId field will be added to attribute table
            bool result = sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT);

            MessageBox.Show("X:" + X.ToString());
            MessageBox.Show("Y:" + Y.ToString());
            // creating points and inserting them in the shape

            var pnt = new MapWinGIS.Point();
                pnt.x = X;
                pnt.y = Y;

                Shape shp = new Shape();
                shp.Create(ShpfileType.SHP_POINT);

                int index = 0;
                shp.InsertPoint(pnt, ref index);
            mainFormObject.mataAirShapefile.StartEditingShapes();
            mainFormObject.mataAirShapefile.StartEditingTable();
            int i = mainFormObject.mataAirShapefile.NumShapes + 1;
            mainFormObject.mataAirShapefile.EditInsertShape(shp, ref i);


            sf.DefaultDrawingOptions.SetDefaultPointSymbol(tkDefaultPointSymbol.dpsStar);

            // adds shapefile to the map
            //axMap1.AddLayer(sf, true);
            
            // save if needed
            //sf.SaveAs(@"c:\points.shp", null);

>>>>>>> de7ee50 (add project)
        }
    }
}
