//#define IV_S_MASTER_VER_03 //IV note: Old Version.
#define IV_S_MASTER_VER_1_5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace IV_Sound_Master
{
    public class IVSMasterCore
    {
#if IV_S_MASTER_VER_03
        static public float iv_s_master_ver = 0.3f;
#elif IV_S_MASTER_VER_1_5
        static public float iv_s_master_ver = 1.5f;
#endif

        static private readonly string iv_sm_logo = "IV Sound Master ver. "+iv_s_master_ver;

        //IV Note: Assembly for reading inluded resources in that core:
        static readonly private System.Reflection.Assembly iv_core_assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //IV Note: menu_return sound file:
        static readonly private System.IO.Stream menu_ui_default_s_file_close = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_back.wav");
        //IV Note: menu_open sound file:
        static readonly private System.IO.Stream menu_ui_default_s_file_open = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_accept.wav");
        //IV Note: gallery_main_menu_open sound file:
        static readonly private System.IO.Stream menu_ui_iv_gallery_open_m_menu = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_horror01.wav");
        //IV Note: Boomer Secred Sound File Variation #1:
        static readonly private System.IO.Stream menu_ui_secred_sanya_boomer_sound_file_1 = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.boomerbacteria.wav");
        //IV Note: Boomer Secred Sound File Variation #2:
        static readonly private System.IO.Stream menu_ui_secred_sanya_boomer_sound_file_2 = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.boomerbacterias.wav");
        //IV Note: Picture Accept Sound File:
        static readonly private System.IO.Stream menu_ui_picture_accept = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.alert_clink.wav");
        //IV Note: UI Problem Sound File:
        static readonly private System.IO.Stream menu_ui_problem = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.beep_error01.wav");
        //IV Note: Close about_page UI Scenario sound:
        public SoundPlayer ui_s_wnd_def_close = new SoundPlayer(menu_ui_default_s_file_close);
        //IV Note: Open about_page UI Scenario sound:
        public SoundPlayer ui_s_wnd_def_open = new SoundPlayer(menu_ui_default_s_file_open);
        //IV Note: Open IV Gallery Main Menu sound:
        public SoundPlayer ui_s_wnd_g_m_m_open = new SoundPlayer(menu_ui_iv_gallery_open_m_menu);
        //IV Note: Boomer Begun #1 sound:
        public SoundPlayer ui_picture_boomer_s_01 = new SoundPlayer(menu_ui_secred_sanya_boomer_sound_file_1);
        //IV Note: Boomer Begun #2 sound:
        public SoundPlayer ui_picture_boomer_s_02 = new SoundPlayer(menu_ui_secred_sanya_boomer_sound_file_2);
        //IV Note: BG Picture Accept sound:
        public SoundPlayer ui_picture_accept_s = new SoundPlayer(menu_ui_picture_accept);
        //IV Note: Main UI Problem sound:
        public SoundPlayer ui_bug_s = new SoundPlayer(menu_ui_problem);

        private string[] IV_SM_Check_Active_Songs_Names()
        {
            string[] iv_sm_temp_active_songs = new string[7] { "ui_s_wnd_def_close", "ui_s_wnd_def_open",
                "ui_s_wnd_g_m_m_open", "ui_picture_boomer_s_01", "ui_picture_boomer_s_02",
                "ui_picture_accept_s", "ui_bug_s" };
            return iv_sm_temp_active_songs;
        }

        private SoundPlayer[] IV_SM_Check_Active_Songs()
        {
            SoundPlayer[] iv_sm_array_of_songs = new SoundPlayer[7] { ui_s_wnd_def_close, ui_s_wnd_def_open,
                ui_s_wnd_g_m_m_open, ui_picture_boomer_s_01, ui_picture_boomer_s_02,
                ui_picture_accept_s, ui_bug_s };
            return iv_sm_array_of_songs;
        }

        public IVSMasterCore()
        {
#if DEBUG
            IV_SM_Active_Sound_List(true, true);
#endif
        }

        public void IV_SM_Active_Sound_List(bool ask_message = false, bool play_songs_from_array = false)
        {
            var songs_list = "List of Active Songs: ";
            var iv_temp_sm_list = IV_SM_Check_Active_Songs_Names();
            var iv_dlg_show_songs_result = DialogResult.No;
            foreach (string song in iv_temp_sm_list)
            {
                var int_pos = Array.IndexOf(iv_temp_sm_list, song, 0) + 1;
                if (int_pos != iv_temp_sm_list.Length)
                    songs_list = songs_list + int_pos + ") " + song + ", ";
                else
                    songs_list = songs_list + int_pos + ") " + song + ".";
            }

            if(ask_message)
            {
                ui_picture_accept_s.Play();
                var dlg_result = MessageBox.Show("Show Available sound List?", iv_sm_logo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlg_result == DialogResult.Yes)
                {
                    iv_dlg_show_songs_result = dlg_result;
                    ui_picture_accept_s.Play();
                    MessageBox.Show(songs_list, iv_sm_logo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ui_picture_accept_s.Play();
                MessageBox.Show(songs_list, iv_sm_logo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(play_songs_from_array && iv_dlg_show_songs_result == DialogResult.Yes)
            {
                ui_picture_accept_s.Play();
                var dlg_result = MessageBox.Show("Play songs from array for Testing That?", iv_sm_logo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlg_result == DialogResult.Yes)
                {
                    var iv_sm_array_temp = IV_SM_Check_Active_Songs();
                    foreach (SoundPlayer sm_temp in iv_sm_array_temp)
                    {
                        var int_s_position = Array.IndexOf(iv_sm_array_temp, sm_temp, 0);
                        var int_s_number = int_s_position + 1;
                        sm_temp.Play();
                        MessageBox.Show("Song #"+int_s_number+" - "+ iv_temp_sm_list[int_s_position], iv_sm_logo);
                        if(int_s_number == iv_sm_array_temp.Length)
                            MessageBox.Show("All Songs Testing - Complete!!!", iv_sm_logo);
                    }
                }
            }
        }
    }
}
