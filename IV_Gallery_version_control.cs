//#define IV_GALLERY_VER_045 //Old Version
//#define IV_GALLERY_VER_048 //Old Version
//#define IV_GALLERY_VER_05 //Old Version
//#define IV_GALLERY_VER_052 //Old Version
//#define IV_GALLERY_VER_053 // Old Version
//#define IV_GALLERY_VER_054 //Defined in build symbols

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WND_FORMS = System.Windows.Forms;
using iv_gallery_main_menu = IV_Gallery.IV_Gallery_Main_Menu;
using checkers_core = IV_Gallery_Checkers_Core.IVCheckerCore;


namespace IV_Gallery
{
    public class IV_Gallery_Version_Manager
    {
        //IV Note: Main class parms:
#if IV_GALLERY_VER_054
        private readonly static float iv_gallery_main_version = 0.54f;
#endif

        public IV_Gallery_Version_Manager()
        {
            IV_VM_Validate_Versions();
        }

        ~IV_Gallery_Version_Manager()
        {
        }

        public void IV_VM_Validate_Versions()
        {
            if (iv_gallery_main_menu.IV_Gallery_Get_Version() != iv_gallery_main_version)
            {
#if DEBUG
                bool is_error = false;
                string problem_message = "Version Manager founded a bug!!! Invaid Version Indefier!!! FIXME!!!" + " In Debug Mode programm not be crashed, but " +
                    "some problems must be founded!!!";
#else
                bool is_error = true;
                string problem_message = "Version Manager founded a bug!!! Invaid Version Indefier!!! FIXME!!!";
#endif
                iv_gallery_main_menu.IV_Gallery_Set_Version(iv_gallery_main_version);
                iv_gallery_main_menu.IV_Release_Problem_Message(problem_message, is_error);
            }
            else
            {
                checkers_core.iv_s_manager.ui_picture_accept_s.Play();
                WND_FORMS.MessageBox.Show("Version Manager Validate file versions sucessfull!!! Version - "
                    + iv_gallery_main_menu.IV_Gallery_Get_Version(), "IV Version Manager", WND_FORMS.MessageBoxButtons.OK, WND_FORMS.MessageBoxIcon.Information);
            }
        }
    }
}
