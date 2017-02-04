using System;
using System.Data;
using System.Collections.Generic;


    public class CoverBLL
    {
        private CoverDAL _coverDAL;
        private CoverEL _coverEL;


   #region "Properties"        

        public CoverEL CoverEL
        {
            get { return _coverEL; }
            set { _coverEL = value; }
        }

 

        #endregion

   #region "Constructors"     

        public CoverBLL()
        {         
            _coverEL = new CoverEL();
         
        }


        public CoverBLL(CoverEL CoverEL)
        {
            _coverEL = CoverEL;
        }
        
        #endregion

        #region "Cover"

        public int SaveCover()
        {
            int id = 0;
            _coverDAL = new CoverDAL(_coverEL);

            id = _coverDAL.SaveCover();

            return id;
        }
    
       

        public DataTable GetAllCover()
        {
            DataTable dt = new DataTable();
            _coverDAL = new CoverDAL(_coverEL);
            dt = _coverDAL.GetCoverByID();

            return dt;
        }

        public CoverEL GetCoverByID()
        {
            _coverDAL = new CoverDAL(_coverEL);
            int CoverID = _coverEL.CoverID;

            _coverEL = new CoverEL();
            _coverEL.CoverID = CoverID;

            DataTable dt = _coverDAL.GetCoverByID();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                _coverEL.CoverID = Convert.ToInt32(row["CoverID"].ToString());               
                if (!row.IsNull("CoverTitle"))
                    _coverEL.CoverTitle = row["CoverTitle"].ToString();
                if (!row.IsNull("CoverPage"))
                    _coverEL.CoverPage = row["CoverPage"].ToString();           
                if (!row.IsNull("CreatedBy"))
                    _coverEL.CreatedBy = row["CreatedBy"].ToString();          
                if (!row.IsNull("ModifiedBy"))
                    _coverEL.ModifiedBy = row["ModifiedBy"].ToString();
                if (!row.IsNull("CreatedDate"))
                    _coverEL.CreatedDate = Convert.ToDateTime (row["CreatedDate"].ToString());
                if (!row.IsNull("ModifiedDate"))
                    _coverEL.ModifiedDate = Convert.ToDateTime (row["ModifiedDate"].ToString());
          

            }

            return _coverEL;
        }


        public bool Delete()
        {
            _coverDAL = new CoverDAL(_coverEL);

            return _coverDAL.Delete();
        }



        #endregion
    }

