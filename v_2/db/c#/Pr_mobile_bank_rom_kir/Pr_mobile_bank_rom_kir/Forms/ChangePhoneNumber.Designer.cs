namespace Pr_mobile_bank_rom_kir.Forms
{
    partial class ChangePhoneNumber
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
            this.changePhoneButton = new System.Windows.Forms.Button();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changePhoneButton
            // 
            this.changePhoneButton.Location = new System.Drawing.Point(189, 49);
            this.changePhoneButton.Name = "changePhoneButton";
            this.changePhoneButton.Size = new System.Drawing.Size(181, 23);
            this.changePhoneButton.TabIndex = 0;
            this.changePhoneButton.Text = "Изменить номер телефона";
            this.changePhoneButton.UseVisualStyleBackColor = true;
            this.changePhoneButton.Click += new System.EventHandler(this.changePhoneButton_Click);
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(189, 23);
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(181, 20);
            this.NumberTextBox.TabIndex = 1;
            this.NumberTextBox.TextChanged += new System.EventHandler(this.NumberTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите новый номер телефона";
            // 
            // ChangePhoneNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 172);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberTextBox);
            this.Controls.Add(this.changePhoneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangePhoneNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePhoneNumber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changePhoneButton;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Label label1;
    }
}