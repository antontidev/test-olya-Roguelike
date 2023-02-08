using Services;
using TMPro;
using UnityEngine;

public class MoveView : MonoBehaviour
{
    [Header("Сыгранные карты")]
    private int _countOfMoves;
    public TextMeshProUGUI countOfMovesText;
    
    [Header("Принадлежность хода")]
    public TextMeshProUGUI whoseMove;

    public GameController GameController;
    
    public void AddCountOfMoves()
    {
        SetCountOfMove(++_countOfMoves);
    }
    public void SetToZeroCountOfMove()
    {
        _countOfMoves = 0;
        SetCountOfMove(0);
    }
    private void SetCountOfMove(int countOfMoves)
    {
        countOfMovesText.text = countOfMoves + "/3";
    }

    public void SwitchMove()
    {
        whoseMove.text = GameController.CurrentMoveCharacter is Enemy ? "Ваш ход" : "Ход врага";
        GameController.SwitchCurrentMoveCharacter();
        SetToZeroCountOfMove();
    }

    public int GetCountOfMove()
    {
        return _countOfMoves;
    }
}