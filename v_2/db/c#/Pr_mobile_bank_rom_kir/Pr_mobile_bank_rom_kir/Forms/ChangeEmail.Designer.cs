namespace Pr_mobile_bank_rom_kir.Forms
{
    partial class ChangeEmail
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
            this.label2 = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.changeEmailButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите новую почту";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(145, 14);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(229, 20);
            this.EmailTextBox.TabIndex = 4;
            // 
            // changeEmailButton
            // 
            this.changeEmailButton.Location = new System.Drawing.Point(145, 40);
            this.changeEmailButton.Name = "changeEmailButton";
            this.changeEmailButton.Size = new System.Drawing.Size(229, 23);
            this.changeEmailButton.TabIndex = 3;
            this.changeEmailButton.Text = "Изменить почту";
            this.changeEmailButton.UseVisualStyleBackColor = true;
            this.changeEmailButton.Click += new System.EventHandler(this.changeEmailButton_Click);
            // 
            // ChangeEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 162);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.changeEmailButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button changeEmailButton;
    }
}