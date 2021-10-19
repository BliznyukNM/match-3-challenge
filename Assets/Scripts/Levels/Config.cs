using Tactile.TactileMatch3Challenge.Model;

namespace Tactile.TactileMatch3Challenge.Levels {

    public class Config {

        public IBoard Board { get; }
        public IRules Rules { get; }

        public Config(IBoard board, IRules rules) {
            Board = board;
            Rules = rules;
        }
    }
}
