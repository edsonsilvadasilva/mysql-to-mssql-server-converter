using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Moletrator.SQLDocumentor;
using Moletrator.MySQLDocumentor;
using System.Threading;
using System.Windows.Threading;
using System.Reflection;

namespace MysqlToSqlServerConverter
{
    public partial class Main : Form
    {
        public string ConvertControl;

        public class KeyValuePair  
        {  
   
            public string Key;
            public string Value;
            public bool BoolValue;
  

            public KeyValuePair(string NewValue,string NewDescription,bool boolValue)  
            {  
                 Key = NewValue;
                 Value = NewDescription;
                BoolValue = boolValue;
            }  
       
            public override string ToString()  
            {
                return Value;
            }  
        }


        //string MSSQLConnectionString;
        //string MySQLConnectionString;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ConvertControl = "ConvertControl.sql";

            if (this.textBoxFile.Text == String.Empty)
            {
                this.textBoxFile.Text = System.IO.Directory.GetCurrentDirectory() + "\\" + ConvertControl;
            }

            KeyValuePair defaultValue = new KeyValuePair("True", "Windows Authentication",true);
            KeyValuePair defaultValue1 = new KeyValuePair("False", "SQL Server Authentication",false);

            comboBoxAuthentication.Items.Add(defaultValue);
            comboBoxAuthentication.Items.Add(defaultValue1);

            if(Properties.Settings.Default.DefaultMSSQLAuthentication == "True")
            {
                comboBoxAuthentication.SelectedItem = defaultValue;
            }
            else
            {
                comboBoxAuthentication.SelectedItem = defaultValue1;
            }
            
            this.comboBoxServerName.Text = Properties.Settings.Default.DefaultMSSQLServerName;
            this.comboBoxDatabase.Items.Add(Properties.Settings.Default.DefaultMSSQLDatabase);
            this.comboBoxDatabase.Text = Properties.Settings.Default.DefaultMSSQLDatabase;
            this.comboBoxUserName.Items.Add(Properties.Settings.Default.DefaultMSSQLUser);
            this.comboBoxUserName.Text = Properties.Settings.Default.DefaultMSSQLUser;
            this.textBoxPassword.Text = Properties.Settings.Default.DefaultMSSQLPass;
            this.comboBoxMysqlHost.Items.Add(Properties.Settings.Default.DefaultMYSQLHost);
            this.comboBoxMysqlHost.Text = Properties.Settings.Default.DefaultMYSQLHost;
            this.comboBoxMysqlUser.Items.Add(Properties.Settings.Default.DefaultMYSQLUser);
            this.comboBoxMysqlUser.Text = Properties.Settings.Default.DefaultMYSQLUser;
            this.comboBoxMysqlDB.Items.Add(Properties.Settings.Default.DefaultMYSQLDatabase);
            this.comboBoxMysqlDB.Text = Properties.Settings.Default.DefaultMYSQLDatabase;
            this.textBoxMysqlPass.Text = Properties.Settings.Default.DefaultMYSQLPass;
            this.textBoxFile.Text = Properties.Settings.Default.DefaultControlfile;
            this.richTextBoxMessage.Text = Properties.Settings.Default.DefaultTextBoxMessage;
        }

        private void FormMSSQLConnectionString()
        {
            textBoxConnectionString.Text = SQLInfoEnumerator.BuildConnectionstring(comboBoxServerName.Text, comboBoxDatabase.Text, comboBoxUserName.Text, textBoxPassword.Text, ((KeyValuePair)comboBoxAuthentication.SelectedItem).BoolValue);
        }

        private void FormMySQLConnectionString()
        {
            textBoxMysqlConnectionStr.Text = "DRIVER={" + this.comboBoxDriver.Text + "};SERVER=" + comboBoxMysqlHost.Text + ";" + (comboBoxMysqlDB.Text == String.Empty ? "DATABASE=mysql;" : "DATABASE =" + comboBoxMysqlDB.Text + ";") + " USER=" + comboBoxMysqlUser.Text +
                "; PASSWORD=" + textBoxMysqlPass.Text + "; OPTION=3";
        }

        private void comboBoxServerName_TextChanged(object sender, EventArgs e)
        {
            FormMSSQLConnectionString();
        }

        private void comboBoxAuthentication_TextChanged(object sender, EventArgs e)
        {
            if (((KeyValuePair)((ComboBox)sender).SelectedItem).Key == "True")
            {
                this.comboBoxUserName.Enabled = false;
                this.textBoxPassword.Enabled = false;
            }
            else
            {
                this.comboBoxUserName.Enabled = true;
                this.textBoxPassword.Enabled = true;
            }
            
            FormMSSQLConnectionString();
        }

