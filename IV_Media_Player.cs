#if !DEBUG
#define IV_FAST_PRE_LOAD_SLOW_POST_LOAD
#endif

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

using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;

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
            if (iv_mp_search_button_text_local == String.Empty)
            {
                iv_mp_search_button_text_local = IV_B_Chose_Media.Text;
                iv_mp_search_button_text_url = "Chose URL";
            }
#if !IV_FAST_PRE_LOAD_SLOW_POST_LOAD
            IV_MP_Release_Slider_Parm();
            IV_MP_Release_Local_or_URL_Search_Method();
            IV_MP_INIT_VLC();
            IV_Release_V_UI();
            IV_MP_Init_Video_Check_State();
#endif
        }

        public bool iv_mp_closed = false;
        private static string ivmp_ab_slider_volume_info = String.Empty;
        private static readonly string ivmp_ab_slider_time_info = "Video time controlling Slider.";
        private static Color ivmp_panel_default_bg_color = Color.Black;
        private bool ivmp_stopped = true;
        private bool ivmp_slider_volume = true;
        private bool ivmp_media_sound = false;
        private IV_MP_Tool_Chose_Internet_Video iv_url_manager = new IV_MP_Tool_Chose_Internet_Video();
        private static readonly string[] ivmp_video_formats = new string[3] {".mp4",".avi",".mkv"};
        private static readonly string[] ivmp_audio_formats = new string[2] {".mp3",".wav"};
        //private string ivmp_last_used_path = String.Empty; //IV note: Deprecated variable.
        private bool ivmp_video_was_url = false;
        
        //VLC Main Panel parms:
        private LibVLC ivmp_lib;
        private MediaPlayer ivmp;
        private Media ivmp_media_temp;

        //VLC Sound wave panel parms:
        private LibVLC ivmp_wave_lib;
        private MediaPlayer ivmp_wave;
        private Media ivmp_media_wave;

        /*static readonly private System.Reflection.Assembly iv_media_programm_center = System.Reflection.Assembly.GetExecutingAssembly();
        static readonly private System.IO.Stream iv_media_wave_dir = iv_media_programm_center.GetManifestResourceStream(@"IV_Gallery.iv_media_cache.media_wave.mp4");*/

        private Media Ivmp_media(string media_path = null, bool url_link = false)
        {
            if(media_path != String.Empty && media_path != null)
            {
                if(!url_link)
                    ivmp_media_temp = new Media(ivmp_lib, media_path);
                else
                {
                    Uri temp_media_url = new Uri("https://vk.com/id504177837");
                    Uri.TryCreate(temp_media_url, media_path, out Uri MediaTested);
#if DEBUG
                    MessageBox.Show("IV URL Media Path is - "+ MediaTested, IV_Gallery_Main_Menu.thsdev_iv_warning_logo);
#endif
                    ivmp_media_temp = new Media(ivmp_lib, MediaTested);
                }
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
            ///////////////////////////////
            //IV Note: Main Video Panel.//
            /////////////////////////////
            ivmp_lib = new LibVLC();
            ivmp = new MediaPlayer(ivmp_lib)
            {
                Fullscreen = false,
                EnableKeyInput = false,
                EnableMouseInput = false
            };
            IV_MP_Main.MediaPlayer = ivmp;

            /////////////////////////////////////
            //IV Note: Sound wave Video Panel.//
            ///////////////////////////////////
            ivmp_wave_lib = new LibVLC();
            ivmp_wave = new MediaPlayer(ivmp_wave_lib)
            {
                Fullscreen = false,
                EnableKeyInput = false,
                EnableMouseInput = false
            };
            IV_MP_Sound_Wave_Panel.MediaPlayer = ivmp_wave;
            ivmp_media_wave = new Media(ivmp_wave_lib, "./iv_media_cache/media_wave.mp4");

            if (ivmp.Volume <= IV_MP_Volume_Bar.Maximum)
                IV_MP_Volume_Bar.Value = ivmp.Volume;
        }

        private void IV_MP_Init_Video_Check_State()
        {
            ivmp.EndReached += IV_Release_Video_on_END;
            ivmp.EncounteredError += IV_MP_Realised_ERROR_State;
            ivmp_wave.EndReached += IV_MP_Wave_Check_End;
            //IV_MP_T_Video_Time_Show.Enabled = true;
            //ivmp.TimeChanged += IV_MP_Time_Control_Think; //IV Note: Not working with single thread.
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
            if (!iv_mp_search_url)
                IV_MP_File_Dialog.ShowDialog();
            else
            {
                if (!iv_url_manager.iv_imf_inited)
                    iv_url_manager = new IV_MP_Tool_Chose_Internet_Video();
                iv_url_manager.Visible = true;
                if(!iv_mp_new_ui)
                    IV_B_Chose_Media.Visible = false;
                else
                    IV_MP_Realise_Buttons_Anim(IV_B_Chose_Media, true);
                IV_MP_T_Check_URL_State.Enabled = true;
            }
        }

        private enum IV_MP_States_Problems_State
        {
            state_1 = 0,
            state_2 = 1,
            state_3 = 2
        }

        private struct IV_MP_States
        {
            public int state_1_number;
            public string state_2_problem_msg;
        }

        private void IV_MP_Realised_ERROR_State(object sender, EventArgs e)
        {
            IV_MP_States state_reason;

            string iv_media_state = ivmp.Media.State.ToString();
            if(ivmp.Media.Mrl != String.Empty || ivmp.Media.Mrl != null)
                state_reason.state_1_number = (int)IV_MP_States_Problems_State.state_2;
            else
                state_reason.state_1_number = (int)IV_MP_States_Problems_State.state_1;
            state_reason.state_2_problem_msg = "Invaid Link!!!";
            string iv_media_state_url = ivmp.Media.Mrl;

            string iv_video_problem_msg;

            if (state_reason.state_1_number != 0)
            {
                iv_video_problem_msg = "Currient Video state is - " + iv_media_state + ". Reason - " + state_reason.state_2_problem_msg
    + " Video URL - " + iv_media_state_url;
            }
            else
            {
                iv_video_problem_msg = "Currient Video state is - " + iv_media_state + ". Reason - " + state_reason.state_2_problem_msg;
            }

            IV_Gallery_Main_Menu.IV_Release_Problem_Message(iv_video_problem_msg);

            ivmp_video_ended = true;
        }

        bool ivmp_slider_timecontrol_changing = false;

        private void IV_MP_Time_Control_Think(object sender, EventArgs e) //(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            if(!ivmp_slider_volume && !ivmp_slider_timecontrol_changing)
            {
                IV_MP_Volume_Bar.Value = (int)ivmp.Time;
            }
            else if(ivmp_slider_timecontrol_changing)
            {
                IV_MP_T_Change_Time_Interval.Enabled = true;
            }
            var currient_time_texted = String.Empty;
            int time_seconds = (int)ivmp.Time / 1000;
            int time_minutes = time_seconds / 60;
            int time_hours = time_minutes / 60;
            if (ivmp.Time > 1000)
                if (ivmp.Time < 60000)
                    currient_time_texted = "00:00:"+ time_seconds;
                else if(ivmp.Time < 3600000)
                    currient_time_texted = "00:" + time_minutes + ":"+ (time_seconds - 60 * time_minutes);
                else if (ivmp.Time >= 3600000)
                    currient_time_texted = time_hours + ":" + (time_minutes - 60 * time_hours) + ":" + (time_seconds - 60 * time_minutes);
            IV_MP_Time_Display_Texted.Text = currient_time_texted;
        }

        private void IV_Music_Player_Close_Hook(object sender, FormClosedEventArgs e)
        {
            iv_url_manager.Close();
            iv_mp_closed = true;
            ivmp.Stop();
            ivmp_wave.Stop();
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            IV_Media_Disponse();
        }

        private void IV_MP_Load_Hook(object sender, EventArgs e)
        {
            iv_mp_closed = false;
#if IV_FAST_PRE_LOAD_SLOW_POST_LOAD
            IV_MP_Release_Slider_Parm();
            IV_MP_Release_Local_or_URL_Search_Method();
            IV_MP_INIT_VLC();
            IV_Release_V_UI();
            IV_MP_Init_Video_Check_State();
#endif
            this.FormBorderStyle = FormBorderStyle.Sizable;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
        }

        private bool IV_media_check_format(string path_check, bool only_audio = false)
        {
            if(!only_audio)
            {
                if (path_check.Contains(ivmp_audio_formats[0]) || path_check.Contains(ivmp_audio_formats[1]) || path_check.Contains(ivmp_video_formats[0])
                    || path_check.Contains(ivmp_video_formats[1]) || path_check.Contains(ivmp_video_formats[2]))
                    return true;
                else
                    return false;
            }
            else
            {
                if (path_check.Contains(ivmp_audio_formats[0]) || path_check.Contains(ivmp_audio_formats[1]))
                    return true;
                else 
                    return false;
            }
        }

        private void IV_MP_DLG_Result(object sender, CancelEventArgs e)
        {
            string iv_fl_path = IV_MP_File_Dialog.FileName;
            if (IV_media_check_format(iv_fl_path))
            {
                if(ivmp_media_temp == null)
                    Ivmp_media(iv_fl_path);
                //ivmp_last_used_path = iv_fl_path;
                string media_file_question = "Play this Media?";
                var iv_media_sound_temp = false;
                if(IV_media_check_format(iv_fl_path, true))
                {
                    iv_media_sound_temp = true;
                    media_file_question = "Play this Sound?";
                    IV_MP_Main.BackColor = Color.Black;
                }
                var dlg_question = MessageBox.Show(media_file_question, IV_Gallery_Main_Menu.thsdev_iv_logo + " Media Player Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg_question == DialogResult.Yes)
                {
                    if (ivmp_media_temp != null)
                        Ivmp_media(iv_fl_path);

                    IV_MP_Play_Video(iv_media_sound_temp);
                }
                else if (IV_MP_Main.BackColor != ivmp_panel_default_bg_color && !ivmp_media_sound && !ivmp.IsPlaying)
                {
                    IV_MP_Main.BackColor = ivmp_panel_default_bg_color;
                }
                else if(ivmp_media_sound)
                {
                    if (ivmp_media_temp != null && ivmp.IsPlaying)
                    {
                        ivmp_video_ended = true;
                        IV_MP_T_Video_End_Check.Enabled = true;
                    }
                }
                else if(ivmp_media_temp == null)
                {
                    ivmp_media_sound = false;
                    IV_MP_Main.BackColor = ivmp_panel_default_bg_color;
                }
            }
            else
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_bug_s.Play();
                MessageBox.Show("File no chosed or INVAID!!!", IV_Gallery_Main_Menu.thsdev_iv_logo + " Media Player Dialog");
            }
        }

        private void IV_MP_Play_Video(bool was_sound, bool url_method = false)
        {
            if (!url_method)
            {
                ivmp_stopped = false;
                ivmp_video_was_url = false;
                IV_About_VLC_Player.Active = false;
                IV_MP_Time_Display_Texted.Text = "00:00:00";
                IV_Release_V_UI();
                if (!was_sound)
                {
                    ivmp_media_sound = false;
                    ivmp_wave.Stop();
                    IV_MP_Sound_Wave_Panel.Visible = false;
                    ivmp_wave_ended = false;
                    IV_T_Video_Wave_Check_Stopped.Enabled = false;
                    IV_MP_Main.BackColor = ivmp_panel_default_bg_color;
                    if(iv_mp_new_ui)
                    {
                        IV_MP_Realise_Buttons_Anim(IV_MP_Volume_Bar, true, true, Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles, 450);
                        IV_MP_Realise_Buttons_Anim(IV_MP_Volume_Bar, false, true, Siticone.Desktop.UI.AnimatorNS.AnimationType.Scale, 350);
                        IV_Release_V_UI(true);
                    }
                }
                else
                {
                    ivmp_media_sound = true;
                    IV_MP_Sound_Wave_Panel.Visible = true;
                    ivmp_wave.Play(ivmp_media_wave);
                    IV_T_Video_Wave_Check_Stopped.Enabled = true;
                }
                ivmp_vui_toggle = true;
                ivmp_video_ended = false;
                ivmp.Play(ivmp_media_temp);
                IV_MP_T_Video_Time_Show.Enabled = true;
                IV_MP_T_Video_End_Check.Enabled = true;
            }
            else
            {
                ivmp_stopped = false;
                ivmp_media_sound = false;
                ivmp_video_was_url = true;
                IV_About_VLC_Player.Active = false;
                IV_Release_V_UI();
                ivmp_vui_toggle = true;
                ivmp_video_ended = false;
                Ivmp_media(iv_mp_url_link, true);
                var url_media = ivmp_media_temp;
                ivmp.Play(url_media);
                IV_MP_T_Video_Time_Show.Enabled = true;
                IV_MP_T_Video_End_Check.Enabled = true;
            }
            if (IV_CB_Toggle_Slider_Func.Checked)
                IV_CB_Toggle_Slider_Func.Checked = false;
        }

        private void IV_MP_Realise_Buttons_Anim(Control controlled_object, bool hide = false, bool video_panel = false, Siticone.Desktop.UI.AnimatorNS.AnimationType 
            anim = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles, int interval = 1000)
        {
            var iv_b_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
            {
                MaxAnimationTime = interval,
                AnimationType = anim
            };

            if(!hide)
            {
                if(!video_panel)
                    iv_b_anim.Show(controlled_object);
                else
                    iv_b_anim.ShowSync(controlled_object);
            }
            else
            {
                if (!video_panel)
                    iv_b_anim.Hide(controlled_object);
                else
                    iv_b_anim.HideSync(controlled_object);
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
                if (!iv_mp_new_ui)
                {
                    IV_MP_Time_Display_Texted.Visible = true;
                    IV_MP_B_Play.Visible = true;
                    IV_CB_Toggle_Slider_Func.Visible = true;
                    IV_MP_B_Restart_Media.Visible = true;
                    IV_MP_B_Stop.Visible = true;
                }
                else
                {
                    IV_MP_Realise_Buttons_Anim(IV_MP_Time_Display_Texted, false, false, Siticone.Desktop.UI.AnimatorNS.AnimationType.Transparent);
                    IV_MP_Realise_Buttons_Anim(IV_MP_B_Play, false, false ,Siticone.Desktop.UI.AnimatorNS.AnimationType.Scale);
                    IV_MP_Realise_Buttons_Anim(IV_CB_Toggle_Slider_Func);
                    IV_MP_Realise_Buttons_Anim(IV_MP_B_Restart_Media);
                    IV_MP_Realise_Buttons_Anim(IV_MP_B_Stop, false, false ,Siticone.Desktop.UI.AnimatorNS.AnimationType.Scale);
                }
            }
            else
            {
                if(!iv_mp_new_ui)
                {
                    IV_MP_Time_Display_Texted.Visible = false;
                    IV_MP_B_Play.Visible = false;
                    IV_CB_Toggle_Slider_Func.Checked = false;
                    IV_CB_Toggle_Slider_Func.Visible = false;
                    if (ivmp_media_temp == null || force_false)
                        IV_MP_B_Restart_Media.Visible = false;
                    IV_MP_B_Stop.Visible = false;
                }
                else
                {
                    IV_MP_Realise_Buttons_Anim(IV_MP_Time_Display_Texted, true, false, Siticone.Desktop.UI.AnimatorNS.AnimationType.Transparent);
                    IV_MP_Realise_Buttons_Anim(IV_MP_B_Play, true, false ,Siticone.Desktop.UI.AnimatorNS.AnimationType.Scale);
                    IV_CB_Toggle_Slider_Func.Checked = false;
                    IV_MP_Realise_Buttons_Anim(IV_CB_Toggle_Slider_Func, true);
                    if (ivmp_media_temp == null || force_false)
                        IV_MP_Realise_Buttons_Anim(IV_MP_B_Restart_Media, true);
                    IV_MP_Realise_Buttons_Anim(IV_MP_B_Stop, true, false ,Siticone.Desktop.UI.AnimatorNS.AnimationType.Scale);
                }
            }
        }

        private void IV_MP_B_PlayStop_Hook(object sender, EventArgs e)
        {
            if(ivmp_stopped)
            {
                ivmp_stopped = false;
                ivmp.Play();
                if (ivmp_media_sound)
                    ivmp_wave.Play();
            }
            else
            {
                ivmp_stopped = true;
                ivmp.Pause();
                if (ivmp_media_sound)
                    ivmp_wave.Pause();
            }
        }

        private void IV_MP_Volume_Scroll_Hook(object sender, EventArgs e)
        {
            if (ivmp_slider_volume)
                ivmp.Volume = IV_MP_Volume_Bar.Value;
            else
            {
                ivmp.Time = IV_MP_Volume_Bar.Value;
                ivmp_slider_timecontrol_changing = true;
            }
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
            if (ivmp_media_temp != null && !ivmp_video_was_url)
                ivmp.Play(ivmp_media_temp);
            else if (ivmp_video_was_url && ivmp_media_temp != null)
            {
                MessageBox.Show("Currient Media URL is - "+ivmp_media_temp.Mrl,IV_Gallery_Main_Menu.thsdev_iv_warning_logo);
                ivmp.Play(ivmp_media_temp);
            }
            if (ivmp_media_sound)
            {
                IV_MP_Sound_Wave_Panel.Visible = true;
                ivmp_wave.Play(ivmp_media_wave);
                IV_T_Video_Wave_Check_Stopped.Enabled = true;
            }
            IV_MP_T_Video_End_Check.Enabled = true;
            ivmp_video_ended = false;
            ivmp_stopped = false;
            IV_MP_T_Video_Time_Show.Enabled = true;
#if DEBUG
            IV_Check_Process_Window iv_p_state = new IV_Check_Process_Window();
            iv_p_state.IV_DBG_Release_State("IV_MP_B_Restart_Click_Hook(object sender, EventArgs e)", 8);
#endif
            IV_About_VLC_Player.Active = false;
            IV_Release_V_UI();
        }

        private void IV_MP_B_Stop_Video_Released()
        {
            IV_CB_Toggle_Slider_Func.Checked = false;
            if (!iv_mp_new_ui)
                IV_CB_Toggle_Slider_Func.Visible = false;
            else
                IV_MP_Realise_Buttons_Anim(IV_CB_Toggle_Slider_Func, true);
            IV_MP_Release_Slider_Parm();
            ivmp.Stop();
            IV_MP_T_Video_Time_Show.Enabled = false;
            ivmp_wave.Stop();
            ivmp_wave_ended = false;
            IV_T_Video_Wave_Check_Stopped.Enabled = false;
            IV_MP_Sound_Wave_Panel.Visible = false;
            var ivmp_media_check_type = ivmp_media_temp.Mrl;
            if (!IV_media_check_format(ivmp_media_check_type, true))
                IV_MP_Main.BackColor = ivmp_panel_default_bg_color;
            else
                IV_MP_Main.BackColor = Color.Black;
            IV_About_VLC_Player.Active = true;
            ivmp_stopped = true;
            if(!iv_mp_new_ui)
            {
                IV_MP_Time_Display_Texted.Visible = false;
                IV_MP_B_Stop.Visible = false;
                IV_MP_B_Play.Visible = false;
            }
            else
            {
                IV_MP_Realise_Buttons_Anim(IV_MP_Time_Display_Texted, true);
                IV_MP_Realise_Buttons_Anim(IV_MP_B_Stop, true);
                IV_MP_Realise_Buttons_Anim(IV_MP_B_Play, true);
            }
#if DEBUG
            IV_Check_Process_Window iv_p_state = new IV_Check_Process_Window();
            iv_p_state.IV_DBG_Release_State("IV_MP_B_Stop_Video_Released()", 5);
#endif
        }

        private void IV_Release_Video_on_END(object sender, EventArgs e)
        {
            if(!ivmp_video_was_url)
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
                IV_CB_Toggle_Slider_Func.Checked = false;
                IV_MP_Volume_Bar.Minimum = 0;
                IV_MP_Volume_Bar.Maximum = 100;
                if(ivmp != null && ivmp.Volume > -1)
                    IV_MP_Volume_Bar.Value = ivmp.Volume;
                IV_MP_Volume_Bar.TickFrequency = 10;
                IV_MP_Volume_Bar.SmallChange = 10;
                IV_MP_Volume_Bar.LargeChange = 20;
                IV_About_Volume.SetToolTip(IV_MP_Volume_Bar, ivmp_ab_slider_volume_info);
                ivmp_slider_volume = true; //IV Note: Idiot... I forget that parm...
            }
            else
            {
                IV_CB_Toggle_Slider_Func.Checked = true;
                IV_MP_Volume_Bar.Minimum = 0;
                long time = ivmp.Length;
                IV_MP_Volume_Bar.Maximum = (int)time;
                if (ivmp != null)
                    IV_MP_Volume_Bar.Value = (int)ivmp.Time;
                var iv_vd_track_10 = (int)time * 10 / 100;
                var iv_vd_track_20 = (int)time * 20 / 100;
                IV_MP_Volume_Bar.TickFrequency = iv_vd_track_10;
                IV_MP_Volume_Bar.SmallChange = iv_vd_track_10;
                IV_MP_Volume_Bar.LargeChange = iv_vd_track_20;
                IV_About_Volume.SetToolTip(IV_MP_Volume_Bar, ivmp_ab_slider_time_info);
                ivmp_slider_volume = false;
#if DEBUG
                var all_time = time;
                string[] time_structure = new string[3] {"seconds","minutes","hours" };
                string currient_t_structure = String.Empty;
                if (all_time < 60000)
                {
                    all_time /= 1000;
                    currient_t_structure = time_structure[0];
                }
                else if (all_time < 3600000)
                {
                    all_time /= 60000;
                    currient_t_structure = time_structure[1];
                }
                else if (all_time >= 3600000)
                {
                    all_time /= 3600000;
                    currient_t_structure = time_structure[2];
                }
                if (all_time >= 60000 && all_time < 3600000)
                    currient_t_structure = currient_t_structure + " "+ (time / 1000 - 60 * all_time)+" "+ time_structure[0];
                else if (all_time >= 3600000)
                    currient_t_structure = currient_t_structure + " " + (time / 60000 - 60 * all_time) 
                        + " " + time_structure[1] + " " + (time / 1000 - 60 * all_time) + " " + time_structure[0];
                MessageBox.Show("IV VLC Video Time is - "+ all_time + " "+ currient_t_structure+".", IV_Gallery_Main_Menu.thsdev_iv_warning_logo);
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
            if(ivmp_media_temp != null)
                ivmp_media_temp.Dispose();
            ivmp_lib.Dispose();
            iv_url_manager.Dispose();
            ivmp_wave.Dispose();
            ivmp_wave_lib.Dispose();
            ivmp_media_wave.Dispose();
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

        private static string iv_mp_search_button_text_local = String.Empty;
        private static string iv_mp_search_button_text_url = String.Empty;
        private bool iv_mp_search_url = false;
        public static bool iv_mp_url_chosed = false;
        public static string iv_mp_url_link = String.Empty;

        private void IV_MP_Release_Local_or_URL_Search_Method(bool url_enabled = false)
        {
            if(!url_enabled)
            {
                if(iv_url_manager.iv_imf_inited && iv_url_manager.Visible)
                    iv_url_manager.Close();
                if (!iv_mp_new_ui)
                    IV_B_Chose_Media.Visible = true;
                else
                    IV_MP_Realise_Buttons_Anim(IV_B_Chose_Media);
                IV_B_Chose_Media.Text = iv_mp_search_button_text_local;
                iv_mp_search_url = false;
            }
            else
            {
                IV_B_Chose_Media.Text = iv_mp_search_button_text_url;
                iv_mp_search_url = true;
#if DEBUG
                IV_Check_Process_Window iv_p_state = new IV_Check_Process_Window();
                iv_p_state.IV_DBG_Release_State("IV_MP_Release_Local_or_URL_Search_Method(bool url_enabled = false)", 8, true);
#endif
            }
        }

        private void IV_MP_CB_URL_Checked(object sender, EventArgs e)
        {
            if(!IV_MP_CB_Ulr_Method.Checked)
            {
                IV_MP_Release_Local_or_URL_Search_Method();
            }
            else
            {
                IV_MP_Release_Local_or_URL_Search_Method(true);
            }
        }

        public void IV_MP_URL_Button_Visible(bool visible)
        {
            bool hide;
            if (visible)
                hide = false;
            else
                hide = true;
            if (!iv_mp_new_ui)
                IV_B_Chose_Media.Visible = visible;
            else
                IV_MP_Realise_Buttons_Anim(IV_B_Chose_Media, hide);
        }

        private void IV_MP_URL_State_Think(object sender, EventArgs e)
        {
            if(iv_mp_url_chosed)
            {
                iv_mp_url_chosed = false;
                IV_MP_T_Check_URL_State.Enabled = false;
                if (!iv_mp_new_ui)
                    IV_B_Chose_Media.Visible = true;
                else
                    IV_MP_Realise_Buttons_Anim(IV_B_Chose_Media);
                IV_MP_Play_Video(false,true);
            }
            else if(!iv_url_manager.iv_imf_inited)
            {
                IV_MP_T_Check_URL_State.Enabled = false;
                if (!iv_mp_new_ui)
                    IV_B_Chose_Media.Visible = true;
                else
                    IV_MP_Realise_Buttons_Anim(IV_B_Chose_Media);
            }
        }

        private void IV_MP_T_Video_T_Change_Interval(object sender, EventArgs e)
        {
            IV_MP_T_Change_Time_Interval.Enabled = false;
            ivmp_slider_timecontrol_changing = false;
        }

        private void IV_MP_Wave_Check_End(object sender, EventArgs e)
        {
            if(ivmp_media_sound)
                ivmp_wave_ended = true;
        }

        private bool ivmp_wave_ended = false;

        private void IV_MP_Wave_Stopped_Think(object sender, EventArgs e)
        {
            if(ivmp_wave_ended && ivmp_media_sound)
            {
                ivmp_wave_ended = false;
                ivmp_wave.Play(ivmp_media_wave);
            }
        }

        private bool iv_mp_new_ui = false;

        private void IV_MP_Double_Menu_Settings(object sender, EventArgs e)
        {
            var iv_dialog_msg = MessageBox.Show("Activate new UI for that tool?; Currient state is - " 
                + iv_mp_new_ui.ToString()+".", IV_Gallery_Main_Menu.thsdev_iv_warning_logo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iv_dialog_msg == DialogResult.Yes)
                iv_mp_new_ui = true;
            else
                iv_mp_new_ui = false;
        }
    }
}
