using System;
using Utility;

namespace BingService
{
    public class BingBgImgSvc
    {
        public static string GetUrl()
        {
            var requestor = new HttpRequester();
            var html = requestor.Request("https://cn.bing.com");
            var strs = html.Split("background-image");
            var strs2 = strs[1].Split(";");
            var strs3 = strs2[0].Split(new[] {"(", ")"}, StringSplitOptions.RemoveEmptyEntries);
            var url = strs3[1];
            var fullPath = "https://cn.bing.com" + url;

            return fullPath;
        }
    }
}
