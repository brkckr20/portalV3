using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalV3._1.Depolar.MalzemeDepo
{
    public partial class MalzemeDepoGiris : Form
    {
        public MalzemeDepoGiris()
        {
            InitializeComponent();
            btnMalzemeDepoSil.Enabled = false;
        }
        DataSet1TableAdapters.MalzemeDepo1TableAdapter d1 = new DataSet1TableAdapters.MalzemeDepo1TableAdapter();
        
        Utils.BildirimGoster bildirim = new Utils.BildirimGoster();

        

        private void btmFirmaKartiSil_Click(object sender, EventArgs e)
        {
            if (lblKayitNo.Text == "0")
            {
                btnMalzemeDepoSil.Enabled = false;
            }
            else {
                if (bildirim.onayAl("Silmek istiyor musunuz?\nBu işlem geri alınamaz!", "Uyarı"))
                    {
                        d1.DepodanSil(int.Parse(lblKayitNo.Text));
                        sonKaydiListele();
                    }
            }
        }
        

        private void btnFirmaKartiKaydet_Click(object sender, EventArgs e)
        {
            if (lblKayitNo.Text == "0")
            {
                d1.Depo1Kaydet(txtIslemCinsi.Text, dtpTarih.Value, txtFirmaKodu.Text, txtFirmaUnvan.Text, txtBelgeNo.Text);
                int kayitNo = (int)d1.Depo1SonKayitIDGetir("SARF_MALZEME_GIRIS");
                foreach (DataGridViewRow row in malzemeGirisKalemler.Rows)
                {
                    string islem_cinsi = string.Empty; // Varsayılan olarak boş bir dize
                    if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
                    {
                        islem_cinsi = row.Cells[0].Value.ToString();
                    }
                    /*
                     INSERT INTO MalzemeDepo2
                         (KALEM_ISLEM, MALZEME_KODU, MALZEME_ADI, MIKTAR, BIRIM, UUID, REF_NO, ACIKLAMA)
VALUES        (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)
                     
                     */
                    if (!row.IsNewRow &&
                        row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null &&
                        row.Cells[5].Value != null && row.Cells[6].Value != null)
                    {
                        d1.Depo2Kaydet(
                            islem_cinsi,
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            int.Parse(row.Cells[3].Value.ToString()),
                            row.Cells[4].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            //row.Cells[5].Value.ToString(),
                            kayitNo,
                            row.Cells[7].Value.ToString());
                    }
                }

                bildirim.Basarili("Kayıt işlemi başarılı", "Bilgi");
            }
            else
            {
                int kayitNo = (int)d1.Depo1SonKayitIDGetir("SARF_MALZEME_GIRIS");
                d1.Depo1Guncelle(dtpTarih.Value, txtFirmaKodu.Text, txtFirmaUnvan.Text, txtBelgeNo.Text, kayitNo);
                foreach (DataGridViewRow row in malzemeGirisKalemler.Rows)
                {
                    string kalem_islem = string.Empty; // Varsayılan olarak boş bir dize
                    if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
                    {
                        kalem_islem = row.Cells[0].Value.ToString();
                    }

                    if (!row.IsNewRow &&
                        row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null &&
                        row.Cells[5].Value != null && row.Cells[6].Value != null)
                    {
                        d1.Depo2Guncelle(
                            kalem_islem,
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            int.Parse(row.Cells[3].Value.ToString()),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString());
                    }
                }
                bildirim.Basarili("Güncelleme işlemi başarılı", "Bilgi");
            }
        }

        private void malzemeGirisKalemler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1){
                Modals.MalzemeListesi ml = new Modals.MalzemeListesi(); // Yeni bir örnek oluşturun
                ml.ShowDialog();

                if (!string.IsNullOrEmpty(ml.malzeme_kodu) || !string.IsNullOrEmpty(ml.malzeme_adi) || !string.IsNullOrEmpty(ml.birim) || !string.IsNullOrEmpty(ml.malzeme_marka))
                {
                   // int rowIndex = malzemeGirisKalemler.Rows.Add(); // Yeni bir satır ekleyin
                    malzemeGirisKalemler.Rows[e.RowIndex].Cells[1].Value = ml.malzeme_kodu; // Veriyi ekleyin
                    malzemeGirisKalemler.Rows[e.RowIndex].Cells[2].Value = ml.malzeme_adi;
                    malzemeGirisKalemler.Rows[e.RowIndex].Cells[4].Value = ml.birim;
                    malzemeGirisKalemler.Rows[e.RowIndex].Cells[5].Value = ml.malzeme_marka;
                    malzemeGirisKalemler.Rows[e.RowIndex].Cells[6].Value = ml.uuid;
                }
            }
        }

        private void sonKaydiListele() {
            btnMalzemeDepoSil.Enabled = true;
            DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter kayitGetir = new DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter();
            DataSet1.MalzemeDepoKayitGetirDataTable sonKayitlar = kayitGetir.MalzemeDepoGirisSonKayit();

            if (sonKayitlar.Rows.Count > 0)
            {
                DataSet1.MalzemeDepoKayitGetirRow ilkSatir = sonKayitlar[0];
                DateTime ilkKayitTarih = ilkSatir.TARIH;
                dtpTarih.Text = ilkKayitTarih.ToString();
                txtFirmaKodu.Text = ilkSatir.FIRMA_KODU.ToString();
                txtFirmaUnvan.Text = ilkSatir.FIRMA_UNVAN.ToString();
                txtBelgeNo.Text = ilkSatir.BELGE_NO.ToString();
                lblKayitNo.Text = ilkSatir.REF_NO.ToString();
                malzemeGirisKalemler.Rows.Clear(); // tekrar tıklanınca alt alta eklememesi için
                foreach (DataSet1.MalzemeDepoKayitGetirRow satir in sonKayitlar)
                {
                    malzemeGirisKalemler.Rows.Add(satir.KALEM_ISLEM, satir.MALZEME_KODU, satir.MALZEME_ADI, satir.MIKTAR, satir.BIRIM, "", satir.UUID, satir.ACIKLAMA);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sonKaydiListele();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter kayitGetir = new DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter();
            DataSet1.MalzemeDepoKayitGetirDataTable sonKayitlar = kayitGetir.MalzemeDepoGirisOncekiKayit(int.Parse(lblKayitNo.Text));
            if (sonKayitlar.Rows.Count > 0)
            {
                DataSet1.MalzemeDepoKayitGetirRow ilkSatir = sonKayitlar[0];
                DateTime ilkKayitTarih = ilkSatir.TARIH;
                dtpTarih.Text = ilkKayitTarih.ToString();
                txtFirmaKodu.Text = ilkSatir.FIRMA_KODU.ToString();
                txtFirmaUnvan.Text = ilkSatir.FIRMA_UNVAN.ToString();
                txtBelgeNo.Text = ilkSatir.BELGE_NO.ToString();
                lblKayitNo.Text = ilkSatir.REF_NO.ToString();
                malzemeGirisKalemler.Rows.Clear(); // tekrar tıklanınca alt alta eklememesi için
                foreach (DataSet1.MalzemeDepoKayitGetirRow satir in sonKayitlar)
                {
                    malzemeGirisKalemler.Rows.Add(satir.KALEM_ISLEM, satir.MALZEME_KODU, satir.MALZEME_ADI, satir.MIKTAR, satir.BIRIM, "", satir.UUID, satir.ACIKLAMA);
                }
            }
            else {
                Utils.BildirimGoster bildirim = new Utils.BildirimGoster();
                bildirim.Basarisiz("Gösterilecek başka kayıt kalmadı","Uyarı");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter kayitGetir = new DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter();
            DataSet1.MalzemeDepoKayitGetirDataTable sonKayitlar = kayitGetir.MalzemeDepoSonrakiKayit(int.Parse(lblKayitNo.Text));
            if (sonKayitlar.Rows.Count > 0)
            {
                DataSet1.MalzemeDepoKayitGetirRow ilkSatir = sonKayitlar[0];
                DateTime ilkKayitTarih = ilkSatir.TARIH;
                dtpTarih.Text = ilkKayitTarih.ToString();
                txtFirmaKodu.Text = ilkSatir.FIRMA_KODU.ToString();
                txtFirmaUnvan.Text = ilkSatir.FIRMA_UNVAN.ToString();
                txtBelgeNo.Text = ilkSatir.BELGE_NO.ToString();
                lblKayitNo.Text = ilkSatir.REF_NO.ToString();
                malzemeGirisKalemler.Rows.Clear(); // tekrar tıklanınca alt alta eklememesi için
                foreach (DataSet1.MalzemeDepoKayitGetirRow satir in sonKayitlar)
                {
                    malzemeGirisKalemler.Rows.Add(satir.KALEM_ISLEM, satir.MALZEME_KODU, satir.MALZEME_ADI, satir.MIKTAR, satir.BIRIM, "", satir.UUID, "");
                }
            }
            else
            {
                Utils.BildirimGoster bildirim = new Utils.BildirimGoster();
                bildirim.Basarisiz("Gösterilecek başka kayıt kalmadı", "Uyarı");
            }
        }

        private void btnFirmaKartiYeni_Click(object sender, EventArgs e)
        {
            lblKayitNo.Text = "0";
            dtpTarih.Value = DateTime.Today;
            txtFirmaKodu.Text = "";
            txtFirmaUnvan.Text = "";
            txtBelgeNo.Text = "";
            malzemeGirisKalemler.RowCount = 1;
        }

        private void MalzemeDepoGiris_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Modals.FirmaListesi fl = new Modals.FirmaListesi();
            fl.ShowDialog();
            txtFirmaKodu.Text = fl.firmaKodu;
            txtFirmaUnvan.Text = fl.firmaUnvan;
        }
    }
}
