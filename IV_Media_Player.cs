#define IV_FAST_PRE_LOAD_SLOW_POST_LOAD

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
            if (ivmp_ab_slider_volume_info == String.Empty || ivmp_ab_slider_volume_info == null)
                ivmp_ab_slider_volume_info = IV_About_Volume.GetToolTip(IV_MP_Volume_Bar);
            if (ivmp_panel_default_bg_color == Color.Black)
                ivmp_panel_default_bg_color = IV_MP_Main.BackColor;
#if !IV_FAST_PRE_LOAD_SLOW_POST_LOAD
            IV_MP_Release_Slider_Parm();
            IV_MP_INIT_VLC();
            IV_Release_V_UI();
            IV_MP_Init_Video_Check_State();
#endif
        }

        public bool iv_mp_closed = false;
        private static string ivmp_ab_slider_volume_info = String.Empty;
        private static string ivmp_ab_slider_time_info = "Video time controlling Slider.";
        private static Color ivmp_panel_default_bg_color = Color.Black;
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
            ivmp.Fullscreen = false;
            ivmp.EnableKeyInput = false;
            ivmp.EnableMouseInput = false;
            IV_MP_Main.MediaPlayer = ivmp;
            IV_MP_Volume_Bar.Value = ivmp.Volume;
        }

        private void IV_MP_Init_Video_Check_State()
        {
            ivmp.EndReached += IV_Release_Video_on_END;
#if DEBUG
            //ivmp.TimeChanged += IV_MP_Time_Changed_Debug_Test;
#endif
        }
#if DEBUG
        /*private void IV_MP_Time_Changed_Debug_Test(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            MessageBox.Show("IV VLC Video Time is - " + ivmp.Length + ". Currient time is - " + ivmp.Time, IV_Gallery_Main_Menu.thsdev_iv_warning_logo);
        }*/
#endif
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
            IV_Media_Disponse();
        }

        private void IV_MP_Load_Hook(object sender, EventArgs e)
        {
            iv_mp_closed = false;
#if IV_FAST_PRE_LOAD_SLOW_POST_LOAD
            IV_MP_Release_Slider_Parm();
            IV_MP_INIT_VLC();
            IV_Release_V_UI();
            IV_MP_Init_Video_Check_State();
#endif
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
                var media_file_question = "Play this Media?";
                if(iv_fl_path.Contains(".mp3") || iv_fl_path.Contains(".wav"))
                {
                    media_file_question = "Play this Sound?";
                    IV_MP_Main.BackColor = Color.DarkViolet;
                }
                var dlg_question = MessageBox.Show(media_file_question, IV_Gallery_Main_Menu.thsdev_iv_logo + " Media Player Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg_question == DialogResult.Yes)
                {
                    ivmp_stopped = false;
                    IV_About_VLC_Player.Active = false;
                    IV_Release_V_UI();
                    ivmp_vui_toggle = true;
                    ivmp_video_ended = false;
                    ivmp.Play(ivmp_media_temp);
                    IV_MP_T_Video_End_Check.Enabled = true;
                }
                else if (IV_MP_Main.BackColor != ivmp_panel_default_bg_color && (iv_fl_path.Contains(".mp3") || iv_fl_path.Contains(".wav")))
                {
                    IV_MP_Main.BackColor = ivmp_panel_default_bg_color;
                    if (ivmp_media_temp != null)
                        ivmp_video_ended = true;
                    IV_MP_T_Video_End_Check.Enabled = true;
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
                ivmp_stopped = false;
                ivmp.Play();
            }
            else
            {
                ivmp_stopped = true;
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
            if (ivmp.IsPlaying || !ivmp_stopped)
            {
                if (!ivmp_vui_toggle)
                {
                    ivmp_vui_toggle = true;
                    IV_Release_V_UI(false, true);
                }
                else
                {
                    ivmp_vui_toggle = false;
                    IV_Release_V_UI(true);
                }
            }
        }

        private void IV_MP_B_Restart_Click_Hook(object sender, EventArgs e)
        {
            if (ivmp_media_temp != null)
                ivmp.Play(ivmp_media_temp);
            IV_MP_T_Video_End_Check.Enabled = true;
            ivmp_video_ended = false;
            ivmp_stopped = false;
            IV_About_VLC_Player.Active = false;
            IV_Release_V_UI();
        }

        private void IV_MP_B_Stop_Video_Released()
        {
            IV_CB_Toggle_Slider_Func.Checked = false;
            IV_CB_Toggle_Slider_Func.Visible = false;
            IV_MP_Release_Slider_Parm();
            ivmp.Stop();
            if (IV_MP_Main.BackColor != ivmp_panel_default_bg_color)
                IV_MP_Main.BackColor = ivmp_panel_default_bg_color;
            IV_About_VLC_Player.Active = true;
            ivmp_stopped = true;
            IV_MP_B_Stop.Visible = false;
            IV_MP_B_Play.Visible = false;
        }

        private void IV_Release_Video_on_END(object sender, EventArgs e)
        {
            ivmp_video_ended = true;
        }

        private void IV_MP_B_Stop_Click_Hook(object sender, EventArgs e)
        {
            ivmp_video_ended = true;
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
                IV_About_Volume.SetToolTip(IV_MP_Volume_Bar, ivmp_ab_slider_volume_info);
            }
            else
            {
                IV_MP_Volume_Bar.Minimum = 0;
                long time = ivmp.Length;
                IV_MP_Volume_Bar.Maximum = (int)time;
                var iv_vd_track_10 = (int)time * 10 / 100;
                var iv_vd_track_20 = (int)time * 20 / 100;
                IV_MP_Volume_Bar.TickFrequency = iv_vd_track_10;
                IV_MP_Volume_Bar.SmallChange = iv_vd_track_10;
                IV_MP_Volume_Bar.LargeChange = iv_vd_track_20;
                IV_About_Volume.SetToolTip(IV_MP_Volume_Bar, ivmp_ab_slider_time_info);
#if DEBUG
                MessageBox.Show("IV VLC Video Time is - "+ time+". Currient time is - "+ivmp.Time, IV_Gallery_Main_Menu.thsdev_iv_warning_logo);
#endif
            }
        }

        private void IV_CB_Register_Hook(object sender, EventArgs e)
        {
            if (IV_CB_Toggle_Slider_Func.Checked)
                IV_MP_Release_Slider_Parm(true);
            else
                IV_MP_Release_Slider_Parm();
        }

        private void IV_Media_Disponse()
        {
            ivmp.Dispose();
            /*var media_temp = ivmp_media();
            if(media_temp != null)
                media_temp.Dispose();*/
            if(ivmp_media_temp != null)
                ivmp_media_temp.Dispose();
            ivmp.Dispose();
            ivmp_lib.Dispose();
            this.Dispose();
        }

        private bool ivmp_video_ended = true;

        private void IV_T_Video_End_Check_Think(object sender, EventArgs e)
        {
            if(ivmp_video_ended)
            {
                IV_MP_T_Video_End_Check.Enabled = false;
                IV_MP_B_Stop_Video_Released();
            }
        }
    }
}
