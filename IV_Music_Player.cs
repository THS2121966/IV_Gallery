using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IV_Gallery
{
    public partial class IV_Music_Player : Form
    {
        public IV_Music_Player()
        {
            InitializeComponent();
        }

        public bool iv_mp_closed = false;

        private void IV_Button_SChange_Press_Hook(object sender, EventArgs e)
        {

        }

        private void IV_Music_Player_Close_Hook(object sender, FormClosedEventArgs e)
        {
            iv_mp_closed = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }

        private void IV_MP_Load_Hook(object sender, EventArgs e)
        {
            iv_mp_closed = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
        }
    }
}
