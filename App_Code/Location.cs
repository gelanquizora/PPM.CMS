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
    
    
    public class Location {
        
        private object _LocationID;
        
        private object _ImageFile;
        
        private object _ImagePath;
        
        private object _VoiceOver;
        
        private object _Description;
        
        private object _Rank;
        
        private object _CreatedBy;
        
        private object _CreatedDate;
        
        private object _ModifiedBy;
        
        private object _ModifiedDate;
        
        private object _PresentationID;
        
        private object _Template;
        
        private object _ImageFile2;
        
        private object _ImagePath2;
        
        private object _ImageFile3;
        
        private object _ImagePath3;
        
        private object _TemplateID;
        
        private object _Title1;
        
        private object _Title2;
        
        public Location() {
        }
        
        public virtual object LocationID {
            get {
                return this._LocationID;
            }
            set {
                this._LocationID = value;
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
        
        public virtual object PresentationID {
            get {
                return this._PresentationID;
            }
            set {
                this._PresentationID = value;
            }
        }
        
        public virtual object Template {
            get {
                return this._Template;
            }
            set {
                this._Template = value;
            }
        }
        
        public virtual object ImageFile2 {
            get {
                return this._ImageFile2;
            }
            set {
                this._ImageFile2 = value;
            }
        }
        
        public virtual object ImagePath2 {
            get {
                return this._ImagePath2;
            }
            set {
                this._ImagePath2 = value;
            }
        }
        
        public virtual object ImageFile3 {
            get {
                return this._ImageFile3;
            }
            set {
                this._ImageFile3 = value;
            }
        }
        
        public virtual object ImagePath3 {
            get {
                return this._ImagePath3;
            }
            set {
                this._ImagePath3 = value;
            }
        }
        
        public virtual object TemplateID {
            get {
                return this._TemplateID;
            }
            set {
                this._TemplateID = value;
            }
        }
        
        public virtual object Title1 {
            get {
                return this._Title1;
            }
            set {
                this._Title1 = value;
            }
        }
        
        public virtual object Title2 {
            get {
                return this._Title2;
            }
            set {
                this._Title2 = value;
            }
        }
    }
    
    public class LocationCollection : System.Collections.CollectionBase {
        
        public virtual Location this[int index] {
            get {
                return ((Location)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public virtual void Add(Location Item) {
            List.Add(Item);
        }
        
        public virtual void Remove(Location Item) {
            List.Remove(Item);
        }
    }

