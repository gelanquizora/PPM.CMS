using System;
using System.Data;


    public class UsersBLL
    {

        
          private UsersDAL _usersDAL;
          private UsersEL _usersEL;


        #region "Properties"
        public UsersEL UsersEL
        {
            get { return  _usersEL; }
            set { _usersEL = value; }
        }
        #endregion

        #region "Constructors"

        public UsersBLL (UsersEL menuEL)
        {
            _usersEL = menuEL;
        }
        public UsersBLL()
        {
            _usersEL = new UsersEL();
            
        }




        #endregion
        public UsersEL GetUserByID()
        {
            _usersDAL = new UsersDAL(_usersEL);
            int ID = _usersEL.UserID;

            _usersEL = new UsersEL();
            _usersEL.UserID = ID;

            DataTable dt = _usersDAL.GetUserByID();
        
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                _usersEL.UserID = Convert.ToInt32(row["UserID"].ToString());
                if (!row.IsNull("UserName"))
                    _usersEL.UserName = row["UserName"].ToString();
                if (!row.IsNull("Password"))
                    _usersEL.Password = row["Password"].ToString();
                if (!row.IsNull("FirstName"))
                    _usersEL.FirstName = row["FirstName"].ToString();
                if (!row.IsNull("LastName"))
                    _usersEL.LastName = row["LastName"].ToString();       
                if (!row.IsNull("RoleID"))
                    _usersEL.RoleID = Convert.ToInt32(row["RoleID"].ToString());             
                if (!row.IsNull("CompanyID"))
                    _usersEL.CompanyID = Convert.ToInt32(row["CompanyID"].ToString());


            }

            return _usersEL;
        }


        //public UsersEL GetRoleByUserName(string username)
        //{


        //    DataTable dt = _usersDAL.GetRoleByUserName(username);

        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow row = dt.Rows[0];
              
        //        //if (!row.IsNull("FirstName"))
        //        //    _usersEL.FirstName = row["FirstName"].ToString();
        //        //if (!row.IsNull("LastName"))
        //        //    _usersEL.LastName = row["LastName"].ToString();
        //        if (!row.IsNull("RoleID"))
        //            _usersEL.RoleID = Convert.ToInt32(row["RoleID"].ToString());
        //        //if (!row.IsNull("CompanyID"))
        //        //    _usersEL.CompanyID = Convert.ToInt32(row["CompanyID"].ToString());


        //    }

        //    return _usersEL;
        //}
        //public UsersEL GetRoleByUserName()
        //{


        //    DataTable dt = _usersDAL.GetRoleByUserName(string username);

        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow row = dt.Rows[0];
                
        
        //        if (!row.IsNull("RoleID"))
        //            _usersEL.RoleID = Convert.ToInt32(row["RoleID"].ToString());
                


        //    }

        //    return _usersEL;
        //}
      
        public int UpdateUser()
        {
            int id = 0;
            _usersDAL = new UsersDAL(_usersEL);

            id = _usersDAL.UpdateUser();

            return id;
        }

    }

