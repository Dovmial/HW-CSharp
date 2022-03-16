
namespace CensoredWordsApp
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
            this.btnDirectory = new System.Windows.Forms.Button();
            this.tbDirectoryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLoadCensoredWords = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCensoredWordsSource = new System.Windows.Forms.TextBox();
            this.btnFileCensoredPath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStopwatch = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClearStatistic = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(445, 179);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(26, 23);
            this.btnDirectory.TabIndex = 0;
            this.btnDirectory.Text = "...";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // tbDirectoryPath
            // 
            this.tbDirectoryPath.Location = new System.Drawing.Point(28, 179);
            this.tbDirectoryPath.Name = "tbDirectoryPath";
            this.tbDirectoryPath.ReadOnly = true;
            this.tbDirectoryPath.Size = new System.Drawing.Size(411, 23);
            this.tbDirectoryPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Check directory";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(356, 274);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(115, 59);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Filter";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnLoadCensoredWords
            // 
            this.btnLoadCensoredWords.Location = new System.Drawing.Point(28, 80);
            this.btnLoadCensoredWords.Name = "btnLoadCensoredWords";
            this.btnLoadCensoredWords.Size = new System.Drawing.Size(134, 40);
            this.btnLoadCensoredWords.TabIndex = 4;
            this.btnLoadCensoredWords.Text = "Load Censored Words";
            this.btnLoadCensoredWords.UseVisualStyleBackColor = true;
            this.btnLoadCensoredWords.Click += new System.EventHandler(this.btnLoadCensoredWords_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Censored words file (source)";
            // 
            // tbCensoredWordsSource
            // 
            this.tbCensoredWordsSource.Location = new System.Drawing.Point(28, 51);
            this.tbCensoredWordsSource.Name = "tbCensoredWordsSource";
            this.tbCensoredWordsSource.ReadOnly = true;
            this.tbCensoredWordsSource.Size = new System.Drawing.Size(411, 23);
            this.tbCensoredWordsSource.TabIndex = 6;
            // 
            // btnFileCensoredPath
            // 
            this.btnFileCensoredPath.Location = new System.Drawing.Point(445, 51);
            this.btnFileCensoredPath.Name = "btnFileCensoredPath";
            this.btnFileCensoredPath.Size = new System.Drawing.Size(26, 23);
            this.btnFileCensoredPath.TabIndex = 5;
            this.btnFileCensoredPath.Text = "...";
            this.btnFileCensoredPath.UseVisualStyleBackColor = true;
            this.btnFileCensoredPath.Click += new System.EventHandler(this.btnFileCensoredPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Location = new System.Drawing.Point(28, 295);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(75, 23);
            this.btnPauseResume.TabIndex = 9;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status";
            // 
            // lblStopwatch
            // 
            this.lblStopwatch.AutoSize = true;
            this.lblStopwatch.Location = new System.Drawing.Point(178, 318);
            this.lblStopwatch.Name = "lblStopwatch";
            this.lblStopwatch.Size = new System.Drawing.Size(17, 15);
            this.lblStopwatch.TabIndex = 11;
            this.lblStopwatch.Text = "\"\"";
            // 
            // btnStop
            // 
            this.btnStop.ForeColor = System.Drawing.Color.Maroon;
            this.btnStop.Location = new System.Drawing.Point(28, 334);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClearStatistic
            // 
            this.btnClearStatistic.Location = new System.Drawing.Point(364, 342);
            this.btnClearStatistic.Name = "btnClearStatistic";
            this.btnClearStatistic.Size = new System.Drawing.Size(97, 23);
            this.btnClearStatistic.TabIndex = 13;
            this.btnClearStatistic.Text = "Clear statistic";
            this.btnClearStatistic.UseVisualStyleBackColor = true;
            this.btnClearStatistic.Click += new System.EventHandler(this.btnClearStatistic_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 227);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(440, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 393);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnClearStatistic);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblStopwatch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCensoredWordsSource);
            this.Controls.Add(this.btnFileCensoredPath);
            this.Controls.Add(this.btnLoadCensoredWords);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDirectoryPath);
            this.Controls.Add(this.btnDirectory);
            this.Name = "Form1";
            this.Text = "Filter Censored Words";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.TextBox tbDirectoryPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLoadCensoredWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCensoredWordsSource;
        private System.Windows.Forms.Button btnFileCensoredPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStopwatch;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClearStatistic;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

