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
    public partial class MalzemeDepoCikis : Form
    {
        public MalzemeDepoCikis()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.MalzemeDepo1TableAdapter d1 = new DataSet1TableAdapters.MalzemeDepo1TableAdapter();
        Utils.BildirimGoster bildirim = new Utils.BildirimGoster();

        private void button4_Click(object sender, EventArgs e)
        {
            Modals.FirmaListesi fl = new Modals.FirmaListesi();
            fl.ShowDialog();
            lblFirmaUnvanText.Text = fl.firmaUnvan;
            txtFirmaKodu.Text = fl.firmaKodu;
        }

        private void MalzemeDepoCikis_Load(object sender, EventArgs e)
        {
            malzemeDepoDurumuGetir();
        }

        public void malzemeDepoDurumuGetir() {
            DataSet1TableAdapters.MalzemeDepoStokDurumTableAdapter stokDurum = new DataSet1TableAdapters.MalzemeDepoStokDurumTableAdapter();
            tblMalzemeDepoDurum.DataSource = stokDurum.MalzemeDepoHavuzDurumuGetir();
        }

        private void tblMalzemeDepoDurum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tblMalzemeDepoDurum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow selectedRow = tblMalzemeDepoDurum.Rows[e.RowIndex];
                if(tblMalzemeCikis.Rows.Count > 0){
                    tblMalzemeCikis.Rows[0].Cells[1].Value = selectedRow.Cells[0].Value.ToString(); //malzeme kodu
                    tblMalzemeCikis.Rows[0].Cells[2].Value = selectedRow.Cells[1].Value.ToString(); // malzeme adı
                    tblMalzemeCikis.Rows[0].Cells[4].Value = selectedRow.Cells[3].Value.ToString();
                    tblMalzemeCikis.Rows[0].Cells[9].Value = selectedRow.Cells[4].Value.ToString(); // uuid değerini aktarma işlemi
                }
            }
        }

        private void btnMalzemeDepoCikisKaydet_Click(object sender, EventArgs e)
        {
           try 
            {
                if (lblKayitNo.Text == "0")
                {
                    d1.Depo1Kaydet(txtIslemCinsi.Text, dtpTarih.Value, txtFirmaKodu.Text, lblFirmaUnvanText.Text, "");
                    int kayitNo = (int)d1.Depo1SonKayitIDGetir(txtIslemCinsi.Text.ToString());

                    foreach (DataGridViewRow row in tblMalzemeCikis.Rows)
                    {
                        if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                        {
                            d1.Depo2CikisKaydet(
                                row.Cells[0].Value.ToString(),
                                row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "",
                                row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "",
                                row.Cells[3].Value != null ? int.Parse(row.Cells[3].Value.ToString()) : 0,
                                row.Cells[4].Value != null ? row.Cells[4].Value.ToString() : "",
                                row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : "",
                                row.Cells[6].Value != null ? row.Cells[6].Value.ToString() : "",
                                row.Cells[7].Value != null ? row.Cells[7].Value.ToString() : "",
                                row.Cells[8].Value != null ? row.Cells[8].Value.ToString() : "",
                                row.Cells[9].Value != null ? row.Cells[9].Value.ToString() : "",
                                kayitNo
                            );
                        }
                    }

                    bildirim.Basarili("Kayıt işlemi başarılı", "Bilgi");
                    malzemeDepoDurumuGetir();
                }
                else {
                    d1.Depo1Kaydet(txtIslemCinsi.Text, dtpTarih.Value, txtFirmaKodu.Text, lblFirmaUnvanText.Text, "");
                    int kayitNo = (int)d1.Depo1SonKayitIDGetir(txtIslemCinsi.Text.ToString());
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Hata Oluştu: " + ex.Message);
            }

          }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnMalzemeDepoCikisYeni_Click(object sender, EventArgs e)
        {
            lblKayitNo.Text = "0";
            dtpTarih.Value = DateTime.Today;
            txtFirmaKodu.Text = "";
            lblFirmaUnvanText.Text = "";
            tblMalzemeCikis.RowCount = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
     }
}
