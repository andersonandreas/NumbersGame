namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> saveGuessedNums = new();
            Random random = new();

            int randomNum = random.Next(1, 20);
            int Maxguesses = 5;
            bool gameOn = true;
            int userGuess;


            WelcomeInfo(1, 20);

            while (Maxguesses > 0 && gameOn)
            {

                if (int.TryParse(Console.ReadLine(), out userGuess))
                {

                    if (!saveGuessedNums.Contains(userGuess))
                    {
                        saveGuessedNums.Add(userGuess);
                        Maxguesses--;
                        CheckGuess(randomNum, userGuess, Maxguesses);

                    }
                    else
                    {
                        Console.WriteLine("Du har redan gissat på detta nummber. Valj ett annat nummber..");
                    }
                }

                else
                {
                    Console.WriteLine("Fel inmatning, endast siffror tillåtna. Skriv en ny gissning.");

                }

            }

            void WelcomeInfo(int numSpan1, int numSpan2)
            {
                Console.WriteLine($"Välkommen! Jag tänker på ett nummer. Kan du gissa vilket?\nDu får fem försök och du får hålla dig inom spanet på ({numSpan1} - {numSpan2}).");

            }


            void GuLeft(int guessLeft)
            {
                Console.WriteLine($"Antal forsok kvar: {guessLeft}");
            }


            void CheckGuess(int rightNum, int userGuessNum, int guessesLeft)
            {


                if (guessesLeft == 0 && userGuessNum != rightNum)
                {
                    Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                    Console.WriteLine($"Talet som du sökte var: {randomNum}");
                    gameOn = false;
                }

                else if (rightNum == userGuessNum + 1 || rightNum == userGuessNum - 1)
                {
                    Console.WriteLine("Det bränns!");
                    GuLeft(Maxguesses);
                }

                else if (rightNum == userGuessNum)
                {
                    Console.WriteLine("Wohoo! Du klarade det!");
                    gameOn = false;
                }

                else if (userGuessNum > rightNum)
                {
                    Console.WriteLine("Tyvärr, du gissade för högt!");
                    GuLeft(Maxguesses);
                }

                else if (userGuessNum < rightNum)
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt!");
                    GuLeft(Maxguesses);
                }


            }


        }
    }
}
