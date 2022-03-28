
namespace RandomOrgAPIAPP
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
            this.btnDice1Random = new System.Windows.Forms.Button();
            this.lblDice1Player1 = new System.Windows.Forms.Label();
            this.lblDice2Player1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblDice2Player2 = new System.Windows.Forms.Label();
            this.lblDice1Player2 = new System.Windows.Forms.Label();
            this.btnDice2Random = new System.Windows.Forms.Button();
            this.lblResultPlayer1 = new System.Windows.Forms.Label();
            this.lblResultPlayer2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAI = new System.Windows.Forms.RadioButton();
            this.rbHuman = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDice1Random
            // 
            this.btnDice1Random.Location = new System.Drawing.Point(55, 206);
            this.btnDice1Random.Name = "btnDice1Random";
            this.btnDice1Random.Size = new System.Drawing.Size(75, 23);
            this.btnDice1Random.TabIndex = 0;
            this.btnDice1Random.Text = "бросок";
            this.btnDice1Random.UseVisualStyleBackColor = true;
            this.btnDice1Random.Click += new System.EventHandler(this.btnDice1Random_Click);
            // 
            // lblDice1Player1
            // 
            this.lblDice1Player1.AutoSize = true;
            this.lblDice1Player1.Location = new System.Drawing.Point(36, 175);
            this.lblDice1Player1.Name = "lblDice1Player1";
            this.lblDice1Player1.Size = new System.Drawing.Size(34, 15);
            this.lblDice1Player1.TabIndex = 1;
            this.lblDice1Player1.Text = "none";
            // 
            // lblDice2Player1
            // 
            this.lblDice2Player1.AutoSize = true;
            this.lblDice2Player1.Location = new System.Drawing.Point(96, 175);
            this.lblDice2Player1.Name = "lblDice2Player1";
            this.lblDice2Player1.Size = new System.Drawing.Size(34, 15);
            this.lblDice2Player1.TabIndex = 2;
            this.lblDice2Player1.Text = "none";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "результат броска";
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(65, 150);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(50, 15);
            this.lblPlayer1.TabIndex = 4;
            this.lblPlayer1.Text = "Игрок 1";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(226, 150);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(50, 15);
            this.lblPlayer2.TabIndex = 5;
            this.lblPlayer2.Text = "Игрок 2";
            // 
            // lblDice2Player2
            // 
            this.lblDice2Player2.AutoSize = true;
            this.lblDice2Player2.Location = new System.Drawing.Point(260, 175);
            this.lblDice2Player2.Name = "lblDice2Player2";
            this.lblDice2Player2.Size = new System.Drawing.Size(34, 15);
            this.lblDice2Player2.TabIndex = 7;
            this.lblDice2Player2.Text = "none";
            // 
            // lblDice1Player2
            // 
            this.lblDice1Player2.AutoSize = true;
            this.lblDice1Player2.Location = new System.Drawing.Point(200, 175);
            this.lblDice1Player2.Name = "lblDice1Player2";
            this.lblDice1Player2.Size = new System.Drawing.Size(34, 15);
            this.lblDice1Player2.TabIndex = 6;
            this.lblDice1Player2.Text = "none";
            // 
            // btnDice2Random
            // 
            this.btnDice2Random.Location = new System.Drawing.Point(219, 206);
            this.btnDice2Random.Name = "btnDice2Random";
            this.btnDice2Random.Size = new System.Drawing.Size(75, 23);
            this.btnDice2Random.TabIndex = 8;
            this.btnDice2Random.Text = "бросок";
            this.btnDice2Random.UseVisualStyleBackColor = true;
            this.btnDice2Random.Click += new System.EventHandler(this.btnDice2Random_Click);
            // 
            // lblResultPlayer1
            // 
            this.lblResultPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultPlayer1.AutoSize = true;
            this.lblResultPlayer1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultPlayer1.Location = new System.Drawing.Point(141, 150);
            this.lblResultPlayer1.Name = "lblResultPlayer1";
            this.lblResultPlayer1.Size = new System.Drawing.Size(13, 15);
            this.lblResultPlayer1.TabIndex = 9;
            this.lblResultPlayer1.Text = "0";
            this.lblResultPlayer1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblResultPlayer2
            // 
            this.lblResultPlayer2.AutoSize = true;
            this.lblResultPlayer2.Location = new System.Drawing.Point(182, 150);
            this.lblResultPlayer2.Name = "lblResultPlayer2";
            this.lblResultPlayer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblResultPlayer2.Size = new System.Drawing.Size(13, 15);
            this.lblResultPlayer2.TabIndex = 10;
            this.lblResultPlayer2.Text = "0";
            this.lblResultPlayer2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = ":";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAI);
            this.groupBox1.Controls.Add(this.rbHuman);
            this.groupBox1.Location = new System.Drawing.Point(34, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 76);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим";
            // 
            // rbAI
            // 
            this.rbAI.AutoSize = true;
            this.rbAI.Location = new System.Drawing.Point(6, 51);
            this.rbAI.Name = "rbAI";
            this.rbAI.Size = new System.Drawing.Size(89, 19);
            this.rbAI.TabIndex = 1;
            this.rbAI.Text = "Компьютер";
            this.rbAI.UseVisualStyleBackColor = true;
            this.rbAI.CheckedChanged += new System.EventHandler(this.rbAI_CheckedChanged);
            // 
            // rbHuman
            // 
            this.rbHuman.AutoSize = true;
            this.rbHuman.Checked = true;
            this.rbHuman.Location = new System.Drawing.Point(6, 26);
            this.rbHuman.Name = "rbHuman";
            this.rbHuman.Size = new System.Drawing.Size(59, 19);
            this.rbHuman.TabIndex = 0;
            this.rbHuman.TabStop = true;
            this.rbHuman.Text = "Игрок";
            this.rbHuman.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 266);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblResultPlayer2);
            this.Controls.Add(this.lblResultPlayer1);
            this.Controls.Add(this.btnDice2Random);
            this.Controls.Add(this.lblDice2Player2);
            this.Controls.Add(this.lblDice1Player2);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDice2Player1);
            this.Controls.Add(this.lblDice1Player1);
            this.Controls.Add(this.btnDice1Random);
            this.Name = "Form1";
            this.Text = "Игральные кости";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDice1Random;
        private System.Windows.Forms.Label lblDice1Player1;
        private System.Windows.Forms.Label lblDice2Player1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblDice2Player2;
        private System.Windows.Forms.Label lblDice1Player2;
        private System.Windows.Forms.Button btnDice2Random;
        private System.Windows.Forms.Label lblResultPlayer1;
        private System.Windows.Forms.Label lblResultPlayer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAI;
        private System.Windows.Forms.RadioButton rbHuman;
    }
}

