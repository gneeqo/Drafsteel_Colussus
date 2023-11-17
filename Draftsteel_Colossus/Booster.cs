using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Booster
    {
        List<Card> remainingCards;

        public Card pickCard(String pickName)
        {
            //gets the card which was picked
            Card returnValue = remainingCards.Find(x => pickName == x.Name);

            //removes it from the list
            remainingCards.Remove(returnValue);

            //returns that card
            return returnValue;
            
        }


        public void addCard(List<Card> pool)
        { 
            //gets random number of item in the pool
            Random rnd = new Random();
            int pickIndex = rnd.Next(0, pool.Count);

            //adds to the pack
            remainingCards.Add(pool[pickIndex]);

            //removes from the pool
            pool.Remove(pool[pickIndex]);
        }

    }
}
