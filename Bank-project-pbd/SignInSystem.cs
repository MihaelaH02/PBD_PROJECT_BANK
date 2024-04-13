using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bank_project_pbd
{
    public partial class SignInSystem : Form
    {

        private OracleConnection con;

        [Obsolete]
        public SignInSystem()
        {
            InitializeComponent();
            con = DatabaseManager.Instance.Connection;
            Password.UseSystemPasswordChar = true;
            Password.PasswordChar = '*';

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM SYSTEM_PROFILE WHERE USERNAME=:username AND PASSWORD_PROFILE=:password";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = UserName.Text;
            cmd.Parameters.Add(":password", OracleDbType.Varchar2).Value = Password.Text;

            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read()) 
            {
                int idProfileIndex = reader.GetOrdinal("ID_PROFILE");
                int roleTypeIndex = reader.GetOrdinal("ID_ROLE_TYPE");

                int idProfile = (int)reader.GetDecimal(idProfileIndex);
                int roleType = (int)reader.GetDecimal(roleTypeIndex);

                if (roleType == 1)
                {
                    new AdminMainManu().ShowDialog();
                }
                else if (roleType == 2)
                {
                    new EmployeeMainManu().ShowDialog();
                }
                else;//client
            }
            else
            {
                errorProviderError.SetError(UserName, "Невалидни данни!");
                errorProviderError.SetError(Password, "Невалидни данни!");
            }
        }

        private void UserName_Validating(object sender, CancelEventArgs e)
        {
            if (UserName.Text == string.Empty)
            {
                errorProviderError.SetError(UserName, "Въведете потребителско име!");
            }
            else
            {
                errorProviderError.SetError(UserName, "");
            }

        }

        private void Password_Validating(object sender, CancelEventArgs e)
        {
            if (Password.Text == string.Empty)
            {
                errorProviderError.SetError(Password, "Въведете парола!");
            }
            else
            {
                errorProviderError.SetError(Password, "");
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {
            errorProviderError.SetError(UserName, String.Empty);
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            errorProviderError.SetError(Password, String.Empty);
        }
    }
}