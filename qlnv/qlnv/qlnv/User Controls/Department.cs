using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlnv.Layers;
using qlnv.Forms;
namespace qlnv.User_Controls
{
    public partial class Department : UserControl
    {
        #region Set UserControl
        private static Department dep;
        public static Department DEP
        {
            get
            {
                    if (dep == null)
                        dep = new Department();
                    return dep;
                
            }
        }
        #endregion
        CDEPARTMENT dbDe = new CDEPARTMENT();
        CEMPLOYEE emp = new CEMPLOYEE();
        Paramater_Dept SelectDept;
        public Department()
        {
            InitializeComponent();
        }
        #region LoadData, dataGridDep_CellClick,daGridlstDep_CellClick
        void LoadData()
        {
            try
            {
                
                dataGridDep.DataSource = dbDe.LoadDepartmentInfo();
                dataGridDep.AutoResizeColumns();
                dataGridDep.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
                dataGridDep_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void dataGridDep_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            int r = dataGridDep.CurrentCell.RowIndex;
            SelectDept = new Paramater_Dept
                (dataGridDep.Rows[r].Cells[0].Value.ToString(),
                dataGridDep.Rows[r].Cells[1].Value.ToString(),
                dataGridDep.Rows[r].Cells[2].Value.ToString(),
                dataGridDep.Rows[r].Cells[3].Value.ToString());
        }

        private string daGridLstDep_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            int r = dataGridDep.CurrentCell.RowIndex;
            string DepId = dataGridDep.Rows[r].Cells[0].Value.ToString();
            return DepId;
        }
        #endregion
       
        private void button10_Click(object sender, EventArgs e)
        {
            AddAndEditDept AddAndDeptForm = new AddAndEditDept();
            AddAndDeptForm.ShowDialog();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAndEditDept addDept = new AddAndEditDept();
            addDept.ShowDialog();
            LoadData();
            btnList.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGridDep_CellClick(null, null);
            EditDep editDept = new EditDep();
            editDept.LoadForEdit(SelectDept);
            editDept.ShowDialog();
            LoadData();
            btnList.Enabled = true;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridDep.DataSource = emp.LoadListEmpOfPerDept(daGridLstDep_CellClick(null, null));
                dataGridDep.AutoResizeColumns();
                label2.Text = "List of Employee";
                btnList.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Please choose a Department!");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            label2.Text = "List of Department";
            LoadData();
            btnList.Enabled = true;
        }

        private void dataGridDep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\AddDe2.png");
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\AddDe.png");
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditDe2.png");
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditDe.png");
        }

        private void btnList_MouseEnter(object sender, EventArgs e)
        {
            btnList.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\See2.png");
        }

        private void btnList_MouseLeave(object sender, EventArgs e)
        {
            btnList.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\See.png");
        }

        private void btnReload_MouseEnter(object sender, EventArgs e)
        {
            btnReload.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\ReDe2.png");
        }

        private void btnReload_MouseLeave(object sender, EventArgs e)
        {
            btnReload.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\ReDe.png");
        }
    }
}
