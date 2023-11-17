using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Player
    {

        List<Booster> packs;

        List<Card> pool;
        
        //cards that have been seen and can't be considered by the bot
        List<Card> seen;
    }
}
