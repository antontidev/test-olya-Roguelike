using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera _mainCamera;
    private Vector3 _startPosition;
    public Transform defaultParent;

    private void Awake()
    {
        _mainCamera = Camera.allCameras[0];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = transform.position - _mainCamera.ScreenToWorldPoint(eventData.position);
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPosition + _startPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}