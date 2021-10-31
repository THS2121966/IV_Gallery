
namespace IV_Gallery
{
    partial class IV_Media_Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_Media_Player));
            this.IV_B_Chose_Media = new System.Windows.Forms.Button();
            this.IV_MP_Main = new LibVLCSharp.WinForms.VideoView();
            this.IV_MP_File_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.IV_MP_Volume_Bar = new System.Windows.Forms.TrackBar();
            this.IV_MP_B_Stop = new System.Windows.Forms.Button();
            this.IV_MP_B_Restart_Media = new System.Windows.Forms.Button();
            this.IV_MP_B_Play = new System.Windows.Forms.Button();
            this.IV_CB_Toggle_Slider_Func = new System.Windows.Forms.CheckBox();
            this.IV_About_VLC_Player = new System.Windows.Forms.ToolTip(this.components);
            this.IV_About_Play = new System.Windows.Forms.ToolTip(this.components);
            this.IV_About_Stop = new System.Windows.Forms.ToolTip(this.components);
            this.IV_About_Restart = new System.Windows.Forms.ToolTip(this.components);
            this.IV_About_Volume = new System.Windows.Forms.ToolTip(this.components);
            this.IV_MP_T_Video_End_Check = new System.Windows.Forms.Timer(this.components);
            this.IV_MP_CB_Ulr_Method = new System.Windows.Forms.CheckBox();
            this.IV_M_Player_BG_Panel = new System.Windows.Forms.PictureBox();
            this.IV_MP_T_Check_URL_State = new System.Windows.Forms.Timer(this.components);
            this.IV_MP_T_Change_Time_Interval = new System.Windows.Forms.Timer(this.components);
            this.IV_MP_T_Video_Time_Show = new System.Windows.Forms.Timer(this.components);
            this.IV_MP_Sound_Wave_Panel = new LibVLCSharp.WinForms.VideoView();
            this.IV_T_Video_Wave_Check_Stopped = new System.Windows.Forms.Timer(this.components);
            this.IV_MP_Anim_State = new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Volume_Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_M_Player_BG_Panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Sound_Wave_Panel)).BeginInit();
            this.SuspendLayout();
            // 
            // IV_B_Chose_Media
            // 
            this.IV_B_Chose_Media.BackColor = System.Drawing.Color.PaleTurquoise;
            this.IV_B_Chose_Media.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IV_B_Chose_Media.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IV_B_Chose_Media.Location = new System.Drawing.Point(0, 0);
            this.IV_B_Chose_Media.Name = "IV_B_Chose_Media";
            this.IV_B_Chose_Media.Size = new System.Drawing.Size(100, 20);
            this.IV_B_Chose_Media.TabIndex = 1;
            this.IV_B_Chose_Media.Text = "Chose Media";
            this.IV_B_Chose_Media.UseVisualStyleBackColor = false;
            this.IV_B_Chose_Media.Click += new System.EventHandler(this.IV_Button_SChange_Press_Hook);
            // 
            // IV_MP_Main
            // 
            this.IV_MP_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_MP_Main.BackColor = System.Drawing.Color.DimGray;
            this.IV_MP_Main.Location = new System.Drawing.Point(106, 12);
            this.IV_MP_Main.MediaPlayer = null;
            this.IV_MP_Main.Name = "IV_MP_Main";
            this.IV_MP_Main.Size = new System.Drawing.Size(446, 122);
            this.IV_MP_Main.TabIndex = 2;
            this.IV_MP_Main.Text = "IV Media Player";
            this.IV_About_VLC_Player.SetToolTip(this.IV_MP_Main, "This Panel translate Selected Videos.");
            // 
            // IV_MP_File_Dialog
            // 
            this.IV_MP_File_Dialog.Title = "IV Media Player DLG";
            this.IV_MP_File_Dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.IV_MP_DLG_Result);
            // 
            // IV_MP_Volume_Bar
            // 
            this.IV_MP_Volume_Bar.BackColor = System.Drawing.Color.Indigo;
            this.IV_MP_Volume_Bar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IV_MP_Volume_Bar.LargeChange = 20;
            this.IV_MP_Volume_Bar.Location = new System.Drawing.Point(12, 26);
            this.IV_MP_Volume_Bar.Maximum = 100;
            this.IV_MP_Volume_Bar.Name = "IV_MP_Volume_Bar";
            this.IV_MP_Volume_Bar.Size = new System.Drawing.Size(85, 45);
            this.IV_MP_Volume_Bar.SmallChange = 10;
            this.IV_MP_Volume_Bar.TabIndex = 4;
            this.IV_MP_Volume_Bar.TickFrequency = 10;
            this.IV_About_Volume.SetToolTip(this.IV_MP_Volume_Bar, "Video Volume controlling Slider.");
            this.IV_MP_Volume_Bar.Scroll += new System.EventHandler(this.IV_MP_Volume_Scroll_Hook);
            // 
            // IV_MP_B_Stop
            // 
            this.IV_MP_B_Stop.BackColor = System.Drawing.Color.Red;
            this.IV_MP_B_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IV_MP_B_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_MP_B_Stop.Location = new System.Drawing.Point(106, 12);
            this.IV_MP_B_Stop.Name = "IV_MP_B_Stop";
            this.IV_MP_B_Stop.Size = new System.Drawing.Size(37, 24);
            this.IV_MP_B_Stop.TabIndex = 5;
            this.IV_MP_B_Stop.Text = "Stop";
            this.IV_About_Stop.SetToolTip(this.IV_MP_B_Stop, "Stop Video Button.");
            this.IV_MP_B_Stop.UseVisualStyleBackColor = false;
            this.IV_MP_B_Stop.Visible = false;
            this.IV_MP_B_Stop.Click += new System.EventHandler(this.IV_MP_B_Stop_Click_Hook);
            // 
            // IV_MP_B_Restart_Media
            // 
            this.IV_MP_B_Restart_Media.BackColor = System.Drawing.Color.Yellow;
            this.IV_MP_B_Restart_Media.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IV_MP_B_Restart_Media.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_MP_B_Restart_Media.Location = new System.Drawing.Point(12, 77);
            this.IV_MP_B_Restart_Media.Name = "IV_MP_B_Restart_Media";
            this.IV_MP_B_Restart_Media.Size = new System.Drawing.Size(53, 24);
            this.IV_MP_B_Restart_Media.TabIndex = 6;
            this.IV_MP_B_Restart_Media.Text = "Restart";
            this.IV_About_Restart.SetToolTip(this.IV_MP_B_Restart_Media, "Restart Video Button.");
            this.IV_MP_B_Restart_Media.UseVisualStyleBackColor = false;
            this.IV_MP_B_Restart_Media.Visible = false;
            this.IV_MP_B_Restart_Media.Click += new System.EventHandler(this.IV_MP_B_Restart_Click_Hook);
            // 
            // IV_MP_B_Play
            // 
            this.IV_MP_B_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IV_MP_B_Play.BackColor = System.Drawing.Color.Orange;
            this.IV_MP_B_Play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IV_MP_B_Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_MP_B_Play.Location = new System.Drawing.Point(106, 110);
            this.IV_MP_B_Play.Name = "IV_MP_B_Play";
            this.IV_MP_B_Play.Size = new System.Drawing.Size(63, 24);
            this.IV_MP_B_Play.TabIndex = 7;
            this.IV_MP_B_Play.Text = "Play/Pause";
            this.IV_About_Play.SetToolTip(this.IV_MP_B_Play, "Play/Pause Video Button.");
            this.IV_MP_B_Play.UseVisualStyleBackColor = false;
            this.IV_MP_B_Play.Visible = false;
            this.IV_MP_B_Play.Click += new System.EventHandler(this.IV_MP_B_PlayStop_Hook);
            // 
            // IV_CB_Toggle_Slider_Func
            // 
            this.IV_CB_Toggle_Slider_Func.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IV_CB_Toggle_Slider_Func.Location = new System.Drawing.Point(78, 77);
            this.IV_CB_Toggle_Slider_Func.Name = "IV_CB_Toggle_Slider_Func";
            this.IV_CB_Toggle_Slider_Func.Size = new System.Drawing.Size(22, 24);
            this.IV_CB_Toggle_Slider_Func.TabIndex = 8;
            this.IV_CB_Toggle_Slider_Func.Text = "Toggle Slider";
            this.IV_CB_Toggle_Slider_Func.UseVisualStyleBackColor = true;
            this.IV_CB_Toggle_Slider_Func.CheckedChanged += new System.EventHandler(this.IV_CB_Register_Hook);
            // 
            // IV_About_VLC_Player
            // 
            this.IV_About_VLC_Player.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_About_VLC_Player.ToolTipTitle = "IV About";
            // 
            // IV_About_Play
            // 
            this.IV_About_Play.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_About_Play.ToolTipTitle = "IV About";
            // 
            // IV_About_Stop
            // 
            this.IV_About_Stop.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_About_Stop.ToolTipTitle = "IV About";
            // 
            // IV_About_Restart
            // 
            this.IV_About_Restart.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_About_Restart.ToolTipTitle = "IV About";
            // 
            // IV_About_Volume
            // 
            this.IV_About_Volume.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_About_Volume.ToolTipTitle = "IV About";
            // 
            // IV_MP_T_Video_End_Check
            // 
            this.IV_MP_T_Video_End_Check.Interval = 1000;
            this.IV_MP_T_Video_End_Check.Tick += new System.EventHandler(this.IV_T_Video_End_Check_Think);
            // 
            // IV_MP_CB_Ulr_Method
            // 
            this.IV_MP_CB_Ulr_Method.AutoSize = true;
            this.IV_MP_CB_Ulr_Method.BackColor = System.Drawing.Color.Silver;
            this.IV_MP_CB_Ulr_Method.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IV_MP_CB_Ulr_Method.Location = new System.Drawing.Point(12, 107);
            this.IV_MP_CB_Ulr_Method.Name = "IV_MP_CB_Ulr_Method";
            this.IV_MP_CB_Ulr_Method.Size = new System.Drawing.Size(73, 17);
            this.IV_MP_CB_Ulr_Method.TabIndex = 9;
            this.IV_MP_CB_Ulr_Method.Text = "Url Search";
            this.IV_MP_CB_Ulr_Method.UseVisualStyleBackColor = false;
            this.IV_MP_CB_Ulr_Method.CheckedChanged += new System.EventHandler(this.IV_MP_CB_URL_Checked);
            // 
            // IV_M_Player_BG_Panel
            // 
            this.IV_M_Player_BG_Panel.BackColor = System.Drawing.Color.Silver;
            this.IV_M_Player_BG_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IV_M_Player_BG_Panel.ErrorImage = global::IV_Gallery.Properties.Resources.ths_hammer_icon;
            this.IV_M_Player_BG_Panel.Image = global::IV_Gallery.Properties.Resources.ths_z_nationF;
            this.IV_M_Player_BG_Panel.InitialImage = global::IV_Gallery.Properties.Resources.ths_icon;
            this.IV_M_Player_BG_Panel.Location = new System.Drawing.Point(0, 0);
            this.IV_M_Player_BG_Panel.Name = "IV_M_Player_BG_Panel";
            this.IV_M_Player_BG_Panel.Size = new System.Drawing.Size(564, 146);
            this.IV_M_Player_BG_Panel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IV_M_Player_BG_Panel.TabIndex = 0;
            this.IV_M_Player_BG_Panel.TabStop = false;
            this.IV_M_Player_BG_Panel.Click += new System.EventHandler(this.IV_MP_Main_Click_Hook);
            // 
            // IV_MP_T_Check_URL_State
            // 
            this.IV_MP_T_Check_URL_State.Tick += new System.EventHandler(this.IV_MP_URL_State_Think);
            // 
            // IV_MP_T_Change_Time_Interval
            // 
            this.IV_MP_T_Change_Time_Interval.Interval = 2000;
            this.IV_MP_T_Change_Time_Interval.Tick += new System.EventHandler(this.IV_MP_T_Video_T_Change_Interval);
            // 
            // IV_MP_T_Video_Time_Show
            // 
            this.IV_MP_T_Video_Time_Show.Interval = 300;
            this.IV_MP_T_Video_Time_Show.Tick += new System.EventHandler(this.IV_MP_Time_Control_Think);
            // 
            // IV_MP_Sound_Wave_Panel
            // 
            this.IV_MP_Sound_Wave_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_MP_Sound_Wave_Panel.BackColor = System.Drawing.Color.Black;
            this.IV_MP_Sound_Wave_Panel.Location = new System.Drawing.Point(106, 42);
            this.IV_MP_Sound_Wave_Panel.MediaPlayer = null;
            this.IV_MP_Sound_Wave_Panel.Name = "IV_MP_Sound_Wave_Panel";
            this.IV_MP_Sound_Wave_Panel.Size = new System.Drawing.Size(446, 62);
            this.IV_MP_Sound_Wave_Panel.TabIndex = 10;
            this.IV_MP_Sound_Wave_Panel.Text = "IV Sound Wave Panel";
            this.IV_MP_Sound_Wave_Panel.Visible = false;
            // 
            // IV_T_Video_Wave_Check_Stopped
            // 
            this.IV_T_Video_Wave_Check_Stopped.Interval = 500;
            this.IV_T_Video_Wave_Check_Stopped.Tick += new System.EventHandler(this.IV_MP_Wave_Stopped_Think);
            // 
            // IV_MP_Anim_State
            // 
            this.IV_MP_Anim_State.AnimationType = Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow.AnimateWindowType.AW_HOR_POSITIVE;
            this.IV_MP_Anim_State.Interval = 450;
            this.IV_MP_Anim_State.TargetForm = this;
            // 
            // IV_Media_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(564, 146);
            this.Controls.Add(this.IV_MP_Sound_Wave_Panel);
            this.Controls.Add(this.IV_MP_CB_Ulr_Method);
            this.Controls.Add(this.IV_CB_Toggle_Slider_Func);
            this.Controls.Add(this.IV_MP_B_Play);
            this.Controls.Add(this.IV_MP_B_Restart_Media);
            this.Controls.Add(this.IV_MP_B_Stop);
            this.Controls.Add(this.IV_MP_Volume_Bar);
            this.Controls.Add(this.IV_MP_Main);
            this.Controls.Add(this.IV_B_Chose_Media);
            this.Controls.Add(this.IV_M_Player_BG_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IV_Media_Player";
            this.Text = "IV Media Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IV_Music_Player_Close_Hook);
            this.Load += new System.EventHandler(this.IV_MP_Load_Hook);
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Volume_Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_M_Player_BG_Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Sound_Wave_Panel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IV_M_Player_BG_Panel;
        private System.Windows.Forms.Button IV_B_Chose_Media;
        private LibVLCSharp.WinForms.VideoView IV_MP_Main;
        private System.Windows.Forms.OpenFileDialog IV_MP_File_Dialog;
        private System.Windows.Forms.TrackBar IV_MP_Volume_Bar;
        private System.Windows.Forms.Button IV_MP_B_Stop;
        private System.Windows.Forms.Button IV_MP_B_Restart_Media;
        private System.Windows.Forms.Button IV_MP_B_Play;
        private System.Windows.Forms.CheckBox IV_CB_Toggle_Slider_Func;
        private System.Windows.Forms.ToolTip IV_About_VLC_Player;
        private System.Windows.Forms.ToolTip IV_About_Play;
        private System.Windows.Forms.ToolTip IV_About_Stop;
        private System.Windows.Forms.ToolTip IV_About_Restart;
        private System.Windows.Forms.ToolTip IV_About_Volume;
        private System.Windows.Forms.Timer IV_MP_T_Video_End_Check;
        private System.Windows.Forms.CheckBox IV_MP_CB_Ulr_Method;
        private System.Windows.Forms.Timer IV_MP_T_Check_URL_State;
        private System.Windows.Forms.Timer IV_MP_T_Change_Time_Interval;
        private System.Windows.Forms.Timer IV_MP_T_Video_Time_Show;
        private LibVLCSharp.WinForms.VideoView IV_MP_Sound_Wave_Panel;
        private System.Windows.Forms.Timer IV_T_Video_Wave_Check_Stopped;
        private Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow IV_MP_Anim_State;
    }
}