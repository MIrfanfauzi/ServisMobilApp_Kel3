using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServisMobilApp
{
    public partial class UC_PemesananServis : UserControl
    {
        private string connectionString = "Data Source=LAPTOP-N8SLA3LN\\IRFANFAUZI;Initial Catalog=ServisMobil;Integrated Security=True";

        public UC_PemesananServis()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadPemesanan();

            // Event untuk memuat kendaraan sesuai pelanggan
            cmbPelanggan.SelectedIndexChanged += cmbPelanggan_SelectedIndexChanged;
        }

        // ==============================
        // LOAD DATA & INITIAL SETUP
        // ==============================

        private void LoadComboBoxData()
        {
            LoadCombo(cmbPelanggan, "SELECT ID_Pelanggan, Nama FROM Pelanggan", "Nama", "ID_Pelanggan");
            LoadCombo(cmbLayanan, "SELECT ID_Layanan, NamaLayanan FROM LayananServis", "NamaLayanan", "ID_Layanan");
            LoadCombo(cmbMekanik, "SELECT ID_Mekanik, Nama FROM Mekanik", "Nama", "ID_Mekanik");
            cmbStatus.Items.AddRange(new[] { "Pending", "Selesai" });
        }

        private void LoadCombo(ComboBox combo, string query, string display, string value)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    combo.DataSource = dt;
                    combo.DisplayMember = display;
                    combo.ValueMember = value;
                    combo.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memuat {combo.Name}: " + ex.Message);
                }
            }
        }

        private void cmbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPelanggan.SelectedValue != null)
            {
                string query = $"SELECT ID_Kendaraan, NomorPlat FROM Kendaraan WHERE ID_Pelanggan = {cmbPelanggan.SelectedValue}";
                LoadCombo(cmbKendaraan, query, "NomorPlat", "ID_Kendaraan");
            }
        }

        private void LoadPemesanan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"
                        SELECT p.ID_Pemesanan, pel.Nama, k.NomorPlat, l.NamaLayanan, m.Nama AS Mekanik, 
                               p.TanggalPesan, p.TanggalServis, p.Status
                        FROM PemesananServis p
                        JOIN Pelanggan pel ON pel.ID_Pelanggan = p.ID_Pelanggan
                        JOIN Kendaraan k ON k.ID_Kendaraan = p.ID_Kendaraan
                        JOIN LayananServis l ON l.ID_Layanan = p.ID_Layanan
                        LEFT JOIN Mekanik m ON m.ID_Mekanik = p.ID_Mekanik";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPemesanan.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat pemesanan: " + ex.Message);
                }
            }
        }

        // ==============================
        // CRUD BUTTONS
        // ==============================

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidasiForm()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO PemesananServis 
                        (ID_Pelanggan, ID_Kendaraan, ID_Layanan, ID_Mekanik, TanggalServis, Status)
                        VALUES (@ID_Pelanggan, @ID_Kendaraan, @ID_Layanan, @ID_Mekanik, @TanggalServis, @Status)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_Pelanggan", cmbPelanggan.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Kendaraan", cmbKendaraan.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Layanan", cmbLayanan.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Mekanik", cmbMekanik.SelectedValue ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TanggalServis", dtpTanggalServis.Value);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pemesanan berhasil ditambahkan!");
                    LoadPemesanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambahkan: " + ex.Message);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblID.Text)) return;
            if (!ValidasiForm()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        UPDATE PemesananServis SET 
                        ID_Pelanggan = @ID_Pelanggan,
                        ID_Kendaraan = @ID_Kendaraan,
                        ID_Layanan = @ID_Layanan,
                        ID_Mekanik = @ID_Mekanik,
                        TanggalServis = @TanggalServis,
                        Status = @Status
                        WHERE ID_Pemesanan = @ID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@ID_Pelanggan", cmbPelanggan.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Kendaraan", cmbKendaraan.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Layanan", cmbLayanan.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Mekanik", cmbMekanik.SelectedValue ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TanggalServis", dtpTanggalServis.Value);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diperbarui!");
                    LoadPemesanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengubah: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblID.Text)) return;

            var confirm = MessageBox.Show("Yakin ingin menghapus pemesanan ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM PemesananServis WHERE ID_Pemesanan = @ID", conn);
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pemesanan dihapus!");
                        LoadPemesanan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus: " + ex.Message);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblID.Text = "";
            cmbPelanggan.SelectedIndex = -1;
            cmbKendaraan.DataSource = null;
            cmbLayanan.SelectedIndex = -1;
            cmbMekanik.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dtpTanggalServis.Value = DateTime.Now;
        }

        // ==============================
        // HELPER FUNCTION
        // ==============================

        private bool ValidasiForm()
        {
            if (cmbPelanggan.SelectedIndex == -1 || cmbKendaraan.SelectedIndex == -1 ||
                cmbLayanan.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Seluruh data wajib diisi!");
                return false;
            }
            return true;
        }

        private void dgvPemesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPemesanan.Rows[e.RowIndex];
                lblID.Text = row.Cells["ID_Pemesanan"].Value?.ToString() ?? "";
                cmbPelanggan.Text = row.Cells["Nama"].Value?.ToString();
                cmbKendaraan.Text = row.Cells["NomorPlat"].Value?.ToString();
                cmbLayanan.Text = row.Cells["NamaLayanan"].Value?.ToString();
                cmbMekanik.Text = row.Cells["Mekanik"].Value?.ToString();
                dtpTanggalServis.Value = Convert.ToDateTime(row.Cells["TanggalServis"].Value);
                cmbStatus.Text = row.Cells["Status"].Value?.ToString();
            }
        }
    }
}
