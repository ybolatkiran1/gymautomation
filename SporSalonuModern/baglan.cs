using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SporSalonuModern
{
    internal class SidebarAnimasyon
    {
      public void Animasyon1(bool sidebarExpend,Panel sidebar,Timer timer1)
        {

            if (sidebarExpend)
            {
                sidebar.Width -= 20;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpend = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 20;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpend = true;
                    timer1.Stop();
                }
            }
        }
    }
}
