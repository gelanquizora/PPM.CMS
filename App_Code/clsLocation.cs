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
    
    
    public class clslocation {
        
        public static void Update(Location location) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Location where 1=1", conn);
            conn.Open();
            System.Data.DataTable tbLocation;
            tbLocation = new System.Data.DataTable("Location");
            adapt.Fill(tbLocation);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
            adapt.InsertCommand = mybuild.GetInsertCommand();
            if (tbLocation.Rows.Count > 0) {
                // Edit methods
                System.Data.DataRow rowLocation;
                rowLocation = tbLocation.Rows[0];
                rowLocation["LocationID"] = location.LocationID;
                rowLocation["ImageFile"] = location.ImageFile;
                rowLocation["ImagePath"] = location.ImagePath;
                rowLocation["VoiceOver"] = location.VoiceOver;
                rowLocation["Description"] = location.Description;
                rowLocation["Rank"] = location.Rank;
                rowLocation["CreatedBy"] = location.CreatedBy;
                rowLocation["CreatedDate"] = location.CreatedDate;
                rowLocation["ModifiedBy"] = location.ModifiedBy;
                rowLocation["ModifiedDate"] = location.ModifiedDate;
                rowLocation["PresentationID"] = location.PresentationID;
                rowLocation["Template"] = location.Template;
                rowLocation["ImageFile2"] = location.ImageFile2;
                rowLocation["ImagePath2"] = location.ImagePath2;
                rowLocation["ImageFile3"] = location.ImageFile3;
                rowLocation["ImagePath3"] = location.ImagePath3;
                rowLocation["TemplateID"] = location.TemplateID;
                rowLocation["Title1"] = location.Title1;
                rowLocation["Title2"] = location.Title2;
                adapt.Update(tbLocation);
            }
            else {
                System.Data.DataRow rowLocation;
                rowLocation = tbLocation.NewRow();
                rowLocation["LocationID"] = location.LocationID;
                rowLocation["ImageFile"] = location.ImageFile;
                rowLocation["ImagePath"] = location.ImagePath;
                rowLocation["VoiceOver"] = location.VoiceOver;
                rowLocation["Description"] = location.Description;
                rowLocation["Rank"] = location.Rank;
                rowLocation["CreatedBy"] = location.CreatedBy;
                rowLocation["CreatedDate"] = location.CreatedDate;
                rowLocation["ModifiedBy"] = location.ModifiedBy;
                rowLocation["ModifiedDate"] = location.ModifiedDate;
                rowLocation["PresentationID"] = location.PresentationID;
                rowLocation["Template"] = location.Template;
                rowLocation["ImageFile2"] = location.ImageFile2;
                rowLocation["ImagePath2"] = location.ImagePath2;
                rowLocation["ImageFile3"] = location.ImageFile3;
                rowLocation["ImagePath3"] = location.ImagePath3;
                rowLocation["TemplateID"] = location.TemplateID;
                rowLocation["Title1"] = location.Title1;
                rowLocation["Title2"] = location.Title2;
                tbLocation.Rows.Add(rowLocation);
                adapt.Update(tbLocation);
            }
        }

        public static Location getLocation(Int32 locationID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;          
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Location where  locationID = " + locationID + "", conn);
            conn.Open();
            System.Data.DataTable tbLocation;
            tbLocation = new System.Data.DataTable("Location");
            adapt.Fill(tbLocation);
            Location Location;
            Location = new Location();
            if (tbLocation.Rows.Count > 0) {
                System.Data.DataRow rowLocation;
                rowLocation = tbLocation.Rows[0];
                Location.LocationID = System.Convert.ToInt32(rowLocation["LocationID"]);
                Location.ImageFile = System.Convert.ToString(rowLocation["ImageFile"]);
                Location.ImagePath = System.Convert.ToString(rowLocation["ImagePath"]);
                Location.VoiceOver = System.Convert.ToString(rowLocation["VoiceOver"]);
                Location.Description = System.Convert.ToString(rowLocation["Description"]);
                Location.Rank = System.Convert.ToInt32(rowLocation["Rank"]);
                Location.CreatedBy = System.Convert.ToString(rowLocation["CreatedBy"]);
                Location.CreatedDate = System.Convert.ToDateTime(rowLocation["CreatedDate"]);
                Location.ModifiedBy = System.Convert.ToString(rowLocation["ModifiedBy"]);
                Location.ModifiedDate = System.Convert.ToDateTime(rowLocation["ModifiedDate"]);
                Location.PresentationID = System.Convert.ToInt32(rowLocation["PresentationID"]);
                Location.Template = System.Convert.ToString(rowLocation["Template"]);
                Location.ImageFile2 = System.Convert.ToString(rowLocation["ImageFile2"]);
                Location.ImagePath2 = System.Convert.ToString(rowLocation["ImagePath2"]);
                Location.ImageFile3 = System.Convert.ToString(rowLocation["ImageFile3"]);
                Location.ImagePath3 = System.Convert.ToString(rowLocation["ImagePath3"]);
                Location.TemplateID = System.Convert.ToInt32(rowLocation["TemplateID"]);
                Location.Title1 = System.Convert.ToString(rowLocation["Title1"]);
                Location.Title2 = System.Convert.ToString(rowLocation["Title2"]);
                return Location;
            }
            else {
                return null;
            }
        }
    }