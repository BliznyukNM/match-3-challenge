using Tactile.TactileMatch3Challenge.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Tactile.TactileMatch3Challenge.UI {

    public class Goal : MonoBehaviour {

        [SerializeField] private Text counterText;
        [SerializeField] private Image iconRenderer;

        private IntCounter counter;

        public void Link(IntCounter counter, Sprite icon) {
            this.counter = counter;
            iconRenderer.sprite = icon;
        }

        private void Update() {
            counterText.text = $"{counter.Current}/{counter.Max}";
        }
    }
}
