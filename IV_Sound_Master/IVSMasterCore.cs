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
        //IV Note: Assembly for reading inluded resources in that core:
        static private System.Reflection.Assembly iv_core_assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //IV Note: Default Empty Route to used (Close about_page UI Scenario) sound file:
        static private System.IO.Stream menu_ui_default_s_file_close = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_back.wav");
        //IV Note: Default Empty Route to used (Open about_page UI Scenario) sound file:
        static private System.IO.Stream menu_ui_default_s_file_open = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_accept.wav");
        //IV Note: Default Empty Route to used (Open about_page UI Scenario) sound file:
        static private System.IO.Stream menu_ui_iv_gallery_open_m_menu = iv_core_assembly.GetManifestResourceStream(@"IV_Sound_Master.iv_sound_cache.menu_horror01.wav");
        //IV Note: Close about_page UI Scenario sound:
        public SoundPlayer ui_s_wnd_def_close = new SoundPlayer(menu_ui_default_s_file_close);
        //IV Note: Open about_page UI Scenario sound:
        public SoundPlayer ui_s_wnd_def_open = new SoundPlayer(menu_ui_default_s_file_open);
        //IV Note: Open IV Gallery Main Menu sound:
        public SoundPlayer ui_s_wnd_g_m_m_open = new SoundPlayer(menu_ui_iv_gallery_open_m_menu);
    }
}
