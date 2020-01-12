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
namespace qlnv
{
    public partial class EditEmp : Form
    {
		string DEP;
        string position;
        public EditEmp()
        {
            InitializeComponent();
			cbSex.SelectedIndex=0 ;
			cbCity.SelectedIndex = 0;
			cbDepartment.SelectedIndex = 0;
            cbPosition.SelectedIndex = 0;
        }
        #region Edit Method
        public void LoadForEdit(Paramater_Emps emp)
        {
            CLogin lg = new CLogin();
			txtId.Text = emp.MANV;
            txtFullName.Text = emp.HOTEN;
            dateTimePicker2.Value = emp.NGAYSINH;
            position = lg.LoadPositionForEdit(txtId.Text);

            if(position=="E")
            {
                cbPosition.SelectedIndex = 1;
            }
            else
            {
                if(position=="M")
                {
                    cbPosition.SelectedIndex = 0;
                }
            }
			if (emp.SEX.Trim() == "Nam")
			{
				cbSex.SelectedIndex = 0;
			}
			else
			{
				cbSex.SelectedIndex = 1;
			}

			if (emp.DEP.Trim() == "FN001")
			{
				cbDepartment.SelectedIndex = 2;
			}
			else
			{
				if (emp.DEP.Trim() == "IT001")
					cbDepartment.SelectedIndex = 0;
				else
				{
					if (emp.DEP.Trim() == "MK001")
						cbDepartment.SelectedIndex = 4;
					else
					{
						if (emp.DEP.Trim() == "CR001")
							cbDepartment.SelectedIndex = 3;
						else
						{
							if (emp.DEP.Trim() == "HR001")
								cbDepartment.SelectedIndex = 1;
						}
					}
				}
			}

			for (int k = 0; k < cbCity.Items.Count; k++)
            {
                if (emp.ADDRESS.Trim() == cbCity.Items[k].ToString())
                {
                    cbCity.SelectedIndex = k;
                }
            }

            txtPhone.Text = emp.PHONE;
            txtSalary.Text = emp.SALARY;
        }
        #endregion
        private void EditEmp_Load(object sender, EventArgs e)
        {
			txtId.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (cbPosition.SelectedIndex)
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
						DEP = "IT001";
						break;
					}
				case 1:
					{
						DEP = "HR001";
						break;
					}
				case 2:
					{
						DEP = "FN001";
						break;
					}
				case 3:
					{
						DEP = "CR001";
						break;
					}
				case 4:
					{
						DEP = "MK001";
						break;
					}
			}
			try
			{
				CEMPLOYEE emps = new CEMPLOYEE();
				Paramater_Emps paraEmp = new Paramater_Emps
					(txtId.Text, txtFullName.Text, dateTimePicker2.Value, cbSex.SelectedItem.ToString(), txtPhone.Text, cbCity.SelectedItem.ToString(), txtSalary.Text, DEP, "NOW");
				emps.UpdateEmp(paraEmp);
                emps.UpdatePosition(txtId.Text, position);
				MessageBox.Show("Edited");
				this.Close();
			}
			catch
			{
				MessageBox.Show("Can not edit");
			}
		}
        #region btnSave_MouseEnter,btnSave_MouseLeave
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveEm2.png");
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SaveEm.png");
        }
        #endregion

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                CLogin lg = new CLogin();
                lg.ChangePassword(txtId.Text, "1000.1962026656160185351301320480154111117132155");
                MessageBox.Show("Your password has been reset!\nYour new password: 1", "Reset Password!!");
            }
            else
            {
                MessageBox.Show("Please to type your ID!", "Warning");
            }
        }
    }

}