        private void comboBoxUserName_TextChanged(object sender, EventArgs e)
        {
            FormMSSQLConnectionString();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            FormMSSQLConnectionString();
        }

        private void comboBoxDatabase_TextChanged(object sender, EventArgs e)
        {
            FormMSSQLConnectionString();
        }

        private void comboBoxMysqlHost_TextChanged(object sender, EventArgs e)
        {
            FormMySQLConnectionString();
        }

        private void comboBoxMysqlPort_StyleChanged(object sender, EventArgs e)
        {
            FormMySQLConnectionString();
        }

        private void comboBoxMysqlUser_TextChanged(object sender, EventArgs e)
        {
            FormMySQLConnectionString();
        }

        private void textBoxMysqlPass_TextChanged(object sender, EventArgs e)
        {
            FormMySQLConnectionString();
        }

        private void comboBoxMysqlDB_TextChanged(object sender, EventArgs e)
        {
            FormMySQLConnectionString();
        }



        private void SaveSettingsMSSQL()
        {
            Properties.Settings.Default.DefaultMSSQLDatabase = this.comboBoxDatabase.Text;
            Properties.Settings.Default.DefaultMSSQLAuthentication = ((KeyValuePair)this.comboBoxAuthentication.SelectedItem).Key;
            Properties.Settings.Default.DefaultMSSQLServerName = this.comboBoxServerName.Text;
            Properties.Settings.Default.DefaultMSSQLUser = this.comboBoxUserName.Text;
            Properties.Settings.Default.DefaultMSSQLPass = this.textBoxPassword.Text;


            Properties.Settings.Default.Save();
        }

        private void SaveSettingsMYSQL()
        {

            Properties.Settings.Default.DefaultMYSQLDatabase = this.comboBoxMysqlDB.Text;
            Properties.Settings.Default.DefaultMYSQLHost = this.comboBoxMysqlHost.Text;
            Properties.Settings.Default.DefaultMYSQLPass = this.textBoxMysqlPass.Text;
            Properties.Settings.Default.DefaultMYSQLUser = this.comboBoxMysqlUser.Text;

            Properties.Settings.Default.Save();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            object[] databases;

            if (SQLInfoEnumerator.TestConnection(this.textBoxConnectionString.Text,out databases))
            {
                buttonMysqlTest.Enabled = true;
                MessageBox.Show(this,"Database Connection Successful.");

                this.comboBoxDatabase.Items.Clear();
                this.comboBoxDatabase.Items.AddRange(databases);
            }
            else
            {
                buttonMysqlTest.Enabled = false;                

                MessageBox.Show(this,"Failed to Connect to Database");
            }

            SaveSettingsMSSQL();
            
        }

        private void buttonMysqlTest_Click(object sender, EventArgs e)
        {
            object[] databases;

            if (SQLInfoEnumerator.TestConnectionMySQL(this.textBoxConnectionString.Text,this.textBoxMysqlConnectionStr.Text,this.comboBoxMysqlDB.Text, out databases))
            {
                buttonStart.Enabled = true;
                MessageBox.Show(this, "MySQL Database Connection Successful.");



                this.comboBoxMysqlDB.Items.Clear();
                this.comboBoxMysqlDB.Items.AddRange(databases);
            }
            else
            {
                buttonStart.Enabled = false;
                MessageBox.Show(this, "Failed to Connect to Database");

            }

            SaveSettingsMYSQL();

        }
        private void buttonConnectServer_Click(object sender, EventArgs e)
        {
            progressBarServer.Visible = true;
            progressBarServer.Value = 50;
            SQLInfoEnumerator sie = new SQLInfoEnumerator();
            try
            {
                buttonConnectServer.Enabled = false;

                string[] listServers = sie.EnumerateSQLServers();
                if (listServers != null)
                {
                    progressBarServer.Value = 80;
                    comboBoxServerName.Items.Clear();
                    comboBoxServerName.Items.AddRange(listServers);
                }
                progressBarServer.Value = 100;
                buttonConnectServer.Enabled = true;
                progressBarServer.Visible = false;
            }
            catch (Exception ex)
            {
                buttonConnectServer.Enabled = true;
                progressBarServer.Visible = false;
                MessageBox.Show(ex.ToString());
            }
        }
 
