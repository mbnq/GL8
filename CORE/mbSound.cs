
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.Media;
using System.Windows.Forms;

namespace GL8.CORE
{
    public static class mbKeySoundHandler
    {
        public static void mbKeyPressSoundHandler(object sender, KeyPressEventArgs e)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer("sfx/mbkeypress.wav"))
                {
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio error: " + ex.Message);
            }
        }
        public static void RegisterKeySoundHandler(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBoxBase || ctrl is MaterialTextBox2)
                {
                    ctrl.KeyPress += mbKeySoundHandler.mbKeyPressSoundHandler;
                }

                if (ctrl.HasChildren)
                {
                    RegisterKeySoundHandler(ctrl.Controls);
                }
            }
        }
    }
}
