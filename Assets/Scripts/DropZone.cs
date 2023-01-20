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

    private bool _moveOfHero = true;
    public TextMeshProUGUI whoseMove;

    
    public void OnDrop(PointerEventData eventData)
    {
        _card = eventData.pointerDrag;
        if (!_card.GetComponent<DragDrop>()) return;
        
        HeroMove();

        if (Enemy.EnemyIsDie)
        {
            SetCountOfMoves(0);
            СardDistribution();
            Enemy.EnemyIsDie = false;
        }
        _countAddCards = cardController.GetComponentsInChildren<Card>().Length;
        if (_countOfMoves < 3 && _countAddCards > 0) return;
        
        SwitchMove(); //начало хода врага
        СardDistribution();
        EnemyMove();
        
        SwitchMove(); //конец хода врага и начало хода героя
        СardDistribution();
    }

    private void HeroMove()
    {
        ActiveCards(false);
        _card.GetComponent<DragDrop>().defaultParent = transform;
        
        gameController.hero.CardMove(_card.GetComponent<Card>());
        SetCountOfMoves(_countOfMoves + 1);
            
        Destroy(_card);
        ActiveCards(true);
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
        
        var cardGameObject = Instantiate(cardController.cardPrefab, transform, false);
        var card = cardGameObject.GetComponent<Card>();
        card.ShowCard(cardStats);

        gameController.enemy.CardMove(card);
        SetCountOfMoves(_countOfMoves + 1);
        
        Destroy(cardGameObject);
    }

    
    private void СardDistribution()
    {
        if (_moveOfHero)
        {
            _countAddCards = cardController.GetComponentsInChildren<Card>().Length;
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
        if (_moveOfHero)
        {
            whoseMove.text = "Ход врага";
            _moveOfHero = false;
        }
        else
        {
            whoseMove.text = "Ваш ход";
            _moveOfHero = true;
        }
        SetCountOfMoves(0);
    }
    private void SetCountOfMoves(int countOfMoves)
    {
        _countOfMoves = countOfMoves;
        countOfMovesText.text = _countOfMoves + "/3";
    }

}