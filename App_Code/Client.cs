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
    
    
    public class Client {
        
        private object _ClientID;
        
        private object _ClientName;
        
        private object _Description;
        
        private object _CompanyID;
        
        public Client() {
        }
        
        public virtual object ClientID {
            get {
                return this._ClientID;
            }
            set {
                this._ClientID = value;
            }
        }
        
        public virtual object ClientName {
            get {
                return this._ClientName;
            }
            set {
                this._ClientName = value;
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
        
        public virtual object CompanyID {
            get {
                return this._CompanyID;
            }
            set {
                this._CompanyID = value;
            }
        }
    }
    
    public class ClientCollection : System.Collections.CollectionBase {
        
        public virtual Client this[int index] {
            get {
                return ((Client)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public virtual void Add(Client Item) {
            List.Add(Item);
        }
        
        public virtual void Remove(Client Item) {
            List.Remove(Item);
        }
    }
//}
