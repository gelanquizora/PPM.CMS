//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//namespace terrible1 {
    using System;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    
    public class Project {
        
        private object _ProjectID;
        
        private object _ProjectName;
        
        private object _Description;
        
        private object _ClientID;
        
        public Project() {
        }
        
        public virtual object ProjectID {
            get {
                return this._ProjectID;
            }
            set {
                this._ProjectID = value;
            }
        }
        
        public virtual object ProjectName {
            get {
                return this._ProjectName;
            }
            set {
                this._ProjectName = value;
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
        
        public virtual object ClientID {
            get {
                return this._ClientID;
            }
            set {
                this._ClientID = value;
            }
        }
    }
    
    public class ProjectCollection : System.Collections.CollectionBase {
        
        public virtual Project this[int index] {
            get {
                return ((Project)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public virtual void Add(Project Item) {
            List.Add(Item);
        }
        
        public virtual void Remove(Project Item) {
            List.Remove(Item);
        }
    }
//}
