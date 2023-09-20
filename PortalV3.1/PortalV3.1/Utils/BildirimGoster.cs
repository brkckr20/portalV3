using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PortalV3._1.Utils
{
    class BildirimGoster
    {

        public void Basarili(String mesaj,String baslik)
        {
            MessageBox.Show(mesaj, baslik,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public bool onayAl(String mesaj, String baslik) 
        {
            DialogResult result = MessageBox.Show(mesaj, baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return (result == DialogResult.OK);
        }

        public void Basarisiz(String mesaj,String baslik) {
            MessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
