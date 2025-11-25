using ChochoNest.Controller;
using ChochoNest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChochoNest.View
{
    public partial class LoginForm : Form
    {
        private AuthController _authController;
        public LoginForm()
        {
            InitializeComponent();
            _authController = new AuthController();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _authController.showRegisterForm(this);
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Username = tbUsername.Text;
            user.Password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                MessageBox.Show("Username dan Password harus di isi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Perkondisian Login Admin
            if (user.Username == "admin" && user.Password == "1234")
            {
                MessageBox.Show("Login Admin berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Contoh buka form admin
                AdminDashboard AK = new AdminDashboard();
                AK.Show();
                this.Hide();
                return;
            }

            var auth = _authController.Login(user);

            if (auth)
            {
                MessageBox.Show($"Login berhasil. Selamat datang {user.Username}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Contoh buka form pelanggan
                KatalogPelanggan KP= new KatalogPelanggan();
                KP.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah. Silahkan periksa kredensial akun anda!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
