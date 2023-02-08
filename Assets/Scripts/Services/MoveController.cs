using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Services
{
    public class MoveController : MonoBehaviour
    {
        private System.Random _random;
        
        private int _countCardInHand;
        // private GameObject _card;

        private Character CurrentMoveCharacter;
        
        private List<CardStats> _currentCards;

        public MoveView MoveView;
        public CameraBlendService CameraBlendService;
        
        public GameController GameController;
        public CardController CardController;
        
        private void Awake() {
            _random = new System.Random();
            _currentCards = new List<CardStats>();
        }
        
        public void CardMoveHero(GameObject card)
        {
            card.GetComponent<DragDrop>().defaultParent = transform;

            var cardView = card.GetComponent<CardView>();
            CardMove(cardView);
        }

        public void NextMove()
        {
            MoveView.SwitchMove();
            CurrentMoveCharacter = GameController.CurrentMoveCharacter;
            if (CurrentMoveCharacter is Enemy) MoveEnemy();
            else MoveHero();
        }
        
        private void MoveHero()
        {
            ActiveCards(true);
            
            CameraBlendService
                .StartSequence()
                .AppendHeroSwitch()
                .AppendMainSwitch();
            
            СardDistribution();
        }
        
        private void MoveEnemy()
        {
            ActiveCards(false);
            
            CameraBlendService
                .StartSequence()
                .AppendEnemySwitch()
                .AppendMainSwitch();
            
            СardDistribution();
            
            for (var i = 0; i < 3; i++)
                EnemyAddCardToMove();
        }

        // private void EnemyCardMove()
        // {
        //     var sequence = DOTween.Sequence();
        //     float cardDelay = 1f;
        //     for (int i = 0; i < _currentCards.Count; i++) {
        //         var card = _currentCards[i];
        //         sequence.AppendCallback(() => {
        //             if (_lastCardView != null) cardController.ReleaseCardView(_lastCardView);
        //
        //             _lastCardView = cardController.GetAndFillCardView(card);
        //             _lastCardView.transform.SetParent(transform);
        //
        //             MoveController.CardMove(_lastCardView.CardStat);
        //         }).AppendInterval(cardDelay);
        //     }
        //
        //     _currentCards.Clear();
        //
        //     sequence.AppendCallback(() => {
        //         callback?.Invoke();
        //     
        //         cardController.ReleaseCardView(_lastCardView);
        //         MoveController.ActiveCards(true);
        //     });
        // }
        
        private void EnemyAddCardToMove()
        {
            var numRandomCard = _random.Next(GameController.enemy.GetHandCount());

            var cardStats = GameController.enemy.GetAndRemoveCardFromHand(numRandomCard);

            MoveView.AddCountOfMoves();
        
            _currentCards.Add(cardStats);
        }
        
        private void СardDistribution()
        {
            _countCardInHand = GameController.CurrentMoveCharacter.GetHandCount();
            if (_countCardInHand < 6)
                GameController.CurrentMoveCharacter.SetCardsInHand(6 - _countCardInHand);
        }

        private void CardMove(CardView cardView)
        {
            var cardStats = cardView.CardStat;
            CurrentMoveCharacter = GameController.CurrentMoveCharacter;
            if (cardStats.Damage != 0)
                CurrentMoveCharacter.MakeDamage(cardStats.Damage);
            if (cardStats.Heal != 0)
                CurrentMoveCharacter.AddHealth(cardStats.Heal);
            if (cardStats.Defense != 0)
                CurrentMoveCharacter.AddDefense(cardStats.Defense);
            if (cardStats.CountAddCards != 0)
                CurrentMoveCharacter.CardsHand.AddCardsToHand(cardStats.CountAddCards);
            CurrentMoveCharacter.CardsHand.GetAndRemove(cardView.CardIndex);
            
            MoveView.AddCountOfMoves();
        }

        public void EnemyIsDie()
        {
            MoveView.SetToZeroCountOfMove();
            СardDistribution();
            Enemy.EnemyIsDie = false;
        }

        private void ActiveCards(bool activeMove)
        {
            foreach (var dragDrop in CardController.GetComponentsInChildren<DragDrop>())
                dragDrop.enabled = activeMove;
        }
    }
}