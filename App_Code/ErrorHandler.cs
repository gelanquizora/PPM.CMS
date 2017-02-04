using System;

 
    public class ErrorHandler
    {
        public static void Handle(Exception applicationException)
        {
            ErrorLog(applicationException.Message.ToString(), applicationException.StackTrace.ToString());
            throw applicationException;

        }
        private static void ErrorLog(string messageException, string sourceException)
        {
            string errDirectoryPath;
            string Filename;

            //errDirectoryPath = System.IO.Directory.GetCurrentDirectory() + "\\PC2ErrorDirectory\\";
            //Filename = errDirectoryPath + "PC2ErrorLogFile";

            //if (System.IO.Directory.Exists(errDirectoryPath))
            //{
            //    WriteErrorToFile(messageException, sourceException, Filename);
            //}
            //else
            //{
            //    System.IO.Directory.CreateDirectory(errDirectoryPath);
            //    WriteErrorToFile(messageException, sourceException, Filename);
            //}

        }

        private static void WriteErrorToFile(string messageException, string sourceException, string filename)
        {
            //System.IO.StreamWriter ErrorStreamWriter;
            //if (!System.IO.File.Exists(filename))
            //{
            //    ErrorStreamWriter = System.IO.File.CreateText(filename);
            //    ErrorStreamWriter.WriteLine("Begin ///////////////////// Begin");
            //    ErrorStreamWriter.Close();
            //    ErrorStreamWriter = System.IO.File.AppendText(filename);
            //    //string test =  
            //    ErrorStreamWriter.WriteLine("Datetime of error encountered : " + System.DateTime.Now.ToString("u"));
            //    ErrorStreamWriter.WriteLine("Error message : " + messageException);
            //    try
            //    {
            //        ErrorStreamWriter.WriteLine("Error source : " + sourceException.Substring(sourceException.IndexOf("PC2"), sourceException.Length - sourceException.IndexOf("PC2")));
            //    }
            //    catch 
            //    {
            //        ErrorStreamWriter.WriteLine("Error source : " + sourceException.ToString());
            //    }
            //    ErrorStreamWriter.WriteLine("End   \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ End");
            //    ErrorStreamWriter.Close();
            //}
            //else
            //{
            //    ErrorStreamWriter = System.IO.File.AppendText(filename);
            //    ErrorStreamWriter.WriteLine("Begin ///////////////////// Begin");
            //    ErrorStreamWriter.WriteLine("Datetime of error encountered : " + DateTime.Today.ToString("u"));
            //    ErrorStreamWriter.WriteLine("Error message : " + messageException);
            //    try
            //    {
            //        ErrorStreamWriter.WriteLine("Error source : " + sourceException.Substring(sourceException.IndexOf("PC2"), sourceException.Length - sourceException.IndexOf("PC2")));
            //    }   
            //    catch
            //    {
            //        ErrorStreamWriter.WriteLine("Error source : "  + sourceException.ToString());
            //    }
            //    ErrorStreamWriter.WriteLine("End   \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ End");
            //    ErrorStreamWriter.Close();
            //}
        }
    }
 