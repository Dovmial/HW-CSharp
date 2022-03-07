namespace TextAnalizatorApp
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnAnalize = new System.Windows.Forms.Button();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.gbTypeReport = new System.Windows.Forms.GroupBox();
            this.rbFileCheck = new System.Windows.Forms.RadioButton();
            this.rbWindowCheck = new System.Windows.Forms.RadioButton();
            this.gbTypeReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(469, 329);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnAnalize
            // 
            this.btnAnalize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnalize.Location = new System.Drawing.Point(502, 89);
            this.btnAnalize.Name = "btnAnalize";
            this.btnAnalize.Size = new System.Drawing.Size(114, 36);
            this.btnAnalize.TabIndex = 1;
            this.btnAnalize.Text = "Analize";
            this.btnAnalize.UseVisualStyleBackColor = true;
            this.btnAnalize.Click += new System.EventHandler(this.btnAnalize_Click);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(502, 294);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(99, 23);
            this.btnShowReport.TabIndex = 2;
            this.btnShowReport.Text = "Show report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // gbTypeReport
            // 
            this.gbTypeReport.Controls.Add(this.rbWindowCheck);
            this.gbTypeReport.Controls.Add(this.rbFileCheck);
            this.gbTypeReport.Location = new System.Drawing.Point(487, 175);
            this.gbTypeReport.Name = "gbTypeReport";
            this.gbTypeReport.Size = new System.Drawing.Size(129, 100);
            this.gbTypeReport.TabIndex = 3;
            this.gbTypeReport.TabStop = false;
            this.gbTypeReport.Text = "Type report";
            // 
            // rbFileCheck
            // 
            this.rbFileCheck.AutoSize = true;
            this.rbFileCheck.Location = new System.Drawing.Point(23, 30);
            this.rbFileCheck.Name = "rbFileCheck";
            this.rbFileCheck.Size = new System.Drawing.Size(54, 19);
            this.rbFileCheck.TabIndex = 0;
            this.rbFileCheck.Text = "in file";
            this.rbFileCheck.UseVisualStyleBackColor = true;
            // 
            // rbWindowCheck
            // 
            this.rbWindowCheck.AutoSize = true;
            this.rbWindowCheck.Checked = true;
            this.rbWindowCheck.Location = new System.Drawing.Point(23, 60);
            this.rbWindowCheck.Name = "rbWindowCheck";
            this.rbWindowCheck.Size = new System.Drawing.Size(80, 19);
            this.rbWindowCheck.TabIndex = 1;
            this.rbWindowCheck.TabStop = true;
            this.rbWindowCheck.Text = "in window";
            this.rbWindowCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 485);
            this.Controls.Add(this.gbTypeReport);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.btnAnalize);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Text analizator";
            this.gbTypeReport.ResumeLayout(false);
            this.gbTypeReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnAnalize;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.GroupBox gbTypeReport;
        private System.Windows.Forms.RadioButton rbWindowCheck;
        private System.Windows.Forms.RadioButton rbFileCheck;
    }
}
