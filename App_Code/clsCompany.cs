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
    using System.Configuration;
    using System.Linq;
    
    
    public class clscompany {
        
        public static void Insert(Company company) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Company", conn); 
            conn.Open();
            System.Data.DataTable tbCompany;
            tbCompany = new System.Data.DataTable("Company");
            adapt.Fill(tbCompany);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
          
            adapt.InsertCommand = mybuild.GetInsertCommand();
         
                System.Data.DataRow rowCompany;
                rowCompany = tbCompany.NewRow();        
                rowCompany["CompanyName"] = company.CompanyName;
                rowCompany["Description"] = company.Description;
                rowCompany["Active"] = true;
                tbCompany.Rows.Add(rowCompany);
                adapt.Update(tbCompany);
       
        }
        public static void Update(Company company)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Company where  CompanyID = " + company.CompanyID + "", conn);
            conn.Open();
            System.Data.DataTable tbCompany;
            tbCompany = new System.Data.DataTable("Company");
            adapt.Fill(tbCompany);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
            adapt.InsertCommand = mybuild.GetInsertCommand();
            if (tbCompany.Rows.Count > 0)
            {
                // Edit methods
                System.Data.DataRow rowCompany;
                rowCompany = tbCompany.Rows[0];
                rowCompany["CompanyName"] = company.CompanyName;
                rowCompany["Description"] = company.Description;
                adapt.Update(tbCompany);
            }
            else
            {
                System.Data.DataRow rowCompany;
                rowCompany = tbCompany.NewRow();
                rowCompany["CompanyID"] = company.CompanyID;
                rowCompany["CompanyName"] = company.CompanyName;
                rowCompany["Description"] = company.Description;
                tbCompany.Rows.Add(rowCompany);
                adapt.Update(tbCompany);
            }
        }
        public static Company getCompany(Int32 CompanyID) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Company where  CompanyID = " + CompanyID + "", conn);
            conn.Open();
            System.Data.DataTable tbCompany;
            tbCompany = new System.Data.DataTable("Company");
            adapt.Fill(tbCompany);
            Company Company;
            Company = new Company();
            if (tbCompany.Rows.Count > 0) {
                System.Data.DataRow rowCompany;
                rowCompany = tbCompany.Rows[0];
                Company.CompanyName = System.Convert.ToString(rowCompany["CompanyName"]);
                Company.Description = System.Convert.ToString(rowCompany["Description"]);
                Company.Logo = System.Convert.ToString(rowCompany["Logo"]);
                return Company;
            }
            else {
                return null;
            }
        }
    }
//}