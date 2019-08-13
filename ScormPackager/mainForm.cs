using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScormPackager
{
    public partial class mainForm : Form
    {
        FolderBrowserDialog courseFolderDialog = new FolderBrowserDialog();
        SaveFileDialog savingPackageDialog = new SaveFileDialog();
        OpenFileDialog ofd = new OpenFileDialog();

        public mainForm()
        {
            InitializeComponent();
            // красивое расположение окна на экране
            StartPosition = FormStartPosition.Manual;
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            Location = new Point(resolution.Width * 3 / 8, resolution.Height * 3 / 8);
            ActiveControl = courseLabel;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            ActiveControl = courseLabel;// перевод фокуса на надпись
        }

        private void browseButton_Click(object sender, EventArgs e)//обзор курса
        {
            if (courseFolderDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSelectFolder.Text = courseFolderDialog.SelectedPath;
                Program.courseFolderPath = courseFolderDialog.SelectedPath; // записываем путь к курсу в глобальную переменную
            }
            ActiveControl = courseLabel;
        }

        private void browseStartPageButton_Click(object sender, EventArgs e)// обзор статартовой html страницы
        {
            if (courseFolderDialog.SelectedPath != null) ofd.InitialDirectory = courseFolderDialog.SelectedPath;
            ofd.Filter = "HTML files (*.html;*.htm)|*.html;*.htm|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxSelectStartPage.Text = ofd.FileName;
                Program.startPagePath = ofd.FileName; // записываем путь к стартовой странице в глобальную переменную
            }
            ActiveControl = courseLabel;
        }

        private void startPackaging_Click(object sender, EventArgs e)//кнопка упаковки
        {
            notificationForm popOut = new notificationForm();

            if (Program.courseFolderPath == null) popOut.ShowDialog();// ошибка, если не указан путь к курсу
            else
            {
                savingPackageDialog.FileName = "archive" + DateTime.Now.ToString("HHmmsstt");// название архива по умолчанию
                savingPackageDialog.DefaultExt = "zip";
                savingPackageDialog.Filter = "ZIP-archives (*.zip)|*.zip|All files (*.*)|*.*";
                savingPackageDialog.OverwritePrompt = true;
                savingPackageDialog.RestoreDirectory = true;
                savingPackageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (savingPackageDialog.ShowDialog() == DialogResult.OK)// если произошло сохранение архива
                {
                    this.UseWaitCursor = true;
                    Program.pathForFile = savingPackageDialog.FileName.Remove(savingPackageDialog.FileName.LastIndexOf('\\'));
                    Program.pathNameType(Program.courseFolderPath);// файл с путями ко всем файлам
                    Program.manifest(Program.courseFolderPath);// создание манифеста
                    Program.copyXSDfiles(Program.courseFolderPath);// копирование xsd-файлов из ресурсов в папку курса
                    Program.zipFolder(Program.courseFolderPath, savingPackageDialog.FileName);// архивирование
                    Program.clearTemp(Program.courseFolderPath);// удаляет из папки курса манифест и xsd-файлы
                    popOut.ShowDialog();// запуск формы уведомлений
                }
            }

            this.UseWaitCursor = false;
            ActiveControl = courseLabel;
        }

        private void programmReference_Click(object sender, EventArgs e)// вызов справки
        {
            referenceForm popOutRef = new referenceForm();
            popOutRef.ShowDialog();
            ActiveControl = courseLabel;
        }
    }
}
