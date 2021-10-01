
namespace IV_Gallery_Checkers_Core
{
    partial class IV_Checker_Core_AppInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_Checker_Core_AppInfo));
            this.IV_C_C_About_Page = new System.Windows.Forms.TextBox();
            this.IV_B_Exit = new System.Windows.Forms.Button();
            this.IV_AB_Exit_Tool = new System.Windows.Forms.ToolTip(this.components);
            this.IV_B_Reload_Programm = new System.Windows.Forms.Button();
            this.IV_AB_Reload_Programm = new System.Windows.Forms.ToolTip(this.components);
            this.IV_T_CountDown_To_Restart = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // IV_C_C_About_Page
            // 
            this.IV_C_C_About_Page.BackColor = System.Drawing.SystemColors.Info;
            this.IV_C_C_About_Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IV_C_C_About_Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_C_C_About_Page.Location = new System.Drawing.Point(0, 0);
            this.IV_C_C_About_Page.Multiline = true;
            this.IV_C_C_About_Page.Name = "IV_C_C_About_Page";
            this.IV_C_C_About_Page.ReadOnly = true;
            this.IV_C_C_About_Page.Size = new System.Drawing.Size(334, 451);
            this.IV_C_C_About_Page.TabIndex = 0;
            this.IV_C_C_About_Page.Text = "Hello World!!!";
            this.IV_C_C_About_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IV_B_Exit
            // 
            this.IV_B_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_B_Exit.Location = new System.Drawing.Point(247, 416);
            this.IV_B_Exit.Name = "IV_B_Exit";
            this.IV_B_Exit.Size = new System.Drawing.Size(75, 23);
            this.IV_B_Exit.TabIndex = 1;
            this.IV_B_Exit.Text = "Exit";
            this.IV_AB_Exit_Tool.SetToolTip(this.IV_B_Exit, "Press that in you want to Exit from that tool.");
            this.IV_B_Exit.UseVisualStyleBackColor = true;
            this.IV_B_Exit.Click += new System.EventHandler(this.IV_Close_Window_Hook);
            // 
            // IV_AB_Exit_Tool
            // 
            this.IV_AB_Exit_Tool.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IV_AB_Exit_Tool.ToolTipTitle = "IV About";
            // 
            // IV_B_Reload_Programm
            // 
            this.IV_B_Reload_Programm.BackColor = System.Drawing.Color.Red;
            this.IV_B_Reload_Programm.Location = new System.Drawing.Point(12, 399);
            this.IV_B_Reload_Programm.Name = "IV_B_Reload_Programm";
            this.IV_B_Reload_Programm.Size = new System.Drawing.Size(100, 40);
            this.IV_B_Reload_Programm.TabIndex = 2;
            this.IV_B_Reload_Programm.Text = "Reload Programm";
            this.IV_AB_Reload_Programm.SetToolTip(this.IV_B_Reload_Programm, "Press that Button if you want to reload that application.");
            this.IV_B_Reload_Programm.UseVisualStyleBackColor = false;
            this.IV_B_Reload_Programm.Click += new System.EventHandler(this.IV_Reload_B_Hook);
            // 
            // IV_AB_Reload_Programm
            // 
            this.IV_AB_Reload_Programm.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.IV_AB_Reload_Programm.ToolTipTitle = "IV About";
            // 
            // IV_T_CountDown_To_Restart
            // 
            this.IV_T_CountDown_To_Restart.Interval = 3000;
            this.IV_T_CountDown_To_Restart.Tick += new System.EventHandler(this.IV_T_Restart_Hook);
            // 
            // IV_Checker_Core_AppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 451);
            this.Controls.Add(this.IV_B_Reload_Programm);
            this.Controls.Add(this.IV_B_Exit);
            this.Controls.Add(this.IV_C_C_About_Page);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IV_Checker_Core_AppInfo";
            this.Text = "App Info";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IV_About_Closed_Hook);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox IV_C_C_About_Page;
        private System.Windows.Forms.Button IV_B_Exit;
        private System.Windows.Forms.ToolTip IV_AB_Exit_Tool;
        private System.Windows.Forms.Button IV_B_Reload_Programm;
        private System.Windows.Forms.ToolTip IV_AB_Reload_Programm;
        private System.Windows.Forms.Timer IV_T_CountDown_To_Restart;
    }
}