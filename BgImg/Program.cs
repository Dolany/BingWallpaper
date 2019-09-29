using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BingService;

namespace BgImg
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullPath = BingBgImgSvc.GetUrl();
            var savePath = "./" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";
            Utility.Common.DownloadImage(fullPath, savePath);
            var image = Image.FromFile(savePath);
            image.Save("./desktopBgImg.bmp", ImageFormat.Bmp);

            var file = new FileInfo("./desktopBgImg.bmp");
            Utility.Common.SystemParametersInfo(20, 0, file.FullName, 0x2);

            Console.WriteLine("Completed");
            Console.ReadKey();
        }
    }
}
