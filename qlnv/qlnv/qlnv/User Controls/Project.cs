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
    public partial class Project : UserControl
    {
        #region SET PROJECT USER CONTROL
        private static Project pr;
        public static Project PR
        {
            get
            {
                if (pr== null)
                    pr = new Project();
                return pr;

            }
        }
        #endregion
        CPROJECT dbPro = new CPROJECT();
        Paramater_Project selecProj;
        public Project()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtGridProject.DataSource = dbPro.LoadProjectInfo();
				dtGridProject.AutoResizeColumns();
                dtGridProject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtGridProject_CellClick(null, null);
			}
            catch
            {
                MessageBox.Show("Error");
            }
        }

        #region Events
        private void dtGridProject_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            int r = dtGridProject.CurrentCell.RowIndex;
            selecProj = new Paramater_Project
                (dtGridProject.Rows[r].Cells[0].Value.ToString(),
                dtGridProject.Rows[r].Cells[1].Value.ToString(),
                dtGridProject.Rows[r].Cells[2].Value.ToString(),
                dtGridProject.Rows[r].Cells[3].Value.ToString(),
                dtGridProject.Rows[r].Cells[4].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectAdd ProAddForm = new ProjectAdd();
            ProAddForm.ShowDialog();
			LoadData();
        }

       

        private void Project_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dtGridProject_CellClick(null, null);
            EditPro edit = new EditPro();
            edit.LoadForEdit(selecProj);
            edit.ShowDialog();
            LoadData();
        }
       
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            frmAssignProject asspr = new frmAssignProject();
            asspr.ShowDialog();
        }
        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\AddPr2.png");
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\AddPr.png");
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditPr2.png");
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\EditPr.png");
        }

        private void btnPhanCong_MouseEnter(object sender, EventArgs e)
        {
            btnPhanCong.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SeeEm2.png");
        }

        private void btnPhanCong_MouseLeave(object sender, EventArgs e)
        {
            btnPhanCong.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\SeeEm.png");
        }

        private void btnReLoad_MouseEnter(object sender, EventArgs e)
        {
            btnReLoad.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\RePr2.png");
        }

        private void btnReLoad_MouseLeave(object sender, EventArgs e)
        {
            btnReLoad.BackgroundImage = Image.FromFile(Application.StartupPath + "\\STAFF\\RePr.png");
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void DtGridProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
