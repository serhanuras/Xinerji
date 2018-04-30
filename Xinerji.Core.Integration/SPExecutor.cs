using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Xinerji.Integration
{
    public class SPExecutor : IDisposable
    {

        SqlConnection _dbConn;
        SProcList _sprocs;
        SqlParameterCollection _lastParams;

  
        //string connStr = "Data Source=DESKTOP-VE67ELT\\SQLEXPRESS;Initial Catalog=PepParaDb;User ID=pepappuser;Password=147852";
        //string connStr = "Data Source=10.21.0.20;Initial Catalog=PepParaDb;User ID=pepappuser;Password=PepparaPassword_";
        //string connStr = "Data Source=MSSQL\\SQLEXPRESS;Initial Catalog=PepParaDb;User ID=pepappuser;Password=PepparaPassword_";

        private static string connStr = "";

        public SPExecutor()
        {
            var section = Xinerji.Configuration.ConfigurationManager.GetDatabaseSetting();

            if (SPExecutor.connStr == "")
            {
                connStr = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                section.Server,
                section.Catalog,
                section.UserId,
                section.GetDecryptedPassword());
            }

            _dbConn = new SqlConnection(connStr);
            _sprocs = new SProcList(this);
        }

        void Open()
        { if (_dbConn.State != ConnectionState.Open) _dbConn.Open(); }
        void Close()
        { if (_dbConn.State == ConnectionState.Open) _dbConn.Close(); }

        SqlCommand NewSProc(string procName)
        {
            SqlCommand cmd = new SqlCommand(procName, _dbConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

#if EmulateDeriveParameters   
                              //own DeriveParameters
            MySqlCmdBuilder.DeriveParameters(cmd);
#else
            Open();
            SqlCommandBuilder.DeriveParameters(cmd);
            foreach (SqlParameter prm in cmd.Parameters)
                if (prm.Direction == ParameterDirection.InputOutput)
                    prm.Direction = ParameterDirection.Output;
#endif

            return cmd;
        }

        SqlCommand FillParams(string procName,
                                bool makeXSSControl,
                                params object[] vals)
        {
            SqlCommand cmd = _sprocs[procName];

            int i = 0;
            int y = 0;
            foreach (SqlParameter prm in cmd.Parameters)
            {
                if (prm.Direction == ParameterDirection.Input
                 || prm.Direction == ParameterDirection.InputOutput)
                {
                    y = i;
                    if (prm.DbType == DbType.Boolean)
                    {
                        if (vals[y].ToString() == "1")
                            vals[y] = (object)"true";
                        else
                            vals[y] = (object)"false";
                    }

                    if (vals[y] == null)
                        vals[y] = "";

                    if (prm.DbType == DbType.DateTime)
                    {
                        //if (vals[y].ToString() == "1.01.0001 00:00:00")
                        if (((DateTime)vals[y]).Year == 1)
                        {
                            vals[y] = new DateTime(1900, 1, 1);
                        }
                    }

                    if (makeXSSControl == true &&
                        (prm.DbType == DbType.AnsiString || prm.DbType == DbType.String || prm.DbType == DbType.StringFixedLength))
                    {
                        vals[y] = excludeXSSCharacters(vals[y].ToString());
                    }


                    prm.Value = vals[y];

                    i++;
                }
            }
            Debug.Assert(i == (vals == null ? 0 : vals.Length));

            _lastParams = cmd.Parameters;
            return cmd;
        }


        public DataRowCollection QueryRows(string strQry)
        {
            DataTable dt = new DataTable();
            new SqlDataAdapter(strQry, _dbConn).Fill(dt);
            return dt.Rows;
        }

        public bool ExecSProc(string procName,
                              params object[] vals)
        {
            return ExecSProc(procName,
                             true,
                             vals);
        }

        public DataView ExecSProcDV(string procName,
                                     params object[] vals)
        {
            return ExecSProcDV(procName, true, vals);
        }

        public DataTable ExecSProcDT(string procName,
                                     params object[] vals)
        {
            return ExecSProcDT(procName, true, vals);
        }

        public DataSet ExecSProcDS(string procName,
                                     params object[] vals)
        {
            return ExecSProcDS(procName, true, vals);
        }


        public bool ExecSProc(string procName,
                             bool makeXSSValidation,
                             params object[] vals)
        {
            int retVal = -1;

            try
            {
                Open();
                FillParams(procName, makeXSSValidation, vals).ExecuteNonQuery();
                retVal = (int)_lastParams[0].Value;
            }

            catch (System.Exception e)
            {
                System.Console.Write(e.Message);
            }
            finally
            {
                Close();
            }

            if (retVal == -1)
                return false;
            else
                return true;
        }

        public DataView ExecSProcDV(string procName,
                                    bool makeXSSValidation,
                                     params object[] vals)
        {
            DataSet ds = new DataSet();

            try
            {
                Open();
                new SqlDataAdapter(
                      FillParams(procName, makeXSSValidation, vals)).Fill(ds);
            }
            finally
            {
                Close();
            }
            return ds.Tables[0].DefaultView;
        }

        public DataTable ExecSProcDT(string procName,
                                 bool makeXSSValidation,
                                     params object[] vals)
        {
            DataSet ds = new DataSet();

            try
            {
                Open();
                new SqlDataAdapter(
                      FillParams(procName, makeXSSValidation, vals)).Fill(ds);
            }
            finally
            {
                Close();
            }
            return ds.Tables[0];
        }

        public DataSet ExecSProcDS(string procName,
                                    bool makeXSSValidation,
                                     params object[] vals)
        {
            DataSet ds = new DataSet();

            try
            {
                Open();
                new SqlDataAdapter(
                      FillParams(procName, makeXSSValidation, vals)).Fill(ds);
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public object Param(string param)
        {
            return _lastParams[param].Value;
        }

        public void Dispose()
        {

        }

        class SProcList : DictionaryBase
        {
            SPExecutor _db;
            public SProcList(SPExecutor db)
            { _db = db; }

            public SqlCommand this[string name]
            {
                get
                {      //read-only, "install on demand"
                    if (!Dictionary.Contains(name))
                        Dictionary.Add(name, _db.NewSProc(name));
                    return (SqlCommand)Dictionary[name];
                }
            }
        }


        string excludeXSSCharacters(string input)
        {
            input = Regex.Replace(input, "<.*?>", String.Empty);
            input = Regex.Replace(input, ".js", " ", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "script", " ", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "SCRIPT", " ", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "https://", " ", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, "http://", " ", RegexOptions.IgnoreCase);
            input = input.Replace("\\u", " ");
            input = input.Replace("\\U", " ");

            return input;
        }
    }
}
