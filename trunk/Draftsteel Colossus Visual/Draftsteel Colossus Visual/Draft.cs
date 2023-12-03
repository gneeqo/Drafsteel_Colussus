using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Draftsteel_Colossus_Visual;

namespace Draftsteel_Colossus
{
    public 
    class Draft
    {
        public string cardsFileName = "";
        public string playersFileName = "";
        private string dataDirectory = "../../Data/";
        private string outputDirectory = "../../Data/Output";

        int numPlayers = 8;
        int numPacks = 3;
        int numPicksPer = 1;
        int numCardsPer = 15;

        public int currPack;
        public int pick;
        public int round;

        private int startingPackIndex;
        private bool started = false;

        List<Card> allCards;

        List<Booster> allPacks;

        public List<Player> allPlayers;
            
        public Draft()
        {
            allCards = new List<Card>();
            allPacks = new List<Booster>();
            allPlayers = new List<Player>();
        }

        public void setCardsFileName(string name)
        {
            cardsFileName = dataDirectory + name;
        }
        public void setPlayerFileName(string name)
        {
            playersFileName = dataDirectory + name;
        }

        void readPlayerData(string filename)
        {
            allPlayers = Player.ReadInPlayers(filename);
        }

        void readCardData(string filename)
        {
            // TODO: THIS IS TEMPORARY CARD DATA READING
            allCards = Card.ReadInCards(filename);

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

        void OutputPlayerData()
        {
            // TODO: Change this to a better data format
            foreach (Player p in allPlayers)
            {
                // Create a new file in the output directory
                string path = outputDirectory;
                try
                {
                    String timeStamp = GetTimestamp(DateTime.Now);
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(outputDirectory, p.name + "_" + timeStamp + ".txt"), true))
                    {
                        outputFile.WriteLine("Name: " + p.name);
                        outputFile.WriteLine("Wins: " +p.wins + ", Losses: " + +p.losses);

                        // Write each card name to the newly created text file
                        for (int i = 0; i < p.pool.Count; ++i)
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

        // Simple random shuffle function, just does n random swaps
        void Shuffle(List<Player> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                --n;
                // Get a random index
                int k = rng.Next(n + 1);
                // Swap the values
                Player value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        void AssignWinningStatistics()
        {
            // Make a list of the winners and add shuffle them around
            List<Player> winners = new List<Player>();
            for(int i = 0; i < numPlayers; ++i)
            {
                winners.Add(allPlayers[i]);
            }
            Shuffle(winners);

            // Player 0 went 3-0, Players 1 thru 3 went 2-1, 4 thru 6 went 1-2, and player 7 went 0-3
            winners[0].wins = 3;
            winners[0].losses = 0;

            for(int i = 1; i <= 3; ++i)
            {
                winners[i].wins = 2;
                winners[i].losses = 1;
            }

            for (int i = 4; i <= 6; ++i)
            {
                winners[i].wins = 1;
                winners[i].losses = 2;
            }

            winners[7].wins = 0;
            winners[7].losses = 3;
        }

        public void startDraft()
        {
            if (started)
                return;

            started = true;

            // Read all the player data first
            readPlayerData(playersFileName);

            // Read in all of the card data
            readCardData(cardsFileName);

            // Generate all the packs
            generatePacks();
        }

        public bool nextPick()
        {
            // If the pick number is greater than the number of cards in a pack, reset it
            if (pick >= numCardsPer)
            {
                ++round;
                startingPackIndex = numPlayers * round;
                pick = 0;
            }

            if (round >= numPacks)
                return false;

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

            ++pick;

            return true;
        }

        public void finishPack()
        {
            if (round >= numPacks)
                return;

            // Determines where the packs start
            startingPackIndex = numPlayers * round;

            // If the pack is empty, start a new pack
            if(allPacks[startingPackIndex].remainingCards.Count <= 0)
            {
                ++round;
                startingPackIndex = numPlayers * round;
                pick = 0;
            }

            // Run through each player and have them pick numPicksPer cards
            while (allPacks[startingPackIndex].remainingCards.Count > 0)
            {
                // If next pick returns false, that means the next pack is ready
                if(!nextPick())
                {
                    break;
                }
            }
        }

        public void finishDraft()
        {
            while(round < numPacks)
            {
                finishPack();
            }

            // Randomly assign winning statistics
            AssignWinningStatistics();

            // At this point, all packs have been drafted and each player has a pool of cards and a win/loss score
            // Output all of the cards that each player has to a .txt for now
            OutputPlayerData();

            // TODO: Using the players that won/lost, adjust the values in the table accordingly
        }

        public void playDraft()
        {
            if(!started)
                startDraft();

            // Run the draft!
            // Run through each pack round
            for(round = 0; round < numPacks; ++round)
            {
                finishPack();
            }

            // Finish any packs remaining, assign winners, and output player and learning data
            finishDraft();
        }
    }
}
