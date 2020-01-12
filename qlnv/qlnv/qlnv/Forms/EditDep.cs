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
    public partial class EditDep : Form
    {
        CEMPLOYEE emp = new CEMPLOYEE();
        public EditDep()
        {
            InitializeComponent();
        }
        #region Edit Method
        public void LoadForEdit(Paramater_Dept dept)
        {
            //CDEPARTMENT cdept = new CDEPARTMENT();


            txtMaPB.Text = dept.MAPB;
            txtTenPB.Text = dept.TENPB;
            txtMaTrPhong.Text = dept.MATRPHONG;
            txtTrPhongName.Text = dept.TENTRPHONG;
            
        }
        
        private void EditDep_Load(object sender, EventArgs e)
        {
            txtMaPB.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtMaPB.Text != "" && this.txtTenPB.Text != "")
            {
                try
                {
                    CDEPARTMENT cdept = new CDEPARTMENT();
                    Paramater_Dept paraDept = new Paramater_Dept
                        (txtMaPB.Text, txtTenPB.Text, txtMaTrPhong.Text, txtTrPhongName.Text);
                    cdept.UpdateDept(paraDept);

                    MessageBox.Show("Edited");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Please fill in Department's Name and Department's Id fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaTrPhong_TextChanged(object sender, EventArgs e)
        {
            if (this.txtMaTrPhong.Text != "")
            {
                this.txtTrPhongName.Text = emp.FindStaff(this.txtMaTrPhong.Text);
            }
            else
            {
                this.txtTrPhongName.Text = "Invalid Employee's Id";
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveDe2.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveDe.png");
        }
    }
}
