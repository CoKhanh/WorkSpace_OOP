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
    public partial class frmAssignProject : Form
    {
        CPROJECT proj = new CPROJECT();
        CEMPLOYEE emp = new CEMPLOYEE();
        QLNVEntities qlnv = new QLNVEntities();
        string IdProj;
        public frmAssignProject()
        {
            InitializeComponent();
 
        }

        void LoadData()
        {
            cbProject.DisplayMember = "TenDA";
            cbProject.ValueMember = "MaDA";
            cbProject.DataSource = qlnv.DUANs;
            //cbProject.DataSource = proj.LoadProjectInfo();
            
            //cbProject.DataSource = qlnv.DUANs;
            
            //cbProject.DisplayMember = "TenDA";

            if (cbProject.SelectedIndex >= 0 && cbProject.SelectedIndex < cbProject.Items.Count)
            {
                dtGridEmp.DataSource = proj.LoadAssign(cbProject.SelectedItem.ToString(),txtempNo.Text);
                dtGridEmp.AutoResizeColumns();
                dtGridEmp.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        #region Events
        private void frmAssignProject_Load(object sender, EventArgs e)
        {
            cbProject.SelectedIndex = 0;
            LoadData();
        }

        private void cbProject_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtempNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtempNo.Text != "")
            {
                this.txtEmpName.Text = emp.FindStaff(this.txtempNo.Text);
            }
            else
            {
                if (this.txtempNo.Text == "")
                {
                    this.txtEmpName.Text = "Invalid Employee's Id";
                }
                else
                {
                    this.txtEmpName.Text = "Invalid Employee's Id";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            switch(cbProject.SelectedIndex)
            {
                case 0:
                    {
                        IdProj = "DA001";
                        break;
                    }
                case 1:
                    {
                        IdProj = "DA002";
                        break;
                    }
                case 2:
                    {
                        IdProj = "DA003";
                        break;
                    }
                case 3:
                    {
                        IdProj = "DA004";
                        break;
                    }
                case 4:
                    {
                        IdProj = "DA005";
                        break;
                    }
                case 5:
                    {
                        IdProj = "DA006";
                        break;
                    }
                case 6:
                    {
                        IdProj = "DA007";
                        break;
                    }
                case 7:
                    {
                        IdProj = "DA008";
                        break;
                    }
                case 8:
                    {
                        IdProj = "DA009";
                        break;
                    }
            }
            try
            {
                proj.AddNewEmpToProject(txtempNo.Text.Trim(), IdProj,txtEmpName.Text);
                MessageBox.Show("Done");
                LoadData();
            }
            catch
            {
                MessageBox.Show("Can not add new employee to" + cbProject.SelectedItem.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            proj.isdelete = true;
            LoadData();
        }
        #endregion

        private void dtGridEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\AddEm2.png");
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\AddEm.png");
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\DelEm-1.png");
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\DelEm.png");
        }
    }
}
