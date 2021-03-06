
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Siticone.Desktop;


namespace IV_Gallery
{
    public partial class IV_Gallery_Main_Menu : Form
    {
        public IV_Gallery_Main_Menu()
        {
            InitializeComponent();
#if IV_GALLERY_VER_045
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[5])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[5]);
#elif IV_GALLERY_VER_048
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[7])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[7]);
#elif IV_GALLERY_VER_05
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[9])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[9]);
#elif IV_GALLERY_VER_052
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[11])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[11]);
#elif IV_GALLERY_VER_053
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[13])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[13]);
#elif IV_GALLERY_VER_054
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[15])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[15]);
#endif
            else
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name, iv_gallery_prog_ver);
            if (IV_Gallery_Checkers_Core.IVCheckerCore.iv_checker_dll_code_ver == last_supported_iv_ch_c_ver)
            {
                IV_Button_App_Info.Visible = true;
            }
            if(IV_G_Check_DEBUG_Core_State())
            {
                debug_mode = true;
                IV_B_Debug_ChangeBGImage.Visible = true;
                iv_g_m_m.MaximizeBox = true;
            }
            if(IV_Gallery_MM_BG_Picture.Image != iv_bg_default)
            {
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
            }
            IV_Release_Load_INFO();
        }

        //////////////////////////////
        //IV Note: Main Menu Parms://
        ////////////////////////////
        private bool debug_mode = false;
        public static string thsdev_iv_logo = "IV";
        public static string thsdev_iv_warning_logo = thsdev_iv_logo + " Warning!";
        public static string thsdev_iv_error_logo = thsdev_iv_logo + " Error!!!";
        static public IV_Gallery_Main_Menu iv_g_m_m;
        private bool iv_mm_bg_clicked = false;
        private bool iv_released_l_info = true;
        private bool iv_l_t_first_inited = true;
        private int int_to_debug = 0;
        private int iv_sb_released_state = 0;
#if IV_GALLERY_VER_045
        static float iv_gallery_prog_ver = 0.45f;
        static float last_supported_iv_ch_c_ver = 0.4f;
#elif IV_GALLERY_VER_048
        static float iv_gallery_prog_ver = 0.48f;
        static float last_supported_iv_ch_c_ver = 0.42f;
#elif IV_GALLERY_VER_05
        static float iv_gallery_prog_ver = 0.5f;
        static float last_supported_iv_ch_c_ver = 0.42f;
#elif IV_GALLERY_VER_052
        static float iv_gallery_prog_ver = 0.52f;
        static float last_supported_iv_ch_c_ver = 0.45f;
#elif IV_GALLERY_VER_053
        private static float iv_gallery_prog_ver = 0.53f;
        private static float last_supported_iv_ch_c_ver = 0.45f;
#elif IV_GALLERY_VER_054
        private static float iv_gallery_prog_ver = 0.54f;
        private readonly static float last_supported_iv_ch_c_ver = 0.48f;
