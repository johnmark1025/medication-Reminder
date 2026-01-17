using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medication_Reminder
{
    public partial class login_forn : Form
    {
        public login_forn()
        {
            InitializeComponent();
        }

        private void login_forn_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "1234";

            if (txtUser.Text == username && txtPass.Text == password)
            {
                Form1 mainForm = new Form1(txtUser.Text);
                
                this.Hide();                 // Hide login form
                mainForm.ShowDialog();       // Show next form

                this.Close();                // Close login after main form closes
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                txtPass.Clear();
                txtUser.Focus();
            }
        }
    }
}
