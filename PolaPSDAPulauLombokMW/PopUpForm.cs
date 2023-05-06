using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using AxMapWinGIS;
using System.IO;

using System.Windows.Forms;

namespace PolaPSDAPulauLombokMW
{
    public partial class PopUpForm : Form
    {
        MainForm mainForm;
        public PopUpForm(MainForm mainFormInisialized)
        {
            InitializeComponent();
            mainForm = mainFormInisialized;
        }

        public string strFotoMataAirPath;
        string fileName;
        string targetPath;
        string filePath;
        string passWord;
        public bool isEditMode = false;

        // Event handler method that receives data from the sender form
        private void MyEventHandlerMethod(bool isEditMode)
        {
            changeAccess(isEditMode);
            MessageBox.Show("Silahkan Mengedit");
        }

        // Method that subscribes to the event in the sender form
        private void SubscribeToSenderFormEvent()
        {
            CredentialForm senderForm = (CredentialForm)Form.ActiveForm;
            senderForm.MyEvent += MyEventHandlerMethod;
        }

        public void changeAccess(bool isEditMode)
        {
            txtDebitAir.ReadOnly = !isEditMode;
            txtLokasi.ReadOnly = !isEditMode;
            txtMataAir.ReadOnly = !isEditMode;
            txtLokasi.ReadOnly = !isEditMode;
            cboCAT.Enabled = isEditMode;
            cmdBrowse.Enabled = isEditMode;
            cmdDelete.Enabled = isEditMode;
            btnSave.Enabled = isEditMode;

        }
        private void FormPopUp_Load(object sender, EventArgs e)
        {   
            strFotoMataAirPath = Path.Combine(mainForm.appDir, "Resources\\database\\NonSpatial\\Photo\\MataAir");
            int shapeIdentifiedIndex = mainForm.shapeIdentifiedIndex;
            Shapefile mataAirShape = mainForm.axMap1.get_Shapefile(mainForm.mataAirLayerHandle);
            int fieldIndex = mataAirShape.FieldIndexByName["foto"];
            int fieldIndexNama = mataAirShape.FieldIndexByName["nm_dat_das"];
            int fieldIndexDebit = mataAirShape.FieldIndexByName["debit"];
            int fieldIndexCAT = mataAirShape.FieldIndexByName["cat"];
            int fieldIndexLokasiX = mataAirShape.FieldIndexByName["koord_x"];
            int fieldIndexLokasiY = mataAirShape.FieldIndexByName["koord_y"];
            int fieldIndexLokasiDesa = mataAirShape.FieldIndexByName["kel_desa"];

            string strFotoPath = Path.Combine(strFotoMataAirPath, mataAirShape.CellValue[fieldIndex, shapeIdentifiedIndex].ToString());

            string strNullFotoPath = Path.Combine(strFotoMataAirPath, "NoAnyFoto.jpg");

            string strFoto = mataAirShape.CellValue[fieldIndex, shapeIdentifiedIndex].ToString();
            string strNama = mataAirShape.CellValue[fieldIndexNama, shapeIdentifiedIndex].ToString();
            string strDebit = mataAirShape.CellValue[fieldIndexDebit, shapeIdentifiedIndex].ToString();
            string strCAT = mataAirShape.CellValue[fieldIndexCAT, shapeIdentifiedIndex].ToString();
            string strLokasiX = mataAirShape.CellValue[fieldIndexLokasiX, shapeIdentifiedIndex].ToString();
            string strLokasiY = mataAirShape.CellValue[fieldIndexLokasiY, shapeIdentifiedIndex].ToString();
            string strLokasiDesa = mataAirShape.CellValue[fieldIndexLokasiDesa, shapeIdentifiedIndex].ToString();


            changeAccess(false);

            if (strFoto == null | strFoto == "")
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(strNullFotoPath);
            }
            else {
                pictureBox1.Image = System.Drawing.Image.FromFile(strFotoPath);
            }
            
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            txtMataAir.Text = strNama;
            txtDebitAir.Text = strDebit + " L/detik";
            cboCAT.Text = strCAT;
            txtLokasi.Text = "Desa: " + strLokasiDesa + ","+ " Long: " + strLokasiX + ", Lat: " + strLokasiY;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtMataAir_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboCAT_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                filePath = openFileDialog.FileName;

                // create a new image object from the file
                System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);

                // display the image in a picture box
                pictureBox1.Image = image;

                // save the image to a local file in your application

            }

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtShapeIndex_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fileName = Path.GetFileName(filePath);
            targetPath = strFotoMataAirPath;
            pictureBox1.Image.Save(Path.Combine(targetPath, fileName));
            MessageBox.Show(Path.Combine(targetPath, fileName));
            pictureBox1.Image.Dispose();
            
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            CredentialForm credentialForm = new CredentialForm();
            credentialForm.Show();
            SubscribeToSenderFormEvent();

            
        }
    }
}
