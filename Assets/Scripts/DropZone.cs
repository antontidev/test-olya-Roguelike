using System;
using System.Collections.Generic;
using DG.Tweening;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private System.Random _random;
    
    public GameController gameController;
    public CardController cardController;

    private int _countAddCards;
    private GameObject _card;
    
    private int _countOfMoves;
    public TextMeshProUGUI countOfMovesText;

    private bool _moveOfEnemy;
    public TextMeshProUGUI whoseMove;

    private CardView _lastCardView;
    private List<CardStats> _currentCards;

    private void Awake() {
        _random = new System.Random();
        _currentCards = new List<CardStats>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        _card = eventData.pointerDrag;
        if (!_card.GetComponent<DragDrop>()) return;
        
        HeroAddCardToMove();

        if (Enemy.EnemyIsDie)
        {
            SetCountOfMoves(0);
            СardDistribution();
            Enemy.EnemyIsDie = false;
        }
        _countAddCards = cardController.GetComponentsInChildren<CardView>().Length;
        if (_countOfMoves < 3 && _countAddCards > 0) return;

        DoCurrentUnitMove(() => {
            SwitchMove(); //начало хода врага
            СardDistribution();
            EnemyMove();
            
            DoCurrentUnitMove(() => {
                SwitchMove(); //конец хода врага и начало хода героя
                СardDistribution();
            });
        });
    }

    private void DoCurrentUnitMove(Action callback = null) {
        var sequence = DOTween.Sequence();
        ActiveCards(false);
        float cardDelay = 1f;
        for (int i = 0; i < _currentCards.Count; i++) {
            var card = _currentCards[i];
                sequence.AppendCallback(() => {
                    if (_lastCardView != null) cardController.ReleaseCardView(_lastCardView);

                    _lastCardView = cardController.GetAndFillCardView(card);
                    _lastCardView.transform.SetParent(transform);

                    gameController.CurrentMoveCharacter.CardMove(_lastCardView);
                }).AppendInterval(cardDelay);
        }

        _currentCards.Clear();

        sequence.AppendCallback(() => {
            callback?.Invoke();
            
            cardController.ReleaseCardView(_lastCardView);
            ActiveCards(true);
        });
    }

    private void HeroAddCardToMove()
    {
        _card.GetComponent<DragDrop>().defaultParent = transform;

        var cardComponent = _card.GetComponent<CardView>();
        
        _currentCards.Add(cardComponent.CardStat);
        
        SetCountOfMoves(_countOfMoves + 1);

        gameController.hero.RemoveCardFromHand(cardComponent.CardStat);
    }
    
    private void EnemyMove()
    {
        for (var i = 0; i < 3; i++)
            EnemyAddCardToMove();
    }

    private void EnemyAddCardToMove()
    {
        var numRandomStat = _random.Next(gameController.enemy.GetHandCount());

        var cardStats = gameController.enemy.GetAndRemoveCardFromHand(numRandomStat);

        SetCountOfMoves(_countOfMoves + 1);
        
        _currentCards.Add(cardStats);
    }

    private void СardDistribution()
    {
        if (!_moveOfEnemy)
        {
            _countAddCards = cardController.GetComponentsInChildren<CardView>().Length;
            if (_countAddCards < 6)
                gameController.hero.SetCardsInHand(6 - _countAddCards);
        }
        else
        {
            _countAddCards = gameController.enemy.GetHandCount();
            if (_countAddCards < 6)
                gameController.enemy.SetCardsInHand(6 - _countAddCards);
        }
    }
    
    private void ActiveCards(bool activeMove)
    {
        foreach (var dragDrop in cardController.GetComponentsInChildren<DragDrop>())
            dragDrop.enabled = activeMove;
    }
    
    private void SwitchMove()
    {
        if (_moveOfEnemy)
        {
            whoseMove.text = "Ваш ход";
            gameController.CurrentMoveCharacter = gameController.hero;
            _moveOfEnemy = false;
        }
        else
        {
            whoseMove.text = "Ход врага";
            gameController.CurrentMoveCharacter = gameController.enemy;
            _moveOfEnemy = true;
        }
        SetCountOfMoves(0);
    }
    
    private void SetCountOfMoves(int countOfMoves)
    {
        _countOfMoves = countOfMoves;
        countOfMovesText.text = _countOfMoves + "/3";
    }
}