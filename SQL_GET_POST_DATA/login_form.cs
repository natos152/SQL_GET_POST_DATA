using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_GET_POST_DATA
{
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        static string conStr = @"Data Source=DESKTOP-FTT4EST\SQLEXPRESS;Initial Catalog=SoccerDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conStr);

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string user = userInput.Text;
            string pass = passInput.Text;
            string query = $"SELECT count(*) from Users where username = '{user}' and password = '{pass}' ";
            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@username", user);
            comm.Parameters.AddWithValue("@password", pass);
            con.Open();
            SqlDataReader res = comm.ExecuteReader();
            while (res.Read())
            {
                IDataRecord record = (IDataRecord)res;
                if ((int)record[0] == 1)
                {
                    MessageBox.Show("Success, welcome to team win", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    team_form t = new team_form();
                    t.Show();
                    userInput.Clear();
                    passInput.Clear();
                }
                else
                {
                    MessageBox.Show("Error, check your detiles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userInput.Focus();
                    userInput.Clear();
                    passInput.Clear();
                }
            }
            con.Close();
        }

        private void passInput_TextChanged(object sender, EventArgs e)
        {
            passInput.PasswordChar = '*';
            passInput.MaxLength = 10;
        }
    }
}
