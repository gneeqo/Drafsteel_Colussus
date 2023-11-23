using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic.FileIO;

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
                 battle,
                 invalid
             };
     
     
      public Dictionary<String, float> attributes;
     
      public cardType type;

        public Card()
        {
            //init the dictionary
            attributes = new Dictionary<string, float>();
        }

        //change this if you add attributes.
        //should be equal to the number of columns in the csv, -1.
        private static int numberOfAttributes = 17;

      public List<String> combos_names;
      public List<String> nonbos_names;
      
      public List<Card> combos;
      public List<Card> nonbos;



        public static List<Card> ReadInCards( String filepath)
        {
            using (TextFieldParser parser = new TextFieldParser(filepath))
            {
                //the top row of the csv
                var keys = new List<String>();

                //what we will be returning
                var allCardsList = new List<Card>();

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
                    Card currentCard = null;
                    
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
                                //starting a new card, get its name correct
                                currentCard = new Card();
                                currentCard.name = field;
                            }
                            else
                            {
                                //type is an enum, so needs to be done separately
                                if (keys[rowItem] == "Type")
                                {

                                    cardType currentType = cardType.invalid;
                                    if (Enum.TryParse<cardType>(field, out currentType))
                                    {
                                        currentCard.type = currentType;

                                    }
                                    //if card type remains invalid, enum parse failed
                                }
                                else
                                {

                                        if (String.IsNullOrEmpty(field))
                                        {
                                        //it's empty so just have it be 0
                                            currentCard.attributes.Add(keys[rowItem], 0.0f);

                                        }
                                        else 
                                        {
                                        //add the float value from the csv into the corresponding key in this card's attributes
                                        currentCard.attributes.Add(keys[rowItem], float.Parse(field, System.Globalization.CultureInfo.InvariantCulture));

                                        }
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
                                //add the finished card 
                                allCardsList.Add(currentCard);

                            }
                                                        
                        }
                        else
                        {
                            //move to the next column
                            rowItem++;
                        }
                    }
                }
                
                //should have all cards in the csv.
                return allCardsList;
            }

            
        }
    }
}
