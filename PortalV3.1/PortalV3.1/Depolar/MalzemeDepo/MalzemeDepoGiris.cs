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
                        sonKaydiListele("son");
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
                    if (!row.IsNewRow &&
                        row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null &&
                        row.Cells[7].Value != null && row.Cells[6].Value != null)
                    {
                        d1.Depo2Kaydet(
                            islem_cinsi,
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            int.Parse(row.Cells[3].Value.ToString()),
                            row.Cells[4].Value.ToString(),
                            row.Cells[6].Value.ToString(),
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
                        d1.Depo2Guncelle( //UPDATE MalzemeDepo2 SET KALEM_ISLEM = @P1,MALZEME_KODU=@P2,MALZEME_ADI=@P3,MIKTAR=@P4,BIRIM=@P5,ACIKLAMA=@P6 WHERE UUID = @P7
                            kalem_islem,
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            int.Parse(row.Cells[3].Value.ToString()),
                            row.Cells[4].Value.ToString(),
                            row.Cells[7].Value.ToString(),
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

        DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter kayitGetir = new DataSet1TableAdapters.MalzemeDepoKayitGetirTableAdapter();
        private void sonKaydiListele(string geriMiIleriMiSonKayitMi)
        {
            btnMalzemeDepoSil.Enabled = true;
            //son kayit icin 
            DataSet1.MalzemeDepoKayitGetirDataTable sonKayitlar = kayitGetir.MalzemeDepoGirisSonKayit();
            //onceki kayit icin 
            DataSet1.MalzemeDepoKayitGetirDataTable oncekiKayit = kayitGetir.MalzemeDepoGirisOncekiKayit(int.Parse(lblKayitNo.Text));
            //sonraki kayit icin
            DataSet1.MalzemeDepoKayitGetirDataTable sonrakiKayit = kayitGetir.MalzemeDepoSonrakiKayit(int.Parse(lblKayitNo.Text));


            if(geriMiIleriMiSonKayitMi == "sonKayit"){
                if (sonKayitlar != null)
                {
                    DateTime kayitTarih = sonKayitlar[0].TARIH;
                    dtpTarih.Text = kayitTarih.ToString();
                    txtFirmaKodu.Text = sonKayitlar[0].FIRMA_KODU;
                    txtFirmaUnvan.Text = sonKayitlar[0].FIRMA_UNVAN;
                    txtBelgeNo.Text = sonKayitlar[0].BELGE_NO;
                    lblKayitNo.Text = sonKayitlar[0].REF_NO.ToString();
                    malzemeGirisKalemler.Rows.Clear();
                    foreach (var satir in sonKayitlar)
                    {
                        malzemeGirisKalemler.Rows.Add(satir.KALEM_ISLEM, satir.MALZEME_KODU, satir.MALZEME_ADI, satir.MIKTAR, satir.BIRIM, "", satir.UUID, satir.ACIKLAMA);
                    }
                }
                else {
                    bildirim.Basarisiz("Gösterilecek başka kayıt kalmadı!", "Uyarı");
                }
            }else if (geriMiIleriMiSonKayitMi == "oncekiKayit"){
                if (oncekiKayit != null && oncekiKayit.Rows.Count > 0)
                {
                    DateTime kayitTarih = oncekiKayit[0].TARIH;
                    dtpTarih.Text = kayitTarih.ToString();
                    txtFirmaKodu.Text = oncekiKayit[0].FIRMA_KODU;
                    txtFirmaUnvan.Text = oncekiKayit[0].FIRMA_UNVAN;
                    txtBelgeNo.Text = oncekiKayit[0].BELGE_NO;
                    lblKayitNo.Text = oncekiKayit[0].REF_NO.ToString();
                    malzemeGirisKalemler.Rows.Clear();
                    foreach (var satir in oncekiKayit)
                    {
                        malzemeGirisKalemler.Rows.Add(satir.KALEM_ISLEM, satir.MALZEME_KODU, satir.MALZEME_ADI, satir.MIKTAR, satir.BIRIM, "", satir.UUID, satir.ACIKLAMA);
                    }
                }
                else
                {
                    bildirim.Basarisiz("Gösterilecek başka kayıt kalmadı!", "Uyarı");
                }
            }else if(geriMiIleriMiSonKayitMi == "sonrakiKayit"){
                if (sonrakiKayit != null && sonrakiKayit.Rows.Count >0 ) {
                    DateTime kayitTarih = sonrakiKayit[0].TARIH;
                    dtpTarih.Text = kayitTarih.ToString();
                    txtFirmaKodu.Text = sonrakiKayit[0].FIRMA_KODU;
                    txtFirmaUnvan.Text = sonrakiKayit[0].FIRMA_UNVAN;
                    txtBelgeNo.Text = sonrakiKayit[0].BELGE_NO;
                    lblKayitNo.Text = sonrakiKayit[0].REF_NO.ToString();
                    malzemeGirisKalemler.Rows.Clear();
                    foreach (var satir in sonrakiKayit)
                    {
                        malzemeGirisKalemler.Rows.Add(satir.KALEM_ISLEM, satir.MALZEME_KODU, satir.MALZEME_ADI, satir.MIKTAR, satir.BIRIM, "", satir.UUID, satir.ACIKLAMA);
                    }
                }
                else
                {
                    bildirim.Basarisiz("Gösterilecek başka kayıt kalmadı!", "Uyarı");
                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sonKaydiListele("sonKayit");            
        }

       private void button1_Click(object sender, EventArgs e)
        {
            sonKaydiListele("oncekiKayit");
        }

      private void button2_Click(object sender, EventArgs e)
        {
            sonKaydiListele("sonrakiKayit");
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
