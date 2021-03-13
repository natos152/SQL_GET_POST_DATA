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
    public partial class team_form : Form
    {
        public team_form()
        {
            InitializeComponent();
        }

        private void ExcNQ(string commTXT)
        {
            string conStr = @"Data Source=DESKTOP-FTT4EST\SQLEXPRESS;Initial Catalog=SoccerDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand(commTXT, con);
            con.Open();
            int res = comm.ExecuteNonQuery(); 
            con.Close();
            MessageBox.Show((res == 1 ? "" : "not ") + "submited!");
        }
        private void addTeamBtn_Click(object sender, EventArgs e)
        {
            ExcNQ($"INSERT INTO Teams(coach_name, club_name,wins,draws,loses) VALUES('{coachInput.Text}', '{clubInput.Text}','{winInput.Text}','{drawInput.Text}','{loseInput.Text}')");
            coachInput.Clear();
            clubInput.Clear();
            winInput.Clear();
            drawInput.Clear();
            loseInput.Clear();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            ExcNQ($" DELETE Teams" +
                    $" WHERE id_team={delInput.Text}");
            delInput.Clear();
        }

        private void updateFormBtn_Click(object sender, EventArgs e)
        {
            update_form update_Form = new update_form();
            update_Form.Show();
        }
    }
}
