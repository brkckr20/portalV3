using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalV3._1.Raporlar.Formlar
{
    public partial class GuvenBilgisayarHizmetRaporu : Form
    {
        public GuvenBilgisayarHizmetRaporu()
        {
            InitializeComponent();
        }
        
        private void GuvenBilgisayarHizmetRaporu_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=BILGIISLEM\SQLEXPRESS;Initial Catalog=PORTAL;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT
                                            FORMAT(d1.TARIH, 'dd.MM.yyyy') AS TARIH,
                                            d2.MALZEME_ADI,
                                            d2.MIKTAR,
                                            d2.BIRIM,
                                            d2.ACIKLAMA
                                        FROM MalzemeDepo1 AS d1
                                        INNER JOIN MalzemeDepo2 AS d2 ON d1.ID = d2.REF_NO
                                        WHERE d1.FIRMA_KODU = '320-01-12-025'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("RaporDataSet",dt);
            reportViewer1.LocalReport.ReportPath = @"E:\Kodlama\PortalV3\PortalV3.1\PortalV3.1\PortalV3.1\Raporlar\Formlar\GuvenBilgisayar.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
