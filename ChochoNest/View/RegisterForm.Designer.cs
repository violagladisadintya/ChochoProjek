namespace ChochoNest.View
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            btnRegis = new Button();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(806, 302);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(125, 27);
            tbUsername.TabIndex = 0;
            tbUsername.TextChanged += tbUsername_TextChanged;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(806, 418);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(125, 27);
            tbPassword.TabIndex = 1;
            tbPassword.TextChanged += tbPassword_TextChanged;
            // 
            // btnRegis
            // 
            btnRegis.Location = new Point(954, 566);
            btnRegis.Name = "btnRegis";
            btnRegis.Size = new Size(94, 29);
            btnRegis.TabIndex = 2;
            btnRegis.Text = "register";
            btnRegis.UseVisualStyleBackColor = true;
            btnRegis.Click += btnRegis_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1280, 720);
            Controls.Add(btnRegis);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnRegis;
    }
}