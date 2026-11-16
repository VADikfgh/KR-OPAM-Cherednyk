using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KR_OPAM_Cherednyk
{
    public partial class TestDriveForm : Form
    {
        private void TestDriveForm_Load(object sender, EventArgs e)
        {
            // Може бути пустим
        }
        private int carId;
        private string carInfo;
        // Ваш стандартний рядок підключення до бази даних
        private string connectionString = "server=localhost;database=autodealer_db;uid=root;pwd=;";

        public TestDriveForm(int id, string car)
        {
            InitializeComponent();
            carId = id;
            carInfo = car;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            TimeSpan selectedTime = dateTimePickerTime.Value.TimeOfDay;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO test_drives (car_id, car_info, test_date, test_time) VALUES (@car_id, @car_info, @date, @time)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@car_id", carId);
                        cmd.Parameters.AddWithValue("@car_info", carInfo);
                        cmd.Parameters.AddWithValue("@date", selectedDate);
                        cmd.Parameters.AddWithValue("@time", selectedTime);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Тест-драйв успішно призначено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка запису на тест-драйв: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            TimeSpan selectedTime = dateTimePickerTime.Value.TimeOfDay;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO test_drives (car_id, car_info, test_date, test_time) VALUES (@car_id, @car_info, @date, @time)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@car_id", carId);
                        cmd.Parameters.AddWithValue("@car_info", carInfo);
                        cmd.Parameters.AddWithValue("@date", selectedDate);
                        cmd.Parameters.AddWithValue("@time", selectedTime);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Тест-драйв успішно призначено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка запису на тест-драйв: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}