#endif
        private readonly static float[] list_of_supported_ch_core_vers = IV_Gallery_Checkers_Core.IVCheckerCore.supported_vers_p_and_iv_c_c;
        private readonly static string iv_gallery_prog_name = "IV_Gallery";
        private readonly static string[] iv_gallery_prog_name_checker_list = IV_Gallery_Checkers_Core.IVCheckerCore.iv_gallery_prog_name;
        static public Image iv_bg_default_standart = Properties.Resources.THSSourcelogoF_source_loading;
        public Image iv_bg_default = iv_bg_default_standart;
        private bool iv_bg_changed = false;
        private static string[] iv_app_warnings_list = new string[1] {String.Empty };
        static public IV_Gallery_Checkers_Core.IVCheckerCore iv_ch_core = new IV_Gallery_Checkers_Core.IVCheckerCore();
        private readonly SoundPlayer[] iv_boomer_random = new SoundPlayer[2] { IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_boomer_s_01, IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_boomer_s_02 };
        private readonly DXCoreTest iv_3dx_render = new DXCoreTest();

        public static string IV_Release_Problem_Message(string message, bool is_error = false)
        {
            if(message == String.Empty || message == null)
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_bug_s.Play();
                MessageBox.Show("Problem isn't founded! Aborting...", thsdev_iv_logo);
                return null;
            }
            if(!is_error)
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_bug_s.Play();

                int counted_w_last_array_length = iv_app_warnings_list.Length;
                int counted_w_last_string = counted_w_last_array_length - 1;

                if(iv_app_warnings_list[counted_w_last_string] == String.Empty)
                    iv_app_warnings_list[counted_w_last_string] = (counted_w_last_string + 1) + ")" + " " + message;
                else
                {
                    Array.Resize(ref iv_app_warnings_list, counted_w_last_array_length + 1);
                    counted_w_last_array_length = iv_app_warnings_list.Length;
                    counted_w_last_string = counted_w_last_array_length - 1;
                    iv_app_warnings_list[counted_w_last_string] = (counted_w_last_string + 1) + ")" + " " + message;
                }

                MessageBox.Show("Something was wrong... - " + message, thsdev_iv_warning_logo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var iv_dlg_show_last_warnings = MessageBox.Show("Show last application warnings?", thsdev_iv_logo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(iv_dlg_show_last_warnings == DialogResult.Yes)
                {
                    var iv_msg_last_varnings = String.Empty;
                    foreach(string msg_w in iv_app_warnings_list)
                    {
                        string[] end_string = new string[2] { ";","." };
                        if(msg_w != iv_app_warnings_list.Last())
                            iv_msg_last_varnings = iv_msg_last_varnings + " " + msg_w + end_string[0];
                        else
                            iv_msg_last_varnings = iv_msg_last_varnings + " " + msg_w + end_string[1];
                    }
                    MessageBox.Show("Last application warnings: " + iv_msg_last_varnings, thsdev_iv_logo);
                }
                return message;
            }
            else
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_bug_s.Play();
                var iv_warning_result = MessageBox.Show("Something was wrong... - " + message + ". If you want to 'Reload' programm press 'OK', else programm will be 'Closed'.", thsdev_iv_error_logo, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (iv_warning_result == DialogResult.Yes)
                    Application.Restart();
                else
                    Application.Exit();
                return message;
            }
        }

        public static float IV_Gallery_Get_Version()
        {
            return iv_gallery_prog_ver;
        }

        public static void IV_Gallery_Set_Version(float sended_version)
        {
            iv_gallery_prog_ver = sended_version;
        }

        private void IV_MM_BG_D_Click(object sender, EventArgs e)
        {
            if(int_to_debug != 8)
            {
                int_to_debug++;
            }
#if DEBUG
            else if(int_to_debug == 8 && !debug_mode && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                debug_mode = true;
                //IV_B_Debug_ChangeBGImage.Visible = true; IV Note: Old Method.

                var iv_anim_b_bg_change_init = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    MaxAnimationTime = 1000,
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles
                };

                iv_anim_b_bg_change_init.Show(IV_B_Debug_ChangeBGImage);
                iv_g_m_m.MaximizeBox = true;
                iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                if(!iv_3dx_render.d3x_opened || iv_3dx_render.DXWnd.Visible == false)
                {
                    var iv_d3x_anim_load = new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(iv_3dx_render.DXWnd)
                    {
                        Interval = 450,
                        AnimationType = Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow.AnimateWindowType.AW_CENTER,
                        TargetForm = iv_3dx_render.DXWnd
                    };

                    iv_3dx_render.Run();
                }
            }
            else if(int_to_debug == 8 && debug_mode && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                debug_mode = false;
                //IV_B_Debug_ChangeBGImage.Visible = false; //IV note: Old Method.

                var iv_anim_b_bg_change_init = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    MaxAnimationTime = 1000,
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles
                };

                iv_anim_b_bg_change_init.Hide(IV_B_Debug_ChangeBGImage);
                iv_g_m_m.MaximizeBox = false;
                iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                if(iv_3dx_render.d3x_opened)
                    iv_3dx_render.DXWnd.Visible = false;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            }
