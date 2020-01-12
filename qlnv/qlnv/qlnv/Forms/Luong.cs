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
    public partial class Luong : Form
    {
        public Luong()
        {
            InitializeComponent();
            cbThang.SelectedIndex = 0;
            cbNam.SelectedIndex = 0;
        }

        private void Luong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNVDataSet.PHONGBAN' table. You can move, or remove it, as needed.
            this.pHONGBANTableAdapter.Fill(this.qLNVDataSet.PHONGBAN);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void cbPB_SelectionChangeCommitted(object sender, EventArgs e)
        {

            this.LuongTableTableAdapter.Fill(this.DataSet1.LuongTable, cbPB.SelectedValue.ToString(), cbThang.SelectedItem.ToString());
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartLuong.Visible = !chartLuong.Visible;
            reportViewer1.Visible = !reportViewer1.Visible;

            if (chartLuong.Visible == true)
            {
                DataTable dt = GetData();

                //chartLuong.Series.Add("s1");
                chartLuong.Series["Series1"].IsValueShownAsLabel = true;
                chartLuong.Series["Series1"].Points.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chartLuong.Series["Series1"].Points.AddXY(dt.Rows[i]["TenPB"].ToString(), dt.Rows[i]["Total"].ToString());

                }
            }
        }
        private DataTable GetData()
        {
            CLogin lg = new CLogin();

            DataTable dt = new DataTable();
            using (QLNVEntities qlnv = new QLNVEntities())
            {
                var temp = from p in qlnv.PHONGBANs select p;
                dt.Columns.Add("TenPB");
                dt.Columns.Add("Total");

                foreach (var p in temp)
                {
                    int total = lg.TotalSalary(p.MaPB, cbThang.SelectedItem.ToString());
                    if (total != 0)
                    {
                        dt.Rows.Add(p.TenPB, total);
                    }
                }
            }
            return dt;
        }

        private void cbThang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (chartLuong.Visible == true) //cap nhat lai bieu do tron
            {
                this.LuongTableTableAdapter.Fill(this.DataSet1.LuongTable, cbPB.SelectedValue.ToString(), cbThang.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();

                DataTable dt = GetData();

                chartLuong.Series["Series1"].IsValueShownAsLabel = true;
                chartLuong.Series["Series1"].Points.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chartLuong.Series["Series1"].Points.AddXY(dt.Rows[i]["TenPB"].ToString(), dt.Rows[i]["Total"].ToString());

                }
            }
            else
            {
                this.LuongTableTableAdapter.Fill(this.DataSet1.LuongTable, cbPB.SelectedValue.ToString(), cbThang.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            chartLuong.Visible = !chartLuong.Visible;
            reportViewer1.Visible = !reportViewer1.Visible;

            if (chartLuong.Visible == true)
            {
                DataTable dt = GetData();
                
                chartLuong.Series["Series1"].IsValueShownAsLabel = true;
                chartLuong.Series["Series1"].Points.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chartLuong.Series["Series1"].Points.AddXY(dt.Rows[i]["TenPB"].ToString(), dt.Rows[i]["Total"].ToString());

                }
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Chart2.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Chart.png");
        }

    }
}
