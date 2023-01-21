using System;
using System.Collections.Generic;
using DG.Tweening;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private static readonly System.Random Random = new();
    
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

        var sequence = DOTween.Sequence();
        
        ActiveCards(false);
        float cardDelay = 1f;
        for (int i = 0; i < _currentCards.Count; i++) {
            var card = _currentCards[i];
            sequence.AppendInterval(cardDelay * i)
                .AppendCallback(() => {
                    if (_lastCardView != null) cardController.ReleaseCardView(_lastCardView);
                    
                    _lastCardView = cardController.GetAndFillCardView(card);
                    _lastCardView.transform.SetParent(transform);
                    
                    gameController.hero.CardMove(_lastCardView);
                });
        }
        
        _currentCards.Clear();
        
        sequence.AppendCallback(() => {
            ActiveCards(true);
            SwitchMove(); //начало хода врага
            СardDistribution();
            EnemyMove();

            SwitchMove(); //конец хода врага и начало хода героя
            СardDistribution();
            
            cardController.ReleaseCardView(_lastCardView);
        });
    }

    private void HeroAddCardToMove()
    {
        _card.GetComponent<DragDrop>().defaultParent = transform;

        var cardComponent = _card.GetComponent<CardView>();
        
        _currentCards.Add(cardComponent.CardStat);
        
        SetCountOfMoves(_countOfMoves + 1);
            
        cardController.ReleaseCardView(cardComponent);
    }
    
    private void EnemyMove()
    {
        ActiveCards(false);
        for (var i = 0; i < 3; i++)
            EnemyCardMove();
        ActiveCards(true);
    }

    private void EnemyCardMove()
    {
        if (gameController.enemy.CardsInHand.Count <= 0)
            return;
        
        var numRandomStat = Random.Next(gameController.enemy.CardsInHand.Count);
        
        var cardStats = gameController.enemy.CardsInHand[numRandomStat];
        gameController.enemy.CardsInHand.RemoveAt(numRandomStat);

        var card = cardController.GetAndFillCardView(cardStats);

        gameController.enemy.CardMove(card);
        SetCountOfMoves(_countOfMoves + 1);
        
        cardController.ReleaseCardView(card);
    }

    private void СardDistribution()
    {
        if (_moveOfEnemy)
        {
            _countAddCards = cardController.GetComponentsInChildren<CardView>().Length;
            if (_countAddCards < 6)
                cardController.SetCardsInHandHero(6 - _countAddCards);
        }
        else
        {
            _countAddCards = gameController.enemy.CardsInHand.Count;
            if (_countAddCards < 6)
                cardController.SetCardsInHandEnemy(6 - _countAddCards, gameController.enemy.CardsInHand);
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
            whoseMove.text = "Ход врага";
            _moveOfEnemy = false;
        }
        else
        {
            whoseMove.text = "Ваш ход";
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