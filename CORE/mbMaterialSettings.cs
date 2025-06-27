
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

    mbMaterialSettings.cs

*/

using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        // ------------------- MaterialSkin setup ---------

        public static ColorScheme mbColorSchemeGrey = new ColorScheme(
            Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500,
            Accent.Grey400, TextShade.WHITE);

        public static ColorScheme mbColorSchemeRed = new ColorScheme(
            Primary.Red800, Primary.Red900, Primary.Red500,
            Accent.Red200, TextShade.WHITE);

        public static ColorScheme mbColorSchemeGreen = new ColorScheme(
            Primary.Green800, Primary.Green900, Primary.Green500,
            Accent.LightGreen200, TextShade.WHITE);

        public static ColorScheme mbColorSchemeBlue = new ColorScheme(
            Primary.Blue800, Primary.Blue900, Primary.Blue500,
            Accent.LightBlue200, TextShade.WHITE);

        public static ColorScheme mbColorSchemeMono = new ColorScheme(
            Primary.Grey500, Primary.Grey700, Primary.Black100,
            Accent.Grey400, TextShade.WHITE);

        public void InitializeMaterialSkin(ColorScheme _colorSchemeInput = null, string brightness = "LIGHT")
        {
            if (_colorSchemeInput == null)
            {
                _colorSchemeInput = mbColorSchemeGrey;
            }

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            if (brightness.ToUpper() == "DARK")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }

            materialSkinManager.ColorScheme = _colorSchemeInput;
        }

        public ColorScheme mbActiveColorScheme = mbColorSchemeBlue; // default color scheme
        public static int mbColorSchemeIndex;                       // default color scheme index
        public void mbSwitchColorScheme()
        {
            switch (mbColorSchemeIndex)
            {
                case 0:
                    mbActiveColorScheme = mbColorSchemeGrey;

                    mbDataView.BackgroundColor = Color.Gray;
                    mbDataView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                    mbDataView.DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
                case 1:
                    mbActiveColorScheme = mbColorSchemeRed;

                    mbDataView.GridColor = Color.MistyRose;
                    mbDataView.DefaultCellStyle.SelectionBackColor = Color.MistyRose;
                    mbDataView.DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
                case 2:
                    mbActiveColorScheme = mbColorSchemeGreen;

                    mbDataView.GridColor = Color.LightGreen;
                    mbDataView.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                    mbDataView.DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
                case 3:
                    mbActiveColorScheme = mbColorSchemeBlue;

                    mbDataView.GridColor = Color.LightBlue;
                    mbDataView.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    mbDataView.DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
                case 4:
                    mbActiveColorScheme = mbColorSchemeMono;

                    mbDataView.GridColor = Color.LightGray;
                    mbDataView.BackgroundColor = Color.Gray;
                    mbDataView.ForeColor = Color.Gray;
                    mbDataView.BackColor = Color.LightGray;
                    mbDataView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                    mbDataView.DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
                default:
                    mbActiveColorScheme = mbColorSchemeBlue;

                    mbDataView.GridColor = Color.LightBlue;
                    mbDataView.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                    mbDataView.DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
            }
            InitializeMaterialSkin(mbActiveColorScheme);
            mbDataView.Refresh();
            this.Refresh();
        }
    }
}  
