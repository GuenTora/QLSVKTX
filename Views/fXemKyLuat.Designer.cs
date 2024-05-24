namespace QLSV
{
    partial class fXemKyLuat
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
            this.label20 = new System.Windows.Forms.Label();
            this.dtgvKyLuat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKyLuat)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Yellow;
            this.label20.Location = new System.Drawing.Point(13, 9);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(774, 81);
            this.label20.TabIndex = 6;
            this.label20.Text = "Danh sách vi phạm kỷ luật của sinh viên";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgvKyLuat
            // 
            this.dtgvKyLuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKyLuat.Location = new System.Drawing.Point(12, 103);
            this.dtgvKyLuat.Name = "dtgvKyLuat";
            this.dtgvKyLuat.RowHeadersWidth = 51;
            this.dtgvKyLuat.RowTemplate.Height = 24;
            this.dtgvKyLuat.Size = new System.Drawing.Size(776, 335);
            this.dtgvKyLuat.TabIndex = 7;
            // 
            // fXemKyLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgvKyLuat);
            this.Controls.Add(this.label20);
            this.Name = "fXemKyLuat";
            this.Text = "fXemKyLuat";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKyLuat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dtgvKyLuat;
    }
}