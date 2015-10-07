namespace Editor_Text_Colaborativ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonBold;
        private System.Windows.Forms.Button buttonUnderline;
        private System.Windows.Forms.Button buttonItalic;
        private System.Windows.Forms.Button buttonCenter;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonServer;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBold;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelItalic;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUnderline;
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
            this.buttonBold = new System.Windows.Forms.Button();
            this.buttonUnderline = new System.Windows.Forms.Button();
            this.buttonItalic = new System.Windows.Forms.Button();
            this.buttonCenter = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBold = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelItalic = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUnderline = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonStop = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBold
            // 
            this.buttonBold.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonBold.Location = new System.Drawing.Point(137, 27);
            this.buttonBold.Name = "buttonBold";
            this.buttonBold.Size = new System.Drawing.Size(75, 23);
            this.buttonBold.TabIndex = 0;
            this.buttonBold.Text = "Bold";
            this.buttonBold.UseVisualStyleBackColor = true;
            this.buttonBold.Click += new System.EventHandler(this.buttonBold_Click);
            // 
            // buttonUnderline
            // 
            this.buttonUnderline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonUnderline.Location = new System.Drawing.Point(218, 27);
            this.buttonUnderline.Name = "buttonUnderline";
            this.buttonUnderline.Size = new System.Drawing.Size(75, 23);
            this.buttonUnderline.TabIndex = 1;
            this.buttonUnderline.Text = "Underline";
            this.buttonUnderline.UseVisualStyleBackColor = true;
            this.buttonUnderline.Click += new System.EventHandler(this.buttonUnderline_Click);
            // 
            // buttonItalic
            // 
            this.buttonItalic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonItalic.Location = new System.Drawing.Point(299, 27);
            this.buttonItalic.Name = "buttonItalic";
            this.buttonItalic.Size = new System.Drawing.Size(75, 23);
            this.buttonItalic.TabIndex = 2;
            this.buttonItalic.Text = "Italic";
            this.buttonItalic.UseVisualStyleBackColor = true;
            this.buttonItalic.Click += new System.EventHandler(this.buttonItalic_Click);
            // 
            // buttonCenter
            // 
            this.buttonCenter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonCenter.Location = new System.Drawing.Point(380, 27);
            this.buttonCenter.Name = "buttonCenter";
            this.buttonCenter.Size = new System.Drawing.Size(75, 23);
            this.buttonCenter.TabIndex = 3;
            this.buttonCenter.Text = "Center";
            this.buttonCenter.UseVisualStyleBackColor = true;
            this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClient.Location = new System.Drawing.Point(225, 345);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(75, 23);
            this.buttonClient.TabIndex = 4;
            this.buttonClient.Text = "Client";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonC_Click);
            // 
            // buttonServer
            // 
            this.buttonServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonServer.Location = new System.Drawing.Point(137, 345);
            this.buttonServer.Name = "buttonServer";
            this.buttonServer.Size = new System.Drawing.Size(75, 23);
            this.buttonServer.TabIndex = 5;
            this.buttonServer.Text = "Server";
            this.buttonServer.UseVisualStyleBackColor = true;
            this.buttonServer.Click += new System.EventHandler(this.buttonS_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Size:";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSize.Location = new System.Drawing.Point(290, 60);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(49, 20);
            this.textBoxSize.TabIndex = 7;
            this.textBoxSize.Text = "10";
            this.textBoxSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSize_KeyPress);
            this.textBoxSize.Validated += new System.EventHandler(this.textBoxSize_Validated);
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxText.Location = new System.Drawing.Point(12, 86);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.Size = new System.Drawing.Size(568, 253);
            this.richTextBoxText.TabIndex = 8;
            this.richTextBoxText.Text = "";
            this.richTextBoxText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxText_LinkClicked);
            this.richTextBoxText.SelectionChanged += new System.EventHandler(this.selectionChanged);
            this.richTextBoxText.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(592, 24);
            this.menuStrip.TabIndex = 12;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::Editor_Text_Colaborativ.Properties.Resources.newToolStripButton_Image;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Editor_Text_Colaborativ.Properties.Resources.saveToolStripButton_Image;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::Editor_Text_Colaborativ.Properties.Resources.openToolStripButton_Image;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.menuItemLoad_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::Editor_Text_Colaborativ.Properties.Resources.helpToolStripButton_Image;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.menuItemHelp_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabelBold,
            this.toolStripStatusLabelItalic,
            this.toolStripStatusLabelUnderline});
            this.statusStrip.Location = new System.Drawing.Point(0, 378);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(592, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = false;
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(259, 17);
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelBold
            // 
            this.toolStripStatusLabelBold.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelBold.Enabled = false;
            this.toolStripStatusLabelBold.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabelBold.Image = global::Editor_Text_Colaborativ.Properties.Resources.boldToolStripButton_Image;
            this.toolStripStatusLabelBold.Name = "toolStripStatusLabelBold";
            this.toolStripStatusLabelBold.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabelBold.Text = "Bold";
            // 
            // toolStripStatusLabelItalic
            // 
            this.toolStripStatusLabelItalic.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelItalic.Enabled = false;
            this.toolStripStatusLabelItalic.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabelItalic.Image = global::Editor_Text_Colaborativ.Properties.Resources.italicToolStripButton_Image;
            this.toolStripStatusLabelItalic.Name = "toolStripStatusLabelItalic";
            this.toolStripStatusLabelItalic.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabelItalic.Text = "Italic";
            // 
            // toolStripStatusLabelUnderline
            // 
            this.toolStripStatusLabelUnderline.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelUnderline.Enabled = false;
            this.toolStripStatusLabelUnderline.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabelUnderline.Image = global::Editor_Text_Colaborativ.Properties.Resources.underlineToolStripButton_Image;
            this.toolStripStatusLabelUnderline.Name = "toolStripStatusLabelUnderline";
            this.toolStripStatusLabelUnderline.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabelUnderline.Text = "Underline";
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(380, 345);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(592, 400);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.richTextBoxText);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonServer);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonCenter);
            this.Controls.Add(this.buttonItalic);
            this.Controls.Add(this.buttonUnderline);
            this.Controls.Add(this.buttonBold);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(519, 300);
            this.Name = "Form1";
            this.Text = "Editor Text Colaborativ";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

