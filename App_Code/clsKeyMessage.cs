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
    
    
    public class clskeyMessage {
        
        public static void Update(KeyMessage keyMessage) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from KeyMessage where 1=1", conn);
            conn.Open();
            System.Data.DataTable tbKeyMessage;
            tbKeyMessage = new System.Data.DataTable("KeyMessage");
            adapt.Fill(tbKeyMessage);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
            adapt.InsertCommand = mybuild.GetInsertCommand();
            if (tbKeyMessage.Rows.Count > 0) {
                // Edit methods
                System.Data.DataRow rowKeyMessage;
                rowKeyMessage = tbKeyMessage.Rows[0];
                rowKeyMessage["KeyID"] = keyMessage.KeyID;
                rowKeyMessage["KeyTitle"] = keyMessage.KeyTitle;
                rowKeyMessage["KeyPage"] = keyMessage.KeyPage;
                rowKeyMessage["KeyFileName"] = keyMessage.KeyFileName;
                rowKeyMessage["CreatedBy"] = keyMessage.CreatedBy;
                rowKeyMessage["CreatedDate"] = keyMessage.CreatedDate;
                rowKeyMessage["ModifiedBy"] = keyMessage.ModifiedBy;
                rowKeyMessage["ModifiedDate"] = keyMessage.ModifiedDate;
                rowKeyMessage["PresentationID"] = keyMessage.PresentationID;
                adapt.Update(tbKeyMessage);
            }
            else {
                System.Data.DataRow rowKeyMessage;
                rowKeyMessage = tbKeyMessage.NewRow();
                rowKeyMessage["KeyID"] = keyMessage.KeyID;
                rowKeyMessage["KeyTitle"] = keyMessage.KeyTitle;
                rowKeyMessage["KeyPage"] = keyMessage.KeyPage;
                rowKeyMessage["KeyFileName"] = keyMessage.KeyFileName;
                rowKeyMessage["CreatedBy"] = keyMessage.CreatedBy;
                rowKeyMessage["CreatedDate"] = keyMessage.CreatedDate;
                rowKeyMessage["ModifiedBy"] = keyMessage.ModifiedBy;
                rowKeyMessage["ModifiedDate"] = keyMessage.ModifiedDate;
                rowKeyMessage["PresentationID"] = keyMessage.PresentationID;
                tbKeyMessage.Rows.Add(rowKeyMessage);
                adapt.Update(tbKeyMessage);
            }
        }

        public static KeyMessage getKeyMessage(Int32 KeyMessageID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;

            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from KeyMessage where  KeyID = " + KeyMessageID + "", conn);


            conn.Open();
            System.Data.DataTable tbKeyMessage;
            tbKeyMessage = new System.Data.DataTable("KeyMessage");
            adapt.Fill(tbKeyMessage);
            KeyMessage KeyMessage;
            KeyMessage = new KeyMessage();
            if (tbKeyMessage.Rows.Count > 0) {
                System.Data.DataRow rowKeyMessage;
                rowKeyMessage = tbKeyMessage.Rows[0];
                KeyMessage.KeyID = System.Convert.ToInt32(rowKeyMessage["KeyID"]);
                KeyMessage.KeyTitle = System.Convert.ToString(rowKeyMessage["KeyTitle"]);
                KeyMessage.KeyPage = System.Convert.ToString(rowKeyMessage["KeyPage"]);
                KeyMessage.KeyFileName = System.Convert.ToString(rowKeyMessage["KeyFileName"]);
                KeyMessage.CreatedBy = System.Convert.ToString(rowKeyMessage["CreatedBy"]);
                KeyMessage.CreatedDate = System.Convert.ToDateTime(rowKeyMessage["CreatedDate"]);
                KeyMessage.ModifiedBy = System.Convert.ToString(rowKeyMessage["ModifiedBy"]);
                KeyMessage.ModifiedDate = System.Convert.ToDateTime(rowKeyMessage["ModifiedDate"]);
                KeyMessage.PresentationID = System.Convert.ToInt32(rowKeyMessage["PresentationID"]);
                return KeyMessage;
            }
            else {
                return null;
            }
        }
    }
