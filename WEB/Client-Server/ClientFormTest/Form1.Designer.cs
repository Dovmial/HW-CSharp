
namespace ClientFormTest
{
    partial class ServerForm
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
            this.rtbSendClient = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbServerAnswear = new System.Windows.Forms.RichTextBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbSendClient
            // 
            this.rtbSendClient.Location = new System.Drawing.Point(12, 41);
            this.rtbSendClient.Name = "rtbSendClient";
            this.rtbSendClient.Size = new System.Drawing.Size(313, 161);
            this.rtbSendClient.TabIndex = 0;
            this.rtbSendClient.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "send message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbServerAnswear
            // 
            this.rtbServerAnswear.Location = new System.Drawing.Point(331, 41);
            this.rtbServerAnswear.Name = "rtbServerAnswear";
            this.rtbServerAnswear.ReadOnly = true;
            this.rtbServerAnswear.Size = new System.Drawing.Size(328, 328);
            this.rtbServerAnswear.TabIndex = 2;
            this.rtbServerAnswear.Text = "";
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(123, 226);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(38, 15);
            this.lblHelp.TabIndex = 3;
            this.lblHelp.Text = "label1";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 381);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.rtbServerAnswear);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbSendClient);
            this.Name = "ServerForm";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSendClient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbServerAnswear;
        private System.Windows.Forms.Label lblHelp;
    }
}

