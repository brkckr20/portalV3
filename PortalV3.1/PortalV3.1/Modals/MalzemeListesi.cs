using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalV3._1.Modals
{
    public partial class MalzemeListesi : Form
    {
        public MalzemeListesi()
        {
            InitializeComponent();
        }
        Utils.Filtrele filtrele = new Utils.Filtrele();

        public string malzeme_kodu;
        public string malzeme_adi;
        public string birim;
        public string malzeme_marka;
        Guid yeniUuid = Guid.NewGuid();
        public string uuid;

        private void MalzemeListesi_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.SarfMalzemeKartiTableAdapter smk = new DataSet1TableAdapters.SarfMalzemeKartiTableAdapter();
            tblMalzemeListesi.DataSource = smk.GetData();
        }

        private void tblMalzemeListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tblMalzemeListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satıra çift tıklanıp tıklanmadığını kontrol edin
            {
                malzeme_kodu = tblMalzemeListesi.Rows[e.RowIndex].Cells[0].Value.ToString(); // İlk hücreyi seçilen veriyi alın
                malzeme_adi = tblMalzemeListesi.Rows[e.RowIndex].Cells[1].Value.ToString();
                birim = tblMalzemeListesi.Rows[e.RowIndex].Cells[2].Value.ToString();
                malzeme_marka = tblMalzemeListesi.Rows[e.RowIndex].Cells[3].Value.ToString();
                uuid = yeniUuid.ToString();
                this.Close(); // Modal pencereyi kapatın
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrele.kodaGöreAra(textBox1.Text, tblMalzemeListesi);  
        }
    }
}
