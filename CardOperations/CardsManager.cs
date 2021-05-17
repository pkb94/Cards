using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardOperations
{
    /// <summary>
    /// Cards Manager class is generic type class using which we can do operations defined in ICards interface
    /// Any class implementing ICards interface can be passed by creating new object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CardsManager<T> where T : ICards
    {
        private T crd;

        public CardsManager(T card)
        {
            this.crd = card;
        }

        public List<Card> GetCards(int numberOfCards)
        {
            return crd.GetCards(numberOfCards);
        }

        public int TopCard
        {
            get { return crd.TopCard; }
        }

        public bool ShuffleCards()
        {
            return crd.ShuffleCards();
        }

        public Card GetTopCard()
        {
            return crd.GetTopCard();
        }

        public bool CheckCardExists(int num, CardType cardType)
        {
            return crd.CheckCardExists(num, cardType);
        }
    }
}
