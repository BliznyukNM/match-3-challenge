using Tactile.TactileMatch3Challenge.Model;
using Tactile.TactileMatch3Challenge.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Tactile.TactileMatch3Challenge.UI {

    public class MainScreen : MonoBehaviour {

        [SerializeField] private Text movesCountText;
        [SerializeField] private Goal goalPrefab;
        [SerializeField] private Transform goalsRoot;
        [SerializeField] private PieceTypeDatabase spritesDatabase;

        [SerializeField] private GameObject winPopup;
        [SerializeField] private GameObject losePopup;

        private IntCounter moveCounter;

        public void Configure(Levels.Config config) {
            ClearUI();

            foreach (var gatherPiece in config.Rules.GatherPieces) {
                var goal = Instantiate(goalPrefab, goalsRoot);
                goal.Link(gatherPiece.Value, spritesDatabase.GetSpriteForPieceType(gatherPiece.Key));
            }
            moveCounter = config.Rules.MovesLeft;

            config.Rules.OnWin += () => winPopup.SetActive(true);
            config.Rules.OnLose += () => losePopup.SetActive(true);
        }

        private void ClearUI() {
            winPopup.SetActive(false);
            losePopup.SetActive(false);
            foreach (Transform child in goalsRoot) {
                Destroy(child.gameObject);
            }
        }

        private void Update() {
            if (moveCounter != null) {
                movesCountText.text = $"{moveCounter.Current}/{moveCounter.Max}";
            }
        }
    }
}
