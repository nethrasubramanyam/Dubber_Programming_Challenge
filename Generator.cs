namespace LottoNumberGenerator
{
    internal class Generator
    {

        /// <summary>
        ///  This is a lottery number generator program.
        /// </summary>
        public void LottoGenerator()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("     Dubber - Lotto number generator         ");
            Console.WriteLine("=============================================");
            Console.WriteLine();
            List<int> possibleNumbers = Enumerable.Range(1, 49).ToList();
            var lotteryNumers = GenerateLottoNumber(possibleNumbers);
            lotteryNumers.Sort();
            DisplayResults(lotteryNumers);
            Console.Write("\nPress any key to draw the bonus ball... ");
            Console.ReadLine();
            GenerateAndDisplayBonusBall(possibleNumbers);
        }

        /// <summary>
        /// Generate/choose 6 unique numbers 
        /// </summary>
        /// <param name="possibleNumbers"> Possible numbers from which the random number can be generated(chosen) </param>
        /// <returns></returns>
        public static List<int> GenerateLottoNumber(List<int> possibleNumbers)
        {
            Random random = new();
            List<int> lotteryNumers = [];
            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(possibleNumbers.Count);
                lotteryNumers.Add(possibleNumbers[index]);
                possibleNumbers.RemoveAt(index);
            }
            return lotteryNumers;
        }

        /// <summary>
        /// Generates and displays bonus ball
        /// </summary>
        /// <param name="possibleNumbers"> Possible numbers from which the bonus ball can be drawn(chosen)</param>
        public static void GenerateAndDisplayBonusBall(List<int> possibleNumbers)
        {
            Random random = new();
            int index = random.Next(possibleNumbers.Count);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  " + possibleNumbers[index] + "  ");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Retrieve all values from the list and output to console
        /// </summary>
        /// <param name="lotteryNumers"> Randomly genearted list containing lotto numbers </param>
        public static void DisplayResults(List<int> lotteryNumers)
        {
            foreach (var num in lotteryNumers)
            {
                SetBackgroudColor(num);
                Console.Write("  " + num + "  ");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Set coloured background based on the lotto number range: 1-9 grey, 10-19 blue, 20-29 pink, 30-39 green, 40-49 yellow.
        /// </summary>
        /// <param name="num"> Randomly genearted lotto number </param>
        public static void SetBackgroudColor(int num)
        {
            ConsoleColor background;
            if (num > 39)
            {
                background = ConsoleColor.Yellow;
            }
            else if (num > 29)
            {
                background = ConsoleColor.Green;
            }
            else if (num > 19)
            {
                background = ConsoleColor.Magenta;
            }
            else if (num > 9)
            {
                background = ConsoleColor.Blue;
            }
            else
            {
                background = ConsoleColor.DarkGray;
            }
            Console.BackgroundColor = background;
        }
    }
}
