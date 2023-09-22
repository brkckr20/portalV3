using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalV3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  DataSet1TableAdapters.SarfMalzemeKartiTableAdapter ds = new DataSet1TableAdapters.SarfMalzemeKartiTableAdapter();
          //  dataGridView1.DataSource = ds.GetData();
        }

        private void tabOlustur(string baslik, Form formAdi)
        {
            TabPage newTab = new TabPage(baslik);
            formAdi.TopLevel = false;
            formAdi.FormBorderStyle = FormBorderStyle.None;
            formAdi.Dock = DockStyle.Fill;
            
            newTab.Controls.Add(formAdi);

            tabMain.TabPages.Add(newTab);
            tabMain.SelectedTab = newTab;
            formAdi.Show();
        }
        
        private void malzemeKartıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kartlar.MalzemeKarti mk = new Kartlar.MalzemeKarti();
            tabOlustur("Malzeme Kartı", mk);
        }

        private void firmaKartıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kartlar.FirmaKarti fk = new Kartlar.FirmaKarti();
            tabOlustur("Firma Kartı", fk);
        }

        private void malzemeDepoGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depolar.MalzemeDepo.MalzemeDepoGiris mg = new Depolar.MalzemeDepo.MalzemeDepoGiris();
            tabOlustur("Malzeme Depo Giriş", mg);
        }

        private void malzemeDepoÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depolar.MalzemeDepo.MalzemeDepoCikis mk = new Depolar.MalzemeDepo.MalzemeDepoCikis();
            tabOlustur("Malzeme Depo Çıkış", mk);
        }
    }
}
