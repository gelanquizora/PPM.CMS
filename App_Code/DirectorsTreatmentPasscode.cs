using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DirectorsTreatmentPasscode
/// </summary>
public class DirectorsTreatmentPasscode
{

    SqlHelper _helper;
	public DirectorsTreatmentPasscode()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _ID;
    private string _PresentationID;
    private string _Passcode;


    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }


    public string PresentationID
    {
        get { return _PresentationID; }
        set { _PresentationID = value; }
    }

    public string Passcode
    {
        get { return _Passcode; }
        set { _Passcode = value; }
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
                _helper.CreateCommand("sp_InsertDirectorsTreatmentPasscodes", true);

                _helper.AddParameter("@PresentationID", this.PresentationID, DbType.Int32, ParameterDirection.Input);
                _helper.AddParameter("@Passcode", this.Passcode, DbType.String, ParameterDirection.Input);
 

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
                _helper.CreateCommand("sp_UpdateDirectorsTreatmentPasscodes", true);

         
                _helper.AddParameter("@PresentationID", this.PresentationID, DbType.Int32, ParameterDirection.Input);
                _helper.AddParameter("@Passcode", this.Passcode, DbType.String, ParameterDirection.Input);


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

    public string Get()
    {
        _helper = new SqlHelper();
        string passcode = "";
        DataTable dt = new DataTable();


        _helper.CloseConnection();
        _helper.CreateCommand("sp_SelectDirectorsTreatmentPasscodes", false);
        _helper.AddParameter("@PresentationID", this.PresentationID, DbType.Int32, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;


        if (dt.Rows.Count > 0)
        {
            passcode = dt.Rows[0]["Passcode"].ToString();
        }
        _helper.CloseConnection();


        return passcode;
    }

}