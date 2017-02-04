using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
         
        //CopyDirectory(Server.MapPath("~/_ipad"), Server.MapPath("~/1/18"));

        DirectoryCopy(Server.MapPath("~/_ipad"), Server.MapPath("~/1/18"), true);

    }
    private static void CopyDirectory(string sourcePath, string destPath)
    {
        //if (!Directory.Exists(destPath))
        //{
        //    Directory.CreateDirectory(destPath);

        //}


        foreach (string file in Directory.GetFiles(sourcePath))
        {
            string dest = Path.Combine(destPath, Path.GetFileName(file));
            File.Copy(file, dest);
        }

        foreach (string folder in Directory.GetDirectories(sourcePath))
        {
            string dest = Path.Combine(destPath, Path.GetFileName(folder));
            CopyDirectory(folder, dest);
        }
    }

    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        // If the destination directory doesn't exist, create it. 
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }

        // If copying subdirectories, copy them and their contents to new location. 
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }


}