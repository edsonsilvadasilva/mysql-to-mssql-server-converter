using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace MysqlToSqlServerConverter
{
    class SQLScriptGenerator
    {
        public bool ShowImportantMessage { get; set; }
        public bool ShowScriptMessage { get; set; }
        public bool ShowRetrievalMessage { get; set; }
        public bool ShowAlterTableMessage { get; set; }
        public string ConnectionStringMsSQL { get; set; }
        public string ConnectionStringMySQL { get; set; }
        public string DatabaseMsSQL { get; set; }
        public string DatabaseMySQL { get; set; }
        public string ControlFile { get; set; }
        public string ExecutionMessage { get; set; }

        public SQLScriptGenerator(string connectionStringMsSQL,
            string connectionStringMySQL, string databaseMsSQL, string databaseMySQL,string controlFile,
            bool showImportantMessage, bool showScriptMessage, bool showRetrievalMessage, bool showAlterTableMessage)
        {

            this.SetConnections(connectionStringMsSQL,
            connectionStringMySQL, databaseMsSQL, databaseMySQL,controlFile,
            showImportantMessage, showScriptMessage, showRetrievalMessage, showAlterTableMessage);
        }


        public void SetConnections(string connectionStringMsSQL,
            string connectionStringMySQL, string databaseMsSQL, string databaseMySQL,string controlFile,
            bool showImportantMessage, bool showScriptMessage, bool showRetrievalMessage, bool showAlterTableMessage)
        {
            this.ShowImportantMessage = showImportantMessage;
            this.ShowScriptMessage = showScriptMessage;
            this.ShowRetrievalMessage = showRetrievalMessage;
            this.ShowAlterTableMessage = showAlterTableMessage;
            this.ConnectionStringMsSQL = connectionStringMsSQL;
            this.ConnectionStringMySQL = connectionStringMySQL;
            this.DatabaseMsSQL = databaseMsSQL;
            this.DatabaseMySQL = databaseMySQL;
            this.ControlFile = controlFile;
        }

        void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            ExecutionMessage = e.Message;
        }

        public void Generate()
        {
            bool errored = false;
            using (SqlConnection conn = new SqlConnection(this.ConnectionStringMsSQL))
            {
                conn.InfoMessage += new SqlInfoMessageEventHandler(ConnectionInfoMessage);
                conn.Open();
                try
                {
                    string sql = GetControlSql(this.ControlFile);
                    OnScriptBeginGeneration(new ScriptGeneratedEventArgs());
                    //using (SqlDataAdapter adapter = new SqlDataAdapter())
                    //{
                        using (SqlCommand command = new SqlCommand { Connection = conn, CommandType = CommandType.Text })
                        {
                            command.CommandTimeout = 600;

                            command.CommandText = sql;
                            // command.Parameters.AddWithValue("@StartDate", versionDate);
                            command.Parameters.AddWithValue("@database",this.DatabaseMsSQL);
                            //--declare @database nvarchar(255)
                            command.Parameters.AddWithValue("@mysqldatabase", this.DatabaseMySQL);
                            //--declare @mysqldatabase nvarchar(255)
                            command.Parameters.AddWithValue("@showmessage",this.ShowScriptMessage);
                            //--declare @showmessage bit 
                            command.Parameters.AddWithValue("@showalterquerymessage", this.ShowAlterTableMessage);
                            //--declare @showalterquerymessage bit 
                            command.Parameters.AddWithValue("@showretrievalquerymessage", this.ShowRetrievalMessage);
                            //--declare @showretrievalquerymessage bit 
                            command.Parameters.AddWithValue("@showimportantmessage", this.ShowImportantMessage);
                            //--declare @showimportantmessage bit


                            int result = command.ExecuteNonQuery();

                            OnScriptEndGeneration(new ScriptGeneratedEventArgs(ExecutionMessage));


                        }
                    //}
                        
                }
                catch (Exception scriptException)
                {
                    errored = true;
                    OnGenerationError(new ScriptGeneratedEventArgs(scriptException, ExecutionMessage));
                    //break;
                     
                }

                if (!errored)
                {
                    OnGenerationComplete(new ScriptGeneratedEventArgs(ExecutionMessage));
                }

                conn.Close();
            }
        }

        public event EventHandler<ScriptGeneratedEventArgs> ScriptBeginGeneration;
        public event EventHandler<ScriptGeneratedEventArgs> ScriptEndGeneration;
        public event EventHandler<ScriptGeneratedEventArgs> GenerationError;
        public event EventHandler<ScriptGeneratedEventArgs> GenerationComplete;

        private void OnScriptBeginGeneration(ScriptGeneratedEventArgs e)
        {
            if (ScriptBeginGeneration != null)
            {
                ScriptBeginGeneration(this, e);
            }
        }

        private void OnScriptEndGeneration(ScriptGeneratedEventArgs e)
        {
            if (ScriptEndGeneration != null)
            {
                ScriptEndGeneration(this, e);
            }
        }

        private void OnGenerationError(ScriptGeneratedEventArgs e)
        {
            if (GenerationError != null)
            {
                GenerationError(this, e);
            }
        }

        private void OnGenerationComplete(ScriptGeneratedEventArgs e)
        {
            if (GenerationComplete != null)
            {
                GenerationComplete(this, e);
            }
        }

        private static string GetControlSql(string fileControl)
        {
            if (!File.Exists(fileControl))
            {
                throw new Exception("Control file does not exists - " + fileControl);
            }

            return File.ReadAllText(fileControl);
        }

    }

    public class ScriptGeneratedEventArgs : EventArgs
    {

        public Exception GenerationException
        {
            get;
            private set;
        }

        public string GenerationMessage
        {
            get;
            private set;
        } 

        public ScriptGeneratedEventArgs(Exception generationException)
        {
            GenerationException = generationException;
        }

        public ScriptGeneratedEventArgs(Exception generationException,string message)
        {
            GenerationException = generationException;
            GenerationMessage = message;
        }

        public ScriptGeneratedEventArgs(string message)
        {
            GenerationMessage = message;
        }

        public ScriptGeneratedEventArgs()
        {

        }

    }
}
