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
                textBoxSelectFolder.BackColor = SystemColors.ButtonHighlight;
                courseNameTB.BackColor = SystemColors.ButtonHighlight;
                courseNameTB.Text = "";

                int i = 0;
                Program.sections = 0; Program.pages = 0;
                sectionsGV.Rows.Clear();
                foreach (DirectoryInfo d in dirs)
                {
                    FileInfo[] files = d.GetFiles();
                    foreach (FileInfo f in files)
                    {
                        if ((f.Extension == ".html") || (f.Extension == ".js")) i++;
                    }
                    if (i > Program.pages) Program.pages = i;
                    i = 0;
                    Program.sections++;

                    sectionsGV.Rows.Add(d.ToString());// запись в левую таблицу папок-разделов
                }
                
                Program.Titles = new string[Program.sections, Program.pages + 1];// в [i, 0] записывает название раздела
                Program.OrgHref = new string[Program.sections + 1, Program.pages];// в [0, i] записываются ссылки из папки shared
                Program.OrgIDref = new string[Program.sections, Program.pages];
                sectionsGV.AutoResizeColumns();
                sectionsGV.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
                sectionsGV.DefaultCellStyle.SelectionForeColor = Color.Black;
                pagesGV.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
                pagesGV.DefaultCellStyle.SelectionForeColor = Color.Black;
                sectionsGV_CellContentClick(null, new DataGridViewCellEventArgs(0, 0));
            }
            ActiveControl = courseLabel;
        }

        private void startPackagingButton_Click(object sender, EventArgs e)//кнопка упаковки
        {
            notificationForm popOut = new notificationForm();
            
            if (!errors()) // если нет ошибок, то начинается упаковка
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
                    Program.courseTitle = courseNameTB.Text.ToString();// название курса в переменную
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

        private void referenceButton_Click(object sender, EventArgs e)// вызов справки
        {
            referenceForm popOutRef = new referenceForm();
            popOutRef.ShowDialog();
            ActiveControl = courseLabel;
        }

        private void writeButton_Click(object sender, EventArgs e)// запись организации
        {
            if (sectionsGV.RowCount != 0)
            {
                // проверка на ошибки
                bool error = false; 
                if (sectionsGV.CurrentRow.Cells[2].Value == null)
                {
                    sectionsGV.CurrentRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    error = true;
                }
                foreach (DataGridViewRow a in pagesGV.Rows)
                {
                    if (a.Cells[2].Value == null)
                    {
                        a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                        error = true;
                    }
                    else if ((a.Cells[2].Value.ToString() != "0") && (a.Cells[1].Value == null))
                    {
                        a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                        error = true;
                    }
                }
                // если ошибок нет, то проиходит запись
                if (!error)
                {
                    Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1, 0] = sectionsGV.CurrentRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow a in pagesGV.Rows)
                    {
                        Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1,
                                       Convert.ToInt32(a.Cells[2].Value.ToString())] = a.Cells[1].Value.ToString();
                        Program.OrgIDref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1,
                                         Convert.ToInt32(a.Cells[2].Value.ToString()) - 1] = Program.enumer.ToString();
                        Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()),
                                         Convert.ToInt32(a.Cells[2].Value.ToString()) - 1] = a.Cells[0].Value.ToString();
                        Program.enumer++;
                    }
                    sectionsGV.CurrentRow.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);// зелёный
                }
            }
            else errors();
        }

        private void sectionsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //заполнение правой таблицы
            string selectedFolder = sectionsGV.CurrentRow.Cells[0].Value.ToString();
            DirectoryInfo info = new DirectoryInfo(Program.courseFolderPath + "\\" + selectedFolder);
            FileInfo[] files = info.GetFiles();
            pagesGV.Rows.Clear();
            if ((sectionsGV.CurrentRow.Cells[2].Value != null) && (Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1, 0] != null))
            {
                for (int i = 0; i < Program.pages; i++)
                {
                    if (Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i] != null)
                    {
                        string[] row = new string[] { Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i],
                                                      Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1, i + 1],
                                                      (i+1).ToString() };
                        pagesGV.Rows.Add(row);
                    }
                }
            }
            else
            {
                foreach (FileInfo f in files)
                {
                    if ((f.Extension == ".html") || (f.Extension == ".js"))
                    {
                        pagesGV.Rows.Add(f.ToString()); // запись в листбокс html и js-файлов из раздела
                    }
                }
            }
            pagesGV.AutoResizeColumns();
            pagesGV.Update();
        }

        //bug - после ввода цифр иногда не вводятся буквы
        private void Num_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            (sender as DataGridView).CurrentRow.DefaultCellStyle.BackColor = SystemColors.Window;
            if ((sender as DataGridView).CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(ColumnNum1_KeyPress);
            }
            else
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress -= ColumnNum1_KeyPress;
            }
            (sender as DataGridView).Update();
        }

        void ColumnNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar != (char)Keys.Back) || (e.KeyChar != (char)Keys.Delete))
                { e.Handled = true; }
            }
        }

        private void courseNameTB_TextChanged(object sender, EventArgs e)
        {
            courseNameTB.BackColor = SystemColors.ButtonHighlight;
        }

        private bool errors()
        {
            bool flag = false;
            if (Program.courseFolderPath == null)
            {   
                textBoxSelectFolder.BackColor = Color.FromArgb(255, 192, 192);
                return true;
            }
            if (courseNameTB.Text == "")
            {
                courseNameTB.BackColor = Color.FromArgb(255, 192, 192);
                flag = true;
            }
            foreach (DataGridViewRow a in sectionsGV.Rows)
            {
                if (a.Cells[2].Value == null)
                {
                    a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    flag = true;
                }
                else if ((a.Cells[2].Value.ToString() != "0") && (a.Cells[1].Value == null))
                {
                    a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    flag = true;
                }
            }

            if (flag) return true;
            else return false;
        }
    }
}