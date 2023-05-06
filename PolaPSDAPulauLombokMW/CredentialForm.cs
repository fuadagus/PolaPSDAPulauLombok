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
    public delegate void MyEventHandler(bool isEditMOde);

    public partial class CredentialForm : Form
    {
        public CredentialForm()
        {
            InitializeComponent();
        }
        string passWord;
        string credential = "abcd";
        public bool isEditMode = false;
        Form popUpForm = PopUpForm.ActiveForm;



        // Define the event that the receiver form will handle
        public event MyEventHandler MyEvent;

        // Method that raises the event and passes data to the receiver form
        private void SendDataToReceiverForm(bool isEditMode)
        {
            if (MyEvent != null)
            {
                MyEvent(isEditMode);
            }
        }


        private void CredentialForm_Load(object sender, EventArgs e)
        {



        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (credential == txtPW.Text)
            {
                SendDataToReceiverForm(true);
                this.Close();
            }
            else
            {
                lblPWMessage.Text = "Password yang anda masukkan salah";
            }
        }
    }
    
    
}
