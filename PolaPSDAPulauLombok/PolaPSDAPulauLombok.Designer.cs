namespace PolaPSDAPulauLombok
{
    partial class PolaPSDAPulauLombok
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolaPSDAPulauLombok));
            kryptonRibbon1 = new Krypton.Ribbon.KryptonRibbon();
            kryptonRibbonTab1 = new Krypton.Ribbon.KryptonRibbonTab();
            kryptonRibbonTab2 = new Krypton.Ribbon.KryptonRibbonTab();
            kryptonRibbonGroup1 = new Krypton.Ribbon.KryptonRibbonGroup();
            ((System.ComponentModel.ISupportInitialize)kryptonRibbon1).BeginInit();
            SuspendLayout();
            // 
            // kryptonRibbon1
            // 
            kryptonRibbon1.InDesignHelperMode = true;
            kryptonRibbon1.Name = "kryptonRibbon1";
            kryptonRibbon1.RibbonTabs.AddRange(new Krypton.Ribbon.KryptonRibbonTab[] { kryptonRibbonTab1, kryptonRibbonTab2 });
            kryptonRibbon1.SelectedTab = kryptonRibbonTab1;
            kryptonRibbon1.Size = new Size(503, 143);
            kryptonRibbon1.TabIndex = 0;
            kryptonRibbon1.SelectedTabChanged += kryptonRibbon1_SelectedTabChanged;
            // 
            // kryptonRibbonTab1
            // 
            kryptonRibbonTab1.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] { kryptonRibbonGroup1 });
            // 
            // kryptonRibbonGroup1
            // 
            kryptonRibbonGroup1.Image = (Image)resources.GetObject("kryptonRibbonGroup1.Image");
            // 
            // PolaPSDAPulauLombok
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 338);
            Controls.Add(kryptonRibbon1);
            Name = "PolaPSDAPulauLombok";
            Text = "Pola PSDA Pulau Lombok";
            ((System.ComponentModel.ISupportInitialize)kryptonRibbon1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab2;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
    }
}