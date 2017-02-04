using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DeviceUser
/// </summary>
public class DeviceUser
{

    SqlHelper _helper;
	public DeviceUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _ID;
    private string _UserName;
    private string _Password;
    private int _ClientID;
    private int _DeckID;



    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }


    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public int ClientID
    {
        get { return _ClientID; }
        set { _ClientID = value; }
    }

    public int DeckID
    {
        get { return _DeckID; }
        set { _DeckID = value; }
    }


    public bool Insert()
    {
        int id = 0;
        bool isSaved = false;
        _helper = new SqlHelper();

        try
        {
            if (_helper.CreateConnection())
            {
                _helper.BeginTransaction();
                _helper.CreateCommand("sp_InsertDeviceUsersByClient", true);
        
                _helper.AddParameter("@UserName", this.UserName, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@Password", this.Password, DbType.String, ParameterDirection.Input);

                _helper.AddParameter("@ClientID", this.ClientID, DbType.Int32, ParameterDirection.Input);
                _helper.AddParameter("@DeckID", this.DeckID, DbType.Int32, ParameterDirection.Input);



                isSaved = _helper.ExecuteNonQuery();

             //   id = Convert.ToInt32(_helper.Command.Parameters["@UserID"].Value);
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
    public bool UpdatePassword()
    {
        int id = 0;
        bool isSaved = false;
        _helper = new SqlHelper();

        try
        {
            if (_helper.CreateConnection())
            {
                _helper.BeginTransaction();
                _helper.CreateCommand("sp_UpdateDeviceUsersByClient", true);

                _helper.AddParameter("@UserName", this.UserName, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@Password", this.Password, DbType.String, ParameterDirection.Input);
 


                isSaved = _helper.ExecuteNonQuery();

                //   id = Convert.ToInt32(_helper.Command.Parameters["@UserID"].Value);
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

    public DataTable GetByUsername()
    {
        _helper = new SqlHelper();

        DataTable dt = new DataTable();


        _helper.CloseConnection();
        _helper.CreateCommand("sp_SelectDeviceUsersByUserName", false);
        _helper.AddParameter("@Username", this.UserName, DbType.String, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;

        _helper.CloseConnection();


        return dt;
    }

    public DataTable GetByClient()
    {
        _helper = new SqlHelper();

        DataTable dt = new DataTable();


        _helper.CloseConnection();
        _helper.CreateCommand("sp_SelectDeviceUsersByClient", false);
        _helper.AddParameter("@ClientID", this.ClientID, DbType.String, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;

        _helper.CloseConnection();


        return dt;
    }

    public bool Update()
    {
        int id = 0;
        bool isSaved = false;
        _helper = new SqlHelper();

        try
        {
            if (_helper.CreateConnection())
            {
                _helper.BeginTransaction();
                _helper.CreateCommand("sp_UpdateDeviceUsersDeckIDByClient", true);

                _helper.AddParameter("@UserName", this.UserName, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@DeckID", this.DeckID, DbType.Int32, ParameterDirection.Input);



                isSaved = _helper.ExecuteNonQuery();

                //   id = Convert.ToInt32(_helper.Command.Parameters["@UserID"].Value);
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

    public void  GetIPadAccess()
    {
        SqlHelper _helper = new SqlHelper();
        string username = String.Empty;
        DataTable dt = new DataTable();


        _helper.CloseConnection();
        _helper.CreateCommand("sp_SelectDeviceUsersByDeck", false);
        _helper.AddParameter("@DeckID", this.DeckID, DbType.Int32, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;

        _helper.CloseConnection();



        if (dt.Rows.Count > 0)
        {
            this.UserName = dt.Rows[0]["UserName"].ToString();
            this.Password = dt.Rows[0]["Password"].ToString();
        }
        else
            this.UserName = string.Empty;

         
    }
    public bool UpdateIPadAccess()
    {
        int id = 0;
        bool isSaved = false;
        _helper = new SqlHelper();

        try
        {
            if (_helper.CreateConnection())
            {
                _helper.BeginTransaction();
                _helper.CreateCommand("sp_UpdateDeviceUsersByDeck", true);

                _helper.AddParameter("@UserName", this.UserName, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@Password", this.Password, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@DeckID", this.DeckID, DbType.Int32, ParameterDirection.Input);



                isSaved = _helper.ExecuteNonQuery();

                //   id = Convert.ToInt32(_helper.Command.Parameters["@UserID"].Value);
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

    public DataTable GetByUsernameDeck()
    {
        _helper = new SqlHelper();

        DataTable dt = new DataTable();


        _helper.CloseConnection();
        _helper.CreateCommand("sp_SelectDeviceUsersByUserNameDeck", false);
        _helper.AddParameter("@Username", this.UserName, DbType.String, ParameterDirection.Input);
        _helper.AddParameter("@DeckID", this.DeckID, DbType.Int32, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;

        _helper.CloseConnection();


        return dt;
    }

   
}