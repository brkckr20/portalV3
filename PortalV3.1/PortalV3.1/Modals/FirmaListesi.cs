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
    public partial class FirmaListesi : Form
    {
        public FirmaListesi()
        {
            InitializeComponent();
        }
        public string firmaKodu { get; private set; }
        public string firmaUnvan { get; private set; }

        private void FirmaListesi_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.CariTableAdapter cariListesi = new DataSet1TableAdapters.CariTableAdapter();
            tblFirmaListesi.DataSource = cariListesi.CariListele();
        }

        private void tblFirmaListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satıra çift tıklanıp tıklanmadığını kontrol edin
            {
                firmaUnvan = tblFirmaListesi.Rows[e.RowIndex].Cells[2].Value.ToString();
                firmaKodu = tblFirmaListesi.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Close(); // Modal pencereyi kapatın
            }
        }
    }
}
