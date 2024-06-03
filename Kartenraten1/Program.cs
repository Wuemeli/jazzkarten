using System;

class Program
{
    static void Main(string[] args)
    {
        string[] cards = { "Herz", "Schaufel", "Kreuz", "Ecken" };
        string[,] deck = new string[4, 5];

        Random rand = new Random();
        int cardcount = 0;
        foreach (string card in cards)
        {
            for (int i = 0; i < 5; i++)
            {
                int column = rand.Next(4);
                int row = rand.Next(deck.GetLength(1));
                if (deck[column, row] == null)
                {
                    deck[column, row] = card;
                    cardcount++;
                    if (cardcount >= 20) break;
                }
            }
        }

        Console.WriteLine("First Round:");
        for (int col = 0; col < deck.GetLength(0); col++)
        {
            Console.Write($"Column {col + 1}: ");
            for (int row = 0; row < deck.GetLength(1); row++)
            {
                Console.Write($"{deck[col, row]} ");
            }
            Console.WriteLine();
        }
        Console.Write("Which column does your card belong to? ");
        int firstchoice = Convert.ToInt32(Console.ReadLine()) - 1;

        string[,] newdist = new string[5, 4];
        int newIndex = 0;
        for (int row = 0; row < deck.GetLength(1); row++)
        {
            newdist[newIndex / 4, newIndex % 4] = deck[firstchoice, row];
            newIndex++;
        }
        Console.WriteLine("Second Round:");
        for (int col = 0; col < newdist.GetLength(0); col++)
        {
            Console.Write($"Column {col + 1}: ");
            for (int row = 0; row < newdist.GetLength(1); row++)
            {
                Console.Write($"{newdist[col, row]} ");
            }
            Console.WriteLine();
        }
        Console.Write("Which column does your card now belong to? ");
        int secondchoice = Convert.ToInt32(Console.ReadLine()) - 1;

        string secondcard = newdist[secondchoice, 0];
        Console.WriteLine($"The searched card was: {secondcard}");
    }
}
