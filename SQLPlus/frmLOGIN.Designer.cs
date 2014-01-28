namespace SQLPlus
{
    partial class frmLOGIN
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSUNUCU_ADI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKULLANICI_ADI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSIFRESI = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunucu Adı";
            // 
            // txtSUNUCU_ADI
            // 
            this.txtSUNUCU_ADI.Location = new System.Drawing.Point(91, 29);
            this.txtSUNUCU_ADI.Name = "txtSUNUCU_ADI";
            this.txtSUNUCU_ADI.Size = new System.Drawing.Size(100, 20);
            this.txtSUNUCU_ADI.TabIndex = 1;
            this.txtSUNUCU_ADI.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // txtKULLANICI_ADI
            // 
            this.txtKULLANICI_ADI.Location = new System.Drawing.Point(91, 55);
            this.txtKULLANICI_ADI.Name = "txtKULLANICI_ADI";
            this.txtKULLANICI_ADI.Size = new System.Drawing.Size(100, 20);
            this.txtKULLANICI_ADI.TabIndex = 3;
            this.txtKULLANICI_ADI.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Şifesi";
            // 
            // txtSIFRESI
            // 
            this.txtSIFRESI.Location = new System.Drawing.Point(91, 82);
            this.txtSIFRESI.Name = "txtSIFRESI";
            this.txtSIFRESI.Size = new System.Drawing.Size(100, 20);
            this.txtSIFRESI.TabIndex = 5;
            this.txtSIFRESI.Text = "123";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(44, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(139, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Vazgeç";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmLOGIN
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(242, 162);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSIFRESI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKULLANICI_ADI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSUNUCU_ADI);
            this.Controls.Add(this.label1);
            this.Name = "frmLOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server Giriş";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txtSUNUCU_ADI;
        public System.Windows.Forms.TextBox txtKULLANICI_ADI;
        public System.Windows.Forms.TextBox txtSIFRESI;
    }
}