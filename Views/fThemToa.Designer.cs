namespace QLSV.Views.UC
{
    partial class fThemToa
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
            this.txthoTen = new System.Windows.Forms.TextBox();
            this.txtQuanli = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbToaQuanLi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txthoTen
            // 
            this.txthoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoTen.Location = new System.Drawing.Point(119, 49);
            this.txthoTen.Margin = new System.Windows.Forms.Padding(2);
            this.txthoTen.Name = "txthoTen";
            this.txthoTen.Size = new System.Drawing.Size(145, 24);
            this.txthoTen.TabIndex = 175;
            // 
            // txtQuanli
            // 
            this.txtQuanli.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuanli.Location = new System.Drawing.Point(119, 11);
            this.txtQuanli.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuanli.Name = "txtQuanli";
            this.txtQuanli.Size = new System.Drawing.Size(145, 24);
            this.txtQuanli.TabIndex = 174;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(481, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 55);
            this.button2.TabIndex = 173;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 55);
            this.button1.TabIndex = 172;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbToaQuanLi
            // 
            this.cbToaQuanLi.FormattingEnabled = true;
            this.cbToaQuanLi.Location = new System.Drawing.Point(445, 11);
            this.cbToaQuanLi.Name = "cbToaQuanLi";
            this.cbToaQuanLi.Size = new System.Drawing.Size(145, 21);
            this.cbToaQuanLi.TabIndex = 171;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 169;
            this.label2.Text = "Tên Tòa";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(336, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 168;
            this.label1.Text = "Giới tính";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(11, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 23);
            this.label16.TabIndex = 167;
            this.label16.Text = "Mã Tòa";
            // 
            // fThemToa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 202);
            this.Controls.Add(this.txthoTen);
            this.Controls.Add(this.txtQuanli);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbToaQuanLi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Name = "fThemToa";
            this.Text = "fThemToa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txthoTen;
        private System.Windows.Forms.TextBox txtQuanli;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbToaQuanLi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
    }
}