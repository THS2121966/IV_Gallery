
namespace IV_Gallery
{
    partial class IV_Check_Process_Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IV_Check_Process_Window));
            this.IV_DBG_Label_Count_State = new System.Windows.Forms.Label();
            this.IV_DBG_T_Still_Counting = new System.Windows.Forms.Timer(this.components);
            this.IV_DBG_T_Exit = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // IV_DBG_Label_Count_State
            // 
            this.IV_DBG_Label_Count_State.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IV_DBG_Label_Count_State.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IV_DBG_Label_Count_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IV_DBG_Label_Count_State.Location = new System.Drawing.Point(0, 0);
            this.IV_DBG_Label_Count_State.Name = "IV_DBG_Label_Count_State";
            this.IV_DBG_Label_Count_State.Size = new System.Drawing.Size(399, 96);
            this.IV_DBG_Label_Count_State.TabIndex = 0;
            this.IV_DBG_Label_Count_State.Text = "0...1...2...3...4...5...6...7...8...9...10";
            this.IV_DBG_Label_Count_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IV_DBG_T_Still_Counting
            // 
            this.IV_DBG_T_Still_Counting.Interval = 350;
            this.IV_DBG_T_Still_Counting.Tick += new System.EventHandler(this.IV_DBG_T_S_C_Hook);
            // 
            // IV_DBG_T_Exit
            // 
            this.IV_DBG_T_Exit.Interval = 1000;
            this.IV_DBG_T_Exit.Tick += new System.EventHandler(this.IV_T_DBG_Exit_Hook);
            // 
            // IV_Check_Process_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(399, 96);
            this.Controls.Add(this.IV_DBG_Label_Count_State);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IV_Check_Process_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IV Debug Load Check";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IV_DL_Closed_Hook);
            this.Load += new System.EventHandler(this.IV_DL_Load_Hook);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label IV_DBG_Label_Count_State;
        private System.Windows.Forms.Timer IV_DBG_T_Still_Counting;
        private System.Windows.Forms.Timer IV_DBG_T_Exit;
    }
}