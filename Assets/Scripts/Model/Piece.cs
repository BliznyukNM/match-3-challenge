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
        public bool IsHorizontalPowerPiece => Type == RocketHorizontal.Type;
        public bool IsVerticalPowerPiece => Type == RocketVertical.Type;

        public static Piece Blue => new Piece(0);
        public static Piece Orange => new Piece(1);
        public static Piece Pink => new Piece(2);
        public static Piece Red => new Piece(3);
        public static Piece Yellow => new Piece(4);
        public static Piece RocketHorizontal => new Piece(5);
        public static Piece RocketVertical => new Piece(6);
    }

}
