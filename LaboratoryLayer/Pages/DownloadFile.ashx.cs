using System;
using System.Web;
using System.Web.SessionState;
using BusinessLayer.Pages;

namespace LaboratoryLayer.Pages
{
    /// <summary>
    /// Summary description for DownloadFileHandler
    /// </summary>
    public class DownloadFileHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            // Retrieve the fileId from the query string
            var fileId = context.Request.QueryString["fileId"];
            var token = context.Request.QueryString["token"];

            // Retrieve the token stored in the session
            var storedToken = GetDownloadToken(context);

            // Check if the token sent with the request matches the stored token
            if (token != storedToken)
            {
                context.Response.StatusCode = 403; // Forbidden
                context.Response.Write("Access Denied");
                context.Response.End();
                return;
            }

            // Check if fileId is not null and process further
            if (string.IsNullOrEmpty(fileId))
            {
                context.Response.Write("Invalid fileId");
                context.Response.StatusCode = 400; // Set 400 status code for invalid request
                context.Response.End();
                return;
            }

            var attachedFiles = new AttachedFilesDB().GetByID(Convert.ToInt32(fileId));
            var filename = attachedFiles.FileName.Replace(" ", "_");

            // Fetch the file based on the fileId
            byte[] fileBytes = attachedFiles.FileContent;
            if (fileBytes == null || fileBytes.Length <= 0)
            {
                context.Response.Write("File not found");
                context.Response.StatusCode = 404; // Set 404 status code for file not found
                context.Response.End();
                return;
            }

            // Set the content type based on the file type
            context.Response.ContentType = "application/octet-stream"; // Change to the appropriate content type

            // Set the file name
            context.Response.AddHeader("Content-Disposition", "attachment;   filename=" + filename); // Change the filename and extension

            // Write the byte array to the output stream
            context.Response.BinaryWrite(fileBytes);
            context.Response.Flush();
        }

        private static string GetDownloadToken(HttpContext context)
        {
            if (context.Session == null) return null;
            return context.Session["DownloadToken"] as string;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}