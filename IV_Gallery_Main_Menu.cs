#define IV_GALLERY_VER_045

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.DXGI;
using SharpDX.Windows;
using D3D11 = SharpDX.Direct3D11;


namespace IV_Gallery
{
    public partial class IV_Gallery_Main_Menu : Form
    {
        public IV_Gallery_Main_Menu()
        {
            InitializeComponent();
            if(iv_gallery_prog_name == iv_gallery_prog_name_checker_list[0] && iv_gallery_prog_ver == list_of_supported_ch_core_vers[5])
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name_checker_list[0], list_of_supported_ch_core_vers[5]);
            else
                iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name, iv_gallery_prog_ver);
            if (IV_Gallery_Checkers_Core.IVCheckerCore.iv_checker_dll_code_ver == last_supported_iv_ch_c_ver)
            {
                IV_Button_App_Info.Visible = true;
            }
            if(IV_G_Check_DEBUG_Core_State())
            {
                debug_mode = true;
                iv_g_m_m.MaximizeBox = true;
            }
            if(IV_Gallery_MM_BG_Picture.Image != iv_bg_default)
            {
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
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
        static public bool d3x_opened = false;
        int int_to_debug = 0;
        int iv_sb_released_state = 0;
#if IV_GALLERY_VER_045
        static float iv_gallery_prog_ver = 0.45f;
#endif
        static float last_supported_iv_ch_c_ver = 0.4f;
        static float[] list_of_supported_ch_core_vers = IV_Gallery_Checkers_Core.IVCheckerCore.supported_vers_p_and_iv_c_c;
        static string iv_gallery_prog_name = "IV_Gallery";
        static string[] iv_gallery_prog_name_checker_list = IV_Gallery_Checkers_Core.IVCheckerCore.iv_gallery_prog_name;
        static public Image iv_bg_default = Properties.Resources.THSSourcelogoF_source_loading;
        static public IV_Gallery_Checkers_Core.IVCheckerCore iv_ch_core = new IV_Gallery_Checkers_Core.IVCheckerCore();
        SoundPlayer[] iv_boomer_random = new SoundPlayer[2] { IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_boomer_s_01, IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_picture_boomer_s_02 };
        DXCoreTest iv_3dx_render = new DXCoreTest();

        private void IV_MM_BG_D_Click(object sender, EventArgs e)
        {
            if(int_to_debug != 8)
            {
                int_to_debug = int_to_debug + 1;
            }
#if DEBUG
            else if(int_to_debug == 8 && !debug_mode && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                debug_mode = true;
                iv_g_m_m.MaximizeBox = true;
                iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                if(!d3x_opened || iv_3dx_render.DXWnd.Visible == false)
                    iv_3dx_render.Run();
            }
            else if(int_to_debug == 8 && debug_mode && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                debug_mode = false;
                iv_g_m_m.MaximizeBox = false;
                iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                if(d3x_opened)
                    iv_3dx_render.DXWnd.Visible = false;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            }
#else
            else if(int_to_debug == 8 && IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible)
            {
                int_to_debug = 0;
                string dlg_message = "Do you want to ENABLE/DISABLE Debug Mode?";
                string dlg_iv_msg_logo = "IV Debug Mode";
                var dlg_result = MessageBox.Show(dlg_message, dlg_iv_msg_logo,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                if(dlg_result == DialogResult.Yes)
                {
                    debug_mode = true;
                    iv_g_m_m.MaximizeBox = true;
                    iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                    if (!d3x_opened || iv_3dx_render.DXWnd.Visible == false)
                        iv_3dx_render.Run();
                }
                else
                {
                    debug_mode = false;
                    iv_g_m_m.MaximizeBox = false;
                    iv_ch_core.IV_Release_DEBUG_MODE(debug_mode);
                    if (d3x_opened)
                        iv_3dx_render.DXWnd.Visible = false;
                    IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                }
            }
#endif
            if (debug_mode)
            {
                if (iv_mm_bg_clicked == false)
                {
                    iv_mm_bg_clicked = true;
                }
                else
                {
                    iv_mm_bg_clicked = false;
                }
                CheckIVBGClickedStatus(iv_mm_bg_clicked);
            }
            if(!debug_mode && IV_Gallery_MM_BG_Picture.Image != iv_bg_default)
            {
                CheckIVBGClickedStatus(false);
            }
        }

        private void CheckIVBGClickedStatus(bool clicked)
        {
            //IV Note: Random scenario for chosing boomer sounds
            Random iv_rnd_for_boomer = new Random();
            if (clicked == true)
            {
                IV_Gallery_MM_BG_Picture.Image = Properties.Resources.SanyaLogoF;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
                iv_boomer_random[iv_rnd_for_boomer.Next(0, 2)].Play();
                IV_G_Button_Exit.Visible = false;
            }
            else
            {
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
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
            int_to_debug = 0;
            if (debug_mode)
                MessageBox.Show("Thank you for testing that programm. Goodbye!!!", "IV");
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Close();
            if (d3x_opened)
                iv_3dx_render.ShutDown();
            iv_g_m_m.Hide();
            IV_T_Exit.Enabled = true;
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

        private bool IV_G_Check_DEBUG_Core_State()
        {
            if(iv_ch_core.debug_mode)
            {
                return iv_ch_core.debug_mode;
            }
            return false;
        }

        private void IV_T_Check_L_Display(object sender, EventArgs e)
        {
            IV_Time_Pre_Finish_Load.Enabled = false;
            IV_Release_Load_INFO();
        }

        private void IV_B_AppInfo_Hook(object sender, EventArgs e)
        {
            int_to_debug = 0;
            IV_THINK_AB_WINDOW_HOOK.Enabled = true;
            iv_ch_core.IV_Checker_Core_Release_Ver_Info(iv_gallery_prog_name, iv_gallery_prog_ver, true);
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_open.Play();
            IV_Release_Load_INFO(70);
        }

        private void IV_T_Exit_Scenario(object sender, EventArgs e)
        {
            if(d3x_opened)
                iv_3dx_render.ShutDown();
            iv_g_m_m.Close();
        }

        private void IV_MM_Load_Hook(object sender, EventArgs e)
        {
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_g_m_m_open.Play();
        }

        private void IV_Think_AB_WND_Hook(object sender, EventArgs e)
        {
            if(IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible == false && !IV_Gallery_Checkers_Core.IVCheckerCore.iv_ab_hide_hack)
            {
                IV_THINK_AB_WINDOW_HOOK.Enabled = false;
            }
            else if(IV_Gallery_Checkers_Core.IVCheckerCore.iv_app_inf_main.Visible == false && IV_Gallery_Checkers_Core.IVCheckerCore.iv_ab_hide_hack)
            {
                IV_THINK_AB_WINDOW_HOOK.Enabled = false;
                IV_Button_App_Info.Visible = false;
                IV_G_Button_Exit.Visible = false;
                if (d3x_opened)
                    iv_3dx_render.ShutDown();
                debug_mode = false;
                iv_ch_core.IV_Release_DEBUG_MODE(false);
                IV_Gallery_MM_BG_Picture.Image = iv_bg_default;
            }
        }
    }

    class DXCoreTest
    {
        public RenderForm DXWnd;
        bool first_d3x_inited = true;
        int Width = 1280;
        int Height = 720;
        private D3D11.Device IVDXDevice;
        private D3D11.DeviceContext IVDXDeviceContext;
        private SwapChain IVswapChain;
        private D3D11.RenderTargetView IVrenderTargetView;

        public DXCoreTest()
        {
            IV_INIT_D3X_Window();
        }

        public void Run()
        {
            if(!IV_Gallery_Main_Menu.d3x_opened)
            {
                IV_RUN_D3X_Window_Simple();
            }
            else
            {
                if(DXWnd.Icon != IV_Gallery_Main_Menu.iv_g_m_m.Icon)
                    DXWnd.Icon = IV_Gallery_Main_Menu.iv_g_m_m.Icon;
                if(first_d3x_inited)
                {
                    first_d3x_inited = false;
                    RenderLoop.Run(DXWnd, RenderCallback);
                }
                else
                {
                    DXWnd.Visible = true;
                }
            }
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_g_m_m_open.Play();
        }

        public void ShutDown()
        {
            DXWnd.Close();
        }

        public void RenderCallback()
        {
            IVD3X_Draw();
        }

        private void IV3DXInitializeDeviceResources()
        {
            ModeDescription ivdx_backBufferDesc = new ModeDescription(Width, Height, new Rational(60, 1), Format.R8G8B8A8_UNorm);

            // Descriptor for the swap chain
            SwapChainDescription ivdx_swapChainDesc = new SwapChainDescription()
            {
                ModeDescription = ivdx_backBufferDesc,
                SampleDescription = new SampleDescription(1, 0),
                Usage = Usage.RenderTargetOutput,
                BufferCount = 1,
                OutputHandle = DXWnd.Handle,
                IsWindowed = true
            };

            // Create device and swap chain
            D3D11.Device.CreateWithSwapChain(DriverType.Hardware, D3D11.DeviceCreationFlags.None, ivdx_swapChainDesc, out IVDXDevice, out IVswapChain);
            IVDXDeviceContext = IVDXDevice.ImmediateContext;

            // Create render target view for back buffer
            using (D3D11.Texture2D backBuffer = IVswapChain.GetBackBuffer<D3D11.Texture2D>(0))
            {
                IVrenderTargetView = new D3D11.RenderTargetView(IVDXDevice, backBuffer);
            }
        }

        private void IV_INIT_D3X_Window()
        {
            DXWnd = new RenderForm("IV DirectX Render Window");
            DXWnd.ClientSize = new Size(Width, Height);
            DXWnd.AllowUserResizing = false;
            DXWnd.SuspendLayout();
            DXWnd.FormClosed += new System.Windows.Forms.FormClosedEventHandler(IV_DX_WND_Closed_Hook);
            IV_Gallery_Main_Menu.d3x_opened = true;
            DXWnd.ResumeLayout(false);
            DXWnd.PerformLayout();

            IV3DXInitializeDeviceResources();
        }

        private void IV_RUN_D3X_Window_Simple()
        {
            DXWnd = new RenderForm("IV DirectX Render Window");
            DXWnd.ClientSize = new Size(Width, Height);
            DXWnd.AllowUserResizing = false;
            DXWnd.FormClosed += new System.Windows.Forms.FormClosedEventHandler(IV_DX_WND_Closed_Hook);
            IV_Gallery_Main_Menu.d3x_opened = true;
            DXWnd.Icon = IV_Gallery_Main_Menu.iv_g_m_m.Icon;
            
            IV3DXInitializeDeviceResources();

            RenderLoop.Run(DXWnd, RenderCallback);
        }

        private void IVD3X_Draw()
        {
            // Set back buffer as current render target view
            IVDXDeviceContext.OutputMerger.SetRenderTargets(IVrenderTargetView);

            // Clear the screen
            IVDXDeviceContext.ClearRenderTargetView(IVrenderTargetView, new SharpDX.Color(32, 103, 178));

            // Swap front and back buffer
            IVswapChain.Present(1, PresentFlags.None);
        }

        private void IV_DX_WND_Closed_Hook(object sender, FormClosedEventArgs e)
        {
            IV_Gallery_Main_Menu.d3x_opened = false;
            IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
        }
    }
}
