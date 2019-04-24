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
        public mainForm()
        {
            InitializeComponent();
            // красивое расположение окна на экране
            StartPosition = FormStartPosition.Manual;
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            Location = new Point(resolution.Width * 3 / 8, resolution.Height * 3 / 8);
            ActiveControl = label;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            ActiveControl = label;
        }

        FolderBrowserDialog fbd = new FolderBrowserDialog();
        SaveFileDialog sfd = new SaveFileDialog();

        private void browseButton_Click(object sender, EventArgs e)//обзор
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxSelectFolder.Text = fbd.SelectedPath;
                Program.courseFolderPath = fbd.SelectedPath; // записываем путь к курсу
            }
            ActiveControl = label;
        }

        private void startPackaging_Click(object sender, EventArgs e)// упаковка
        {
            notificationForm popOut = new notificationForm();

            if (Program.courseFolderPath == null) popOut.ShowDialog();// ошибка, если не указан путь к курсу
            else
            {
                sfd.FileName = "archive";// по умолчанию
                sfd.DefaultExt = "zip";
                sfd.Filter = "ZIP-archives (*.zip)|*.zip|All files (*.*)|*.*";
                sfd.OverwritePrompt = true;
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (sfd.ShowDialog() == DialogResult.OK)// если произошло сохранение архива
                {
                    this.UseWaitCursor = true;
                    Program.packageSavePath = sfd.FileName.Remove(sfd.FileName.LastIndexOf('\\')); 
                    Program.zipFolder(Program.courseFolderPath, sfd.FileName);// архивирование
                    Program.pathNameType(Program.courseFolderPath, Program.packageSavePath);// файл с путями ко всем файлам
                    popOut.ShowDialog();// запуск формы уведомлений
                }
            }
            this.UseWaitCursor = false;
            ActiveControl = label;
        }

        private void programmReference_Click(object sender, EventArgs e)// вызов справки
        {
            referenceForm popOutRef = new referenceForm();
            popOutRef.ShowDialog();
            ActiveControl = label;
        }
    }
}
