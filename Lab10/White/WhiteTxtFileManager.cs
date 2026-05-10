using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.White
{
    public class WhiteTxtFileManager : IWhiteSerializer
    {
        private string _name;
        public string Name => _name;
        private string _extension;
        public string Extension => _extension;

        public WhiteTxtFileManager(string name, string something = "txt")
        {
            _name = name;
            _extension = something;
        }
        public void Serialize(Lab9.White.White obj)
        {
            // папка запуска (глубоко в проекте)
            // типо такого: C:\Users\Teacher.TEST-PC\source\repos\BIVT-25-Lab-10\Lab10\bin\Debug\net8.0
            var folder = Directory.GetCurrentDirectory();
            // получу это: C:\Users\Teacher.TEST-PC\source\repos\BIVT-25-Lab-10\Lab10
            folder = Directory.GetParent(folder).Parent.Parent.FullName;

            // получить путь к папке (рабочий стол)
            folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var filePath = Path.Combine(folder, Name);
            filePath += "." + Extension;

            if (File.Exists(filePath)) // удаляем файл
                File.Delete(filePath);

            if (!File.Exists(filePath)) // создаем файл
                File.Create(filePath).Close();

            File.WriteAllText(filePath, obj.Input); // перезаписать все, как есть

            File.AppendAllText(filePath, obj.Input); // записать все, как есть в конец

            //  |"Type":"White"|
            //  |"Input":"some text"|
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Type", obj.GetType().Name);
            dict.Add("Input", obj.Input);
            var d = dict.ToArray();
            string[] lines = new string[dict.Count];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = d[i].Key + ":" + d[i].Value;
            }

            lines[0] = "Type:" + obj.GetType().Name;
            lines[1] = "Input:" + obj.Input;

            File.WriteAllLines(filePath, lines);

            var str = File.ReadAllText(filePath); // читает все одной строкой

            lines = File.ReadAllLines(filePath);

            var pair = lines[0].Split(":", 2, StringSplitOptions.RemoveEmptyEntries);
            var input = lines[1].Split(":", 2, StringSplitOptions.RemoveEmptyEntries);

            Lab9.White.White desObj;
            
            if (pair[0] == "Type")
            {
                switch (pair[1])
                {
                    case "Task1": desObj = new Lab9.White.White(); break; // Task1(input[1]);
                    case "Task2": desObj = new Lab9.White.White(); break;
                }
            }
        }
    }
}
