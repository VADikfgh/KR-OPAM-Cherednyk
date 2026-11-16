namespace KR_OPAM_Cherednyk
{
    partial class CarDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxCar = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrandModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTransmission = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFuel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEngineVolume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHorsepower = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnSelectPhoto = new System.Windows.Forms.Button();
            this.btnTestDrive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCar
            // 
            this.pictureBoxCar.Location = new System.Drawing.Point(343, 41);
            this.pictureBoxCar.Name = "pictureBoxCar";
            this.pictureBoxCar.Size = new System.Drawing.Size(246, 235);
            this.pictureBoxCar.TabIndex = 0;
            this.pictureBoxCar.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(65, 398);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(214, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Марка та модель";
            // 
            // txtBrandModel
            // 
            this.txtBrandModel.Location = new System.Drawing.Point(163, 41);
            this.txtBrandModel.Name = "txtBrandModel";
            this.txtBrandModel.Size = new System.Drawing.Size(100, 20);
            this.txtBrandModel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ціна ($)";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(163, 76);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 7;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "В наявності",
            "Продано",
            "Продано (Trade-In)"});
            this.cmbStatus.Location = new System.Drawing.Point(163, 115);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 21);
            this.cmbStatus.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Статус";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Колір";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(163, 156);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(100, 20);
            this.txtColor.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Коробка передач";
            // 
            // cmbTransmission
            // 
            this.cmbTransmission.FormattingEnabled = true;
            this.cmbTransmission.Items.AddRange(new object[] {
            "Механіка",
            "Автомат",
            "Робот",
            "Варіатор"});
            this.cmbTransmission.Location = new System.Drawing.Point(162, 190);
            this.cmbTransmission.Name = "cmbTransmission";
            this.cmbTransmission.Size = new System.Drawing.Size(100, 21);
            this.cmbTransmission.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Тип палива";
            // 
            // cmbFuel
            // 
            this.cmbFuel.FormattingEnabled = true;
            this.cmbFuel.Items.AddRange(new object[] {
            "Бензин",
            "Дизель",
            "Електро",
            "Гібрид"});
            this.cmbFuel.Location = new System.Drawing.Point(163, 224);
            this.cmbFuel.Name = "cmbFuel";
            this.cmbFuel.Size = new System.Drawing.Size(100, 21);
            this.cmbFuel.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Об\'єм двигуна (л)";
            // 
            // txtEngineVolume
            // 
            this.txtEngineVolume.Location = new System.Drawing.Point(163, 256);
            this.txtEngineVolume.Name = "txtEngineVolume";
            this.txtEngineVolume.Size = new System.Drawing.Size(100, 20);
            this.txtEngineVolume.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Потужність (к.с.)";
            // 
            // txtHorsepower
            // 
            this.txtHorsepower.Location = new System.Drawing.Point(163, 291);
            this.txtHorsepower.Name = "txtHorsepower";
            this.txtHorsepower.Size = new System.Drawing.Size(100, 20);
            this.txtHorsepower.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Опис";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(162, 360);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Рік випуску";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(162, 325);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 23;
            // 
            // btnSelectPhoto
            // 
            this.btnSelectPhoto.Location = new System.Drawing.Point(412, 318);
            this.btnSelectPhoto.Name = "btnSelectPhoto";
            this.btnSelectPhoto.Size = new System.Drawing.Size(92, 23);
            this.btnSelectPhoto.TabIndex = 24;
            this.btnSelectPhoto.Text = "Змінити фото";
            this.btnSelectPhoto.UseVisualStyleBackColor = true;
            this.btnSelectPhoto.Click += new System.EventHandler(this.btnSelectPhoto_Click);
            // 
            // btnTestDrive
            // 
            this.btnTestDrive.Location = new System.Drawing.Point(618, 398);
            this.btnTestDrive.Name = "btnTestDrive";
            this.btnTestDrive.Size = new System.Drawing.Size(123, 23);
            this.btnTestDrive.TabIndex = 25;
            this.btnTestDrive.Text = "Взяти на тест-драйв";
            this.btnTestDrive.UseVisualStyleBackColor = true;
            this.btnTestDrive.Click += new System.EventHandler(this.btnTestDrive_Click);
            // 
            // CarDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestDrive);
            this.Controls.Add(this.btnSelectPhoto);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtHorsepower);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEngineVolume);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbFuel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTransmission);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBrandModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pictureBoxCar);
            this.Name = "CarDetailsForm";
            this.Text = "CarDetailsForm";
            this.Load += new System.EventHandler(this.CarDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCar;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrandModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTransmission;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFuel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEngineVolume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHorsepower;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnSelectPhoto;
        private System.Windows.Forms.Button btnTestDrive;
    }
}