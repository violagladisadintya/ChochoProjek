namespace ChochoNest.View
{
    partial class Keranjang
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnProsesTransaksi = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(96, 66);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 100);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnProsesTransaksi
            // 
            btnProsesTransaksi.Location = new Point(477, 226);
            btnProsesTransaksi.Name = "btnProsesTransaksi";
            btnProsesTransaksi.Size = new Size(75, 23);
            btnProsesTransaksi.TabIndex = 1;
            btnProsesTransaksi.Text = "button1";
            btnProsesTransaksi.UseVisualStyleBackColor = true;
            btnProsesTransaksi.Click += button1_Click;
            // 
            // Keranjang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProsesTransaksi);
            Controls.Add(flowLayoutPanel1);
            Name = "Keranjang";
            Text = "Keranjang";
            Load += Keranjang_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnProsesTransaksi;
    }
}