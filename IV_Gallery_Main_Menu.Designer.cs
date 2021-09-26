
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
            this.IV_MM_BackGround_IMG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IV_MM_BackGround_IMG)).BeginInit();
            this.SuspendLayout();
            // 
            // IV_MM_BackGround_IMG
            // 
            this.IV_MM_BackGround_IMG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IV_MM_BackGround_IMG.ErrorImage = global::IV_Gallery.Properties.Resources.ths_icon;
            this.IV_MM_BackGround_IMG.Image = global::IV_Gallery.Properties.Resources.THSSourcelogoF_source_loading;
            this.IV_MM_BackGround_IMG.InitialImage = global::IV_Gallery.Properties.Resources.BetaTHSF;
            this.IV_MM_BackGround_IMG.Location = new System.Drawing.Point(0, 0);
            this.IV_MM_BackGround_IMG.Name = "IV_MM_BackGround_IMG";
            this.IV_MM_BackGround_IMG.Size = new System.Drawing.Size(800, 577);
            this.IV_MM_BackGround_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IV_MM_BackGround_IMG.TabIndex = 0;
            this.IV_MM_BackGround_IMG.TabStop = false;
            // 
            // IV_Gallery_Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.IV_MM_BackGround_IMG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IV_Gallery_Main_Menu";
            this.Text = "IV Gallery";
            ((System.ComponentModel.ISupportInitialize)(this.IV_MM_BackGround_IMG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox IV_MM_BackGround_IMG;
    }
}

