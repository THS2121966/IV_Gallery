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
    public partial class IV_Gallery_Main_Menu : Form
    {
        public IV_Gallery_Main_Menu()
        {
            InitializeComponent();
            iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name, iv_gallery_prog_ver, false, true);
            if(IV_Gallery_Checkers_Core.IVCheckerCore.iv_checker_dll_code_ver == last_supported_iv_ch_c_ver)
            {
                IV_Button_App_Info.Visible = true;
            }
            if(iv_ch_core.debug_mode)
            {
                debug_mode = true;
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
        int iv_sb_released_state = 0;
        static float iv_gallery_prog_ver = 0.35f;
        static public float last_supported_iv_ch_c_ver = 0.35f;
        static string iv_gallery_prog_name = "IV_Gallery";
        static string[] iv_gallery_prog_name_checker_list = new string[3] { "IV_Gallery", "UNUSED2", "UNUSED3" };
        static public Image iv_bg_default = global::IV_Gallery.Properties.Resources.THSSourcelogoF_source_loading;
        static public IV_Gallery_Checkers_Core.IVCheckerCore iv_ch_core = new IV_Gallery_Checkers_Core.IVCheckerCore();

        private void IV_MM_BG_D_Click(object sender, EventArgs e)
        {
            if(iv_mm_bg_clicked == false)
            {
                iv_mm_bg_clicked = true;
            }
            else
            {
                iv_mm_bg_clicked = false;
            }
            CheckIVBGClickedStatus(iv_mm_bg_clicked);
        }

        private void CheckIVBGClickedStatus(bool clicked)
        {
            if(clicked == true)
            {
                IV_Gallery_MM_BG_Picture.Image = global::IV_Gallery.Properties.Resources.SanyaLogoF;
                IV_G_Button_Exit.Visible = false;
            }
            else
            {
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
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
            if(debug_mode)
                MessageBox.Show("Thank you for testing that programm. Goodbye!!!", "IV");
            iv_g_m_m.Close();
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

        private void IV_T_Check_L_Display(object sender, EventArgs e)
        {
            IV_Time_Pre_Finish_Load.Enabled = false;
            IV_Release_Load_INFO();
        }

        private void IV_B_AppInfo_Hook(object sender, EventArgs e)
        {
            iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name, iv_gallery_prog_ver, true, true);
            IV_Release_Load_INFO(70);
        }
    }
}
