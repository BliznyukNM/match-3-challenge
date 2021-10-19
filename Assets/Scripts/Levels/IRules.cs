using System.Collections.Generic;
using Tactile.TactileMatch3Challenge.Utils;

public interface IRules
{
    IntCounter MovesLeft { get; }
    Dictionary<int, IntCounter> GatherPieces { get; }
}
