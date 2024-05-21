namespace Pr_mobile_bank_rom_kir.Forms
{
    partial class SendToForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxCvv = new System.Windows.Forms.TextBox();
            this.TextBoxCardTo = new System.Windows.Forms.TextBox();
            this.TextBoxCard = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBoxCardDestination = new System.Windows.Forms.TextBox();
            this.TextBoxSum = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 96;
            this.label1.Text = "С карты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 97;
            this.label2.Text = "карта получателя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(41, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 98;
            this.label3.Text = "Сумма";
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.YellowGreen;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.ForeColor = System.Drawing.Color.Transparent;
            this.SendButton.Location = new System.Drawing.Point(333, 498);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(289, 31);
            this.SendButton.TabIndex = 99;
            this.SendButton.Text = "Перевести";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TextBoxCvv);
            this.panel1.Controls.Add(this.TextBoxCardTo);
            this.panel1.Controls.Add(this.TextBoxCard);
            this.panel1.Location = new System.Drawing.Point(165, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 219);
            this.panel1.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(37, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "CVV-код";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(37, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Срок действия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(37, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Номер карты";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.TextBoxCardDestination);
            this.panel2.Location = new System.Drawing.Point(165, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 137);
            this.panel2.TabIndex = 101;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(25, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Номер карты";
            // 
            // TextBoxCardDestination
            // 
            this.TextBoxCardDestination.Location = new System.Drawing.Point(116, 46);
            this.TextBoxCardDestination.Name = "TextBoxCardDestination";
            this.TextBoxCardDestination.Size = new System.Drawing.Size(185, 20);
            this.TextBoxCardDestination.TabIndex = 0;
            // 
            // TextBoxSum
            // 
            this.TextBoxSum.Location = new System.Drawing.Point(165, 455);
            this.TextBoxSum.Name = "TextBoxSum";
            this.TextBoxSum.Size = new System.Drawing.Size(100, 20);
            this.TextBoxSum.TabIndex = 102;
            // 
            // SendToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(661, 565);
            this.Controls.Add(this.TextBoxSum);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SendToForm";
            this.Text = "SendToForm";
            this.Load += new System.EventHandler(this.SendToForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SendToForm_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TextBoxSum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxCvv;
        private System.Windows.Forms.TextBox TextBoxCardTo;
        private System.Windows.Forms.TextBox TextBoxCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBoxCardDestination;
    }
}