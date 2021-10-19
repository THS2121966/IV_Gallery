using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp;
using LibVLCSharp.Shared;

namespace IV_Gallery
{
    public partial class IV_Media_Player : Form
    {
        public IV_Media_Player()
        {
            InitializeComponent();
            IV_MP_INIT_VLC();
            IV_Release_V_UI();
            IV_MP_Release_Slider_Parm();
        }

        public bool iv_mp_closed = false;
        private bool ivmp_stopped = true;
        private bool ivmp_slider_volume = true;
        
        //VLC stuff
        private LibVLC ivmp_lib;
        private MediaPlayer ivmp;
        private Media ivmp_media_temp;
        private Media ivmp_media(string media_path = null)
        {
            if(media_path != String.Empty && media_path != null)
            {
                ivmp_media_temp = new Media(ivmp_lib, media_path);
                return ivmp_media_temp;
            }
            else
            {
                IV_Gallery_Main_Menu.IV_Release_Problem_Message("Media Result - ERROR!!!");
                IV_Release_V_UI(false, true);
                return null;
            }
        }

        private void IV_MP_INIT_VLC()
        {
            Core.Initialize();
            ivmp_lib = new LibVLC();
            ivmp = new MediaPlayer(ivmp_lib);
            IV_MP_Main.MediaPlayer = ivmp;
            IV_MP_Volume_Bar.Value = ivmp.Volume;
        }

        private void IV_Button_SChange_Press_Hook(object sender, EventArgs e)
        {
            IV_MP_File_Dialog.ShowDialog();
        }

        private void IV_Music_Player_Close_Hook(object sender, FormClosedEventArgs e)
        {
            iv_mp_closed = true;
            ivmp.Stop();
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }

        private void IV_MP_Load_Hook(object sender, EventArgs e)
        {
            iv_mp_closed = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
        }

        private void IV_MP_DLG_Result(object sender, CancelEventArgs e)
        {
            var iv_fl_path = String.Empty;
            iv_fl_path = IV_MP_File_Dialog.FileName;
            if (iv_fl_path.Contains(".mp3") || iv_fl_path.Contains(".wav") || iv_fl_path.Contains(".avi") || iv_fl_path.Contains(".mp4")
                || iv_fl_path.Contains(".mkv"))
            {
                ivmp_media(iv_fl_path);
                var dlg_question = MessageBox.Show("Play this Media?", IV_Gallery_Main_Menu.thsdev_iv_logo + " Media Player Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dlg_question == DialogResult.Yes)
                {
                    ivmp_stopped = false;
                    IV_Release_V_UI();
                    ivmp.Play(ivmp_media_temp);
                }
            }
            else
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_bug_s.Play();
                MessageBox.Show("File no chosed or INVAID!!!", IV_Gallery_Main_Menu.thsdev_iv_logo + " Media Player Dialog");
            }
        }

        private void IV_Release_V_UI(bool force_true = false, bool force_false = false)
        {
            bool hook_true = false;
            if (!ivmp_stopped)
                hook_true = true;
            if (force_true)
                hook_true = force_true;
            if (force_false)
                hook_true = force_true;
            if (hook_true)
            {
                IV_MP_B_Play.Visible = true;
                IV_CB_Toggle_Slider_Func.Visible = true;
                IV_MP_B_Restart_Media.Visible = true;
                IV_MP_B_Stop.Visible = true;
            }
            else
            {
                IV_MP_B_Play.Visible = false;
                IV_CB_Toggle_Slider_Func.Checked = false;
                IV_CB_Toggle_Slider_Func.Visible = false;
                if (ivmp_media_temp == null || force_false)
                    IV_MP_B_Restart_Media.Visible = false;
                IV_MP_B_Stop.Visible = false;
            }
        }

        private void IV_MP_B_PlayStop_Hook(object sender, EventArgs e)
        {
            if(ivmp_stopped)
            {
                ivmp.Play();
            }
            else
            {
                ivmp.Pause();
            }
        }

        private void IV_MP_Volume_Scroll_Hook(object sender, EventArgs e)
        {
            if (ivmp_slider_volume)
                ivmp.Volume = IV_MP_Volume_Bar.Value;
            else
                ivmp.Time = IV_MP_Volume_Bar.Value;
        }

        private bool ivmp_vui_toggle = false;

        private void IV_MP_Main_Click_Hook(object sender, EventArgs e)
        {
            if(!ivmp_vui_toggle)
            {
                ivmp_vui_toggle = true;
                IV_Release_V_UI(false, ivmp_vui_toggle);
            }
            else
            {
                ivmp_vui_toggle = false;
                IV_Release_V_UI(ivmp_vui_toggle, false);
            }
        }

        private void IV_MP_B_Restart_Click_Hook(object sender, EventArgs e)
        {
            if (ivmp_media_temp != null)
                ivmp.Play(ivmp_media_temp);
            IV_Release_V_UI();
        }

        private void IV_MP_B_Stop_Click_Hook(object sender, EventArgs e)
        {
            IV_MP_Release_Slider_Parm();
            IV_CB_Toggle_Slider_Func.Visible = false;
            ivmp.Stop();
            IV_MP_B_Stop.Visible = false;
            IV_MP_B_Play.Visible = false;
        }

        private void IV_MP_Release_Slider_Parm(bool state = false)
        {
            if(!state)
            {
                IV_MP_Volume_Bar.Minimum = 0;
                IV_MP_Volume_Bar.Maximum = 100;
                IV_MP_Volume_Bar.TickFrequency = 10;
                IV_MP_Volume_Bar.SmallChange = 10;
                IV_MP_Volume_Bar.LargeChange = 20;
            }
            else
            {
                IV_MP_Volume_Bar.Minimum = 0;
                var time = ivmp.Time;
                var time_int = int.Parse(time.ToString());
                IV_MP_Volume_Bar.Maximum = time_int;
                var iv_vd_track_10 = time_int * 10 / 100;
                var iv_vd_track_20 = time_int * 20 / 100;
                IV_MP_Volume_Bar.TickFrequency = iv_vd_track_10;
                IV_MP_Volume_Bar.SmallChange = iv_vd_track_10;
                IV_MP_Volume_Bar.LargeChange = iv_vd_track_20;
            }
        }

        private void IV_CB_Register_Hook(object sender, EventArgs e)
        {
            if (IV_CB_Toggle_Slider_Func.Checked)
                IV_MP_Release_Slider_Parm(true);
            else
                IV_MP_Release_Slider_Parm();
        }
    }
}
