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
        int sections = 0, pages = 0, enumer = 0;

        public mainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
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
                DirectoryInfo info = new DirectoryInfo(Program.courseFolderPath);
                DirectoryInfo[] dirs = info.GetDirectories();

                int i = 0;
                sectionsGV.Rows.Clear();
                foreach (DirectoryInfo d in dirs)
                {
                    FileInfo[] files = d.GetFiles();
                    foreach (FileInfo f in files)
                    {
                        if ((f.Extension == ".html") || (f.Extension == ".js"))
                            i++;
                    }
                    if (i > pages) pages = i;
                    i = 0;
                    sections++;

                    sectionsGV.Rows.Add(d.ToString());// запись в левую таблицу папок-разделов
                }

                sectionsGV.AutoResizeColumns();
                Program.Titles = new string[sections, pages];
                Program.OrgHref = new string[sections, pages];
                Program.OrgIDref = new string[sections, pages];
                sectionsGV_CellContentClick(null, new DataGridViewCellEventArgs(0, 0));
            }
            ActiveControl = courseLabel;
        }

        private void startPackaging_Click(object sender, EventArgs e)//кнопка упаковки
        {
            notificationForm popOut = new notificationForm();

            Program.courseTitle = courseNameTB.Text.ToString();// название курса в переменную

            if ((Program.courseFolderPath == null) | (Program.courseTitle == ""))
            {
                popOut.ShowDialog();// ошибка, если не указан путь к курсу
            }
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
                    Program.clearTemp(Program.courseFolderPath);// удаляет из начальной папки курса манифест и xsd-файлы
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
            //заполнение правой таблицы
            string selectedFolder = sectionsGV.CurrentRow.Cells[0].Value.ToString();
            DirectoryInfo info = new DirectoryInfo(Program.courseFolderPath + "\\" + selectedFolder);
            FileInfo[] files = info.GetFiles();
            pagesGV.Rows.Clear();
            if ((sectionsGV.CurrentRow.Cells[2].Value != null) && (Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), 0] != null))
            {
                int i = 1;
                while (Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i] != null)
                {
                    string[] row = new string[] { Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i],
                                                  Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i],
                                                  i.ToString() };
                    pagesGV.Rows.Add(row);
                    //pagesGV.Rows[i-1].Cells[0].Value = Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i];
                    //pagesGV.Rows[i-1].Cells[1].Value = Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i];
                    //pagesGV.Rows[i-1].Cells[2].Value = i;
                    i++;
                }
            }
            else
            {
                foreach (FileInfo f in files)
                {
                    if ((f.Extension == ".html") || (f.Extension == ".js"))
                    {
                        pages++;
                        pagesGV.Rows.Add(f.ToString()); // запись в листбокс html и js-файлов из раздела
                    }
                }
            }
            pagesGV.AutoResizeColumns();
            pagesGV.Update();
        }

        //bug - после ввода цифр не вводят буквы
        private void Num_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView a = sender as DataGridView;
            if (a.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(ColumnNum1_KeyPress);
            }
            else
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress -= ColumnNum1_KeyPress;
            }
            a.Update();
        }

        void ColumnNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar != (char)Keys.Back) || (e.KeyChar != (char)Keys.Delete))
                { e.Handled = true; }
            }
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), 0] = sectionsGV.CurrentRow.Cells[1].Value.ToString();
            foreach (DataGridViewRow a in pagesGV.Rows)
            {
                Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()),
                               Convert.ToInt32(a.Cells[2].Value.ToString())] = a.Cells[1].Value.ToString();
                Program.OrgIDref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()),
                                 Convert.ToInt32(a.Cells[2].Value.ToString())] = enumer.ToString();
                Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()),
                                 Convert.ToInt32(a.Cells[2].Value.ToString())] = a.Cells[0].Value.ToString();
                enumer++;
            }
        }

        private void pagesGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}