using Services;
using TMPro;
using UnityEngine;

namespace Views
{
    public class MoveView : MonoBehaviour
    {
        [Header("Сыгранные карты")]
        private int _countOfMoves;
        public TextMeshProUGUI countOfMovesText;
    
        [Header("Принадлежность хода")]
        public TextMeshProUGUI whoseMove;

        public BattleController BattleController;
    
        public void AddCountOfMoves()
        {
            SetCountOfMove(++_countOfMoves);
        }
        public void SetToZeroCountOfMove()
        {
            SetCountOfMove(0);
        }
        private void SetCountOfMove(int countOfMoves)
        {
            _countOfMoves = countOfMoves;
            countOfMovesText.text = _countOfMoves + "/3";
        }

        public void SwitchMove()
        {
            BattleController.SwitchCurrentMoveCharacter();
            whoseMove.text = BattleController.CurrentMoveCharacter is Enemy ? "Ход врага" : "Ваш ход";
            SetToZeroCountOfMove();
        }

        public int GetCountOfMove()
        {
            return _countOfMoves;
        }
    }
}
