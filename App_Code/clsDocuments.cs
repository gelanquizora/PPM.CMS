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
    using System.Configuration;
    using System.Linq;
    
    
    public class clsdocuments {
        public static void Insert(Documents documents)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Documents", conn);
            conn.Open();
            System.Data.DataTable tbDocuments;
            tbDocuments = new System.Data.DataTable("Documents");
            adapt.Fill(tbDocuments);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
        
            adapt.InsertCommand = mybuild.GetInsertCommand();

            System.Data.DataRow rowDocuments;
            rowDocuments = tbDocuments.NewRow();


            rowDocuments["DocumentTitle"] = documents.DocumentTitle;
            rowDocuments["DocumentPath"] = documents.DocumentPath;
            rowDocuments["CreatedBy"] = documents.CreatedBy;
            rowDocuments["CreatedDate"] = documents.CreatedDate;
            rowDocuments["ModifiedBy"] = documents.ModifiedBy;
            rowDocuments["ModifiedDate"] = documents.ModifiedDate;
            adapt.Update(tbDocuments);

        }
        public static void Update(Documents documents) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;           
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Documents where  DocumentID = " + documents.DocumentID + "", conn);
            conn.Open();
            System.Data.DataTable tbDocuments;
            tbDocuments = new System.Data.DataTable("Documents");
            adapt.Fill(tbDocuments);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
            adapt.InsertCommand = mybuild.GetInsertCommand();
     
                // Edit methods
                System.Data.DataRow rowDocuments;
                rowDocuments = tbDocuments.Rows[0];
                rowDocuments["DocumentID"] = documents.DocumentID;
                rowDocuments["DocumentTitle"] = documents.DocumentTitle;
                rowDocuments["DocumentPath"] = documents.DocumentPath;
                rowDocuments["CreatedBy"] = documents.CreatedBy;
                rowDocuments["CreatedDate"] = documents.CreatedDate;
                rowDocuments["ModifiedBy"] = documents.ModifiedBy;
                rowDocuments["ModifiedDate"] = documents.ModifiedDate;
                adapt.Update(tbDocuments);
       
        }

        public static Documents getDocuments(Int32 DocumentID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;         
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Documents where  DocumentID = " + DocumentID + "", conn);
            conn.Open();
            System.Data.DataTable tbDocuments;
            tbDocuments = new System.Data.DataTable("Documents");
            adapt.Fill(tbDocuments);
            Documents Documents;
            Documents = new Documents();
            if (tbDocuments.Rows.Count > 0) {
                System.Data.DataRow rowDocuments;
                rowDocuments = tbDocuments.Rows[0];
                Documents.DocumentID = System.Convert.ToInt32(rowDocuments["DocumentID"]);
                Documents.DocumentTitle = System.Convert.ToString(rowDocuments["DocumentTitle"]);
                Documents.DocumentPath = System.Convert.ToString(rowDocuments["DocumentPath"]);
                Documents.CreatedBy = System.Convert.ToString(rowDocuments["CreatedBy"]);
                Documents.CreatedDate = System.Convert.ToDateTime(rowDocuments["CreatedDate"]);
                Documents.ModifiedBy = System.Convert.ToString(rowDocuments["ModifiedBy"]);
                Documents.ModifiedDate = System.Convert.ToDateTime(rowDocuments["ModifiedDate"]);
                return Documents;
            }
            else {
                return null;
            }
        }
    }

