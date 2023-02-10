using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class DropZone : MonoBehaviour, IDropHandler
{
    public MoveController MoveController;
    public MoveView MoveView;
    [FormerlySerializedAs("ButtleController")] [FormerlySerializedAs("GameController")] public BattleController BattleController;

    private GameObject _card;

    public void OnDrop(PointerEventData eventData)
    {
        _card = eventData.pointerDrag;
        if (!_card.GetComponent<DragDrop>()) return;
        
        MoveController.CardMoveHero(_card);

        if (BattleController.enemy.Died) MoveController.EnemyIsDie();
        
        if (MoveView.GetCountOfMove() < 3) return;
        
        MoveController.NextMove();//ход врага
    }
}