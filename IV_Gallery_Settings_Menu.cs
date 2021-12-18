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

        bool iv_g_setting_are_changed = false;

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
                {
                    IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                    Close();
                }
            }
            else
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                Close();
            }
        }

        private void IV_Settings_Menu_Loaded(object sender, EventArgs e)
        {

        }
    }
}
