using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Player
    {
        public string name;

        float johnny;
        float spike;
        float timmy;

        List<Card> pool;
        
        //cards that have been seen and can't be considered by the bot
        List<Card> seen;

        public Player()
        {
            pool = new List<Card>();
            seen = new List<Card>();
        }

        public void pickCard(Booster pack)
        {
            // TODO: Actually implement slurry algorithm
            // THIS IS ALL TEMPORARY!!!

            Card card = pack.pickCard(pack.remainingCards[0].name);
            pool.Add(card);

            // TODO: Add to seen list
        }
    }
}
