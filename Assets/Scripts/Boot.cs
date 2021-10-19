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
            level.ConfigureWithDefaultRandomRules();
            var board = level.Config.Board as Board;
            boardRenderer.Initialize(board);
            mainScreen.Configure(level.Config);
        }

    }

}
