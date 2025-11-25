namespace ChochoNest.View
{
    partial class KelolaKatalog
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
            btn_TambahProduk = new Button();
            panelProduk = new FlowLayoutPanel();
            panel1 = new Panel();
            btnHapus = new Button();
            btnEdit = new Button();
            lblStok = new Label();
            lblHarga = new Label();
            lblNama = new Label();
            pictureBox1 = new PictureBox();
            btn_Dashborad = new Button();
            panelProduk.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_TambahProduk
            // 
            btn_TambahProduk.Location = new Point(1105, 109);
            btn_TambahProduk.Name = "btn_TambahProduk";
            btn_TambahProduk.Size = new Size(148, 29);
            btn_TambahProduk.TabIndex = 1;
            btn_TambahProduk.Text = "Tambah Produk";
            btn_TambahProduk.UseVisualStyleBackColor = true;
            btn_TambahProduk.Click += btn_TambahProduk_Click;
            // 
            // panelProduk
            // 
            panelProduk.AutoScroll = true;
            panelProduk.BackColor = Color.Transparent;
            panelProduk.Controls.Add(panel1);
            panelProduk.Location = new Point(279, 161);
            panelProduk.Name = "panelProduk";
            panelProduk.Size = new Size(989, 482);
            panelProduk.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Rectangle_20151;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(btnHapus);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(lblStok);
            panel1.Controls.Add(lblHarga);
            panel1.Controls.Add(lblNama);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(392, 249);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.Red;
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(263, 174);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(94, 29);
            btnHapus.TabIndex = 5;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(134, 174);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Location = new Point(134, 128);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(88, 20);
            lblStok.TabIndex = 3;
            lblStok.Text = "Stok Produk";
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Location = new Point(134, 87);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(104, 20);
            lblHarga.TabIndex = 2;
            lblHarga.Text = "Rp. 50.000.000";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(129, 48);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(99, 20);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama Produk";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 87);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btn_Dashborad
            // 
            btn_Dashborad.Location = new Point(70, 178);
            btn_Dashborad.Name = "btn_Dashborad";
            btn_Dashborad.Size = new Size(94, 29);
            btn_Dashborad.TabIndex = 3;
            btn_Dashborad.Text = "Dashboard";
            btn_Dashborad.UseVisualStyleBackColor = true;
            // 
            // KelolaKatalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Dashboard_admin;
            ClientSize = new Size(1280, 720);
            Controls.Add(btn_Dashborad);
            Controls.Add(panelProduk);
            Controls.Add(btn_TambahProduk);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KelolaKatalog";
            Text = "KelolaKatalog";
            Load += KelolaKatalog_Load;
            panelProduk.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_TambahProduk;
        private FlowLayoutPanel panelProduk;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblStok;
        private Label lblHarga;
        private Label lblNama;
        private Button btnEdit;
        private Button btnHapus;
        private Button btn_Dashborad;
    }
}