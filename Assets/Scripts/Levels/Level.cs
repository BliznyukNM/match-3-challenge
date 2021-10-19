using Tactile.TactileMatch3Challenge.Model;

namespace Tactile.TactileMatch3Challenge.Levels {

    public class Level {

        public Config Config { get; private set; }

        public Level() { }

        public Level(Config config) {
            Config = config;
        }

        public void ConfigureWithDefaultRandomRules() {

            int[,] boardDefinition = {
                {3, 3, 1, 2, 4, 4},
                {2, 2, 1, 2, 3, 4},
                {1, 1, 0, 0, 2, 2},
                {2, 2, 0, 0, 1, 1},
                {1, 4, 2, 2, 1, 1},
                {1, 4, 2, 2, 1, 1},
            };

            var pieceSpawner = new PieceSpawner();
            var board = Board.Create(boardDefinition, pieceSpawner);
            var rules = DefaultRules.GetRandomRules();

            board.OnPieceDeleted += (type) => {
                if (rules.GatherPieces.ContainsKey(type)) {
                    rules.GatherPieces[type].Count(1);
                }
            };
            board.OnMoveMade += () => {
                rules.MovesLeft.Count(1);
            };

            Config = new Config(board, rules);
        }
    }
}
