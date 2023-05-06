using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolaPSDAPulauLombokMW
{
    
    public partial class AddPointForm : Form
    {
        private double _x;
        private double _y;
        public AddPointForm(double x, double y)
        {
            InitializeComponent();
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
        }
    }
}
