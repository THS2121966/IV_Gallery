
namespace IV_Gallery
{
    partial class IV_MP_Tool_Chose_Internet_Video
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_MP_Tool_Chose_Internet_Video));
            this.IV_IMF_Label_Main = new System.Windows.Forms.Label();
            this.IV_IMF_Link_Chose_Panel = new System.Windows.Forms.TextBox();
            this.IV_IMF_WebBrowser_Test_URL = new System.Windows.Forms.WebBrowser();
            this.IV_IMF_B_Search_URL = new System.Windows.Forms.Button();
            this.IV_IMF_T_Test_Site = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // IV_IMF_Label_Main
            // 
            this.IV_IMF_Label_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_IMF_Label_Main.BackColor = System.Drawing.SystemColors.Menu;
            this.IV_IMF_Label_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IV_IMF_Label_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_IMF_Label_Main.Location = new System.Drawing.Point(12, 9);
            this.IV_IMF_Label_Main.Name = "IV_IMF_Label_Main";
            this.IV_IMF_Label_Main.Size = new System.Drawing.Size(776, 32);
            this.IV_IMF_Label_Main.TabIndex = 0;
            this.IV_IMF_Label_Main.Text = "IV Internet Media Founder";
            this.IV_IMF_Label_Main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IV_IMF_Link_Chose_Panel
            // 
            this.IV_IMF_Link_Chose_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_IMF_Link_Chose_Panel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.IV_IMF_Link_Chose_Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_IMF_Link_Chose_Panel.Location = new System.Drawing.Point(173, 44);
            this.IV_IMF_Link_Chose_Panel.Multiline = true;
            this.IV_IMF_Link_Chose_Panel.Name = "IV_IMF_Link_Chose_Panel";
            this.IV_IMF_Link_Chose_Panel.Size = new System.Drawing.Size(458, 28);
            this.IV_IMF_Link_Chose_Panel.TabIndex = 1;
            this.IV_IMF_Link_Chose_Panel.Text = "Enter your inernet media link here...";
            this.IV_IMF_Link_Chose_Panel.TextChanged += new System.EventHandler(this.IV_IMF_Link_Panel_Text_Changed);
            // 
            // IV_IMF_WebBrowser_Test_URL
            // 
            this.IV_IMF_WebBrowser_Test_URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_IMF_WebBrowser_Test_URL.Location = new System.Drawing.Point(0, 145);
            this.IV_IMF_WebBrowser_Test_URL.MinimumSize = new System.Drawing.Size(20, 20);
            this.IV_IMF_WebBrowser_Test_URL.Name = "IV_IMF_WebBrowser_Test_URL";
            this.IV_IMF_WebBrowser_Test_URL.Size = new System.Drawing.Size(802, 306);
            this.IV_IMF_WebBrowser_Test_URL.TabIndex = 2;
            this.IV_IMF_WebBrowser_Test_URL.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.IV_IMF_Web_Loaded);
            // 
            // IV_IMF_B_Search_URL
            // 
            this.IV_IMF_B_Search_URL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IV_IMF_B_Search_URL.BackColor = System.Drawing.SystemColors.ControlLight;
            this.IV_IMF_B_Search_URL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IV_IMF_B_Search_URL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IV_IMF_B_Search_URL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_IMF_B_Search_URL.Location = new System.Drawing.Point(637, 47);
            this.IV_IMF_B_Search_URL.Name = "IV_IMF_B_Search_URL";
            this.IV_IMF_B_Search_URL.Size = new System.Drawing.Size(75, 25);
            this.IV_IMF_B_Search_URL.TabIndex = 3;
            this.IV_IMF_B_Search_URL.Text = "Search";
            this.IV_IMF_B_Search_URL.UseVisualStyleBackColor = false;
            this.IV_IMF_B_Search_URL.Visible = false;
            this.IV_IMF_B_Search_URL.Click += new System.EventHandler(this.IV_IMF_B_Search_Click);
            // 
            // IV_IMF_T_Test_Site
            // 
            this.IV_IMF_T_Test_Site.Interval = 1000;
            this.IV_IMF_T_Test_Site.Tick += new System.EventHandler(this.IV_IMF_T_Test_Site_load_State_Think);
            // 
            // IV_MP_Tool_Chose_Internet_Video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IV_IMF_B_Search_URL);
            this.Controls.Add(this.IV_IMF_WebBrowser_Test_URL);
            this.Controls.Add(this.IV_IMF_Link_Chose_Panel);
            this.Controls.Add(this.IV_IMF_Label_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IV_MP_Tool_Chose_Internet_Video";
            this.Text = "IV Media Link Checker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IV_IMF_Force_Closed);
            this.Load += new System.EventHandler(this.IV_IMF_Loaded);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IV_IMF_Label_Main;
        private System.Windows.Forms.TextBox IV_IMF_Link_Chose_Panel;
        private System.Windows.Forms.WebBrowser IV_IMF_WebBrowser_Test_URL;
        private System.Windows.Forms.Button IV_IMF_B_Search_URL;
        private System.Windows.Forms.Timer IV_IMF_T_Test_Site;
    }
}