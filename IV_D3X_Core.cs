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
using SharpDX.D3DCompiler;
using SharpDX.DXGI;
using SharpDX.Windows;
using D3D11 = SharpDX.Direct3D11;

namespace IV_Gallery
{
    class DXCoreTest : IDisposable
    {
        public RenderForm DXWnd;
        private readonly static string thsdev_iv_d3x_logo = IV_Gallery_Main_Menu.thsdev_iv_logo + " DirectX (D3X) Visualiser";
        public bool d3x_opened = false;
        public bool ivdx_shutdown_silent = false;
        private bool first_d3x_inited = true;
        static readonly private int Width = 1280;
        static private readonly int Height = 720;
        private D3D11.Device IVDXDevice;
        private D3D11.DeviceContext IVDXDeviceContext;
        private SwapChain IVswapChain;
        private D3D11.RenderTargetView IVrenderTargetView;
        private Viewport IV3DXviewport;

        // Shaders
        private D3D11.VertexShader IV_G_Test_VertexShader;
        private D3D11.PixelShader IV_G_Test_PixelShader;
        private ShaderSignature IVEngine_inputSignature;
        private D3D11.InputLayout IVEngine_inputLayout;

        private readonly D3D11.InputElement[] IVEngine_inputElements = new D3D11.InputElement[]
        {
            new D3D11.InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0, D3D11.InputClassification.PerVertexData, 0),
            new D3D11.InputElement("COLOR", 0, Format.R32G32B32A32_Float, 12, 0, D3D11.InputClassification.PerVertexData, 0)
        };

        // Triangle vertices
        private readonly IV_VertexPosColor[] IVvertices = new IV_VertexPosColor[] { new IV_VertexPosColor(new Vector3(-0.5f, 0.5f, 0.0f), SharpDX.Color.Red), new IV_VertexPosColor(new Vector3(0.5f, 0.5f, 0.0f), SharpDX.Color.Green), new IV_VertexPosColor(new Vector3(0.0f, -0.5f, 0.0f), SharpDX.Color.Blue) };
        private D3D11.Buffer IVtriangleVertexBuffer;

        public DXCoreTest()
        {
            IV_INIT_D3X_Window();
        }

