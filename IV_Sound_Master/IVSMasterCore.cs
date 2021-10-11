#define IV_S_MASTER_VER_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;

namespace IV_Sound_Master
{
    public class IVSMasterCore
    {
#if IV_S_MASTER_VER_03
        static public float iv_s_master_ver = 0.3f;
#endif
        //IV Note: Assembly for reading inluded resources in that core:
        static private System.Reflection.Assembly iv_core_assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //IV Note: menu_return sound file:
        static private System.IO.Stream menu_ui_default_s_file_close = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_back.wav");
        //IV Note: menu_open sound file:
        static private System.IO.Stream menu_ui_default_s_file_open = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_accept.wav");
        //IV Note: gallery_main_menu_open sound file:
        static private System.IO.Stream menu_ui_iv_gallery_open_m_menu = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_horror01.wav");
        //IV Note: Boomer Secred Sound File Variation #1:
        static private System.IO.Stream menu_ui_secred_sanya_boomer_sound_file_1 = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.boomerbacteria.wav");
        //IV Note: Boomer Secred Sound File Variation #2:
        static private System.IO.Stream menu_ui_secred_sanya_boomer_sound_file_2 = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.boomerbacterias.wav");
        //IV Note: Picture Accept Sound File:
        static private System.IO.Stream menu_ui_picture_accept = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.alert_clink.wav");
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
    }
}
