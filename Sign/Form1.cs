
using System.Data.OleDb;

namespace Sign
{
    public partial class frmRigester : Form
    {
        public frmRigester()
        {
            InitializeComponent();
        
        }
    OleDbConnection  con = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0 ;Data Sourse=db_users.mdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text ==""&&txtpassword.Text==""&&txtComPassword.Text=="")
            {
                MessageBox.Show("Username and Password fields are empty","Rigistrion fields",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else if (txtpassword.Text == txtComPassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtusername.Text + "','" + txtpassword.Text + "')";
                cmd=new OleDbCommand(register,con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtusername.Text = "";
                txtpassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your Accounts has been Successfully Created", "Regester Succusfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            else
            {
                MessageBox.Show("Password does not match ,Please Re enter", "Rigistrion fields", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtComPassword.Text = "";
                txtpassword.Focus();
            }
        }

        private void CheckbxSowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxSowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtComPassword.Text = "";
            txtusername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}