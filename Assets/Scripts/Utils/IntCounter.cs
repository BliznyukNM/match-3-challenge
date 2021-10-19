using UnityEngine;

namespace Tactile.TactileMatch3Challenge.Utils {

    public class IntCounter {

        public int Current { get; private set; }
        public int Max { get; }

        public IntCounter(int max) {
            Current = 0;
            Max = max;
        }

        public bool Count(int amount) {
            Current = Mathf.Clamp(Current + amount, 0, Max);
            return Current == Max;
        }

        public static implicit operator IntCounter(int amount) {
            return new IntCounter(amount);
        }
    }
}
