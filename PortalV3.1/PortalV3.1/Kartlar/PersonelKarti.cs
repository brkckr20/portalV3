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
    public partial class PersonelKarti : Form
    {
        public PersonelKarti()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.PersonelKartiTableAdapter ds = new DataSet1TableAdapters.PersonelKartiTableAdapter();
        Utils.BildirimGoster bildirim = new Utils.BildirimGoster();

        private void btnPersonelKartiKaydet_Click(object sender, EventArgs e)
        {
            if (txtKayitNo.Text == "")
            {
                try
                {
                    ds.PersonelEkle(txtAdSoyad.Text, txtDepartman.Text);
                    bildirim.Basarili("Personel kayıt işlemi başarılı", "Bilgi");
                    //resetForm();
                    sonKaydiYansit();
                    tblPersonel.DataSource = ds.PersonelGetir();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata" + ex.Message);
                }
            }
            else {
                ds.PersonelGuncelle(txtAdSoyad.Text, txtDepartman.Text, int.Parse(txtKayitNo.Text));
                bildirim.Basarili("Personel güncelleme işlemi başarılı", "Bilgi");
                tblPersonel.DataSource = ds.PersonelGetir();
            }
            
        }

        public void resetForm() {
            txtAdSoyad.Text = "";
            txtDepartman.Text = "";
            txtKayitNo.Text = "";
        }

        public void sonKaydiYansit() {
            int? sonKayitNullable = ds.SonKayitGetir();
            int sonKayit = sonKayitNullable.HasValue ? sonKayitNullable.Value : 0; // Eğer sonuc null ise 0 olarak kabul edilir
            txtKayitNo.Text = sonKayit.ToString();
        }

        private void PersonelKarti_Load(object sender, EventArgs e)
        {
            tblPersonel.DataSource = ds.PersonelGetir();
        }

        private void btnPersonelKartiYeni_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void tblPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKayitNo.Text = tblPersonel.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAdSoyad.Text = tblPersonel.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDepartman.Text = tblPersonel.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btmPersonelKartiSil_Click(object sender, EventArgs e)
        {
            if (txtKayitNo.Text == "")
            {
                bildirim.Basarisiz("Lütfen silmek istediğiniz personelin olduğu satıra tıklayınız!", "Uyarı");
            }
            else {
                if (bildirim.onayAl("Personel silenecek!\nEmin misiniz?", "Uyarı"))
                {
                    ds.PersonelSil(int.Parse(txtKayitNo.Text));
                    tblPersonel.DataSource = ds.PersonelGetir();
                }
            }
        }

    }
}
