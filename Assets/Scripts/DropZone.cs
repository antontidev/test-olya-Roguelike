using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Character Character;

    private GameObject _card;
    
    public void Initialize(Character enemy)
    {
        Character = enemy;
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        _card = eventData.pointerDrag;
        if (!_card.GetComponent<DragDrop>()) return;
        
        Character.BattleController.MoveController.CardMoveHero(_card, this);

        // if (_character.Died) _character.BattleController.MoveController.EnemyIsDie();
        
        if (Character.BattleController.MoveView.GetCountOfMove() < 3) return;
        
        Character.BattleController.MoveController.NextMove();//ход врага
    }
}