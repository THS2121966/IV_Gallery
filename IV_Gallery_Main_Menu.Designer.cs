
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_Gallery_Main_Menu));
            this.IV_Gallery_MM_BG_Picture = new System.Windows.Forms.PictureBox();
            this.IV_G_Button_Exit = new System.Windows.Forms.Button();
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
            this.IV_G_Button_Exit.UseVisualStyleBackColor = false;
            this.IV_G_Button_Exit.Click += new System.EventHandler(this.IV_Exit_Click_Scenario);
            // 
            // IV_Gallery_Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.IV_G_Button_Exit);
            this.Controls.Add(this.IV_Gallery_MM_BG_Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IV_Gallery_Main_Menu";
            this.Text = "IV Gallery";
            ((System.ComponentModel.ISupportInitialize)(this.IV_Gallery_MM_BG_Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        static public IV_Gallery_Main_Menu iv_g_m_m = new IV_Gallery_Main_Menu();

        public System.Windows.Forms.PictureBox IV_Gallery_MM_BG_Picture;
        public System.Windows.Forms.Button IV_G_Button_Exit;
    }
}

