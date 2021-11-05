using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IV_Gallery
{
    public partial class IV_Check_Process_Window : Form
    {
        public IV_Check_Process_Window()
        {
            InitializeComponent();
            IV_DBG_Init_Default_Parms();
        }

        public bool iv_dbg_process_p_closed = true;
        private string iv_dbg_process_text = "0";
        private int iv_dbg_p_last_state = 0;
        private string iv_dbg_process_name = "NULL:";
        private bool iv_dbg_p_state_done = false;
        private bool iv_dbg_ignore_msg_check = false;

        private string IV_DBG_P_Next_State(int count_state, string process_name = "NULL:")
        {
            if(count_state > 0 && count_state <= 10)
            {
                iv_dbg_p_last_state = count_state;
                iv_dbg_process_name = process_name;
                if (count_state == 0)
                    iv_dbg_process_text = process_name + " 0...";
                else if (count_state == 1)
                    iv_dbg_process_text = process_name + " 0...1...";
                else if (count_state == 2)
                    iv_dbg_process_text = process_name + " 0...1...2...";
                else if (count_state == 3)
                    iv_dbg_process_text = process_name + " 0...1...2...3...";
                else if (count_state == 4)
                    iv_dbg_process_text = process_name + " 0...1...2...3...4...";
                else if (count_state == 5)
                    iv_dbg_process_text = process_name + " 0...1...2...3...4...5...";
                else if (count_state == 6)
                    iv_dbg_process_text = process_name + " 0...1...2...3...4...5...6...";
                else if (count_state == 7)
                    iv_dbg_process_text = process_name + " 0...1...2...3...4...5...6...7...";
                else if (count_state == 8)
                    iv_dbg_process_text = process_name + " 0...1...2...3...4...5...6...7...8...";
                else if (count_state == 9)
                    iv_dbg_process_text = process_name + " 0...1...2...3...4...5...6...7...8...9...";
                else if (count_state == 10)
                {
                    iv_dbg_process_text = process_name + " 0...1...2...3...4...5...6...7...8...9...10";
                }
                else if (count_state > 10)
                {
                    MessageBox.Show("Wrong Progress state - " + count_state + ". Tell a programmer!!!", IV_Gallery_Main_Menu.thsdev_iv_warning_logo);
                    return null;
                }
            }
            return iv_dbg_process_text;
        }

        private bool iv_dbg_first_t_check = true;

        public void IV_DBG_Release_State(string process_name = "NULL", int state = -1, bool force_more_size = false)
        {
            if(force_more_size)
            {
                this.Width = Width + 30;
                this.Height = Height + 30;
            }
            if(state >= 0 && state <= 10)
            {
                IV_DBG_P_Next_State(state, process_name);
            }
            else
            {
                IV_DBG_Label_Count_State.Text = "INVAID Parms!!! Tell a Programmer!!!";
                iv_dbg_p_state_done = true;
                iv_dbg_ignore_msg_check = true;
            }
            if(iv_dbg_first_t_check)
            {
                IV_DBG_T_Still_Counting.Enabled = true;
                iv_dbg_first_t_check = false;
            }
            if (!this.Visible)
                this.Visible = true;
        }

        private void IV_DBG_Init_Default_Parms()
        {
            iv_dbg_process_p_closed = false;
            IV_DBG_Label_Count_State.Text = iv_dbg_process_text;
        }

        private void IV_DL_Load_Hook(object sender, EventArgs e)
        {
            iv_dbg_process_p_closed = false;
        }

        private void IV_DL_Closed_Hook(object sender, FormClosedEventArgs e)
        {
            iv_dbg_process_p_closed = true;
        }

        private void IV_DBG_T_S_C_Hook(object sender, EventArgs e)
        {
            IV_DBG_P_Next_State(iv_dbg_p_last_state, iv_dbg_process_name);
            if (IV_DBG_Label_Count_State.Text != iv_dbg_process_text && !iv_dbg_ignore_msg_check)
                IV_DBG_Label_Count_State.Text = iv_dbg_process_text;
            if (iv_dbg_p_state_done || iv_dbg_p_last_state == 10)
            {
                IV_DBG_T_Still_Counting.Enabled = false;
                IV_DBG_T_Exit.Enabled = true;
            }
            else
                iv_dbg_p_last_state++;
        }

        private void IV_T_DBG_Exit_Hook(object sender, EventArgs e)
        {
            IV_DBG_T_Exit.Enabled = false;
            this.Close();
        }
    }
}
