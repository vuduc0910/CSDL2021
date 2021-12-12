
namespace NGANHANG
{
    partial class FormChuyenTien
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nGAYGDLabel;
            System.Windows.Forms.Label sOTIENLabel;
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label sOTK_CHUYENLabel;
            System.Windows.Forms.Label sOTK_NHANLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChuyenTien));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnHieuChinh = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.DSCT = new NGANHANG.DSCT();
            this.bdsCT = new System.Windows.Forms.BindingSource(this.components);
            this.gD_CHUYENTIENTableAdapter = new NGANHANG.DSCTTableAdapters.GD_CHUYENTIENTableAdapter();
            this.tableAdapterManager = new NGANHANG.DSCTTableAdapters.TableAdapterManager();
            this.nhanVienTableAdapter = new NGANHANG.DSCTTableAdapters.NhanVienTableAdapter();
            this.taiKhoanTableAdapter = new NGANHANG.DSCTTableAdapters.TaiKhoanTableAdapter();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chuyentienGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTK_CHUYEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTK_NHAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODUTKCHUYEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODUTKNHAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControlDetail = new DevExpress.XtraEditors.PanelControl();
            this.txtSoTKN = new System.Windows.Forms.TextBox();
            this.txtSoTKC = new System.Windows.Forms.TextBox();
            this.cmbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.bdsNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.txtSoTien = new DevExpress.XtraEditors.TextEdit();
            this.dateEditNgayGD = new DevExpress.XtraEditors.DateEdit();
            this.bdsTaiKhoan = new System.Windows.Forms.BindingSource(this.components);
            this.txtSoDuTKC = new DevExpress.XtraEditors.TextEdit();
            this.txtSODUTKN = new DevExpress.XtraEditors.TextEdit();
            nGAYGDLabel = new System.Windows.Forms.Label();
            sOTIENLabel = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            sOTK_CHUYENLabel = new System.Windows.Forms.Label();
            sOTK_NHANLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chuyentienGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDetail)).BeginInit();
            this.panelControlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgayGD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgayGD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDuTKC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSODUTKN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nGAYGDLabel
            // 
            nGAYGDLabel.AutoSize = true;
            nGAYGDLabel.Location = new System.Drawing.Point(908, 87);
            nGAYGDLabel.Name = "nGAYGDLabel";
            nGAYGDLabel.Size = new System.Drawing.Size(52, 13);
            nGAYGDLabel.TabIndex = 2;
            nGAYGDLabel.Text = "NGAYGD:";
            // 
            // sOTIENLabel
            // 
            sOTIENLabel.AutoSize = true;
            sOTIENLabel.Location = new System.Drawing.Point(912, 175);
            sOTIENLabel.Name = "sOTIENLabel";
            sOTIENLabel.Size = new System.Drawing.Size(48, 13);
            sOTIENLabel.TabIndex = 4;
            sOTIENLabel.Text = "SOTIEN:";
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(435, 280);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(39, 13);
            mANVLabel.TabIndex = 8;
            mANVLabel.Text = "MANV:";
            // 
            // sOTK_CHUYENLabel
            // 
            sOTK_CHUYENLabel.AutoSize = true;
            sOTK_CHUYENLabel.Location = new System.Drawing.Point(394, 86);
            sOTK_CHUYENLabel.Name = "sOTK_CHUYENLabel";
            sOTK_CHUYENLabel.Size = new System.Drawing.Size(80, 13);
            sOTK_CHUYENLabel.TabIndex = 9;
            sOTK_CHUYENLabel.Text = "SOTK CHUYEN:";
            // 
            // sOTK_NHANLabel
            // 
            sOTK_NHANLabel.AutoSize = true;
            sOTK_NHANLabel.Location = new System.Drawing.Point(406, 175);
            sOTK_NHANLabel.Name = "sOTK_NHANLabel";
            sOTK_NHANLabel.Size = new System.Drawing.Size(68, 13);
            sOTK_NHANLabel.TabIndex = 10;
            sOTK_NHANLabel.Text = "SOTK NHAN:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnHieuChinh,
            this.btnLuu,
            this.btnXoa,
            this.btnPhucHoi,
            this.btnReload,
            this.btnIn,
            this.btnThoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHieuChinh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLuu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPhucHoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnHieuChinh
            // 
            this.btnHieuChinh.Caption = "Hiệu Chỉnh";
            this.btnHieuChinh.Id = 1;
            this.btnHieuChinh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHieuChinh.ImageOptions.Image")));
            this.btnHieuChinh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHieuChinh.ImageOptions.LargeImage")));
            this.btnHieuChinh.Name = "btnHieuChinh";
            this.btnHieuChinh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnHieuChinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHieuChinh_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 2;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.LargeImage")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xoá";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phục hồi";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.ImageOptions.Image")));
            this.btnPhucHoi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.ImageOptions.LargeImage")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 5;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.LargeImage")));
            this.btnReload.Name = "btnReload";
            this.btnReload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.LargeImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1454, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 936);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1454, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 891);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1454, 45);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 891);
            // 
            // btnIn
            // 
            this.btnIn.Caption = "In danh sách nhân viên";
            this.btnIn.Id = 6;
            this.btnIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.ImageOptions.Image")));
            this.btnIn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIn.ImageOptions.LargeImage")));
            this.btnIn.Name = "btnIn";
            this.btnIn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // DSCT
            // 
            this.DSCT.DataSetName = "DSCT";
            this.DSCT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsCT
            // 
            this.bdsCT.DataMember = "GD_CHUYENTIEN";
            this.bdsCT.DataSource = this.DSCT;
            // 
            // gD_CHUYENTIENTableAdapter
            // 
            this.gD_CHUYENTIENTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = this.gD_CHUYENTIENTableAdapter;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.TaiKhoanTableAdapter = this.taiKhoanTableAdapter;
            this.tableAdapterManager.UpdateOrder = NGANHANG.DSCTTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // taiKhoanTableAdapter
            // 
            this.taiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxChiNhanh);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1454, 52);
            this.panelControl1.TabIndex = 7;
            // 
            // comboBoxChiNhanh
            // 
            this.comboBoxChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChiNhanh.FormattingEnabled = true;
            this.comboBoxChiNhanh.Location = new System.Drawing.Point(516, 15);
            this.comboBoxChiNhanh.Name = "comboBoxChiNhanh";
            this.comboBoxChiNhanh.Size = new System.Drawing.Size(491, 21);
            this.comboBoxChiNhanh.TabIndex = 5;
            this.comboBoxChiNhanh.SelectedIndexChanged += new System.EventHandler(this.comboBoxChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chi Nhánh";
            // 
            // chuyentienGridControl
            // 
            this.chuyentienGridControl.DataSource = this.bdsCT;
            this.chuyentienGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.chuyentienGridControl.Location = new System.Drawing.Point(0, 97);
            this.chuyentienGridControl.MainView = this.gridView1;
            this.chuyentienGridControl.MenuManager = this.barManager1;
            this.chuyentienGridControl.Name = "chuyentienGridControl";
            this.chuyentienGridControl.Size = new System.Drawing.Size(1454, 220);
            this.chuyentienGridControl.TabIndex = 7;
            this.chuyentienGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAGD,
            this.colNGAYGD,
            this.colSOTK_CHUYEN,
            this.colSOTK_NHAN,
            this.colSOTIEN,
            this.colMANV,
            this.colSODUTKCHUYEN,
            this.colSODUTKNHAN});
            this.gridView1.GridControl = this.chuyentienGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colMAGD
            // 
            this.colMAGD.FieldName = "MAGD";
            this.colMAGD.Name = "colMAGD";
            this.colMAGD.Visible = true;
            this.colMAGD.VisibleIndex = 0;
            // 
            // colNGAYGD
            // 
            this.colNGAYGD.FieldName = "NGAYGD";
            this.colNGAYGD.Name = "colNGAYGD";
            this.colNGAYGD.Visible = true;
            this.colNGAYGD.VisibleIndex = 2;
            // 
            // colSOTK_CHUYEN
            // 
            this.colSOTK_CHUYEN.FieldName = "SOTK_CHUYEN";
            this.colSOTK_CHUYEN.Name = "colSOTK_CHUYEN";
            this.colSOTK_CHUYEN.Visible = true;
            this.colSOTK_CHUYEN.VisibleIndex = 1;
            // 
            // colSOTK_NHAN
            // 
            this.colSOTK_NHAN.FieldName = "SOTK_NHAN";
            this.colSOTK_NHAN.Name = "colSOTK_NHAN";
            this.colSOTK_NHAN.Visible = true;
            this.colSOTK_NHAN.VisibleIndex = 4;
            // 
            // colSOTIEN
            // 
            this.colSOTIEN.FieldName = "SOTIEN";
            this.colSOTIEN.Name = "colSOTIEN";
            this.colSOTIEN.Visible = true;
            this.colSOTIEN.VisibleIndex = 3;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 5;
            // 
            // colSODUTKCHUYEN
            // 
            this.colSODUTKCHUYEN.FieldName = "SODUTKCHUYEN";
            this.colSODUTKCHUYEN.Name = "colSODUTKCHUYEN";
            this.colSODUTKCHUYEN.Visible = true;
            this.colSODUTKCHUYEN.VisibleIndex = 6;
            // 
            // colSODUTKNHAN
            // 
            this.colSODUTKNHAN.FieldName = "SODUTKNHAN";
            this.colSODUTKNHAN.Name = "colSODUTKNHAN";
            this.colSODUTKNHAN.Visible = true;
            this.colSODUTKNHAN.VisibleIndex = 7;
            // 
            // panelControlDetail
            // 
            this.panelControlDetail.Controls.Add(this.txtSODUTKN);
            this.panelControlDetail.Controls.Add(this.txtSoDuTKC);
            this.panelControlDetail.Controls.Add(sOTK_NHANLabel);
            this.panelControlDetail.Controls.Add(this.txtSoTKN);
            this.panelControlDetail.Controls.Add(sOTK_CHUYENLabel);
            this.panelControlDetail.Controls.Add(this.txtSoTKC);
            this.panelControlDetail.Controls.Add(mANVLabel);
            this.panelControlDetail.Controls.Add(this.cmbMaNhanVien);
            this.panelControlDetail.Controls.Add(sOTIENLabel);
            this.panelControlDetail.Controls.Add(this.txtSoTien);
            this.panelControlDetail.Controls.Add(nGAYGDLabel);
            this.panelControlDetail.Controls.Add(this.dateEditNgayGD);
            this.panelControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlDetail.Location = new System.Drawing.Point(0, 317);
            this.panelControlDetail.Name = "panelControlDetail";
            this.panelControlDetail.Size = new System.Drawing.Size(1454, 619);
            this.panelControlDetail.TabIndex = 8;
            // 
            // txtSoTKN
            // 
            this.txtSoTKN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCT, "SOTK_NHAN", true));
            this.txtSoTKN.Location = new System.Drawing.Point(480, 172);
            this.txtSoTKN.Name = "txtSoTKN";
            this.txtSoTKN.Size = new System.Drawing.Size(240, 21);
            this.txtSoTKN.TabIndex = 11;
            // 
            // txtSoTKC
            // 
            this.txtSoTKC.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCT, "SOTK_CHUYEN", true));
            this.txtSoTKC.Location = new System.Drawing.Point(480, 83);
            this.txtSoTKC.Name = "txtSoTKC";
            this.txtSoTKC.Size = new System.Drawing.Size(240, 21);
            this.txtSoTKC.TabIndex = 10;
            // 
            // cmbMaNhanVien
            // 
            this.cmbMaNhanVien.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCT, "MANV", true));
            this.cmbMaNhanVien.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsCT, "MANV", true));
            this.cmbMaNhanVien.DataSource = this.bdsNhanVien;
            this.cmbMaNhanVien.DisplayMember = "MANV";
            this.cmbMaNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaNhanVien.FormattingEnabled = true;
            this.cmbMaNhanVien.Location = new System.Drawing.Point(480, 277);
            this.cmbMaNhanVien.Name = "cmbMaNhanVien";
            this.cmbMaNhanVien.Size = new System.Drawing.Size(240, 21);
            this.cmbMaNhanVien.TabIndex = 9;
            this.cmbMaNhanVien.ValueMember = "MANV";
            // 
            // bdsNhanVien
            // 
            this.bdsNhanVien.DataMember = "NhanVien";
            this.bdsNhanVien.DataSource = this.DSCT;
            // 
            // txtSoTien
            // 
            this.txtSoTien.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCT, "SOTIEN", true));
            this.txtSoTien.Location = new System.Drawing.Point(966, 172);
            this.txtSoTien.MenuManager = this.barManager1;
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.DisplayFormat.FormatString = "n0";
            this.txtSoTien.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.Properties.EditFormat.FormatString = "n0";
            this.txtSoTien.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.Size = new System.Drawing.Size(258, 20);
            this.txtSoTien.TabIndex = 5;
            // 
            // dateEditNgayGD
            // 
            this.dateEditNgayGD.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCT, "NGAYGD", true));
            this.dateEditNgayGD.EditValue = null;
            this.dateEditNgayGD.Location = new System.Drawing.Point(966, 84);
            this.dateEditNgayGD.MenuManager = this.barManager1;
            this.dateEditNgayGD.Name = "dateEditNgayGD";
            this.dateEditNgayGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditNgayGD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditNgayGD.Properties.UseMaskAsDisplayFormat = true;
            this.dateEditNgayGD.Size = new System.Drawing.Size(258, 20);
            this.dateEditNgayGD.TabIndex = 3;
            // 
            // bdsTaiKhoan
            // 
            this.bdsTaiKhoan.DataMember = "TaiKhoan";
            this.bdsTaiKhoan.DataSource = this.DSCT;
            // 
            // txtSoDuTKC
            // 
            this.txtSoDuTKC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCT, "SODUTKCHUYEN", true));
            this.txtSoDuTKC.Enabled = false;
            this.txtSoDuTKC.Location = new System.Drawing.Point(0, 579);
            this.txtSoDuTKC.MenuManager = this.barManager1;
            this.txtSoDuTKC.Name = "txtSoDuTKC";
            this.txtSoDuTKC.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtSoDuTKC.Properties.Appearance.Options.UseForeColor = true;
            this.txtSoDuTKC.Size = new System.Drawing.Size(10, 20);
            this.txtSoDuTKC.TabIndex = 12;
            // 
            // txtSODUTKN
            // 
            this.txtSODUTKN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCT, "SODUTKNHAN", true));
            this.txtSODUTKN.Enabled = false;
            this.txtSODUTKN.Location = new System.Drawing.Point(0, 553);
            this.txtSODUTKN.MenuManager = this.barManager1;
            this.txtSODUTKN.Name = "txtSODUTKN";
            this.txtSODUTKN.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtSODUTKN.Properties.Appearance.Options.UseForeColor = true;
            this.txtSODUTKN.Size = new System.Drawing.Size(10, 20);
            this.txtSODUTKN.TabIndex = 13;
            // 
            // FormChuyenTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 956);
            this.Controls.Add(this.panelControlDetail);
            this.Controls.Add(this.chuyentienGridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormChuyenTien";
            this.Text = "FormChuyenTien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormChuyenTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chuyentienGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDetail)).EndInit();
            this.panelControlDetail.ResumeLayout(false);
            this.panelControlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgayGD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNgayGD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDuTKC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSODUTKN.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnHieuChinh;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private System.Windows.Forms.BindingSource bdsCT;
        private DSCT DSCT;
        private DSCTTableAdapters.GD_CHUYENTIENTableAdapter gD_CHUYENTIENTableAdapter;
        private DSCTTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.PanelControl panelControlDetail;
        private DevExpress.XtraGrid.GridControl chuyentienGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox comboBoxChiNhanh;
        private System.Windows.Forms.Label label1;
        private DSCTTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private System.Windows.Forms.BindingSource bdsNhanVien;
        private DSCTTableAdapters.TaiKhoanTableAdapter taiKhoanTableAdapter;
        private System.Windows.Forms.BindingSource bdsTaiKhoan;
        private System.Windows.Forms.ComboBox cmbMaNhanVien;
        private DevExpress.XtraEditors.TextEdit txtSoTien;
        private DevExpress.XtraEditors.DateEdit dateEditNgayGD;
        private System.Windows.Forms.TextBox txtSoTKN;
        private System.Windows.Forms.TextBox txtSoTKC;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGD;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYGD;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK_CHUYEN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK_NHAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colSODUTKCHUYEN;
        private DevExpress.XtraGrid.Columns.GridColumn colSODUTKNHAN;
        private DevExpress.XtraEditors.TextEdit txtSODUTKN;
        private DevExpress.XtraEditors.TextEdit txtSoDuTKC;
    }
}