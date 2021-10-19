using System.Collections.Generic;
using Tactile.TactileMatch3Challenge.Model;
using Tactile.TactileMatch3Challenge.Utils;

namespace Tactile.TactileMatch3Challenge.Levels {

    public class DefaultRules : IRules {

        public IntCounter MovesLeft { get; }

        public Dictionary<Piece, IntCounter> GatherPieces { get; }

        public DefaultRules(int maxMoves, Dictionary<Piece, IntCounter> gatherPieces) {
            MovesLeft = maxMoves;
            GatherPieces = gatherPieces;
        }

        public static DefaultRules GetRandomRules() {
            int movesCount = UnityEngine.Random.Range(10, 16);
            int pieceTypesCount = UnityEngine.Random.Range(1, 4);
            var gatherPieces = new Dictionary<Piece, IntCounter>();
            var piecesToGenerate = new List<Piece> { Piece.Red, Piece.Blue, Piece.Orange, Piece.Pink, Piece.Yellow };

            for (int i = 0; i < pieceTypesCount; i++) {
                var piece = piecesToGenerate[UnityEngine.Random.Range(0, piecesToGenerate.Count)];
                gatherPieces.Add(piece, UnityEngine.Random.Range(5, 11));
                piecesToGenerate.Remove(piece);
            }

            return new DefaultRules(movesCount, gatherPieces);
        }
    }
}
