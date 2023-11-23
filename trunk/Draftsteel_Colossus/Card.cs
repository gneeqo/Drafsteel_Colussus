using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Card
    {
        
        public String name;
      public enum cardType
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
     
     
     
      public float white;
      public float black;
      public float blue;
      public float red;
      public float green;
      
      public cardType type;
      
      public float value;
      
      public float infamy;
      
      public float aggro;
      public float reanimate;
      public float breach;
      public float ramp;
      public float control;
      public float artifacts;
      public float storm;
      public float sacrifice;
      public float blink;
      public float lands;
      
      public List<String> combos_names;
      public List<String> nonbos_names;
      
      public List<Card> combos;
      public List<Card> nonbos;

    }
}
