using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services
{
    public class MoveController : MonoBehaviour
    {
        private System.Random _random;
        
        private int _countCardInHand;

        private Character CurrentMoveCharacter;

        private CardView _cardViewEnemy;

        public MoveView MoveView;
        public CameraBlendService CameraBlendService;
        
        [FormerlySerializedAs("ButtleController")] [FormerlySerializedAs("GameController")] public BattleController BattleController;
        public CardController CardController;
        
        private void Awake() {
            _random = new System.Random();
        }

        public void NextMove()
        {
            MoveView.SwitchMove();
            CurrentMoveCharacter = BattleController.CurrentMoveCharacter;
            if (CurrentMoveCharacter is Enemy) MoveEnemy();
            else MoveHero();
        }
        
        private void MoveHero()
        {
            var sequence = DOTween.Sequence();

            sequence.AppendCallback(() =>
                {
                    CameraBlendService
                        .StartSequence()
                        .AppendHeroSwitch()
                        .AppendMainSwitch();
                })
                .AppendInterval(3)
                .AppendCallback(() =>
                {
                    СardDistribution();
                    ActiveCards(true);
                });
        }
        
        public void CardMoveHero(GameObject card)
        {
            card.GetComponent<DragDrop>().defaultParent = transform;
            var cardView = card.GetComponent<CardView>();
            CardMove(cardView);
            MoveView.AddCountOfMoves();
            CurrentMoveCharacter.GetAndRemoveCardFromHand(cardView.CardIndex);
        }
        
        private void MoveEnemy()
        {
            ActiveCards(false);
            СardDistribution();
            
            var sequence = DOTween.Sequence();

            sequence.AppendCallback(() =>
            {
                CameraBlendService
                    .StartSequence()
                    .AppendEnemySwitch()
                    .AppendMainSwitch();
            })
                .AppendInterval(2);
            
            for (int i = 0; i < 3; i++)
            {
                sequence
                    .AppendInterval(1)
                    .AppendCallback(CardMoveEnemy)
                    .AppendInterval(1);
            }

            sequence.AppendCallback(NextMove);
        }

        private void CardMoveEnemy()
        {
            var numRandomCard = _random.Next(CurrentMoveCharacter.GetCountCardsInHand());

            var cardStats = CurrentMoveCharacter.GetAndRemoveCardFromHand(numRandomCard);

            _cardViewEnemy = CardController.GetAndFillCardView(cardStats);
            _cardViewEnemy.transform.SetParent(transform);
        
            CardMove(_cardViewEnemy);
            MoveView.AddCountOfMoves();

            var sequence = DOTween.Sequence();

            sequence.AppendInterval(1)
                .AppendCallback(() =>
                {
                    CardController.ReleaseCardView(_cardViewEnemy);
                });
        }
        
        private void СardDistribution()
        {
            _countCardInHand = CurrentMoveCharacter.GetCountCardsInHand();
            CurrentMoveCharacter.AddCardsToHand(6 - _countCardInHand);
        }

        private void CardMove(CardView cardView)
        {
            var cardStats = cardView.CardStat;
            CurrentMoveCharacter = BattleController.CurrentMoveCharacter;
            if (cardStats.Damage != 0)
                CurrentMoveCharacter.MakeDamage(cardStats.Damage);
            if (cardStats.Heal != 0)
                CurrentMoveCharacter.AddHealth(cardStats.Heal);
            if (cardStats.Defense != 0)
                CurrentMoveCharacter.AddDefense(cardStats.Defense);
            if (cardStats.CountAddCards != 0)
                CurrentMoveCharacter.AddCardsToHand(cardStats.CountAddCards);
        }

        public void EnemyIsDie()
        {
            MoveView.SetToZeroCountOfMove();
            СardDistribution();
            BattleController.enemy.Died = false;
        }

        private void ActiveCards(bool activeMove)
        {
            CardController.CardsRootCanvasGroup.blocksRaycasts = activeMove;

            float fadeValue;
            if (activeMove)
            {
                fadeValue = 1;
            }
            else
            {
                fadeValue = 0.5f;
            }

            CardController.CardsRootCanvasGroup.DOFade(fadeValue, 0.3f);
        }
    }
}