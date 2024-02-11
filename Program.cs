using System;
using System.Collections.Generic;

class Program
{
    private static readonly Random random = new Random();
    static Card RandomCard()
    {
        return new Card((Values)random.Next(1, 14), (Suits)random.Next(4));
    }
    static void PrintCards(List<Card> cards)
    {
        foreach (Card card in cards)
        {
            Console.WriteLine(card.Name);
        }
    }


    static void Main(string[] args)
    {
        List<Card> cards = new List<Card>();
        Console.WriteLine("Enter number of cards: ");
        if (int.TryParse(Console.ReadLine(), out int numberOfCards))
            for(int i = 0; i < numberOfCards; i++)
                cards.Add(RandomCard());

        PrintCards(cards);

        cards.Sort(new CardComparerByValue());
        Console.WriteLine("\n... sorting the cards ...\n");

        PrintCards(cards);
    }
}

class CardComparerByValue : IComparer<Card>
{
    public int Compare(Card x, Card y)
    {
        if (x.Suit > y.Suit)
            return 1;
        if (x.Suit < y.Suit)
            return -1;
        if (x.Value > y.Value)
            return 1;
        if (x.Value < y.Value)
            return -1;
        return 0;

    }
}
enum Suits
{
    Diamonds,
    Clubs,
    Hearts,
    Spades,
}
enum Values
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
}
class Card
{
    public Values Value  { get; private set; }
    public Suits Suit { get; private set; }
    public string Name { get { return $"{Value} of {Suit}"; } }

    public Card(Values value, Suits suit)
    {
        this.Suit = suit;
        this.Value = value;
    }
}


