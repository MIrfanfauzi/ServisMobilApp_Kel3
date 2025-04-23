using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServisMobilApp
{
    public partial class UC_Mekanik : UserControl
    {
        private string connectionString = "Data Source=LAPTOP-N8SLA3LN\\IRFANFAUZI;Initial Catalog=ServisMobil;Integrated Security=True";

        public UC_Mekanik()
        {
            InitializeComponent();

            // Inisialisasi ComboBox
            cmbSpesialisasi.Items.AddRange(new string[] { "Tune Up", "Servis Berkala", "Mesin" });
            cmbSpesialisasi.DropDownStyle = ComboBoxStyle.DropDownList;

            // Inisialisasi DataGridView dan Event
            dgvData.AutoGenerateColumns = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = false;
            dgvData.CellClick += dgvData_CellClick;

            LoadMekanik();
        }

        private void LoadMekanik()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID_Mekanik, Nama, Telepon, Spesialisasi FROM Mekanik";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }

        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtNoTelp.Text) ||
                cmbSpesialisasi.SelectedIndex == -1)
            {
                MessageBox.Show("Semua field wajib diisi!");
                return false;
            }

            if (!txtNoTelp.Text.StartsWith("08") || txtNoTelp.Text.Length < 12 || txtNoTelp.Text.Length > 13)
            {
                MessageBox.Show("Nomor telepon harus diawali dengan 08 dan panjangnya 12-13 digit.");
                return false;
            }

            return true;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Mekanik (Nama, Telepon, Spesialisasi) VALUES (@Nama, @Telepon, @Spesialisasi)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telepon", txtNoTelp.Text.Trim());
                    cmd.Parameters.AddWithValue("@Spesialisasi", cmbSpesialisasi.SelectedItem.ToString());

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Mekanik berhasil ditambahkan!");
                        LoadMekanik();
                        KosongkanForm();
                    }
                }
                catch (SqlException ex)
                {
                    TampilkanPesanKesalahan(ex);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih data yang ingin diubah!");
                return;
            }

            if (!ValidasiInput()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Mekanik SET Nama=@Nama, Telepon=@Telepon, Spesialisasi=@Spesialisasi WHERE ID_Mekanik=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telepon", txtNoTelp.Text.Trim());
                    cmd.Parameters.AddWithValue("@Spesialisasi", cmbSpesialisasi.SelectedItem.ToString());

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Data mekanik berhasil diubah!");
                        LoadMekanik();
                        KosongkanForm();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan atau tidak ada perubahan.");
                    }
                }
                catch (SqlException ex)
                {
                    TampilkanPesanKesalahan(ex);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Mekanik WHERE ID_Mekanik = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Data mekanik berhasil dihapus!");
                            LoadMekanik();
                            KosongkanForm();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus: " + ex.Message);
                    }
                }
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvData.Rows[e.RowIndex].Cells.Count >= 4)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                lblID.Text = row.Cells["ID_Mekanik"].Value?.ToString() ?? "";
                txtNama.Text = row.Cells["Nama"].Value?.ToString() ?? "";
                txtNoTelp.Text = row.Cells["Telepon"].Value?.ToString() ?? "";
                cmbSpesialisasi.SelectedItem = row.Cells["Spesialisasi"].Value?.ToString();
            }
        }

        private void KosongkanForm()
        {
            lblID.Text = "";
            txtNama.Clear();
            txtNoTelp.Clear();
            cmbSpesialisasi.SelectedIndex = -1;
            txtNama.Focus();
        }

        private void TampilkanPesanKesalahan(SqlException ex)
        {
            if (ex.Message.Contains("UNIQUE") && ex.Message.Contains("Telepon"))
            {
                MessageBox.Show("Nomor telepon sudah digunakan oleh mekanik lain.", "Validasi Telepon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex.Message.Contains("Cannot insert the value NULL"))
            {
                MessageBox.Show("Semua field wajib diisi. Pastikan tidak ada kolom yang kosong.", "Validasi Data Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex.Message.Contains("CHECK") && ex.Message.Contains("Spesialisasi"))
            {
                MessageBox.Show("Spesialisasi harus salah satu dari: Tune Up, Servis Berkala, atau Mesin.", "Validasi Spesialisasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Kesalahan SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
