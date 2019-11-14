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
            this.panel_MapBorder.SendToBack();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel_MapBorder = new System.Windows.Forms.Panel();
            this.label_TensorLoadStatus = new System.Windows.Forms.Label();
            this.button_LocateTensorAutomaticaly = new System.Windows.Forms.Button();
            this.button_LocateTensorManually = new System.Windows.Forms.Button();
            this.listCaves = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sbar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel_MapBorder.SuspendLayout();
            this.sbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_MapBorder
            // 
            this.panel_MapBorder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_MapBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_MapBorder.Controls.Add(this.label_TensorLoadStatus);
            this.panel_MapBorder.Controls.Add(this.button_LocateTensorAutomaticaly);
            this.panel_MapBorder.Controls.Add(this.button_LocateTensorManually);
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
            // button_LocateTensorAutomaticaly
            // 
            this.button_LocateTensorAutomaticaly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_LocateTensorAutomaticaly.Location = new System.Drawing.Point(177, 287);
            this.button_LocateTensorAutomaticaly.Name = "button_LocateTensorAutomaticaly";
            this.button_LocateTensorAutomaticaly.Size = new System.Drawing.Size(280, 34);
            this.button_LocateTensorAutomaticaly.TabIndex = 2;
            this.button_LocateTensorAutomaticaly.Text = "Autodetect \"Tensor.xex\" location...";
            this.button_LocateTensorAutomaticaly.UseVisualStyleBackColor = true;
            this.button_LocateTensorAutomaticaly.Click += new System.EventHandler(this.button_LocateTensorAutomaticaly_Click);
            // 
            // button_LocateTensorManually
            // 
            this.button_LocateTensorManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_LocateTensorManually.Location = new System.Drawing.Point(177, 247);
            this.button_LocateTensorManually.Name = "button_LocateTensorManually";
            this.button_LocateTensorManually.Size = new System.Drawing.Size(280, 34);
            this.button_LocateTensorManually.TabIndex = 1;
            this.button_LocateTensorManually.Text = "Loacte \"Tensor.xex\"...";
            this.button_LocateTensorManually.UseVisualStyleBackColor = true;
            this.button_LocateTensorManually.Click += new System.EventHandler(this.button_LocateTensorManually_Click);
            // 
            // listCaves
            // 
            this.listCaves.AutoArrange = false;
            this.listCaves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listCaves.FullRowSelect = true;
            this.listCaves.GridLines = true;
            this.listCaves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listCaves.Location = new System.Drawing.Point(645, 12);
            this.listCaves.Name = "listCaves";
            this.listCaves.Size = new System.Drawing.Size(351, 418);
            this.listCaves.TabIndex = 2;
            this.listCaves.UseCompatibleStateImageBehavior = false;
            this.listCaves.View = System.Windows.Forms.View.Details;
            this.listCaves.SelectedIndexChanged += new System.EventHandler(this.listCaves_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 213;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // sbar
            // 
            this.sbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sbar.Location = new System.Drawing.Point(0, 707);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.sbar);
            this.Controls.Add(this.listCaves);
            this.Controls.Add(this.panel_MapBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tensor Trzaskowskiego Cave Editor by mgr inż. Rafał";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_MapBorder.ResumeLayout(false);
            this.sbar.ResumeLayout(false);
            this.sbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_MapBorder;
        private System.Windows.Forms.ListView listCaves;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip sbar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button_LocateTensorManually;
        private System.Windows.Forms.Button button_LocateTensorAutomaticaly;
        private System.Windows.Forms.Label label_TensorLoadStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

