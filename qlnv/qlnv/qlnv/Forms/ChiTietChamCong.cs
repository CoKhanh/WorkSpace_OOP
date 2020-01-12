using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlnv.Layers;
namespace qlnv.Forms
{
    public partial class ChiTietChamCong : Form
    {
        CLogin lg = new CLogin();
        public string ID;
        public string MONTH;
        public string NAME;

        public ChiTietChamCong()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            lblMaNV.Text = ID;
            lblThang.Text = MONTH;
            lblName.Text = NAME;
            dataGridChiTiet.DataSource = lg.SalaryByMonth(lblMaNV.Text, lblThang.Text);
            dataGridChiTiet.AutoResizeColumns();
        }

        private void ChiTietChamCong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnOKk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
