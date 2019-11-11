﻿namespace tensor_patcher_gui {
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
        const int FORM_WIDTH = 1024;
        const int FORM_HEIGHT = 768;

        private void SetupControls() {
            this.ClientSize = new System.Drawing.Size(FORM_WIDTH, FORM_HEIGHT);
            for (int i = 0; i < 12; ++i) {
                for (int j = 0; j < 12; ++j) {
                    System.Windows.Forms.Button but = new System.Windows.Forms.Button();
                    but.Top = i * TILE_SIZE;
                    but.Left = j * TILE_SIZE;
                    but.Height = TILE_SIZE;
                    but.Width = TILE_SIZE;
                    but.BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick05;
                    but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    but.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                    this.Controls.Add(but);
                }
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick05;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(667, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
    }
}

