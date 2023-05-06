
namespace PolaPSDAPulauLombokMW
{
    partial class PopUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtFoto = new System.Windows.Forms.TextBox();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.txtDebitAir = new System.Windows.Forms.TextBox();
            this.txtMataAir = new System.Windows.Forms.TextBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblCAT = new System.Windows.Forms.Label();
            this.lblLokasi = new System.Windows.Forms.Label();
            this.lblNamaKantor = new System.Windows.Forms.Label();
            this.lblKode = new System.Windows.Forms.Label();
            this.lblInformasi = new System.Windows.Forms.Label();
            this.cboCAT = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(51, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 196);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(329, 463);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(72, 21);
            this.cmdCancel.TabIndex = 62;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(228, 463);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(2);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(69, 21);
            this.cmdEdit.TabIndex = 61;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(142, 464);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(2);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(64, 21);
            this.cmdDelete.TabIndex = 60;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(329, 390);
            this.cmdBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(72, 21);
            this.cmdBrowse.TabIndex = 59;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtFoto
            // 
            this.txtFoto.Location = new System.Drawing.Point(130, 392);
            this.txtFoto.Margin = new System.Windows.Forms.Padding(2);
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.Size = new System.Drawing.Size(195, 20);
            this.txtFoto.TabIndex = 57;
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(130, 356);
            this.txtLokasi.Margin = new System.Windows.Forms.Padding(2);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(271, 20);
            this.txtLokasi.TabIndex = 56;
            // 
            // txtDebitAir
            // 
            this.txtDebitAir.Location = new System.Drawing.Point(130, 285);
            this.txtDebitAir.Margin = new System.Windows.Forms.Padding(2);
            this.txtDebitAir.Name = "txtDebitAir";
            this.txtDebitAir.Size = new System.Drawing.Size(271, 20);
            this.txtDebitAir.TabIndex = 55;
            // 
            // txtMataAir
            // 
            this.txtMataAir.Location = new System.Drawing.Point(130, 250);
            this.txtMataAir.Margin = new System.Windows.Forms.Padding(2);
            this.txtMataAir.Name = "txtMataAir";
            this.txtMataAir.Size = new System.Drawing.Size(271, 20);
            this.txtMataAir.TabIndex = 54;
            this.txtMataAir.TextChanged += new System.EventHandler(this.txtMataAir_TextChanged);
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(48, 394);
            this.lblFoto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(28, 13);
            this.lblFoto.TabIndex = 49;
            this.lblFoto.Text = "Foto";
            // 
            // lblCAT
            // 
            this.lblCAT.AutoSize = true;
            this.lblCAT.Location = new System.Drawing.Point(48, 325);
            this.lblCAT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCAT.Name = "lblCAT";
            this.lblCAT.Size = new System.Drawing.Size(28, 13);
            this.lblCAT.TabIndex = 48;
            this.lblCAT.Text = "CAT";
            // 
            // lblLokasi
            // 
            this.lblLokasi.AutoSize = true;
            this.lblLokasi.Location = new System.Drawing.Point(48, 356);
            this.lblLokasi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLokasi.Name = "lblLokasi";
            this.lblLokasi.Size = new System.Drawing.Size(38, 13);
            this.lblLokasi.TabIndex = 47;
            this.lblLokasi.Text = "Lokasi";
            // 
            // lblNamaKantor
            // 
            this.lblNamaKantor.AutoSize = true;
            this.lblNamaKantor.Location = new System.Drawing.Point(48, 253);
            this.lblNamaKantor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNamaKantor.Name = "lblNamaKantor";
            this.lblNamaKantor.Size = new System.Drawing.Size(77, 13);
            this.lblNamaKantor.TabIndex = 46;
            this.lblNamaKantor.Text = "Nama Mata Air";
            // 
            // lblKode
            // 
            this.lblKode.AutoSize = true;
            this.lblKode.Location = new System.Drawing.Point(48, 288);
            this.lblKode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(47, 13);
            this.lblKode.TabIndex = 45;
            this.lblKode.Text = "Debit Air";
            // 
            // lblInformasi
            // 
            this.lblInformasi.AutoSize = true;
            this.lblInformasi.Location = new System.Drawing.Point(180, 9);
            this.lblInformasi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInformasi.Name = "lblInformasi";
            this.lblInformasi.Size = new System.Drawing.Size(66, 13);
            this.lblInformasi.TabIndex = 44;
            this.lblInformasi.Text = "INFORMASI";
            // 
            // cboCAT
            // 
            this.cboCAT.FormattingEnabled = true;
            this.cboCAT.Items.AddRange(new object[] {
            "CAT MATARAM-SELONG",
            "CAT TANJUNG-SAMBELIA",
            "NON CAT"});
            this.cboCAT.Location = new System.Drawing.Point(130, 322);
            this.cboCAT.Margin = new System.Windows.Forms.Padding(2);
            this.cboCAT.Name = "cboCAT";
            this.cboCAT.Size = new System.Drawing.Size(271, 21);
            this.cboCAT.TabIndex = 64;
            this.cboCAT.SelectedIndexChanged += new System.EventHandler(this.cboCAT_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(51, 463);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 21);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 513);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboCAT);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtFoto);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.txtDebitAir);
            this.Controls.Add(this.txtMataAir);
            this.Controls.Add(this.lblFoto);
            this.Controls.Add(this.lblCAT);
            this.Controls.Add(this.lblLokasi);
            this.Controls.Add(this.lblNamaKantor);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.lblInformasi);
            this.Name = "PopUpForm";
            this.Text = "Informasi Mata Air";
            this.Load += new System.EventHandler(this.FormPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdEdit;
        internal System.Windows.Forms.Button cmdDelete;
        internal System.Windows.Forms.Button cmdBrowse;
        internal System.Windows.Forms.TextBox txtFoto;
        internal System.Windows.Forms.TextBox txtLokasi;
        internal System.Windows.Forms.TextBox txtDebitAir;
        internal System.Windows.Forms.TextBox txtMataAir;
        internal System.Windows.Forms.Label lblFoto;
        internal System.Windows.Forms.Label lblCAT;
        internal System.Windows.Forms.Label lblLokasi;
        internal System.Windows.Forms.Label lblNamaKantor;
        internal System.Windows.Forms.Label lblKode;
        internal System.Windows.Forms.Label lblInformasi;
        private System.Windows.Forms.ComboBox cboCAT;
        internal System.Windows.Forms.Button btnSave;
    }
}