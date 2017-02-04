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
    
    
    public class clsdirectorsTreatment {
        public static void Insert(DirectorsTreatment directorsTreatment)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;

            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from DirectorsTreatment", conn);
            conn.Open();
            System.Data.DataTable tbDirectorsTreatment;
            tbDirectorsTreatment = new System.Data.DataTable("DirectorsTreatment");
            adapt.Fill(tbDirectorsTreatment);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);      

            adapt.InsertCommand = mybuild.GetInsertCommand();


   
            System.Data.DataRow rowDirectorsTreatment;
            rowDirectorsTreatment = tbDirectorsTreatment.NewRow();
           
            rowDirectorsTreatment["ImageFile"] = directorsTreatment.ImageFile;
            rowDirectorsTreatment["ImagePath"] = directorsTreatment.ImagePath;
            rowDirectorsTreatment["VoiceOver"] = directorsTreatment.VoiceOver;
            rowDirectorsTreatment["Description"] = directorsTreatment.Description;
            rowDirectorsTreatment["Rank"] = directorsTreatment.Rank;
            rowDirectorsTreatment["CreatedBy"] = directorsTreatment.CreatedBy;
            rowDirectorsTreatment["CreatedDate"] = directorsTreatment.CreatedDate;
            rowDirectorsTreatment["ModifiedBy"] = directorsTreatment.ModifiedBy;
            rowDirectorsTreatment["ModifiedDate"] = directorsTreatment.ModifiedDate;
            adapt.Update(tbDirectorsTreatment);

        }
        public static void Update(DirectorsTreatment directorsTreatment) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
          
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from DirectorsTreatment where  DTID = " + directorsTreatment.DTID + "", conn);
            conn.Open();
            System.Data.DataTable tbDirectorsTreatment;
            tbDirectorsTreatment = new System.Data.DataTable("DirectorsTreatment");
            adapt.Fill(tbDirectorsTreatment);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
        
       
                // Edit methods
                System.Data.DataRow rowDirectorsTreatment;
                rowDirectorsTreatment = tbDirectorsTreatment.Rows[0];
                rowDirectorsTreatment["DTID"] = directorsTreatment.DTID;
                //rowDirectorsTreatment["ImageFile"] = directorsTreatment.ImageFile;
                //rowDirectorsTreatment["ImagePath"] = directorsTreatment.ImagePath;
                rowDirectorsTreatment["VoiceOver"] = directorsTreatment.VoiceOver;
                rowDirectorsTreatment["Description"] = directorsTreatment.Description;
                rowDirectorsTreatment["Rank"] = directorsTreatment.Rank;
                //rowDirectorsTreatment["CreatedBy"] = directorsTreatment.CreatedBy;
                //rowDirectorsTreatment["CreatedDate"] = directorsTreatment.CreatedDate;
                rowDirectorsTreatment["ModifiedBy"] = directorsTreatment.ModifiedBy;
                rowDirectorsTreatment["ModifiedDate"] = directorsTreatment.ModifiedDate;
                adapt.Update(tbDirectorsTreatment);
           
        }

        public static DirectorsTreatment getDirectorsTreatment(Int32 DTID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;           
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from DirectorsTreatment where  DTID = " + DTID + "", conn);
            conn.Open();
            System.Data.DataTable tbDirectorsTreatment;
            tbDirectorsTreatment = new System.Data.DataTable("DirectorsTreatment");
            adapt.Fill(tbDirectorsTreatment);
            DirectorsTreatment DirectorsTreatment;
            DirectorsTreatment = new DirectorsTreatment();
            if (tbDirectorsTreatment.Rows.Count > 0) {
                System.Data.DataRow rowDirectorsTreatment;
                rowDirectorsTreatment = tbDirectorsTreatment.Rows[0];
                DirectorsTreatment.DTID = System.Convert.ToInt32(rowDirectorsTreatment["DTID"]);
                DirectorsTreatment.ImageFile = System.Convert.ToString(rowDirectorsTreatment["ImageFile"]);
                DirectorsTreatment.ImagePath = System.Convert.ToString(rowDirectorsTreatment["ImagePath"]);
                DirectorsTreatment.VoiceOver = System.Convert.ToString(rowDirectorsTreatment["VoiceOver"]);
                DirectorsTreatment.Description = System.Convert.ToString(rowDirectorsTreatment["Description"]);
                DirectorsTreatment.Rank = System.Convert.ToInt32(rowDirectorsTreatment["Rank"]);
                DirectorsTreatment.CreatedBy = System.Convert.ToString(rowDirectorsTreatment["CreatedBy"]);
                DirectorsTreatment.CreatedDate = System.Convert.ToDateTime(rowDirectorsTreatment["CreatedDate"]);
                DirectorsTreatment.ModifiedBy = System.Convert.ToString(rowDirectorsTreatment["ModifiedBy"]);
                DirectorsTreatment.ModifiedDate = System.Convert.ToDateTime(rowDirectorsTreatment["ModifiedDate"]);
                return DirectorsTreatment;
            }
            else {
                return null;
            }
        }

        public static DataTable getDirectorsTreatmentByPresentation(Int32 PresentationID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from DirectorsTreatment where  PresentationID = " + PresentationID + " ORDER BY [Rank]", conn);
            conn.Open();
            System.Data.DataTable tbDirectorsTreatment;
            tbDirectorsTreatment = new System.Data.DataTable("DirectorsTreatment");
            adapt.Fill(tbDirectorsTreatment);
            DirectorsTreatment DirectorsTreatment;
            DirectorsTreatment = new DirectorsTreatment();


            return tbDirectorsTreatment;
        }
    }

