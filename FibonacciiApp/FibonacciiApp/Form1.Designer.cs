namespace FibonacciiApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFibonacci = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFibonacci
            // 
            this.btnFibonacci.Location = new System.Drawing.Point(131, 81);
            this.btnFibonacci.Name = "btnFibonacci";
            this.btnFibonacci.Size = new System.Drawing.Size(85, 39);
            this.btnFibonacci.TabIndex = 0;
            this.btnFibonacci.Text = "Фибоначчи генератор";
            this.btnFibonacci.UseVisualStyleBackColor = true;
            this.btnFibonacci.Click += new System.EventHandler(this.btnFibonacci_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "минимум";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "максимум";
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(83, 23);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(133, 23);
            this.tbMin.TabIndex = 3;
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(83, 52);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(133, 23);
            this.tbMax.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(222, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(308, 264);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // btnSuspend
            // 
            this.btnSuspend.Location = new System.Drawing.Point(105, 215);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(111, 23);
            this.btnSuspend.TabIndex = 6;
            this.btnSuspend.Text = "Приостановить";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(105, 244);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(111, 23);
            this.btnResume.TabIndex = 7;
            this.btnResume.Text = "Продолжить";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Задержка потока";
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(12, 126);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(100, 23);
            this.tbDelay.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "мс";
            // 
            // btnDelay
            // 
            this.btnDelay.Location = new System.Drawing.Point(12, 155);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(63, 23);
            this.btnDelay.TabIndex = 11;
            this.btnDelay.Text = "Принять";
            this.btnDelay.UseVisualStyleBackColor = true;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(105, 186);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(111, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Остановить";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 299);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnDelay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDelay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFibonacci);
            this.Name = "Form1";
            this.Text = "Fibonacii Sequence";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnFibonacci;
        private Label label1;
        private Label label2;
        private TextBox tbMin;
        private TextBox tbMax;
        private RichTextBox richTextBox1;
        private Button btnSuspend;
        private Button btnResume;
        private Label label3;
        private TextBox tbDelay;
        private Label label4;
        private Button btnDelay;
        private Button btnStop;
    }
}