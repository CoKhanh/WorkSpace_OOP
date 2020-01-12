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
namespace qlnv
{
    public partial class AddAndEditDept : Form
    {
        CEMPLOYEE emp = new CEMPLOYEE();
        public AddAndEditDept()
        {
            InitializeComponent();
            this.txtTenTrPhong.Text = "Invalid Employee's Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtMaPB.Text != "" && this.txtTenPB.Text != "")
            {
                try
                {
                    CDEPARTMENT dept = new CDEPARTMENT();
                    dept.AddDept
                        (this.txtMaPB.Text,
                        this.txtTenPB.Text,
                        this.txtMaTrPhong.Text,
                        this.txtTenTrPhong.Text);

                    MessageBox.Show("Done");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Please fill in Department's Name and Department's Id fields","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void AddAndEditDept_Load(object sender, EventArgs e)
        {

        }

        private void txtMaTrPhong_TextChanged(object sender, EventArgs e)
        {
            //emp.FindStaff(this.txtMaTrPhong.Text);
            if (this.txtMaTrPhong.Text != "")
            {
                this.txtTenTrPhong.Text = emp.FindStaff(this.txtMaTrPhong.Text);
            }
            else
            {
                this.txtTenTrPhong.Text = "Invalid Employee's Id";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveDe2.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveDe.png");
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
