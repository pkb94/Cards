using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardOperations
{
    /// <summary>
    /// Enum type for the type of card
    /// </summary>
    public enum CardType
    {
        Spade = 0,
        Club = 1,
        Heart = 2,
        Diamond = 3
    }

    /// <summary>
    /// Card object , this represents card object
    /// </summary>
    public class Card
    {
        //Construct id as combination of num + cardType
        public string id;

        //Number for the card, for displaying A, J, Q, K use special handling to convert this to correct alphabets
        public int num;

        //Type of card
        public CardType cardType;
    }
}
