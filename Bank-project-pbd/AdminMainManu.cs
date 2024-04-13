﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Bank_project_pbd
{
    public partial class AdminMainManu : Form
    {
        private OracleConnection con;
        public AdminMainManu()
        {
            InitializeComponent();
            con = DatabaseManager.Instance.Connection;
            this.Controls.Add(AddNewEmployeePanel);
            this.Controls.Add(FindEmployeePanel);
            PasswordEmployeeAddTextBox.UseSystemPasswordChar = true;
            PasswordEmployeeAddTextBox.PasswordChar = '*';
            PositionEmployeeAddComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ResultsFindEmployeeTable.Visible = false;
        }

        private void AddEmployeeMenu_Click(object sender, EventArgs e)
        {
            TitleEmployeeInfoLabel.Text = "Добави нов служител";
            TitleEmployeeInfoButton.Text = "Добави служител";
            TypeProfileEmployeeAddComboBox.Enabled = false;
            TypeProfileEmployeeAddComboBox.SelectedIndex = 1;
            FindEmployeePanel.Visible = false;
            AddNewEmployeePanel.BringToFront();
            AddNewEmployeePanel.Visible = true;
            ResultsFindEmployeeTable.Controls.Clear();
        }

        private void TtitleEmployeeInfoButton_Click(object sender, EventArgs e)
        {
            if(TitleEmployeeInfoButton.Text.Equals("Добави служител"))
            {
                OracleCommand commandAddProfile = new OracleCommand("insert_system_profile", con);
                commandAddProfile.CommandType = CommandType.StoredProcedure;
                commandAddProfile.Parameters.Add("p_username", OracleDbType.Varchar2).Value = UsernameEmployeeAddTextBox.Text;
                commandAddProfile.Parameters.Add("p_password_profile", OracleDbType.Varchar2).Value = PasswordEmployeeAddTextBox.Text;
                commandAddProfile.Parameters.Add("p_id_role_type", OracleDbType.Int32).Value = 2;
                commandAddProfile.Parameters.Add("p_id_employee", OracleDbType.Int32).Value = null;
                commandAddProfile.Parameters.Add("p_id_client", OracleDbType.Int32).Value = null;
                commandAddProfile.ExecuteNonQuery();

                int newIdProfile = Convert.ToInt32(new OracleCommand("SELECT MAX(id_profile) FROM system_profile", con).ExecuteScalar());

                OracleCommand commandAddEmployee = new OracleCommand("EMPLOYEE_INS", con);
                commandAddEmployee.CommandType = CommandType.StoredProcedure;
                commandAddEmployee.Parameters.Add("v_pos_name_emp", OracleDbType.Varchar2).Value = NameEmployeeAddTextBox.Text;
                commandAddEmployee.Parameters.Add("v_pos_phone_emp", OracleDbType.Varchar2).Value = PhoneEmployeeAddTextBox.Text;
                commandAddEmployee.Parameters.Add("v_pos_position_emp", OracleDbType.Int32).Value = PositionEmployeeAddComboBox.SelectedIndex + 1;
                commandAddEmployee.Parameters.Add("v_pos_profile_emp", OracleDbType.Int32).Value = newIdProfile;
                commandAddEmployee.ExecuteNonQuery();

                int newIdEmployee = Convert.ToInt32(new OracleCommand("SELECT MAX(id_employee) FROM employee", con).ExecuteScalar());
                OracleCommand commandAddEmployeeToProfiles = con.CreateCommand();
                String sql = "UPDATE system_profile SET id_employee = :id_employee WHERE id_profile = :id_profile";
                commandAddEmployeeToProfiles.Parameters.Add("id_profile", OracleDbType.Int32).Value = newIdProfile;
                commandAddEmployeeToProfiles.Parameters.Add("id_employee", OracleDbType.Int32).Value = newIdEmployee;
                commandAddEmployeeToProfiles.CommandText = sql;
                commandAddEmployeeToProfiles.ExecuteNonQuery();

                DialogResult result = MessageBox.Show("Успешно добавен служител!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    AddNewEmployeePanel.Controls.Clear();
                    AddNewEmployeePanel.Visible = false;
                }
            }
            else if (TitleEmployeeInfoButton.Text.Equals("Редактирай служител")){
                ArrayList tags = (ArrayList)AddNewEmployeePanel.Tag;
                int id_employee = (int)tags[0];
                int id_profile = (int)tags[1];

                OracleCommand commandAddProfile = new OracleCommand("update_system_profile", con);
                commandAddProfile.CommandType = CommandType.StoredProcedure;
                commandAddProfile.Parameters.Add("p_id_profile", OracleDbType.Int32).Value = id_profile;
                commandAddProfile.Parameters.Add("p_username", OracleDbType.Varchar2).Value = UsernameEmployeeAddTextBox.Text;
                commandAddProfile.Parameters.Add("p_password_profile", OracleDbType.Varchar2).Value = PasswordEmployeeAddTextBox.Text;
                commandAddProfile.Parameters.Add("p_id_role_type", OracleDbType.Int32).Value = 1;
                commandAddProfile.Parameters.Add("p_id_employee", OracleDbType.Int32).Value = id_employee;
                commandAddProfile.Parameters.Add("p_id_client", OracleDbType.Int32).Value = null;
                commandAddProfile.ExecuteNonQuery();

                OracleCommand commandAddEmployee = new OracleCommand("EMPLOYEE_UPD", con);
                commandAddEmployee.CommandType = CommandType.StoredProcedure;
                commandAddEmployee.Parameters.Add("p_pos_id_employee", OracleDbType.Int32).Value = id_employee;
                commandAddEmployee.Parameters.Add("v_pos_name_emp", OracleDbType.Varchar2).Value = NameEmployeeAddTextBox.Text;
                commandAddEmployee.Parameters.Add("v_pos_phone_emp", OracleDbType.Varchar2).Value = PhoneEmployeeAddTextBox.Text;
                commandAddEmployee.Parameters.Add("v_pos_position_emp", OracleDbType.Int32).Value = PositionEmployeeAddComboBox.SelectedIndex + 1;
                commandAddEmployee.Parameters.Add("v_pos_profile_emp", OracleDbType.Int32).Value = id_profile;
                commandAddEmployee.ExecuteNonQuery();

                DialogResult result = MessageBox.Show("Успешно редактиран служител!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    AddNewEmployeePanel.Controls.Clear();
                    AddNewEmployeePanel.Visible = false;
                }
                AddNewEmployeePanel.Tag = null;
            }
            

        }

        private void CancelAddEmployeeButton_Click(object sender, EventArgs e)
        {
            AddNewEmployeePanel.Visible = false;
            AddNewEmployeePanel.Controls.Clear();

        }

        private void FindEmployeeMenu_Click(object sender, EventArgs e)
        {
            AddNewEmployeePanel.Visible=false;
            FindEmployeePanel.BringToFront();
            FindEmployeePanel.Visible = true;
            FindEmployeeByPositionButton.BackColor = System.Drawing.Color.White;
            FindEmployeeByNameButton.BackColor = System.Drawing.Color.White;
            FindEmployeeByPhoneButton.BackColor = System.Drawing.Color.White;
        }

        private void FindEmployeeByNameButton_Click(object sender, EventArgs e)
        {
            FindEmployeeByNameButton.BackColor = System.Drawing.Color.LightGray;
            FindEmployeeByPhoneButton.BackColor = System.Drawing.Color.White;
            FindEmployeeByPositionButton.BackColor = System.Drawing.Color.White;
            SearchImageFindEmployee.Visible = true;
            SearchEmployeeButton.Visible = true;
            SearchEmployeeTextBox.Visible = true;
            FindEmployeeByPositionComboBox.Visible = false;
            ResultsFindEmployeeTable.Visible = false;
            ResultsFindEmployeeTable.Controls.Clear();
            SearchEmployeeTextBox.Clear();
        }

        private void FindEmployeeByPhoneButton_Click(object sender, EventArgs e)
        {
            FindEmployeeByPhoneButton.BackColor = System.Drawing.Color.LightGray;
            FindEmployeeByNameButton.BackColor = System.Drawing.Color.White;
            FindEmployeeByPositionButton.BackColor = System.Drawing.Color.White;
            SearchImageFindEmployee.Visible = true;
            SearchEmployeeButton.Visible = true;
            SearchEmployeeTextBox.Visible = true;
            FindEmployeeByPositionComboBox.Visible = false;
            ResultsFindEmployeeTable.Visible = false;
            ResultsFindEmployeeTable.Controls.Clear();
            SearchEmployeeTextBox.Clear();
        }

        private void FindEmployeeByPositionButton_Click(object sender, EventArgs e)
        {
            FindEmployeeByPositionButton.BackColor = System.Drawing.Color.LightGray;
            FindEmployeeByNameButton.BackColor = System.Drawing.Color.White;
            FindEmployeeByPhoneButton.BackColor = System.Drawing.Color.White;
            SearchImageFindEmployee.Visible = true;
            SearchEmployeeButton.Visible = true;
            SearchEmployeeTextBox.Visible = false;
            FindEmployeeByPositionComboBox.Visible = true;
            FindEmployeeByPositionComboBox.SelectedIndex = -1;
            ResultsFindEmployeeTable.Visible = false;
            ResultsFindEmployeeTable.Controls.Clear();
        }

        private void SearchEmployeeButton_Click(object sender, EventArgs e)
        {
            ResultsFindEmployeeTable.Controls.Clear();
            string sql = null;
            OracleCommand cmd = con.CreateCommand();
            if (SearchEmployeeTextBox.Text != null || FindEmployeeByPositionComboBox != null)
            {
                if (FindEmployeeByNameButton.BackColor == System.Drawing.Color.LightGray)
                {
                    sql = "SELECT e.id_employee, e.name_employee, e.phone_employee, p.position_type FROM EMPLOYEE e JOIN POSITION p ON p.ID_POSITION = E.ID_POSITION WHERE e.NAME_EMPLOYEE=:name";
                    cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = SearchEmployeeTextBox.Text;
                }
                else if (FindEmployeeByPhoneButton.BackColor == System.Drawing.Color.LightGray)
                {
                    sql = "SELECT e.id_employee, e.name_employee, e.phone_employee, p.position_type FROM EMPLOYEE e JOIN POSITION p ON p.ID_POSITION = e.ID_POSITION WHERE e.PHONE_EMPLOYEE = :phone";
                    cmd.Parameters.Add(":phone", OracleDbType.Varchar2).Value = SearchEmployeeTextBox.Text;
                }
                else
                {
                    sql = "SELECT e.id_employee, e.name_employee, e.phone_employee, p.position_type FROM EMPLOYEE E JOIN POSITION P ON P.ID_POSITION = E.ID_POSITION WHERE p.position_type=:position";
                    cmd.Parameters.Add(":position", OracleDbType.Varchar2).Value = FindEmployeeByPositionComboBox.Text;
                }
                cmd.CommandText = sql;
                ShowResultsFinedEmployees(cmd);
            }
            //error provider
        }

        private void ShowResultsFinedEmployees(OracleCommand cmd)
        {
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
  
                ResultsFindEmployeeTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                ResultsFindEmployeeTable.ColumnStyles.Clear();
                ResultsFindEmployeeTable.RowStyles.Clear();

                ResultsFindEmployeeTable.Controls.Add(new Label() { Text = "Име и фамилия", AutoSize = true }, 0, 0);
                ResultsFindEmployeeTable.Controls.Add(new Label() { Text = "Телефонен номер", AutoSize = true }, 1, 0);
                ResultsFindEmployeeTable.Controls.Add(new Label() { Text = "Позиция", AutoSize = true }, 2, 0);
                ResultsFindEmployeeTable.Controls.Add(new Label() { Text = "Редактирай", AutoSize = true }, 3, 0);
                ResultsFindEmployeeTable.Controls.Add(new Label() { Text = "Изтрий", AutoSize = true }, 4, 0);

                for (int i = 1; reader.Read(); i++)
                {
                    ResultsFindEmployeeTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    int idEmployeeIndex = reader.GetOrdinal("ID_EMPLOYEE");
                    int nameEmployeeIndex = reader.GetOrdinal("NAME_EMPLOYEE");
                    int phoneEmployeeIndex = reader.GetOrdinal("PHONE_EMPLOYEE");
                    int positionEmployeeIndex = reader.GetOrdinal("POSITION_TYPE");
                    Button edit = new Button();
                    edit.Text = "🖋";
                    edit.Tag = (int)reader.GetDecimal(idEmployeeIndex);
                    edit.Click += EditEmployeeButton_Click;
                    edit.AutoSize = true;
                    Button delete = new Button();
                    delete.Text = " X ";
                    delete.Tag = (int)reader.GetDecimal(idEmployeeIndex);
                    delete.Click += DeleteDataButton_Click;
                    delete.AutoSize = true;
                    ResultsFindEmployeeTable.Controls.Add(new Label() { Text = reader.GetString(nameEmployeeIndex), AutoSize= true }, 0, i);
                    ResultsFindEmployeeTable.Controls.Add(new Label() { Text = reader.GetString(phoneEmployeeIndex), AutoSize = true }, 1, i);
                    ResultsFindEmployeeTable.Controls.Add(new Label() { Text = reader.GetString(positionEmployeeIndex), AutoSize = true }, 2, i);
                    ResultsFindEmployeeTable.Controls.Add(edit, 3, i);
                    ResultsFindEmployeeTable.Controls.Add(delete, 4, i);
                }
                ResultsFindEmployeeTable.AutoScroll = true;
                ResultsFindEmployeeTable.Visible = true;
            }
            else;//error provider
        }

        private void EditEmployeeButton_Click(object sender, EventArgs e)
        {
            FindEmployeePanel.Visible = false;
            TitleEmployeeInfoLabel.Text = "Редактирай служител";
            TitleEmployeeInfoButton.Text = "Редактирай служител";
            string sql = "SELECT * FROM EMPLOYEE E JOIN POSITION P ON P.ID_POSITION = E.ID_POSITION JOIN SYSTEM_PROFILE SP ON SP.ID_PROFILE = E.ID_PROFILE JOIN PROFILE_ROLE PR ON SP.ID_ROLE_TYPE = PR.ID_ROLE_TYPE WHERE E.ID_EMPLOYEE = :id";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = (int)((Button)sender).Tag;

            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                int nameEmployeeIndex = reader.GetOrdinal("NAME_EMPLOYEE");
                int phoneEmployeeIndex = reader.GetOrdinal("PHONE_EMPLOYEE");
                int positionEmployeeIndex = reader.GetOrdinal("POSITION_TYPE");
                int usernameEmployeeIndex = reader.GetOrdinal("USERNAME");
                int passwordEmployeeIndex = reader.GetOrdinal("PASSWORD_PROFILE");
                int idEmployee = reader.GetOrdinal("id_employee");
                int idProfile = reader.GetOrdinal("id_profile");
                
                NameEmployeeAddTextBox.Text = reader.GetString(nameEmployeeIndex);
                PhoneEmployeeAddTextBox.Text = reader.GetString(phoneEmployeeIndex);
                PositionEmployeeAddComboBox.SelectedIndex = positionEmployeeIndex;
                UsernameEmployeeAddTextBox.Text = reader.GetString(usernameEmployeeIndex);
                PasswordEmployeeAddTextBox.Text = reader.GetString(passwordEmployeeIndex);

                TypeProfileEmployeeAddComboBox.SelectedIndex = 1;
                TypeProfileEmployeeAddComboBox.Enabled = false;
                TitleEmployeeInfoButton.Text = "Редактирай служител";
                AddNewEmployeePanel.Visible = true;
                AddNewEmployeePanel.BringToFront();
                AddNewEmployeePanel.Tag = new ArrayList(){(int)reader.GetDecimal(idEmployee), (int)reader.GetDecimal(idProfile) };
     
            }
        }

        private void DeleteDataButton_Click(Object sender, EventArgs e)
        {
            int id_employee = (int)((Button)sender).Tag;
            int id_profile= 0;
            string sql = "SELECT id_profile FROM EMPLOYEE WHERE ID_EMPLOYEE = :id";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_employee;
            OracleDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) id_profile = (int)reader.GetDecimal(0);

            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да изтриете запис?", "Потвърждение за изтриване", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                sql = "UPDATE system_profile SET id_employee = null WHERE id_profile = :id_profile";
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("id", OracleDbType.Int32).Value = id_profile;
                cmd.ExecuteNonQuery();

                sql = "DELETE FROM EMPLOYEE WHERE ID_EMPLOYEE = :id";
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_employee;
                cmd.ExecuteNonQuery();

                sql = "DELETE FROM SYSTEM_PROFILE WHERE id_profile = :id";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(":id", OracleDbType.Decimal).Value = id_profile;
                cmd.ExecuteNonQuery();
                result = MessageBox.Show("Успешно изтрит служител!", "Потвърждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    FindEmployeePanel.Controls.Clear();
                    FindEmployeePanel.Visible = false;
                }
                FindEmployeePanel.Tag = null;
            }

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

        private void AdminMainManu_Load(object sender, EventArgs e)
        {

        }
    }   
}