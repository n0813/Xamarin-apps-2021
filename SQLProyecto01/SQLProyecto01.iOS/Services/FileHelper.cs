using System;
using System.IO;
using SQLProyecto01.iOS.Services;
using SQLProyecto01.Services;
using Xamarin.Forms;


[assembly: Dependency(typeof(FileHelper))]
namespace SQLProyecto01.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            //Agregar System.IO
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);

        }
    }
}
