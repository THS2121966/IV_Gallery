
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
            // 
            // IV_Gallery_Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
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

        public System.Windows.Forms.PictureBox IV_Gallery_MM_BG_Picture;
    }
}

