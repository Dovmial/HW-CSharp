
namespace ClientSubscriber
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
            this.btnSubsribe = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEconomics = new System.Windows.Forms.RadioButton();
            this.rbSport = new System.Windows.Forms.RadioButton();
            this.rbPolit = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(19, 122);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(325, 234);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnSubsribe
            // 
            this.btnSubsribe.Location = new System.Drawing.Point(223, 57);
            this.btnSubsribe.Name = "btnSubsribe";
            this.btnSubsribe.Size = new System.Drawing.Size(75, 23);
            this.btnSubsribe.TabIndex = 1;
            this.btnSubsribe.Text = "Запрос";
            this.btnSubsribe.UseVisualStyleBackColor = true;
            this.btnSubsribe.Click += new System.EventHandler(this.btnSubsribe_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEconomics);
            this.groupBox1.Controls.Add(this.rbSport);
            this.groupBox1.Controls.Add(this.rbPolit);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 104);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тематика";
            // 
            // rbEconomics
            // 
            this.rbEconomics.AutoSize = true;
            this.rbEconomics.Location = new System.Drawing.Point(7, 75);
            this.rbEconomics.Name = "rbEconomics";
            this.rbEconomics.Size = new System.Drawing.Size(87, 19);
            this.rbEconomics.TabIndex = 2;
            this.rbEconomics.TabStop = true;
            this.rbEconomics.Text = "Экономика";
            this.rbEconomics.UseVisualStyleBackColor = true;
            // 
            // rbSport
            // 
            this.rbSport.AutoSize = true;
            this.rbSport.Location = new System.Drawing.Point(7, 49);
            this.rbSport.Name = "rbSport";
            this.rbSport.Size = new System.Drawing.Size(59, 19);
            this.rbSport.TabIndex = 1;
            this.rbSport.TabStop = true;
            this.rbSport.Text = "Спорт";
            this.rbSport.UseVisualStyleBackColor = true;
            // 
            // rbPolit
            // 
            this.rbPolit.AutoSize = true;
            this.rbPolit.Location = new System.Drawing.Point(7, 23);
            this.rbPolit.Name = "rbPolit";
            this.rbPolit.Size = new System.Drawing.Size(79, 19);
            this.rbPolit.TabIndex = 0;
            this.rbPolit.TabStop = true;
            this.rbPolit.Text = "Политика";
            this.rbPolit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubsribe);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Обзорщик новостей";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSubsribe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEconomics;
        private System.Windows.Forms.RadioButton rbSport;
        private System.Windows.Forms.RadioButton rbPolit;
    }
}

