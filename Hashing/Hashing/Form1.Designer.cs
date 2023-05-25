namespace Hashing
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnEcrypt = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PassEncr = new System.Windows.Forms.TextBox();
            this.EncrMessageOut = new System.Windows.Forms.TextBox();
            this.EncrMessageIn = new System.Windows.Forms.TextBox();
            this.PassDecr = new System.Windows.Forms.TextBox();
            this.DecrMessageOut = new System.Windows.Forms.TextBox();
            this.BtnDecrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnEcrypt
            // 
            this.BtnEcrypt.Location = new System.Drawing.Point(153, 151);
            this.BtnEcrypt.Name = "BtnEcrypt";
            this.BtnEcrypt.Size = new System.Drawing.Size(191, 23);
            this.BtnEcrypt.TabIndex = 0;
            this.BtnEcrypt.Text = "Encrypt";
            this.BtnEcrypt.UseVisualStyleBackColor = true;
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(153, 42);
            this.Message.Multiline = true;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(191, 51);
            this.Message.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Message";
            // 
            // PassEncr
            // 
            this.PassEncr.Location = new System.Drawing.Point(153, 114);
            this.PassEncr.Name = "PassEncr";
            this.PassEncr.Size = new System.Drawing.Size(191, 20);
            this.PassEncr.TabIndex = 3;
            // 
            // EncrMessageOut
            // 
            this.EncrMessageOut.Location = new System.Drawing.Point(504, 42);
            this.EncrMessageOut.Multiline = true;
            this.EncrMessageOut.Name = "EncrMessageOut";
            this.EncrMessageOut.Size = new System.Drawing.Size(191, 51);
            this.EncrMessageOut.TabIndex = 4;
            // 
            // EncrMessageIn
            // 
            this.EncrMessageIn.Location = new System.Drawing.Point(153, 259);
            this.EncrMessageIn.Multiline = true;
            this.EncrMessageIn.Name = "EncrMessageIn";
            this.EncrMessageIn.Size = new System.Drawing.Size(191, 50);
            this.EncrMessageIn.TabIndex = 5;
            // 
            // PassDecr
            // 
            this.PassDecr.Location = new System.Drawing.Point(153, 318);
            this.PassDecr.Name = "PassDecr";
            this.PassDecr.Size = new System.Drawing.Size(191, 20);
            this.PassDecr.TabIndex = 6;
            // 
            // DecrMessageOut
            // 
            this.DecrMessageOut.Location = new System.Drawing.Point(504, 259);
            this.DecrMessageOut.Multiline = true;
            this.DecrMessageOut.Name = "DecrMessageOut";
            this.DecrMessageOut.Size = new System.Drawing.Size(191, 50);
            this.DecrMessageOut.TabIndex = 7;
            // 
            // BtnDecrypt
            // 
            this.BtnDecrypt.Location = new System.Drawing.Point(153, 362);
            this.BtnDecrypt.Name = "BtnDecrypt";
            this.BtnDecrypt.Size = new System.Drawing.Size(191, 23);
            this.BtnDecrypt.TabIndex = 8;
            this.BtnDecrypt.Text = "Decrypt";
            this.BtnDecrypt.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Encrypted message";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Encrypted message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Decrypted message";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnDecrypt);
            this.Controls.Add(this.DecrMessageOut);
            this.Controls.Add(this.PassDecr);
            this.Controls.Add(this.EncrMessageIn);
            this.Controls.Add(this.EncrMessageOut);
            this.Controls.Add(this.PassEncr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.BtnEcrypt);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEcrypt;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PassEncr;
        private System.Windows.Forms.TextBox EncrMessageOut;
        private System.Windows.Forms.TextBox EncrMessageIn;
        private System.Windows.Forms.TextBox PassDecr;
        private System.Windows.Forms.TextBox DecrMessageOut;
        private System.Windows.Forms.Button BtnDecrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

