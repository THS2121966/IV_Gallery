﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.Windows;

namespace IV_Gallery
{
    public partial class IV_Gallery_Main_Menu : Form
    {
        public IV_Gallery_Main_Menu()
        {
            InitializeComponent();
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[5])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[5]);
            else
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name, iv_gallery_prog_ver);
            if (IV_Gallery_Checkers_Core.IVCheckerCore.iv_checker_dll_code_ver == last_supported_iv_ch_c_ver)
            {
                IV_Button_App_Info.Visible = true;
            }
            if(IV_G_Check_DEBUG_Core_State())
            {
                debug_mode = true;
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
        bool debug_mode = false;
        bool iv_mm_bg_clicked = false;
        bool iv_released_l_info = true;
        bool iv_l_t_first_inited = true;
        static public bool d3x_closed = true;
        int int_to_debug = 0;
        int iv_sb_released_state = 0;
        static float iv_gallery_prog_ver = 0.45f;
        static float last_supported_iv_ch_c_ver = 0.4f;
        static float[] list_of_supported_ch_core_vers = IV_Gallery_Checkers_Core.IVCheckerCore.supported_vers_p_and_iv_c_c;
        static string iv_gallery_prog_name = "IV_Gallery";
        static string[] iv_gallery_prog_name_checker_list = IV_Gallery_Checkers_Core.IVCheckerCore.iv_gallery_prog_name;
        static public Image iv_bg_default = Properties.Resources.THSSourcelogoF_source_loading;
        static public IV_Gallery_Checkers_Core.IVCheckerCore iv_ch_core = new IV_Gallery_Checkers_Core.IVCheckerCore();
        SoundPlayer[] iv_boomer_random = new SoundPlayer[2] { IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_boomer_s_01, IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_boomer_s_02 };
        DXCoreTest iv_3dx_render = new DXCoreTest();

        private void IV_MM_BG_D_Click(object sender, EventArgs e)
        {
            if(int_to_debug != 8)
            {
                int_to_debug = int_to_debug + 1;
            }
            else if(int_to_debug == 8 && !debug_mode && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                debug_mode = true;
                iv_g_m_m.MaximizeBox = true;
                iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                if(d3x_closed || iv_3dx_render.DXWnd.Visible == false)
                    iv_3dx_render.Run();
            }
            else if(int_to_debug == 8 && debug_mode && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                debug_mode = false;
                iv_g_m_m.MaximizeBox = false;
                iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                if(!d3x_closed)
                    iv_3dx_render.DXWnd.Visible = false;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            }
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
                IV_Gallery_MM_BG_Picture.Image = Properties.Resources.SanyaLogoF;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
                iv_boomer_random[iv_rnd_for_boomer.Next(0, 2)].Play();
                IV_G_Button_Exit.Visible = false;
            }
            else
            {
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                IV_G_Button_Exit.Visible = true;
            }
            IV_Release_Load_INFO(70);
        }

        public void IV_Release_Load_INFO(int starting_value = 0)
        {
            if(iv_released_l_info == true)
            {
                iv_released_l_info = false;
                IV_MM_Load_Status_Bar.Value = 0;
                iv_sb_released_state = starting_value;
                IV_MM_Load_Status_Bar.Visible = true;
                IV_Time_WAIT_UN_Load.Enabled = true;
            }
            else
            {
                iv_released_l_info = true;
                IV_MM_Load_Status_Bar.Value = 100;
                IV_MM_Load_Status_Bar.Visible = false;
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
            if (debug_mode)
                MessageBox.Show("Thank you for testing that programm. Goodbye!!!", "IV");
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Close();
            if (!d3x_closed)
                iv_3dx_render.ShutDown();
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
            if(iv_ch_core.debug_mode)
            {
                return iv_ch_core.debug_mode;
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
            if(!d3x_closed)
                iv_3dx_render.ShutDown();
            iv_g_m_m.Close();
        }

        private void IV_MM_Load_Hook(object sender, EventArgs e)
        {
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_g_m_m_open.Play();
        }

        private void IV_Think_AB_WND_Hook(object sender, EventArgs e)
        {
            if(IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible == false && !IV_Gallery_Checkers_Core.IVCheckerCore.iv_ab_hide_hack)
            {
                IV_THINK_AB_WINDOW_HOOK.Enabled = false;
            }
            else if(IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible == false && IV_Gallery_Checkers_Core.IVCheckerCore.iv_ab_hide_hack)
            {
                IV_THINK_AB_WINDOW_HOOK.Enabled = false;
                IV_Button_App_Info.Visible = false;
                IV_G_Button_Exit.Visible = false;
                if (!d3x_closed)
                    iv_3dx_render.ShutDown();
                debug_mode = false;
                iv_ch_core.IV_Release_DEBUG_MODE(false);
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
            }
        }
    }

    class DXCoreTest
    {
        public RenderForm DXWnd;

        public DXCoreTest()
        {
            DXWnd = new RenderForm("IV DirectX Render Window");
            IV_Gallery_Main_Menu.d3x_closed = false;
            DXWnd.Closed += new System.EventHandler(DXCoreTest.IV_DX_WND_Closed_Hook);
        }

        public void Run()
        {
            if(IV_Gallery_Main_Menu.d3x_closed)
            {
                DXWnd = new RenderForm("IV DirectX Render Window");
                IV_Gallery_Main_Menu.d3x_closed = false;
                DXWnd.Icon = IV_Gallery_Main_Menu.iv_g_m_m.Icon;
                RenderLoop.Run(DXWnd, RenderCallback);
            }
            else
            {
                if(DXWnd.Icon != IV_Gallery_Main_Menu.iv_g_m_m.Icon)
                    DXWnd.Icon = IV_Gallery_Main_Menu.iv_g_m_m.Icon;
                DXWnd.Visible = true;
            }
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_g_m_m_open.Play();
        }

        public void ShutDown()
        {
            DXWnd.Close();
        }

        public void RenderCallback()
        {

        }

        static private void IV_DX_WND_Closed_Hook(object sender, EventArgs e)
        {
            IV_Gallery_Main_Menu.d3x_closed = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }
    }
}
