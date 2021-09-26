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
        }

        //////////////////////////////
        //IV Note: Main Menu Parms://
        ////////////////////////////
        bool iv_mm_bg_clicked = false;
        static public Image iv_bg_default = global::IV_Gallery.Properties.Resources.THSSourcelogoF_source_loading;

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
        }

        private void IV_Exit_Click_Scenario(object sender, EventArgs e)
        {
            iv_g_m_m.Close();
        }
    }
}
