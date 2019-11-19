namespace tensor_patcher_gui {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetupForm() {
            CreateMapTiles();
            CreateToolbox();
            this.panel_MapBorder.SendToBack();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel_MapBorder = new System.Windows.Forms.Panel();
            this.label_TensorLoadStatus = new System.Windows.Forms.Label();
            this.button_LocateTensorManually = new System.Windows.Forms.Button();
            this.listCaves = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sbar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Save = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picSelection = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel_MapBorder.SuspendLayout();
            this.sbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_MapBorder
            // 
            this.panel_MapBorder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_MapBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_MapBorder.Controls.Add(this.label_TensorLoadStatus);
            this.panel_MapBorder.Location = new System.Drawing.Point(12, 12);
            this.panel_MapBorder.Name = "panel_MapBorder";
            this.panel_MapBorder.Size = new System.Drawing.Size(611, 616);
            this.panel_MapBorder.TabIndex = 1;
            // 
            // label_TensorLoadStatus
            // 
            this.label_TensorLoadStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label_TensorLoadStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_TensorLoadStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_TensorLoadStatus.ForeColor = System.Drawing.Color.Red;
            this.label_TensorLoadStatus.Location = new System.Drawing.Point(117, 143);
            this.label_TensorLoadStatus.Name = "label_TensorLoadStatus";
            this.label_TensorLoadStatus.Size = new System.Drawing.Size(400, 41);
            this.label_TensorLoadStatus.TabIndex = 3;
            this.label_TensorLoadStatus.Text = "Tensor not loaded";
            this.label_TensorLoadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_LocateTensorManually
            // 
            this.button_LocateTensorManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_LocateTensorManually.Location = new System.Drawing.Point(888, 376);
            this.button_LocateTensorManually.Name = "button_LocateTensorManually";
            this.button_LocateTensorManually.Size = new System.Drawing.Size(100, 23);
            this.button_LocateTensorManually.TabIndex = 1;
            this.button_LocateTensorManually.Text = "&Load...";
            this.button_LocateTensorManually.UseVisualStyleBackColor = true;
            this.button_LocateTensorManually.Click += new System.EventHandler(this.button_LocateTensorManually_Click);
            // 
            // listCaves
            // 
            this.listCaves.AutoArrange = false;
            this.listCaves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listCaves.FullRowSelect = true;
            this.listCaves.GridLines = true;
            this.listCaves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listCaves.HideSelection = false;
            this.listCaves.Location = new System.Drawing.Point(645, 121);
            this.listCaves.Name = "listCaves";
            this.listCaves.Size = new System.Drawing.Size(220, 309);
            this.listCaves.TabIndex = 2;
            this.listCaves.UseCompatibleStateImageBehavior = false;
            this.listCaves.View = System.Windows.Forms.View.Details;
            this.listCaves.SelectedIndexChanged += new System.EventHandler(this.listCaves_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 213;
            // 
            // sbar
            // 
            this.sbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sbar.Location = new System.Drawing.Point(0, 639);
            this.sbar.Name = "sbar";
            this.sbar.Size = new System.Drawing.Size(1008, 22);
            this.sbar.SizingGrip = false;
            this.sbar.TabIndex = 3;
            this.sbar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xex";
            this.openFileDialog.FileName = "Tensor.xex";
            this.openFileDialog.Filter = "Atari executables (*.xex)|*.xex";
            this.openFileDialog.Title = "Where is the Tensor.xex file?";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(647, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 182);
            this.panel1.TabIndex = 4;
            // 
            // button_Save
            // 
            this.button_Save.Enabled = false;
            this.button_Save.Location = new System.Drawing.Point(888, 407);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(100, 23);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "&Save...";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xex";
            this.saveFileDialog.FileName = "Tensor.xex";
            this.saveFileDialog.Filter = "Atari executables (*.xex)|*.xex";
            this.saveFileDialog.Title = "Choose location of your fresh, new \"Tensor.xex\"...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tensor_patcher_gui.Properties.Resources.title;
            this.pictureBox1.Location = new System.Drawing.Point(658, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 92);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // picSelection
            // 
            this.picSelection.Image = global::tensor_patcher_gui.Properties.Resources.selection;
            this.picSelection.Location = new System.Drawing.Point(-100, -100);
            this.picSelection.Name = "picSelection";
            this.picSelection.Size = new System.Drawing.Size(16, 16);
            this.picSelection.TabIndex = 5;
            this.picSelection.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(875, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 91);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tensor Trzaskowskiego\r\nMap Editor\r\nby\r\nmgr inż. Rafał\r\n \r\nCopyright (c) 2019\r\nMag" +
    "ister Labs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(876, 228);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "github.com/mgr-inz-rafal";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_LocateTensorManually);
            this.Controls.Add(this.picSelection);
            this.Controls.Add(this.sbar);
            this.Controls.Add(this.listCaves);
            this.Controls.Add(this.panel_MapBorder);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tensor Trzaskowskiego Cave Editor by mgr inż. Rafał (v 1.0)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_MapBorder.ResumeLayout(false);
            this.sbar.ResumeLayout(false);
            this.sbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_MapBorder;
        private System.Windows.Forms.ListView listCaves;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.StatusStrip sbar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button_LocateTensorManually;
        private System.Windows.Forms.Label label_TensorLoadStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picSelection;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

