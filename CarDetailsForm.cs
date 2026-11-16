using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KR_OPAM_Cherednyk
{
    public partial class CarDetailsForm : Form
    {
        private int carId; // Зберігаємо ID поточного авто для оновлення в БД
        private string connectionString = "server=localhost;database=autodealer_db;uid=root;pwd=;";
        private string currentPhotoPath = "";

        // Конструктор приймає ID та всі дані для заповнення полів
        public CarDetailsForm(int id, string brandModel, int year, string vin, decimal price, string status, string color, int hp, string transmission, string fuel, decimal engineVol, string description, string photoPath)
        {
            InitializeComponent();
            carId = id;

            // Заповнюємо поля екрана значеннями
            txtBrandModel.Text = brandModel;
            txtPrice.Text = price.ToString();
            cmbStatus.Text = status;
            txtColor.Text = color;
            cmbTransmission.Text = transmission;
            cmbFuel.Text = fuel;
            txtEngineVolume.Text = engineVol.ToString();
            txtHorsepower.Text = hp.ToString();
            txtDescription.Text = description;

            // Додатково можна вивести рік та VIN у звичайні Label, якщо вони є на формі
            // Наприклад: lblVinYear.Text = $"Рік: {year} | VIN: {vin}";

            // Робимо поля неактивними до натискання кнопки «Редагувати»
            SetFieldsEnabled(false);
            btnSave.Visible = false;

            // Завантаження фотографії
            if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
            {
                try
                {
                    pictureBoxCar.Image = Image.FromFile(photoPath);
                    pictureBoxCar.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { }
            }
        }

        // Метод для блокування/розблокування полів
        private void SetFieldsEnabled(bool enabled)
        {
            txtBrandModel.ReadOnly = !enabled;
            txtBrandModel.Enabled = true;

            txtPrice.Enabled = enabled;
            txtYear.Enabled = enabled;
            txtPrice.Enabled = enabled;
            cmbStatus.Enabled = enabled;
            txtColor.Enabled = enabled;
            cmbTransmission.Enabled = enabled;
            cmbFuel.Enabled = enabled;
            txtEngineVolume.Enabled = enabled;
            txtHorsepower.Enabled = enabled;
            txtDescription.Enabled = enabled;

            btnSelectPhoto.Enabled = enabled;
        }

        // Кнопка «Редагувати» — розблоковує поля
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetFieldsEnabled(true);
            btnEdit.Visible = false;      // Ховаємо кнопку редагування
            btnSave.Visible = true;     // Показуємо кнопку збереження
        }

        // Кнопка «Зберегти» — оновлює дані в базі даних MySQL
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE cars SET price = @price, status = @status, color = @color, " +
                                   "transmission = @trans, fuel_type = @fuel, engine_volume = @eng, " +
                                   "horsepower = @hp, description = @desc WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                        cmd.Parameters.AddWithValue("@color", txtColor.Text);
                        cmd.Parameters.AddWithValue("@trans", cmbTransmission.Text);
                        cmd.Parameters.AddWithValue("@fuel", cmbFuel.Text);
                        cmd.Parameters.AddWithValue("@eng", Convert.ToDecimal(txtEngineVolume.Text));
                        cmd.Parameters.AddWithValue("@hp", Convert.ToInt32(txtHorsepower.Text));
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@id", carId);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Характеристики автомобіля успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Закриваємо вікно після збереження
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CarDetailsForm_Load(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            // Розблоковуємо всі поля (рік, ціна, статус, колір, об'єм тощо)
            SetFieldsEnabled(true);

            // Перемикаємо видимість кнопок
            btnEdit.Visible = false;
            btnSave.Visible = true;

            // Робимо кнопку вибору фото активною для редагування
            btnSelectPhoto.Enabled = true;
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
        {
            // Відкриваємо діалогове вікно вибору файлу
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Встановлюємо фільтр для зображень
                ofd.Filter = "Зображення (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Виберіть фотографію автомобіля";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Зберігаємо новий шлях до файлу в змінну
                    currentPhotoPath = ofd.FileName;

                    try
                    {
                        // Завантажуємо зображення у PictureBox та адаптуємо його розмір
                        pictureBoxCar.Image = Image.FromFile(currentPhotoPath);
                        pictureBoxCar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не вдалося завантажити зображення: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Запит на оновлення даних автомобіля в базі даних
                    string query = "UPDATE cars SET brand = @brand, model = @model, year = @year, price = @price, " +
                                   "status = @status, color = @color, transmission = @transmission, fuel_type = @fuel, " +
                                   "engine_volume = @engine, horsepower = @hp, description = @desc, photo_path = @photo WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Розбиваємо "Марка та модель" назад на два поля, якщо вони вводяться в один рядок, 
                        // або зберігаємо залежно від вашої структури БД:
                        string fullBrandModel = txtBrandModel.Text.Trim();
                        string brand = fullBrandModel;
                        string model = "";

                        if (fullBrandModel.Contains(" "))
                        {
                            int spaceIndex = fullBrandModel.IndexOf(' ');
                            brand = fullBrandModel.Substring(0, spaceIndex);
                            model = fullBrandModel.Substring(spaceIndex + 1);
                        }

                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@year", Convert.ToInt32(txtYear.Text));

                        // Безпечне зчитування ціни
                        decimal price = 0;
                        decimal.TryParse(txtPrice.Text.Replace(".", ","), out price);
                        cmd.Parameters.AddWithValue("@price", price);

                        cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                        cmd.Parameters.AddWithValue("@color", txtColor.Text);
                        cmd.Parameters.AddWithValue("@transmission", cmbTransmission.Text);
                        cmd.Parameters.AddWithValue("@fuel", cmbFuel.Text);

                        decimal engine = 0;
                        decimal.TryParse(txtEngineVolume.Text.Replace(".", ","), out engine);
                        cmd.Parameters.AddWithValue("@engine", engine);

                        cmd.Parameters.AddWithValue("@hp", Convert.ToInt32(string.IsNullOrEmpty(txtHorsepower.Text) ? "0" : txtHorsepower.Text));
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@photo", currentPhotoPath);
                        cmd.Parameters.AddWithValue("@id", carId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Зміни успішно збережено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Повторно блокуємо поля після збереження
                    SetFieldsEnabled(false);
                    btnSave.Visible = false;
                    btnEdit.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

        private void btnTestDrive_Click(object sender, EventArgs e)
        {
        {
            TestDriveForm form = new TestDriveForm(carId, txtBrandModel.Text);
            form.ShowDialog();
        }
    }
    }
}

