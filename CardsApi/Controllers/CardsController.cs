using CardOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CardsApi.Controllers
{
    public class CardsController : ApiController
    {
        CardsManager<CardOperations.Cards> crdManager = null;

        public CardsController()
        {
            crdManager = new CardsManager<CardOperations.Cards>(new CardOperations.Cards());
        }

        [HttpGet]
        [Route("api/Cards/{count}")] //URL to run .... append after localhost = /api/cards/TopCard (Ex. http://localhost:59471/api/cards/5 )
        public IEnumerable<Card> GetCards(int count)
        {
            return crdManager.GetCards(count);
        }

        [HttpGet]
        [Route("api/Cards/TopCard")] //URL to run .... append after localhost = /api/cards/TopCard (Ex. http://localhost:59471/api/cards/topcard )
        public Card GetTopCard()
        {
            return crdManager.GetTopCard();
        }

        [HttpGet]
        [Route("api/Cards/TopCardIndex")] //URL to run .... append after localhost = /api/cards/TopCard (Ex. http://localhost:59471/api/cards/topcardindex )
        public int GetTopCardIndex()
        {
            return crdManager.TopCard;
        }

        [HttpGet]
        [Route("api/Cards/CardExists/{num}/{type}")] //URL to run .... append after localhost = /api/cards/TopCard (Ex. http://localhost:59471/api/cards/cardexists/2/spade )
        public bool CheckCardExists(int num, string type)
        {
            CardType cardType;
            Enum.TryParse("Active", out cardType);
            return crdManager.CheckCardExists(num, cardType);
        }

        [HttpGet]
        [Route("api/Cards/ShuffleCards")] //URL to run .... append after localhost = /api/cards/TopCard (Ex. http://localhost:59471/api/cards/ShuffleCards )
        public bool ShuffleCards()
        {
            return crdManager.ShuffleCards();
        }
    }
}
