using Tactile.TactileMatch3Challenge.Levels;
using Tactile.TactileMatch3Challenge.Model;
using Tactile.TactileMatch3Challenge.UI;
using Tactile.TactileMatch3Challenge.ViewComponents;
using UnityEngine;

namespace Tactile.TactileMatch3Challenge {

    public class Boot : MonoBehaviour {

        [SerializeField] private BoardRenderer boardRenderer;
        [SerializeField] private MainScreen mainScreen;

        private Level level;

        void Start() {

            level = new Level();
            ChooseDefaultRandomLevel();
        }

        public void ChooseDefaultRandomLevel() {
            level.ConfigureWithDefaultRandomRules();
            level.Config.Rules.OnWin += () => boardRenderer.Pause(true);
            level.Config.Rules.OnLose += () => boardRenderer.Pause(true);
            var board = level.Config.Board as Board;
            boardRenderer.Initialize(board);
            boardRenderer.Pause(false);
            mainScreen.Configure(level.Config);
        }
    }

}
