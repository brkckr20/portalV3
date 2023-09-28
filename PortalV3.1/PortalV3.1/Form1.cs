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

        private void TabMain_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                Rectangle rectCloseImage = new Rectangle(
                    tabMain.GetTabRect(i).Right - 16,
                    tabMain.GetTabRect(i).Top + 4,
                    12, 12);

                if (rectCloseImage.Contains(e.Location))
                {
                    // Kapatma düğmesine tıklanmış.
                    tabMain.TabPages.RemoveAt(i);
                    break;
                }
            }
        }
        private Point _imagelocation = new Point(13, 5);
        private Point _imgHitArea = new Point(13, 2);
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

        /*kartlar*/
        
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

        private void personelKartıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kartlar.PersonelKarti pk = new Kartlar.PersonelKarti();
            tabOlustur("Personel Kartı", pk);
        }

        /*depolar*/
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

        private void güvenBilgisayarHizmetRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raporlar.Formlar.GuvenBilgisayarHizmetRaporu frm = new Raporlar.Formlar.GuvenBilgisayarHizmetRaporu();
            frm.Show();
        }

        
    }
}
