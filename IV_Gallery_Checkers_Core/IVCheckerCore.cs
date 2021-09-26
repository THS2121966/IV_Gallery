using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IV_Gallery_Checkers_Core
{
    public class IVCheckerCore
    {
        static public float iv_checker_dll_code_ver = 0.312f;
        static float[] supported_vers_p_and_iv_c_c = new float[2] { 0.312f, 0.32f };

        //IV Note: List of Supported programs:
        static string[] iv_gallery_prog_name = new string[3] { "IV_Gallery", "UNUSED2","UNUSED3" };
        public string iv_used_programm = null;
        static public IV_Checker_Core_AppInfo iv_app_inf_main = new IV_Checker_Core_AppInfo();
        string last_genetaded_inf_for_about = null;

        ///////////////////////////////////////////////////////////////////////////////
        //IV Note: Intreger Create Scenario for Save Release Progress Bar variables.//
        /////////////////////////////////////////////////////////////////////////////
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
        public void IV_Checker_Core_Release_Ver_Info(string main_programm_name = "FIXME_MAIN_PROGRAMM", float main_prog_ver = 0.1f, bool use_ui_for_info = false)
        {
            bool checked_state_p_name = false;
            bool checked_programm_ver = false;

            if (main_programm_name == iv_gallery_prog_name[0] || main_programm_name == iv_gallery_prog_name[1] || main_programm_name == iv_gallery_prog_name[2])
            {
                if(main_programm_name == iv_gallery_prog_name[1] || main_programm_name == iv_gallery_prog_name[2])
                {
                    MessageBox.Show("That Library dosen't fully support this app!!!", "IV Checker Core " + iv_checker_dll_code_ver + " Programm name - " + main_programm_name);
                }
                else
                {
                    checked_state_p_name = true;
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
                    iv_app_inf_main.IV_C_C_About_Page.Text = main_programm_name + "\n" + "Programm Version - " + main_prog_ver + "\n" + "Used IV Library: "
                        + "\n" + "1) IV Checker Core";
                    if(iv_app_inf_main.iv_ab_closed_hook == true)
                    {
                        iv_app_inf_main = new IV_Checker_Core_AppInfo();
                        iv_app_inf_main.iv_ab_closed_hook = false;
                        iv_app_inf_main.IV_C_C_About_Page.Text = last_genetaded_inf_for_about;
                        iv_app_inf_main.Show();
                    }
                    else if(!iv_app_inf_main.Visible)
                    {
                        iv_app_inf_main.Show();
                        last_genetaded_inf_for_about = iv_app_inf_main.IV_C_C_About_Page.Text;
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
    }
}
