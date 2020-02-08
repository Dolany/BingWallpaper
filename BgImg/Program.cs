using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BingService;
using Utility;

namespace BgImg
{
    class Program
    {
        private const string PicCachePath = "./BGs/";

        static void Main(string[] args)
        {
            Console.WriteLine("Program is starting...");
            Console.WriteLine("Parsing Url...");
            try
            {
                var fullPath = BingBgImgSvc.GetUrl();
                var dir = new DirectoryInfo(PicCachePath);
                if (!dir.Exists)
                {
                    Console.WriteLine("Creating PicCache Folder...");
                    dir.Create();
                }

                var savePath = $"{PicCachePath}{DateTime.Now:yyyyMMdd}.jpg";
                Console.WriteLine("Downloading Image...");
                Common.DownloadImage(fullPath, savePath);
                var image = Image.FromFile(savePath);
                Console.WriteLine("Copying Image to Workplace...");
                image.Save("./desktopBgImg.bmp", ImageFormat.Bmp);

                var file = new FileInfo("./desktopBgImg.bmp");
                Console.WriteLine("Setting Bg...");
                Common.SystemParametersInfo(20, 0, file.FullName, 0x2);

                Console.WriteLine("Completed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong...");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            Console.ReadKey();
        }
    }
}
