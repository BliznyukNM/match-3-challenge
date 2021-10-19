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

        private IntCounter moveCounter;

        public void Configure(Levels.Config config) {
            foreach (var gatherPiece in config.Rules.GatherPieces) {
                var goal = Instantiate(goalPrefab, goalsRoot);
                goal.Link(gatherPiece.Value, spritesDatabase.GetSpriteForPieceType(gatherPiece.Key));
            }
            moveCounter = config.Rules.MovesLeft;
        }

        private void Update() {
            if (moveCounter != null) {
                movesCountText.text = $"{moveCounter.Current}/{moveCounter.Max}";
            }
        }
    }
}
