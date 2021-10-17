using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp;
using LibVLCSharp.Shared;

namespace IV_Gallery
{
    public partial class IV_Media_Player : Form
    {
        public IV_Media_Player()
        {
            InitializeComponent();
            IV_MP_INIT_VLC();
        }

        public bool iv_mp_closed = false;
        private bool ivmp_stopped = true;
        
        //VLC stuff
        private LibVLC ivmp_lib;
        private MediaPlayer ivmp;
        private Media ivmp_media_temp;
        private Media ivmp_media(string media_path = null)
        {
            if(media_path != String.Empty && media_path != null)
            {
                ivmp_media_temp = new Media(ivmp_lib, media_path);
                return ivmp_media_temp;
            }
            else
            {
                IV_Gallery_Main_Menu.IV_Release_Problem_Message("Media Result - ERROR!!!");
                return null;
            }
        }

        private void IV_MP_INIT_VLC()
        {
            Core.Initialize();
            ivmp_lib = new LibVLC();
            ivmp = new MediaPlayer(ivmp_lib);
            IV_MP_Main.MediaPlayer = ivmp;
            IV_MP_Volume_Bar.Value = ivmp.Volume;
        }

        private void IV_Button_SChange_Press_Hook(object sender, EventArgs e)
        {
            IV_MP_File_Dialog.ShowDialog();
        }

        private void IV_Music_Player_Close_Hook(object sender, FormClosedEventArgs e)
        {
            iv_mp_closed = true;
            ivmp.Stop();
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }

        private void IV_MP_Load_Hook(object sender, EventArgs e)
        {
            iv_mp_closed = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_mp_showed = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
        }

        private void IV_MP_DLG_Result(object sender, CancelEventArgs e)
        {
            var iv_fl_path = String.Empty;
            iv_fl_path = IV_MP_File_Dialog.FileName;
            if (iv_fl_path.Contains(".mp3") || iv_fl_path.Contains(".wav") || iv_fl_path.Contains(".avi") || iv_fl_path.Contains(".mp4")
                || iv_fl_path.Contains(".mkv"))
            {
                ivmp_media(iv_fl_path);
                var dlg_question = MessageBox.Show("Play this Media?", IV_Gallery_Main_Menu.thsdev_iv_logo + " Media Player Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dlg_question == DialogResult.Yes)
                {
                    ivmp_stopped = false;
                    ivmp.Play(ivmp_media_temp);
                }
            }
            else
            {
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_bug_s.Play();
                MessageBox.Show("File no chosed or INVAID!!!", IV_Gallery_Main_Menu.thsdev_iv_logo + " Media Player Dialog");
            }
        }

        private void IV_MP_B_PlayStop_Hook(object sender, EventArgs e)
        {
            if(ivmp_stopped)
            {
                ivmp.Play();
            }
            else
            {
                ivmp.Pause();
            }
        }

        private void IV_MP_Volume_Scroll_Hook(object sender, EventArgs e)
        {
            ivmp.Volume = IV_MP_Volume_Bar.Value;
        }
    }
}
