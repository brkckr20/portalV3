using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalV3._1.Kartlar
{
    public partial class MalzemeKarti : Form
    {
        public MalzemeKarti()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.SarfMalzemeKartiTableAdapter ds = new DataSet1TableAdapters.SarfMalzemeKartiTableAdapter();
        Utils.BildirimGoster bildirim = new Utils.BildirimGoster();

        private void MalzemeKarti_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.GetData();
        }

        private void btnMalzemeKartiKaydet_Click(object sender, EventArgs e)
        {
            if (txtMalzemeKodu.Enabled)
            {
                ds.KartEkle(txtMalzemeKodu.Text, txtMalzemeAdi.Text, txtBirim.Text, txtMarka.Text);
                bildirim.Basarili("Malzeme Kartı başarıyla eklendi", "Bilgi");
                dataGridView1.DataSource = ds.GetData();
            }
            else
            {
                ds.KartGuncelle(txtMalzemeAdi.Text,txtBirim.Text,txtMarka.Text,txtMalzemeKodu.Text);
                bildirim.Basarili("Malzeme Kartı başarıyla güncellendi", "Bilgi");
                dataGridView1.DataSource = ds.GetData();
            }
        }

        private void btmMalzemeKartiSil_Click(object sender, EventArgs e)
        {
            if (bildirim.onayAl("Kart silinecek emin misiniz", "Dikkat"))
            {
                ds.KartSil(txtMalzemeKodu.Text);
                bildirim.Basarili("Malzeme Kartı başarıyla silindi", "Bilgi");
            }
            else
            {
                bildirim.Basarisiz("Malzeme kartı silme işlemi iptal edildi", "Bilgi");
            }
            
            dataGridView1.DataSource = ds.GetData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMalzemeKodu.Enabled = false;
            txtMalzemeKodu.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMalzemeAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBirim.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnMalzemeKartiYeni_Click(object sender, EventArgs e)
        {
            txtMalzemeKodu.Enabled = true;
            txtMalzemeKodu.Text = "";
            txtMalzemeAdi.Text = "";
            txtBirim.Text = "";
            txtMarka.Text = "";
        }
    }
}
