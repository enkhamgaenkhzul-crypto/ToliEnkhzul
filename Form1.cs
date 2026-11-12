
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace ToliEnkhzul
{
    public partial class Form1 : Form
    {
        private readonly string _toliConn =
            "Data Source=" + Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "toli.db");

        private readonly string _savedConn =
            "Data Source=" + Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "saved.db");

        private int _selectedId = -1;
        private bool _isSavedSelected = false;


        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;

            cmbLang.Items.Clear();
            cmbLang.Items.Add("Англи");
            cmbLang.Items.Add("Монгол");
            cmbLang.Items.Add("Орос");
            cmbLang.SelectedIndex = 0;

            InitDb();
            InitSavedDb();
            LoadWords();
            UpdateCount();
            LoadSavedWords();
        }

        private void LoadSavedWords()
        {
            using var con = new SqliteConnection(_savedConn);
            con.Open();

            string sql = "SELECT id, eng, mon, rus FROM saved_words";

            using var cmd = new SqliteCommand(sql, con);
            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            // Дарааллын дугаар нэмэх
            dt.Columns.Add("№", typeof(int));
            dt.Columns["№"].SetOrdinal(0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["№"] = i + 1;
            }

            dataGridView2.DataSource = dt;

            // Жинхэнэ ID-г нуух
            dataGridView2.Columns["id"].Visible = false;

            UpdateCount();
        }

        private void InitDb()
        {
            using var con = new SqliteConnection(_toliConn);
            con.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS words (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    eng TEXT NOT NULL,
                    mon TEXT NOT NULL,
                    rus TEXT NOT NULL
                );";

            using var cmd = new SqliteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        private void LoadWords()
        {
            using var con = new SqliteConnection(_toliConn);
            con.Open();

            string sql = "SELECT id, eng, mon, rus FROM words";

            using var cmd = new SqliteCommand(sql, con);
            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dt.Columns.Add("№", typeof(int));
            dt.Columns["№"].SetOrdinal(0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["№"] = i + 1;
            }

            dataGridView1.DataSource = dt;

        
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["№"].DisplayIndex = 0;


            UpdateCount();
        }

        private void UpdateCount()
        {
            int total = 0;
            int saved = 0;

            using (var con = new SqliteConnection(_toliConn))
            {
                con.Open();
                using var cmd = new SqliteCommand(
                    "SELECT COUNT(*) FROM words", con);
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }

            using (var con = new SqliteConnection(_savedConn))
            {
                con.Open();
                using var cmd = new SqliteCommand(
                    "SELECT COUNT(*) FROM saved_words", con);
                saved = Convert.ToInt32(cmd.ExecuteScalar());
            }

            lblCount.Text = $"Нийт: {total} үг · Санасан: {saved}";
        }
        private void InitSavedDb()
        {
            using var con = new SqliteConnection(_savedConn);
            con.Open();

            string sql = @"
        CREATE TABLE IF NOT EXISTS saved_words (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            eng TEXT NOT NULL,
            mon TEXT NOT NULL,
            rus TEXT NOT NULL
        );";

            using var cmd = new SqliteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLang.SelectedIndex == -1) return;

            using var con = new SqliteConnection(_toliConn);
            con.Open();

            string column = cmbLang.SelectedIndex switch
            {
                0 => "eng",
                1 => "mon",
                2 => "rus",
                _ => "eng"
            };

            string sql = $"SELECT id, eng, mon, rus FROM words WHERE {column} LIKE @search";

            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text.Trim() + "%");

            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dataGridView1.DataSource = dt;

        }


        private void label1_Click(object sender, EventArgs e)
        {
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string eng = txtEng.Text.Trim();
            string mon = txtMon.Text.Trim();
            string rus = txtRus.Text.Trim();

            if (eng == "" || mon == "" || rus == "")
            {
                MessageBox.Show("Гурван хэлний үгийг бүрэн оруулна уу!");
                return;
            }

            using var con = new SqliteConnection(_toliConn);
            con.Open();

            string sql = "INSERT INTO words (eng, mon, rus) VALUES (@eng, @mon, @rus)";

            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@eng", eng);
            cmd.Parameters.AddWithValue("@mon", mon);
            cmd.Parameters.AddWithValue("@rus", rus);
            cmd.ExecuteNonQuery();

            LoadWords();

            txtEng.Clear();
            txtMon.Clear();
            txtRus.Clear();

            MessageBox.Show("Үг амжилттай нэмэгдлээ!");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                MessageBox.Show("Эхлээд хүснэгтээс засах үгээ сонгоно уу!");
                return;
            }

            string eng = txtEng.Text.Trim();
            string mon = txtMon.Text.Trim();
            string rus = txtRus.Text.Trim();

            if (eng == "" || mon == "" || rus == "")
            {
                MessageBox.Show("Гурван хэлний үгийг бүрэн оруулна уу!");
                return;
            }

            using var con = new SqliteConnection(_toliConn);
            con.Open();

            string sql = @"UPDATE words
                   SET eng=@eng, mon=@mon, rus=@rus
                   WHERE id=@id";

            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@eng", eng);
            cmd.Parameters.AddWithValue("@mon", mon);
            cmd.Parameters.AddWithValue("@rus", rus);
            cmd.Parameters.AddWithValue("@id", _selectedId);
            cmd.ExecuteNonQuery();

            LoadWords();
            _selectedId = -1;

            txtEng.Clear();
            txtMon.Clear();
            txtRus.Clear();

            MessageBox.Show("Амжилттай засагдлаа!");
        }
        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _isSavedSelected = false;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            _selectedId = Convert.ToInt32(row.Cells["id"].Value);

            txtEng.Text = row.Cells["eng"].Value?.ToString();
            txtMon.Text = row.Cells["mon"].Value?.ToString();
            txtRus.Text = row.Cells["rus"].Value?.ToString();
        }
        private void dataGridView2_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _isSavedSelected = true;

            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

            _selectedId = Convert.ToInt32(row.Cells["id"].Value);

            txtEng.Text = row.Cells["eng"].Value?.ToString();
            txtMon.Text = row.Cells["mon"].Value?.ToString();
            txtRus.Text = row.Cells["rus"].Value?.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                MessageBox.Show("Эхлээд устгах үгээ сонгоно уу!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Сонгосон үгийг устгах уу?",
                "Баталгаажуулалт",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            if (_isSavedSelected)
            {
                using var con = new SqliteConnection(_savedConn);
                con.Open();

                string sql = "DELETE FROM saved_words WHERE id=@id";

                using var cmd = new SqliteCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", _selectedId);
                cmd.ExecuteNonQuery();

                LoadSavedWords();
            }
            else
            {
                using var con = new SqliteConnection(_toliConn);
                con.Open();

                string sql = "DELETE FROM words WHERE id=@id";

                using var cmd = new SqliteCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", _selectedId);
                cmd.ExecuteNonQuery();

                LoadWords();
            }

            _selectedId = -1;
            _isSavedSelected = false;

            txtEng.Clear();
            txtMon.Clear();
            txtRus.Clear();

            UpdateCount();

            MessageBox.Show("Үг амжилттай устгагдлаа!");
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEng.Clear();
            txtMon.Clear();
            txtRus.Clear();

            _selectedId = -1;

            dataGridView1.ClearSelection();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                MessageBox.Show("Эхлээд хүснэгтээс үг сонгоно уу!");
                return;
            }

            string eng = txtEng.Text.Trim();
            string mon = txtMon.Text.Trim();
            string rus = txtRus.Text.Trim();

            using var con = new SqliteConnection(_savedConn);
            con.Open();

            string sql = @"INSERT INTO saved_words (eng, mon, rus)
                   SELECT @eng, @mon, @rus
                   WHERE NOT EXISTS (
                       SELECT 1 FROM saved_words WHERE eng=@eng
                   )";

            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@eng", eng);
            cmd.Parameters.AddWithValue("@mon", mon);
            cmd.Parameters.AddWithValue("@rus", rus);

            int result = cmd.ExecuteNonQuery();

            LoadSavedWords();

            if (result > 0)
                MessageBox.Show("Үг амжилттай хадгалагдлаа!");
            else
                MessageBox.Show("Энэ үг өмнө нь хадгалагдсан байна!");
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string column = cmbLang.SelectedIndex switch
            {
                0 => "eng",
                1 => "mon",
                2 => "rus",
                _ => "eng"
            };

            using var con = new SqliteConnection(_toliConn);
            con.Open();

            string sql = $"SELECT id, eng, mon, rus FROM words WHERE {column} LIKE @search";

            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text.Trim() + "%");

            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dataGridView1.DataSource = dt;
            UpdateCount();

        }

        private void Англи_Click(object sender, EventArgs e)
        {

        }

        private void lblSaved_Click(object sender, EventArgs e)
        {

        }
    }

}
