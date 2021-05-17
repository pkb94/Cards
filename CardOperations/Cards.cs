using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardOperations
{
    /// <summary>
    /// Cards class implementing all the operations for the deck of cards
    /// We can have multiple cards class, implementing different count of cards
    /// </summary>
    public class Cards : ICards
    {
        public Cards()
        {
            ConstructCardsList();
        }

        private List<Card> DeckOfCards = new List<Card>();
        private int _topCard = 0;

        /// <summary>
        /// Constructing all the cards in a pack
        /// This method constructs all the cards of each number and each type in pack of cards
        /// </summary>
        private void ConstructCardsList()
        {
            for (int i = 0; i < 13; i++)
            {
                //this will construct card object for each number one by one
                //for ex. 1 will be constructed first for each type, like 1 club, 1 heart, 1 spade, 1 diamond and then 2 club .... etc in that order
                for (int j = 0; j < 4; j++)
                {
                    Card c = new Card();
                    CardType ct = (CardType)j;
                    c.id = String.Format("{0}{1}", i, ct.ToString());
                    c.num = i;
                    c.cardType = ct;
                    DeckOfCards.Add(c);
                }
            }
        }

        /// <summary>
        /// Index of TopCard
        /// </summary>
        public int TopCard
        {
            get { return _topCard; }
            set { _topCard = value; }
        }

        /// <summary>
        /// Get the number of cards from the top card
        /// </summary>
        /// <param name="numberOfCards"></param>
        /// <returns></returns>
        public List<Card> GetCards(int numberOfCards)
        {
            if (numberOfCards > DeckOfCards.Count)
                return null;
            List<Card> res = new List<Card>();

            for (int i = 0; i < numberOfCards; i++)
            {
                res.Add(DeckOfCards[TopCard + i]);
            }
            return res;
        }

        /// <summary>
        /// Shuffle cards using random class
        /// </summary>
        /// <returns></returns>
        public bool ShuffleCards()
        {
            Random r = new Random();
            TopCard = r.Next(0, DeckOfCards.Count);
            return true;
        }

        /// <summary>
        /// Get top card
        /// </summary>
        /// <returns></returns>
        public Card GetTopCard()
        {
            return DeckOfCards[TopCard];
        }

        /// <summary>
        /// Check if card exists or not
        /// </summary>
        /// <param name="num"></param>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public bool CheckCardExists(int num, CardType cardType)
        {
            string k = string.Format("{0}{1}", num, cardType.ToString());
            for (int i = 0; i < DeckOfCards.Count; i++)
            {
                if (DeckOfCards[i].id == k)
                    return true;
            }
            return false;
        }
    }
}
