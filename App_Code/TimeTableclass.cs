//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


    using System;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    
    public class TimeTableclass {
        
        private object _TimeTableID;
        
        private object _TimeTableTitle;
        
        private object _TimeTablePage;
        
        private object _TimeTableFileName;
        
        private object _CreatedBy;
        
        private object _CreatedDate;
        
        private object _ModifiedBy;
        
        private object _ModifiedDate;
        
        private object _PresentationID;
        
        private object _TRow;
        
        private object _TCol;

        public TimeTableclass()
        {
        }
        
        public virtual object TimeTableID {
            get {
                return this._TimeTableID;
            }
            set {
                this._TimeTableID = value;
            }
        }
        
        public virtual object TimeTableTitle {
            get {
                return this._TimeTableTitle;
            }
            set {
                this._TimeTableTitle = value;
            }
        }
        
        public virtual object TimeTablePage {
            get {
                return this._TimeTablePage;
            }
            set {
                this._TimeTablePage = value;
            }
        }
        
        public virtual object TimeTableFileName {
            get {
                return this._TimeTableFileName;
            }
            set {
                this._TimeTableFileName = value;
            }
        }
        
        public virtual object CreatedBy {
            get {
                return this._CreatedBy;
            }
            set {
                this._CreatedBy = value;
            }
        }
        
        public virtual object CreatedDate {
            get {
                return this._CreatedDate;
            }
            set {
                this._CreatedDate = value;
            }
        }
        
        public virtual object ModifiedBy {
            get {
                return this._ModifiedBy;
            }
            set {
                this._ModifiedBy = value;
            }
        }
        
        public virtual object ModifiedDate {
            get {
                return this._ModifiedDate;
            }
            set {
                this._ModifiedDate = value;
            }
        }
        
        public virtual object PresentationID {
            get {
                return this._PresentationID;
            }
            set {
                this._PresentationID = value;
            }
        }
        
        public virtual object TRow {
            get {
                return this._TRow;
            }
            set {
                this._TRow = value;
            }
        }
        
        public virtual object TCol {
            get {
                return this._TCol;
            }
            set {
                this._TCol = value;
            }
        }
    }
    
    public class TimeTableCollection : System.Collections.CollectionBase {

        public virtual TimeTableclass this[int index]
        {
            get {
                return ((TimeTableclass)(List[index]));
            }
            set {
                List[index] = value;
            }
        }

        public virtual void Add(TimeTableclass Item)
        {
            List.Add(Item);
        }

        public virtual void Remove(TimeTableclass Item)
        {
            List.Remove(Item);
        }
    }

