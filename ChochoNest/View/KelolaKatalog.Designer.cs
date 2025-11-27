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
            btn_TambahProduk.Location = new Point(967, 82);
            btn_TambahProduk.Margin = new Padding(3, 2, 3, 2);
            btn_TambahProduk.Name = "btn_TambahProduk";
            btn_TambahProduk.Size = new Size(130, 22);
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
            panelProduk.Location = new Point(280, 82);
            panelProduk.Margin = new Padding(3, 2, 3, 2);
            panelProduk.Name = "panelProduk";
            panelProduk.Size = new Size(829, 401);
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
            panel1.Location = new Point(3, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 178);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.Red;
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(230, 130);
            btnHapus.Margin = new Padding(3, 2, 3, 2);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(82, 22);
            btnHapus.TabIndex = 5;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(117, 130);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(82, 22);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Location = new Point(117, 96);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(71, 15);
            lblStok.TabIndex = 3;
            lblStok.Text = "Stok Produk";
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Location = new Point(117, 65);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(81, 15);
            lblHarga.TabIndex = 2;
            lblHarga.Text = "Rp. 50.000.000";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(113, 36);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(80, 15);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama Produk";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 46);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(94, 65);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btn_Dashborad
            // 
            btn_Dashborad.Location = new Point(61, 134);
            btn_Dashborad.Margin = new Padding(3, 2, 3, 2);
            btn_Dashborad.Name = "btn_Dashborad";
            btn_Dashborad.Size = new Size(82, 22);
            btn_Dashborad.TabIndex = 3;
            btn_Dashborad.Text = "Dashboard";
            btn_Dashborad.UseVisualStyleBackColor = true;
            // 
            // KelolaKatalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Dashboard_admin;
            ClientSize = new Size(1120, 540);
            Controls.Add(btn_Dashborad);
            Controls.Add(panelProduk);
            Controls.Add(btn_TambahProduk);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
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