using Services;

namespace Map
{
    public class Battle : Station
    {
        protected override void Action()
        {
            GameController.Instance.StartLevel();
        }
    }
}