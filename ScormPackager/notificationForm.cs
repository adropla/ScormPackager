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
    public partial class notificationForm : Form
    {
        public notificationForm()
        {
            InitializeComponent();
            //красивое расположение окна
            StartPosition = FormStartPosition.Manual;
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            Location = new Point(resolution.Width * 4 / 9, resolution.Height * 4 / 10);
            //ошибка, если не указан путь с курсом
            if (Program.courseFolderPath == null)
            {
                label.Location = new Point(23, 0);
                label.Text = "Ошибка!\nУкажите папку с курсом";
            }
            else if (Program.courseTitle == null)
            {
                label.Location = new Point(23, 0);
                label.Text = "Ошибка!\nУкажите название курса";
            }
            else
                label.Text = "Упаковка выполена успешно!";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
