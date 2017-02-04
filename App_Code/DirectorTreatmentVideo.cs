using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DirectorTreatmentVideo
/// </summary>
public class DirectorTreatmentVideo
{

    SqlHelper _helper;
    private int _ID;
    private int _PresentationID;

    private string _Path;
    private string _Filename;
    private string _Title;
    private string _CreatedBy;
    private string _ModifiedBy;
    private DateTime _CreatedDate;
    private DateTime _ModifiedDate;
    private Int32 _Rank;

	public DirectorTreatmentVideo()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public int PresentationID
    {
        get { return _PresentationID; }
        set { _PresentationID = value; }
    }

    public string Path
    {
        get { return _Path; }
        set { _Path = value; }
    }
    public string Filename
    {
        get { return _Filename; }
        set { _Filename = value; }
    }


    public Int32 Rank
    {
        get { return _Rank; }
        set { _Rank = value; }
    }

    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }

    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }


    public string ModifiedBy
    {
        get { return _ModifiedBy; }
        set { _ModifiedBy = value; }
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
                _helper.CreateCommand("sp_InsertDirectorsTreatmentVideo", true);

                _helper.AddParameter("@Title", this.Title, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@Path", this.Path, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@Filename", this.Filename, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@CreatedBy", this.CreatedBy, DbType.String, ParameterDirection.Input);

                _helper.AddParameter("@Rank", this.Rank, DbType.Int32, ParameterDirection.Input);
                _helper.AddParameter("@PresentationID", this.PresentationID, DbType.Int32, ParameterDirection.Input);



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
                _helper.CreateCommand("sp_UpdateDirectorsTreatmentVideo", true);

                _helper.AddParameter("@Title", this.Title, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@Path", this.Path, DbType.String, ParameterDirection.Input);
                _helper.AddParameter("@ModifiedBy", this.ModifiedBy, DbType.String, ParameterDirection.Input);

                _helper.AddParameter("@Rank", this.Rank, DbType.Int32, ParameterDirection.Input);
                _helper.AddParameter("@ID", this.ID, DbType.Int32, ParameterDirection.Input);



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

    public bool UpdateWithoutVideo()
    {
        int id = 0;
        bool isSaved = false;
        _helper = new SqlHelper();

        try
        {
            if (_helper.CreateConnection())
            {
                _helper.BeginTransaction();
                _helper.CreateCommand("sp_UpdateDirectorsTreatmentVideoInfo", true);

                _helper.AddParameter("@Title", this.Title, DbType.String, ParameterDirection.Input);
    
                _helper.AddParameter("@ModifiedBy", this.ModifiedBy, DbType.String, ParameterDirection.Input);

                _helper.AddParameter("@Rank", this.Rank, DbType.Int32, ParameterDirection.Input);
                _helper.AddParameter("@ID", this.ID, DbType.Int32, ParameterDirection.Input);



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

    public DataTable GetByID()
    {
        _helper = new SqlHelper();
        string passcode = "";
        DataTable dt = new DataTable();


        _helper.CloseConnection();
        _helper.CreateCommand("sp_SelectDirectorsTreatmentVideoByID", false);
        _helper.AddParameter("@ID", this.ID, DbType.Int32, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;


        if (dt.Rows.Count > 0)
        {
            this.Rank = Convert.ToInt32(dt.Rows[0]["Rank"].ToString());
            this.Title =  dt.Rows[0]["Title"].ToString();
            this.Path = dt.Rows[0]["Path"].ToString();

        }
        _helper.CloseConnection();


        return dt;
    }

}