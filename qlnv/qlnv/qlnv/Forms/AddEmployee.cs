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
using qlnv.User_Controls;
using qlnv.Forms;
namespace qlnv
{
    public partial class AddEmployee:Form
    {
        string depname;
        string err;
        string position;
        public AddEmployee()
        {
            InitializeComponent();
		}

        void LoadData()
        {
            using (QLNVEntities qlnv = new QLNVEntities())
            {
                cbPosition.DisplayMember = "TenDA";
                cbPosition.ValueMember = "MaDA";
                cbPosition.DataSource = qlnv.DUANs;
            }

           
            cbDepartment.SelectedIndex = 0;
            cbCity.SelectedIndex = 0;
            cbSex.SelectedIndex = 0;
            cbPosition.SelectedIndex = 0;
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        #region Add
        private void button1_Click(object sender, EventArgs e)
        {
            switch(cbPosition.SelectedIndex)
            {
                case 0:
                    {
                        position = "M";
                        break;
                    }
                case 1:
                    {
                        position = "E";
                        break;
                    }
            }
                    switch (cbDepartment.SelectedIndex)
            {
                case 0:
                    {
                        depname = "IT001";
                        break;
                    }
                case 1:
                    {
                        depname = "HR001";
                        break;
                    }
                case 2:
                    {
                        depname = "FN001";
                        break;
                    }
                case 3:
                    {
                        depname = "CR001";
                        break;
                    }
                case 4:
                    {
                        depname = "MK001";
                        break;
                    }
            }
            try
            {
                CEMPLOYEE emp = new CEMPLOYEE();
                CPROJECT proj = new CPROJECT();

                emp.AddNewEmployee
					(this.txtId.Text,
					this.txtFullName.Text,
					this.dateTimePicker2.Value,
					cbSex.SelectedItem.ToString(),
					this.txtPhone.Text,
					cbCity.SelectedItem.ToString(),
					this.txtSalary.Text,
					depname,
					"Now",
					ref err);
                proj.AddNewEmpToProject(txtId.Text, "NEWBIE", txtFullName.Text);
                emp.CreateAccount(txtId.Text, "1000.1962026656160185351301320480154111117132155", position); //chuỗi 1000. ... là mật khẩu "1" sau khi đc mã hóa
                MessageBox.Show("Done");
                this.Close();

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        #endregion
        private void AddEmployee_Load(object sender, EventArgs e)
        {
            cbPosition.SelectedIndex = 0;
            LoadData();
            CEMPLOYEE emp = new CEMPLOYEE();
            //đoạn này tạo ra Id mới
            int newId = emp.AutoAddNewId();
            if(newId<100)
            {
                txtId.Text = "0" + newId.ToString();
            }
            else
            {
                if(newId>100)
                {
                    txtId.Text = newId.ToString();
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //CellClick cell = new CellClick();
            //MessageBox.Show(cell.Id);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveEm2.png");
        }

        private void button1_DragLeave(object sender, EventArgs e)
        {

            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveEm.png");
        }
    }
    
}
