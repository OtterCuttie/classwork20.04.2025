using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Blue
{
    public class FileName
    {
        public class FileNames : ISerializer 
        {
            private string _name;
            public string Name => _name;
            private string _extension;
            public string Extension => _extension;
            public FileName(string name)
            {
                _name = name;
            }
            public FileName(string name, string something = "txt")
            {
                _name = name;
                _extension = something;
            }
            public void Serialize(Lab9.Blue.Blue obj)
            {
                var folder = Directory.GetCurrentDirectory();// папка запуска глуюокок в проекте

                folder = Directory.GetParent(folder).Parent.FullName;

                folder =Environment.GetFolderPath( Environment.SpecialFolder.Desktop);//рабочий стол gлучение доступа

                var filePath = Path.Combine(folder, Name);
                filePath += "."+Extension;

                File.Create(filePath);
            }
        }

    }
}
