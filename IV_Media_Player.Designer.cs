
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_Media_Player));
            this.IV_M_Player_BG_Panel = new System.Windows.Forms.PictureBox();
            this.IV_B_Chose_Media = new System.Windows.Forms.Button();
            this.IV_MP_Main = new LibVLCSharp.WinForms.VideoView();
            this.IV_MP_File_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.IV_MP_B_PlayStop = new System.Windows.Forms.Button();
            this.IV_MP_Volume_Bar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.IV_M_Player_BG_Panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Volume_Bar)).BeginInit();
            this.SuspendLayout();
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
            // 
            // IV_MP_File_Dialog
            // 
            this.IV_MP_File_Dialog.Title = "IV Media Player DLG";
            this.IV_MP_File_Dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.IV_MP_DLG_Result);
            // 
            // IV_MP_B_PlayStop
            // 
            this.IV_MP_B_PlayStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IV_MP_B_PlayStop.BackColor = System.Drawing.Color.Orange;
            this.IV_MP_B_PlayStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IV_MP_B_PlayStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_MP_B_PlayStop.Location = new System.Drawing.Point(106, 110);
            this.IV_MP_B_PlayStop.Name = "IV_MP_B_PlayStop";
            this.IV_MP_B_PlayStop.Size = new System.Drawing.Size(55, 24);
            this.IV_MP_B_PlayStop.TabIndex = 3;
            this.IV_MP_B_PlayStop.Text = "Play/Stop";
            this.IV_MP_B_PlayStop.UseVisualStyleBackColor = false;
            this.IV_MP_B_PlayStop.Click += new System.EventHandler(this.IV_MP_B_PlayStop_Hook);
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
            this.IV_MP_Volume_Bar.Scroll += new System.EventHandler(this.IV_MP_Volume_Scroll_Hook);
            // 
            // IV_Media_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(564, 146);
            this.Controls.Add(this.IV_MP_Volume_Bar);
            this.Controls.Add(this.IV_MP_B_PlayStop);
            this.Controls.Add(this.IV_MP_Main);
            this.Controls.Add(this.IV_B_Chose_Media);
            this.Controls.Add(this.IV_M_Player_BG_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IV_Media_Player";
            this.Text = "IV Media Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IV_Music_Player_Close_Hook);
            this.Load += new System.EventHandler(this.IV_MP_Load_Hook);
            ((System.ComponentModel.ISupportInitialize)(this.IV_M_Player_BG_Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MP_Volume_Bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IV_M_Player_BG_Panel;
        private System.Windows.Forms.Button IV_B_Chose_Media;
        private LibVLCSharp.WinForms.VideoView IV_MP_Main;
        private System.Windows.Forms.OpenFileDialog IV_MP_File_Dialog;
        private System.Windows.Forms.Button IV_MP_B_PlayStop;
        private System.Windows.Forms.TrackBar IV_MP_Volume_Bar;
    }
}