using Services;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public MoveController MoveController;
    public MoveView MoveView;
    public GameController GameController;

    private GameObject _card;

    public void OnDrop(PointerEventData eventData)
    {
        _card = eventData.pointerDrag;
        if (!_card.GetComponent<DragDrop>()) return;
        
        MoveController.CardMoveHero(_card);

        if (GameController.enemy.Died) MoveController.EnemyIsDie();
        
        if (MoveView.GetCountOfMove() < 3) return;
        
        MoveController.NextMove();//ход врага
    }
}