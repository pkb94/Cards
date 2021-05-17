using CardOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            //You can pass any class which implements ICards interface
            //In our case, we are passing Cards class, which implements ICards interface
            //For MVC use the below statement to create the object
            CardsManager<CardOperations.Cards> crdManager = new CardsManager<CardOperations.Cards>(new CardOperations.Cards());

            //Method to check if card exists
            bool isCardPresent = crdManager.CheckCardExists(3, CardType.Club);
            if(isCardPresent)
            {
                Console.WriteLine("Card is present");
            }
            else
            {
                Console.WriteLine("Card not present");
            }

            int topCard = crdManager.TopCard;

            bool isShuffleSuccessful = crdManager.ShuffleCards();

            Card topCrdAfterShuffle = crdManager.GetTopCard();

            var cards = crdManager.GetCards(5);
        }
    }
}
