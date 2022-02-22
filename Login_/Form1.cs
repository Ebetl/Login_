using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient; 

namespace Login_
{
    public partial class LoginForm : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com; 

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            // Don't forget to update your datasource link
            con = new SqlConnection("Data Source=**** ;Initial Catalog=***;User ID=***;Password=*");
            com = new SqlCommand();
            con.Open();
            com.Connection=con;
            com.CommandText="Select * from User_Information Where userName = '"+ textBox1.Text +
                "' And password= '" +textBox2.Text + "'";  
            dr= com.ExecuteReader();

            if(dr.Read())
            {
                MessageBox.Show(" Congratulations. Login Succesful");
                MessageForm state = new MessageForm();
                state.Show();
                this.Hide();                    
            } 
            else
            { 
                MessageBox.Show("Wrong username or password");
            }

            con.Close();
        }
    }
}
