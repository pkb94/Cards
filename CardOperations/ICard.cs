using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardOperations
{
    public interface ICards
    {
        //Get the nmber of cards given as input to this method, get the number of cards from the top
        List<Card> GetCards(int numberOfCards);

        //Index of the card in the list, which is at the top
        int TopCard { get; set; }

        //Suffle cards, just get the random number within number of cards given
        bool ShuffleCards();

        //Return the card object pointed by the TopCard index
        Card GetTopCard();

        //Check if card exists
        bool CheckCardExists(int num, CardType cardType);
    }
}
