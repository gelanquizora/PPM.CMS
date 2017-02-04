using System;
using System.Data;


    public class CoverDAL
    {
        private CoverEL _coverEL;
        private SqlHelper _helper;

        #region "Properties"
        public CoverEL CoverEL
        {
            get { return _coverEL; }
            set { _coverEL = value; }
        }
        #endregion

        #region "Constructors"

        public CoverDAL(CoverEL CoverEL)
        {
            _coverEL = CoverEL;
        }
        public CoverDAL()
        {
            _coverEL = new CoverEL();
        }


        #endregion    

        public int SaveCover()
        {
            int id = 0;
            bool isSaved = false;
            _helper = new SqlHelper();

            try
            {
                if (_helper.CreateConnection())
                {
                    _helper.BeginTransaction();
                    _helper.CreateCommand("sp_InsertCover", true);                    
                    _helper.AddParameter("@CoverTitle", _coverEL.CoverTitle , DbType.String, ParameterDirection.Input);
                    _helper.AddParameter("@CoverPage", _coverEL.CoverPage, DbType.String, ParameterDirection.Input);                   
                    _helper.AddParameter("@CreatedBy", _coverEL.CreatedBy, DbType.String, ParameterDirection.Input);                  
                    _helper.AddParameter("@ModifiedBy", _coverEL.ModifiedBy, DbType.String, ParameterDirection.Input);
                   
                    

                    isSaved = _helper.ExecuteNonQuery();

               
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

        public DataTable GetCoverByID()
        {
            _helper = new SqlHelper();

            DataTable dt = new DataTable();

            try
            {
                _helper.CloseConnection();
                _helper.CreateCommand("sp_SelectCoverByID", false);
                _helper.AddParameter("@CoverID", _coverEL.CoverID, DbType.Int32, ParameterDirection.Input);
                _helper.ExecuteDataTable();
                dt = _helper.DataTable;
            }
            catch (Exception ex)
            {
    
            }
            finally
            {
                _helper.CloseConnection();

            }
            return dt;
        }

    
        
        public bool Delete()
        {

            bool isSaved = false;

            _helper = new SqlHelper();
            try
            {

                if (_helper.CreateConnection())
                {
                    _helper.BeginTransaction();
                    _helper.CreateCommand("sp_DeleteCover", true);

                    _helper.AddParameter("@CoverID", _coverEL.CoverID, DbType.Int32, ParameterDirection.Input);

                    isSaved = _helper.ExecuteNonQuery();

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

            return isSaved;
        }


    }

