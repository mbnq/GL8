
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin;
using MaterialSkin.Controls;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        // ------------------- MaterialSkin setup ---------

        public static ColorScheme mbColorSchemeGrey = new ColorScheme(
            Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500,
            Accent.LightBlue200, TextShade.WHITE);

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
                    break;
                case 1:
                    mbActiveColorScheme = mbColorSchemeRed;
                    break;
                case 2:
                    mbActiveColorScheme = mbColorSchemeGreen;
                    break;
                case 3:
                    mbActiveColorScheme = mbColorSchemeBlue;
                    break;
                case 4:
                    mbActiveColorScheme = mbColorSchemeMono;
                    break;
                default:
                    mbActiveColorScheme = mbColorSchemeBlue;
                    break;
            }
            InitializeMaterialSkin(mbActiveColorScheme);
        }
    }
}  