        private void buttonControl_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            dialog.DefaultExt = ".sql";
            dialog.Filter = "Control Files (.sql)|*.sql";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                this.textBoxFile.Text = dialog.FileName;
            }
        }

        private void scriptGenerator_GenerationComplete(object sender, ScriptGeneratedEventArgs e)
        {
            SetControlPropertyValue(this.richTextBoxMessage, "Text", e.GenerationMessage);
            SetControlPropertyValue(this.generationProgressBar, "Value", 100);
            MessageBox.Show("Execution Finished!");
            setControl(true);
        }
        private void scriptGenerator_GenerationError(object sender, ScriptGeneratedEventArgs e)
        {
            setControl(true);
            if (e.GenerationException.Message.StartsWith("*"))
            {
                SetControlPropertyValue(this.richTextBoxMessage, "Text", e.GenerationException.Message);
                scriptGenerator_GenerationComplete(sender, e);
                
            }
            else
            {
                MessageBox.Show("Error occured during conversion." + e.GenerationException.Message, "Generation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetControlPropertyValue(this.generationProgressBar, "Value", 0);
                SetControlPropertyValue(this.richTextBoxMessage, "Text", e.GenerationException.Message);
            }

        }
        private void scriptGenerator_ScriptBeginGeneration(object sender, ScriptGeneratedEventArgs e)
        { 
            SetControlPropertyValue(this.generationProgressBar, "Value", 50);
        }
        private void scriptGenerator_ScriptEndGeneration(object sender, ScriptGeneratedEventArgs e)
        { 
            SetControlPropertyValue(this.generationProgressBar, "Value", 90);
        }

        private void setControl(bool enable)
        {
            this.buttonTest.Enabled = enable;
            this.buttonMysqlTest.Enabled = enable;
            this.buttonConnectServer.Enabled = enable;
            this.buttonStart.Enabled = enable;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            bool allowgeneration = this.comboBoxDatabase.Text != String.Empty && this.comboBoxMysqlDB.Text != String.Empty;
            bool begingeneration = true;

            Properties.Settings.Default.DefaultControlfile = this.textBoxFile.Text;
            Properties.Settings.Default.Save();

            if (!allowgeneration)
            {
                begingeneration = false;
                MessageBox.Show("Please select Database!", "Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (this.comboBoxDatabase.Text != String.Empty)
                {
                    this.comboBoxDatabase.Focus();
                }
                if (this.comboBoxMysqlDB.Text != String.Empty)
                {
                    this.comboBoxMysqlDB.Focus();
                }
            }


            if (begingeneration && !File.Exists(this.textBoxFile.Text))
            {
                MessageBox.Show("Control file does not exist! Please look for file named " + ConvertControl + ".", "Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (begingeneration== true && MessageBox.Show("Are you sure you wan't to generate MYSQL database to MSSQL?", "Generation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                begingeneration = true;
            }
            else
            {
                begingeneration = false;
            }

            if(begingeneration == true)
            {

                setControl(false);

                try
                {
                    SQLScriptGenerator generate = new SQLScriptGenerator(this.textBoxConnectionString.Text,
                         this.textBoxMysqlConnectionStr.Text, this.comboBoxDatabase.Text, this.comboBoxMysqlDB.Text, this.textBoxFile.Text,
                         this.checkBoxImportantMsg.Checked, checkBoxScriptMsg.Checked, this.checkBoxRetrievalMsg.Checked, this.checkBoxAlterMsg.Checked);

                    this.richTextBoxMessage.Text = "";

                    Thread generationThread = new Thread(delegate()
                    {
                        GenerateScripts(generate);
                    });

                    generationThread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void GenerateScripts(SQLScriptGenerator generate)
        {
 
            try
            {

                generate.GenerationComplete += scriptGenerator_GenerationComplete;
                generate.GenerationError += scriptGenerator_GenerationError;
                generate.ScriptBeginGeneration += scriptGenerator_ScriptBeginGeneration;
                generate.ScriptEndGeneration += scriptGenerator_ScriptEndGeneration;


                generate.Generate();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             

        }


 
        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        private void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBoxMessage.Text = "";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxServerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void comboBoxServerName_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBoxMysqlDB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMysqlPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void comboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void Clear(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DefaultControlfile = this.textBoxFile.Text;
            Properties.Settings.Default.DefaultTextBoxMessage = this.richTextBoxMessage.Text;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBoxConverter x = new AboutBoxConverter();
            x.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://convertmysqltosqlserver.blogspot.com/2012/03/migrate-mysql-to-microsoft-sql-server.html");
        }


    }
}
