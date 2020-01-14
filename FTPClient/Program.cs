using System;
using System.IO;
using System.Net;
namespace FTPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://127.0.0.1/1.txt"));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            //request.Credentials = new NetworkCredential("admin", "123456");
            //request.EnableSsl = true; - используется ssl (ftps://)
            request.UseBinary = false;
            var response = (FtpWebResponse)request.GetResponse();
            using (var responsestream = response.GetResponseStream())
            {
                responsestream.CopyTo(File.OpenWrite("1.txt"));
            }
        }
    }
}
