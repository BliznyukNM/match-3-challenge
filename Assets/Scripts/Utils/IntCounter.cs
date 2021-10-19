using UnityEngine;

namespace Tactile.TactileMatch3Challenge.Utils {

    public class IntCounter {

        public int Current { get; private set; }
        public int Max { get; }

        public event System.Action OnFinished;

        public bool IsFinished => Current == Max;

        public IntCounter(int max) {
            Current = 0;
            Max = max;
        }

        public void Count(int amount) {

            if (IsFinished) {
                return;
            }

            Current = Mathf.Clamp(Current + amount, 0, Max);

            if (Current == Max) {
                OnFinished?.Invoke();
            }
        }

        public static implicit operator IntCounter(int amount) {
            return new IntCounter(amount);
        }
    }
}
