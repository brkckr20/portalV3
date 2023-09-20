namespace PortalV3._1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kartlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.malzemeKartıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firmaKartıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.malzemeDepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.malzemeDepoGirişToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kartlarToolStripMenuItem,
            this.malzemeDepoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kartlarToolStripMenuItem
            // 
            this.kartlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.malzemeKartıToolStripMenuItem,
            this.firmaKartıToolStripMenuItem});
            this.kartlarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kartlarToolStripMenuItem.Image")));
            this.kartlarToolStripMenuItem.Name = "kartlarToolStripMenuItem";
            this.kartlarToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.kartlarToolStripMenuItem.Text = "Kartlar";
            // 
            // malzemeKartıToolStripMenuItem
            // 
            this.malzemeKartıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("malzemeKartıToolStripMenuItem.Image")));
            this.malzemeKartıToolStripMenuItem.Name = "malzemeKartıToolStripMenuItem";
            this.malzemeKartıToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.malzemeKartıToolStripMenuItem.Text = "Malzeme Kartı";
            this.malzemeKartıToolStripMenuItem.Click += new System.EventHandler(this.malzemeKartıToolStripMenuItem_Click);
            // 
            // firmaKartıToolStripMenuItem
            // 
            this.firmaKartıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("firmaKartıToolStripMenuItem.Image")));
            this.firmaKartıToolStripMenuItem.Name = "firmaKartıToolStripMenuItem";
            this.firmaKartıToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.firmaKartıToolStripMenuItem.Text = "Firma Kartı";
            this.firmaKartıToolStripMenuItem.Click += new System.EventHandler(this.firmaKartıToolStripMenuItem_Click);
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1272, 484);
            this.tabMain.TabIndex = 1;
            // 
            // malzemeDepoToolStripMenuItem
            // 
            this.malzemeDepoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.malzemeDepoGirişToolStripMenuItem});
            this.malzemeDepoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("malzemeDepoToolStripMenuItem.Image")));
            this.malzemeDepoToolStripMenuItem.Name = "malzemeDepoToolStripMenuItem";
            this.malzemeDepoToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.malzemeDepoToolStripMenuItem.Text = "Malzeme Depo";
            // 
            // malzemeDepoGirişToolStripMenuItem
            // 
            this.malzemeDepoGirişToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("malzemeDepoGirişToolStripMenuItem.Image")));
            this.malzemeDepoGirişToolStripMenuItem.Name = "malzemeDepoGirişToolStripMenuItem";
            this.malzemeDepoGirişToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.malzemeDepoGirişToolStripMenuItem.Text = "Malzeme Depo Giriş";
            this.malzemeDepoGirişToolStripMenuItem.Click += new System.EventHandler(this.malzemeDepoGirişToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 508);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal V3.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kartlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem malzemeKartıToolStripMenuItem;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.ToolStripMenuItem firmaKartıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem malzemeDepoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem malzemeDepoGirişToolStripMenuItem;

    }
}

