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

        const int TILE_SIZE = 48;

        private void CreateMapTiles() {
            for (int i = 0; i < 12; ++i) {
                for (int j = 0; j < 12; ++j) {
                    System.Windows.Forms.Button but = new System.Windows.Forms.Button();
                    but.Top = 32 + i * TILE_SIZE;
                    but.Left = 32 + j * TILE_SIZE;
                    but.Height = TILE_SIZE;
                    but.Width = TILE_SIZE;
                    but.BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick05;
                    but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    but.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                    this.Controls.Add(but);
                }
            }
        }

        private void SetupForm() {
            this.panel_MapBorder.SendToBack();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel_MapBorder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sbar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_MapBorder.SuspendLayout();
            this.sbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_MapBorder
            // 
            this.panel_MapBorder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_MapBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_MapBorder.Controls.Add(this.label1);
            this.panel_MapBorder.Controls.Add(this.button2);
            this.panel_MapBorder.Controls.Add(this.button1);
            this.panel_MapBorder.Location = new System.Drawing.Point(12, 12);
            this.panel_MapBorder.Name = "panel_MapBorder";
            this.panel_MapBorder.Size = new System.Drawing.Size(611, 616);
            this.panel_MapBorder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(117, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tensor not loaded";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(177, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Autodetect \"Tensor.xex\" location...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_LocateTensorAutomaticaly_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(177, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Loacte \"Tensor.xex\"...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Location = new System.Drawing.Point(645, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(351, 418);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel1.Text = "All correct";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.sbar);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip sbar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

