
namespace NGANHANG
{
    partial class FormReportKhachHang
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.comboBoxChiNhanh);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1454, 181);
            this.panelControl2.TabIndex = 17;
            // 
            // comboBoxChiNhanh
            // 
            this.comboBoxChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChiNhanh.FormattingEnabled = true;
            this.comboBoxChiNhanh.Location = new System.Drawing.Point(463, 62);
            this.comboBoxChiNhanh.Name = "comboBoxChiNhanh";
            this.comboBoxChiNhanh.Size = new System.Drawing.Size(491, 21);
            this.comboBoxChiNhanh.TabIndex = 3;
            this.comboBoxChiNhanh.SelectedIndexChanged += new System.EventHandler(this.comboBoxChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chi Nhánh";
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(416, 392);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(214, 51);
            this.buttonPreview.TabIndex = 18;
            this.buttonPreview.Text = "PREVIEW";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(734, 392);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(206, 51);
            this.buttonClose.TabIndex = 19;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormReportKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 928);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.panelControl2);
            this.Name = "FormReportKhachHang";
            this.Text = "FormReportKhachHang";
            this.Load += new System.EventHandler(this.FormReportKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ComboBox comboBoxChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.Button buttonClose;
    }
}