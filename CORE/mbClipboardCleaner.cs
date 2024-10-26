
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

    Usage _ = mbClipboardCleaner.AutoClearAsync(10);

*/

using MaterialSkin.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GL8.CORE
{
    public static class mbClipboardCleaner
    {
        public static async Task AutoClearAsync(int delay = 10)
        {
            try
            {
                await Task.Delay(delay * 1000);

                if (Clipboard.ContainsText()) Clipboard.Clear();
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred while managing the clipboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
