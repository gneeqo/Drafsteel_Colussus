using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Draftsteel_Colossus_Visual
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bitmap image = ScryfallAPI.GetCardImage("Black Lotus");
            Bitmap image2 = ScryfallAPI.GetCardImage("Black Lotus");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Bingus());
        }
    }
}
