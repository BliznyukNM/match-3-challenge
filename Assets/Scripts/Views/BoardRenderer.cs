using System.Collections;
using System.Collections.Generic;
using Tactile.TactileMatch3Challenge.Model;
using UnityEngine;

namespace Tactile.TactileMatch3Challenge.ViewComponents {

    public class BoardRenderer : MonoBehaviour {

        [SerializeField] private PieceTypeDatabase pieceTypeDatabase;
        [SerializeField] private VisualPiece visualPiecePrefab;

        private Board board;
        private bool discardInput;

        public void Initialize(Board board) {
            this.board = board;

            CenterCamera();
            CreateVisualPiecesFromBoardState();
        }

        private void CenterCamera() {
            Camera.main.transform.position = new Vector3((board.Width - 1) * 0.5f, -(board.Height - 1) * 0.5f);
        }

        private void CreateVisualPiecesFromBoardState() {
            DestroyVisualPieces();

            foreach (var pieceInfo in board.IteratePieces()) {

                var visualPiece = CreateVisualPiece(pieceInfo.piece);
                visualPiece.transform.localPosition = LogicPosToVisualPos(pieceInfo.pos.x, pieceInfo.pos.y);
            }
        }

        private IEnumerator CreateVisualPiecesFromResolveResult(ResolveResult resolveResult) {

            discardInput = true;
            DestroyVisualPieces();

            var visualPieces = new Dictionary<BoardPos, VisualPiece>();
            foreach (var pieceInfo in board.IteratePieces()) {
                var visualPiece = CreateVisualPiece(pieceInfo.piece);
                visualPiece.transform.localPosition = LogicPosToVisualPos(pieceInfo.pos.x, pieceInfo.pos.y);
                visualPieces.Add(pieceInfo.pos, visualPiece);
            }

            var fallings = new List<Coroutine>();
            foreach (var change in resolveResult.changes) {

                Piece piece = change.Key;
                ChangeInfo changeInfo = change.Value;
                VisualPiece visualPiece = visualPieces[changeInfo.ToPos];
                Vector3 visualToPos = LogicPosToVisualPos(changeInfo.ToPos.x, changeInfo.ToPos.y);
                Vector3 visualFromPos = LogicPosToVisualPos(changeInfo.FromPos.x, changeInfo.FromPos.y);
                var fallingTime = Random.Range(0.5f, 0.6f);

                if (changeInfo.WasCreated) {
                    visualFromPos += Vector3.up * 3f;
                }

                var fallingAnimation = StartCoroutine(Utils.Tween.Move(
                            visualPiece.transform, visualFromPos, visualToPos, fallingTime, Utils.EaseFunctions.EaseOutBounce));
                fallings.Add(fallingAnimation);
            }

            foreach (var falling in fallings) {
                yield return falling;
            }

            discardInput = false;
        }

        public Vector3 LogicPosToVisualPos(float x, float y) {
            return new Vector3(x, -y, -y);
        }

        private BoardPos ScreenPosToLogicPos(float x, float y) {

            var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(x, y, -Camera.main.transform.position.z));
            var boardSpace = transform.InverseTransformPoint(worldPos);

            return new BoardPos() {
                x = Mathf.RoundToInt(boardSpace.x),
                y = -Mathf.RoundToInt(boardSpace.y)
            };

        }

        private VisualPiece CreateVisualPiece(Piece piece) {

            var pieceObject = Instantiate(visualPiecePrefab, transform, true);
            var sprite = pieceTypeDatabase.GetSpriteForPieceType(piece.type);
            pieceObject.SetSprite(sprite);
            return pieceObject;

        }

        private void DestroyVisualPieces() {
            foreach (var visualPiece in GetComponentsInChildren<VisualPiece>()) {
                Object.Destroy(visualPiece.gameObject);
            }
        }

        private void Update() {

            if (!discardInput && Input.GetMouseButtonDown(0)) {

                var pos = ScreenPosToLogicPos(Input.mousePosition.x, Input.mousePosition.y);

                if (board.IsWithinBounds(pos.x, pos.y)) {
                    var resolveResult = board.Resolve(pos.x, pos.y);
                    StartCoroutine(CreateVisualPiecesFromResolveResult(resolveResult));
                }

            }
        }

    }

}
