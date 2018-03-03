using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Conferinta
{
    public partial class Settings : Form 
    {
        Form1 mainForm;
        string connectionSet;
        SqlConnection conn;

        public Settings(Form1 frm)
        {
            mainForm = frm;
            conn = mainForm.ConnectionSql;
            connectionSet = conn.ConnectionString;
            //mainForm.Enabled = false;
            
            InitializeComponent();
            saveConBtn.Enabled = false;

            ParseConnection();
        }

        private void ParseConnection()
        {
            char[] delim = { '=', ';' };
            string[] words = connectionSet.Split(delim);

            dataSourcetextBox.Text = @words[1];
            initCatTextBox.Text = words[3];
            userIDTextBox.Text = words[7];
            passTextBox.Text = words[9];
        }

        private void saveConBtn_Click(object sender, EventArgs e)
        {
            connectionSet = "Data Source = " + dataSourcetextBox.Text.Trim() + "; Initial Catalog = " + initCatTextBox.Text.Trim() + ";" +
                " Persist Security Info=True;" +
            "User ID = " + userIDTextBox.Text.Trim() + "; Password=" + passTextBox.Text.Trim();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.ConnectionString = connectionSet;

            mainForm.ConnectionSql = conn;

            this.Close();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            connectionSet = "Data Source = " + dataSourcetextBox.Text.Trim() + "; Initial Catalog = " + initCatTextBox.Text.Trim() + ";" +
                " Persist Security Info=True;" +
            "User ID = " + userIDTextBox.Text.Trim() + "; Password=" + passTextBox.Text.Trim();

            conn.ConnectionString = connectionSet;

            try
            {
                conn.Open();

                MessageBox.Show("Conexiune reusita!");

                conn.Close();

                saveConBtn.Enabled = true;
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server returned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelSetBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPass_CheckStateChanged(object sender, EventArgs e)
        {
            if(showPass.CheckState == CheckState.Checked)
            {
                passTextBox.PasswordChar = '\0';
            }
            else
            {
                passTextBox.PasswordChar = '*';
            }
        }
    }
}
