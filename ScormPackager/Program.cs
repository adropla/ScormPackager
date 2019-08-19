using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Xml;
using HtmlAgilityPack;
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

        public static void copyXSDfiles(string path)// копирование xsd-файлов из ресурсов в папку курса
        {
            File.Copy(@"Resources/adlcp_rootv1p2.xsd", path + @"/adlcp_rootv1p2.xsd");
            File.Copy(@"Resources/ims_xml.xsd", path + @"/ims_xml.xsd");
            File.Copy(@"Resources/imscp_rootv1p1p2.xsd", path + @"/imscp_rootv1p1p2.xsd");
            File.Copy(@"Resources/imsmd_rootv1p2p1.xsd", path + @"/imsmd_rootv1p2p1.xsd");
        }

        public static void clearTemp(string path)
        {
            File.Delete(path + @"/adlcp_rootv1p2.xsd");
            File.Delete(path + @"/ims_xml.xsd");
            File.Delete(path + @"/imscp_rootv1p1p2.xsd");
            File.Delete(path + @"/imsmd_rootv1p2p1.xsd");
            File.Delete(path + @"/imsmanifest.xml");
        }

        public static void manifest(string path) // манифест
        {
            XmlDocument manifest = new XmlDocument();
            manifest.Load(@"Resources\imsmanifest.xml");
            XmlElement xRoot = manifest.DocumentElement;
            //organizations
            XmlElement organizations = manifest.CreateElement("organizations");
            XmlElement organization = manifest.CreateElement("organization");
            XmlAttribute Default = manifest.CreateAttribute("default");
            XmlText DefaultText = manifest.CreateTextNode("default_organizations");
            //resources
            XmlElement resources = manifest.CreateElement("resources", "http://www.imsproject.org/xsd/imscp_rootv1p1p2"); 
            var files = File.ReadAllLines(pathForFile + @"\PathNameType.txt").ToList();
            var filesSplit = new List<string[]>();  //0 path 1 name 2 type
            for (int i = 0; i < files.Count; i++)
            {
                filesSplit.Add(files[i].Split(' '));
            }
            for (int i = 0; i < filesSplit.Count; i++)
            {
                if (filesSplit[i][2] == "html")
                {
                    XmlElement file = manifest.CreateElement("file", "http://www.imsproject.org/xsd/imscp_rootv1p1p2");
                    XmlElement resource = manifest.CreateElement("resource", "http://www.imsproject.org/xsd/imscp_rootv1p1p2");
                    XmlAttribute identifier = manifest.CreateAttribute("identifier");
                    XmlAttribute type = manifest.CreateAttribute("type");
                    XmlText webcontent = manifest.CreateTextNode("webcontent");
                    type.AppendChild(webcontent);
                    XmlText id = manifest.CreateTextNode(i.ToString());
                    identifier.AppendChild(id);
                    XmlAttribute adlcpscormType = manifest.CreateAttribute("adlcp", "scormtype", "http://www.adlnet.org/xsd/adlcp_rootv1p2");
                    XmlText asset = manifest.CreateTextNode("asset");
                    adlcpscormType.AppendChild(asset);
                    XmlAttribute href = manifest.CreateAttribute("href");
                    XmlText reference = manifest.CreateTextNode(filesSplit[i][0] + filesSplit[i][1] + '.' + filesSplit[i][2]);
                    href.AppendChild(reference);
                    resource.Attributes.Append(identifier);
                    resource.Attributes.Append(type);
                    resource.Attributes.Append(adlcpscormType);
                    resource.Attributes.Append(href);
                    XmlAttribute hrefcopy = manifest.CreateAttribute("href");
                    XmlText referencecopy = manifest.CreateTextNode(filesSplit[i][0] + filesSplit[i][1] + '.' + filesSplit[i][2]);
                    hrefcopy.AppendChild(referencecopy);
                    file.Attributes.Append(hrefcopy);
                    resource.AppendChild(file);
                    XmlElement dependency = manifest.CreateElement("dependency", "http://www.imsproject.org/xsd/imscp_rootv1p1p2");
                    XmlText common = manifest.CreateTextNode("common_files");
                    XmlAttribute identifiercommon = manifest.CreateAttribute("identifier");
                    identifiercommon.AppendChild(common);
                    dependency.Attributes.Append(identifiercommon);
                    resource.AppendChild(dependency);
                    resources.AppendChild(resource);
                }
            }
            xRoot.AppendChild(resources);
            manifest.Save(path + @"\imsmanifest.xml");
        }

        public static void zipFolder(string folder, string path)
        {
            ZipFile.CreateFromDirectory(folder, path, CompressionLevel.Fastest, true); // упаковка папки
        }

        public static void pathNameType(string folder)
        {
            int num = folder.Split(new char[] {'\\'}).Length;
            getfiles get = new getfiles();
            List<string> files = get.GetAllFiles(folder);
            var path = new List<string>();
            var name = new List<string>();
            var type = new List<string>();
            using (var File = new FileStream(pathForFile + @"\PathNameType.txt", FileMode.Create))
            foreach (string f in files)
            {

                string[] words = f.Split('\\', '.');//разбиение по \ и .
                int wordsLength = words.Length;
                type.Add(words[wordsLength - 1]);// путь, ибо после точки
                name.Add(words[wordsLength - 2]);//название, ибо между \ и .
                string temp = "";
                for (int i = num; i < wordsLength - 2; i++)
                {
                    temp += words[i] + @"\"; // возвращение к виду Д/папка/

                }
                
                /*if (temp.Length != 0)
                {*/
                path.Add(temp); 
                /*}*/
            }
            var lines = File.ReadAllLines(pathForFile + @"\PathNameType.txt").ToList();
            for (int i = 0; i < path.Count(); i++)
            {
                lines.Add(path[i] + " " + name[i] + " " + type[i]);
            }
            File.WriteAllLines(pathForFile + @"\PathNameType.txt", lines); // записываем путь имя тип
        }

        public static string courseFolderPath, // переменная пути к папке с курсом
                             pathForFile,
                             courseTitle; // название курса  
        public static string[,] Titles,    // [sections, pages]
                                OrgIDref, 
                                OrgHref;
    }

    //class

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