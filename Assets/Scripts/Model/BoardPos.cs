using UnityEngine;

namespace Tactile.TactileMatch3Challenge.Model {

    public struct BoardPos {
        public int x;
        public int y;

        public BoardPos(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public static Vector3 operator+ (BoardPos a, Vector3 b) {
            return new Vector3(a.x + b.x, a.y + b.y, b.z);
        }
    }
}
