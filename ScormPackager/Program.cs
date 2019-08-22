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
            File.Delete(pathForFile + @"\PathNameType.txt");
        }
        
        public static void manifest(string path) // манифест
        {
            int sectionNumerator = 1, pageNumerator = 1;
            XmlDocument manifest = new XmlDocument();
            XmlDeclaration xmlDeclaration = manifest.CreateXmlDeclaration("1.0", "utf-8", "no");
            manifest.AppendChild(xmlDeclaration);
            
            // тег manifest
            XmlElement manifestElement = manifest.CreateElement("manifest");
            // атрибуты тега manifest ? сделать переносы атрибутов на новую строку
            manifestElement.SetAttribute("identifier", "com.scorm.golfsamples.contentpackaging.multioscosinglefile.12");
            manifestElement.SetAttribute("version", "1");
            manifestElement.SetAttribute("xmlns", "http://www.imsproject.org/xsd/imscp_rootv1p1p2");
            manifestElement.SetAttribute("xmlns:adlcp", "http://www.adlnet.org/xsd/adlcp_rootv1p2");
            manifestElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            // ? сделать переносы аргумента
            manifestElement.SetAttribute("xsi:schemaLocation", "http://www.imsproject.org/xsd/imscp_rootv1p1p2 imscp_rootv1p1p2.xsd http://www.imsglobal.org/xsd/imsmd_rootv1p2p1 imsmd_rootv1p2p1.xsd http://www.adlnet.org/xsd/adlcp_rootv1p2 adlcp_rootv1p2.xsd");

            //metadata
            XmlElement metadata = manifest.CreateElement("metadata");
            XmlElement schema = manifest.CreateElement("schema");
            schema.InnerText = "ADL SCORM";
            XmlElement schemaversion = manifest.CreateElement("schemaversion");
            schemaversion.InnerText = "1.2";
            metadata.AppendChild(schema);
            metadata.AppendChild(schemaversion);
            manifestElement.AppendChild(metadata);

            //organizations
            // ? сделать определение опроса 
            XmlElement organizations = manifest.CreateElement("organizations");
            XmlElement organization = manifest.CreateElement("organization");
            XmlElement orgTitle = manifest.CreateElement("title");
            orgTitle.InnerText = Program.courseTitle;
            organization.AppendChild(orgTitle);

            for (int i = 0; i < sections; i++)
            {
                XmlElement sectionItem = manifest.CreateElement("item");
                sectionItem.SetAttribute("identifier", "section" + (sectionNumerator++).ToString());
                XmlElement sectionTitle = manifest.CreateElement("title");
                sectionTitle.InnerText = Titles[i, 0];
                sectionItem.AppendChild(sectionTitle);
                for (int j = 0; j < pages; j++)
                {
                    if (Program.OrgIDref[i, j] != null)
                    {
                        XmlElement pageItem = manifest.CreateElement("item");
                        XmlElement pageTitle = manifest.CreateElement("title");
                        XmlText pageTextTitle = manifest.CreateTextNode(Titles[i, j]);
                        pageTitle.AppendChild(pageTextTitle);// Название страницы
                        pageItem.AppendChild(pageTitle);
                        pageItem.SetAttribute("identifier", "page" + (pageNumerator++).ToString());
                        XmlAttribute identifierref = manifest.CreateAttribute("identifierref");
                        identifierref.InnerText = Program.OrgIDref[i, j];
                        pageItem.Attributes.Append(identifierref);
                        sectionItem.AppendChild(pageItem);
                    }
                }
                organization.AppendChild(sectionItem);
            }
            // атрибуты organisation
            XmlAttribute orgIdentifier = manifest.CreateAttribute("identifier");
            XmlText orgIdentifierText = manifest.CreateTextNode("default_organization");
            orgIdentifier.AppendChild(orgIdentifierText);
            organization.Attributes.Append(orgIdentifier);
            organizations.AppendChild(organization);
            // атрибуты organisations
            XmlAttribute Default = manifest.CreateAttribute("default");
            XmlText defaultText = manifest.CreateTextNode("default_organization");
            Default.AppendChild(defaultText);
            organizations.Attributes.Append(Default);
            manifestElement.AppendChild(organizations);

            //resources
            // в dependecy записываются все i-файлы из OrgHref[0, i](там все файлы из папки shared, если она вообще есть)
            XmlElement resources = manifest.CreateElement("resources", "http://www.imsproject.org/xsd/imscp_rootv1p1p2"); 
            var files = File.ReadAllLines(pathForFile + @"\PathNameType.txt").ToList();
            var filesSplit = new List<string[]>();  //0 path 1 name 2 type
            for (int i = 0; i < files.Count; i++)
            {
                filesSplit.Add(files[i].Split(' '));
            }
            for (int i = 0; i < filesSplit.Count; i++)
            {
                if ((filesSplit[i][2] == "html") || (filesSplit[i][2] == "js"))
                {
                    XmlElement file = manifest.CreateElement("file", "http://www.imsproject.org/xsd/imscp_rootv1p1p2");
                    XmlElement resource = manifest.CreateElement("resource", "http://www.imsproject.org/xsd/imscp_rootv1p1p2");
                    XmlAttribute type = manifest.CreateAttribute("type");
                    XmlText webcontent = manifest.CreateTextNode("webcontent");
                    type.AppendChild(webcontent);
                    XmlAttribute identifier = manifest.CreateAttribute("identifier");
                    //id берётся из OrgIDref сопоставляя с массивом OrgHref
                    //например, OrgHref[1,1] = "course.html" , OrgIDref[1,1] = 5;
                    //значит id файла "course.html" равно что ты пидор ёпта
                    XmlText id = manifest.CreateTextNode(i.ToString());//?
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

            manifestElement.AppendChild(resources);
            manifest.AppendChild(manifestElement);
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
        public static int sections = 0, pages = 0, enumer = 0;
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