        public void Run()
        {
            if (!d3x_opened)
            {
                IV_RUN_D3X_Window_Simple();
            }
            else
            {
                if (DXWnd.Icon != IV_Gallery_Main_Menu.iv_g_m_m.Icon)
                    DXWnd.Icon = IV_Gallery_Main_Menu.iv_g_m_m.Icon;
                if (first_d3x_inited)
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
            ModeDescription IVDXbackBufferDesc = new ModeDescription(Width, Height, new Rational(60, 1), Format.R8G8B8A8_UNorm);

            // Descriptor for the swap chain
            SwapChainDescription IVDXswapChainDesc = new SwapChainDescription()
            {
                ModeDescription = IVDXbackBufferDesc,
                SampleDescription = new SampleDescription(1, 0),
                Usage = Usage.RenderTargetOutput,
                BufferCount = 1,
                OutputHandle = DXWnd.Handle,
                IsWindowed = true
            };

            // Create device and swap chain
            D3D11.Device.CreateWithSwapChain(DriverType.Hardware, D3D11.DeviceCreationFlags.None, IVDXswapChainDesc, out IVDXDevice, out IVswapChain);
            IVDXDeviceContext = IVDXDevice.ImmediateContext;

            IV3DXviewport = new Viewport(0, 0, Width, Height);
            IVDXDeviceContext.Rasterizer.SetViewport(IV3DXviewport);

            // Create render target view for back buffer
            using (D3D11.Texture2D backBuffer = IVswapChain.GetBackBuffer<D3D11.Texture2D>(0))
            {
                IVrenderTargetView = new D3D11.RenderTargetView(IVDXDevice, backBuffer);
            }
        }

        private void IV3DXInitializeShaders()
        {
            // Compile the vertex shader code
            using (var IVEngineVertexShaderByteCode = ShaderBytecode.CompileFromFile("iv_shaders_cache/gallery_test_vertexShader.hlsl", "main", "vs_4_0", ShaderFlags.Debug))
            {
                // Read input signature from shader code
                IVEngine_inputSignature = ShaderSignature.GetInputSignature(IVEngineVertexShaderByteCode);

                IV_G_Test_VertexShader = new D3D11.VertexShader(IVDXDevice, IVEngineVertexShaderByteCode);
            }

            // Compile the pixel shader code
            using (var IVEnginePixelShaderByteCode = ShaderBytecode.CompileFromFile("iv_shaders_cache/gallery_test_pixelShader.hlsl", "main", "ps_4_0", ShaderFlags.Debug))
            {
                IV_G_Test_PixelShader = new D3D11.PixelShader(IVDXDevice, IVEnginePixelShaderByteCode);
            }

            // Set as current vertex and pixel shaders
            IVDXDeviceContext.VertexShader.Set(IV_G_Test_VertexShader);
            IVDXDeviceContext.PixelShader.Set(IV_G_Test_PixelShader);

            IVDXDeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;

            // Create the input layout from the input signature and the input elements
            IVEngine_inputLayout = new D3D11.InputLayout(IVDXDevice, IVEngine_inputSignature, IVEngine_inputElements);

            // Set input layout to use
            IVDXDeviceContext.InputAssembler.InputLayout = IVEngine_inputLayout;
        }

        private void IV3DXInitializeTriangle()
        {
            // Create a vertex buffer, and use our array with vertices as data
            IVtriangleVertexBuffer = D3D11.Buffer.Create(IVDXDevice, D3D11.BindFlags.VertexBuffer, IVvertices);
        }

        private void IV_INIT_D3X_Window()
        {
            DXWnd = new RenderForm(thsdev_iv_d3x_logo)
            {
                ClientSize = new Size(Width, Height),
                AllowUserResizing = false
            };
            DXWnd.SuspendLayout();
            DXWnd.FormBorderStyle = FormBorderStyle.None;
            DXWnd.Load += IVD3X_Load_Window;
            DXWnd.FormClosing += IV_DX_WND_Closed_Hook;
            d3x_opened = true;
            DXWnd.ResumeLayout(false);
            DXWnd.PerformLayout();

            /*IV3DXInitializeDeviceResources();
            IV3DXInitializeShaders();
            IV3DXInitializeTriangle();*/
        }

        private void IVD3X_Load_Window(object sender, EventArgs e)
        {
            IV3DXInitializeDeviceResources();
            IV3DXInitializeShaders();
            IV3DXInitializeTriangle();
            DXWnd.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void IV_RUN_D3X_Window_Simple()
        {
            IV_INIT_D3X_Window();
            DXWnd.Icon = IV_Gallery_Main_Menu.iv_g_m_m.Icon;

            RenderLoop.Run(DXWnd, RenderCallback);
        }

        private void IVD3X_Draw()
        {
            // Set render targets
            IVDXDeviceContext.OutputMerger.SetRenderTargets(IVrenderTargetView);

            // Clear the screen
            IVDXDeviceContext.ClearRenderTargetView(IVrenderTargetView, new SharpDX.Color(32, 103, 178));

            // Set vertex buffer
            IVDXDeviceContext.InputAssembler.SetVertexBuffers(0, new D3D11.VertexBufferBinding(IVtriangleVertexBuffer, Utilities.SizeOf<IV_VertexPosColor>(), 0));

            // Draw the triangle
            IVDXDeviceContext.Draw(IVvertices.Count(), 0);

            // Swap front and back buffer
            IVswapChain.Present(1, PresentFlags.None);
        }

        private void IV_DX_WND_Closed_Hook(object sender, FormClosingEventArgs e)
        {
            if (DXWnd.Visible && !ivdx_shutdown_silent)
            {
                string dlg_message =
                "Close "+ thsdev_iv_d3x_logo + "?";
                string dlg_caption = thsdev_iv_d3x_logo;
                var dlg_result = MessageBox.Show(dlg_message, dlg_caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                // If the no button was pressed ...
                if (dlg_result == DialogResult.No)
                {
                    // cancel the closure of the form.
                    e.Cancel = true;
                }
                else
                {
                    d3x_opened = false;
                    IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                    this.Dispose();
                }
            }
            else
            {
                d3x_opened = false;
                IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
            }
        }

        public void Dispose()
        {
            IVEngine_inputLayout.Dispose();
            IVEngine_inputSignature.Dispose();
            IVtriangleVertexBuffer.Dispose();
            IV_G_Test_VertexShader.Dispose();
            IV_G_Test_PixelShader.Dispose();
            IVrenderTargetView.Dispose();
            IVswapChain.Dispose();
            IVDXDevice.Dispose();
            IVDXDeviceContext.Dispose();
            DXWnd.Dispose();
        }
    }
}
