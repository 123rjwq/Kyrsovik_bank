namespace Pr_mobile_bank_rom_kir.Forms
{
    partial class PhoneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTotalSum = new System.Windows.Forms.Label();
            this.labelCommission = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TextBoxCvv = new System.Windows.Forms.TextBox();
            this.TextBoxCardTo = new System.Windows.Forms.TextBox();
            this.TextBoxCard = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonSendToPhone = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(61, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пополнение мобильного";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тел.:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(78, 60);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(205, 20);
            this.textBoxNumber.TabIndex = 3;
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Items.AddRange(new object[] {
            "MTS",
            "Tele2",
            "Beeline",
            "Megafon"});
            this.comboBoxOperator.Location = new System.Drawing.Point(290, 58);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOperator.TabIndex = 4;
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(78, 105);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(205, 20);
            this.textBoxSum.TabIndex = 5;
            this.textBoxSum.TextChanged += new System.EventHandler(this.textBoxSum_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сумма:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(287, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "currency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(107, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "К оплате:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(107, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Комиссия:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(289, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "RUB";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(289, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "RUB";
            // 
            // labelTotalSum
            // 
            this.labelTotalSum.AutoSize = true;
            this.labelTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalSum.Location = new System.Drawing.Point(238, 176);
            this.labelTotalSum.Name = "labelTotalSum";
            this.labelTotalSum.Size = new System.Drawing.Size(14, 16);
            this.labelTotalSum.TabIndex = 12;
            this.labelTotalSum.Text = "0";
            // 
            // labelCommission
            // 
            this.labelCommission.AutoSize = true;
            this.labelCommission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCommission.Location = new System.Drawing.Point(238, 141);
            this.labelCommission.Name = "labelCommission";
            this.labelCommission.Size = new System.Drawing.Size(14, 16);
            this.labelCommission.TabIndex = 13;
            this.labelCommission.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.TextBoxCvv);
            this.panel1.Controls.Add(this.TextBoxCardTo);
            this.panel1.Controls.Add(this.TextBoxCard);
            this.panel1.Location = new System.Drawing.Point(84, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 226);
            this.panel1.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(37, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "CVV-код";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(37, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "Срок действия";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(37, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "Номер карты";
            // 
            // TextBoxCvv
            // 
            this.TextBoxCvv.Location = new System.Drawing.Point(37, 170);
            this.TextBoxCvv.Name = "TextBoxCvv";
            this.TextBoxCvv.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCvv.TabIndex = 2;
            this.TextBoxCvv.TextChanged += new System.EventHandler(this.TextBoxCvv_TextChanged);
            // 
            // TextBoxCardTo
            // 
            this.TextBoxCardTo.Location = new System.Drawing.Point(37, 105);
            this.TextBoxCardTo.Name = "TextBoxCardTo";
            this.TextBoxCardTo.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCardTo.TabIndex = 1;
            // 
            // TextBoxCard
            // 
            this.TextBoxCard.Location = new System.Drawing.Point(37, 31);
            this.TextBoxCard.Name = "TextBoxCard";
            this.TextBoxCard.Size = new System.Drawing.Size(247, 20);
            this.TextBoxCard.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(8, 234);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 101;
            this.label14.Text = "С карты:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(5, 221);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(647, 13);
            this.label15.TabIndex = 103;
            this.label15.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------------------------------------------------------";
            // 
            // buttonSendToPhone
            // 
            this.buttonSendToPhone.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonSendToPhone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSendToPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSendToPhone.ForeColor = System.Drawing.Color.Transparent;
            this.buttonSendToPhone.Location = new System.Drawing.Point(150, 507);
            this.buttonSendToPhone.Name = "buttonSendToPhone";
            this.buttonSendToPhone.Size = new System.Drawing.Size(289, 31);
            this.buttonSendToPhone.TabIndex = 104;
            this.buttonSendToPhone.Text = "Пополнить";
            this.buttonSendToPhone.UseVisualStyleBackColor = false;
            this.buttonSendToPhone.Click += new System.EventHandler(this.buttonSendToPhone_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tele2 - 52",
            "Beeline - 03 09 60 76",
            "Megafon - 20 26 27 37",
            "MTS - 14 18 13 19"});
            this.comboBox1.Location = new System.Drawing.Point(433, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 105;
            // 
            // PhoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 579);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonSendToPhone);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labelCommission);
            this.Controls.Add(this.labelTotalSum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.comboBoxOperator);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PhoneForm";
            this.Text = "PhoneForm";
            this.Load += new System.EventHandler(this.PhoneForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTotalSum;
        private System.Windows.Forms.Label labelCommission;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TextBoxCvv;
        private System.Windows.Forms.TextBox TextBoxCardTo;
        private System.Windows.Forms.TextBox TextBoxCard;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonSendToPhone;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}