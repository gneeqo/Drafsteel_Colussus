using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Player
    {
        public string name;

        public int wins;
        public int losses;

        float johnny;
        float spike;
        float timmy;

        public List<Card> pool;

        //cards that have been seen and can't be considered by the bot
        List<Card> seen;


        public static Dictionary<String, float> AvgAttributes(List<Card> poolToEvaluate)
        {
            var averagedAttributes = new Dictionary<String, float>();
            int numOfAttributes = 0;
            bool countAttributes = true;
            foreach (Card currentCard in poolToEvaluate)
            {
                foreach (var item in currentCard.attributes)
                {
                    if (countAttributes) numOfAttributes++;
                    if (averagedAttributes.ContainsKey(item.Key))
                    {
                        if (item.Value != 0)
                        {
                            //multiply by the new value

                            float initial = averagedAttributes[item.Key];
                            float modifier = item.Value;

                            float final = (initial * modifier);

                            averagedAttributes[item.Key] = final;

                        }


                    }
                    else
                    {
                        averagedAttributes.Add(item.Key, item.Value);

                    }
                }

                countAttributes = false;
            }
            var finalDict = new Dictionary<String, float>();
            foreach (var item in averagedAttributes)
            {
                //actually do go mean
                finalDict.Add(item.Key, (float)Math.Pow(item.Value, 1 / numOfAttributes));
            }
            return finalDict;

        }

        // these attributes are affected by player personality.
        public float CalculateBonusValue(Card input)
        {


            var attributes = input.attributes;
            float value = attributes["Value"];
            float infamy = attributes["Infamy"];

            //this calculation should probably be more nuanced.

            value *= (timmy + 1);
            infamy *= (johnny + 1);

            return value + infamy;

        }

        public Player()
        {
            pool = new List<Card>();
            seen = new List<Card>();
        }

        public void pickCard(Booster pack)
        {
            // TODO: Actually implement slurry algorithm
            // THIS IS ALL TEMPORARY!!!
            var poolAttributes = AvgAttributes(pool);

            foreach (var currentCard in pack.remainingCards)
            {
                currentCard.pickValue = 0;

                foreach (var item in currentCard.attributes)
                {
                    //don't consider value or infamy until later
                    if (item.Key != "value" || item.Key != "infamy")
                    {
                        float cardvalue = item.Value;
                        float poolvalue = 0;

                        if (poolAttributes.ContainsKey(item.Key))
                        {
                            poolvalue = poolAttributes[item.Key];
                        }
                        //add value based on compatibility with the pool
                        //e.g. if an attribute is 1 in the pool and 1 in the card,
                        //1.0 value will be added.
                        //if the attribute is 0.5 in the pool and 1 in the card,
                        //0.5 value will be added
                        currentCard.pickValue += (cardvalue * poolvalue);

                    }

                }
                currentCard.pickValue += CalculateBonusValue(currentCard);

            }

            pack.remainingCards.Sort((x, y) => x.pickValue.CompareTo(y.pickValue));
            pack.remainingCards.Reverse();
            Card card = pack.pickCard(pack.remainingCards[0].name);
            pool.Add(card);

            // TODO: Add to seen list
        }
    }
}
