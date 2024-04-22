using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Bank_project_pbd
{
    //add id_client in system_profile not working!  client_upd not working

    public partial class EmployeeMainManu : Form
    {
        private OracleConnection con;

        public EmployeeMainManu()
        {
            InitializeComponent();
            con = DatabaseManager.Instance.Connection;
            this.Controls.Add(AddNewClientPanel);
            this.Controls.Add(FindClientPanel);
            this.Controls.Add(AddNewAccountPanel);
            PasswordClientAddTextBox.UseSystemPasswordChar = true;
            PasswordClientAddTextBox.PasswordChar = '*';
            ResultsFindClientTable.Visible = false;
            CurrencyAccoutComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusAccountComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private bool HasEmptyFieldForEmployeeData()
        {

            foreach (Control control in Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                    return true;
            }
            return false;
        }

        private void ClearControls(Control collection)
        {
            foreach (Control control in collection.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = String.Empty;
                    errorProvider1.SetError(control, String.Empty);

                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                    errorProvider1.SetError(control, String.Empty);
                }
            }

        }

        private void ClearDataFromFinedClient()
        {
            FinedClientNameDataLabel.Text = String.Empty;
            FinedClientDataPhoneLabel.Text = String.Empty;
            FinedClientEGNDataLabel.Text = String.Empty;
            FinedClientAddressDataLabel.Text = String.Empty;
            FinedClientEmailDataLabel.Text= String.Empty;
        }

        private void ShowResultsFinedClients(OracleCommand cmd)
        {
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                EditClientButton.Visible = true;
                DeleteClienButton.Visible = true;
                AddNewAccountButton.Visible = true;

                int idClientIndex = reader.GetOrdinal("ID_CLIENT");
                int nameClientIndex = reader.GetOrdinal("NAME_CLIENT");
                int phoneClientIndex = reader.GetOrdinal("PHONE_CLIENT");
                int egnClientIndex = reader.GetOrdinal("EGN");
                int addressClientIndex = reader.GetOrdinal("ADDRESS");
                int emailClientIndex = reader.GetOrdinal("EMAIL");

                int idClient = (int)reader.GetDecimal(idClientIndex);

                EditClientButton.Tag = idClient;
                DeleteClienButton.Tag = idClient;
                AddNewAccountButton.Tag = idClient;
                
                FinedClientNameDataLabel.Text = reader.GetString(nameClientIndex);
                FinedClientDataPhoneLabel.Text = reader.GetString(phoneClientIndex);
                FinedClientEGNDataLabel.Text = reader.GetString(egnClientIndex);
                FinedClientAddressDataLabel.Text = reader.GetString(addressClientIndex);
                FinedClientEmailDataLabel.Text = reader.GetString(emailClientIndex);

                string sql = "SELECT * FROM account a JOIN currency c ON a.id_currency = c.id_currency JOIN status_account sa ON a.id_status_account=sa.id_status WHERE a.id_client = :id_client";
                OracleCommand cmdAccounts = con.CreateCommand();
                cmdAccounts.Parameters.Add(":id_client", OracleDbType.Decimal).Value = reader.GetDecimal(idClientIndex);
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
                        int availability = readerA.GetOrdinal("AVAILABILITY_AMOUNT");
                        int currency = readerA.GetOrdinal("CURRENCY");
                        int statats = readerA.GetOrdinal("STATUS");

                        Button editAccount = new Button();
                        editAccount.Text = "🖋";
                        editAccount.Tag = (int)readerA.GetDecimal(idAccount);
                        editAccount.Click += EditAccountButton_Click;
                        editAccount.AutoSize = true;

                        Button deleteAccount = new Button();
                        deleteAccount.Text = " X ";
                        deleteAccount.Tag = (int)readerA.GetDecimal(idAccount);
                        deleteAccount.Click += DeleteAccountButton_Click;
                        deleteAccount.AutoSize = true;

                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetDecimal(number).ToString(), AutoSize = true }, 0, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetDecimal(availability).ToString(), AutoSize = true }, 1, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetString(currency).ToString(), AutoSize = true }, 2, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetDecimal(interest).ToString(), AutoSize = true }, 3, i);
                        ResultsFindClientTable.Controls.Add(new Label() { Text = readerA.GetString(statats).ToString(), AutoSize = true }, 4, i);
                        ResultsFindClientTable.Controls.Add(editAccount, 5, i);
                        ResultsFindClientTable.Controls.Add(deleteAccount, 6, i);
                    }
                    ResultsFindClientTable.AutoScroll = true;
                    ResultsFindClientTable.Visible = true;
                }
            }
        }


        private void AddNewClientMenuItem_Click(object sender, EventArgs e)
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
            if (!HasEmptyFieldForEmployeeData())
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
                    commandAddClient.Parameters.Add("v_pos_address", OracleDbType.Varchar2).Value = AddressClientAddTextBox.Text;
                    commandAddClient.Parameters.Add("v_pos_email", OracleDbType.Varchar2).Value = EmailClientAddTextBox.Text;
                    commandAddClient.Parameters.Add("v_pos_profile", OracleDbType.Int32).Value = newIdProfile;
                    commandAddClient.ExecuteNonQuery();

                    int newIdClient = Convert.ToInt32(new OracleCommand("SELECT MAX(id_client) FROM client", con).ExecuteScalar());
                    OracleCommand commandAddClientToProfiles = new OracleCommand("UPDATE system_profile SET id_client = :id_client WHERE id_profile = :id_profile", con);
                    commandAddClientToProfiles.Parameters.Add("id_profile", OracleDbType.Int32).Value = newIdProfile;
                    commandAddClientToProfiles.Parameters.Add("id_client", OracleDbType.Int32).Value = newIdClient;
                    commandAddClientToProfiles.ExecuteNonQuery();//not working

                    DialogResult result = MessageBox.Show("Успешно добавен клиент!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        CancelAddClientButton_Click(null, null);
                        AddNewClientPanel.Visible = false;
                    }
                }
                else if (TitleClientInfoButton.Text.Equals("Редактирай клиент"))
                {
                    ArrayList tags = (ArrayList)AddNewClientPanel.Tag;
                    int id_client = (int)tags[0];
                    int id_profile = (int)tags[1];

                    OracleCommand commandAddProfile = new OracleCommand("update_system_profile", con);
                    commandAddProfile.CommandType = CommandType.StoredProcedure;
                    commandAddProfile.Parameters.Add("p_id_profile", OracleDbType.Int32).Value = id_profile;
                    commandAddProfile.Parameters.Add("p_username", OracleDbType.Varchar2).Value = UsernameClientAddTextBox.Text;
                    commandAddProfile.Parameters.Add("p_password_profile", OracleDbType.Varchar2).Value = PasswordClientAddTextBox.Text;
                    commandAddProfile.Parameters.Add("p_id_role_type", OracleDbType.Int32).Value = 3;
                    commandAddProfile.Parameters.Add("p_id_employee", OracleDbType.Int32).Value = null;
                    commandAddProfile.Parameters.Add("p_id_client", OracleDbType.Int32).Value = id_client;
                    commandAddProfile.ExecuteNonQuery();

                    OracleCommand commandEditClient = new OracleCommand("CLIENT_UPD", con);
                    commandEditClient.CommandType = CommandType.StoredProcedure;
                    commandEditClient.Parameters.Add("v_pos_id", OracleDbType.Int32).Value = id_client;
                    commandEditClient.Parameters.Add("v_pos_name", OracleDbType.Varchar2).Value = NameClientAddTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_egn", OracleDbType.Varchar2).Value = EGNClientAddTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_phone", OracleDbType.Varchar2).Value = PhoneClientAddTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_address", OracleDbType.Varchar2).Value = AddressClientAddTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_email", OracleDbType.Varchar2).Value = EmailClientAddTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_profile", OracleDbType.Int32).Value = id_profile;
                    commandEditClient.ExecuteNonQuery();//wrong numebr or types of arguments in call

                    DialogResult result = MessageBox.Show("Успешно редактиран клиент!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        CancelAddClientButton_Click(null, null);
                        AddNewClientPanel.Visible = false;
                    }
                    AddNewClientPanel.Tag = null;
                }
            }
        }

        private void CancelAddClientButton_Click(object sender, EventArgs e)
        {
            AddNewClientPanel.Visible = false;
            ClearControls(groupBoxClientDataAdd);
            ClearControls(ProfileDataClientAdd);
        }

        
        private void FindClientMenuItem_Click(object sender, EventArgs e)
        {
            AddNewClientPanel.Visible = false;
            FindClientPanel.Visible = true;
            FindClientPanel.BringToFront();
            FindClientByNameButton.BackColor = System.Drawing.Color.White;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.White;
            FindClientByEGNButton.BackColor = System.Drawing.Color.White;
            SearchClientTextBox.Text =String.Empty;
            ClearDataFromFinedClient();
            ResultsFindClientTable.Controls.Clear();

        }

        private void FindClientByNameButton_Click(object sender, EventArgs e)
        {
            FindClientByNameButton.BackColor = System.Drawing.Color.LightGray;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.White;
            FindClientByEGNButton.BackColor = System.Drawing.Color.White;
            SearchClientButton.Enabled = true;
            ResultsFindClientTable.Visible = false;
            ResultsFindClientTable.Controls.Clear();
            SearchClientTextBox.Text = String.Empty;
            ClearDataFromFinedClient();
        }

        private void FindClientByPhoneButton_Click(object sender, EventArgs e)
        {
            FindClientByNameButton.BackColor = System.Drawing.Color.White;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.LightGray;
            FindClientByEGNButton.BackColor = System.Drawing.Color.White;
            SearchClientButton.Enabled = true;
            ResultsFindClientTable.Visible = false;
            ResultsFindClientTable.Controls.Clear();
            SearchClientTextBox.Text = String.Empty;
            ClearDataFromFinedClient();
        }

        private void FindClientByEGNButton_Click(object sender, EventArgs e)
        {
            FindClientByNameButton.BackColor = System.Drawing.Color.White;
            FindClientByPhoneButton.BackColor = System.Drawing.Color.White;
            FindClientByEGNButton.BackColor = System.Drawing.Color.LightGray;
            SearchClientButton.Enabled = true;
            ResultsFindClientTable.Visible = false;
            ResultsFindClientTable.Controls.Clear();
            SearchClientTextBox.Text = String.Empty;
            ClearDataFromFinedClient();
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
        }


        private void EditClientButton_Click(object sender, EventArgs e)
        {
            FindClientPanel.Visible = false;
            string sql = "SELECT * FROM client c JOIN SYSTEM_PROFILE SP ON SP.id_client = c.id_client WHERE c.id_client = :id";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = (int)((Button)sender).Tag;

            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int nameClientIndex = reader.GetOrdinal("NAME_CLIENT");
                int phoneClientIndex = reader.GetOrdinal("PHONE_CLIENT");
                int egnClientIndex = reader.GetOrdinal("EGN");
                int addressClientIndex = reader.GetOrdinal("ADDRESS");
                int emailClientIndex = reader.GetOrdinal("EMAIL");
                int usernameClientIndex = reader.GetOrdinal("USERNAME");
                int passwordClientIndex = reader.GetOrdinal("PASSWORD_PROFILE");
                int idClient = reader.GetOrdinal("ID_CLIENT");
                int idProfile = reader.GetOrdinal("id_profile");

                NameClientAddTextBox.Text = reader.GetString(nameClientIndex);
                PhoneClientAddTextBox.Text = reader.GetString(phoneClientIndex);
                EGNClientAddTextBox.Text = reader.GetString(egnClientIndex);
                AddressClientAddTextBox.Text = reader.GetString(addressClientIndex);
                EmailClientAddTextBox.Text=  reader.GetString(emailClientIndex);
                UsernameClientAddTextBox.Text = reader.GetString(usernameClientIndex);
                PasswordClientAddTextBox.Text = reader.GetString(passwordClientIndex);

                TitleClientInfoLabel.Text = "Редактирай клиент";
                TitleClientInfoButton.Text = "Редактирай клиент";
                TypeProfileClientAddComboBox.SelectedIndex = 2;
                TypeProfileClientAddComboBox.Enabled = false;
                AddNewClientPanel.Visible = true;
                AddNewClientPanel.BringToFront();
                AddNewClientPanel.Tag = new ArrayList() { (int)reader.GetDecimal(idClient), (int)reader.GetDecimal(idProfile) };
            }
        }

        private void DeleteClienButton_Click(Object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да изтриете клиента?", "Потвърждение за изтриване", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id_client = (int)((Button)sender).Tag;
                int id_profile = 0;
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT id_profile FROM EMPLOYEE WHERE ID_EMPLOYEE = :id";
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_client;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) id_profile = (int)reader.GetDecimal(0);

                string sql = "SELECT * FROM Account WHERE id_client = :id_client";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_client;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    MessageBox.Show("Невалидна опция! Клиента, който искате да изтриете има активни сметки!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sql = "UPDATE system_profile SET id_employee = null WHERE id_profile = :id_profile";
                    cmd = con.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", OracleDbType.Int32).Value = id_profile;
                    cmd.ExecuteNonQuery();

                    sql = "DELETE FROM client WHERE id_client = :id";
                    cmd = con.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_client;
                    cmd.ExecuteNonQuery();

                    sql = "DELETE FROM SYSTEM_PROFILE WHERE id_profile = :id";
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_profile;
                    cmd.ExecuteNonQuery();

                    DialogResult resultOK = MessageBox.Show("Успешно изтрит клиент!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (resultOK == DialogResult.OK)
                    {
                        ClearDataFromFinedClient();
                        ResultsFindClientTable.Controls.Clear();
                        FindClientPanel.Visible = false;
                    }
                }
            }

        }


        private void AddNewAccountButton_Click(object sender, EventArgs e)
        {
            FindClientPanel.Visible = false;
            TitleAccountlabel.Text = "Добави сметка";
            TitleClientInfoButton.Text = "Добави сметка";
            AddNewAccountPanel.BringToFront();
            AddNewAccountPanel.Visible = true;
        }

        private void AddOrEditAccountButton_Click(object sender, EventArgs e)
        {
            if (!HasEmptyFieldForEmployeeData())
            {
                if (TitleAccountlabel.Text.Equals("Добави сметка"))
                {
                    int idClient = (int)AddNewAccountButton.Tag;
                    OracleCommand commandAddClient = new OracleCommand("ACCOUNT_INS", con);
                    commandAddClient.CommandType = CommandType.StoredProcedure;
                    commandAddClient.Parameters.Add("v_pos_number", OracleDbType.Varchar2).Value = NumberAccountTextBox.Text;
                    commandAddClient.Parameters.Add("v_pos_client", OracleDbType.Varchar2).Value = idClient;
                    commandAddClient.Parameters.Add("v_pos_interest", OracleDbType.Decimal).Value = InterestAccountTextBox.Text;
                    commandAddClient.Parameters.Add("v_pos_amount", OracleDbType.Decimal).Value = AmountAccountTextBox.Text;
                    commandAddClient.Parameters.Add("v_pos_currency", OracleDbType.Int32).Value = CurrencyAccoutComboBox.SelectedIndex + 1;
                    commandAddClient.Parameters.Add("v_pos_status", OracleDbType.Int32).Value = StatusAccountComboBox.SelectedIndex + 1;
                    commandAddClient.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show("Успешно добавена сметка!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        CancelAccountButton_Click(null, null);
                        AddNewClientPanel.Visible = false;
                    }
                }
                else if (TitleClientInfoButton.Text.Equals("Редактирай сметка"))
                {

                    ArrayList tags = (ArrayList)EditClientButton.Tag;
                    int idAccount = (int)tags[0];
                    int idClient = (int)tags[1];
                    OracleCommand commandEditClient = new OracleCommand("ACCOUNT_UPD", con);
                    commandEditClient.CommandType = CommandType.StoredProcedure;
                    commandEditClient.Parameters.Add("v_pos_id", OracleDbType.Int32).Value = idAccount;
                    commandEditClient.Parameters.Add("v_pos_number", OracleDbType.Varchar2).Value = NumberAccountTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_client", OracleDbType.Varchar2).Value = idClient;
                    commandEditClient.Parameters.Add("v_pos_interest", OracleDbType.Decimal).Value = InterestAccountTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_amount", OracleDbType.Decimal).Value = AmountAccountTextBox.Text;
                    commandEditClient.Parameters.Add("v_pos_currency", OracleDbType.Int32).Value = CurrencyAccoutComboBox.SelectedIndex + 1;
                    commandEditClient.Parameters.Add("v_pos_status", OracleDbType.Int32).Value = StatusAccountComboBox.SelectedIndex + 1;
                    commandEditClient.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show("Успешно редактирана сметка!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        CancelAccountButton_Click(null, null);
                        AddNewClientPanel.Visible = false;
                    }
                    AddNewClientPanel.Tag = null;
                }
            }
        }

        private void CancelAccountButton_Click(object sender, EventArgs e)
        {
            AddNewAccountPanel.Visible = false;
            ClearControls(AddNewAccountPanel);
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            FindClientPanel.Visible = false;
            int idAccout = (int)((Button)sender).Tag;
            string sql = "SELECT * FROM account WHERE id_account = :id";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = idAccout;

            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            { 
                int numberAccountIndex = reader.GetOrdinal("NUMBER_ACCOUNT");
                int idClientIndex = reader.GetOrdinal("ID_CLIENT");
                int interestIndex = reader.GetOrdinal("INTEREST");
                int amountIndex = reader.GetOrdinal("AVAILABILITY_AMOUNT");
                int currencyIndex = reader.GetOrdinal("ID_CURRENCY");
                int statusIndex = reader.GetOrdinal("ID_STATUS_ACCOUNT");

                NumberAccountTextBox.Text = reader.GetDecimal(numberAccountIndex).ToString();
                InterestAccountTextBox.Text = reader.GetDecimal(interestIndex).ToString();
                AmountAccountTextBox.Text = reader.GetDecimal(amountIndex).ToString();
                CurrencyAccoutComboBox.SelectedIndex =(int) reader.GetDecimal(currencyIndex)-1;
                StatusAccountComboBox.SelectedIndex =(int) reader.GetDecimal(statusIndex)-1;

                TitleAccountlabel.Text = "Редактирай акаунт";
                TitleClientInfoButton.Text = "Редактирай акаунт";
                AddNewAccountPanel.Visible = true;
                AddNewAccountPanel.BringToFront();
                AddNewAccountPanel.Tag = new ArrayList() { idAccout, (int)reader.GetDecimal(idClientIndex) };
            }
        }

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            int id_account = (int)((Button)sender).Tag;

            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да изтриете сметка?", "Потвърждение за изтриване", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                OracleCommand cmd = con.CreateCommand();
                string sql = "UPDATE transaction SET id_account = NULL WHERE id_account = :id";
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_account;
                cmd.ExecuteNonQuery();

                sql = "UPDATE transaction SET id_account_send = NULL WHERE id_account_send = :id";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_account;
                cmd.ExecuteNonQuery();

                sql = "DELETE FROM Account WHERE id_account = :id";
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_account;
                cmd.ExecuteNonQuery();

                result = MessageBox.Show("Успешно изтриа сметка!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    cmd.CommandText = "SELECT * FROM CLIENT WHERE id_client =:id";
                    ShowResultsFinedClients(cmd);
                }
            }
        }


        private void ExitProfileMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да излезете?", "Потвърждение за излизане", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SignInSystem signInSystem = new SignInSystem();
                this.Hide();
                signInSystem.ShowDialog();
                this.Close();
            }
        }


        private void NameClientAddTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool findNumber = false;
            foreach (char letter in NameClientAddTextBox.Text)
            {
                if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                {
                    errorProvider1.SetError(NameClientAddTextBox, "Невалидни данни!");
                    findNumber = true;
                }
            }
            if (!findNumber)
                errorProvider1.SetError(NameClientAddTextBox, String.Empty);
        }

        private void EGNClientAddTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool findLetter = false;
            foreach (int number in EGNClientAddTextBox.Text)
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    errorProvider1.SetError(EGNClientAddTextBox, "ЕГН трябва да съдържа само числа!");
                    findLetter = true;
                }
            }
            if (!findLetter)
                errorProvider1.SetError(EGNClientAddTextBox, String.Empty);
        }

        private void PhoneClientAddTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool findLetter = false;
            foreach (int number in PhoneClientAddTextBox.Text)
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    errorProvider1.SetError(PhoneClientAddTextBox, "Телефонният номер трябва да съдържа само числа!");
                    findLetter = true;
                }
            }
            if (!findLetter)
                errorProvider1.SetError(PhoneClientAddTextBox, String.Empty);
        }

        private void SearchClientTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(FindClientByNameButton.BackColor == System.Drawing.Color.LightGray)
            {
                bool findNumber = false;
                foreach (char letter in SearchClientTextBox.Text)
                {
                    if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                    {
                        errorProvider1.SetError(SearchClientTextBox, "Невалидни данни!");
                        findNumber = true;
                    }
                }
                if (!findNumber)
                    errorProvider1.SetError(SearchClientTextBox, String.Empty);
            }
            else
            {
                bool findLetter = false;
                foreach (int number in SearchClientTextBox.Text)
                {
                    if (!char.IsDigit(e.KeyChar))
                    {
                        errorProvider1.SetError(SearchClientTextBox, "Невалидни данни!");
                        findLetter = true;
                    }
                }
                if (!findLetter)
                    errorProvider1.SetError(PhoneClientAddTextBox, String.Empty);
            }
        }


        private void PhoneClientAddTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PhoneClientAddTextBox.Text.Length != 10)
            {
                errorProvider1.SetError(PhoneClientAddTextBox, "Телефонният номер трябва да е с дължина 10 цифри!");
            }
            else
            {
                OracleCommand cmd = con.CreateCommand();
                String sql = "SELECT COUNT(*) FROM client WHERE phone_client = :client";
                cmd.Parameters.Add("client", OracleDbType.Varchar2).Value = PhoneClientAddTextBox.Text;
                cmd.CommandText = sql;
                if ((TitleClientInfoLabel.Text == "Редактирай клиент" && Convert.ToInt32(cmd.ExecuteScalar()) > 1) || (TitleClientInfoLabel.Text == "Добави клиент" && Convert.ToInt32(cmd.ExecuteScalar()) == 1))
                {
                    errorProvider1.SetError(PhoneClientAddTextBox, "Вече има регистринан клиент с този телефонен номер!");
                }
                else errorProvider1.SetError(PhoneClientAddTextBox, String.Empty);
            }
        }

        private void EGNClientAddTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EGNClientAddTextBox.Text.Length != 10)
            {
                errorProvider1.SetError(EGNClientAddTextBox, "ЕГН трябва да е с дължина 10 цифри!");
            }
            else
            {
                OracleCommand cmd = con.CreateCommand();
                String sql = "SELECT COUNT(*) FROM client WHERE egn = :egn";
                cmd.Parameters.Add("egn", OracleDbType.Varchar2).Value = PhoneClientAddTextBox.Text;
                cmd.CommandText = sql;
                if ((TitleClientInfoLabel.Text == "Редактирай клиент" && Convert.ToInt32(cmd.ExecuteScalar()) > 1) || (TitleClientInfoLabel.Text == "Добави клиент" && Convert.ToInt32(cmd.ExecuteScalar()) == 1))
                {
                    errorProvider1.SetError(PhoneClientAddTextBox, "Вече има регистринан клиент с това ЕГН!");
                }
                else errorProvider1.SetError(PhoneClientAddTextBox, String.Empty);
            }
        }

        private void SearchClientTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((FindClientByPhoneButton.BackColor == System.Drawing.Color.LightGray || FindClientByEGNButton.BackColor == System.Drawing.Color.LightGray) && SearchClientTextBox.Text.Length != 10)
            {
                errorProvider1.SetError(SearchClientTextBox, "Телефонният номер/ЕГН трябва да е с дължина 10 цифри!");
            }
            else errorProvider1.SetError(SearchClientTextBox, String.Empty);

        }

        private void NumberAccountTextBox_TextChanged(object sender, EventArgs e)
        {
            if ( NumberAccountTextBox.Text.Length < 8 || NumberAccountTextBox.Text.Length > 12)
            {
                errorProvider1.SetError(NumberAccountTextBox, "Номерат на банковата сметка трябва да е с дължина от 8 до 12 символа!");
            }
            else errorProvider1.SetError(NumberAccountTextBox, String.Empty);
        }


        private void NameClientAddTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameClientAddTextBox.Text))
            {
                errorProvider1.SetError(NameClientAddTextBox, "Въведете име и фамилия!");
            }
            errorProvider1.SetError(NameClientAddTextBox, String.Empty);
        }

        private void EGNClientAddTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EGNClientAddTextBox.Text))
            {
                errorProvider1.SetError(EGNClientAddTextBox, "Въведете ЕГН!");
            }
            else errorProvider1.SetError(NameClientAddTextBox, String.Empty);
        }

        private void PhoneClientAddTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhoneClientAddTextBox.Text))
            {
                errorProvider1.SetError(PhoneClientAddTextBox, "Въведете телефонен номер!");
            }
            else errorProvider1.SetError(NameClientAddTextBox, String.Empty);

        }

        private void AddressClientAddTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddressClientAddTextBox.Text))
            {
                errorProvider1.SetError(AddressClientAddTextBox, "Въведете адрес!");
            }
            else errorProvider1.SetError(NameClientAddTextBox, String.Empty);

        }

        private void EmailClientAddTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailClientAddTextBox.Text))
            {
                errorProvider1.SetError(EmailClientAddTextBox, "Въведете имейл!");
            }
            else errorProvider1.SetError(EmailClientAddTextBox, String.Empty);

        }

        private void UsernameClientAddTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameClientAddTextBox.Text))
            {
                errorProvider1.SetError(UsernameClientAddTextBox, "Въведете потребителско име!");
            }
            else errorProvider1.SetError(UsernameClientAddTextBox, String.Empty);

        }

        private void PasswordClientAddTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordClientAddTextBox.Text))
            {
                errorProvider1.SetError(PasswordClientAddTextBox, "Въведете парола!");
            }
            else errorProvider1.SetError(PasswordClientAddTextBox,String.Empty);
        }

        private void SearchClientTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchClientButton.Text))
            {
                errorProvider1.SetError(SearchClientButton, "Въведете данни за търсене!");
            }
            else 
                errorProvider1.SetError(SearchClientButton, String.Empty);

        }

        private void NumberAccountTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NumberAccountTextBox.Text))
            {
                errorProvider1.SetError(NumberAccountTextBox, "Въведете данни номер на сметка!");
            }
            else
                errorProvider1.SetError(NumberAccountTextBox, String.Empty);
        }

        private void InterestAccountTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InterestAccountTextBox.Text))
            {
                errorProvider1.SetError(InterestAccountTextBox, "Въведете данни за лихва!");
            }
            else
                errorProvider1.SetError(InterestAccountTextBox, String.Empty);
        }

        private void AmountAccountTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AmountAccountTextBox.Text))
            {
                errorProvider1.SetError(AmountAccountTextBox, "Въведете данни за наличност!");
            }
            else
                errorProvider1.SetError(AmountAccountTextBox, String.Empty);
        }

        private void CurrencyAccoutComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CurrencyAccoutComboBox.SelectedIndex == -1)
            {
                errorProvider1.SetError(CurrencyAccoutComboBox, "Изберете валута!");
            }
            else
                errorProvider1.SetError(CurrencyAccoutComboBox, String.Empty);
        }

        private void StatusAccountComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (StatusAccountComboBox.SelectedIndex == -1)
            {
                errorProvider1.SetError(StatusAccountComboBox, "Изберете статус!");
            }
            else
                errorProvider1.SetError(StatusAccountComboBox, String.Empty);
        }

        private void InterestAccountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(InterestAccountTextBox.Text) < 0 || Int32.Parse(InterestAccountTextBox.Text) > 20)
            {
                errorProvider1.SetError(InterestAccountTextBox, "Лихвата може да бъде между 0-20%!");
            }
            else errorProvider1.SetError(SearchClientTextBox, String.Empty);
        }
    }//add amount textChange and keypress for interest and amount
}
