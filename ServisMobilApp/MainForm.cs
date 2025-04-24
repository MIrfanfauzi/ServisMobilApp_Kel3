using System;
using System.Windows.Forms;

namespace ServisMobilApp
{
    public partial class MainForm : Form
    {
        string connectionString = "Data Source=LAPTOP-N8SLA3LN\\IRFANFAUZI;Initial Catalog=ServisMobil;Integrated Security=True";
        private Form loginForm;

        public MainForm(Form loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;


            this.btnPelanggan.Click += new EventHandler(this.btnPelanggan_Click);
            this.btnMekanik.Click += new EventHandler(this.btnMekanik_Click);
            this.btnKendaraan.Click += new EventHandler(this.btnKendaraan_Click);
            this.btnLayananServis.Click += new EventHandler(this.btnLayananServis_Click);
            this.btnPemesananServis.Click += new EventHandler(this.btnPemesananServis_Click);
            this.btnLaporanServis.Click += new EventHandler(this.btnLaporanServis_Click);


            AddLogoutButton();
        }

        private void AddLogoutButton()
        {
            Button btnLogout = new Button();
            btnLogout.Name = "btnLogout";
            btnLogout.Text = "Logout";
            btnLogout.Size = new System.Drawing.Size(100, 30);
            btnLogout.Location = new System.Drawing.Point(10, 10);
            btnLogout.Click += new EventHandler(this.btnLogout_Click);
            this.Controls.Add(btnLogout);
        }

        private void LoadUserControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        private void LoadForm(Form form)
        {
            panelContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Pelanggan1());
        }

        private void btnKendaraan_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Kendaraan2());
        }

        private void btnMekanik_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Mekanik());
        }

        private void btnLayananServis_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_LayananServis());
        }

        private void btnPemesananServis_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_PemesananServis());
        }

        private void btnLaporanServis_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_LaporanServis());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                loginForm.Show();
            }
        }

    }
}