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

 


           List<Card> cardlist = Card.ReadInCards("..//..//Data//11_22_CardValueTest.csv");

           

            Draft draft = new Draft(cardlist);
            draft.playDraft();

            

            bool DoStringOutput = false;
           
            //Uncomment below line to get a string output of the card list (a little janky)
           //DoStringOutput = true;
            if (DoStringOutput)
            {
                bool firstCard = true;
                Console.WriteLine();
                foreach (var currentcard in cardlist)
                {
                    if (firstCard)
                    {

                        Console.Write("Name ");
                        Console.Write("Type ");
                        foreach (var data in currentcard.attributes)
                        {
                            Console.Write(data.Key);
                            Console.Write(" ");

                        }
                        Console.WriteLine();
                        firstCard = false;
                    }

                    Console.Write(currentcard.name);

                    Console.Write(" ");

                    Console.Write(currentcard.type.ToString());

                    Console.Write(" ");

                    foreach (var data in currentcard.attributes)
                    {
                        Console.Write(data.Value.ToString());

                        var whitespace = new String(' ', data.Key.Length);
                        Console.Write(whitespace);

                    }
                    Console.WriteLine();
                }
            }
            
            Console.ReadKey();
        }
    }




}
