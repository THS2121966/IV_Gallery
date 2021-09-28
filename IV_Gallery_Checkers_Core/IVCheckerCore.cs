using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IV_Gallery_Checkers_Core
{
    public class IVCheckerCore
    {
        //IV Note: CheckersCore Version:
        static public float iv_checker_dll_code_ver = 0.35f;
        //IV Note: CheckersCore versions Indefier with main programm list:
        static float[] supported_vers_p_and_iv_c_c = new float[2] { iv_checker_dll_code_ver, 0.35f };
        //IV Note: Core side Debug Mode parm:
        public bool debug_mode = false;

        //IV Note: List of Supported programs:
        static string[] iv_gallery_prog_name = new string[3] { "IV_Gallery", "UNUSED2","UNUSED3" };
        //IV Note: Used programm name:
        public static string iv_used_programm = null;
        //IV Note: Used programm version:
        public static float iv_used_programm_ver = 0.1f;
        //IV Note: AppInfo Form variable for using that UI Component:
        static public IV_Checker_Core_AppInfo iv_app_inf_main = new IV_Checker_Core_AppInfo();
        //IV Note: Assembly for reading inluded resources in that core:
        static System.Reflection.Assembly iv_this_p_assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //IV Note: Default Empty Route to used (Close about_page UI Scenario) sound file:
        static System.IO.Stream menu_ui_about_s_file_close = iv_this_p_assembly.GetManifestResourceStream("null");
        //IV Note: Default Empty Route to used (Open about_page UI Scenario) sound file:
        static System.IO.Stream menu_ui_about_s_file_open = iv_this_p_assembly.GetManifestResourceStream("null");
        //IV Note: Close about_page UI Scenario sound:
        static public SoundPlayer ui_s_wnd_ab_close = new SoundPlayer(menu_ui_about_s_file_close);
        //IV Note: Open about_page UI Scenario sound:
        static public SoundPlayer ui_s_wnd_ab_open = new SoundPlayer(menu_ui_about_s_file_open);
        //IV Note: Text for about_page Programm information:
        static string last_genetaded_inf_for_about = iv_used_programm + "\n" + "Programm Version - " + iv_used_programm_ver + "\n" + "Used IV Library: "
                        + "\n" + "1) IV Checker Core";
        //IV Note: Text for about_page Programm information with DEBUG_MODE_ENABLED:
        static string last_genetaded_inf_for_about_with_dbg = last_genetaded_inf_for_about + " DEBUG_MODE_ENABLED";


        //IV Note: Intreger Create Scenario for Save Release Progress Bar variables.
        public int iv_progress_b_last_state_int = 505;
        /////////////////////////////////////////////////////////////////////
        //IV Note: Intreger Create Scenario for Save Release Progress Bar.//
        ///////////////////////////////////////////////////////////////////
        public int IV_Calculate_for_Progress_Bar(int value_for_recreate = 0, int value_count = 1, string method = "+")
        {
            if (iv_used_programm == null)
                return 505;

            if(method == "+" || method == "-" || method == "*" || method == "/")
            {
                if(method == "+")
                {
                    value_for_recreate = value_for_recreate + value_count;
                }
                else if(method == "-")
                {
                    value_for_recreate = value_for_recreate - value_count;
                }
                else if (method == "*")
                {
                    value_for_recreate = value_for_recreate * value_count;
                }
                else if (method == "/")
                {
                    value_for_recreate = value_for_recreate / value_count;
                }
                iv_progress_b_last_state_int = value_for_recreate;
                return value_for_recreate;
            }
            else
            {
                value_for_recreate = 505;
                iv_progress_b_last_state_int = value_for_recreate;
                return 505;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////
        //IV Note: That void Checks Programm main and Core Versions with their names.//
        //////////////////////////////////////////////////////////////////////////////
        public void IV_Checker_Core_Release_Ver_Info(string main_programm_name = "FIXME_MAIN_PROGRAMM", float main_prog_ver = 0.1f, bool use_ui_for_info = false)
        {
            bool checked_state_p_name = false;
            bool checked_programm_ver = false;

            IV_Reload_AB_P_Text();

            if (main_programm_name == iv_gallery_prog_name[0] || main_programm_name == iv_gallery_prog_name[1] || main_programm_name == iv_gallery_prog_name[2])
            {
                if(main_programm_name == iv_gallery_prog_name[1] || main_programm_name == iv_gallery_prog_name[2])
                {
                    MessageBox.Show("That Library dosen't fully support this app!!!", "IV Checker Core " + iv_checker_dll_code_ver + " Programm name - " + main_programm_name);
                    IV_Release_DEBUG_MODE(true);
                }
                else
                {
                    checked_state_p_name = true;
                    /*if (!use_debug_mode)
                        debug_mode = false;
                    else
                        debug_mode = true;*/ //IV Note: Old DEBUG INIT Scenario. Stupid variation...
                }
            }
            else
            {
                MessageBox.Show("That Library dosen't support this app!!! Aborting...", "IV Checker Core " + iv_checker_dll_code_ver + " Programm name - " + main_programm_name);
                Application.Exit();
            }
            if(main_prog_ver == supported_vers_p_and_iv_c_c[1] && iv_checker_dll_code_ver == supported_vers_p_and_iv_c_c[0])
            {
                checked_programm_ver = true;
                iv_used_programm_ver = main_prog_ver;
            }
            else
            {
                MessageBox.Show("That Library version dosen't fully comportable with this programm version!!! That casules to many problems!!!", "IV Checker Core " 
                    + iv_checker_dll_code_ver + " Programm name - " + main_programm_name);
            }
            if(checked_state_p_name == true && checked_programm_ver == true)
            {
                iv_used_programm = main_programm_name;
                if(use_ui_for_info == true)
                {
                    if (!debug_mode)
                        iv_app_inf_main.IV_C_C_About_Page.Text = last_genetaded_inf_for_about;
                    else
                        iv_app_inf_main.IV_C_C_About_Page.Text = last_genetaded_inf_for_about_with_dbg;
                    if (main_programm_name == iv_gallery_prog_name[0])
                    {
                        menu_ui_about_s_file_close = iv_this_p_assembly.GetManifestResourceStream(@"IV_Gallery_Checkers_Core.iv_sound_cache.menu_back.wav");
                        menu_ui_about_s_file_open = iv_this_p_assembly.GetManifestResourceStream(@"IV_Gallery_Checkers_Core.iv_sound_cache.menu_accept.wav");
                        ui_s_wnd_ab_close = new SoundPlayer(menu_ui_about_s_file_close);
                        ui_s_wnd_ab_open = new SoundPlayer(menu_ui_about_s_file_open);
                    }
                    if (iv_app_inf_main.iv_ab_closed_hook == true)
                    {
                        iv_app_inf_main = new IV_Checker_Core_AppInfo();
                        iv_app_inf_main.iv_ab_closed_hook = false;
                        if (!debug_mode)
                            iv_app_inf_main.IV_C_C_About_Page.Text = last_genetaded_inf_for_about;
                        else
                            iv_app_inf_main.IV_C_C_About_Page.Text = last_genetaded_inf_for_about_with_dbg;
                        iv_app_inf_main.Show();
                    }
                    else if(!iv_app_inf_main.Visible)
                    {
                        iv_app_inf_main.Show();
                    }
                    else if(iv_app_inf_main.Visible)
                    {
                        iv_app_inf_main.Hide();
                    }
                }
            }
            else if(main_programm_name == iv_gallery_prog_name[1] || main_programm_name == iv_gallery_prog_name[2])
            {
                iv_used_programm = main_programm_name;
                MessageBox.Show("That Library dosen't fully support this app!!! Using Anyway...", "IV Checker Core " + iv_checker_dll_code_ver + " Programm name - " + main_programm_name);
            }
        }
        /////////////////////////////////////////////
        //IV Note: void for Reload AboutPage Text.//
        ///////////////////////////////////////////
        static void IV_Reload_AB_P_Text()
        {
            last_genetaded_inf_for_about = iv_used_programm + "\n" + "Programm Version - " + iv_used_programm_ver + "\n" + "Used IV Library: "
                            + "\n" + "1) IV Checker Core";
            last_genetaded_inf_for_about_with_dbg = last_genetaded_inf_for_about + " DEBUG_MODE_ENABLED";
        }
        ////////////////////////////////////////////////////
        //IV Note: Debug mode Core Activator void Method.//
        //////////////////////////////////////////////////
        public void IV_Release_DEBUG_MODE(bool active_state = true)
        {
            if(active_state)
            {
                debug_mode = true;
                if (debug_mode && iv_app_inf_main.Visible)
                    iv_app_inf_main.IV_C_C_About_Page.Text = last_genetaded_inf_for_about_with_dbg;
                MessageBox.Show("Debug State was - ON", "IV "+ iv_used_programm);
            }
            else
            {
                debug_mode = false;
                if (!debug_mode && iv_app_inf_main.Visible)
                    iv_app_inf_main.IV_C_C_About_Page.Text = last_genetaded_inf_for_about;
                MessageBox.Show("Debug State was - OFF", "IV " + iv_used_programm);
            }
        }
    }
}
