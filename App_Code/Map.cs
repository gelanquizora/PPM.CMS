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
    
    
    public class Map {
        
        private object _MapID;
        
        private object _MapFile;
        
        private object _MapPath;
        
        private object _CreatedBy;
        
        private object _CreatedDate;
        
        private object _ModifiedBy;
        
        private object _ModifiedDate;
        
        private object _PresentationID;
        
        public Map() {
        }
        
        public virtual object MapID {
            get {
                return this._MapID;
            }
            set {
                this._MapID = value;
            }
        }
        
        public virtual object MapFile {
            get {
                return this._MapFile;
            }
            set {
                this._MapFile = value;
            }
        }
        
        public virtual object MapPath {
            get {
                return this._MapPath;
            }
            set {
                this._MapPath = value;
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
    }
    
    public class MapCollection : System.Collections.CollectionBase {
        
        public virtual Map this[int index] {
            get {
                return ((Map)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public virtual void Add(Map Item) {
            List.Add(Item);
        }
        
        public virtual void Remove(Map Item) {
            List.Remove(Item);
        }
    }
