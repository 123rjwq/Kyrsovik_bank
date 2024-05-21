namespace Pr_mobile_bank_rom_kir.Forms
{
    partial class Validation
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
            this.label1 = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.numericUpDownPin = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 97;
            this.label1.Text = "Введите ваш Pin-код";
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.YellowGreen;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.ForeColor = System.Drawing.Color.Transparent;
            this.SendButton.Location = new System.Drawing.Point(25, 57);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(289, 31);
            this.SendButton.TabIndex = 100;
            this.SendButton.Text = "ОК";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // numericUpDownPin
            // 
            this.numericUpDownPin.Location = new System.Drawing.Point(154, 19);
            this.numericUpDownPin.Name = "numericUpDownPin";
            this.numericUpDownPin.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPin.TabIndex = 101;
            // 
            // Validation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(326, 97);
            this.Controls.Add(this.numericUpDownPin);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Validation";
            this.Text = "Validation";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.NumericUpDown numericUpDownPin;
    }
}