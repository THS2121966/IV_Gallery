using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IV_Gallery_Checkers_Core
{
    public partial class IV_Checker_Core_AppInfo : Form
    {
        public IV_Checker_Core_AppInfo()
        {
            InitializeComponent();
        }

        public bool iv_ab_closed_hook = false;

        private void IV_Close_Window_Hook(object sender, EventArgs e)
        {
            this.Close();
            IV_Gallery_Checkers_Core.IVCheckerCore.ui_s_wnd_ab_close.Play();
        }

        private void IV_About_Closed_Hook(object sender, FormClosedEventArgs e)
        {
            iv_ab_closed_hook = true;
        }
    }
}