#else
            else if(int_to_debug == 8 && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                string dlg_message = "Do you want to ENABLE/DISABLE Debug Mode?";
                string dlg_iv_msg_logo = thsdev_iv_logo;
                var dlg_result = MessageBox.Show(dlg_message, dlg_iv_msg_logo,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                if(dlg_result == DialogResult.Yes)
                {
                    debug_mode = true;
                    //IV_B_Debug_ChangeBGImage.Visible = true; IV Note: Old Method.

                    var iv_anim_b_bg_change_init = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                    {
                        MaxAnimationTime = 1000,
                        AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles
                    };

                    iv_anim_b_bg_change_init.Show(IV_B_Debug_ChangeBGImage);
                    iv_g_m_m.MaximizeBox = true;
                    iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                    if (!iv_3dx_render.d3x_opened || iv_3dx_render.DXWnd.Visible == false)
                    {
                        var iv_d3x_anim_load = new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(iv_3dx_render.DXWnd)
                        {
                            Interval = 450,
                            AnimationType = Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow.AnimateWindowType.AW_CENTER,
                            TargetForm = iv_3dx_render.DXWnd
                        };

                        iv_3dx_render.Run();
                    }
                }
                else
                {
                    debug_mode = false;
                    //IV_B_Debug_ChangeBGImage.Visible = false; //IV note: Old Method.
                    
                    var iv_anim_b_bg_change_init = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                    {
                        MaxAnimationTime = 1000,
                        AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles
                    };
                    
                    iv_anim_b_bg_change_init.Hide(IV_B_Debug_ChangeBGImage);
                    iv_g_m_m.MaximizeBox = false;
                    iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                    if (iv_3dx_render.d3x_opened)
                        iv_3dx_render.DXWnd.Visible = false;
                    IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                }
            }
#endif
            if (debug_mode)
            {
                if (iv_mm_bg_clicked == false)
                {
                    iv_mm_bg_clicked = true;
                }
                else
                {
                    iv_mm_bg_clicked = false;
                }
                CheckIVBGClickedStatus(iv_mm_bg_clicked);
            }
            if(!debug_mode && IV_Gallery_MM_BG_Picture.Image != iv_bg_default)
            {
                CheckIVBGClickedStatus(false);
            }
        }

        private void CheckIVBGClickedStatus(bool clicked)
        {
            //IV Note: Random scenario for chosing boomer sounds
            Random iv_rnd_for_boomer = new Random();

            if (clicked == true)
            {
                var iv_bg_change_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Transparent,
                    MaxAnimationTime = 350
                };

                var iv_buttons_hide_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles,
                    MaxAnimationTime = 1000
                };

                this.BackColor = Color.Black;

                /*IV_G_Button_Exit.Visible = false;
                IV_B_Debug_ChangeBGImage.Visible = false;
                IV_B_Debug_Resset_BG_IMG_TO_Def.Visible = false;*/ //IV Note: Old hide Method.
                iv_buttons_hide_anim.Hide(IV_G_Button_Exit);
                iv_buttons_hide_anim.Hide(IV_B_Gallery_Settings);
                iv_buttons_hide_anim.Hide(IV_B_Debug_ChangeBGImage);
                iv_buttons_hide_anim.Hide(IV_B_Debug_Resset_BG_IMG_TO_Def);
                iv_bg_change_anim.HideSync(IV_Gallery_MM_BG_Picture);
                IV_Gallery_MM_BG_Picture.Image = Properties.Resources.SanyaLogoF;
                iv_bg_change_anim.ShowSync(IV_Gallery_MM_BG_Picture);
                IV_G_Button_Exit.UseTransparentBackground = true;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
                iv_boomer_random[iv_rnd_for_boomer.Next(0, 2)].Play();
            }
            else
            {
                var iv_bg_change_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Transparent,
                    MaxAnimationTime = 350
                };

                var iv_buttons_show_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles,
                    MaxAnimationTime = 1000
                };

                iv_bg_change_anim.HideSync(IV_Gallery_MM_BG_Picture);
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
                iv_bg_change_anim.ShowSync(IV_Gallery_MM_BG_Picture);
                IV_G_Button_Exit.UseTransparentBackground = true;
                this.BackColor = Color.White;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                //IV_G_Button_Exit.Visible = true;
                iv_buttons_show_anim.Show(IV_G_Button_Exit);
                iv_buttons_show_anim.Show(IV_B_Gallery_Settings);
                if (debug_mode)
                    //IV_B_Debug_ChangeBGImage.Visible = true;
                    iv_buttons_show_anim.Show(IV_B_Debug_ChangeBGImage);
                if (iv_bg_changed)
                {
                    //IV_B_Debug_Resset_BG_IMG_TO_Def.Visible = true;
                    iv_buttons_show_anim.Show(IV_B_Debug_Resset_BG_IMG_TO_Def);
                }
            }
            IV_Release_Load_INFO(70);
        }

        public void IV_Release_Load_INFO(int starting_value = 0)
        {
            if(iv_default_settings_b_pos == new Point(30, 30))
                iv_default_settings_b_pos = IV_B_Gallery_Settings.Location;

            if (iv_released_l_info == true)
            {
                iv_released_l_info = false;
                IV_MM_Load_Status_Bar.Value = 0;
                iv_sb_released_state = starting_value;
                IV_Change_Settings_Button_Origin(false);
                IV_MM_Load_Status_Bar.Visible = true;
                IV_Time_WAIT_UN_Load.Enabled = true;
            }
            else
            {
                iv_released_l_info = true;
                IV_MM_Load_Status_Bar.Value = 100;
                IV_MM_Load_Status_Bar.Visible = false;
                IV_Change_Settings_Button_Origin(true);
                if (IV_Time_WAIT_UN_Load.Enabled == true || IV_Time_Pre_Finish_Load.Enabled == true)
                {
                    IV_Release_Load_INFO(starting_value);
                }
                else
                {
                    IV_Time_WAIT_UN_Load.Enabled = false;
                    IV_Time_Pre_Finish_Load.Enabled = false;
                    IV_G_Button_Exit.Text = "Exit";
                }
            }
        }

        private void IV_Exit_Click_Scenario(object sender, EventArgs e)
        {
            int_to_debug = 0;
            iv_3dx_render.ivdx_shutdown_silent = true;
#if !DEBUG
            if (debug_mode)
                MessageBox.Show("Thank you for testing that programm. Goodbye!!!", thsdev_iv_logo);
#else
            if (debug_mode)
            {
                int test_counts = 1;
                for(int i = 1; i <= test_counts; i++)
                    IV_Release_Problem_Message("Thank you for testing that programm. Goodbye!!!");
            }
#endif
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Close();
            if (iv_3dx_render.d3x_opened)
                iv_3dx_render.ShutDown();
            iv_mp.Close();
            iv_mp_2.Close();
            iv_mp_3.Close();

            iv_g_m_m.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            var iv_hide_window = new Siticone.Desktop.UI.WinForms.SiticoneTransition
            {
                AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.ScaleAndHorizSlide,
                MaxAnimationTime = 1000
            };

            iv_hide_window.Hide(iv_g_m_m);
            iv_g_m_m.Hide();

            IV_T_Exit.Enabled = true;
        }

        private void IV_L_TIME_HOOK(object sender, EventArgs e)
        {
            if(iv_l_t_first_inited == true)
            {
                IV_MM_Load_Status_Bar.Value = iv_sb_released_state;
                iv_l_t_first_inited = false;
            }
            if (IV_MM_Load_Status_Bar.Value == 100)
            {
                IV_Time_WAIT_UN_Load.Enabled = false;
                iv_l_t_first_inited = true;
                IV_Time_Pre_Finish_Load.Enabled = true;
            }
            else
            {
                IV_MM_Load_Status_Bar.Value = iv_ch_core.IV_Calculate_for_Progress_Bar(IV_MM_Load_Status_Bar.Value, 10, "+");
                IV_G_Button_Exit.Text = Convert.ToString(iv_ch_core.iv_progress_b_last_state_int);
                //IV_MM_Load_Status_Bar.Value = IV_MM_Load_Status_Bar.Value + 10; - IV Note: Old Method.
            }
        }

        private bool IV_G_Check_DEBUG_Core_State()
        {
            if(IV_Gallery_Checkers_Core.IVCheckerCore.debug_mode)
            {
                return IV_Gallery_Checkers_Core.IVCheckerCore.debug_mode;
            }
            return false;
        }

        private void IV_T_Check_L_Display(object sender, EventArgs e)
        {
            IV_Time_Pre_Finish_Load.Enabled = false;
            IV_Release_Load_INFO();
        }

        private void IV_B_AppInfo_Hook(object sender, EventArgs e)
        {
            int_to_debug = 0;
            IV_THINK_AB_WINDOW_HOOK.Enabled = true;
            iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name, iv_gallery_prog_ver, true);
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
            IV_Release_Load_INFO(70);
        }

        private void IV_T_Exit_Scenario(object sender, EventArgs e)
        {
            if(iv_3dx_render.d3x_opened)
                iv_3dx_render.ShutDown();
            iv_g_m_m.Close();
        }

        private void IV_MM_Load_Hook(object sender, EventArgs e)
        {
            iv_g_m_m = this;
            IV_T_Load_Check.Enabled = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_g_m_m_open.Play();
        }

        private IV_Media_Player iv_mp = new IV_Media_Player();
        private IV_Media_Player iv_mp_2 = new IV_Media_Player();
        private IV_Media_Player iv_mp_3 = new IV_Media_Player();

        private bool ivmp_init_max_vlc_panels = false;

        private void IV_Think_AB_WND_Hook(object sender, EventArgs e)
        {
#region IV_RESTART_PROGRAMM_HOOK
            if (IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible == false && !IV_Gallery_Checkers_Core.IVCheckerCore.iv_ab_hide_hack)
            {
                IV_THINK_AB_WINDOW_HOOK.Enabled = false;
            }
            else if(IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible == false && IV_Gallery_Checkers_Core.IVCheckerCore.iv_ab_hide_hack)
            {
                IV_THINK_AB_WINDOW_HOOK.Enabled = false;
                IV_Button_App_Info.Visible = false;
                IV_B_Gallery_Settings.Visible = false;
                IV_B_Debug_ChangeBGImage.Visible = false;
                iv_mp.Close();
                iv_mp_2.Close();
                iv_mp_3.Close();
                if (IV_Check_BG_Change_Status())
                    IV_Resset_Main_BG();
                IV_G_Button_Exit.Visible = false;
                iv_3dx_render.ivdx_shutdown_silent = true;
                if (iv_3dx_render.d3x_opened)
                    iv_3dx_render.ShutDown();
                debug_mode = false;
                iv_ch_core.IV_Release_DEBUG_MODE(false, true);
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
            }
#endregion
#region IV_MUSIC_PLAYER
            if (IV_Gallery_Checkers_Core.IVCheckerCore.ivmp_more_panels)
                ivmp_init_max_vlc_panels = true;
            else
                ivmp_init_max_vlc_panels = false;

            if (IV_Gallery_Checkers_Core.IVCheckerCore.iv_music_player_show_hack && !iv_mp.Visible)
            {
                if(!ivmp_init_max_vlc_panels)
                    IV_Gallery_Checkers_Core.IVCheckerCore.iv_music_player_show_hack = false;
                if (iv_mp.iv_mp_closed)
                    iv_mp = new IV_Media_Player();
                iv_mp.Visible = true;
            }
            if (IV_Gallery_Checkers_Core.IVCheckerCore.iv_music_player_show_hack && !iv_mp_2.Visible && ivmp_init_max_vlc_panels)
            {
                //IV_Gallery_Checkers_Core.IVCheckerCore.iv_music_player_show_hack = false;
                if (iv_mp_2.iv_mp_closed)
                    iv_mp_2 = new IV_Media_Player();
                iv_mp_2.Visible = true;
            }
            if (IV_Gallery_Checkers_Core.IVCheckerCore.iv_music_player_show_hack && !iv_mp_3.Visible && ivmp_init_max_vlc_panels)
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_music_player_show_hack = false;
                if (iv_mp_3.iv_mp_closed)
                    iv_mp_3 = new IV_Media_Player();
                iv_mp_3.Visible = true;
            }
            else if (iv_mp_3.iv_mp_closed && iv_mp_2.iv_mp_closed && iv_mp.iv_mp_closed && ivmp_init_max_vlc_panels)
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.IV_MP_Realise_Music_Button(true);
            }
            else if (iv_mp.iv_mp_closed && !ivmp_init_max_vlc_panels)
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.IV_MP_Realise_Music_Button(true);
            }
