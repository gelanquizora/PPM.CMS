using System;
using System.Data;


    public class UsersDAL
    {
        private UsersEL _usersEL;
        private SqlHelper _helper;

        

        #region "Properties"
        public UsersEL UsersEL
        {
            get { return _usersEL; }
            set { _usersEL = value; }
        }
        #endregion

        #region "Constructors"

        public UsersDAL(UsersEL usersEL)
        {
            _usersEL = usersEL;
        }
        public UsersDAL()
        {
            _usersEL = new UsersEL();
        }
        #endregion


        public int UpdateUser()
        {
            int id = 0;
            bool isSaved = false;
            _helper = new SqlHelper();

            try
            {
                if (_helper.CreateConnection())
                {
                    _helper.BeginTransaction();
                    _helper.CreateCommand("sp_UpdateUsers", true);
                    _helper.AddParameter("@UserID", _usersEL.UserID, DbType.Int32, ParameterDirection.InputOutput);
                    _helper.AddParameter("@UserName", _usersEL.UserName, DbType.String, ParameterDirection.Input);
                    _helper.AddParameter("@Password", _usersEL.Password, DbType.String, ParameterDirection.Input);
                    _helper.AddParameter("@FirstName", _usersEL.FirstName, DbType.String, ParameterDirection.Input);
                    _helper.AddParameter("@LastName", _usersEL.LastName, DbType.String, ParameterDirection.Input);
                    _helper.AddParameter("@RoleID", _usersEL.RoleID, DbType.Int32, ParameterDirection.Input);
                    _helper.AddParameter("@CompanyID", _usersEL.CompanyID, DbType.Int32, ParameterDirection.Input);
                    



                    isSaved = _helper.ExecuteNonQuery();

                    id = Convert.ToInt32(_helper.Command.Parameters["@UserID"].Value);
                    _helper.ClearCommandParameters();

                    if (isSaved)
                    {
                        _helper.CommitTransaction();
                    }

                }
            }
            catch (Exception ex)
            {
                _helper.RollbackTransaction();
              
            }
            finally
            {
                _helper.CloseConnection();

            }

            return id;
        }

      
        public DataTable GetUserByID()
        {
            _helper = new SqlHelper();

            DataTable dt = new DataTable();

            
                _helper.CloseConnection();
                _helper.CreateCommand("sp_SelectUserByUserID", false);
                _helper.AddParameter("@UserID", _usersEL.UserID, DbType.Int32, ParameterDirection.Input);
                _helper.ExecuteDataTable();
                dt = _helper.DataTable;
           
                _helper.CloseConnection();

          
            return dt;
        }


      

    }



