using System;
using System.Collections.Generic;
using System.Data; // DataTable için
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // DataGridView için


namespace PortalV3._1.Utils
{
    class Filtrele
    {
        public void kodaGöreAra(string aramaIfadesi, DataGridView dataGridView)
        {
            if (dataGridView == null || dataGridView.DataSource == null)
            {
                // Eğer DataGridView veya veri kaynağı yoksa veya arama terimi boşsa işlem yapmayın.
                return;
            }
            DataTable tablo = (DataTable)dataGridView.DataSource;
            if (string.IsNullOrWhiteSpace(aramaIfadesi))
            {
                dataGridView.DataSource = tablo;
                return;
            }

                
            DataView dv = tablo.DefaultView;
            dv.RowFilter = "MALZEME_KODU LIKE '%" + aramaIfadesi + "%'"; // "MALZEME_KODU" sütununa göre arama yapılıyor.
            dataGridView.DataSource = dv.ToTable();
        }
    }
}
