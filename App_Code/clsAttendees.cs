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
    
    
    public class clsattendees {
        
        public static void Update(Attendees attendees) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Attendees where 1=1", conn);
            conn.Open();
            System.Data.DataTable tbAttendees;
            tbAttendees = new System.Data.DataTable("Attendees");
            adapt.Fill(tbAttendees);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
            adapt.InsertCommand = mybuild.GetInsertCommand();
            if (tbAttendees.Rows.Count > 0) {
                // Edit methods
                System.Data.DataRow rowAttendees;
                rowAttendees = tbAttendees.Rows[0];
                rowAttendees["AttendeeID"] = attendees.AttendeeID;
                rowAttendees["AttendeeTitle"] = attendees.AttendeeTitle;
                rowAttendees["AttendeePage"] = attendees.AttendeePage;
                rowAttendees["AttendeeFileName"] = attendees.AttendeeFileName;
                rowAttendees["CreatedBy"] = attendees.CreatedBy;
                rowAttendees["CreatedDate"] = attendees.CreatedDate;
                rowAttendees["ModifiedBy"] = attendees.ModifiedBy;
                rowAttendees["ModifiedDate"] = attendees.ModifiedDate;
                adapt.Update(tbAttendees);
            }
            else {
                System.Data.DataRow rowAttendees;
                rowAttendees = tbAttendees.NewRow();
                rowAttendees["AttendeeID"] = attendees.AttendeeID;
                rowAttendees["AttendeeTitle"] = attendees.AttendeeTitle;
                rowAttendees["AttendeePage"] = attendees.AttendeePage;
                rowAttendees["AttendeeFileName"] = attendees.AttendeeFileName;
                rowAttendees["CreatedBy"] = attendees.CreatedBy;
                rowAttendees["CreatedDate"] = attendees.CreatedDate;
                rowAttendees["ModifiedBy"] = attendees.ModifiedBy;
                rowAttendees["ModifiedDate"] = attendees.ModifiedDate;
                tbAttendees.Rows.Add(rowAttendees);
                adapt.Update(tbAttendees);
            }
        }

        public static Attendees getAttendees(Int32 AttendeeID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;    
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Attendees where  AttendeeID = " + AttendeeID + "", conn);
            conn.Open();
            System.Data.DataTable tbAttendees;
            tbAttendees = new System.Data.DataTable("Attendees");
            adapt.Fill(tbAttendees);
            Attendees Attendees;
            Attendees = new Attendees();
            if (tbAttendees.Rows.Count > 0) {
                System.Data.DataRow rowAttendees;
                rowAttendees = tbAttendees.Rows[0];
                Attendees.AttendeeID = System.Convert.ToInt32(rowAttendees["AttendeeID"]);
                Attendees.AttendeeTitle = System.Convert.ToString(rowAttendees["AttendeeTitle"]);
                Attendees.AttendeePage = System.Convert.ToString(rowAttendees["AttendeePage"]);
                Attendees.AttendeeFileName = System.Convert.ToString(rowAttendees["AttendeeFileName"]);
                Attendees.CreatedBy = System.Convert.ToString(rowAttendees["CreatedBy"]);
                Attendees.CreatedDate = System.Convert.ToDateTime(rowAttendees["CreatedDate"]);
                Attendees.ModifiedBy = System.Convert.ToString(rowAttendees["ModifiedBy"]);
                Attendees.ModifiedDate = System.Convert.ToDateTime(rowAttendees["ModifiedDate"]);
                return Attendees;
            }
            else {
                return null;
            }
        }
    }

