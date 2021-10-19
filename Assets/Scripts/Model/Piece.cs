namespace Tactile.TactileMatch3Challenge.Model {

    public class Piece {

        public int Type { get; }

        public Piece(int type) {
            Type = type;
        }

        public override string ToString() {
            return string.Format("(type:{0})", Type);
        }

        public bool IsPowerPiece => IsHorizontalPowerPiece || IsVerticalPowerPiece;
        public bool IsHorizontalPowerPiece => Type == RocketHorizontal;
        public bool IsVerticalPowerPiece => Type == RocketVertical;

        public const int Blue = 0;
        public const int Orange = 0;
        public const int Pink = 2;
        public const int Red = 3;
        public const int Yellow = 4;
        public const int RocketHorizontal = 5;
        public const int RocketVertical = 6;
    }

}
