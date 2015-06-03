using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data.SqlClient;

namespace Umetzu
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            textBox2.Focus();
        }

        private void ProcessLogin()
        {
            string user = textBox1.Text;
            string pass = textBox2.Password;

            using (var con = new SqlConnection(string.Format("Data Source=.;Initial Catalog=umetzu_db;user={0};password={1};Persist Security Info=True;", user, pass)))
            {
                try
                {
                    con.Open();
                    con.Close();
                    DialogResult = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Try Again.");
                }
            }
        }
        
        private void textBox1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                ProcessLogin();
            }
        }

        private void textBox2_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                ProcessLogin();
            }
        }
    }
}
