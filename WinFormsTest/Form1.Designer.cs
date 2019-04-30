namespace WinFormsTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxFirstCtrlText = new System.Windows.Forms.GroupBox();
            this.linkEnglish = new System.Windows.Forms.LinkLabel();
            this.linkRussian = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // groupBoxFirstCtrlText
            // 
            this.groupBoxFirstCtrlText.Location = new System.Drawing.Point(30, 36);
            this.groupBoxFirstCtrlText.Name = "groupBoxFirstCtrlText";
            this.groupBoxFirstCtrlText.Size = new System.Drawing.Size(318, 225);
            this.groupBoxFirstCtrlText.TabIndex = 0;
            this.groupBoxFirstCtrlText.TabStop = false;
            this.groupBoxFirstCtrlText.Text = "groupBox1";
            // 
            // linkEnglish
            // 
            this.linkEnglish.AutoSize = true;
            this.linkEnglish.Location = new System.Drawing.Point(511, 26);
            this.linkEnglish.Name = "linkEnglish";
            this.linkEnglish.Size = new System.Drawing.Size(55, 13);
            this.linkEnglish.TabIndex = 1;
            this.linkEnglish.TabStop = true;
            this.linkEnglish.Text = "linkLabel1";
            this.linkEnglish.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEnglish_LinkClicked);
            // 
            // linkRussian
            // 
            this.linkRussian.AutoSize = true;
            this.linkRussian.Location = new System.Drawing.Point(511, 48);
            this.linkRussian.Name = "linkRussian";
            this.linkRussian.Size = new System.Drawing.Size(55, 13);
            this.linkRussian.TabIndex = 2;
            this.linkRussian.TabStop = true;
            this.linkRussian.Text = "linkLabel1";
            this.linkRussian.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRussian_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 434);
            this.Controls.Add(this.linkRussian);
            this.Controls.Add(this.linkEnglish);
            this.Controls.Add(this.groupBoxFirstCtrlText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFirstCtrlText;
        private System.Windows.Forms.LinkLabel linkEnglish;
        private System.Windows.Forms.LinkLabel linkRussian;
    }
}

