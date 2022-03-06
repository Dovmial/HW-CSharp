namespace DancingProgressBarsApp
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCountProgressBars = new System.Windows.Forms.TextBox();
            this.btnStartProgressBars = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(122, 100);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "количество баров";
            // 
            // tbCountProgressBars
            // 
            this.tbCountProgressBars.Location = new System.Drawing.Point(29, 101);
            this.tbCountProgressBars.Name = "tbCountProgressBars";
            this.tbCountProgressBars.Size = new System.Drawing.Size(65, 23);
            this.tbCountProgressBars.TabIndex = 2;
            this.tbCountProgressBars.Text = "0";
            // 
            // btnStartProgressBars
            // 
            this.btnStartProgressBars.Location = new System.Drawing.Point(31, 139);
            this.btnStartProgressBars.Name = "btnStartProgressBars";
            this.btnStartProgressBars.Size = new System.Drawing.Size(75, 23);
            this.btnStartProgressBars.TabIndex = 3;
            this.btnStartProgressBars.Text = "Запуск";
            this.btnStartProgressBars.UseVisualStyleBackColor = true;
            this.btnStartProgressBars.Click += new System.EventHandler(this.btnStartProgressBars_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(122, 139);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 237);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStartProgressBars);
            this.Controls.Add(this.tbCountProgressBars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCountProgressBars;
        private System.Windows.Forms.Button btnStartProgressBars;
        private System.Windows.Forms.Button btnReset;
    }
}
