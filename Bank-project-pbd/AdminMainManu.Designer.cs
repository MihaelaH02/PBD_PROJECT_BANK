namespace Bank_project_pbd
{
    partial class AdminMainManu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainManu));
            this.menuStripAdmin = new System.Windows.Forms.MenuStrip();
            this.AddEmployeeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindEmployeeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitProfileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.AddNewEmployeePanel = new System.Windows.Forms.Panel();
            this.CancelAddEmployeeButton = new System.Windows.Forms.Button();
            this.TitleEmployeeInfoButton = new System.Windows.Forms.Button();
            this.ProfileDataEmployeeAdd = new System.Windows.Forms.GroupBox();
            this.TypeProfileEmployeeLabel = new System.Windows.Forms.Label();
            this.TypeProfileEmployeeAddComboBox = new System.Windows.Forms.ComboBox();
            this.PasswordEmployeeLabel = new System.Windows.Forms.Label();
            this.UsernameEmployeeLabel = new System.Windows.Forms.Label();
            this.PasswordEmployeeAddTextBox = new System.Windows.Forms.TextBox();
            this.UsernameEmployeeAddTextBox = new System.Windows.Forms.TextBox();
            this.groupBoxEmployeeDataAdd = new System.Windows.Forms.GroupBox();
            this.PositionEmployeeLabel = new System.Windows.Forms.Label();
            this.PhoneEmployeeLabel = new System.Windows.Forms.Label();
            this.NameEmployeeLabel = new System.Windows.Forms.Label();
            this.PositionEmployeeAddComboBox = new System.Windows.Forms.ComboBox();
            this.PhoneEmployeeAddTextBox = new System.Windows.Forms.TextBox();
            this.NameEmployeeAddTextBox = new System.Windows.Forms.TextBox();
            this.TitlePanelAddEmployee = new System.Windows.Forms.Label();
            this.TitleEmployeeInfoLabel = new System.Windows.Forms.Label();
            this.FindEmployeePanel = new System.Windows.Forms.Panel();
            this.FindEmployeeByPositionComboBox = new System.Windows.Forms.ComboBox();
            this.ResultsFindEmployeeTable = new System.Windows.Forms.TableLayoutPanel();
            this.SearchImageFindEmployee = new System.Windows.Forms.PictureBox();
            this.SearchEmployeeTextBox = new System.Windows.Forms.TextBox();
            this.FindEmployeeByPositionButton = new System.Windows.Forms.Button();
            this.FindEmployeeByPhoneButton = new System.Windows.Forms.Button();
            this.FindEmployeeByNameButton = new System.Windows.Forms.Button();
            this.SearchEmployeeButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStripAdmin.SuspendLayout();
            this.AddNewEmployeePanel.SuspendLayout();
            this.ProfileDataEmployeeAdd.SuspendLayout();
            this.groupBoxEmployeeDataAdd.SuspendLayout();
            this.FindEmployeePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchImageFindEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.Font = new System.Drawing.Font("Calibri", 10F);
            this.menuStripAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEmployeeMenuItem,
            this.FindEmployeeMenuItem,
            this.ExitProfileMenuItem});
            this.menuStripAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Size = new System.Drawing.Size(837, 30);
            this.menuStripAdmin.TabIndex = 1;
            this.menuStripAdmin.Text = "menuStrip1";
            // 
            // AddEmployeeMenuItem
            // 
            this.AddEmployeeMenuItem.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEmployeeMenuItem.Name = "AddEmployeeMenuItem";
            this.AddEmployeeMenuItem.Size = new System.Drawing.Size(193, 26);
            this.AddEmployeeMenuItem.Text = "Добави нов служител";
            this.AddEmployeeMenuItem.Click += new System.EventHandler(this.AddEmployeeMenu_Click);
            // 
            // FindEmployeeMenuItem
            // 
            this.FindEmployeeMenuItem.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindEmployeeMenuItem.Name = "FindEmployeeMenuItem";
            this.FindEmployeeMenuItem.Size = new System.Drawing.Size(145, 26);
            this.FindEmployeeMenuItem.Text = "Търси служител";
            this.FindEmployeeMenuItem.Click += new System.EventHandler(this.FindEmployeeMenu_Click);
            // 
            // ExitProfileMenuItem
            // 
            this.ExitProfileMenuItem.Name = "ExitProfileMenuItem";
            this.ExitProfileMenuItem.Size = new System.Drawing.Size(67, 26);
            this.ExitProfileMenuItem.Text = "Изход";
            this.ExitProfileMenuItem.Click += new System.EventHandler(this.ExitProfileMenuItem_Click);
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Font = new System.Drawing.Font("Calibri", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelloLabel.Location = new System.Drawing.Point(190, 89);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(371, 35);
            this.HelloLabel.TabIndex = 2;
            this.HelloLabel.Text = "Добър ден, администратор";
            // 
            // AddNewEmployeePanel
            // 
            this.AddNewEmployeePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddNewEmployeePanel.Controls.Add(this.CancelAddEmployeeButton);
            this.AddNewEmployeePanel.Controls.Add(this.TitleEmployeeInfoButton);
            this.AddNewEmployeePanel.Controls.Add(this.ProfileDataEmployeeAdd);
            this.AddNewEmployeePanel.Controls.Add(this.groupBoxEmployeeDataAdd);
            this.AddNewEmployeePanel.Controls.Add(this.TitlePanelAddEmployee);
            this.AddNewEmployeePanel.Controls.Add(this.TitleEmployeeInfoLabel);
            this.AddNewEmployeePanel.Location = new System.Drawing.Point(26, 45);
            this.AddNewEmployeePanel.Name = "AddNewEmployeePanel";
            this.AddNewEmployeePanel.Size = new System.Drawing.Size(776, 419);
            this.AddNewEmployeePanel.TabIndex = 4;
            this.AddNewEmployeePanel.Visible = false;
            // 
            // CancelAddEmployeeButton
            // 
            this.CancelAddEmployeeButton.Location = new System.Drawing.Point(410, 366);
            this.CancelAddEmployeeButton.Name = "CancelAddEmployeeButton";
            this.CancelAddEmployeeButton.Size = new System.Drawing.Size(178, 36);
            this.CancelAddEmployeeButton.TabIndex = 5;
            this.CancelAddEmployeeButton.Text = "Отказ";
            this.CancelAddEmployeeButton.UseVisualStyleBackColor = true;
            this.CancelAddEmployeeButton.Click += new System.EventHandler(this.CancelAddEmployeeButton_Click);
            // 
            // TitleEmployeeInfoButton
            // 
            this.TitleEmployeeInfoButton.Location = new System.Drawing.Point(216, 366);
            this.TitleEmployeeInfoButton.Name = "TitleEmployeeInfoButton";
            this.TitleEmployeeInfoButton.Size = new System.Drawing.Size(178, 36);
            this.TitleEmployeeInfoButton.TabIndex = 4;
            this.TitleEmployeeInfoButton.Text = "Добави акаунт";
            this.TitleEmployeeInfoButton.UseVisualStyleBackColor = true;
            this.TitleEmployeeInfoButton.Click += new System.EventHandler(this.TtitleEmployeeInfoButton_Click);
            // 
            // ProfileDataEmployeeAdd
            // 
            this.ProfileDataEmployeeAdd.Controls.Add(this.TypeProfileEmployeeLabel);
            this.ProfileDataEmployeeAdd.Controls.Add(this.TypeProfileEmployeeAddComboBox);
            this.ProfileDataEmployeeAdd.Controls.Add(this.PasswordEmployeeLabel);
            this.ProfileDataEmployeeAdd.Controls.Add(this.UsernameEmployeeLabel);
            this.ProfileDataEmployeeAdd.Controls.Add(this.PasswordEmployeeAddTextBox);
            this.ProfileDataEmployeeAdd.Controls.Add(this.UsernameEmployeeAddTextBox);
            this.ProfileDataEmployeeAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileDataEmployeeAdd.Location = new System.Drawing.Point(410, 79);
            this.ProfileDataEmployeeAdd.Name = "ProfileDataEmployeeAdd";
            this.ProfileDataEmployeeAdd.Size = new System.Drawing.Size(334, 270);
            this.ProfileDataEmployeeAdd.TabIndex = 3;
            this.ProfileDataEmployeeAdd.TabStop = false;
            this.ProfileDataEmployeeAdd.Text = "Данни за профил на служител";
            // 
            // TypeProfileEmployeeLabel
            // 
            this.TypeProfileEmployeeLabel.AutoSize = true;
            this.TypeProfileEmployeeLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeProfileEmployeeLabel.Location = new System.Drawing.Point(23, 186);
            this.TypeProfileEmployeeLabel.Name = "TypeProfileEmployeeLabel";
            this.TypeProfileEmployeeLabel.Size = new System.Drawing.Size(92, 21);
            this.TypeProfileEmployeeLabel.TabIndex = 9;
            this.TypeProfileEmployeeLabel.Text = "Тип акаунт:";
            // 
            // TypeProfileEmployeeAddComboBox
            // 
            this.TypeProfileEmployeeAddComboBox.FormattingEnabled = true;
            this.TypeProfileEmployeeAddComboBox.Items.AddRange(new object[] {
            "admin",
            "employee",
            "client"});
            this.TypeProfileEmployeeAddComboBox.Location = new System.Drawing.Point(27, 210);
            this.TypeProfileEmployeeAddComboBox.Name = "TypeProfileEmployeeAddComboBox";
            this.TypeProfileEmployeeAddComboBox.Size = new System.Drawing.Size(269, 32);
            this.TypeProfileEmployeeAddComboBox.TabIndex = 9;
            // 
            // PasswordEmployeeLabel
            // 
            this.PasswordEmployeeLabel.AutoSize = true;
            this.PasswordEmployeeLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordEmployeeLabel.Location = new System.Drawing.Point(23, 121);
            this.PasswordEmployeeLabel.Name = "PasswordEmployeeLabel";
            this.PasswordEmployeeLabel.Size = new System.Drawing.Size(69, 21);
            this.PasswordEmployeeLabel.TabIndex = 10;
            this.PasswordEmployeeLabel.Text = "Парола:";
            // 
            // UsernameEmployeeLabel
            // 
            this.UsernameEmployeeLabel.AutoSize = true;
            this.UsernameEmployeeLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameEmployeeLabel.Location = new System.Drawing.Point(23, 50);
            this.UsernameEmployeeLabel.Name = "UsernameEmployeeLabel";
            this.UsernameEmployeeLabel.Size = new System.Drawing.Size(158, 21);
            this.UsernameEmployeeLabel.TabIndex = 9;
            this.UsernameEmployeeLabel.Text = "Потребителско име:";
            // 
            // PasswordEmployeeAddTextBox
            // 
            this.PasswordEmployeeAddTextBox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordEmployeeAddTextBox.Location = new System.Drawing.Point(27, 145);
            this.PasswordEmployeeAddTextBox.Name = "PasswordEmployeeAddTextBox";
            this.PasswordEmployeeAddTextBox.Size = new System.Drawing.Size(269, 29);
            this.PasswordEmployeeAddTextBox.TabIndex = 4;
            // 
            // UsernameEmployeeAddTextBox
            // 
            this.UsernameEmployeeAddTextBox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameEmployeeAddTextBox.Location = new System.Drawing.Point(27, 74);
            this.UsernameEmployeeAddTextBox.Name = "UsernameEmployeeAddTextBox";
            this.UsernameEmployeeAddTextBox.Size = new System.Drawing.Size(269, 29);
            this.UsernameEmployeeAddTextBox.TabIndex = 3;
            // 
            // groupBoxEmployeeDataAdd
            // 
            this.groupBoxEmployeeDataAdd.Controls.Add(this.PositionEmployeeLabel);
            this.groupBoxEmployeeDataAdd.Controls.Add(this.PhoneEmployeeLabel);
            this.groupBoxEmployeeDataAdd.Controls.Add(this.NameEmployeeLabel);
            this.groupBoxEmployeeDataAdd.Controls.Add(this.PositionEmployeeAddComboBox);
            this.groupBoxEmployeeDataAdd.Controls.Add(this.PhoneEmployeeAddTextBox);
            this.groupBoxEmployeeDataAdd.Controls.Add(this.NameEmployeeAddTextBox);
            this.groupBoxEmployeeDataAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxEmployeeDataAdd.Location = new System.Drawing.Point(24, 79);
            this.groupBoxEmployeeDataAdd.Name = "groupBoxEmployeeDataAdd";
            this.groupBoxEmployeeDataAdd.Size = new System.Drawing.Size(370, 270);
            this.groupBoxEmployeeDataAdd.TabIndex = 2;
            this.groupBoxEmployeeDataAdd.TabStop = false;
            this.groupBoxEmployeeDataAdd.Text = "Лични данни на служител";
            // 
            // PositionEmployeeLabel
            // 
            this.PositionEmployeeLabel.AutoSize = true;
            this.PositionEmployeeLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PositionEmployeeLabel.Location = new System.Drawing.Point(20, 186);
            this.PositionEmployeeLabel.Name = "PositionEmployeeLabel";
            this.PositionEmployeeLabel.Size = new System.Drawing.Size(77, 21);
            this.PositionEmployeeLabel.TabIndex = 8;
            this.PositionEmployeeLabel.Text = "Позиция:";
            // 
            // PhoneEmployeeLabel
            // 
            this.PhoneEmployeeLabel.AutoSize = true;
            this.PhoneEmployeeLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneEmployeeLabel.Location = new System.Drawing.Point(20, 121);
            this.PhoneEmployeeLabel.Name = "PhoneEmployeeLabel";
            this.PhoneEmployeeLabel.Size = new System.Drawing.Size(143, 21);
            this.PhoneEmployeeLabel.TabIndex = 7;
            this.PhoneEmployeeLabel.Text = "Телефонен номер:";
            // 
            // NameEmployeeLabel
            // 
            this.NameEmployeeLabel.AutoSize = true;
            this.NameEmployeeLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameEmployeeLabel.Location = new System.Drawing.Point(20, 50);
            this.NameEmployeeLabel.Name = "NameEmployeeLabel";
            this.NameEmployeeLabel.Size = new System.Drawing.Size(129, 21);
            this.NameEmployeeLabel.TabIndex = 6;
            this.NameEmployeeLabel.Text = "Име и фамилия:";
            // 
            // PositionEmployeeAddComboBox
            // 
            this.PositionEmployeeAddComboBox.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.PositionEmployeeAddComboBox.FormattingEnabled = true;
            this.PositionEmployeeAddComboBox.Items.AddRange(new object[] {
            "Мениджър отдел Банкови операции",
            "Консултант-продажби в отдел Банкиране на дребно",
            "Консултант-продажби в отдел Банково застраховане",
            "Консултант-продажби в отдел Жилищно кредитиране",
            "Консултант-продажби в отдел Стоково кредитиране",
            "Спициалист в отдел Банкови операции",
            "Главен експерт в отдел връзки с обществеността",
            "Главен експерт в отдел връзки с обществеността",
            "Специалист в одел Банкиране на дребно",
            "Управител",
            "Хигиенист"});
            this.PositionEmployeeAddComboBox.Location = new System.Drawing.Point(24, 210);
            this.PositionEmployeeAddComboBox.Name = "PositionEmployeeAddComboBox";
            this.PositionEmployeeAddComboBox.Size = new System.Drawing.Size(288, 23);
            this.PositionEmployeeAddComboBox.TabIndex = 5;
            // 
            // PhoneEmployeeAddTextBox
            // 
            this.PhoneEmployeeAddTextBox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneEmployeeAddTextBox.Location = new System.Drawing.Point(24, 145);
            this.PhoneEmployeeAddTextBox.Name = "PhoneEmployeeAddTextBox";
            this.PhoneEmployeeAddTextBox.Size = new System.Drawing.Size(288, 29);
            this.PhoneEmployeeAddTextBox.TabIndex = 2;
            // 
            // NameEmployeeAddTextBox
            // 
            this.NameEmployeeAddTextBox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameEmployeeAddTextBox.Location = new System.Drawing.Point(24, 74);
            this.NameEmployeeAddTextBox.Name = "NameEmployeeAddTextBox";
            this.NameEmployeeAddTextBox.Size = new System.Drawing.Size(288, 29);
            this.NameEmployeeAddTextBox.TabIndex = 1;
            // 
            // TitlePanelAddEmployee
            // 
            this.TitlePanelAddEmployee.AutoSize = true;
            this.TitlePanelAddEmployee.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitlePanelAddEmployee.Location = new System.Drawing.Point(252, 21);
            this.TitlePanelAddEmployee.Name = "TitlePanelAddEmployee";
            this.TitlePanelAddEmployee.Size = new System.Drawing.Size(0, 37);
            this.TitlePanelAddEmployee.TabIndex = 0;
            // 
            // TitleEmployeeInfoLabel
            // 
            this.TitleEmployeeInfoLabel.AutoSize = true;
            this.TitleEmployeeInfoLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleEmployeeInfoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleEmployeeInfoLabel.Location = new System.Drawing.Point(286, 21);
            this.TitleEmployeeInfoLabel.Name = "TitleEmployeeInfoLabel";
            this.TitleEmployeeInfoLabel.Size = new System.Drawing.Size(83, 35);
            this.TitleEmployeeInfoLabel.TabIndex = 7;
            this.TitleEmployeeInfoLabel.Text = "label1";
            // 
            // FindEmployeePanel
            // 
            this.FindEmployeePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FindEmployeePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FindEmployeePanel.Controls.Add(this.FindEmployeeByPositionComboBox);
            this.FindEmployeePanel.Controls.Add(this.ResultsFindEmployeeTable);
            this.FindEmployeePanel.Controls.Add(this.SearchImageFindEmployee);
            this.FindEmployeePanel.Controls.Add(this.SearchEmployeeTextBox);
            this.FindEmployeePanel.Controls.Add(this.FindEmployeeByPositionButton);
            this.FindEmployeePanel.Controls.Add(this.FindEmployeeByPhoneButton);
            this.FindEmployeePanel.Controls.Add(this.FindEmployeeByNameButton);
            this.FindEmployeePanel.Controls.Add(this.SearchEmployeeButton);
            this.FindEmployeePanel.Controls.Add(this.label7);
            this.FindEmployeePanel.Location = new System.Drawing.Point(23, 45);
            this.FindEmployeePanel.Name = "FindEmployeePanel";
            this.FindEmployeePanel.Size = new System.Drawing.Size(776, 443);
            this.FindEmployeePanel.TabIndex = 6;
            this.FindEmployeePanel.Visible = false;
            // 
            // FindEmployeeByPositionComboBox
            // 
            this.FindEmployeeByPositionComboBox.FormattingEnabled = true;
            this.FindEmployeeByPositionComboBox.Items.AddRange(new object[] {
            "Мениджър отдел Банкови операции",
            "Консултант-продажби в отдел Банкиране на дребно",
            "Консултант-продажби в отдел Банково застраховане",
            "Консултант-продажби в отдел Жилищно кредитиране",
            "Консултант-продажби в отдел Стоково кредитиране",
            "Спициалист в отдел Банкови операции",
            "Главен експерт в отдел връзки с обществеността",
            "Специалист в одел Банкиране на дребно",
            "Управител",
            "Хигиенист"});
            this.FindEmployeeByPositionComboBox.Location = new System.Drawing.Point(131, 143);
            this.FindEmployeeByPositionComboBox.Name = "FindEmployeeByPositionComboBox";
            this.FindEmployeeByPositionComboBox.Size = new System.Drawing.Size(444, 24);
            this.FindEmployeeByPositionComboBox.TabIndex = 13;
            this.FindEmployeeByPositionComboBox.Visible = false;
            // 
            // ResultsFindEmployeeTable
            // 
            this.ResultsFindEmployeeTable.ColumnCount = 5;
            this.ResultsFindEmployeeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultsFindEmployeeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultsFindEmployeeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultsFindEmployeeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ResultsFindEmployeeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResultsFindEmployeeTable.Location = new System.Drawing.Point(3, 196);
            this.ResultsFindEmployeeTable.Name = "ResultsFindEmployeeTable";
            this.ResultsFindEmployeeTable.RowCount = 1;
            this.ResultsFindEmployeeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResultsFindEmployeeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.ResultsFindEmployeeTable.Size = new System.Drawing.Size(773, 220);
            this.ResultsFindEmployeeTable.TabIndex = 12;
            this.ResultsFindEmployeeTable.Visible = false;
            // 
            // SearchImageFindEmployee
            // 
            this.SearchImageFindEmployee.Image = ((System.Drawing.Image)(resources.GetObject("SearchImageFindEmployee.Image")));
            this.SearchImageFindEmployee.Location = new System.Drawing.Point(65, 140);
            this.SearchImageFindEmployee.Name = "SearchImageFindEmployee";
            this.SearchImageFindEmployee.Size = new System.Drawing.Size(46, 26);
            this.SearchImageFindEmployee.TabIndex = 11;
            this.SearchImageFindEmployee.TabStop = false;
            this.SearchImageFindEmployee.Visible = false;
            // 
            // SearchEmployeeTextBox
            // 
            this.SearchEmployeeTextBox.Font = new System.Drawing.Font("Calibri", 9F);
            this.SearchEmployeeTextBox.Location = new System.Drawing.Point(128, 142);
            this.SearchEmployeeTextBox.Name = "SearchEmployeeTextBox";
            this.SearchEmployeeTextBox.Size = new System.Drawing.Size(447, 26);
            this.SearchEmployeeTextBox.TabIndex = 10;
            this.SearchEmployeeTextBox.Visible = false;
            // 
            // FindEmployeeByPositionButton
            // 
            this.FindEmployeeByPositionButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindEmployeeByPositionButton.Location = new System.Drawing.Point(528, 79);
            this.FindEmployeeByPositionButton.Name = "FindEmployeeByPositionButton";
            this.FindEmployeeByPositionButton.Size = new System.Drawing.Size(178, 36);
            this.FindEmployeeByPositionButton.TabIndex = 9;
            this.FindEmployeeByPositionButton.Text = "по позиция";
            this.FindEmployeeByPositionButton.UseVisualStyleBackColor = true;
            this.FindEmployeeByPositionButton.Click += new System.EventHandler(this.FindEmployeeByPositionButton_Click);
            // 
            // FindEmployeeByPhoneButton
            // 
            this.FindEmployeeByPhoneButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindEmployeeByPhoneButton.Location = new System.Drawing.Point(290, 79);
            this.FindEmployeeByPhoneButton.Name = "FindEmployeeByPhoneButton";
            this.FindEmployeeByPhoneButton.Size = new System.Drawing.Size(178, 36);
            this.FindEmployeeByPhoneButton.TabIndex = 8;
            this.FindEmployeeByPhoneButton.Text = "по телефонен номер";
            this.FindEmployeeByPhoneButton.UseVisualStyleBackColor = true;
            this.FindEmployeeByPhoneButton.Click += new System.EventHandler(this.FindEmployeeByPhoneButton_Click);
            // 
            // FindEmployeeByNameButton
            // 
            this.FindEmployeeByNameButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindEmployeeByNameButton.Location = new System.Drawing.Point(65, 79);
            this.FindEmployeeByNameButton.Name = "FindEmployeeByNameButton";
            this.FindEmployeeByNameButton.Size = new System.Drawing.Size(178, 36);
            this.FindEmployeeByNameButton.TabIndex = 7;
            this.FindEmployeeByNameButton.Text = "По име";
            this.FindEmployeeByNameButton.UseVisualStyleBackColor = true;
            this.FindEmployeeByNameButton.Click += new System.EventHandler(this.FindEmployeeByNameButton_Click);
            // 
            // SearchEmployeeButton
            // 
            this.SearchEmployeeButton.Location = new System.Drawing.Point(581, 140);
            this.SearchEmployeeButton.Name = "SearchEmployeeButton";
            this.SearchEmployeeButton.Size = new System.Drawing.Size(122, 28);
            this.SearchEmployeeButton.TabIndex = 5;
            this.SearchEmployeeButton.Text = "Търси";
            this.SearchEmployeeButton.UseVisualStyleBackColor = true;
            this.SearchEmployeeButton.Visible = false;
            this.SearchEmployeeButton.Click += new System.EventHandler(this.SearchEmployeeButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(283, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 37);
            this.label7.TabIndex = 0;
            this.label7.Text = "Търси служител";
            // 
            // AdminMainManu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(837, 500);
            this.Controls.Add(this.FindEmployeePanel);
            this.Controls.Add(this.menuStripAdmin);
            this.Controls.Add(this.AddNewEmployeePanel);
            this.Controls.Add(this.HelloLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStripAdmin;
            this.Name = "AdminMainManu";
            this.Text = "Администратор";
            this.Load += new System.EventHandler(this.AdminMainManu_Load);
            this.menuStripAdmin.ResumeLayout(false);
            this.menuStripAdmin.PerformLayout();
            this.AddNewEmployeePanel.ResumeLayout(false);
            this.AddNewEmployeePanel.PerformLayout();
            this.ProfileDataEmployeeAdd.ResumeLayout(false);
            this.ProfileDataEmployeeAdd.PerformLayout();
            this.groupBoxEmployeeDataAdd.ResumeLayout(false);
            this.groupBoxEmployeeDataAdd.PerformLayout();
            this.FindEmployeePanel.ResumeLayout(false);
            this.FindEmployeePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchImageFindEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem AddEmployeeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindEmployeeMenuItem;
        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.ToolStripMenuItem ExitProfileMenuItem;
        private System.Windows.Forms.Panel AddNewEmployeePanel;
        private System.Windows.Forms.GroupBox groupBoxEmployeeDataAdd;
        private System.Windows.Forms.TextBox NameEmployeeAddTextBox;
        private System.Windows.Forms.Label TitlePanelAddEmployee;
        private System.Windows.Forms.GroupBox ProfileDataEmployeeAdd;
        private System.Windows.Forms.TextBox UsernameEmployeeAddTextBox;
        private System.Windows.Forms.TextBox PhoneEmployeeAddTextBox;
        private System.Windows.Forms.TextBox PasswordEmployeeAddTextBox;
        private System.Windows.Forms.Label NameEmployeeLabel;
        private System.Windows.Forms.ComboBox PositionEmployeeAddComboBox;
        private System.Windows.Forms.Label PhoneEmployeeLabel;
        private System.Windows.Forms.Label PasswordEmployeeLabel;
        private System.Windows.Forms.Label UsernameEmployeeLabel;
        private System.Windows.Forms.Label PositionEmployeeLabel;
        private System.Windows.Forms.Button TitleEmployeeInfoButton;
        private System.Windows.Forms.Button CancelAddEmployeeButton;
        private System.Windows.Forms.Label TypeProfileEmployeeLabel;
        private System.Windows.Forms.ComboBox TypeProfileEmployeeAddComboBox;
        private System.Windows.Forms.Panel FindEmployeePanel;
        private System.Windows.Forms.Button SearchEmployeeButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button FindEmployeeByPositionButton;
        private System.Windows.Forms.Button FindEmployeeByPhoneButton;
        private System.Windows.Forms.Button FindEmployeeByNameButton;
        private System.Windows.Forms.TextBox SearchEmployeeTextBox;
        private System.Windows.Forms.PictureBox SearchImageFindEmployee;
        private System.Windows.Forms.TableLayoutPanel ResultsFindEmployeeTable;
        private System.Windows.Forms.Label TitleEmployeeInfoLabel;
        private System.Windows.Forms.ComboBox FindEmployeeByPositionComboBox;
    }
}