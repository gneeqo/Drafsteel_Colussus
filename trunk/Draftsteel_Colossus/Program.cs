using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bingus");

            Draft draft = new Draft();

            draft.playDraft();

            Console.ReadKey();
        }
    }
}
