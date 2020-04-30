using System;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;

namespace RevitConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //string path = $"{Path.GetTempPath() + Guid.NewGuid()}/*.rvt";
            //string path2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "temFile.rvt";
            //string path3 = typeof(Program).Assembly.Location;
            //string path = $@"{Path.GetTempPath()}\Temp\";
            //Console.WriteLine(path);
            //Console.WriteLine(path2);
            //Console.WriteLine(path3);
            //string path=@"C:\Users\lxysa\Desktop\RevitSaveTest\TestApplication\bin\Debug\temp\";
            //DirectoryInfo di = new DirectoryInfo(path);
            //DateTime times = DateTime.Now;
            //if (!di.Exists)
            //{
            //    di.Create(); //创建文件夹 roHidDir(path);  
            //}
            //di.LastWriteTime = times;
            //di.LastAccessTime = times;
            //File.SetAttributes(path, di.Attributes | FileAttributes.Hidden & ~FileAttributes.ReadOnly);
            //path = path + "BaseProject.rvt";
            //FileInfo fi = new FileInfo(path);
            //File.SetAttributes(path, fi.Attributes | FileAttributes.Hidden | FileAttributes.ReadOnly);

            string path = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\temp\";
            DirectoryInfo dir = new DirectoryInfo(path);
            DateTime times = DateTime.Now;
            if (!dir.Exists)
            {
                dir.Create();
            }
            if (!dir.Attributes.Equals(FileAttributes.Hidden|FileAttributes.Directory))
            {
                dir.LastWriteTime = times;
                dir.LastAccessTime = times;
                File.SetAttributes(path, dir.Attributes | FileAttributes.Hidden);
            }
            Console.WriteLine(dir.Attributes);
            Console.ReadKey();
        }
    }
}
