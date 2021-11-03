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
    public partial class IV_MP_Tool_Chose_Internet_Video : Form
    {
        public IV_MP_Tool_Chose_Internet_Video()
        {
            InitializeComponent();
            if (iv_imf_default_enter_message == String.Empty)
                iv_imf_default_enter_message = IV_IMF_Link_Chose_Panel.Text;
            iv_imf_inited = true;
        }

        private static string iv_imf_default_enter_message = String.Empty;
        private string iv_imf_media_link = String.Empty;
        public bool iv_imf_inited = false;
        private bool iv_imf_default_search_text_restore = false;

        private void IV_IMF_Link_Panel_Text_Changed(object sender, EventArgs e)
        {
            if (IV_IMF_Link_Chose_Panel.Text == String.Empty)
            {
                if(iv_imf_default_search_text_restore)
                {
                    iv_imf_default_search_text_restore = false;
                    IV_IMF_Link_Chose_Panel.Text = iv_imf_default_enter_message;
                }
                IV_IMF_B_Search_URL.Visible = false;
            }
            else
            {
                IV_IMF_B_Search_URL.Visible = true;
            }
        }

        /*private void IV_IMF_Web_Loaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }*/

        private void IV_IMF_B_Search_Click(object sender, EventArgs e)
        {
            iv_imf_media_link = IV_IMF_Link_Chose_Panel.Text;
            iv_imf_default_search_text_restore = true;
            IV_IMF_Link_Chose_Panel.Text = String.Empty;
            Uri iv_media_link = new Uri("https://vk.com/id504177837");
            if (Uri.TryCreate(iv_media_link, iv_imf_media_link, out Uri CheckedUri))
                iv_media_link = CheckedUri;

            IV_Media_Player.iv_mp_url_link = iv_media_link.ToString();
            IV_Media_Player.iv_mp_url_chosed = true;
            IV_IMF_T_to_Close.Enabled = true;
        }

        private void IV_IMF_Force_Closed(object sender, FormClosedEventArgs e)
        {
            iv_imf_inited = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }

        private void IV_IMF_Loaded(object sender, EventArgs e)
        {
            iv_imf_inited = true;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
        }

        /*private void IV_IMF_T_Test_Site_load_State_Think(object sender, EventArgs e)
        {
            if (IV_IMF_WebBrowser_Test_URL.ReadyState == WebBrowserReadyState.Complete)
            {
                IV_IMF_T_Test_Site.Enabled = false;
                this.Close();
            }
        }*/

        private void IV_IMF_B_BG_Color_P_Hook(object sender, EventArgs e)
        {
            var iv_color = IV_IMF_Color_Manager.ShowDialog();
            if(iv_color == DialogResult.OK)
            {
                this.BackColor = IV_IMF_Color_Manager.Color;
            }
        }

        private int iv_imf_ready_to_close = 4;

        private void IV_IMF_T_Close_Hook(object sender, EventArgs e)
        {
            if(iv_imf_ready_to_close == 4)
            {
                iv_imf_ready_to_close--;
                IV_IMF_Count_to_Close_Label.Visible = true;
            }
            else if(iv_imf_ready_to_close <= 3 && iv_imf_ready_to_close >= 0)
            {
                IV_IMF_Count_to_Close_Label.Text = iv_imf_ready_to_close.ToString();
                iv_imf_ready_to_close--;
            }
            else if(iv_imf_ready_to_close == -1)
            {
                iv_imf_ready_to_close--;
                IV_IMF_Count_to_Close_Label.Text = "Closing...";
                IV_IMF_Count_to_Close_Label.AutoSize = true;
            }
            else if(iv_imf_ready_to_close == -2)
            {
                IV_IMF_T_to_Close.Enabled = false;
                this.Close();
            }
        }
    }
}
