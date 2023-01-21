namespace Core.Pools.Base {
    public class PoolExpander {
        private readonly ExpandType _expandType;
        private readonly ExpandType _percentToExpand;
        private readonly GameObjectsPool _pool;

        public PoolExpander(ExpandType expandType, ExpandType percentToExpand, GameObjectsPool pool) {
            _expandType = expandType;
            _percentToExpand = percentToExpand;
            _pool = pool;
        }

        public void CheckExpand() {
            if (_expandType == ExpandType.None) return;
            
            var takenPercent = GetTakenPercent();
            var expandValue = (int) _expandType;
            var percentToExpand = (int) _percentToExpand;
            if (takenPercent < percentToExpand) return;

            var expandCount = _pool.NumTotal * expandValue / 100;
            
            _pool.Instantiate(expandCount);
        }
        
        private float GetTakenPercent() {
            var taken = _pool.NumActive;
            var all = _pool.NumTotal;
            
            return (float)taken / all * 100;
        }

    }
}