using System.Collections.Generic;
using UnityEngine;

namespace Services {
    public class CardController : MonoBehaviour
    {
        private static readonly System.Random Random = new();

        public GameObject cardPrefab;

        public void SetCardsInHandHero(int countAddCards)
        {
            for (var i = 0; i < countAddCards; i++)
                Instantiate(cardPrefab, transform, false).GetComponent<Card>().ShowRandomCard();
        }

        public void SetCardsInHandEnemy(int countAddCards, List<CardStats> cards)
        {
            for (var i = 0; i < countAddCards; i++)
            {
                var card = RandomSelection();
                cards.Add(card);
            }
        }
    
        public static CardStats RandomSelection()
        {
            var card = CardMap.Cards[Random.Next(CardMap.Cards.Count)];
            return card;
        }
    }
}
