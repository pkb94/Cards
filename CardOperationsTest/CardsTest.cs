using System;
using System.Collections.Generic;
using CardOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CardOperationsTest
{
    /// <summary>
    /// We are using MSTest to test the CardsTest class
    /// </summary>
    [TestClass]
    public class CardsTest
    {
        //Mocking the cards object
        Moq.Mock<ICards> mockICards = new Moq.Mock<ICards>();

        /// <summary>
        /// Test to check initial value of TopCard index property
        /// </summary>
        [TestMethod]
        public void TestInitialTopCardIndex()
        {
            mockICards.Setup(m => m.TopCard).Returns(0);
            ICards crds = mockICards.Object;
            Assert.AreEqual(crds.TopCard, 0);
        }

        /// <summary>
        /// Test to check if card is present
        /// </summary>
        [TestMethod]
        public void TestCardExists()
        {
            mockICards.Setup(m => m.CheckCardExists(It.IsAny<int>(),It.IsAny<CardType>())).Returns(true);
            ICards crds = mockICards.Object;
            Assert.IsTrue(crds.CheckCardExists(3, CardType.Diamond));
        }

        /// <summary>
        /// Test to check if card is not present
        /// </summary>
        [TestMethod]
        public void TestCardNotExists()
        {
            mockICards.Setup(m => m.CheckCardExists(It.IsAny<int>(), It.IsAny<CardType>())).Returns(false);
            ICards crds = mockICards.Object;
            Assert.IsFalse(crds.CheckCardExists(4, CardType.Club));
        }

        /// <summary>
        /// Test to shuffle cards on success
        /// </summary>
        [TestMethod]
        public void TestCardsShuffleSuccess()
        {
            mockICards.Setup(m => m.ShuffleCards()).Returns(true);
            ICards crds = mockICards.Object;
            Assert.IsTrue(crds.ShuffleCards());
        }

        /// <summary>
        /// Test to shuffle cards on success
        /// </summary>
        [TestMethod]
        public void TestCardsShuffleFailure()
        {
            mockICards.Setup(m => m.ShuffleCards()).Returns(false);
            ICards crds = mockICards.Object;
            Assert.IsFalse(crds.ShuffleCards());
        }

        /// <summary>
        /// Test to get top card
        /// </summary>
        [TestMethod]
        public void TestGetTopCard()
        {
            var crd = new Card() { cardType = CardType.Spade, id = "2Spade", num = 2 };
            mockICards.Setup(m => m.GetTopCard()).Returns(crd);
            ICards crds = mockICards.Object;
            Assert.AreEqual(crd, crds.GetTopCard());
        }

        /// <summary>
        /// Test to get number of cards
        /// </summary>
        [TestMethod]
        public void TestGetCards()
        {
            var crdsLst = new List<Card>() {
                new Card() { cardType = CardType.Spade, id = "2Spade", num = 2 },
                new Card() { cardType = CardType.Heart, id = "7Heart", num = 7 },
                new Card() { cardType = CardType.Club, id = "8Club", num = 8 },
                new Card() { cardType = CardType.Diamond, id = "5Diamond", num = 5 }};


            mockICards.Setup(m => m.GetCards(It.IsAny<int>())).Returns(crdsLst);
            ICards crds = mockICards.Object;
            var lstCards = crds.GetCards(4);
            Assert.IsNotNull(lstCards);
            Assert.AreEqual(lstCards.Count, 4);
        }
    }
}
