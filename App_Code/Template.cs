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
    
    
    public class Template {
        
        private object _TemplateID;
        
        private object _Title;
        
        private object _PageContent;
        
        private object _Ordinal;
        
        private object _PresentationID;
        
        public Template() {
        }
        
        public virtual object TemplateID {
            get {
                return this._TemplateID;
            }
            set {
                this._TemplateID = value;
            }
        }
        
        public virtual object Title {
            get {
                return this._Title;
            }
            set {
                this._Title = value;
            }
        }
        
        public virtual object PageContent {
            get {
                return this._PageContent;
            }
            set {
                this._PageContent = value;
            }
        }
        
        public virtual object Ordinal {
            get {
                return this._Ordinal;
            }
            set {
                this._Ordinal = value;
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
    
    public class TemplateCollection : System.Collections.CollectionBase {
        
        public virtual Template this[int index] {
            get {
                return ((Template)(List[index]));
            }
            set {
                List[index] = value;
            }
        }
        
        public virtual void Add(Template Item) {
            List.Add(Item);
        }
        
        public virtual void Remove(Template Item) {
            List.Remove(Item);
        }
    }

