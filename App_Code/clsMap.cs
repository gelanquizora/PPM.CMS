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
    
    
    public class clsmap {
        
        public static void Update(Map map) {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;
            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Map where 1=1", conn);
            conn.Open();
            System.Data.DataTable tbMap;
            tbMap = new System.Data.DataTable("Map");
            adapt.Fill(tbMap);
            SqlCommandBuilder mybuild;
            mybuild = new System.Data.SqlClient.SqlCommandBuilder(adapt);
            adapt.UpdateCommand = mybuild.GetUpdateCommand();
            adapt.InsertCommand = mybuild.GetInsertCommand();
            if (tbMap.Rows.Count > 0) {
                // Edit methods
                System.Data.DataRow rowMap;
                rowMap = tbMap.Rows[0];
                rowMap["MapID"] = map.MapID;
                rowMap["MapFile"] = map.MapFile;
                rowMap["MapPath"] = map.MapPath;
                rowMap["CreatedBy"] = map.CreatedBy;
                rowMap["CreatedDate"] = map.CreatedDate;
                rowMap["ModifiedBy"] = map.ModifiedBy;
                rowMap["ModifiedDate"] = map.ModifiedDate;
                rowMap["PresentationID"] = map.PresentationID;
                adapt.Update(tbMap);
            }
            else {
                System.Data.DataRow rowMap;
                rowMap = tbMap.NewRow();
                rowMap["MapID"] = map.MapID;
                rowMap["MapFile"] = map.MapFile;
                rowMap["MapPath"] = map.MapPath;
                rowMap["CreatedBy"] = map.CreatedBy;
                rowMap["CreatedDate"] = map.CreatedDate;
                rowMap["ModifiedBy"] = map.ModifiedBy;
                rowMap["ModifiedDate"] = map.ModifiedDate;
                rowMap["PresentationID"] = map.PresentationID;
                tbMap.Rows.Add(rowMap);
                adapt.Update(tbMap);
            }
        }

        public static Map getMap(int MapID)
        {
            SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ConnectionString);
            SqlDataAdapter adapt;          

            adapt = new System.Data.SqlClient.SqlDataAdapter("select * from Map where  MapID = " + MapID + "", conn);
            conn.Open();
            System.Data.DataTable tbMap;
            tbMap = new System.Data.DataTable("Map");
            adapt.Fill(tbMap);
            Map Map;
            Map = new Map();
            if (tbMap.Rows.Count > 0) {
                System.Data.DataRow rowMap;
                rowMap = tbMap.Rows[0];
                Map.MapID = System.Convert.ToInt32(rowMap["MapID"]);
                Map.MapFile = System.Convert.ToString(rowMap["MapFile"]);
                Map.MapPath = System.Convert.ToString(rowMap["MapPath"]);
                Map.CreatedBy = System.Convert.ToString(rowMap["CreatedBy"]);
                Map.CreatedDate = System.Convert.ToDateTime(rowMap["CreatedDate"]);
                Map.ModifiedBy = System.Convert.ToString(rowMap["ModifiedBy"]);
                Map.ModifiedDate = System.Convert.ToDateTime(rowMap["ModifiedDate"]);
                Map.PresentationID = System.Convert.ToInt32(rowMap["PresentationID"]);
                return Map;
            }
            else {
                return null;
            }
        }


     

        public static bool Delete(int MapID)
        {
            int id = 0;
            bool isSaved = false;
            SqlHelper _helper = new SqlHelper();

            try
            {
                if (_helper.CreateConnection())
                {
                    _helper.BeginTransaction();
                    _helper.CreateCommand("sp_DeleteMap", true);
                    _helper.AddParameter("@MapID", MapID, DbType.Int32, ParameterDirection.Input);
                   
                    isSaved = _helper.ExecuteNonQuery();
                    _helper.ClearCommandParameters();

                    if (isSaved)
                    {
                        _helper.CommitTransaction();
                    }

                }
            }
            catch (Exception ex)
            {
                _helper.RollbackTransaction();

            }
            finally
            {
                _helper.CloseConnection();

            }

            return isSaved;
        }

    }
