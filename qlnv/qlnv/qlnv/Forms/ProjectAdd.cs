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
namespace qlnv
{
    public partial class ProjectAdd : Form
    {
		string DepName;
		string Now="Not Now";
        public ProjectAdd()
        {
            InitializeComponent();
			comboBox2.SelectedIndex = 0;
        }

		private void button1_Click(object sender, EventArgs e)
		{
			switch(comboBox2.SelectedIndex)
			{
				case 0:
					{
						DepName = "IT001";
						break;
					}
				case 1:
					{
						DepName = "FN001";
						break;
					}
				case 2:
					{
						DepName = "CR001";
						break;
					}
				case 3:
					{
						DepName = "HR001";
						break;
					}
				case 4:
					{
						DepName = "MK001";
						break;
					}
			}
			if(radioNow.Checked)
			{
				Now = "Now";
			}
			try
			{
				CPROJECT proj = new CPROJECT();
				proj.AddProject
					(this.txtProId.Text,
					this.txtProName.Text,
					DepName,
					this.txtBudget.Text,
					Now);
				MessageBox.Show("Done");
				this.Close();
			}
			catch
			{
				MessageBox.Show("Can not add");
			}
		}

		private void ProjectAdd_Load(object sender, EventArgs e)
		{

		}

        private void radioNow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Save2.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\Save.png");
        }
    }
}
