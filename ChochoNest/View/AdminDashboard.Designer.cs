namespace ChochoNest.View
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            btn_Dashboard = new Button();
            btn_RiwayatTransaksi = new Button();
            btn_KelolaKatalog = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btn_Dashboard
            // 
            btn_Dashboard.Location = new Point(93, 172);
            btn_Dashboard.Name = "btn_Dashboard";
            btn_Dashboard.Size = new Size(94, 29);
            btn_Dashboard.TabIndex = 0;
            btn_Dashboard.Text = "Dashboard";
            btn_Dashboard.UseVisualStyleBackColor = true;
            btn_Dashboard.Click += btn_Dashboard_Click;
            // 
            // btn_RiwayatTransaksi
            // 
            btn_RiwayatTransaksi.BackColor = Color.Transparent;
            btn_RiwayatTransaksi.Location = new Point(63, 293);
            btn_RiwayatTransaksi.Name = "btn_RiwayatTransaksi";
            btn_RiwayatTransaksi.Size = new Size(160, 29);
            btn_RiwayatTransaksi.TabIndex = 2;
            btn_RiwayatTransaksi.Text = "Riwayat Transaksi";
            btn_RiwayatTransaksi.UseVisualStyleBackColor = false;
            btn_RiwayatTransaksi.Click += btn_RiwayatTransaksi_Click;
            // 
            // btn_KelolaKatalog
            // 
            btn_KelolaKatalog.Location = new Point(63, 233);
            btn_KelolaKatalog.Name = "btn_KelolaKatalog";
            btn_KelolaKatalog.Size = new Size(181, 29);
            btn_KelolaKatalog.TabIndex = 3;
            btn_KelolaKatalog.Text = "Pengelolaan Katalog";
            btn_KelolaKatalog.UseVisualStyleBackColor = true;
            btn_KelolaKatalog.Click += btn_KelolaKatalog_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(331, 145);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(903, 342);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1280, 720);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btn_KelolaKatalog);
            Controls.Add(btn_RiwayatTransaksi);
            Controls.Add(btn_Dashboard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminDashboard";
            Text = "AdminKatalog";
            Load += AdminDashboard_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Dashboard;
        private Button btn_RiwayatTransaksi;
        private Button btn_KelolaKatalog;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}