using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iv_g_main_hook = IV_Gallery.IV_Gallery_Main_Menu;

namespace IV_Gallery
{
    public partial class IV_Gallery_Settings_Menu : Form
    {
        public IV_Gallery_Settings_Menu()
        {
            InitializeComponent();
        }
        ~IV_Gallery_Settings_Menu()
        {
            iv_g_setting_are_changed = false;
        }

        public bool iv_g_setting_are_changed = false;
        public bool iv_settings_closed = false;
        private Siticone.Desktop.UI.WinForms.SiticoneButton[] iv_main_object_buttons = null;
        bool[] iv_s_button_realised = null;

        private void IV_Settings_Button_Exit(object sender, EventArgs e)
        {
            this.Visible = false;

            if(iv_g_setting_are_changed)
            {
                var iv_dlg_save_settings = MessageBox.Show("Save Currient Settings?", iv_g_main_hook.thsdev_iv_warning_logo, 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if(iv_dlg_save_settings == DialogResult.Yes)
                {
                    MessageBox.Show("Currient Settings are Saved!", iv_g_main_hook.thsdev_iv_logo,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    iv_g_setting_are_changed = false;
                }
                else if(iv_dlg_save_settings == DialogResult.Cancel)
                {
                    this.Visible = true;
                }
                else
                    Close();
            }
            else
                Close();
        }

        private void IV_Settings_Menu_Loaded(object sender, EventArgs e)
        {
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();

            if (iv_main_object_buttons == null)
            iv_main_object_buttons = new Siticone.Desktop.UI.WinForms.SiticoneButton[12] {IV_S_UI_Structure_01, IV_S_UI_Structure_02, IV_S_UI_Structure_03, 
                IV_S_UI_Structure_04, IV_S_UI_Structure_05, IV_S_UI_Structure_06, IV_S_UI_Structure_07, IV_S_UI_Structure_08, IV_S_UI_Structure_09, 
                IV_S_UI_Structure_10, IV_S_UI_Structure_11, IV_S_UI_Structure_12 };

            iv_s_button_realised = new bool[iv_main_object_buttons.Length];

            for(int i = 0; i < iv_s_button_realised.Length; i++ )
            {
                iv_s_button_realised[i] = false;
            }
        }

        private void IV_Settings_Force_Close(object sender, FormClosedEventArgs e)
        {
            iv_settings_closed = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }

        private void IV_Settings_Change_Active_Visible(bool state)
        {
            if (!this.AllowTransparency)
                this.AllowTransparency = true;

            if (state)
                this.Opacity = 100;
            else
                this.Opacity = 60;
        }

        private void IV_Settings_Active_Panel(object sender, EventArgs e)
        {
            IV_Settings_Change_Active_Visible(true);
        }

        private void IV_Settings_INActive_Panel(object sender, EventArgs e)
        {
            IV_Settings_Change_Active_Visible(false);
        }
    }
}
