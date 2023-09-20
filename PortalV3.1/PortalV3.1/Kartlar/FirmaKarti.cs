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
    public partial class FirmaKarti : Form
    {
        public FirmaKarti()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.CariTableAdapter cari = new DataSet1TableAdapters.CariTableAdapter();
        Utils.BildirimGoster bildirim = new Utils.BildirimGoster();

        private void FirmaKarti_Load(object sender, EventArgs e)
        {
            dgwFirmalar.DataSource = cari.CariListele();
        }

        private void btnFirmaKartiKaydet_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblKayitNo.Text) == 0)
            {
                cari.CariEkle(txtFirmaKod.Text, txtFirmaUnvan.Text);
                bildirim.Basarili("Firma kayıt işlemi başarıyla tamamlandı", "Bilgi");
                dgwFirmalar.DataSource = cari.CariListele();
            }
            else
            {
                cari.CariGuncelle(txtFirmaKod.Text, txtFirmaUnvan.Text, int.Parse(lblKayitNo.Text));
                bildirim.Basarili("Firma güncelleme işlemi başarıyla tamamlandı", "Bilgi");
                dgwFirmalar.DataSource = cari.CariListele();
            }
        }

        private void btnFirmaKartiYeni_Click(object sender, EventArgs e)
        {
            txtFirmaKod.Text = "";
            txtFirmaUnvan.Text = "";
            lblKayitNo.Text = "0";
        }

        private void btmFirmaKartiSil_Click(object sender, EventArgs e)
        {
            if (bildirim.onayAl("Kart silinecek emin misiniz?\nBu işlem geri alınamaz", "Uyarı"))
            {
                cari.CariSil(int.Parse(lblKayitNo.Text));
                dgwFirmalar.DataSource = cari.CariListele();
            }
            else {
                bildirim.Basarisiz("İşlem iptal edildi", "Bilgi");
            }
        }

        private void dgwFirmalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblKayitNo.Text= dgwFirmalar.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFirmaKod.Text = dgwFirmalar.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtFirmaUnvan.Text = dgwFirmalar.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
