using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            typeof(Control).GetProperty("DoubleBuffered",
                             System.Reflection.BindingFlags.NonPublic |
                             System.Reflection.BindingFlags.Instance)
               .SetValue(sectionsGV, true, null);
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
                DirectoryInfo info = new DirectoryInfo(Program.courseFolderPath);
                DirectoryInfo[] dirs = info.GetDirectories();
                FileInfo[] files = info.GetFiles();

                sectionsGV.Rows.Clear();
                foreach (DirectoryInfo d in dirs) sectionsGV.Rows.Add(d.ToString());// запись в таблицу папок-разделов
                sectionsGV_CellContentClick(null, new DataGridViewCellEventArgs(0,0));
            }
            ActiveControl = courseLabel;
        }

        private void startPackaging_Click(object sender, EventArgs e)//кнопка упаковки
        {
            notificationForm popOut = new notificationForm();

            Program.courseTitle = courseNameTB.ToString();

            if ((Program.courseFolderPath == null) || (Program.courseTitle == null)) popOut.ShowDialog();// ошибка, если не указан путь к курсу
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
                    Program.clearTemp(Program.courseFolderPath);
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

        private void sectionsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pagesGV.Rows.Clear();

            string selectedFolder = sectionsGV.CurrentRow.Cells[0].Value.ToString();

            DirectoryInfo info = new DirectoryInfo(Program.courseFolderPath + "\\" + selectedFolder);
            FileInfo[] files = info.GetFiles();
            foreach (FileInfo f in files)
            {
                if ((f.Extension == ".html") || (f.Extension == ".js")) pagesGV.Rows.Add(f.ToString()); // запись в листбокс html и js-файлов из раздела
            }
        }

        private void sectionsGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (sectionsGV.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(ColumnNum1_KeyPress);
            }
            else
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress -= ColumnNum1_KeyPress;
            }
        }

        private void pagesGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (pagesGV.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(ColumnNum1_KeyPress);
            }
            else
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress -= ColumnNum1_KeyPress;
            }
        }

        void ColumnNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar != (char)Keys.Back) || (e.KeyChar != (char)Keys.Delete))
                { e.Handled = true; }
            }
        }
    }
}