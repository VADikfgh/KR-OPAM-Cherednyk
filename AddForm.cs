using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KR_OPAM_Cherednyk
{
    public partial class AddForm : Form
    {
        // Такий самий рядок підключення до бази даних
        string connectionString = "server=localhost;database=autodealer_db;uid=root;pwd=";

        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи заповнені поля
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Будь ласка, заповніть хоча б марку, модель та рік!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO cars (brand, model, year, vin, price, status) VALUES (@brand, @model, @year, @vin, @price, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@brand", textBox1.Text);
                        cmd.Parameters.AddWithValue("@model", textBox2.Text);
                        cmd.Parameters.AddWithValue("@year", Convert.ToInt32(textBox3.Text));
                        cmd.Parameters.AddWithValue("@vin", textBox4.Text);
                        cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox5.Text));
                        cmd.Parameters.AddWithValue("@status", textBox6.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Автомобіль успішно додано до бази!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Закриваємо вікно додавання
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}