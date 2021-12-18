using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iv_winforms_main = System.Windows.Forms;
using iv_gallery_hook_main = IV_Gallery.IV_Gallery_Main_Menu;

namespace IV_Gallery
{
    class IV_Vector_Base_2D
    {
        protected int x_vec = 0;
        protected int y_vec = 0;

        public IV_Vector_Base_2D(int x = 0, int y = 0)
        {
            if (x != 0)
                x_vec = x;
            if (y != 0)
                y_vec = y;
        }
        ~IV_Vector_Base_2D()
        {
            x_vec = 0;
            y_vec = 0;
        }

        public virtual int[] GetVector()
        {
            return new int[2] { x_vec, y_vec };
        }

        public virtual int GetVectorX()
        {
            return x_vec;
        }

        public virtual int GetVectorY()
        {
            return y_vec;
        }

        public virtual void SetVector(int x, int y)
        {
            x_vec = x;
            y_vec = y;
        }

        public virtual string[] ConvertVectorToString()
        {
            string x_vec_string = x_vec + "";
            string y_vec_string = y_vec + "";

            return new string[2] { x_vec_string, y_vec_string };
        }

        public virtual void PrintVector()
        {
            iv_winforms_main.MessageBox.Show("Currient Vector2D Parms: x = "+x_vec+"; y = "+y_vec+".", iv_gallery_hook_main.thsdev_iv_logo, 
                iv_winforms_main.MessageBoxButtons.OK, iv_winforms_main.MessageBoxIcon.Information);
        }
    }

    class IV_Vector_Base_3D : IV_Vector_Base_2D
    {
        private int z_vec = 0;

        public IV_Vector_Base_3D(int x = 0, int y = 0, int z = 0) : base(x, y)
        {
            if (x != 0)
                x_vec = x;
            if (y != 0)
                y_vec = y;
            if (z != 0)
                z_vec = z;
        }
        ~IV_Vector_Base_3D()
        {
            x_vec = 0;
            y_vec = 0;
            z_vec = 0;
        }

        public override int[] GetVector()
        {
            return new int[3] { x_vec, y_vec, z_vec };
        }

        public override int GetVectorX()
        {
            return base.GetVectorX();
        }

        public override int GetVectorY()
        {
            return base.GetVectorY();
        }

        public int GetVectorZ()
        {
            return z_vec;
        }

        public void SetVector3D(int x, int y, int z)
        {
            x_vec = x;
            y_vec = y;
            z_vec = z;
        }

        public override string[] ConvertVectorToString()
        {
            string x_vec_string = x_vec + "";
            string y_vec_string = y_vec + "";
            string z_vec_string = z_vec + "";

            return new string[3] { x_vec_string, y_vec_string, z_vec_string };
        }

        public override void PrintVector()
        {
            iv_winforms_main.MessageBox.Show("Currient Vector3D Parms: x = " + x_vec + "; y = " + y_vec + "; z = "+z_vec+".", iv_gallery_hook_main.thsdev_iv_logo,
                iv_winforms_main.MessageBoxButtons.OK, iv_winforms_main.MessageBoxIcon.Information);
        }
    }
}
