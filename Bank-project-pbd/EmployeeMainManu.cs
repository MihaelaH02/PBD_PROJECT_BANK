using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Bank_project_pbd
{//test add -can`t connect profile to client, delete add edit
    public partial class EmployeeMainManu : Form
    {
        private OracleConnection con;

        public EmployeeMainManu()
        {
            InitializeComponent();
            InitializeComponent();
            con = DatabaseManager.Instance.Connection;
            this.Controls.Add(AddNewClientPanel);
            this.Controls.Add(FindClientPanel);
            PasswordClientAddTextBox.UseSystemPasswordChar = true;
            PasswordClientAddTextBox.PasswordChar = '*';
            ResultsFindClientTable.Visible = false;
        }

        private void AddNewClienrMenuItem_Click(object sender, EventArgs e)
        {

            TitleClientInfoLabel.Text = "Добави нов клиент";
            TitleClientInfoButton.Text = "Добави клиент";
            TypeProfileClientAddComboBox.Enabled = false;
            TypeProfileClientAddComboBox.SelectedIndex = 2;
            FindClientPanel.Visible = false;
            AddNewClientPanel.BringToFront();
            AddNewClientPanel.Visible = true;
            ResultsFindClientTable.Controls.Clear();
        }

        private void TitleClientInfoButton_Click(object sender, EventArgs e)
        {
            if (TitleClientInfoButton.Text.Equals("Добави клиент"))
            {
                OracleCommand commandAddProfile = new OracleCommand("insert_system_profile", con);
                commandAddProfile.CommandType = CommandType.StoredProcedure;
                commandAddProfile.Parameters.Add("p_username", OracleDbType.Varchar2).Value = UsernameClientAddTextBox.Text;
                commandAddProfile.Parameters.Add("p_password_profile", OracleDbType.Varchar2).Value = PasswordClientAddTextBox.Text;
                commandAddProfile.Parameters.Add("p_id_role_type", OracleDbType.Int32).Value = 3;
                commandAddProfile.Parameters.Add("p_id_employee", OracleDbType.Int32).Value = null;
                commandAddProfile.Parameters.Add("p_id_client", OracleDbType.Int32).Value = null;
                commandAddProfile.ExecuteNonQuery();

                int newIdProfile = Convert.ToInt32(new OracleCommand("SELECT MAX(id_profile) FROM system_profile", con).ExecuteScalar());

                OracleCommand commandAddClient = new OracleCommand("CLIENT_INS", con);
                commandAddClient.CommandType = CommandType.StoredProcedure;
                commandAddClient.Parameters.Add("v_pos_name", OracleDbType.Varchar2).Value = NameClientAddTextBox.Text;
                commandAddClient.Parameters.Add("v_pos_egn", OracleDbType.Varchar2).Value = EGNClientAddTextBox.Text;
                commandAddClient.Parameters.Add("v_pos_phone", OracleDbType.Varchar2).Value = PhoneClientAddTextBox.Text;
                commandAddClient.Parameters.Add("v_pos_adress", OracleDbType.Varchar2).Value = AddressClientAddTextBox.Text;
                commandAddClient.Parameters.Add("v_pos_email", OracleDbType.Varchar2).Value = EmailClientAddTextBox.Text;
                commandAddClient.Parameters.Add("v_pos_id_profile", OracleDbType.Int32).Value = newIdProfile;
                commandAddClient.ExecuteNonQuery();//seq failed re-validation

                int newIdClient = Convert.ToInt32(new OracleCommand("SELECT MAX(id_client) FROM client", con).ExecuteScalar());
                OracleCommand commandAddClientToProfiles = new OracleCommand("UPDATE system_profile SET id_client = :id_client WHERE id_profile = :id_profile", con);
                commandAddClientToProfiles.Parameters.Add("id_profile", OracleDbType.Int32).Value = newIdProfile;
                commandAddClientToProfiles.Parameters.Add("id_client", OracleDbType.Int32).Value = newIdClient;
                commandAddClientToProfiles.ExecuteNonQuery();

                DialogResult result = MessageBox.Show("Успешно добавен служител!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    AddNewClientPanel.Controls.Clear();
                    AddNewClientPanel.Visible = false;
                }
            }

            //edit
        }

        private void CancelAddClientButton_Click(object sender, EventArgs e)
        {
            AddNewClientPanel.Visible = false;
            AddNewClientPanel.Controls.Clear();
        }

        private void FindClientMenuItem_Click(object sender, EventArgs e)
        {
            AddNewClientPanel.Visible = false;
            FindClientPanel.BringToFront();
            FindClientPanel.Visible = true;
            SearchClientTextBox.Visible = true;
            FindClientByNameButton.BackColor = System.Drawing.Color.White;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.White;
            FindClientByEGNButton.BackColor = System.Drawing.Color.White;
        }

        private void FindClientByNameButton_Click(object sender, EventArgs e)
        {
            FindClientByNameButton.BackColor = System.Drawing.Color.LightGray;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.White;
            FindClientByEGNButton.BackColor = System.Drawing.Color.White;
            SearchClientButton.Visible = true;
            SearchClientTextBox.Visible = true;
            ResultsFindClientTable.Visible = false;
            ResultsFindClientTable.Controls.Clear();
            SearchClientTextBox.Clear();
        }

        private void FindClientByPhoneButton_Click(object sender, EventArgs e)
        {
            FindClientByNameButton.BackColor = System.Drawing.Color.White;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.LightGray;
            FindClientByEGNButton.BackColor = System.Drawing.Color.White;
            SearchClientButton.Visible = true;
            SearchClientTextBox.Visible = true;
            ResultsFindClientTable.Visible = false;
            ResultsFindClientTable.Controls.Clear();
            SearchClientTextBox.Clear();
        }

        private void FindClientByEGNButton_Click(object sender, EventArgs e)
        {
            FindClientByNameButton.BackColor = System.Drawing.Color.White;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.White;
            FindClientByEGNButton.BackColor = System.Drawing.Color.LightGray;
            SearchClientButton.Visible = true;
            ResultsFindClientTable.Visible = false;
            ResultsFindClientTable.Controls.Clear();
            SearchClientTextBox.Clear();
        }
 
        private void SearchClientButton_Click(object sender, EventArgs e)
        {
            ResultsFindClientTable.Controls.Clear();
            string sql = null;
            OracleCommand cmd = con.CreateCommand();
            if (SearchClientTextBox.Text != null)
            {
                if (FindClientByNameButton.BackColor == System.Drawing.Color.LightGray)
                {
                    sql = "SELECT * FROM CLIENT WHERE name_client=:name";
                    cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = SearchClientTextBox.Text;
                }
                else if (FindClientByPhoneButton.BackColor == System.Drawing.Color.LightGray)
                {
                    sql = "SELECT * FROM CLIENT WHERE PHONE_CLIENT = :phone";
                    cmd.Parameters.Add(":phone", OracleDbType.Varchar2).Value = SearchClientTextBox.Text;
                }
                else
                {
                    sql = "SELECT * FROM CLIENT WHERE egn=:egn";
                    cmd.Parameters.Add(":egn", OracleDbType.Varchar2).Value = SearchClientTextBox.Text;
                }
                cmd.CommandText = sql;
                ShowResultsFinedClients(cmd);
            }
            //error provider
        }

        private void ShowResultsFinedClients(OracleCommand cmd)
        {
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int idClientIndex = reader.GetOrdinal("ID_CLIENT");
                int nameClientIndex = reader.GetOrdinal("NAME_CLIENT");
                int phoneClientIndex = reader.GetOrdinal("PHONE_CLIENT");
                int egnClientIndex = reader.GetOrdinal("EGN");
                int addressClientIndex = reader.GetOrdinal("ADRESS");
                int emailClientIndex = reader.GetOrdinal("EMAIL");

                EditClientButton.Tag = (int)reader.GetDecimal(idClientIndex);
                DeleteClienButton.Tag = (int)reader.GetDecimal(idClientIndex);

                FinedClientNameDataLabel.Text = reader.GetString(nameClientIndex);
                FinedClientDataPhoneLabel.Text = reader.GetString(phoneClientIndex);
                FinedClientEGNDataLabel.Text = reader.GetString(egnClientIndex);
                FinedClientAddressDataLabel.Text = reader.GetString(addressClientIndex);
                //FinedClientEmailDataLabel.Text = reader.GetString(emailClientIndex);

                string sql = "SELECT * FROM account a JOIN currency c ON a.id_currency = c.id_currency JOIN status_account sa ON a.id_status_account=sa.id_status WHERE a.id_client = :id_client";
                OracleCommand cmdAccounts = con.CreateCommand();
                cmdAccounts.Parameters.Add(":id_client", OracleDbType.Decimal).Value = (decimal)idClientIndex;
                cmdAccounts.CommandText = sql;
                OracleDataReader readerA = cmdAccounts.ExecuteReader();
                if (readerA.HasRows)
                {
                    ResultsFindClientTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                    ResultsFindClientTable.ColumnStyles.Clear();
                    ResultsFindClientTable.RowStyles.Clear();

                    ResultsFindClientTable.Controls.Add(new Label() { Text = "Номер на сметка", AutoSize = true }, 0, 0);
                    ResultsFindClientTable.Controls.Add(new Label() { Text = "Наличност", AutoSize = true }, 1, 0);
                    ResultsFindClientTable.Controls.Add(new Label() { Text = "Валута", AutoSize = true }, 2, 0);
                    ResultsFindClientTable.Controls.Add(new Label() { Text = "Лихва", AutoSize = true }, 3, 0);
                    ResultsFindClientTable.Controls.Add(new Label() { Text = "Статус", AutoSize = true }, 4, 0);
                    ResultsFindClientTable.Controls.Add(new Label() { Text = "Редактирай", AutoSize = true }, 5, 0);
                    ResultsFindClientTable.Controls.Add(new Label() { Text = "Изтрий", AutoSize = true }, 6, 0);

                    for (int i = 1; readerA.Read(); i++)
                    {
                        ResultsFindClientTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                        int idAccount = readerA.GetOrdinal("ID_ACCOUNT");
                        int number = readerA.GetOrdinal("NUMBER_ACCOUNT");
                        int interest = readerA.GetOrdinal("INTEREST");
                        int availability = readerA.GetOrdinal("AVAILABILITY");
                        int currency = readerA.GetOrdinal("CURRENCY");
                        int statats = readerA.GetOrdinal("STATUS");

                        Button editAccount = new Button();
                        editAccount.Text = "🖋";
                        editAccount.Tag = (int)readerA.GetDecimal(idAccount);
                        //editAccount.Click += EditAccountButton_Click;
                        editAccount.AutoSize = true;

                        Button deleteAccount = new Button();
                        deleteAccount.Text = " X ";
                        deleteAccount.Tag = (int)readerA.GetDecimal(idAccount);
                        deleteAccount.Click += DeleteAccountButton_Click;
                        deleteAccount.AutoSize = true;

                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetString(number), AutoSize = true }, 0, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetString(availability), AutoSize = true }, 1, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetString(currency), AutoSize = true }, 2, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetString(interest), AutoSize = true }, 3, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetString(statats), AutoSize = true }, 4, i);
                        ResultsFindClientTable.Controls.Add(editAccount, 5, i);
                        ResultsFindClientTable.Controls.Add(deleteAccount, 6, i);
                    }
                    ResultsFindClientTable.AutoScroll = true;
                    ResultsFindClientTable.Visible = true;
                }
                else;//error provider
            }
        }
        //edit account
        //edit client

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            int id_account = (int)((Button)sender).Tag;

            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да изтриете запис?", "Потвърждение за изтриване", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                OracleCommand cmd = con.CreateCommand();
                string sql = "DELETE FROM Account WHERE id_account = :id";
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_account;
                cmd.ExecuteNonQuery();

                result = MessageBox.Show("Успешно изтриа сметка!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    FindClientPanel.Controls.Clear();
                    FindClientPanel.Visible = false;
                }
            }
        }

        private void DeleteClienButton_Click(Object sender, EventArgs e)
        {
            int id_client = (int)((Button)sender).Tag;
            string sql = "SELECT * FROM Account WHERE id_client = :id_client";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_client;
            OracleDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) MessageBox.Show("Невалидна опция! Клиента, който искате да изтриете има активни сметки!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                sql = "DELETE FROM Account WHERE id_client = :client";
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_client;
                cmd.ExecuteNonQuery();

                DialogResult result = MessageBox.Show("Успешно изтрит клиент!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    FindClientPanel.Controls.Clear();
                    FindClientPanel.Visible = false;
                }
            }

        }
        private void ClientMainManu_Load(object sender, EventArgs e)
        {

        }

        private void groupBoxEmployeeDataAdd_Enter(object sender, EventArgs e)
        {

        }

        private void ExitProfileMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да излезете?", "Потвърждение за излизане", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                new SignInSystem().ShowDialog();
            }
        }

    }
       
}
