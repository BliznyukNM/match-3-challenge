using System.Collections.Generic;
using Tactile.TactileMatch3Challenge.Model;
using Tactile.TactileMatch3Challenge.Utils;
using System.Linq;

namespace Tactile.TactileMatch3Challenge.Levels {

    public class DefaultRules : IRules {

        public IntCounter MovesLeft { get; }

        public Dictionary<int, IntCounter> GatherPieces { get; }

        public DefaultRules(int maxMoves, Dictionary<int, IntCounter> gatherPieces) {
            MovesLeft = maxMoves;
            GatherPieces = gatherPieces;

            MovesLeft.OnFinished += () => OnLose?.Invoke();
            foreach (var gatherPiece in gatherPieces) {
                gatherPiece.Value.OnFinished += () => {
                    if (gatherPieces.All(g => g.Value.IsFinished)) {
                        OnWin?.Invoke();
                    }
                };
            }
        }

        public event System.Action OnWin;
        public event System.Action OnLose;

        public static DefaultRules GetRandomRules() {
            int movesCount = UnityEngine.Random.Range(10, 16);
            int pieceTypesCount = UnityEngine.Random.Range(1, 4);
            var gatherPieces = new Dictionary<int, IntCounter>();
            var piecesToGenerate = new List<int> { Piece.Red, Piece.Blue, Piece.Orange, Piece.Pink, Piece.Yellow };

            for (int i = 0; i < pieceTypesCount; i++) {
                var piece = piecesToGenerate[UnityEngine.Random.Range(0, piecesToGenerate.Count)];
                gatherPieces.Add(piece, UnityEngine.Random.Range(5, 11));
                piecesToGenerate.Remove(piece);
            }

            return new DefaultRules(movesCount, gatherPieces);
        }
    }
}
