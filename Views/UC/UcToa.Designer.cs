namespace QLSV.Views.UC
{
    partial class UcToa
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
            this.txtToaQuanLi = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txthoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuanli = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtgvToa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvToa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtToaQuanLi
            // 
            this.txtToaQuanLi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToaQuanLi.Location = new System.Drawing.Point(437, 7);
            this.txtToaQuanLi.Margin = new System.Windows.Forms.Padding(2);
            this.txtToaQuanLi.Name = "txtToaQuanLi";
            this.txtToaQuanLi.Size = new System.Drawing.Size(145, 24);
            this.txtToaQuanLi.TabIndex = 168;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(486, 102);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 23);
            this.btnSua.TabIndex = 167;
            this.btnSua.Text = "Sửa Tòa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(384, 102);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 23);
            this.btnThem.TabIndex = 165;
            this.btnThem.Text = "Thêm Tòa";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txthoTen
            // 
            this.txthoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoTen.Location = new System.Drawing.Point(111, 46);
            this.txthoTen.Margin = new System.Windows.Forms.Padding(2);
            this.txthoTen.Name = "txthoTen";
            this.txthoTen.Size = new System.Drawing.Size(145, 24);
            this.txthoTen.TabIndex = 162;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 161;
            this.label2.Text = "Tên Tòa";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(344, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 160;
            this.label1.Text = "Giới tính";
            // 
            // txtQuanli
            // 
            this.txtQuanli.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuanli.Location = new System.Drawing.Point(111, 8);
            this.txtQuanli.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuanli.Name = "txtQuanli";
            this.txtQuanli.Size = new System.Drawing.Size(145, 24);
            this.txtQuanli.TabIndex = 159;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(3, 8);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 23);
            this.label16.TabIndex = 158;
            this.label16.Text = "Mã Tòa";
            // 
            // dtgvToa
            // 
            this.dtgvToa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvToa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvToa.Location = new System.Drawing.Point(2, 130);
            this.dtgvToa.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvToa.Name = "dtgvToa";
            this.dtgvToa.ReadOnly = true;
            this.dtgvToa.RowHeadersWidth = 51;
            this.dtgvToa.RowTemplate.Height = 24;
            this.dtgvToa.Size = new System.Drawing.Size(590, 235);
            this.dtgvToa.TabIndex = 157;
            this.dtgvToa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvToa_CellClick);
            // 
            // UcToa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtToaQuanLi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txthoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuanli);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtgvToa);
            this.Name = "UcToa";
            this.Size = new System.Drawing.Size(594, 372);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvToa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtToaQuanLi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txthoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuanli;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dtgvToa;
    }
}
