
namespace IV_Gallery
{
    partial class IV_Gallery_Main_Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_Gallery_Main_Menu));
            this.IV_Gallery_MM_BG_Picture = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.IV_G_Button_Exit = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.IV_MM_Load_Status_Bar = new System.Windows.Forms.ProgressBar();
            this.IV_Time_WAIT_UN_Load = new System.Windows.Forms.Timer(this.components);
            this.IV_Time_Pre_Finish_Load = new System.Windows.Forms.Timer(this.components);
            this.IV_Button_App_Info = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.IV_T_Exit = new System.Windows.Forms.Timer(this.components);
            this.IV_AB_Exit_Info = new System.Windows.Forms.ToolTip(this.components);
            this.IV_AB_AppInfo_Info = new System.Windows.Forms.ToolTip(this.components);
            this.IV_THINK_AB_WINDOW_HOOK = new System.Windows.Forms.Timer(this.components);
            this.IV_B_Debug_ChangeBGImage = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.IV_DLG_BG_IMG_Finder = new System.Windows.Forms.OpenFileDialog();
            this.IV_AB_ChangeBG_Button = new System.Windows.Forms.ToolTip(this.components);
            this.IV_B_Debug_Resset_BG_IMG_TO_Def = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.IV_M_M_Animated_Load = new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(this.components);
            this.IV_T_Load_Check = new System.Windows.Forms.Timer(this.components);
            this.IV_B_Gallery_Settings = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            ((System.ComponentModel.ISupportInitialize)(this.IV_Gallery_MM_BG_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // IV_Gallery_MM_BG_Picture
            // 
            this.IV_Gallery_MM_BG_Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IV_Gallery_MM_BG_Picture.ErrorImage = global::IV_Gallery.Properties.Resources.ths_hammer_icon;
            this.IV_Gallery_MM_BG_Picture.Image = global::IV_Gallery.Properties.Resources.THSSourcelogoF_source_loading;
            this.IV_Gallery_MM_BG_Picture.ImageRotate = 0F;
            this.IV_Gallery_MM_BG_Picture.InitialImage = global::IV_Gallery.Properties.Resources.ths_icon;
            this.IV_Gallery_MM_BG_Picture.Location = new System.Drawing.Point(0, 0);
            this.IV_Gallery_MM_BG_Picture.Name = "IV_Gallery_MM_BG_Picture";
            this.IV_Gallery_MM_BG_Picture.ShadowDecoration.Parent = this.IV_Gallery_MM_BG_Picture;
            this.IV_Gallery_MM_BG_Picture.Size = new System.Drawing.Size(800, 577);
            this.IV_Gallery_MM_BG_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IV_Gallery_MM_BG_Picture.TabIndex = 0;
            this.IV_Gallery_MM_BG_Picture.TabStop = false;
            this.IV_Gallery_MM_BG_Picture.DoubleClick += new System.EventHandler(this.IV_MM_BG_D_Click);
            // 
            // IV_G_Button_Exit
            // 
            this.IV_G_Button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_G_Button_Exit.Animated = true;
            this.IV_G_Button_Exit.AutoRoundedCorners = true;
            this.IV_G_Button_Exit.BackColor = System.Drawing.Color.Transparent;
            this.IV_G_Button_Exit.BorderRadius = 14;
            this.IV_G_Button_Exit.CheckedState.Parent = this.IV_G_Button_Exit;
            this.IV_G_Button_Exit.CustomImages.Parent = this.IV_G_Button_Exit;
            this.IV_G_Button_Exit.DisabledState.Parent = this.IV_G_Button_Exit;
            this.IV_G_Button_Exit.FillColor = System.Drawing.SystemColors.InactiveCaption;
            this.IV_G_Button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.IV_G_Button_Exit.ForeColor = System.Drawing.Color.Black;
            this.IV_G_Button_Exit.HoverState.Parent = this.IV_G_Button_Exit;
            this.IV_G_Button_Exit.Location = new System.Drawing.Point(708, 535);
            this.IV_G_Button_Exit.Name = "IV_G_Button_Exit";
            this.IV_G_Button_Exit.ShadowDecoration.Parent = this.IV_G_Button_Exit;
            this.IV_G_Button_Exit.Size = new System.Drawing.Size(80, 30);
            this.IV_G_Button_Exit.TabIndex = 1;
            this.IV_G_Button_Exit.Text = "Exit";
            this.IV_AB_Exit_Info.SetToolTip(this.IV_G_Button_Exit, "Click to that Button if you want to Exit.");
            this.IV_G_Button_Exit.UseTransparentBackground = true;
            this.IV_G_Button_Exit.Click += new System.EventHandler(this.IV_Exit_Click_Scenario);
            // 
            // IV_MM_Load_Status_Bar
            // 
            this.IV_MM_Load_Status_Bar.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.IV_MM_Load_Status_Bar.ForeColor = System.Drawing.Color.Lime;
            this.IV_MM_Load_Status_Bar.Location = new System.Drawing.Point(0, 0);
            this.IV_MM_Load_Status_Bar.Name = "IV_MM_Load_Status_Bar";
            this.IV_MM_Load_Status_Bar.Size = new System.Drawing.Size(100, 23);
            this.IV_MM_Load_Status_Bar.TabIndex = 2;
            this.IV_MM_Load_Status_Bar.Visible = false;
            // 
            // IV_Time_WAIT_UN_Load
            // 
            this.IV_Time_WAIT_UN_Load.Tick += new System.EventHandler(this.IV_L_TIME_HOOK);
            // 
            // IV_Time_Pre_Finish_Load
            // 
            this.IV_Time_Pre_Finish_Load.Interval = 3000;
            this.IV_Time_Pre_Finish_Load.Tick += new System.EventHandler(this.IV_T_Check_L_Display);
            // 
            // IV_Button_App_Info
            // 
            this.IV_Button_App_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IV_Button_App_Info.Animated = true;
            this.IV_Button_App_Info.CheckedState.Parent = this.IV_Button_App_Info;
            this.IV_Button_App_Info.CustomImages.Parent = this.IV_Button_App_Info;
            this.IV_Button_App_Info.DisabledState.Parent = this.IV_Button_App_Info;
            this.IV_Button_App_Info.FillColor = System.Drawing.SystemColors.Info;
            this.IV_Button_App_Info.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IV_Button_App_Info.ForeColor = System.Drawing.Color.Black;
            this.IV_Button_App_Info.HoverState.Parent = this.IV_Button_App_Info;
            this.IV_Button_App_Info.Location = new System.Drawing.Point(0, 557);
            this.IV_Button_App_Info.Name = "IV_Button_App_Info";
            this.IV_Button_App_Info.ShadowDecoration.Parent = this.IV_Button_App_Info;
            this.IV_Button_App_Info.Size = new System.Drawing.Size(78, 20);
            this.IV_Button_App_Info.TabIndex = 3;
            this.IV_Button_App_Info.Text = "App Info";
            this.IV_AB_AppInfo_Info.SetToolTip(this.IV_Button_App_Info, "Click if you want to show App Information.");
            this.IV_Button_App_Info.Visible = false;
            this.IV_Button_App_Info.Click += new System.EventHandler(this.IV_B_AppInfo_Hook);
            // 
            // IV_T_Exit
            // 
            this.IV_T_Exit.Interval = 3000;
            this.IV_T_Exit.Tick += new System.EventHandler(this.IV_T_Exit_Scenario);
            // 
            // IV_AB_Exit_Info
            // 
            this.IV_AB_Exit_Info.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_AB_Exit_Info.ToolTipTitle = "IV About";
            // 
            // IV_AB_AppInfo_Info
            // 
            this.IV_AB_AppInfo_Info.IsBalloon = true;
            this.IV_AB_AppInfo_Info.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_AB_AppInfo_Info.ToolTipTitle = "IV About";
            // 
            // IV_THINK_AB_WINDOW_HOOK
            // 
            this.IV_THINK_AB_WINDOW_HOOK.Tick += new System.EventHandler(this.IV_Think_AB_WND_Hook);
            // 
            // IV_B_Debug_ChangeBGImage
            // 
            this.IV_B_Debug_ChangeBGImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_B_Debug_ChangeBGImage.Animated = true;
            this.IV_B_Debug_ChangeBGImage.BackColor = System.Drawing.Color.LemonChiffon;
            this.IV_B_Debug_ChangeBGImage.CheckedState.Parent = this.IV_B_Debug_ChangeBGImage;
            this.IV_B_Debug_ChangeBGImage.CustomImages.Parent = this.IV_B_Debug_ChangeBGImage;
            this.IV_B_Debug_ChangeBGImage.DisabledState.Parent = this.IV_B_Debug_ChangeBGImage;
            this.IV_B_Debug_ChangeBGImage.FillColor = System.Drawing.Color.Purple;
            this.IV_B_Debug_ChangeBGImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IV_B_Debug_ChangeBGImage.ForeColor = System.Drawing.Color.White;
            this.IV_B_Debug_ChangeBGImage.HoverState.Parent = this.IV_B_Debug_ChangeBGImage;
            this.IV_B_Debug_ChangeBGImage.Location = new System.Drawing.Point(708, 0);
            this.IV_B_Debug_ChangeBGImage.Name = "IV_B_Debug_ChangeBGImage";
            this.IV_B_Debug_ChangeBGImage.ShadowDecoration.Parent = this.IV_B_Debug_ChangeBGImage;
            this.IV_B_Debug_ChangeBGImage.Size = new System.Drawing.Size(92, 20);
            this.IV_B_Debug_ChangeBGImage.TabIndex = 4;
            this.IV_B_Debug_ChangeBGImage.Text = "ChangeBG";
            this.IV_AB_ChangeBG_Button.SetToolTip(this.IV_B_Debug_ChangeBGImage, "Press that button if you want to Chose new Default Background.");
            this.IV_B_Debug_ChangeBGImage.Visible = false;
            this.IV_B_Debug_ChangeBGImage.Click += new System.EventHandler(this.IV_B_BGCH_Click);
            // 
            // IV_DLG_BG_IMG_Finder
            // 
            this.IV_DLG_BG_IMG_Finder.InitialDirectory = ".\\";
            this.IV_DLG_BG_IMG_Finder.Title = "IV File Dialog Manager";
            this.IV_DLG_BG_IMG_Finder.FileOk += new System.ComponentModel.CancelEventHandler(this.IV_DLG_BG_Set_Result);
            // 
            // IV_AB_ChangeBG_Button
            // 
            this.IV_AB_ChangeBG_Button.IsBalloon = true;
            this.IV_AB_ChangeBG_Button.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_AB_ChangeBG_Button.ToolTipTitle = "IV About";
            // 
            // IV_B_Debug_Resset_BG_IMG_TO_Def
            // 
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Animated = true;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.BackColor = System.Drawing.Color.Red;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.CheckedState.Parent = this.IV_B_Debug_Resset_BG_IMG_TO_Def;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.CustomImages.Parent = this.IV_B_Debug_Resset_BG_IMG_TO_Def;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.DisabledState.Parent = this.IV_B_Debug_Resset_BG_IMG_TO_Def;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.FillColor = System.Drawing.Color.Red;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.ForeColor = System.Drawing.Color.White;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.HoverState.Parent = this.IV_B_Debug_Resset_BG_IMG_TO_Def;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Location = new System.Drawing.Point(708, 26);
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Name = "IV_B_Debug_Resset_BG_IMG_TO_Def";
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.ShadowDecoration.Parent = this.IV_B_Debug_Resset_BG_IMG_TO_Def;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Size = new System.Drawing.Size(92, 20);
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.TabIndex = 5;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Text = "Resset BG";
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Visible = false;
            this.IV_B_Debug_Resset_BG_IMG_TO_Def.Click += new System.EventHandler(this.IV_B_BG_Reset_Hook);
            // 
            // IV_M_M_Animated_Load
            // 
            this.IV_M_M_Animated_Load.Interval = 450;
            this.IV_M_M_Animated_Load.TargetForm = this;
            // 
            // IV_T_Load_Check
            // 
            this.IV_T_Load_Check.Interval = 1000;
            this.IV_T_Load_Check.Tick += new System.EventHandler(this.IV_T_Loaded_Show_Form_B_Hook);
            // 
            // IV_B_Gallery_Settings
            // 
            this.IV_B_Gallery_Settings.Animated = true;
            this.IV_B_Gallery_Settings.CheckedState.Parent = this.IV_B_Gallery_Settings;
            this.IV_B_Gallery_Settings.CustomImages.Parent = this.IV_B_Gallery_Settings;
            this.IV_B_Gallery_Settings.DisabledState.Parent = this.IV_B_Gallery_Settings;
            this.IV_B_Gallery_Settings.FillColor = System.Drawing.Color.LightSteelBlue;
            this.IV_B_Gallery_Settings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IV_B_Gallery_Settings.ForeColor = System.Drawing.Color.Black;
            this.IV_B_Gallery_Settings.HoverState.Parent = this.IV_B_Gallery_Settings;
            this.IV_B_Gallery_Settings.Location = new System.Drawing.Point(106, 0);
            this.IV_B_Gallery_Settings.Name = "IV_B_Gallery_Settings";
            this.IV_B_Gallery_Settings.ShadowDecoration.Parent = this.IV_B_Gallery_Settings;
            this.IV_B_Gallery_Settings.Size = new System.Drawing.Size(108, 20);
            this.IV_B_Gallery_Settings.TabIndex = 6;
            this.IV_B_Gallery_Settings.Text = "Gallery Settings";
            this.IV_B_Gallery_Settings.Visible = false;
            this.IV_B_Gallery_Settings.Click += new System.EventHandler(this.IV_B_Gallery_S_Menu_Hook);
            this.IV_B_Gallery_Settings.DoubleClick += new System.EventHandler(this.IV_Debug_D_Click_Element_Move);
            // 
            // IV_Gallery_Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.IV_B_Gallery_Settings);
            this.Controls.Add(this.IV_B_Debug_Resset_BG_IMG_TO_Def);
            this.Controls.Add(this.IV_B_Debug_ChangeBGImage);
            this.Controls.Add(this.IV_Button_App_Info);
            this.Controls.Add(this.IV_MM_Load_Status_Bar);
            this.Controls.Add(this.IV_G_Button_Exit);
            this.Controls.Add(this.IV_Gallery_MM_BG_Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IV_Gallery_Main_Menu";
            this.Text = "IV Gallery";
            this.Load += new System.EventHandler(this.IV_MM_Load_Hook);
            ((System.ComponentModel.ISupportInitialize)(this.IV_Gallery_MM_BG_Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer IV_Time_WAIT_UN_Load;
        private System.Windows.Forms.Timer IV_Time_Pre_Finish_Load;
        private System.Windows.Forms.Timer IV_T_Exit;
        private System.Windows.Forms.ToolTip IV_AB_Exit_Info;
        private System.Windows.Forms.ToolTip IV_AB_AppInfo_Info;
        private System.Windows.Forms.Timer IV_THINK_AB_WINDOW_HOOK;
        private Siticone.Desktop.UI.WinForms.SiticoneButton IV_B_Debug_ChangeBGImage;
        private System.Windows.Forms.OpenFileDialog IV_DLG_BG_IMG_Finder;
        private System.Windows.Forms.ToolTip IV_AB_ChangeBG_Button;
        private Siticone.Desktop.UI.WinForms.SiticoneButton IV_B_Debug_Resset_BG_IMG_TO_Def;
        private Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow IV_M_M_Animated_Load;
        private System.Windows.Forms.ProgressBar IV_MM_Load_Status_Bar;
        private Siticone.Desktop.UI.WinForms.SiticoneButton IV_Button_App_Info;
        private Siticone.Desktop.UI.WinForms.SiticoneButton IV_G_Button_Exit;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox IV_Gallery_MM_BG_Picture;
        private System.Windows.Forms.Timer IV_T_Load_Check;
        private Siticone.Desktop.UI.WinForms.SiticoneButton IV_B_Gallery_Settings;
    }
}

