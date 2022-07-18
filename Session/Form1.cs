using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connection_DB;
using MySql.Data.MySqlClient;


namespace Session
{
    public partial class LoginForm : Form
    {
        connection con = new connection();
        string id, username, password;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (username_txtbox.Text != "" && password_txtbox.Text != "")
                {

                    con.Open();
                    string query = "select id,username,password from Users WHERE username ='" + username_txtbox.Text + "' AND password ='" + password_txtbox.Text + "'";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                       
                        MessageBox.Show("Login Sucessful!");
                        Dashboard openDashboard = new Dashboard();
                        this.Hide();
                        openDashboard.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Data not found", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error", "Information");

            }
        }
    }
}
