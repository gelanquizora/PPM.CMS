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
    
    
    public class TerribleUsers {
        
        private object _TUserID;
        
        private object _TUserName;
        
        private object _TPassword;
        
        private object _TFirstName;
        
        private object _TLastName;
        
        private object _TRoleID;
        
        public TerribleUsers() {
        }
        
        public virtual object TUserID {
            get {
                return this._TUserID;
            }
            set {
                this._TUserID = value;
            }
        }
        
        public virtual object TUserName {
            get {
                return this._TUserName;
            }
            set {
                this._TUserName = value;
            }
        }
        
        public virtual object TPassword {
            get {
                return this._TPassword;
            }
            set {
                this._TPassword = value;
            }
        }
        
        public virtual object TFirstName {
            get {
                return this._TFirstName;
            }
            set {
                this._TFirstName = value;
            }
        }
        
        public virtual object TLastName {
            get {
                return this._TLastName;
            }
            set {
                this._TLastName = value;
            }
        }
        
        public virtual object TRoleID {
            get {
                return this._TRoleID;
            }
            set {
                this._TRoleID = value;
            }
        }
    }
    
    public class TerribleUsersCollection : System.Collections.CollectionBase {
        
        public virtual TerribleUsers this[int index] {
            get {
                return ((TerribleUsers)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public virtual void Add(TerribleUsers Item) {
            List.Add(Item);
        }
        
        public virtual void Remove(TerribleUsers Item) {
            List.Remove(Item);
        }
    }

