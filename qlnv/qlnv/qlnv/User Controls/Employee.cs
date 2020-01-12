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
    public partial class Employee : UserControl
    {
        #region Set Employee User Control
        private static Employee emp;
        public static Employee EMP
        {
            get
            {
                if (emp == null)
                    emp= new Employee();
                return emp;
            }
        }
        #endregion
        #region Init
        CEMPLOYEE dbEmp = new CEMPLOYEE();
        Paramater_Emps SelectEmp;
        bool flag = false;
        public Employee()
        {
            InitializeComponent();
            txtSearch.ForeColor = Color.LightGray;
            txtSearch.Text = "Enter Employee's ID";
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Enter Employee's ID";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter Employee's ID")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            try
            {
                dataGridEmployee.DataSource = dbEmp.LoadEmployeeInfo(txtSearch.Text);
                dataGridEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridEmployee.AutoResizeColumns();
                dataGridEmployee_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("System Error!!");
            }
        }
        #endregion
        #region Events
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            flag = true;
            LoadData();
            flag = false;
        }
        private void dataGridEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == false)
            {
                int r = dataGridEmployee.CurrentCell.RowIndex;
                DateTime date = DateTime.ParseExact(dataGridEmployee.Rows[r].Cells[2].Value.ToString(), "dd/MM/yyyy", null);
                SelectEmp = new Paramater_Emps
                    (dataGridEmployee.Rows[r].Cells[0].Value.ToString(),
                    dataGridEmployee.Rows[r].Cells[1].Value.ToString(),
                    date,
                    /*sex*/dataGridEmployee.Rows[r].Cells[3].Value.ToString(),
                    dataGridEmployee.Rows[r].Cells[4].Value.ToString(),
                    /*Add*/dataGridEmployee.Rows[r].Cells[5].Value.ToString(),
                    dataGridEmployee.Rows[r].Cells[6].Value.ToString(),
                    /*Dep*/dataGridEmployee.Rows[r].Cells[7].Value.ToString(),
                    dataGridEmployee.Rows[r].Cells[8].Value.ToString());
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee AddEmpForm = new AddEmployee();
            AddEmpForm.ShowDialog();
            LoadData();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
			dataGridEmployee_CellClick(null, null);
			EditEmp editForm = new EditEmp();
			
			editForm.LoadForEdit(SelectEmp);
            editForm.ShowDialog();
            LoadData();
        }
        private void BtnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
		

		private void btnDele_Click(object sender, EventArgs e)
		{
            try
            {
                int r = dataGridEmployee.CurrentCell.RowIndex;

                string strStaffiD = dataGridEmployee.Rows[r].Cells[0].Value.ToString();
                string newNow = "No";

                DialogResult rs;
                rs = MessageBox.Show("Do you want to delete", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    dbEmp.ChangeNowWorkingToNo(strStaffiD, newNow);
                    LoadData();
                    MessageBox.Show("Done");
                }
            }
            catch
            {
                MessageBox.Show("Can not delete");
            }
        }
        private void btnStatistical_Click(object sender, EventArgs e)
        {
            Luong tk = new Luong();
            tk.ShowDialog();
        }
        #endregion
        #region Set Image
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Add2.png");
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Add.png");
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Edit2.png");
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Edit.png");
        }

        private void btnDele_MouseEnter(object sender, EventArgs e)
        {
            btnDele.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Del2.png");
        }

        private void btnDele_MouseLeave(object sender, EventArgs e)
        {
            btnDele.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Del.png");
        }

        private void btnStatistical_MouseEnter(object sender, EventArgs e)
        {
            btnStatistical.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Sta2.png");
        }

        private void btnStatistical_MouseLeave(object sender, EventArgs e)
        {
            btnStatistical.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Sta.png");
        }

        private void btnReload_MouseEnter(object sender, EventArgs e)
        {
            btnReload.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Re2.png");
        }

        private void btnReload_MouseLeave(object sender, EventArgs e)
        {
            btnReload.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Re.png");
        }
        #endregion
    }

}
