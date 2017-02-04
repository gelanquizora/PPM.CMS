using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class UsersEL
    {
        private int _userID = 0;
        private string _userName = null;
        private string _password = "";
        private string _firstName = null;
        private string _lastName = "";
        private int _roleID = 0;
        private int _companyID = 0;
       


        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

    }

