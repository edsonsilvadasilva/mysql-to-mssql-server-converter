namespace MysqlToSqlServerConverter
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBarServer = new System.Windows.Forms.ProgressBar();
            this.buttonConnectServer = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxUserName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAuthentication = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxServerName = new System.Windows.Forms.ComboBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxDriver = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxMysqlDB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxMysqlPass = new System.Windows.Forms.TextBox();
            this.comboBoxMysqlHost = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMysqlConnectionStr = new System.Windows.Forms.TextBox();
            this.comboBoxMysqlUser = new System.Windows.Forms.ComboBox();
            this.buttonMysqlTest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.generationProgressBar = new System.Windows.Forms.ProgressBar();
            this.checkBoxImportantMsg = new System.Windows.Forms.CheckBox();
            this.buttonControl = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.checkBoxAlterMsg = new System.Windows.Forms.CheckBox();
            this.checkBoxRetrievalMsg = new System.Windows.Forms.CheckBox();
            this.checkBoxScriptMsg = new System.Windows.Forms.CheckBox();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.toolTipMSSQLConnect = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.progressBarServer);
            this.groupBox1.Controls.Add(this.buttonConnectServer);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBoxDatabase);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxAuthentication);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxServerName);
            this.groupBox1.Controls.Add(this.buttonTest);
            this.groupBox1.Controls.Add(this.textBoxConnectionString);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MsSQL Connection";
            // 
            // progressBarServer
            // 
            this.progressBarServer.Location = new System.Drawing.Point(82, 18);
            this.progressBarServer.Name = "progressBarServer";
            this.progressBarServer.Size = new System.Drawing.Size(158, 22);
            this.progressBarServer.TabIndex = 37;
            this.progressBarServer.Visible = false;
            // 
            // buttonConnectServer
            // 
            this.buttonConnectServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonConnectServer.Location = new System.Drawing.Point(244, 17);
            this.buttonConnectServer.Name = "buttonConnectServer";
            this.buttonConnectServer.Size = new System.Drawing.Size(23, 23);
            this.buttonConnectServer.TabIndex = 8;
            this.buttonConnectServer.Text = "...";
            this.toolTipMSSQLConnect.SetToolTip(this.buttonConnectServer, "List all available servers.");
            this.buttonConnectServer.UseVisualStyleBackColor = false;
            this.buttonConnectServer.Click += new System.EventHandler(this.buttonConnectServer_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Connection String:";
            this.toolTipMSSQLConnect.SetToolTip(this.label11, "You can edit the connection string here.");
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.BackColor = System.Drawing.Color.White;
            this.comboBoxDatabase.FormattingEnabled = true;
            this.comboBoxDatabase.Location = new System.Drawing.Point(82, 144);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.Size = new System.Drawing.Size(178, 21);
            this.comboBoxDatabase.TabIndex = 30;
            this.toolTipMSSQLConnect.SetToolTip(this.comboBoxDatabase, "Choose database for MSSQL.");
            this.comboBoxDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabase_SelectedIndexChanged);
            this.comboBoxDatabase.TextChanged += new System.EventHandler(this.comboBoxDatabase_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Database:";
            this.toolTipMSSQLConnect.SetToolTip(this.label9, "Choose database for MSSQL.");
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.Location = new System.Drawing.Point(82, 93);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(178, 20);
            this.textBoxPassword.TabIndex = 20;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // comboBoxUserName
            // 
            this.comboBoxUserName.BackColor = System.Drawing.Color.White;
            this.comboBoxUserName.FormattingEnabled = true;
            this.comboBoxUserName.Location = new System.Drawing.Point(82, 70);
            this.comboBoxUserName.Name = "comboBoxUserName";
            this.comboBoxUserName.Size = new System.Drawing.Size(178, 21);
            this.comboBoxUserName.TabIndex = 15;
            this.comboBoxUserName.TextChanged += new System.EventHandler(this.comboBoxUserName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Name:";
            // 
            // comboBoxAuthentication
            // 
            this.comboBoxAuthentication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBoxAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAuthentication.FormattingEnabled = true;
            this.comboBoxAuthentication.Location = new System.Drawing.Point(82, 43);
            this.comboBoxAuthentication.Name = "comboBoxAuthentication";
            this.comboBoxAuthentication.Size = new System.Drawing.Size(178, 21);
            this.comboBoxAuthentication.TabIndex = 10;
            this.comboBoxAuthentication.TextChanged += new System.EventHandler(this.comboBoxAuthentication_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Authentication:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Name:";
            // 
            // comboBoxServerName
            // 
            this.comboBoxServerName.BackColor = System.Drawing.Color.White;
            this.comboBoxServerName.FormattingEnabled = true;
            this.comboBoxServerName.Location = new System.Drawing.Point(82, 19);
            this.comboBoxServerName.Name = "comboBoxServerName";
            this.comboBoxServerName.Size = new System.Drawing.Size(158, 21);
            this.comboBoxServerName.TabIndex = 5;
            this.comboBoxServerName.DropDown += new System.EventHandler(this.comboBoxServerName_DropDown);
            this.comboBoxServerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxServerName_SelectedIndexChanged);
            this.comboBoxServerName.TextChanged += new System.EventHandler(this.comboBoxServerName_TextChanged);
            // 
            // buttonTest
            // 
            this.buttonTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonTest.Location = new System.Drawing.Point(6, 112);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(57, 23);
            this.buttonTest.TabIndex = 25;
            this.buttonTest.Text = "Connect";
            this.toolTipMSSQLConnect.SetToolTip(this.buttonTest, "Press button to connect to MS SQL Server 2005 and higher.\r\nIf successful, press t" +
                    "he MYSQL Connect button.");
            this.buttonTest.UseVisualStyleBackColor = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.BackColor = System.Drawing.Color.White;
            this.textBoxConnectionString.Location = new System.Drawing.Point(9, 188);
            this.textBoxConnectionString.Multiline = true;
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(251, 79);
            this.textBoxConnectionString.TabIndex = 35;
            this.toolTipMSSQLConnect.SetToolTip(this.textBoxConnectionString, "You can edit the connection string here.");
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.comboBoxDriver);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comboBoxMysqlDB);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBoxMysqlPass);
            this.groupBox2.Controls.Add(this.comboBoxMysqlHost);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxMysqlConnectionStr);
            this.groupBox2.Controls.Add(this.comboBoxMysqlUser);
            this.groupBox2.Controls.Add(this.buttonMysqlTest);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(287, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 278);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MySQL Connection";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // comboBoxDriver
            // 
            this.comboBoxDriver.BackColor = System.Drawing.Color.White;
            this.comboBoxDriver.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MysqlToSqlServerConverter.Properties.Settings.Default, "DefaultMYSQLDriver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDriver.FormattingEnabled = true;
            this.comboBoxDriver.Location = new System.Drawing.Point(82, 88);
            this.comboBoxDriver.Name = "comboBoxDriver";
            this.comboBoxDriver.Size = new System.Drawing.Size(178, 21);
            this.comboBoxDriver.TabIndex = 53;
            this.comboBoxDriver.Text = global::MysqlToSqlServerConverter.Properties.Settings.Default.DefaultMYSQLDriver;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Driver:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Connection String:";
            this.toolTipMSSQLConnect.SetToolTip(this.label12, "You can edit the connection string here.");
            // 
            // comboBoxMysqlDB
            // 
            this.comboBoxMysqlDB.BackColor = System.Drawing.Color.White;
            this.comboBoxMysqlDB.FormattingEnabled = true;
            this.comboBoxMysqlDB.Location = new System.Drawing.Point(82, 139);
            this.comboBoxMysqlDB.Name = "comboBoxMysqlDB";
            this.comboBoxMysqlDB.Size = new System.Drawing.Size(178, 21);
            this.comboBoxMysqlDB.TabIndex = 60;
            this.toolTipMSSQLConnect.SetToolTip(this.comboBoxMysqlDB, "Choose database for MYSQL.");
            this.comboBoxMysqlDB.SelectedIndexChanged += new System.EventHandler(this.comboBoxMysqlDB_SelectedIndexChanged);
            this.comboBoxMysqlDB.TextChanged += new System.EventHandler(this.comboBoxMysqlDB_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Database:";
            this.toolTipMSSQLConnect.SetToolTip(this.label10, "Choose database for MYSQL.");
            // 
            // textBoxMysqlPass
            // 
            this.textBoxMysqlPass.BackColor = System.Drawing.Color.White;
            this.textBoxMysqlPass.Location = new System.Drawing.Point(82, 67);
            this.textBoxMysqlPass.Name = "textBoxMysqlPass";
            this.textBoxMysqlPass.Size = new System.Drawing.Size(178, 20);
            this.textBoxMysqlPass.TabIndex = 50;
            this.textBoxMysqlPass.UseSystemPasswordChar = true;
            this.textBoxMysqlPass.TextChanged += new System.EventHandler(this.textBoxMysqlPass_TextChanged);
            // 
            // comboBoxMysqlHost
            // 
            this.comboBoxMysqlHost.BackColor = System.Drawing.Color.White;
            this.comboBoxMysqlHost.FormattingEnabled = true;
            this.comboBoxMysqlHost.Location = new System.Drawing.Point(82, 20);
            this.comboBoxMysqlHost.Name = "comboBoxMysqlHost";
            this.comboBoxMysqlHost.Size = new System.Drawing.Size(178, 21);
            this.comboBoxMysqlHost.TabIndex = 40;
            this.comboBoxMysqlHost.TextChanged += new System.EventHandler(this.comboBoxMysqlHost_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Password:";
            // 
            // textBoxMysqlConnectionStr
            // 
            this.textBoxMysqlConnectionStr.BackColor = System.Drawing.Color.White;
            this.textBoxMysqlConnectionStr.Location = new System.Drawing.Point(9, 188);
            this.textBoxMysqlConnectionStr.Multiline = true;
            this.textBoxMysqlConnectionStr.Name = "textBoxMysqlConnectionStr";
            this.textBoxMysqlConnectionStr.Size = new System.Drawing.Size(251, 79);
            this.textBoxMysqlConnectionStr.TabIndex = 65;
            this.toolTipMSSQLConnect.SetToolTip(this.textBoxMysqlConnectionStr, "You can edit the connection string here.");
            // 
            // comboBoxMysqlUser
            // 
            this.comboBoxMysqlUser.BackColor = System.Drawing.Color.White;
            this.comboBoxMysqlUser.FormattingEnabled = true;
            this.comboBoxMysqlUser.Location = new System.Drawing.Point(82, 44);
            this.comboBoxMysqlUser.Name = "comboBoxMysqlUser";
            this.comboBoxMysqlUser.Size = new System.Drawing.Size(178, 21);
            this.comboBoxMysqlUser.TabIndex = 45;
            this.comboBoxMysqlUser.TextChanged += new System.EventHandler(this.comboBoxMysqlUser_TextChanged);
            // 
            // buttonMysqlTest
            // 
            this.buttonMysqlTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonMysqlTest.Enabled = false;
            this.buttonMysqlTest.Location = new System.Drawing.Point(11, 107);
            this.buttonMysqlTest.Name = "buttonMysqlTest";
            this.buttonMysqlTest.Size = new System.Drawing.Size(57, 23);
            this.buttonMysqlTest.TabIndex = 55;
            this.buttonMysqlTest.Text = "Connect";
            this.toolTipMSSQLConnect.SetToolTip(this.buttonMysqlTest, "Press button to test the connection of MYSQL database.\r\nIf successful, you can no" +
                    "w click the Start button to begin conversion.");
            this.buttonMysqlTest.UseVisualStyleBackColor = false;
            this.buttonMysqlTest.Click += new System.EventHandler(this.buttonMysqlTest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "User Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Hostname:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.generationProgressBar);
            this.groupBox3.Controls.Add(this.checkBoxImportantMsg);
            this.groupBox3.Controls.Add(this.buttonControl);
            this.groupBox3.Controls.Add(this.textBoxFile);
            this.groupBox3.Controls.Add(this.checkBoxAlterMsg);
            this.groupBox3.Controls.Add(this.checkBoxRetrievalMsg);
            this.groupBox3.Controls.Add(this.checkBoxScriptMsg);
            this.groupBox3.Controls.Add(this.richTextBoxMessage);
            this.groupBox3.Controls.Add(this.buttonStart);
            this.groupBox3.Location = new System.Drawing.Point(8, 296);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(549, 237);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Convert MYSQL to MSSQL";
            this.toolTipMSSQLConnect.SetToolTip(this.groupBox3, "Click this button to view available servers for MSSQL.");
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(4, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 105;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // generationProgressBar
            // 
            this.generationProgressBar.Location = new System.Drawing.Point(91, 208);
            this.generationProgressBar.Name = "generationProgressBar";
            this.generationProgressBar.Size = new System.Drawing.Size(451, 23);
            this.generationProgressBar.TabIndex = 40;
            // 
            // checkBoxImportantMsg
            // 
            this.checkBoxImportantMsg.AutoSize = true;
            this.checkBoxImportantMsg.Checked = true;
            this.checkBoxImportantMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxImportantMsg.Location = new System.Drawing.Point(91, 45);
            this.checkBoxImportantMsg.Name = "checkBoxImportantMsg";
            this.checkBoxImportantMsg.Size = new System.Drawing.Size(160, 17);
            this.checkBoxImportantMsg.TabIndex = 75;
            this.checkBoxImportantMsg.Text = "Show Conversion Messages";
            this.toolTipMSSQLConnect.SetToolTip(this.checkBoxImportantMsg, "There are scripts from the MYSQL that is not supported in\r\nMSSQL. This will displ" +
                    "ay the script that is not converted.");
            this.checkBoxImportantMsg.UseVisualStyleBackColor = true;
            // 
            // buttonControl
            // 
            this.buttonControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonControl.Location = new System.Drawing.Point(4, 19);
            this.buttonControl.Name = "buttonControl";
            this.buttonControl.Size = new System.Drawing.Size(75, 23);
            this.buttonControl.TabIndex = 67;
            this.buttonControl.Text = "Control";
            this.toolTipMSSQLConnect.SetToolTip(this.buttonControl, "Select the ConvertControl.sql file. This is the control file\r\nscript the do almos" +
                    "t all the conversion. Look for this file\r\nwithin the exe folder.");
            this.buttonControl.UseVisualStyleBackColor = false;
            this.buttonControl.Click += new System.EventHandler(this.buttonControl_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MysqlToSqlServerConverter.Properties.Settings.Default, "DefaultControlfile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFile.Location = new System.Drawing.Point(91, 19);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(438, 20);
            this.textBoxFile.TabIndex = 70;
            this.textBoxFile.Text = global::MysqlToSqlServerConverter.Properties.Settings.Default.DefaultControlfile;
            this.toolTipMSSQLConnect.SetToolTip(this.textBoxFile, "Select the ConvertControl.sql file. This is the control file");
            // 
            // checkBoxAlterMsg
            // 
            this.checkBoxAlterMsg.AutoSize = true;
            this.checkBoxAlterMsg.Location = new System.Drawing.Point(376, 68);
            this.checkBoxAlterMsg.Name = "checkBoxAlterMsg";
            this.checkBoxAlterMsg.Size = new System.Drawing.Size(153, 17);
            this.checkBoxAlterMsg.TabIndex = 90;
            this.checkBoxAlterMsg.Text = "Show Alter Table Message";
            this.toolTipMSSQLConnect.SetToolTip(this.checkBoxAlterMsg, "Check this to show all the ALTER script. This is used for debugging the control.");
            this.checkBoxAlterMsg.UseVisualStyleBackColor = true;
            // 
            // checkBoxRetrievalMsg
            // 
            this.checkBoxRetrievalMsg.AutoSize = true;
            this.checkBoxRetrievalMsg.Location = new System.Drawing.Point(226, 68);
            this.checkBoxRetrievalMsg.Name = "checkBoxRetrievalMsg";
            this.checkBoxRetrievalMsg.Size = new System.Drawing.Size(144, 17);
            this.checkBoxRetrievalMsg.TabIndex = 85;
            this.checkBoxRetrievalMsg.Text = "Show Retrieval Message";
            this.toolTipMSSQLConnect.SetToolTip(this.checkBoxRetrievalMsg, "Check this to view all the SELECT query within the control. This is used for debu" +
                    "gging.");
            this.checkBoxRetrievalMsg.UseVisualStyleBackColor = true;
            // 
            // checkBoxScriptMsg
            // 
            this.checkBoxScriptMsg.AutoSize = true;
            this.checkBoxScriptMsg.Location = new System.Drawing.Point(91, 68);
            this.checkBoxScriptMsg.Name = "checkBoxScriptMsg";
            this.checkBoxScriptMsg.Size = new System.Drawing.Size(129, 17);
            this.checkBoxScriptMsg.TabIndex = 80;
            this.checkBoxScriptMsg.Text = "Show Script Message";
            this.toolTipMSSQLConnect.SetToolTip(this.checkBoxScriptMsg, "Check this to show that script section that is running. This is good for debuggin" +
                    "g the control.");
            this.checkBoxScriptMsg.UseVisualStyleBackColor = true;
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.BackColor = System.Drawing.Color.White;
            this.richTextBoxMessage.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MysqlToSqlServerConverter.Properties.Settings.Default, "DefaultTextBoxMessage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.richTextBoxMessage.Location = new System.Drawing.Point(91, 93);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ReadOnly = true;
            this.richTextBoxMessage.Size = new System.Drawing.Size(451, 112);
            this.richTextBoxMessage.TabIndex = 100;
            this.richTextBoxMessage.Text = global::MysqlToSqlServerConverter.Properties.Settings.Default.DefaultTextBoxMessage;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(4, 91);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 95;
            this.buttonStart.Text = "Start";
            this.toolTipMSSQLConnect.SetToolTip(this.buttonStart, "This will start the conversion process. Please see to it that you\r\nselect the pro" +
                    "per databases.");
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconApp.Icon")));
            this.notifyIconApp.Text = "notifyIconApp";
            this.notifyIconApp.Visible = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(25, 167);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 106;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(25, 192);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(42, 13);
            this.linkLabel2.TabIndex = 107;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Donate";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = global::MysqlToSqlServerConverter.Properties.Resources.myimage;
            this.ClientSize = new System.Drawing.Size(562, 539);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "MYSQL to MSSQL Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxAuthentication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxDatabase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxMysqlPass;
        private System.Windows.Forms.ComboBox comboBoxMysqlHost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMysqlConnectionStr;
        private System.Windows.Forms.ComboBox comboBoxMysqlUser;
        private System.Windows.Forms.Button buttonMysqlTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxMysqlDB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonConnectServer;
        private System.Windows.Forms.ComboBox comboBoxDriver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.CheckBox checkBoxAlterMsg;
        private System.Windows.Forms.CheckBox checkBoxRetrievalMsg;
        private System.Windows.Forms.CheckBox checkBoxScriptMsg;
        private System.Windows.Forms.Button buttonControl;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.CheckBox checkBoxImportantMsg;
        private System.Windows.Forms.ProgressBar generationProgressBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTipMSSQLConnect;
        private System.Windows.Forms.ProgressBar progressBarServer;
        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;


    }
}