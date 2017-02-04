using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class CoverEL
    {
        private int _coverID = 0;
        private string _coverTitle = "";  
        private string _coverPage = "";      
        private string _createdBy = "";      
        private string _modifiedBy = "";
        private DateTime _createdDate = DateTime.MinValue;
        private DateTime _modifiedDate = DateTime.MinValue;
     
      

        public int CoverID
        {
            get { return _coverID; }
            set { _coverID = value; }
        }

        public string CoverTitle
        {
            get { return _coverTitle; }
            set { _coverTitle = value; }
        }
        public string CoverPage
        {
            get { return _coverPage; }
            set { _coverPage = value; }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public DateTime  ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

    }

