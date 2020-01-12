using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlnv.Forms;
using qlnv.Layers;
namespace qlnv.Forms
{
    public partial class ChamCong : Form
    {
        public string ID;
        public string PASS;
        public int isStaff;
        public string month;
        public bool checkPassForEditInfo = false;
        public bool checkPassForEditPass = false;
        public bool CheckMonth = false;
        int Salary;
        int Month = DateTime.Now.Month;
        public ChamCong()
        {
            InitializeComponent();
        }

        void LoadData()
        {

            CEMPLOYEE emp = new CEMPLOYEE();
            CLogin lg = new CLogin();
            ChiTietChamCong cc = new ChiTietChamCong();

            Salary = 0;
            string empId = emp.ID(ID);
            string empPass = emp.Password(PASS);
            string empName = emp.FULLNAME(ID);
            DateTime empBirth = emp.BIRTHDAY(ID);
            string empAddress = emp.ADDRESS(ID);
            string empPhone = emp.PHONE(ID);
            string empChangeId = lg.ShowId(ID);

            txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lbId.Text = empId;
            txtPerName.Text = empName;
            dtBirth.Value = empBirth;
            txtPhone.Text = empPhone;
            txtID2.Text = empChangeId;
            lbToday.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbSalary.Text = lg.SalaryPerMonth(lbId.Text.Trim(), lbMonth.Text.Trim());
            dataGridTime.DataSource = lg.LoadByMonth(lbMonth.Text.Trim(), lbId.Text.Trim());
            dataGridTime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            month = lbMonth.Text;
            if (Convert.ToInt32(month)==DateTime.Now.Month)
            {
                lbSalary.Text = "0";
                linkLabel1.Enabled = false;
            }
            else
            {
                linkLabel1.Enabled = true;
            }
            
            lg.Tre(lbId.Text,lbMonth.Text);
            lg.Month(lbId.Text.Trim(), lbMonth.Text.Trim());
            lg.ID(lbId.Text.Trim(), lbMonth.Text.Trim());
            lg.WorkingDay(lbId.Text.Trim(), lbMonth.Text.Trim());
            lg.AdsentDay(lbMonth.Text);
            lg.Proccess(lbId.Text.Trim());
            lg.Bonus();
            lg.Basicsalary(lbId.Text.Trim());
            lg.Punishment();
            CheckMonth = lg.NoneCheckedIn(lbMonth.Text, lbId.Text);
            if (CheckMonth == true) //KIEM TRA THANG DO CO DI LAM KHONG
            {
                lg.SALARY();
                Salary = Convert.ToInt32(lg.SalaryPerMonth(lbId.Text.Trim(), lbMonth.Text.Trim()));
            }
            if (lg.AddedToSalaryTable(lbId.Text, lbMonth.Text) == false)
            {
                lg.AddToSalaryTable();
            }

            for (int i = 0; i < cbCity.Items.Count; i++)
            {
                if (cbCity.Items[i].ToString() == empAddress)
                {
                    cbCity.SelectedIndex = i;
                }
            }

            emp.AutoAddNewId();
        }
        #region Events

        private void ChamCong_Load(object sender, EventArgs e)
        {
            lbMonth.Text = Month.ToString();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CLogin lg = new CLogin();

            lg.RefreshSalaryTable(lbId.Text, lbMonth.Text);
            try
            {
                lg.Checkin(lbId.Text,txtPerName.Text.Trim(), lbToday.Text, txtTime.Text.Trim(),lbMonth.Text.Trim());
                    LoadData();
                    MessageBox.Show("Done", "Checked Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("You have already checked in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            pnlXacNhanMK.Visible = true;
            pnlXacNhanMK.BringToFront();
            txtMK_cu.Focus();
            checkPassForEditPass = true;
        }

        private void lbShowPass_Click(object sender, EventArgs e)
        {
            txtRetypeNewPass.UseSystemPasswordChar = txtNew.UseSystemPasswordChar = !txtNew.UseSystemPasswordChar;
            if(txtNew.UseSystemPasswordChar)
            {
                lbShowPass.ForeColor = Color.Red;
            }
            else
            {
                lbShowPass.ForeColor = Color.DarkGray;
            }
            
        }

        private void txtRetypeNewPass_TextChanged(object sender, EventArgs e)
        {
            if (txtNew.Text!="" && (txtNew.Text == txtRetypeNewPass.Text))
            {
                lbRetype.Text = "Correct";
            }
            else
            {
                if (txtNew.Text == "" || checkPassForEditPass == false)
                    lbRetype.Text = "Not correct";
                else
                    lbRetype.Text = "Not correct";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlXacNhanMK.Visible = true;
            pnlXacNhanMK.BringToFront();
            txtMK_cu.Focus();
            checkPassForEditInfo = true;
        }

        private void txtNew_TextChanged(object sender, EventArgs e)
        {
            if (txtNew.Text != "")
            {
                btnEditAcc.Enabled = true;
            }
            else
                btnEditAcc.Enabled = false;
        }

        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CLogin lg = new CLogin();
            Month += 1;
            if (Month <= 12)
            {
                lbMonth.Text = Month.ToString();
                lg.LoadByMonth(lbMonth.Text.Trim(), lbId.Text.Trim()); //load thong tin cham cong theo thang
                LoadData();
            }
            else
            {
                Month = 1;
                lbMonth.Text = Month.ToString();
                lg.LoadByMonth(lbMonth.Text.Trim(), lbId.Text.Trim());
                LoadData();
            }
        }
        private void linkPre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CLogin lg = new CLogin();
            Month -= 1;
            if (Month >= 1)
            {
                lbMonth.Text = Month.ToString();
                lg.LoadByMonth(lbMonth.Text.Trim(), lbId.Text.Trim());
                LoadData();
            }
            else
            {
                Month = 12;
                lbMonth.Text = Month.ToString();
                lg.LoadByMonth(lbMonth.Text.Trim(), lbId.Text.Trim());
                LoadData();
            }
        }

        private void lbMonth_TextChanged(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(lbMonth.Text.Trim());
            int Month = DateTime.Now.Month;
            if(month!=Month)
            {
                btncInOut.Enabled = false;
            }
            else
            {
                btncInOut.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChiTietChamCong ct = new ChiTietChamCong();
            ct.ID = lbId.Text;
            ct.NAME = txtPerName.Text;
            ct.MONTH = lbMonth.Text;
            ct.ShowDialog();
        }
        #endregion
        #region MouseEnter Events
        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditSa2.png");
        }
        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditSa.png");
        }

