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
    
    
    public class clsdirectorsBoard {
        
        public static void Update(DirectorsBoard directorsBoard) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from DirectorsBoard where 1=1", conn);
            conn.Open();
            System.Data.DataTable tbDirectorsBoard;
            tbDirectorsBoard = new System.Data.DataTable("DirectorsBoard");
            adapt.Fill(tbDirectorsBoard);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
            adapt.InsertCommand = mybuild.GetInsertCommand();
            if (tbDirectorsBoard.Rows.Count > 0) {
                // Edit methods
                System.Data.DataRow rowDirectorsBoard;
                rowDirectorsBoard = tbDirectorsBoard.Rows[0];
                rowDirectorsBoard["BoardID"] = directorsBoard.BoardID;
                rowDirectorsBoard["BoardTitle"] = directorsBoard.BoardTitle;
                rowDirectorsBoard["BoardPage"] = directorsBoard.BoardPage;
                rowDirectorsBoard["BoardFileName"] = directorsBoard.BoardFileName;
                rowDirectorsBoard["BoardDescription"] = directorsBoard.BoardDescription;
                rowDirectorsBoard["CreatedBy"] = directorsBoard.CreatedBy;
                rowDirectorsBoard["CreatedDate"] = directorsBoard.CreatedDate;
                rowDirectorsBoard["ModifiedBy"] = directorsBoard.ModifiedBy;
                rowDirectorsBoard["ModifiedDate"] = directorsBoard.ModifiedDate;
                rowDirectorsBoard["PresentationID"] = directorsBoard.PresentationID;
                adapt.Update(tbDirectorsBoard);
            }
            else {
                System.Data.DataRow rowDirectorsBoard;
                rowDirectorsBoard = tbDirectorsBoard.NewRow();
                rowDirectorsBoard["BoardID"] = directorsBoard.BoardID;
                rowDirectorsBoard["BoardTitle"] = directorsBoard.BoardTitle;
                rowDirectorsBoard["BoardPage"] = directorsBoard.BoardPage;
                rowDirectorsBoard["BoardFileName"] = directorsBoard.BoardFileName;
                rowDirectorsBoard["BoardDescription"] = directorsBoard.BoardDescription;
                rowDirectorsBoard["CreatedBy"] = directorsBoard.CreatedBy;
                rowDirectorsBoard["CreatedDate"] = directorsBoard.CreatedDate;
                rowDirectorsBoard["ModifiedBy"] = directorsBoard.ModifiedBy;
                rowDirectorsBoard["ModifiedDate"] = directorsBoard.ModifiedDate;
                rowDirectorsBoard["PresentationID"] = directorsBoard.PresentationID;
                tbDirectorsBoard.Rows.Add(rowDirectorsBoard);
                adapt.Update(tbDirectorsBoard);
            }
        }

        public static DirectorsBoard getDirectorsBoard(Int32 BoardID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt; 


            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from DirectorsBoard where  BoardID = " + BoardID + "", conn);

            conn.Open();
            System.Data.DataTable tbDirectorsBoard;
            tbDirectorsBoard = new System.Data.DataTable("DirectorsBoard");
            adapt.Fill(tbDirectorsBoard);
            DirectorsBoard DirectorsBoard;
            DirectorsBoard = new DirectorsBoard();
            if (tbDirectorsBoard.Rows.Count > 0) {
                System.Data.DataRow rowDirectorsBoard;
                rowDirectorsBoard = tbDirectorsBoard.Rows[0];
                DirectorsBoard.BoardID = System.Convert.ToInt32(rowDirectorsBoard["BoardID"]);
                DirectorsBoard.BoardTitle = System.Convert.ToString(rowDirectorsBoard["BoardTitle"]);
                DirectorsBoard.BoardPage = System.Convert.ToString(rowDirectorsBoard["BoardPage"]);
                DirectorsBoard.BoardFileName = System.Convert.ToString(rowDirectorsBoard["BoardFileName"]);
                DirectorsBoard.BoardDescription = System.Convert.ToString(rowDirectorsBoard["BoardDescription"]);
                DirectorsBoard.CreatedBy = System.Convert.ToString(rowDirectorsBoard["CreatedBy"]);
                DirectorsBoard.CreatedDate = System.Convert.ToDateTime(rowDirectorsBoard["CreatedDate"]);
                DirectorsBoard.ModifiedBy = System.Convert.ToString(rowDirectorsBoard["ModifiedBy"]);
                DirectorsBoard.ModifiedDate = System.Convert.ToDateTime(rowDirectorsBoard["ModifiedDate"]);
                DirectorsBoard.PresentationID = System.Convert.ToInt32(rowDirectorsBoard["PresentationID"]);
                return DirectorsBoard;
            }
            else {
                return null;
            }
        }
    }

