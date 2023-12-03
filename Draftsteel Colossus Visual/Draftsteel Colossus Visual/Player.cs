using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace Draftsteel_Colossus
{
    public
    class Player
    {
        public string name;

        public int wins;
        public int losses;

        //change this if you add attributes.
        //should be equal to the number of columns in the csv, -1.
        private static int numberOfAttributes = 16;

        public Dictionary<string, double> personality;

        public List<Card> pool;


        public Card lastPicked;
        //cards that have been seen and can't be considered by the bot
        List<Card> seen;


        public static Dictionary<String, double> AvgAttributes(List<Card> poolToEvaluate)
        {
            var averagedAttributes = new Dictionary<String, double>();
            int numOfAttributes = 0;
            bool countAttributes = true;
            foreach (Card currentCard in poolToEvaluate)
            {
                foreach (var item in currentCard.attributes)
                {
                    if (countAttributes) numOfAttributes++;
                    if (averagedAttributes.ContainsKey(item.Key))
                    {
                        double modifier = item.Value;
                        double initial = averagedAttributes[item.Key];
                        
                        

                        double final = (initial + modifier);

                        averagedAttributes[item.Key] = final;

                    }
                    else
                    {
                        averagedAttributes.Add(item.Key, item.Value);

                    }
                }

                countAttributes = false;
            }
            var finalDict = new Dictionary<String, double>();
            foreach (var item in averagedAttributes)
            {
                //actually do go mean
                
                double rawVal = item.Value;
                finalDict.Add(item.Key, rawVal/poolToEvaluate.Count);
                
            }
            return finalDict;

        }

        // these attributes are affected by player personality.

        public Player()
        {
            pool = new List<Card>();
            seen = new List<Card>();


            personality = new Dictionary<string, double>();
        }


        public static List<Player> ReadInPlayers(String filepath)
        {

            using (TextFieldParser parser = new TextFieldParser(filepath))
            {
                //the top row of the csv
                var keys = new List<String>();

                //what we will be returning
                var allPlayersList = new List<Player>();

                //should only be true for the first row(obviously)
                //turn off after first row
                bool firstRow = true;

                //getting rows
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {

                    //which column are you in
                    int rowItem = 0;

                    //make a new var to hold the card
                    Player currentPlayer = null;

                    // Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {

                        if (firstRow)
                        {
                            //we're in first row, so get the row keys
                            keys.Add(field);
                        }
                        else
                        {
                            //name is a string, so needs to be done separately
                            if (keys[rowItem] == "Name")
                            {
                                //starting a new player, get its name correct
                                currentPlayer = new Player();
                                currentPlayer.name = field;

                            }
                            else
                            {


                                if (String.IsNullOrEmpty(field))
                                {
                                    //it's empty so just have it be 0
                                    currentPlayer.personality.Add(keys[rowItem], 0.0f);

                                }
                                else
                                {
                                    //add the double value from the csv into the corresponding key in this player's personality
                                    currentPlayer.personality.Add(keys[rowItem], double.Parse(field, System.Globalization.CultureInfo.InvariantCulture));

                                }




                            }
                        }

                        if (rowItem == numberOfAttributes)
                        {
                            //the row should be ending.  Make sure numberOfAttributes is the number of coluimns -1
                            //reset row item
                            rowItem = 0;

                            if (firstRow)
                            {
                                //we're never in first row again.
                                firstRow = false;
                            }
                            else
                            {
                                //add the finished player 
                                allPlayersList.Add(currentPlayer);

                            }

                        }
                        else
                        {
                            //move to the next column
                            rowItem++;
                        }
                    }
                }

                //should have all players in the csv.
                return allPlayersList;
            }

        }



        public double CalculateBonusValue(Card input)
        {


            var attributes = input.attributes;
            double value = attributes["Value"];
            double infamy = attributes["Infamy"];

            //this calculation should probably be more nuanced.

            value *= (personality["Value"] + 1);
            infamy *= (personality["Infamy"] + 1);

            return value + infamy;

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
                        double cardvalue = item.Value;
                        double poolvalue = 0;
                        double personalvalue = 0;

                        if (poolAttributes.ContainsKey(item.Key))
                        {
                            poolvalue = poolAttributes[item.Key];
                        }
                        if (personality.ContainsKey(item.Key))
                        {
                            personalvalue = personality[item.Key];
                        }
                        //add value based on compatibility with the pool
                        //e.g. if an attribute is 1 in the pool and 1 in the card,
                        //1.0 value will be added.
                        //if the attribute is 0.5 in the pool and 1 in the card,
                        //0.5 value will be added
                        currentCard.pickValue += (cardvalue * poolvalue) + (cardvalue*personalvalue);

                    }

                }
                currentCard.pickValue += CalculateBonusValue(currentCard);

            }

            pack.remainingCards.Sort((x, y) => x.pickValue.CompareTo(y.pickValue));
            pack.remainingCards.Reverse();
            Card card = pack.pickCard(pack.remainingCards[0].name);
            pool.Add(card);
            lastPicked = card;
            // TODO: Add to seen list
        }
    }
}
