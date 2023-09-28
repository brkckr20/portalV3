using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace PortalV3._1.Components
{
    public class KapanabilirTab : TabControl
    {
        public KapanabilirTab() {
        
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            Rectangle rectCloseImage = new Rectangle(e.Bounds.Right - 16, e.Bounds.Top + 4, 12, 12);
            Image closeIconImage = Properties.Resources.CloseIcon;
            e.Graphics.DrawImage(closeIconImage, rectCloseImage);
            // Kapatma simgesi burada kullanıldı, siz kendi simgenizi ekleyebilirsiniz.

            e.Graphics.DrawString(this.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 8, e.Bounds.Top + 4);
        }
    }
}
