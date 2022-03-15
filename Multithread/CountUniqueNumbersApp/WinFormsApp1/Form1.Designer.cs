namespace WinFormsApp1
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
            this.btnLoadNumbers = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseFileSource = new System.Windows.Forms.Button();
            this.lblCountElements = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadNumbers
            // 
            this.btnLoadNumbers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoadNumbers.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLoadNumbers.Location = new System.Drawing.Point(333, 73);
            this.btnLoadNumbers.Name = "btnLoadNumbers";
            this.btnLoadNumbers.Size = new System.Drawing.Size(151, 36);
            this.btnLoadNumbers.TabIndex = 0;
            this.btnLoadNumbers.Text = "Load numbers";
            this.btnLoadNumbers.UseVisualStyleBackColor = true;
            this.btnLoadNumbers.Click += new System.EventHandler(this.btnLoadNumbers_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.Location = new System.Drawing.Point(62, 32);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.ReadOnly = true;
            this.tbSourceFile.Size = new System.Drawing.Size(382, 23);
            this.tbSourceFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "path: ";
            // 
            // btnChooseFileSource
            // 
            this.btnChooseFileSource.Location = new System.Drawing.Point(450, 32);
            this.btnChooseFileSource.Name = "btnChooseFileSource";
            this.btnChooseFileSource.Size = new System.Drawing.Size(34, 23);
            this.btnChooseFileSource.TabIndex = 3;
            this.btnChooseFileSource.Text = "...";
            this.btnChooseFileSource.UseVisualStyleBackColor = true;
            this.btnChooseFileSource.Click += new System.EventHandler(this.btnChooseFileSource_Click);
            // 
            // lblCountElements
            // 
            this.lblCountElements.AutoSize = true;
            this.lblCountElements.Location = new System.Drawing.Point(39, 129);
            this.lblCountElements.Name = "lblCountElements";
            this.lblCountElements.Size = new System.Drawing.Size(98, 15);
            this.lblCountElements.TabIndex = 4;
            this.lblCountElements.Text = "Count unique:   0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 216);
            this.Controls.Add(this.lblCountElements);
            this.Controls.Add(this.btnChooseFileSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSourceFile);
            this.Controls.Add(this.btnLoadNumbers);
            this.Name = "Form1";
            this.Text = "Count unique numbers from file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadNumbers;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseFileSource;
        private System.Windows.Forms.Label lblCountElements;
    }
}
