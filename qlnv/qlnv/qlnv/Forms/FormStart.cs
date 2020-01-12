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
using qlnv.User_Controls;
namespace qlnv
{
    public partial class FormStart : Form
    {
        public string ID;
        
        public FormStart()
        {
            InitializeComponent();
		}

		bool LoadFormLogin()
        {
            Login lg = new Login();
            if (lg.Done == 0)
                return false;
            return true;
        }

        #region Employee,Department,Project,Timekeeping Enter
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ChamCong cc = new ChamCong();
            cc.ID = this.ID;
            cc.ShowDialog();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = panel1.Visible==true?false:true;
            if(!panel1.Controls.Contains(Employee.EMP))
            {
                panel1.Controls.Add(Employee.EMP);
                //Employee.EMP.Dock = DockStyle.Fill;
                Employee.EMP.BringToFront();
            }
            else
            {
                Employee.EMP.BringToFront();
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = panel1.Visible == true ? false : true;
            if (!panel1.Controls.Contains(Department.DEP))
            {
                panel1.Controls.Add(Department.DEP);
                Department.DEP.Dock = DockStyle.Fill;
                Department.DEP.BringToFront();
            }
            else
            {
                Department.DEP.BringToFront();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = panel1.Visible == true ? false : true;
            if (!panel1.Controls.Contains(Project.PR))
            {
                panel1.Controls.Add(Project.PR);
                Project.PR.Dock = DockStyle.Fill;
                Project.PR.BringToFront();
            }
            else
            {
                Project.PR.BringToFront();
            }
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            //LoadFormLogin();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Contains(Employee.EMP))
            {
                panel1.Visible = !panel1.Visible;
                panel1.Controls.Remove(Employee.EMP);
                //Employee.EMP.Dock=DockStyle.
            }
            if (panel1.Controls.Contains(Department.DEP))
            {
                panel1.Visible = !panel1.Visible;
                panel1.Controls.Remove(Department.DEP);
            }
            if (panel1.Controls.Contains(Project.PR))
            {
                panel1.Visible = !panel1.Visible;
                panel1.Controls.Remove(Project.PR);
            }
        }

        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Em2.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Em.png");
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\De2.png");
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\As.png");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\As-1.png");
        }

      

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Time2.png");
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Time.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\De.png");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
