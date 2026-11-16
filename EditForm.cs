using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KR_OPAM_Cherednyk
{
    public partial class EditForm : Form
    {
        string connectionString = "server=localhost;database=autodealer_db;uid=root;pwd=";
        private int carId; // Зберігаємо ID автомобіля, який редагуємо

        // Конструктор приймає дані обраного авто
        public EditForm(int id, string brand, string model, int year, string vin, decimal price, string status)
        {
            InitializeComponent();

            carId = id;
            // Заповнюємо поля поточними значеннями з таблиці
            textBox1.Text = brand;
            textBox2.Text = model;
            textBox3.Text = year.ToString();
            textBox4.Text = vin;
            textBox5.Text = price.ToString();
            textBox6.Text = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE cars SET brand = @brand, model = @model, year = @year, vin = @vin, price = @price, status = @status WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@brand", textBox1.Text);
                        cmd.Parameters.AddWithValue("@model", textBox2.Text);
                        cmd.Parameters.AddWithValue("@year", Convert.ToInt32(textBox3.Text));
                        cmd.Parameters.AddWithValue("@vin", textBox4.Text);
                        cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox5.Text));
                        cmd.Parameters.AddWithValue("@status", textBox6.Text);
                        cmd.Parameters.AddWithValue("@id", carId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Дані автомобіля успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при оновленні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
