using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KR_OPAM_Cherednyk
{
    public partial class TradeInForm : Form
    {
        string connectionString = "server=localhost;database=autodealer_db;uid=root;pwd=";

        public TradeInForm()
        {
            InitializeComponent();
            LoadAvailableCars(); // Завантажуємо доступні машини у випадаючий список при відкритті вікна
        }

        // Завантаження машин зі статусом "В наявності" у ComboBox (comboBoxCars)
        private void LoadAvailableCars()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, CONCAT(brand, ' ', model, ' ($', price, ')') AS car_info FROM cars WHERE status = 'В наявності'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    comboBoxCars.DataSource = table;
                    comboBoxCars.DisplayMember = "car_info";
                    comboBoxCars.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження авто: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка розрахунку та оформлення Trade-In (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxCars.SelectedValue == null || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля та виберіть автомобіль!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int carId = Convert.ToInt32(comboBoxCars.SelectedValue);
                string clientName = textBox1.Text;
                decimal oldCarPrice = Convert.ToDecimal(textBox2.Text);

                decimal newCarPrice = 0;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string priceQuery = "SELECT price FROM cars WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(priceQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", carId);
                        newCarPrice = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    // Розраховуємо суму доплати
                    decimal extraPayment = newCarPrice - oldCarPrice;
                    if (extraPayment < 0) extraPayment = 0;

                    // Оновлюємо статус машини на "Продано (Trade-In)" у базі
                    string updateQuery = "UPDATE cars SET status = 'Продано (Trade-In)' WHERE id = @id";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@id", carId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Виводимо результат у ваш Label (lblResult) на формі
                    lblResult.Text = $"Успішно оформлено!\n" +
                                     $"Клієнт: {clientName}\n" +
                                     $"Ціна нового авто: ${newCarPrice}\n" +
                                     $"Оцінка старого: ${oldCarPrice}\n" +
                                     $"Сума доплати: ${extraPayment}";

                    MessageBox.Show("Угоду Trade-In успішно оформлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка розрахунку: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}