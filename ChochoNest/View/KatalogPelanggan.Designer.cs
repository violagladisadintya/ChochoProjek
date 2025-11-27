namespace ChochoNest.View
{
    partial class KatalogPelanggan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KatalogPelanggan));
            RiwayatTransaksiBTN = new Button();
            KeranjangBTN = new Button();
            SuspendLayout();
            // 
            // RiwayatTransaksiBTN
            // 
            RiwayatTransaksiBTN.BackColor = Color.Transparent;
            RiwayatTransaksiBTN.FlatAppearance.BorderSize = 0;
            RiwayatTransaksiBTN.FlatStyle = FlatStyle.Popup;
            RiwayatTransaksiBTN.ForeColor = Color.Transparent;
            RiwayatTransaksiBTN.Location = new Point(70, 205);
            RiwayatTransaksiBTN.Name = "RiwayatTransaksiBTN";
            RiwayatTransaksiBTN.Size = new Size(171, 35);
            RiwayatTransaksiBTN.TabIndex = 0;
            RiwayatTransaksiBTN.UseVisualStyleBackColor = false;
            // 
            // KeranjangBTN
            // 
            KeranjangBTN.BackColor = Color.Transparent;
            KeranjangBTN.FlatAppearance.BorderSize = 0;
            KeranjangBTN.FlatStyle = FlatStyle.Popup;
            KeranjangBTN.Location = new Point(1169, 614);
            KeranjangBTN.Name = "KeranjangBTN";
            KeranjangBTN.Size = new Size(83, 55);
            KeranjangBTN.TabIndex = 1;
            KeranjangBTN.UseVisualStyleBackColor = false;
            // 
            // KatalogPelanggan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(KeranjangBTN);
            Controls.Add(RiwayatTransaksiBTN);
            Name = "KatalogPelanggan";
            Text = "KatalogPelanggan";
            Load += KatalogPelanggan_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button RiwayatTransaksiBTN;
        private Button KeranjangBTN;
    }
}