﻿using System;
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
        bool first_d3x_inited = true;
        int Width = 1280;
        int Height = 720;
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

        private D3D11.InputElement[] IVEngine_inputElements = new D3D11.InputElement[]
        {
            new D3D11.InputElement("POSITION", 0, Format.R32G32B32_Float, 0)
        };

        // Triangle vertices
        private Vector3[] IVvertices = new Vector3[] { new Vector3(-0.5f, 0.5f, 0.0f), new Vector3(0.5f, 0.5f, 0.0f), new Vector3(0.0f, -0.5f, 0.0f) };
        private D3D11.Buffer IVtriangleVertexBuffer;

        public DXCoreTest()
        {
            IV_INIT_D3X_Window();
        }

        public void Run()
        {
            if (!IV_Gallery_Main_Menu.d3x_opened)
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
            IVtriangleVertexBuffer = D3D11.Buffer.Create<Vector3>(IVDXDevice, D3D11.BindFlags.VertexBuffer, IVvertices);
        }

        private void IV_INIT_D3X_Window()
        {
            DXWnd = new RenderForm("IV DirectX Render Window");
            DXWnd.ClientSize = new Size(Width, Height);
            DXWnd.AllowUserResizing = false;
            DXWnd.SuspendLayout();
            DXWnd.FormClosing += new System.Windows.Forms.FormClosingEventHandler(IV_DX_WND_Closed_Hook);
            IV_Gallery_Main_Menu.d3x_opened = true;
            DXWnd.ResumeLayout(false);
            DXWnd.PerformLayout();

            IV3DXInitializeDeviceResources();
            IV3DXInitializeShaders();
            IV3DXInitializeTriangle();
        }

        private void IV_RUN_D3X_Window_Simple()
        {
            IV_INIT_D3X_Window();
            DXWnd.Icon = IV_Gallery_Main_Menu.iv_g_m_m.Icon;

            RenderLoop.Run(DXWnd, RenderCallback);
        }

        private void IVD3X_Draw()
        {
            // Set back buffer as current render target view
            IVDXDeviceContext.OutputMerger.SetRenderTargets(IVrenderTargetView);

            // Clear the screen
            IVDXDeviceContext.ClearRenderTargetView(IVrenderTargetView, new SharpDX.Color(32, 103, 178));

            // Set vertex buffer
            IVDXDeviceContext.InputAssembler.SetVertexBuffers(0, new D3D11.VertexBufferBinding(IVtriangleVertexBuffer, Utilities.SizeOf<Vector3>(), 0));

            // Draw the triangle
            IVDXDeviceContext.Draw(IVvertices.Count(), 0);

            // Swap front and back buffer
            IVswapChain.Present(1, PresentFlags.None);
        }

        private void IV_DX_WND_Closed_Hook(object sender, FormClosingEventArgs e)
        {
            if (DXWnd.Visible && !IV_Gallery_Main_Menu.ivdx_shutdown_silent)
            {
                const string dlg_message =
                "Closing IV DirectX Window?";
                const string dlg_caption = "IV DirectX Manager";
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
                    IV_Gallery_Main_Menu.d3x_opened = false;
                    IV_Gallery_Checkers_Core.IVCheckerCore.iv_s_manager.ui_s_wnd_def_close.Play();
                }
            }
            else
            {
                IV_Gallery_Main_Menu.d3x_opened = false;
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
