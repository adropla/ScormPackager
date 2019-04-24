using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
namespace ScormPackager
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new mainForm());
            
        }
        public static void zipFolder(string folder, string path)
        {
            ZipFile.CreateFromDirectory(folder, path, CompressionLevel.Fastest, true); // упаковка папки
        }
        public static void pathNameType(string folder, string pathForFile)
        {
            getfiles get = new getfiles();
            List<string> files = get.GetAllFiles(folder);
            var path = new List<string>();
            var name = new List<string>();
            var type = new List<string>();
            using (var File = new FileStream(pathForFile + @"\PathNameType.txt", FileMode.Create)) ;
            foreach (string f in files)
            {

                string[] words = f.Split('\\', '.');//разбиение по \ и .
                int wordsLength = words.Length;
                type.Add(words[wordsLength - 1]);// путь, ибо после точки
                name.Add(words[wordsLength - 2]);//название, ибо между \ и .
                string temp = "";
                for (int i = 0; i < wordsLength - 2; i++)
                {
                    temp += words[i] + @"\"; // возвращение к виду Д/папка/

                }
                path.Add(temp);
            }
            var lines = File.ReadAllLines(pathForFile + @"\PathNameType.txt").ToList();
            foreach (string p in path)
            {
                lines.Add(p);
            }
            foreach (string n in name)
            {
                lines.Add(n);
            }
            foreach (string t in type)
            {
                lines.Add(t);
            }
            File.WriteAllLines(pathForFile + @"\PathNameType.txt", lines); // записываем путь имя тип
        }

        public static string courseFolderPath, // переменная пути к папке с курсом
                             packageSavePath;   // переменная пути сохранения Scorm пакета в виде ZIP-архива

    }


    class getfiles
    {
        public List<string> GetAllFiles(string sDirt)
        {
            List<string> files = new List<string>();

            try
            {
                foreach (string file in Directory.GetFiles(sDirt))
                {
                    files.Add(file);
                }
                foreach (string fl in Directory.GetDirectories(sDirt))
                {
                    files.AddRange(GetAllFiles(fl));
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return files;
        }
    }
}