        private void btnEditAcc_MouseEnter(object sender, EventArgs e)
        {
            btnEditAcc.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditSa2.png");
        }

        private void btnEditAcc_MouseLeave(object sender, EventArgs e)
        {
            btnEditAcc.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditSa.png");
        }

        private void btncInOut_MouseEnter(object sender, EventArgs e)
        {
            btncInOut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Check2.png");
        }

        private void btncInOut_MouseLeave(object sender, EventArgs e)
        {
            btncInOut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Check.png");
        }
        #endregion
        #region lbLuong and edit button
        private void picClose_Click(object sender, EventArgs e)
        {
            if (this.isStaff == 1)
            {
                DialogResult rs = MessageBox.Show("Do you want to log out?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Hide();
            }
        }
        private void label12_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(month) == DateTime.Now.Month)
            {
                MessageBox.Show("Chưa thống kê kỳ lương tháng: " + lbMonth.Text, "Kỳ lương tháng " + lbMonth.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (CheckMonth == true)
                {
                    MessageBox.Show("Nhân viên: " + txtPerName.Text + "\nKỳ lương tháng: " + lbMonth.Text + "\nLương: " + Salary, "Kỳ lương tháng " + lbMonth.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pnlXacNhanMK.Visible = false;
            pnlXacNhanMK.SendToBack();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CLogin lg = new CLogin();
            string num = lg.SubNum(lbId.Text); //lấy ra 4 ký tự đầu tiên trong chuỗi mật khẩu đã được mã hóa
            string bcryptPass = num + "." + lg.HashPass(txtMK_cu.Text);  //ma hoa mat khau
            if (lg.CheckPassWord(lbId.Text, bcryptPass) ==true) //kiểm tra tài khoản cũ nhập vào có đúng hay không
            {
                pnlXacNhanMK.Visible = false;
                pnlXacNhanMK.SendToBack();
                txtMK_cu.ResetText();
                txtMK_cu.Focus();
                lbRetype.Text = "Not correct";
                if (checkPassForEditInfo == true) //kiểm tra xem người dùng đang muốn thay đổi thông tin cá nhân hay mật khẩu
                {
                    checkPassForEditInfo = false;
                    try
                    {
                        CEMPLOYEE emp = new CEMPLOYEE();
                        emp.EditInFormChamCong(lbId.Text.Trim(), txtPerName.Text.Trim(), dtBirth.Value, cbCity.SelectedItem.ToString(), txtPhone.Text.Trim());
                        MessageBox.Show("Edited");
                    }
                    catch
                    {
                        MessageBox.Show("Can not edit");
                    }
                }
                else
                {
                    if(checkPassForEditPass==true)
                    {
                        if (txtNew.Text == txtRetypeNewPass.Text && txtNew.Text != "")
                        {
                            checkPassForEditPass = false;
                            try
                            {
                                //CLogin lg = new CLogin();
                                string hash = lg.HashPass(txtNew.Text);
                                string randomNum;
                                Random rd = new Random();
                                randomNum = rd.Next(1000, 9999).ToString();
                                string newPass = randomNum + "." + hash;
                                lg.ChangePassword(txtID2.Text.Trim(), newPass);

                                MessageBox.Show("Edited");
                                txtNew.ResetText();
                                txtRetypeNewPass.ResetText();
                                txtNew.Focus();
                            }
                            catch
                            {
                                MessageBox.Show("System's Error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Make sure that you retyped correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong password!!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMK_cu.ResetText();
                txtMK_cu.Focus();
            }
        }
        #endregion

        private void pnlXacNhanMK_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
