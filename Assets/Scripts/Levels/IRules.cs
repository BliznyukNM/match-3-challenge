using System.Collections.Generic;
using Tactile.TactileMatch3Challenge.Model;
using Tactile.TactileMatch3Challenge.Utils;

public interface IRules
{
    IntCounter MovesLeft { get; }
    Dictionary<Piece, IntCounter> GatherPieces { get; }
}
