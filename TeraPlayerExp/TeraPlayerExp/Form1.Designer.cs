namespace TeraPlayerExp
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnLoadExp = new System.Windows.Forms.Button();
            this.btnLoadNewExp = new System.Windows.Forms.Button();
            this.btnSaveNewExp = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 50);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(468, 324);
            this.listBox1.TabIndex = 0;
            // 
            // btnLoadExp
            // 
            this.btnLoadExp.Location = new System.Drawing.Point(16, 384);
            this.btnLoadExp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadExp.Name = "btnLoadExp";
            this.btnLoadExp.Size = new System.Drawing.Size(469, 28);
            this.btnLoadExp.TabIndex = 1;
            this.btnLoadExp.Text = "Load Player Experience";
            this.btnLoadExp.UseVisualStyleBackColor = true;
            this.btnLoadExp.Click += new System.EventHandler(this.btnLoadExp_Click);
            // 
            // btnLoadNewExp
            // 
            this.btnLoadNewExp.Location = new System.Drawing.Point(16, 421);
            this.btnLoadNewExp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadNewExp.Name = "btnLoadNewExp";
            this.btnLoadNewExp.Size = new System.Drawing.Size(469, 28);
            this.btnLoadNewExp.TabIndex = 2;
            this.btnLoadNewExp.Text = "Load New Experience Dictionary";
            this.btnLoadNewExp.UseVisualStyleBackColor = true;
            this.btnLoadNewExp.Click += new System.EventHandler(this.btnLoadNewExp_Click);
            // 
            // btnSaveNewExp
            // 
            this.btnSaveNewExp.Location = new System.Drawing.Point(16, 458);
            this.btnSaveNewExp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveNewExp.Name = "btnSaveNewExp";
            this.btnSaveNewExp.Size = new System.Drawing.Size(469, 28);
            this.btnSaveNewExp.TabIndex = 3;
            this.btnSaveNewExp.Text = "Save Experience Binary";
            this.btnSaveNewExp.UseVisualStyleBackColor = true;
            this.btnSaveNewExp.Click += new System.EventHandler(this.btnSaveNewExp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(503, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 513);
            this.Controls.Add(this.btnSaveNewExp);
            this.Controls.Add(this.btnLoadNewExp);
            this.Controls.Add(this.btnLoadExp);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Tera Experience Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnLoadExp;
        private System.Windows.Forms.Button btnLoadNewExp;
        private System.Windows.Forms.Button btnSaveNewExp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

