using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Character Character;

    private GameObject _card;

    private bool _enemiesDiy;
    
    public void Initialize(Character enemy)
    {
        Character = enemy;
        _enemiesDiy = true;
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        _card = eventData.pointerDrag;
        if (!_card.GetComponent<DragDrop>()) return;
        
        Character.BattleController.MoveController.CardMoveHero(_card, this);
        //
        // foreach (var enemy in Character.BattleController.Enemy)
        //     if (enemy is Enemy && !enemy.Died)
        //         _enemiesDiy = false; 
        if (Character.BattleController.Enemy.Count == 0) Character.BattleController.MoveController.EnemyIsDie();
        
        if (Character.BattleController.MoveView.GetCountOfMove() < 3) return;
        
        Character.BattleController.MoveController.NextMove();//ход врага
    }
}