using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Card
    {

        String Name;
        enum cardType
        { 
            creature,
            land,
            instant,
            sorcery,
            enchantment,
            artifact,
            planeswalker,
            battle
        };
        


        float white;
        float black;
        float blue;
        float red;
        float green;

        cardType type;

        float value;

        float infamy;

        float aggro;
        float reanimate;
        float breach;
        float ramp;
        float control;
        float artifacts;
        float storm;
        float sacrifice;
        float blink;
        float lands;

        List<String> combos_names;
        List<String> nonbos_names;

        List<Card> combos;
        List<Card> nonbos;



    }
}
