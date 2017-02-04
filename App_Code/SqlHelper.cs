using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
 


    public class SqlHelper
    {
        #region Members

        private SqlConnection _sqlConn;
        private SqlTransaction _sqlTrans;
        private SqlCommand _sqlCommand;
        private DataSet _sqlDS;
        private DataTable _sqlDT;
        private bool _ongoingTransaction;




        public event EventHandler<ErrorEventArgs> ErrorOccuredEvent;
        private string _ConnectionString = ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString();
  

        #endregion

        #region Properties

        public SqlConnection Connection
        {
            get { return _sqlConn; }
        }

        public SqlTransaction Transaction
        {
            get { return _sqlTrans; }
        }

        public SqlCommand Command
        {
            get { return _sqlCommand; }
        }

        public DataSet DataSet
        {
            get { return _sqlDS; }
        }

        public DataTable DataTable
        {
            get { return _sqlDT; }
        }



        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        #endregion

        #region Transactions
        public void BeginTransaction()
        {
            try
            {
                if (_ongoingTransaction == true)
                    throw new Exception("There's a current ongoing transaction");
                _ongoingTransaction = true;
                CreateConnection();
                _sqlConn.Open();
                _sqlTrans = _sqlConn.BeginTransaction("SqlHelperTransaction");
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
        }
        public void CommitTransaction()
        {
            try
            {
                _sqlTrans.Commit();
                _ongoingTransaction = false;
                CloseConnection();
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _sqlTrans.Rollback();
                _ongoingTransaction = false;
                CloseConnection();
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
        }

        #endregion

        #region Execute commands

        public bool ExecuteNonQuery()
        {
            try
            {
                //Check if there is an SQLCommand existing before executing Data Reader. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null.");
                //Check if the connection state of the SQLConnection object is open, if not open it.
                if (_sqlConn.State == ConnectionState.Closed) _sqlConn.Open();
                _sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                return false;
            }
        }

        public bool ExecuteNonQuery(SqlCommand command)
        {
            try
            {

                //Check if there is an SQLCommand existing before executing Data Reader. If not, then return an exception.
                if (command == null) throw new NullReferenceException("Command Object is null.");
                //Check if the connection state of the SQLConnection object is open, if not open it.
                if (_sqlConn.State == ConnectionState.Closed) _sqlConn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                return false;
            }
        }

        public void ExecuteDataSet()
        {
            try
            {
                //Check if there is an SQLCommand existing before executing Data Reader. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null.");
                //Check if the connection state of the SQLConnection object is open, if not open it.
                if (_sqlConn.State == ConnectionState.Closed) _sqlConn.Open();
                //Close first the existing dataset if there is any 
                CloseDataSet();
                //fill the dataset with the dataadapter 
                SqlDataAdapter dataAdapter = new SqlDataAdapter(_sqlCommand);
                if (_sqlDS == null)
                {
                    _sqlDS = new DataSet();
                    _sqlDS.Locale = System.Globalization.CultureInfo.InvariantCulture;
                }
                dataAdapter.Fill(_sqlDS);
                dataAdapter.Dispose();
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
        }

        public void ExecuteDataTable()
        {
            try
            {
                //Check if there is an SQLCommand existing before executing Data Reader. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null.");
                //Check if the connection state of the SQLConnection object is open, if not open it.
                if (_sqlConn.State == ConnectionState.Closed) _sqlConn.Open();
                //Close first the existing dataset if there is any 
                CloseDataTable();
                //fill the dataset with the dataadapter 
                SqlDataAdapter dataAdapter = new SqlDataAdapter(_sqlCommand);
                if (_sqlDT == null)
                {
                    _sqlDT = new DataTable();
                    _sqlDT.Locale = System.Globalization.CultureInfo.InvariantCulture;
                }
                dataAdapter.Fill(_sqlDT);
                dataAdapter.Dispose();
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
        }

        public string ExecuteScalar()
        {
            try
            {
                //Check if there is an SQLCommand existing before executing Data Reader. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null");
                //Check if the connection state of the SQLConnection object is open, if not open it.
                if (_sqlConn.State == ConnectionState.Closed) _sqlConn.Open();

                string tmpValue = (string)_sqlCommand.ExecuteScalar().ToString();
                //Check returned value

                if (tmpValue == null)
                {
                    return "";
                }
                return tmpValue;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                return "";
            }
        }
        #endregion

        #region DB Connection

        public bool IsDBConnected()
        {
            bool connected;
            try
            {
                //ConnectionStringSettings connectionStringSettings = config.SQLConnection();
                //string str = connectionStringSettings.ConnectionString;
                string str = _ConnectionString;
                SqlConnection sqlConn = new SqlConnection(str);
                sqlConn.Open();
                sqlConn.Close();
                connected = true;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                connected = false;
            }
            return connected;
        }

        public bool CreateConnection()
        {
            try
            {
                //Check first if the connection is open, if yes, close it first before creating a new one 
                CloseConnection();
                if (_sqlConn == null)
                {
                    //Create the SQLConnection object for the class to use 
                    //ConnectionStringSettings cts = config.SQLConnection();
                    //string str = cts.ConnectionString;
                    string str = _ConnectionString;
                    _sqlConn = new SqlConnection(str);
                }
                return true;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                return false;
            }
        }
        #endregion

        #region Create objects

        public bool CreateTransaction()
        {
            try
            {
                if (_sqlConn == null) throw new NullReferenceException("Connection Object is null");
                if (_sqlConn.State == ConnectionState.Closed) _sqlConn.Open();
                _sqlTrans = _sqlConn.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                return false;
            }
        }

        public SqlCommand CreateCommand(string storedProcName, bool useTransaction)
        {
            try
            {
                //Check first if the command is existing, if yes, set it first to null before creating a new one 
                CloseCommand();
                //Check if there is an SQLConnection object existing for the command to use 
                if (_sqlConn == null) CreateConnection();
                //Create the SQLCommand object for the class to use 
                if (_sqlCommand == null || _ongoingTransaction == false)
                {
                    _sqlCommand = new SqlCommand();
                }
                _sqlCommand.Connection = _sqlConn;
                if (useTransaction) _sqlCommand.Transaction = _sqlTrans;

                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.CommandText = storedProcName;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
            return _sqlCommand;
        }
        public SqlCommand CreateCommand(string StoredProcName)
        {
            try
            {
                //Check first if the command is existing, if yes, set it first to null before creating a new one 
                ClearCommandParameters();
                CloseCommand();
                //Check if there is an SQLConnection object existing for the command to use 
                if (_sqlConn == null) CreateConnection();
                //Create the SQLCommand object for the class to use 
                if (_sqlCommand == null || _ongoingTransaction == false)
                {
                    _sqlCommand = new SqlCommand();
                }
                //
                if (_ongoingTransaction == true) _sqlCommand.Transaction = _sqlTrans;
                _sqlCommand.Connection = _sqlConn;
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.CommandText = StoredProcName;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
            return _sqlCommand;
        }
        public SqlCommand CreateCommand(string commandText, CommandType commandType)
        {
            try
            {
                //Check first if the command is existing, if yes, set it first to null before creating a new one 
                CloseCommand();
                //Check if there is an SQLConnection object existing for the command to use 
                if (_sqlConn == null) CreateConnection();
                //Create the SQLCommand object for the class to use 
                _sqlCommand = new SqlCommand();
                _sqlCommand.CommandType = commandType;

                _sqlCommand.Connection = _sqlConn;
                _sqlCommand.CommandText = commandText;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
            return _sqlCommand;
        }

        public SqlParameter AddParameter(string ParamName, DbType ParamDbType, ParameterDirection ParamDirection)
        {
            SqlParameter parameter = default(SqlParameter);
            try
            {
                //Check if there is an SQLCommand existing before adding the parameters. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null. Please execute CreateCommand first before adding parameters.");
                //Add the parameter to the SQLCommand object

                parameter = _sqlCommand.CreateParameter();
                parameter.ParameterName = ParamName;
                parameter.DbType = ParamDbType;
                parameter.Direction = ParamDirection;
                _sqlCommand.Parameters.Add(parameter);
                parameter.IsNullable = true;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
            return parameter;
        }

        public SqlParameter AddParameter(string ParamName, SqlDbType ParamDbType, ParameterDirection ParamDirection)
        {
            SqlParameter parameter = default(SqlParameter);
            try
            {
                //Check if there is an SQLCommand existing before adding the parameters. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null. Please execute CreateCommand first before adding parameters.");
                //Add the parameter to the SQLCommand object

                parameter = _sqlCommand.CreateParameter();
                parameter.ParameterName = ParamName;
                parameter.SqlDbType = ParamDbType;
                parameter.Direction = ParamDirection;
                _sqlCommand.Parameters.Add(parameter);
                parameter.IsNullable = true;

            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
            return parameter;
        }

        public SqlParameter AddParameter(string ParamName, object ParamValue, DbType ParamDbType, ParameterDirection ParamDirection)
        {
            SqlParameter parameter = default(SqlParameter);
            try
            {
                //Check if there is an SQLCommand existing before adding the parameters. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null. Please execute CreateCommand first before adding parameters.");
                //Add the parameter to the SQLCommand object

                parameter = _sqlCommand.CreateParameter();
                parameter.ParameterName = ParamName;
                parameter.Value = ParamValue;
                parameter.DbType = ParamDbType;
                parameter.Direction = ParamDirection;
                _sqlCommand.Parameters.Add(parameter);
                parameter.IsNullable = true;


                if (ParamValue == null)
                    parameter.Value = DBNull.Value;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
            return parameter;
        }

        public SqlParameter AddParameter(string ParamName, object ParamValue, SqlDbType ParamDbType, ParameterDirection ParamDirection)
        {
            SqlParameter parameter = default(SqlParameter);
            try
            {
                //Check if there is an SQLCommand existing before adding the parameters. If not, then return an exception.
                if (_sqlCommand == null) throw new NullReferenceException("Command Object is null. Please execute CreateCommand first before adding parameters.");
                //Add the parameter to the SQLCommand object

                parameter = _sqlCommand.CreateParameter();
                parameter.ParameterName = ParamName;
                parameter.Value = ParamValue;
                parameter.SqlDbType = ParamDbType;
                parameter.Direction = ParamDirection;
                _sqlCommand.Parameters.Add(parameter);

                if (ParamValue == null)
                    parameter.Value = DBNull.Value;
            }
            catch (Exception ex)
            {
               
                OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
            }
            return parameter;
        }

        #endregion

        #region Clear Collections
        public void ClearCommandParameters()
        {
            if (_sqlCommand != null)
            {
                _sqlCommand.Parameters.Clear();
            }
        }
        #endregion

        #region Close objects

        public void CloseConnection()
        {
            if (_ongoingTransaction == false && (_sqlConn != null))
            {
                try
                {
                    //Check if connection is already closed, if not, then close it
                    if (_sqlConn.State != ConnectionState.Closed) _sqlConn.Close();
                    //Dispose the connection object and set it to null to release resources used by the object 
                    _sqlConn.Close();
                    _sqlConn.Dispose();
                    _sqlConn = null;
                }
                catch (Exception ex)
                {
                   
                    OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                }
            }
        }

        private void CloseCommand()
        {
            if ((_ongoingTransaction == false) && (_sqlCommand != null))
            {
                try
                {
                    //Dispose the command object and set it to null to release resources used by the object
                    _sqlCommand.Dispose();
                    _sqlCommand = null;
                }
                catch (Exception ex)
                {
                   
                    OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                }
            }
        }

        private void CloseDataSet()
        {
            if ((_sqlDS != null))
            {
                try
                {
                    // Dispose object to release resources used
                    _sqlDS.Dispose();
                    _sqlDS = null;
                }
                catch (Exception ex)
                {
                   
                    OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                }
            }
        }

        private void CloseDataTable()
        {
            if ((_sqlDT != null))
            {
                try
                {
                    // Dispose object to release resources used
                    _sqlDT.Dispose();
                    _sqlDT = null;
                }
                catch (Exception ex)
                {
                   
                    OnRaiseErrorOccuredEvent(this, new ErrorEventArgs(ex));
                }
            }
        }

        #endregion

        #region Custom Event

        protected virtual void OnRaiseErrorOccuredEvent(object sender, ErrorEventArgs e)
        {
            EventHandler<ErrorEventArgs> handler = ErrorOccuredEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

    }
