using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draftsteel_Colossus
{
    class Draft
    {
        string cardsFileName = "../../Data/MTGOVintageCube.txt";
        string playersFileName = "../../Data/PlayerData.txt";
        string outputDirectory = "../../Data/Output";

        int numPlayers = 8;
        int numPacks = 3;
        int numPicksPer = 1;
        int numCardsPer = 15;

        List<Card> allCards;

        List<Booster> allPacks;

        List<Player> allPlayers;

        public Draft()
        {
            allCards = new List<Card>();
            allPacks = new List<Booster>();
            allPlayers = new List<Player>();
        }
        void readPlayerData(string filename)
        {
            // TODO: THIS IS TEMPORARY PLAYER DATA READING
            string[] playernames = File.ReadAllLines(filename);

            for (int i = 0; i < playernames.Length; ++i)
            {
                Player currPlayer = new Player();
                currPlayer.name = playernames[i];
                allPlayers.Add(currPlayer);
            }
        }

        void readCardData(string filename)
        {
            // TODO: THIS IS TEMPORARY CARD DATA READING
            string[] cardnames = File.ReadAllLines(filename);

            for(int i = 0; i < cardnames.Length; ++i)
            {
                Card currcard = new Card();
                currcard.name = cardnames[i];
                allCards.Add(currcard);
            }
        }

        void generatePacks()
        {
            // Each player gets numPacks of packs
            for(int i = 0; i < numPlayers * numPacks; ++i)
            {
                allPacks.Add(new Booster(numCardsPer, allCards));
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMdd_HHmmss");
        }

        public void playDraft()
        {
            // Read all the player data first
            readPlayerData(playersFileName);

            // Read in all of the card data
            readCardData(cardsFileName);

            // Generate all the packs
            generatePacks();

            // Run the draft!
            // Run through each pack round
            for(int round = 0; round < numPacks; ++round)
            {
                // Determines where the packs start
                int startingPackIndex = numPlayers * round;

                int pick = -1;

                // Run through each player and have them pick numPicksPer cards
                while (allPacks[startingPackIndex].remainingCards.Count > 0)
                {
                    ++pick;
                   
                    for (int currPlayer = 0; currPlayer < allPlayers.Count; ++currPlayer)
                    {
                        // Determine which pack each player looks at
                        int packIndex = startingPackIndex + ((pick + currPlayer) % allPlayers.Count);
                        Booster currPack = allPacks[packIndex];

                        for (int j = 0; j < numPicksPer; ++j)
                        {
                            // Player picks a card
                            allPlayers[currPlayer].pickCard(currPack);
                        }
                    }
                }
            }

            // At this point, all packs have been drafted and each player has a pool of cards

            // Output all of the cards that each player has to a .txt for now
            // TODO: Change this to a better data format
            foreach(Player p in allPlayers)
            {
                // Create a new file in the output directory
                string path = outputDirectory;
                try
                {
                    String timeStamp = GetTimestamp(DateTime.Now);
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(outputDirectory, p.name + "_" + timeStamp + ".txt"), true))
                    {
                        // Write each card name to the newly created text file
                        for(int i = 0; i < p.pool.Count; ++i)
                        {
                            outputFile.WriteLine(p.pool[i].name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
