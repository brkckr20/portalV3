﻿namespace PortalV3._1.Modals
{
    partial class FirmaListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmaListesi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAramaIfadesi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblFirmaListesi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblFirmaListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAramaIfadesi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 31);
            this.panel1.TabIndex = 0;
            // 
            // txtAramaIfadesi
            // 
            this.txtAramaIfadesi.Location = new System.Drawing.Point(95, 6);
            this.txtAramaIfadesi.Name = "txtAramaIfadesi";
            this.txtAramaIfadesi.Size = new System.Drawing.Size(394, 20);
            this.txtAramaIfadesi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arama İfadesi :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tblFirmaListesi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 217);
            this.panel2.TabIndex = 1;
            // 
            // tblFirmaListesi
            // 
            this.tblFirmaListesi.BackgroundColor = System.Drawing.Color.White;
            this.tblFirmaListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblFirmaListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFirmaListesi.Location = new System.Drawing.Point(0, 0);
            this.tblFirmaListesi.Name = "tblFirmaListesi";
            this.tblFirmaListesi.Size = new System.Drawing.Size(501, 217);
            this.tblFirmaListesi.TabIndex = 0;
            this.tblFirmaListesi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblFirmaListesi_CellDoubleClick);
            // 
            // FirmaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 248);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirmaListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firma Listesi";
            this.Load += new System.EventHandler(this.FirmaListesi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblFirmaListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAramaIfadesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tblFirmaListesi;
    }
}