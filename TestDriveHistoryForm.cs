using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KR_OPAM_Cherednyk
{
    public partial class TestDriveHistoryForm : Form
    {
        // Ваш рядок підключення до бази даних
        private string connectionString = "server=localhost;database=autodealer_db;uid=root;pwd=;";

        public TestDriveHistoryForm()
        {
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, car_info AS 'Машина', test_date AS 'Дата', test_time AS 'Час' FROM test_drives";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewHistory.DataSource = dt;

                        // Ховаємо службовий id від користувача
                        if (dataGridViewHistory.Columns["id"] != null)
                            dataGridViewHistory.Columns["id"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження історії: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Обробка натискання кнопки "Завершити / Видалити запис"
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistory.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewHistory.SelectedRows[0].Cells["id"].Value);

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM test_drives WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Тест-драйв успішно завершено та видалено з історії!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHistory(); // Оновлюємо таблицю
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть рядок у таблиці!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinish_Click_1(object sender, EventArgs e)
        {
        {
            // Перевіряємо, чи вибрано хоча б один рядок у таблиці
            if (dataGridViewHistory.SelectedRows.Count > 0)
            {
                // Отримуємо унікальний id вибраного тест-драйву з прихованої колонки
                int id = Convert.ToInt32(dataGridViewHistory.SelectedRows[0].Cells["id"].Value);

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // Видаляємо запис із бази даних за його id
                        string query = "DELETE FROM test_drives WHERE id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Тест-драйв успішно завершено та видалено з історії!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Оновлюємо таблицю, щоб рядок зник із екрана
                        LoadHistory();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні запису: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть рядок у таблиці!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }
}
