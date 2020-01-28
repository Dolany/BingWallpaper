using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BingService;

namespace BgImg
{
    class Program
    {
        private const string PicCachePath = "./BGs/";

        static void Main(string[] args)
        {
            Console.WriteLine("Program is starting...");
            Console.WriteLine("Parsing Url...");
            var fullPath = BingBgImgSvc.GetUrl();
            var dir = new DirectoryInfo(PicCachePath);
            if (!dir.Exists)
            {
                Console.WriteLine("Creating PicCache Folder...");
                dir.Create();
            }

            var savePath = $"{PicCachePath}{DateTime.Now:yyyyMMdd}.jpg";
            Console.WriteLine("Downloading Image...");
            Utility.Common.DownloadImage(fullPath, savePath);
            var image = Image.FromFile(savePath);
            Console.WriteLine("Copying Image to Workplace...");
            image.Save("./desktopBgImg.bmp", ImageFormat.Bmp);

            var file = new FileInfo("./desktopBgImg.bmp");
            Console.WriteLine("Setting Bg...");
            Utility.Common.SystemParametersInfo(20, 0, file.FullName, 0x2);

            Console.WriteLine("Completed");
            Console.ReadKey();
        }
    }
}