#endregion
        }

        private void IV_B_BGCH_Click(object sender, EventArgs e)
        {
            IV_DLG_BG_IMG_Finder.ShowDialog();
        }

        private Image IV_DLG_Detect_BG_Image(string iv_path_file_detect = null)
        {
            Image iv_new_photo;
            if (iv_path_file_detect != String.Empty || iv_path_file_detect != null)
            {
                iv_new_photo = Image.FromFile(iv_path_file_detect);
#if DEBUG
                MessageBox.Show("Image Result - OK","IV Debug Manager");
#endif
                return iv_new_photo;
            }
#if DEBUG
            IV_Release_Problem_Message("Image Result - ERROR!!!");
#endif
            return null;
        }

        private void IV_DLG_BG_Set_Result(object sender, CancelEventArgs e)
        {
            Image iv_temp_bg_def_old;
            Image iv_new_photo;
            string iv_fl_path = IV_DLG_BG_IMG_Finder.FileName;
            if (iv_fl_path.Contains(".png") || iv_fl_path.Contains(".jpg") || iv_fl_path.Contains(".JPG") 
                || iv_fl_path.Contains(".jpeg") || iv_fl_path.Contains(".bmp") || iv_fl_path.Contains(".PNG"))
                iv_new_photo = IV_DLG_Detect_BG_Image(iv_fl_path);
            else
                iv_new_photo = null;
            if(iv_new_photo != null)
            {
                iv_temp_bg_def_old = iv_bg_default;
                iv_bg_default = iv_new_photo;
                iv_bg_changed = true;
                if (IV_Gallery_MM_BG_Picture.Image == iv_temp_bg_def_old)
                {
                    var iv_bg_change_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                    {
                        AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Transparent,
                        MaxAnimationTime = 350
                    };
                    var iv_button_resset_show_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                    {
                        AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles,
                        MaxAnimationTime = 1000
                    };

                    this.BackColor = Color.Black;

                    iv_bg_change_anim.HideSync(IV_Gallery_MM_BG_Picture);
                    IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
                    iv_bg_change_anim.ShowSync(IV_Gallery_MM_BG_Picture);
                    this.BackColor = Color.White;
                    IV_G_Button_Exit.UseTransparentBackground = true;
                    //IV_B_Debug_Resset_BG_IMG_TO_Def.Visible = true; //IV Note: Old show Method.
                    iv_button_resset_show_anim.Show(IV_B_Debug_Resset_BG_IMG_TO_Def);
                    IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_accept_s.Play();
                }
            }
            else
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_bug_s.Play();
                IV_Release_Problem_Message("File no chosed or INVAID!!!");
                //MessageBox.Show("File no chosed or INVAID!!!", IV_DLG_BG_IMG_Finder.Title);
            }
        }

        private bool IV_Check_BG_Change_Status(bool force_true = false)
        {
            if(force_true)
            {
                return true;
            }
            else
            {
                if(iv_bg_changed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void IV_Resset_Main_BG()
        {
            iv_bg_changed = false;

            var iv_bg_to_def_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
            {
                MaxAnimationTime = 350,
                AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.HorizSlide
            };

            var iv_button_resset_hide_anim = new Siticone.Desktop.UI.WinForms.SiticoneTransition
            {
                AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles,
                MaxAnimationTime = 1000
            };

            this.BackColor = Color.Black;
            iv_bg_to_def_anim.HideSync(IV_Gallery_MM_BG_Picture);
            iv_bg_default = iv_bg_default_standart;
            IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
            iv_bg_to_def_anim.ShowSync(IV_Gallery_MM_BG_Picture);
            this.BackColor = Color.White;
            IV_G_Button_Exit.UseTransparentBackground = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_accept_s.Play();
            if (iv_bg_default == iv_bg_default_standart)
                //IV_B_Debug_Resset_BG_IMG_TO_Def.Visible = false; //IV Note: Old hide Method.
                iv_button_resset_hide_anim.Hide(IV_B_Debug_Resset_BG_IMG_TO_Def);
        }

        private void IV_B_BG_Reset_Hook(object sender, EventArgs e)
        {
            if (IV_Check_BG_Change_Status())
                IV_Resset_Main_BG();
            else
                IV_Release_Problem_Message("iv_bg_changed - Checked and = " + IV_Check_BG_Change_Status().ToString() + ". Why? Tell a programmer!!!");
        }

        private void IV_T_Loaded_Show_Form_B_Hook(object sender, EventArgs e)
        {
            IV_T_Load_Check.Enabled = false;
            iv_g_m_m.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            iv_g_m_m.Icon = this.Icon;

            var iv_b_app_inf_anim_loaded = new Siticone.Desktop.UI.WinForms.SiticoneTransition
            {
                MaxAnimationTime = 1000,
                AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.ScaleAndRotate
            };

            if (IV_Button_App_Info.Visible)
            {
                iv_b_app_inf_anim_loaded.HideSync(IV_Button_App_Info);
                iv_b_app_inf_anim_loaded.AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles;
                iv_b_app_inf_anim_loaded.Show(IV_Button_App_Info);
                iv_b_app_inf_anim_loaded.Show(IV_B_Gallery_Settings);
            }
        }

        private static Point iv_default_settings_b_pos = new Point(30, 30);

        private bool IV_Change_Settings_Button_Origin(bool change_to_slider_pos, bool only_check_status = false)
        {
            if(!change_to_slider_pos && !only_check_status)
            {
                IV_B_Gallery_Settings.Location = iv_default_settings_b_pos;
            }
            else if(!only_check_status)
            {
                IV_B_Gallery_Settings.Location = IV_MM_Load_Status_Bar.Location;
            }
            if(!only_check_status)
                return change_to_slider_pos;
            else
            {
                var iv_check_last_pos = IV_B_Gallery_Settings.Location;

                if (iv_check_last_pos != iv_default_settings_b_pos)
                    return true;
                else
                    return false;
            }
        }

        private bool iv_b_tested_moved = false;
        private readonly int iv_test_mode_fps = 350; 
        private bool iv_think_1_first_init = true;
        private Timer iv_test_cursored_move_think;
        private Control iv_test_selected_control;
        private Point iv_test_last_object_pos = new Point(0, 0);

#if DEBUG
        IV_Gallery_Version_Manager iv_version_verify = new IV_Gallery_Version_Manager();
#else
        IV_Gallery_Version_Manager iv_version_verify;
#endif

        private void IV_B_Gallery_S_Menu_Hook(object sender, EventArgs e)
        {
            if(iv_version_verify == null)
                iv_version_verify = new IV_Gallery_Version_Manager();

            iv_version_verify.IV_VM_Validate_Versions();
        }

        private void IV_Debug_D_Click_Element_Move(object sender, EventArgs e)
        {
            if(iv_think_1_first_init)
            {
                iv_think_1_first_init = false;
                iv_test_cursored_move_think = new Timer(components)
                {
                    Enabled = false,
                    Interval = iv_test_mode_fps
                };

                iv_test_cursored_move_think.Tick += IV_Test_Cursored_B_Pos_Think;
            }

            iv_test_selected_control = sender as Control;
            if (!iv_b_tested_moved)
                iv_test_last_object_pos = iv_test_selected_control.Location;
            if (iv_test_def_control_last_b_text == String.Empty)
                iv_test_def_control_last_b_text = iv_test_selected_control.Text;

            if (!iv_b_tested_moved)
            {
                var iv_anim_to_def = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    MaxAnimationTime = 1000,
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Mosaic
                };

                iv_anim_to_def.HideSync(iv_test_selected_control);
                iv_b_tested_moved = true;
                iv_test_cursored_move_think.Enabled = true;
                iv_anim_to_def.Show(iv_test_selected_control);
            }
            else
            {
                var iv_anim_to_def = new Siticone.Desktop.UI.WinForms.SiticoneTransition
                {
                    MaxAnimationTime = 1000,
                    AnimationType = Siticone.Desktop.UI.AnimatorNS.AnimationType.Particles
                };

                iv_b_tested_moved = false;
                iv_test_cursored_move_think.Enabled = false;
                iv_anim_to_def.HideSync(iv_test_selected_control);
                iv_test_selected_control.Text = iv_test_def_control_last_b_text;
                iv_test_selected_control.Location = iv_test_last_object_pos;
                iv_anim_to_def.Show(iv_test_selected_control);
            }
        }

        private string iv_test_def_control_last_b_text = String.Empty;
        private readonly static string[] iv_test_ha_msg = new string[3] {"Lox", "Pidor", "Govnoed" };

        private void IV_Test_Cursored_B_Pos_Think(object sender, EventArgs e)
        {
            if(iv_b_tested_moved)
            {
                /*var pos_x = Cursor.Position.X - 170;
                var pos_y = Cursor.Position.Y - 170;
                Point result_pos = new Point(pos_x, pos_y);*/

                Random randomiser = new Random();
                int rand_x = randomiser.Next(0, 100);
                int rand_y = randomiser.Next(0, 100);

                int ha_result = randomiser.Next(0, 2);
                if (ha_result == 1)
                    iv_test_selected_control.Text = iv_test_ha_msg[randomiser.Next(0,2)];
                else
                    iv_test_selected_control.Text = iv_test_def_control_last_b_text;

                Point result_pos = new Point(rand_x, rand_y);

                iv_test_selected_control.Location = result_pos;
            }
        }
    }
}
