using Tactile.TactileMatch3Challenge.Levels;
using Tactile.TactileMatch3Challenge.Model;
using Tactile.TactileMatch3Challenge.ViewComponents;
using UnityEngine;

namespace Tactile.TactileMatch3Challenge {

    public class Boot : MonoBehaviour {

        [SerializeField] private BoardRenderer boardRenderer;

        private Level level;

        void Start() {

            level = new Level();
            level.ConfigureWithDefaultRandomRules();
            var board = level.Config.Board as Board;
            boardRenderer.Initialize(board);
        }

    }

}
