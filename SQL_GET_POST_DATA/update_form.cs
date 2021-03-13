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
    public partial class update_form : Form
    {
        public update_form()
        {
            InitializeComponent();
        }
        static string conStr = @"Data Source=DESKTOP-FTT4EST\SQLEXPRESS;Initial Catalog=SoccerDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conStr);


        private void updateTeamBtn_Click(object sender, EventArgs e)
        {
            string teamInput = teamUpdateInput.Text;
            string query = $"SELECT * From Teams where club_name = '{teamInput}'";
            SqlCommand comm = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sql = comm.ExecuteReader();
            if (sql.Read())
            {
                string qu =
                $"UPDATE Teams Set ";
                if (clubInput.Text != "")
                {
                    qu += $"club_name='{clubInput.Text}' ,";
                }
                if (coachInput.Text != "")
                {
                    qu += $"coach_name='{coachInput.Text}' ,";
                }
                if (winInput.Text != "")
                {
                    qu += $"wins='{winInput.Text}' ,";
                }
                if (drawInput.Text != "")
                {
                    qu += $"draws='{drawInput.Text}' ,";
                }
                if (loseInput.Text != "")
                {
                    qu += $"loses='{loseInput.Text}' ";
                }
                if (qu.EndsWith(","))
                {
                    qu = qu.Remove(qu.Length - 1);
                }
                qu += $"where club_name='{teamInput}' ";
                con.Close();
                SqlCommand updateCom = new SqlCommand(qu, con);
                con.Open();
                int res = updateCom.ExecuteNonQuery();
                con.Close();
                MessageBox.Show((res == 1 ? "" : "not ") + "submited!");
                teamUpdateInput.Clear();
                coachInput.Clear();
                clubInput.Clear();
                winInput.Clear();
                drawInput.Clear();
                loseInput.Clear();
                return;
            }
            MessageBox.Show("error");
        }
    }
}
