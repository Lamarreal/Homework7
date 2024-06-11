
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyNamespace
{
    public enum CardSymbol
    {
       None = 0,
       Hearts = '♥',
       Diamonds = '♦',
       Spades = '♠',
       Clubs = '♣',

    }
    public class Card
    {
        public string MainFrame = "";
        public string Id = "";


        public void Draw()
        {
            var rand = new Random();

            int rng = rand.Next(1, 4);
            CardSymbol symbol = (CardSymbol)rng;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(MainFrame, Id, (char)symbol, "║", "═", "╚", "╝", "╔", "╗");
        }
    }
    class Space
    {
        static float Power(float A, float N){
            return MathF.Pow(A,N);
        }

        static string CardTemplate = "{6}{3}{3}{3}{3}{3}{3}{3}{7}\n{2} {0,4}  {2}\n{2}       {2}\n{2}       {2}\n{2}   {1}   {2}\n{2}       {2}\n{2}       {2}\n{2}  {0,-4} {2}\n{4}{3}{3}{3}{3}{3}{3}{3}{5}\n";

        static List<Card> GetCards()
        {
            List<Card> cards = new();

            for (int i = 1; i <= 14; i++)
            {
                string CurentId = i.ToString();

                switch (i)
                {
                    case 11:
                        CurentId = "Val";
                        break;
                    case 12:
                        CurentId = "Dama";
                        break;
                    case 13:
                        CurentId = "King";
                        break;
                    case 14:
                        CurentId = "Ace";
                        break;
                    default:
                        break;
                }

                Card card = new Card();
                card.MainFrame = CardTemplate;
                card.Id = CurentId;
                cards.Add(card);
            }

            return cards;
        }

        static void SumOfDP(in int A,in int B,out int Result)
        {
            int Res = 0;
            try
            {

                if (A > B)
                    throw new Exception("Number A must be smaller than B");

                for (int i = A; i < B; i++)
                {
                    Res += i;
                }
                Result = Res;
            }
            catch (Exception E)
            {
        
                Console.WriteLine(E.Message);
            }

            Result = Res;
        }

        static bool IsPerfectNumber(int Number)
        {
            if (Number < 2)
                return false;

            int divisorsSum = 1;

            for (int i = 2; i <= MathF.Sqrt(Number); i++)
            {
                if (Number % i == 0)
                {
                    divisorsSum += i;
                    if (i != Number / i)
                        divisorsSum += Number / i;
                }
            }

            return divisorsSum == Number;
        }

        static List<int> FindPerfectNumbersInRange(int start, int end)
        {
            List<int> perfectNumbers = new List<int>();
            for (int num = start; num <= end; num++)
            {
                if (IsPerfectNumber(num))
                    perfectNumbers.Add(num);
            }
            return perfectNumbers;
        }

        static bool IsLuckyNumber(int number)
        {
            try
            {
                if (number < 100000 || number > 999999)
                    throw new Exception("Number must be six digit");

                int firstHalfSum = 0;
                int secondHalfSum = 0;

                for (int i = 0; i < 3; i++)
                {
                    firstHalfSum += number / (int)Math.Pow(10, 5 - i) % 10;
                    secondHalfSum += number / (int)Math.Pow(10, 2 - i) % 10;
                }

                return firstHalfSum == secondHalfSum;
            }
            catch (Exception E)
            {

                Console.WriteLine("Lucky Number check: {0}",E.Message);
            }
            return false;
        }


        static (int,int) GetInfo()
        {
            try
            {
                Console.Write(">");
                string? inp1 = Console.ReadLine();
                Console.Write(">");
                string? inp2 = Console.ReadLine();

                int Number1 = Convert.ToInt32(inp1);
                int Number2 = Convert.ToInt32(inp2);

                return (Number1,Number2);
            }
            catch (Exception E)
            {
                Console.WriteLine($"GetInfo: {E.Message}");
            }
            return (0,0);
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Start");
                //---------------------------------------------------------------------------------

                Console.WriteLine("In Power Of (1)-> A (2)-> N");
                (int, int) Stats = GetInfo();
                float Pow = Power(Stats.Item1, Stats.Item2);
                Console.WriteLine(" {0} in Power of {1} is: {2}", Stats.Item1, Stats.Item2, Pow);

                //---------------------------------------------------------------------------------

                Console.WriteLine("Sum in range of numbers");
                (int, int) Stats2 = GetInfo();
                SumOfDP(Stats2.Item1, Stats2.Item2, out int Result);
                Console.WriteLine(Result);

                //---------------------------------------------------------------------------------

                Console.WriteLine("'perfect' number in range");
                (int, int) Stats3 = GetInfo();
                List<int> perfectNumbers = FindPerfectNumbersInRange(Stats3.Item1, Stats3.Item2);
                foreach (var Number in perfectNumbers)
                {
                    Console.Write("{0}\t", Number);
                }
                Console.WriteLine(" ");

                //---------------------------------------------------------------------------------

                Console.WriteLine("Pick a card 1-14");
                Console.Write(">");
                string? inp1 = Console.ReadLine();
                if (inp1 != null)
                {
                    int Number1 = Convert.ToInt32(inp1);
                    Number1 = Math.Clamp(Number1, 1, 14);
                    List<Card> Cards = GetCards();

                    Card CurentCard = Cards[Number1-1];
                    CurentCard.Draw();
                }

                //---------------------------------------------------------------------------------

                Console.WriteLine("Write a number (Six digit)");
                Console.Write(">");
                string? inp2 = Console.ReadLine();
                if (inp1 != null)
                {
                    int Number2 = Convert.ToInt32(inp2);
                    Console.WriteLine("Number is lucky: " + IsLuckyNumber(Number2));
                }


                Console.WriteLine("End");
            }
        }
       
    }
}



