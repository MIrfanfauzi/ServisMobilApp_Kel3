using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServisMobilApp
{
    public partial class UC_LaporanServis : UserControl
    {
        private string connectionString = "Data Source=LAPTOP-N8SLA3LN\\IRFANFAUZI;Initial Catalog=ServisMobil;Integrated Security=True";

        public UC_LaporanServis()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadLaporan();

            // Event handler tombol
            btnTambah.Click += btnTambah_Click;
            btnUbah.Click += btnUbah_Click;
            btnHapus.Click += btnHapus_Click;
            dgvLaporan.CellClick += dgvLaporan_CellClick;
        }

        private void LoadComboBoxData()
        {
            // Hanya load pemesanan yang status-nya sudah 'Selesai'
            LoadCombo(cmbPemesanan, "SELECT ID_Pemesanan FROM PemesananServis WHERE Status = 'Selesai'", "ID_Pemesanan", "ID_Pemesanan");
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
                    MessageBox.Show($"Gagal load {combo.Name}: " + ex.Message);
                }
            }
        }

        private void LoadLaporan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT ID_Laporan, ID_Pemesanan, Deskripsi, BiayaTambahan, TanggalSelesai FROM LaporanServis";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLaporan.DataSource = dt;
                    KosongkanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat laporan: " + ex.Message);
                }
            }
        }

        private void KosongkanForm()
        {
            lblID.Text = "";
            cmbPemesanan.SelectedIndex = -1;
            txtDeskripsi.Clear();
            txtBiayaTambahan.Clear();
            dtpTanggalSelesai.Value = DateTime.Now;
            cmbPemesanan.Focus();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (cmbPemesanan.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtDeskripsi.Text))
            {
                MessageBox.Show("Data wajib diisi!");
                return;
            }

            if (!decimal.TryParse(txtBiayaTambahan.Text, out decimal biayaTambahan) || biayaTambahan < 0)
            {
                MessageBox.Show("Masukkan biaya tambahan yang valid!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO LaporanServis 
                                     (ID_Pemesanan, Deskripsi, BiayaTambahan, TanggalSelesai)
                                     VALUES (@ID_Pemesanan, @Deskripsi, @BiayaTambahan, @TanggalSelesai)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_Pemesanan", cmbPemesanan.SelectedValue);
                    cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text);
                    cmd.Parameters.AddWithValue("@BiayaTambahan", biayaTambahan);
                    cmd.Parameters.AddWithValue("@TanggalSelesai", dtpTanggalSelesai.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Laporan berhasil ditambahkan!");
                    LoadLaporan();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal tambah laporan: " + ex.Message);
                }
            }
        }

        private void dgvLaporan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLaporan.Rows[e.RowIndex];
                lblID.Text = row.Cells["ID_Laporan"].Value.ToString();
                cmbPemesanan.Text = row.Cells["ID_Pemesanan"].Value.ToString();
                txtDeskripsi.Text = row.Cells["Deskripsi"].Value.ToString();
                txtBiayaTambahan.Text = row.Cells["BiayaTambahan"].Value.ToString();
                dtpTanggalSelesai.Value = Convert.ToDateTime(row.Cells["TanggalSelesai"].Value);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblID.Text))
            {
                MessageBox.Show("Pilih data yang ingin diubah!");
                return;
            }

            if (!decimal.TryParse(txtBiayaTambahan.Text, out decimal biayaTambahan) || biayaTambahan < 0)
            {
                MessageBox.Show("Masukkan biaya tambahan yang valid!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE LaporanServis SET 
                                     ID_Pemesanan = @ID_Pemesanan,
                                     Deskripsi = @Deskripsi,
                                     BiayaTambahan = @BiayaTambahan,
                                     TanggalSelesai = @TanggalSelesai
                                     WHERE ID_Laporan = @ID_Laporan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_Laporan", lblID.Text);
                    cmd.Parameters.AddWithValue("@ID_Pemesanan", cmbPemesanan.SelectedValue);
                    cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text);
                    cmd.Parameters.AddWithValue("@BiayaTambahan", biayaTambahan);
                    cmd.Parameters.AddWithValue("@TanggalSelesai", dtpTanggalSelesai.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diperbarui!");
                    LoadLaporan();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal update: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblID.Text))
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus laporan ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM LaporanServis WHERE ID_Laporan = @ID", conn);
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Laporan dihapus!");
                        LoadLaporan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal hapus: " + ex.Message);
                    }
                }
            }
        }
    }
}
