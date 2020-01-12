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
    public partial class EditPro : Form
    {
        string DEP;
        string NOW;
        public EditPro()
        {
            InitializeComponent();
            cbDEP.SelectedIndex = 0;
        }

        #region Edit Method
        public void LoadForEdit(Paramater_Project proj)
        {
            txtProId.Text = proj.MADA;
            txtProName.Text = proj.TENDA;

            if (proj.DEP.Trim() == "FN001")
            {
                cbDEP.SelectedIndex = 1;
            }
            else
            {
                if (proj.DEP.Trim() == "IT001")
                    cbDEP.SelectedIndex = 0;
                else
                {
                    if (proj.DEP.Trim() == "MK001")
                        cbDEP.SelectedIndex = 4;
                    else
                    {
                        if (proj.DEP.Trim() == "CR001")
                            cbDEP.SelectedIndex = 2;
                        else
                        {
                            if (proj.DEP.Trim() == "HR001")
                                cbDEP.SelectedIndex = 3;
                        }
                    }
                }
            }
            txtBudget.Text = proj.CHIPHI;
            if(proj.NOWINWORKING.Trim()=="Now")
            {
                radioNow.Checked = true;
            }
            else
            {
                radioNotNow.Checked = true;
            }
            
        }
        #endregion
        private void EditPro_Load(object sender, EventArgs e)
        {
            txtProId.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbDEP.SelectedIndex)
            {
                case 0:
                    {
                        DEP = "IT001";
                        break;
                    }
                case 1:
                    {
                        DEP = "FN001";
                        break;
                    }
                case 2:
                    {
                        DEP = "CR001";
                        break;
                    }
                case 3:
                    {
                        DEP = "HR001";
                        break;
                    }
                case 4:
                    {
                        DEP = "MK001";
                        break;
                    }
            }
            if (radioNow.Checked)
            {
                NOW = "Now";
            }
            else
            {
                if (radioNotNow.Checked)
                    NOW = "Not Now";
            }
            try
            {
                CPROJECT projs = new CPROJECT();
                Paramater_Project paraProj = new Paramater_Project
                    (txtProId.Text, txtProName.Text, DEP, txtBudget.Text, NOW);
                projs.UpdateProject(paraProj);
                MessageBox.Show("Edited");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Can not edited");
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Save2.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Save.png");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
