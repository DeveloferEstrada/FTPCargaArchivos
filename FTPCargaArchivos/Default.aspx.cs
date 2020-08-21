using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FTPCargaArchivos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (ftpFileUpload.HasFile)
            {
                string fileName = ftpFileUpload.FileName;
                string path= "~/Archivos/";
                Directory.CreateDirectory(Server.MapPath(path));

                Stream fs = ftpFileUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((Int32)fs.Length);

                string filePath = path + fileName;
                File.WriteAllBytes(Server.MapPath(filePath), bytes);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://107.180.46.193/httpdocs/FTPFiles/" + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential("usuario", "password");

                byte[] fileContents;

                using (StreamReader sourceStream = new StreamReader(Server.MapPath(filePath)))
                {
                    fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                }

                request.ContentLength = fileContents.Length;

                using(Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

            }
        }
    }
}