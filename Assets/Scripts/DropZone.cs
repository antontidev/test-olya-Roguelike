using System;
using System.Collections.Generic;
using DG.Tweening;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public MoveController MoveController;
    public MoveView MoveView;

    private GameObject _card;

    public void OnDrop(PointerEventData eventData)
    {
        _card = eventData.pointerDrag;
        if (!_card.GetComponent<DragDrop>()) return;
        
        MoveController.CardMoveHero(_card);

        if (Enemy.EnemyIsDie) MoveController.EnemyIsDie();
        
        if (MoveView.GetCountOfMove() < 3) return;
        
        MoveController.NextMove();//ход врага
        MoveController.NextMove();//запуск хода игрока
    }
}