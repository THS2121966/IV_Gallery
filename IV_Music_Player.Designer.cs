
namespace IV_Gallery
{
    partial class IV_Music_Player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_Music_Player));
            this.IV_M_Player_BG_Panel = new System.Windows.Forms.PictureBox();
            this.IV_B_Chose_Sound = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IV_M_Player_BG_Panel)).BeginInit();
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
            // IV_B_Chose_Sound
            // 
            this.IV_B_Chose_Sound.BackColor = System.Drawing.Color.PaleTurquoise;
            this.IV_B_Chose_Sound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IV_B_Chose_Sound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IV_B_Chose_Sound.Location = new System.Drawing.Point(0, 0);
            this.IV_B_Chose_Sound.Name = "IV_B_Chose_Sound";
            this.IV_B_Chose_Sound.Size = new System.Drawing.Size(100, 20);
            this.IV_B_Chose_Sound.TabIndex = 1;
            this.IV_B_Chose_Sound.Text = "Chose Sound";
            this.IV_B_Chose_Sound.UseVisualStyleBackColor = false;
            this.IV_B_Chose_Sound.Click += new System.EventHandler(this.IV_Button_SChange_Press_Hook);
            // 
            // IV_Music_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(564, 146);
            this.Controls.Add(this.IV_B_Chose_Sound);
            this.Controls.Add(this.IV_M_Player_BG_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IV_Music_Player";
            this.Text = "IV Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.IV_M_Player_BG_Panel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox IV_M_Player_BG_Panel;
        private System.Windows.Forms.Button IV_B_Chose_Sound;
    }
}