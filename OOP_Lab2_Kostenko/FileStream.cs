using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OOP_Lab2_Kostenko
{
    class FileStrm
    {
        public void CreateDir()
        {
            string path = @"C:\LabaOOP";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

        public string Read_file()
        {
            string path = @"C:\LabaOOP\Lab3.txt";
            byte[] output;
            using (FileStream fstream = new FileStream($"{path}",
            FileMode.OpenOrCreate))
            {
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                string text_File = Encoding.Default.GetString(output);
                return text_File;
            }
        }

        public void WriteFile(Menu menu)
        {
            string name;
            int id = 1;
            string writepath = @"C:\LabaOOP\Lab3.txt";

            foreach (Dish dish in menu.GetAvalableDishes())
            {
                name = $"{id++}:{dish.ToString()}";

                using (StreamWriter sw = new StreamWriter(writepath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(name);
                }

            }
        }
    }
}
