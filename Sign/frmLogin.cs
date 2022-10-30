using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sign
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;Data Sourse=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT*FROM tbl_users WHERE username='" + txtusername.Text + "'and password'" + txtpassword.Text + "'";
            cmd=new OleDbCommand(login,con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ivalid Username or Password, Please try Again","Lodn Faild",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtusername.Text = "";
                txtpassword.Text = "";
                txtusername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();
        }

        private void CheckbxSowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxSowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        
    }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRigester().Show();
            this.Hide();
        }
    }
}
