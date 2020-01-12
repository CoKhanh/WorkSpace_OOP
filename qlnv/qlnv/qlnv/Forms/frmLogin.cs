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
    public partial class frmLogin : Form
    {
        CLogin lg = new CLogin();
        public bool IsEmployee;
        public frmLogin()
        {
            InitializeComponent();
            txtId.ForeColor = Color.LightGray;
            txtId.Text = "Please enter your ID";
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            this.txtId.Enter += new System.EventHandler(this.txtId_Enter);

            txtPassword.ForeColor = Color.LightGray;
            txtPassword.Text = "Please enter your password";
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
        }
        #region Events

        private void txtId_Leave(object sender,EventArgs e)
        {
            if(txtId.Text=="")
            {
                txtId.Text = "Please enter your ID";
                txtId.ForeColor = Color.Gray;
            }
        }

        private void txtId_Enter(object sender,EventArgs e)
        {
            if(txtId.Text=="Please enter your ID")
            {
                txtId.Text = "";
                txtId.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Enter(object sender,EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            if (txtPassword.Text == "Please enter your password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender,EventArgs e)
        {
            if (txtPassword.Text=="")
            {
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
                txtPassword.Text = "Please enter your password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void picOutLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void LoadDATA()
        {
            if (txtId.Text != "")
            {
                bool rs = lg.IsLogin(txtId.Text, txtPassword.Text);
                //if (lg.CannotLogin(txtId.Text) == false)
                //{
                    if (IsEmployee == true && radioStaff.Checked && rs == true) //nếu tài khoản là nhân viên
                    {
                        ChamCong cc = new ChamCong();
                        cc.ID = txtId.Text;
                        cc.isStaff = 1;
                        txtId.Focus();
                        this.Hide();
                        cc.ShowDialog();
                        radioStaff.Checked = true;
                        txtId.ResetText();
                        txtPassword.Text = "Please enter your password";
                        txtPassword.ForeColor = Color.LightGray;
                        txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
                        this.Show();
                    }
                    else
                    {
                        if (IsEmployee == false && radioManage.Checked && rs == true) //nếu tài khoản là quản lý
                        {
                            ChamCong cc = new ChamCong();
                            FormStart fs = new FormStart();
                            fs.ID = txtId.Text;
                            txtId.Focus();
                            this.Hide();
                            fs.ShowDialog();
                            radioStaff.Checked = true;
                            txtId.ResetText();
                            txtPassword.Text = "Please enter your password";
                            txtPassword.ForeColor = Color.LightGray;
                            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
                            this.Show();
                        }
                        else
                        {
                            if ((IsEmployee == false && radioStaff.Checked) || (IsEmployee == true && radioManage.Checked))
                            {
                                MessageBox.Show("Wrong Position", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Invalid User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                //}
            }
            else
            {
                MessageBox.Show("Invalid User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            progress.PerformStep();
            if (progress.Value == 100)
            {
                timerProgress.Stop();
                LoadDATA();
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            timerProgress.Start();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ////kiểm tra và tự động check vô checkbox
            //CLogin lg = new CLogin();
            ////hàm bên dưới để lấy ra vai trò là quản lý hay nhân viên trong csdl xem trong CLogin.cs
            //string chucvu = lg.EmployeeOrManager(txtId.Text.Trim()); 
            //if (chucvu == "E")
            //{
            //    IsEmployee = true;
            //    radioStaff.Checked = true;
            //}
            //else
            //{
            //    if (chucvu== "M")
            //    {
            //        IsEmployee = false;
            //        radioManage.Checked = true;
            //    }
            //}
        }
        #endregion

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Login2.png");
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Login.png");
        }
        
        private void label6_Click(object sender, EventArgs e)
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

        private void TxtId_Leave_1(object sender, EventArgs e)
        {
            //kiểm tra và tự động check vô checkbox
            CLogin lg = new CLogin();
            //hàm bên dưới để lấy ra vai trò là quản lý hay nhân viên trong csdl xem trong CLogin.cs
            string chucvu = lg.EmployeeOrManager(txtId.Text.Trim());
            if (chucvu == "E")
            {
                IsEmployee = true;
                radioStaff.Checked = true;
                lbForgot.Visible = false;
                lbForgot.Enabled = false;
            }
            else
            {
                if (chucvu == "M")
                {
                    IsEmployee = false;
                    radioManage.Checked = true;
                    lbForgot.Visible = true;
                    lbForgot.Enabled = true;
                }
            }
        }
    }
}
