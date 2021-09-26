using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV_Gallery_Checkers_Core
{
    public class IVCheckerCore
    {
        /////////////////////////////////////////////////////////////////////
        //IV Note: Intreger Create Scenario for Save Release Progress Bar.//
        ///////////////////////////////////////////////////////////////////
        public int IV_Calculate_for_Progress_Bar(int value_for_recreate = 0, int value_count = 1, string method = "+")
        {
            if(method == "+" || method == "-" || method == "*" || method == "/")
            {
                if(method == "+")
                {
                    value_for_recreate = value_for_recreate + value_count;
                }
                else if(method == "-")
                {
                    value_for_recreate = value_for_recreate - value_count;
                }
                else if (method == "*")
                {
                    value_for_recreate = value_for_recreate * value_count;
                }
                else if (method == "/")
                {
                    value_for_recreate = value_for_recreate / value_count;
                }
                return value_for_recreate;
            }
            else
            {
                return 505;
            }
        }
    }
}
