using System;
using System.Net;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Utility
{
    public static class Common
    {
        public static bool DownloadImage(string url, string savePath)
        {
            try
            {
                var req = (HttpWebRequest)WebRequest.Create(url);
                req.ServicePoint.Expect100Continue = false;
                req.Method = "GET";
                req.KeepAlive = true;
                req.ContentType = "image/*";
                using var rsp = (HttpWebResponse) req.GetResponse();
                using var stream = rsp.GetResponseStream();
                Image.FromStream(stream).Save(savePath);

                return true;
            }
            catch (Exception e)
            {
                RuntimeLogger.Log(e);
                return false;
            }
        }

        public static string ToCommonString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
            int uAction,
            int uParam,
            string lpvParam,
            int fuWinIni
        );
    }
}
