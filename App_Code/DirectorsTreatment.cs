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
    
    
    public class DirectorsTreatment {
        
        private object _DTID;
        
        private object _ImageFile;
        
        private object _ImagePath;
        
        private object _VoiceOver;
        
        private object _Description;
        
        private object _Rank;
        
        private object _CreatedBy;
        
        private object _CreatedDate;
        
        private object _ModifiedBy;
        
        private object _ModifiedDate;
        
        public DirectorsTreatment() {
        }
        
        public virtual object DTID {
            get {
                return this._DTID;
            }
            set {
                this._DTID = value;
            }
        }
        
        public virtual object ImageFile {
            get {
                return this._ImageFile;
            }
            set {
                this._ImageFile = value;
            }
        }
        
        public virtual object ImagePath {
            get {
                return this._ImagePath;
            }
            set {
                this._ImagePath = value;
            }
        }
        
        public virtual object VoiceOver {
            get {
                return this._VoiceOver;
            }
            set {
                this._VoiceOver = value;
            }
        }
        
        public virtual object Description {
            get {
                return this._Description;
            }
            set {
                this._Description = value;
            }
        }
        
        public virtual object Rank {
            get {
                return this._Rank;
            }
            set {
                this._Rank = value;
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
    }
    
    public class DirectorsTreatmentCollection : System.Collections.CollectionBase {
        
        public virtual DirectorsTreatment this[int index] {
            get {
                return ((DirectorsTreatment)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public virtual void Add(DirectorsTreatment Item) {
            List.Add(Item);
        }
        
        public virtual void Remove(DirectorsTreatment Item) {
            List.Remove(Item);
        }


    }

