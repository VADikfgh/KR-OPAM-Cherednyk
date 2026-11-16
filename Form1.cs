using MySql.Data.MySqlClient; // Підключаємо бібліотеку MySQL
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace KR_OPAM_Cherednyk
{
    public partial class Form1 : Form
    {
        // Рядок підключення до нашої бази даних
        string connectionString = "server=localhost;database=autodealer_db;uid=root;pwd=";

        public Form1()
        {
            InitializeComponent();
            LoadCarsData(); // Викликаємо завантаження даних при відкритті програми
        }

        // Цей метод потрібен дизайнеру форм, щоб усе працювало без помилок
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Функція для завантаження автомобілів з бази у dataGridView1
        private void LoadCarsData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Запит без VIN-коду (VIN залишиться тільки в базі та для детального вікна)
                    string query = "SELECT id, brand AS 'Марка', model AS 'Модель', year AS 'Рік', price AS 'Ціна ($)', status AS 'Статус' FROM cars";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження даних: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        {
            // Перевіряємо, чи вибраний якийсь рядок у таблиці
            if (dataGridView1.CurrentRow != null)
            {
                // Отримуємо ID вибраного автомобіля з першої колонки
                int carId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                // Питаємо підтвердження у користувача
                DialogResult result = MessageBox.Show("Ви дійсно хочете видалити цей автомобіль із бази?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM cars WHERE id = @id";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                // Передаємо параметр ID безпечним шляхом
                                cmd.Parameters.AddWithValue("@id", carId);
                                cmd.ExecuteNonQuery();
                            }

                            // Оновлюємо таблицю на екрані
                            LoadCarsData();
                            MessageBox.Show("Автомобіль успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Помилка при видаленні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть рядок з автомобілем у таблиці!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

        private void button1_Click(object sender, EventArgs e)
        {
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog(); // Відкриваємо вікно додавання
            LoadCarsData();       // Оновлюємо таблицю на головному екрані після закриття вікна
        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            // Просто викликаємо метод подвійного кліку для вибраного рядка
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1_CellDoubleClick(dataGridView1, new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentRow.Index));
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть автомобіль у таблиці!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // (назва кнопки може відрізнятися, наприклад button4 чи buttonTrade)
        {
            TradeInForm tradeForm = new TradeInForm();
            tradeForm.ShowDialog();
            LoadCarsData(); // Оновлюємо таблицю на головному екрані після закриття вікна
        }
    }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        {
            string searchText = txtSearch.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Запит із фільтрацією за маркою, моделлю або VIN-кодом
                    string query = "SELECT id, brand AS 'Марка', model AS 'Модель', year AS 'Рік', vin AS 'VIN-код', price AS 'Ціна ($)', status AS 'Статус' " +
                                   "FROM cars WHERE brand LIKE @search OR model LIKE @search OR vin LIKE @search";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Додаємо символи % для пошуку входження підстроки
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка пошуку: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        {
            // Перевіряємо, чи клікнули саме по рядку (а не по шапці таблиці)
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                // Змінні для збереження даних з бази
                string brand = "", model = "", vin = "", status = "", color = "", desc = "", photo = "", transmission = "", fuel = "";
                int year = 0, hp = 0;
                decimal price = 0, engineVol = 0;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Завантажуємо абсолютно всі поля для цього ID, включаючи VIN та нові характеристики
                    string q = "SELECT * FROM cars WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                brand = reader["brand"].ToString();
                                model = reader["model"].ToString();
                                year = Convert.ToInt32(reader["year"]);
                                vin = reader["vin"].ToString();
                                price = Convert.ToDecimal(reader["price"]);
                                status = reader["status"].ToString();
                                color = reader["color"]?.ToString() ?? "Не вказано";
                                hp = reader["horsepower"] != DBNull.Value ? Convert.ToInt32(reader["horsepower"]) : 0;
                                transmission = reader["transmission"]?.ToString() ?? "Не вказано";
                                fuel = reader["fuel_type"]?.ToString() ?? "Не вказано";
                                engineVol = reader["engine_volume"] != DBNull.Value ? Convert.ToDecimal(reader["engine_volume"]) : 0;
                                desc = reader["description"]?.ToString() ?? "";
                                photo = reader["photo_path"]?.ToString() ?? "";
                            }
                        }
                    }
                }

                    // Об'єднуємо марку і модель в один рядок
                    string brandModel = brand + " " + model;

                    // Викликаємо форму (передаємо рівно 13 аргументів)
                    CarDetailsForm detailsForm = new CarDetailsForm(id, brandModel, year, vin, price, status, color, hp, transmission, fuel, engineVol, desc, photo);
                    detailsForm.ShowDialog();
                    LoadCarsData(); // Оновлюємо таблицю після закриття
                }
        }
    }

        private void button2_Click_1(object sender, EventArgs e)
        {
        {
            TestDriveHistoryForm historyForm = new TestDriveHistoryForm();
            historyForm.ShowDialog();
        }
    }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Немає даних для експорту!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV файли (*.csv)|*.csv|Усі файли (*.*)|*.*";
                sfd.FileName = "Cars_Catalog.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            // Шапка таблиці
                            string headerLine = "";
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                headerLine += dataGridView1.Columns[i].HeaderText;
                                if (i < dataGridView1.Columns.Count - 1)
                                    headerLine += ";";
                            }
                            sw.WriteLine(headerLine);

                            // Рядки таблиці
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue;

                                string line = "";
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    object value = row.Cells[i].Value;
                                    line += (value != null ? value.ToString() : "");

                                    if (i < dataGridView1.Columns.Count - 1)
                                        line += ";";
                                }
                                sw.WriteLine(line);
                            }
                        }

                        MessageBox.Show("Каталог автомобілів успішно експортовано в Excel!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при експорті: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
    }
}
