
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
            this.IV_Gallery_MM_BG_Picture = new System.Windows.Forms.PictureBox();
            this.IV_G_Button_Exit = new System.Windows.Forms.Button();
            this.IV_MM_Load_Status_Bar = new System.Windows.Forms.ProgressBar();
            this.IV_Time_WAIT_UN_Load = new System.Windows.Forms.Timer(this.components);
            this.IV_Time_Pre_Finish_Load = new System.Windows.Forms.Timer(this.components);
            this.IV_Button_App_Info = new System.Windows.Forms.Button();
            this.IV_T_Exit = new System.Windows.Forms.Timer(this.components);
            this.IV_AB_Exit_Info = new System.Windows.Forms.ToolTip(this.components);
            this.IV_AB_AppInfo_Info = new System.Windows.Forms.ToolTip(this.components);
            this.IV_THINK_AB_WINDOW_HOOK = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IV_Gallery_MM_BG_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // IV_Gallery_MM_BG_Picture
            // 
            this.IV_Gallery_MM_BG_Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IV_Gallery_MM_BG_Picture.ErrorImage = global::IV_Gallery.Properties.Resources.ths_hammer_icon;
            this.IV_Gallery_MM_BG_Picture.Image = global::IV_Gallery.Properties.Resources.THSSourcelogoF_source_loading;
            this.IV_Gallery_MM_BG_Picture.InitialImage = global::IV_Gallery.Properties.Resources.ths_icon;
            this.IV_Gallery_MM_BG_Picture.Location = new System.Drawing.Point(0, 0);
            this.IV_Gallery_MM_BG_Picture.Name = "IV_Gallery_MM_BG_Picture";
            this.IV_Gallery_MM_BG_Picture.Size = new System.Drawing.Size(800, 577);
            this.IV_Gallery_MM_BG_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IV_Gallery_MM_BG_Picture.TabIndex = 0;
            this.IV_Gallery_MM_BG_Picture.TabStop = false;
            this.IV_Gallery_MM_BG_Picture.DoubleClick += new System.EventHandler(this.IV_MM_BG_D_Click);
            // 
            // IV_G_Button_Exit
            // 
            this.IV_G_Button_Exit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.IV_G_Button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IV_G_Button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_G_Button_Exit.Location = new System.Drawing.Point(708, 535);
            this.IV_G_Button_Exit.Name = "IV_G_Button_Exit";
            this.IV_G_Button_Exit.Size = new System.Drawing.Size(80, 30);
            this.IV_G_Button_Exit.TabIndex = 1;
            this.IV_G_Button_Exit.Text = "Exit";
            this.IV_AB_Exit_Info.SetToolTip(this.IV_G_Button_Exit, "Click to that Button if you want to Exit.");
            this.IV_G_Button_Exit.UseVisualStyleBackColor = false;
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
            this.IV_Button_App_Info.Location = new System.Drawing.Point(0, 557);
            this.IV_Button_App_Info.Name = "IV_Button_App_Info";
            this.IV_Button_App_Info.Size = new System.Drawing.Size(60, 20);
            this.IV_Button_App_Info.TabIndex = 3;
            this.IV_Button_App_Info.Text = "App Info";
            this.IV_AB_AppInfo_Info.SetToolTip(this.IV_Button_App_Info, "Click if you want to show App Information.");
            this.IV_Button_App_Info.UseVisualStyleBackColor = true;
            this.IV_Button_App_Info.Visible = false;
            this.IV_Button_App_Info.Click += new System.EventHandler(this.IV_B_AppInfo_Hook);
            // 
            // IV_T_Exit
            // 
            this.IV_T_Exit.Interval = 1000;
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
            // IV_Gallery_Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.IV_Button_App_Info);
            this.Controls.Add(this.IV_MM_Load_Status_Bar);
            this.Controls.Add(this.IV_G_Button_Exit);
            this.Controls.Add(this.IV_Gallery_MM_BG_Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IV_Gallery_Main_Menu";
            this.Text = "IV Gallery";
            this.Load += new System.EventHandler(this.IV_MM_Load_Hook);
            ((System.ComponentModel.ISupportInitialize)(this.IV_Gallery_MM_BG_Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        static public IV_Gallery_Main_Menu iv_g_m_m = new IV_Gallery_Main_Menu();

        public System.Windows.Forms.PictureBox IV_Gallery_MM_BG_Picture;
        public System.Windows.Forms.Button IV_G_Button_Exit;
        public System.Windows.Forms.ProgressBar IV_MM_Load_Status_Bar;
        private System.Windows.Forms.Timer IV_Time_WAIT_UN_Load;
        private System.Windows.Forms.Timer IV_Time_Pre_Finish_Load;
        public System.Windows.Forms.Button IV_Button_App_Info;
        private System.Windows.Forms.Timer IV_T_Exit;
        private System.Windows.Forms.ToolTip IV_AB_Exit_Info;
        private System.Windows.Forms.ToolTip IV_AB_AppInfo_Info;
        private System.Windows.Forms.Timer IV_THINK_AB_WINDOW_HOOK;
    }
}

