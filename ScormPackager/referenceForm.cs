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
    public partial class referenceForm : Form
    {
        public referenceForm()
        {
            InitializeComponent();
            //красивое расположение окна
            StartPosition = FormStartPosition.Manual;
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            Location = new Point(resolution.Width * 7 / 17, resolution.Height * 1 / 8);
            ActiveControl = buttonOK;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
