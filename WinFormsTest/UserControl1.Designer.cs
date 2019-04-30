namespace WinFormsTest
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxInside1stCtrl = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBoxInside1stCtrl
            // 
            this.groupBoxInside1stCtrl.Location = new System.Drawing.Point(26, 72);
            this.groupBoxInside1stCtrl.Name = "groupBoxInside1stCtrl";
            this.groupBoxInside1stCtrl.Size = new System.Drawing.Size(238, 143);
            this.groupBoxInside1stCtrl.TabIndex = 0;
            this.groupBoxInside1stCtrl.TabStop = false;
            this.groupBoxInside1stCtrl.Text = "groupBox1";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBoxInside1stCtrl);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(303, 259);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInside1stCtrl;
    }
}
