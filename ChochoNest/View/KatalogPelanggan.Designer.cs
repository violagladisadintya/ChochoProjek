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
            RiwayatTransaksiPelBTN = new Button();
            KeranjangBTN = new Button();
            SuspendLayout();
            // 
            // RiwayatTransaksiPelBTN
            // 
            RiwayatTransaksiPelBTN.BackColor = Color.Transparent;
            RiwayatTransaksiPelBTN.Location = new Point(73, 204);
            RiwayatTransaksiPelBTN.Name = "RiwayatTransaksiPelBTN";
            RiwayatTransaksiPelBTN.Size = new Size(144, 29);
            RiwayatTransaksiPelBTN.TabIndex = 0;
            RiwayatTransaksiPelBTN.UseVisualStyleBackColor = false;
            // 
            // KeranjangBTN
            // 
            KeranjangBTN.BackColor = Color.Transparent;
            KeranjangBTN.Location = new Point(1177, 606);
            KeranjangBTN.Name = "KeranjangBTN";
            KeranjangBTN.Size = new Size(75, 63);
            KeranjangBTN.TabIndex = 1;
            KeranjangBTN.UseVisualStyleBackColor = false;
            // 
            // KatalogPelanggan
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(KeranjangBTN);
            Controls.Add(RiwayatTransaksiPelBTN);
            DoubleBuffered = true;
            Name = "KatalogPelanggan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A";
            Load += KatalogPelanggan_Load;
            ResumeLayout(false);

        }

        #endregion

        private Button RiwayatTransaksiPelBTN;
        private Button KeranjangBTN;
    }
}