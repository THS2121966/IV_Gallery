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
            if (IV_CHECK_MP_Button() || IVCheckerCore.iv_mp_showed)
                IV_B_Music_Player.Visible = false;
        }

        public bool iv_ab_closed_hook = false;

        private void IV_Close_Window_Hook(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IV_About_Closed_Hook(object sender, FormClosedEventArgs e)
        {
            iv_ab_closed_hook = true;
            IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }

        private void IV_Reload_B_Hook(object sender, EventArgs e)
        {
            IV_T_CountDown_To_Restart.Enabled = true;
            IVCheckerCore.iv_ab_hide_hack = true;
            this.Visible = false;
            IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }

        private void IV_T_Restart_Hook(object sender, EventArgs e)
        {
            IV_T_CountDown_To_Restart.Enabled = false;
            Application.Restart();
        }

        private bool IV_CHECK_MP_Button(bool force_status_on = false)
        {
            if (!force_status_on)
            {
                if (IVCheckerCore.iv_music_player_show_hack)
                    return true;
                else
                    return false;
            }
            else
                return force_status_on;
        }

        public void IV_MP_Realise_Music_Button(bool skip_hack = false)
        {
            if(!skip_hack)
                IVCheckerCore.iv_music_player_show_hack = false;
            IV_B_Music_Player.Visible = true;
        }

        private void IV_B_MP_Press_Hook(object sender, EventArgs e)
        {
            if (!IVCheckerCore.iv_music_player_show_hack)
            {
                IVCheckerCore.iv_music_player_show_hack = true;
                IV_B_Music_Player.Visible = false;
            }
        }
    }
}
