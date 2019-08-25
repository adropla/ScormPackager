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
        bool pageIndexIsMatch;
        bool sectionIndexIsMatch;

        public mainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            // красивое расположение окна на экране
            StartPosition = FormStartPosition.Manual;
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            Location = new Point(resolution.Width * 3 / 10, resolution.Height * 3 / 10);

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
            bool error = false;
            bool[] pageIndex = new bool[Program.pages + 1];
            if (sectionsGV.RowCount != 0)
            {
                if (sectionsGV.CurrentRow.Cells[2].Value == null)
                {
                    sectionsGV.CurrentRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    error = true;
                    notificationTB.Text = "Введите данные раздела";
                }
                else
                {
                    if (Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) != 0)
                        if (Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1, 0] != null)
                        {
                            sectionsGV.CurrentRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                            error = true;
                            notificationTB.Text = "Неверный индекс раздела";
                        }
                }

                if (sectionsGV.CurrentRow.Cells[2].Value != null)
                {
                    if (Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) != 0)
                    {
                        if (sectionsGV.CurrentRow.Cells[1].Value == null)
                        {
                            sectionsGV.CurrentRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                            error = true;
                            notificationTB.Text = "Введите данные раздела";
                        }
                        foreach (DataGridViewRow a in pagesGV.Rows)
                        {
                            if (a.Cells[2].Value == null)
                            {
                                a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                                error = true;
                                notificationTB.Text = "Введите индекс страницы";
                            }
                            else
                            {
                                if ((a.Cells[1].Value == null) && (Convert.ToInt32(a.Cells[2].Value.ToString()) != 0))
                                {
                                    a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                                    error = true;
                                    notificationTB.Text = "Введите название страницы";
                                }
                                if (Convert.ToInt32(a.Cells[2].Value.ToString()) > Convert.ToInt32((pagesGV.RowCount.ToString())))
                                {
                                    a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                                    error = true;
                                    notificationTB.Text = "Индекс превышает количество страниц";
                                    break;
                                }
                            }

                            // если есть повторяющиеся индексы в правой колонке, то выделить их
                            if (a.Cells[2].Value != null)
                            {
                                if (pageIndex[Convert.ToInt32(a.Cells[2].Value.ToString())] == true)
                                {
                                    foreach (DataGridViewRow b in pagesGV.Rows)
                                    {
                                        if (b.Cells[2].Value != null)
                                        {
                                            if (b.Cells[2].Value.ToString() == a.Cells[2].Value.ToString())
                                            {
                                                b.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                                            }
                                            else
                                            {
                                                b.DefaultCellStyle.BackColor = SystemColors.Window;
                                            }
                                        }
                                    }
                                    notificationTB.Text = "Повторяющиееся индексы страниц";
                                    error = true;
                                    pageIndexIsMatch = true;
                                }
                                else
                                {
                                    pageIndex[Convert.ToInt32(a.Cells[2].Value.ToString())] = true;
                                    pageIndex[0] = false;
                                }
                            }
                        }
                    }

                    foreach (DataGridViewRow a in sectionsGV.Rows)
                    {
                        if (a.Cells[2].Value != null)
                        {
                            if ((Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) == Convert.ToInt32(a.Cells[2].Value.ToString()))
                                && (sectionsGV.CurrentRow.Index != a.Index))
                            {
                                notificationTB.Text = "Повторяющиееся индексы разделов";
                                error = true;
                                a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                            }
                            else
                            {
                                if (a.DefaultCellStyle.BackColor != Color.FromArgb(192, 255, 192)) a.DefaultCellStyle.BackColor = SystemColors.Window;
                            }
                        }
                    }
                }

                // если есть ошибки, выделить окно уведомлений в красный
                if (error)
                {
                    notificationTB.BackColor = Color.FromArgb(255, 192, 192);
                }
                // если ошибок нет, то происходит запись
                if (!error)
                {
                    if (Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) != 0)
                    {
                        Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1, 0] = sectionsGV.CurrentRow.Cells[1].Value.ToString();
                        foreach (DataGridViewRow a in pagesGV.Rows)
                        {
                            if (Convert.ToInt32(a.Cells[2].Value.ToString()) != 0)
                            {
                                Program.Titles[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1,
                                                Convert.ToInt32(a.Cells[2].Value.ToString())] = a.Cells[1].Value.ToString();
                                Program.OrgIDref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()) - 1,
                                                    Convert.ToInt32(a.Cells[2].Value.ToString()) - 1] = Program.enumer.ToString();
                                Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()),
                                                    Convert.ToInt32(a.Cells[2].Value.ToString()) - 1] = a.Cells[0].Value.ToString();
                                Program.enumer++;
                            }
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (DataGridViewRow a in pagesGV.Rows)
                        {
                            if (a.Cells[2].Value == null)
                            {
                                Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()), i++] = a.Cells[0].Value.ToString();
                            }
                            else Program.OrgHref[Convert.ToInt32(sectionsGV.CurrentRow.Cells[2].Value.ToString()),
                                                Convert.ToInt32(a.Cells[2].Value.ToString()) - 1] = a.Cells[0].Value.ToString();
                        }
                    }
                    sectionsGV.CurrentRow.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);// зелёный
                    sectionsGV.CurrentRow.ReadOnly = true;
                    notificationTB.Text = "Запись прошла успешно";
                    notificationTB.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
            else errors();
        }

        private void sectionsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            notificationTB.Text = "";
            notificationTB.BackColor = SystemColors.Window;
            //заполнение правой таблицы
            string selectedFolder = sectionsGV.CurrentRow.Cells[0].Value.ToString();
            DirectoryInfo info = new DirectoryInfo(Program.courseFolderPath + "\\" + selectedFolder);
            FileInfo[] files = info.GetFiles();
            pagesGV.Rows.Clear();

            try
            {
                if (sectionsGV.CurrentRow.ReadOnly == true)
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
            }
            catch
            {
                foreach (FileInfo f in files)
                {
                    if ((f.Extension == ".html") || (f.Extension == ".js"))
                    {
                        pagesGV.Rows.Add(f.ToString()); // запись в листбокс html и js-файлов из раздела
                    }
                }
            }

            foreach (DataGridViewRow a in sectionsGV.Rows)
            {
                if (a.DefaultCellStyle.BackColor != Color.FromArgb(192, 255, 192)) a.DefaultCellStyle.BackColor = SystemColors.Window;
            }
            pagesGV.AutoResizeColumns();
            pagesGV.Update();
        }

        //bug - после ввода цифр иногда не вводятся буквы
        private void Num_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (pageIndexIsMatch)
            {
                foreach (DataGridViewRow a in pagesGV.Rows)
                {
                    a.DefaultCellStyle.BackColor = SystemColors.Window;
                }
            }
            if (sectionIndexIsMatch)
            {
                foreach (DataGridViewRow a in sectionsGV.Rows)
                {
                    a.DefaultCellStyle.BackColor = SystemColors.Window;
                }
            }

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
            notificationTB.Text = "";
            notificationTB.BackColor = SystemColors.Window;
        }

        private bool errors()
        {
            bool error = false;

            if (Program.courseFolderPath == null)
            {
                textBoxSelectFolder.BackColor = Color.FromArgb(255, 192, 192);
                notificationTB.Text = "Выберите курс";
                notificationTB.BackColor = Color.FromArgb(255, 192, 192);
                return true;
            }

            foreach (DataGridViewRow a in sectionsGV.Rows)
            {
                if (a.ReadOnly != true)
                {
                    a.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                    notificationTB.Text = "Проведите запись всех разделов";
                    error = true;
                }
            }

            if (courseNameTB.Text == "")
            {
                courseNameTB.BackColor = Color.FromArgb(255, 192, 192);
                notificationTB.Text = "Введите название курса";
                error = true;
            }

            if (error)
            {
                notificationTB.BackColor = Color.FromArgb(255, 192, 192);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}