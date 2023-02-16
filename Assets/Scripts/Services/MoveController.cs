using DG.Tweening;
using UnityEngine;

namespace Services
{
    public class MoveController : MonoBehaviour
    {
        private System.Random _random;
        
        private int _countCardInHand;

        // private Character CurrentMoveCharacter;

        private CardView _cardViewEnemy;

        public BattleController BattleController;
        
        private void Awake() {
            _random = new System.Random();
        }

        public void NextMove()
        {
            BattleController.MoveView.SwitchMove();
            // CurrentMoveCharacter = BattleController.CurrentMoveCharacter;
            if (BattleController.CurrentMoveCharacter is Enemy) MoveEnemy();
            else MoveHero();
        }
        
        private void MoveHero()
        {
            var sequence = DOTween.Sequence();

            sequence.AppendCallback(() =>
                {
                    BattleController.CameraBlendService
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
        
        public void CardMoveHero(GameObject card, DropZone dropZone)
        {
            card.GetComponent<DragDrop>().defaultParent = dropZone.transform;
            var cardView = card.GetComponent<CardView>();
            
            CardMove(cardView.CardStat, dropZone.Character);
            
            BattleController.MoveView.AddCountOfMoves();
            BattleController.CurrentMoveCharacter.GetAndRemoveCardFromHand(cardView.CardIndex);
        }
        
        private void MoveEnemy()
        {
            ActiveCards(false);
            СardDistribution();
            
            var sequence = DOTween.Sequence();

            sequence.AppendCallback(() =>
            {
                BattleController.CameraBlendService
                    .StartSequence()
                    .AppendEnemySwitch()
                    .AppendMainSwitch();
            })
                .AppendInterval(2);
            
            for (var i = 0; i < 3; i++)
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
            var numRandomCard = _random.Next(BattleController.CurrentMoveCharacter.GetCountCardsInHand());

            var cardStats = BattleController.CurrentMoveCharacter.GetAndRemoveCardFromHand(numRandomCard);

            _cardViewEnemy = BattleController.CardController.GetAndFillCardView(cardStats);
            _cardViewEnemy.transform.SetParent(transform);

            CardMove(_cardViewEnemy.CardStat,
                _cardViewEnemy.CardStat.Damage != 0 ? BattleController.Hero : BattleController.CurrentMoveCharacter);
            BattleController.MoveView.AddCountOfMoves();

            var sequence = DOTween.Sequence();

            sequence.AppendInterval(1)
                .AppendCallback(() =>
                {
                    BattleController.CardController.ReleaseCardView(_cardViewEnemy);
                });
        }
        
        private void СardDistribution()
        {
            _countCardInHand = BattleController.CurrentMoveCharacter.GetCountCardsInHand();
            BattleController.CurrentMoveCharacter.AddCardsToHand(6 - _countCardInHand);
        }

        private void CardMove(CardStats cardStats, Character character)
        {
            // CurrentMoveCharacter = BattleController.CurrentMoveCharacter;
            if (cardStats.Damage != 0)
                character.GetDamage(cardStats.Damage);
            if (cardStats.Heal != 0)
                character.AddHealth(cardStats.Heal);
            if (cardStats.Defense != 0)
                character.AddDefense(cardStats.Defense);
            if (cardStats.CountAddCards != 0)
                character.AddCardsToHand(cardStats.CountAddCards);
        }

        public void EnemyIsDie()
        {
            BattleController.MoveView.SetToZeroCountOfMove();
            СardDistribution();
            BattleController.Enemy[0].Died = false;
        }

        private void ActiveCards(bool activeMove)
        {
            BattleController.CardController.CardsRootCanvasGroup.blocksRaycasts = activeMove;

            float fadeValue;
            if (activeMove)
            {
                fadeValue = 1;
            }
            else
            {
                fadeValue = 0.5f;
            }

            BattleController.CardController.CardsRootCanvasGroup.DOFade(fadeValue, 0.3f);
        }
    }
}