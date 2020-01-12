using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlnv.User_Controls
{
    public partial class Login : UserControl
    {
        public int Done = 0;
        private static Login lg;
        public static Login LG
        {
            get
            {
                if (lg == null)
                    lg = new Login();
                return lg;
            }
        }
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Done = 1;
            //this.SendToBack();
        }
    }
}
