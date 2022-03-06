namespace SearchWordApp
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
            this.tbPathFile = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWordSearch = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPathFile
            // 
            this.tbPathFile.Location = new System.Drawing.Point(102, 79);
            this.tbPathFile.Name = "tbPathFile";
            this.tbPathFile.Size = new System.Drawing.Size(322, 23);
            this.tbPathFile.TabIndex = 0;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(430, 79);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(35, 23);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к  файлу";
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(102, 43);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(274, 23);
            this.tbWord.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Слово";
            // 
            // btnWordSearch
            // 
            this.btnWordSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWordSearch.Location = new System.Drawing.Point(349, 121);
            this.btnWordSearch.Name = "btnWordSearch";
            this.btnWordSearch.Size = new System.Drawing.Size(116, 33);
            this.btnWordSearch.TabIndex = 5;
            this.btnWordSearch.Text = "Поиск";
            this.btnWordSearch.UseVisualStyleBackColor = true;
            this.btnWordSearch.Click += new System.EventHandler(this.btnWordSearch_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.SystemColors.Control;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResult.ForeColor = System.Drawing.Color.Navy;
            this.lblResult.Location = new System.Drawing.Point(33, 129);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(65, 25);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 173);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnWordSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.tbPathFile);
            this.Name = "Form1";
            this.Text = "Поиск слова";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPathFile;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWordSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblResult;
    }
}
