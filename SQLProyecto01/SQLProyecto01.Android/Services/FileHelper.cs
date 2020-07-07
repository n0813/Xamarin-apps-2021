using System;
using SQLProyecto01.Droid.Services;
using SQLProyecto01.Services;
using Xamarin.Forms;
using System.IO;

[assembly:Dependency(typeof(FileHelper))]
namespace SQLProyecto01.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            //Agregar System.IO
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}
