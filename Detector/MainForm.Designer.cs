namespace Detector
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.detectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showBoxesCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.busyIndicator = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.busyIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(776, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openImageFileButton });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageFileButton
            // 
            this.openImageFileButton.Name = "openImageFileButton";
            this.openImageFileButton.Size = new System.Drawing.Size(103, 22);
            this.openImageFileButton.Text = "Open";
            this.openImageFileButton.Click += new System.EventHandler(this.openImageFileButton_Click);
            // 
            // imageFileDialog
            // 
            this.imageFileDialog.Filter = "JPG|*.jpg|PNG|*.png";
            // 
            // detectButton
            // 
            this.detectButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.detectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.detectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.detectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (192)))), ((int) (((byte) (192)))));
            this.detectButton.FlatAppearance.BorderSize = 4;
            this.detectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.detectButton.Location = new System.Drawing.Point(4, 12);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(153, 23);
            this.detectButton.TabIndex = 4;
            this.detectButton.Text = "Detect place";
            this.detectButton.UseVisualStyleBackColor = false;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.showBoxesCheckBox);
            this.panel1.Controls.Add(this.detectButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.MinimumSize = new System.Drawing.Size(165, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 537);
            this.panel1.TabIndex = 5;
            // 
            // showBoxesCheckBox
            // 
            this.showBoxesCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showBoxesCheckBox.Location = new System.Drawing.Point(4, 41);
            this.showBoxesCheckBox.Name = "showBoxesCheckBox";
            this.showBoxesCheckBox.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.showBoxesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.showBoxesCheckBox.Size = new System.Drawing.Size(153, 26);
            this.showBoxesCheckBox.TabIndex = 5;
            this.showBoxesCheckBox.Text = "Show boxes";
            this.showBoxesCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                       | System.Windows.Forms.AnchorStyles.Left)
                                                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.busyIndicator);
            this.panel2.Controls.Add(this.imageBox);
            this.panel2.Location = new System.Drawing.Point(171, 24);
            this.panel2.MinimumSize = new System.Drawing.Size(165, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 537);
            this.panel2.TabIndex = 6;
            // 
            // imageBox
            // 
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.Location = new System.Drawing.Point(0, 0);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(599, 533);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // busyIndicator
            // 
            this.busyIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.busyIndicator.Location = new System.Drawing.Point(0, 0);
            this.busyIndicator.Name = "busyIndicator";
            this.busyIndicator.Size = new System.Drawing.Size(599, 533);
            this.busyIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.busyIndicator.TabIndex = 1;
            this.busyIndicator.TabStop = false;
            this.busyIndicator.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(153, 39);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.busyIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox busyIndicator;

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imageBox;

        private System.Windows.Forms.CheckBox showBoxesCheckBox;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Button detectButton;

        private System.Windows.Forms.OpenFileDialog imageFileDialog;

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageFileButton;

        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion
    }
}