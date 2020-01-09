using UnityEngine;

namespace eidng8.SpaceFlight.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class AnchoredElement : MonoBehaviour
    {
        private bool _hasRect;

        private RectTransform _rect;

        public SpriteAlignment anchor = SpriteAlignment.BottomLeft;
        public float xOffset = 5;

        public float yOffset = 5;

        private RectTransform Rect {
            get {
                if (this._hasRect) { return this._rect; }

                this._rect = this.GetComponent<RectTransform>();
                this._hasRect = true;
                return this._rect;
            }
        }

        public float X {
            get {
                if (null == Camera.main) { return 0; }

                float x = this.xOffset;
                switch (this.anchor) {
                    case SpriteAlignment.Center:
                    case SpriteAlignment.BottomCenter:
                    case SpriteAlignment.TopCenter:
                        x += Camera.main.pixelWidth / 2f;
                        break;

                    case SpriteAlignment.BottomRight:
                    case SpriteAlignment.RightCenter:
                    case SpriteAlignment.TopRight:
                        x = Camera.main.pixelWidth - x - this.Rect.rect.width;
                        break;
                }

                return x;
            }
        }

        public float Y {
            get {
                if (null == Camera.main) { return 0; }

                float y = this.yOffset;
                switch (this.anchor) {
                    case SpriteAlignment.Center:
                    case SpriteAlignment.LeftCenter:
                    case SpriteAlignment.RightCenter:
                        y += Camera.main.pixelHeight / 2f;
                        break;

                    case SpriteAlignment.TopCenter:
                    case SpriteAlignment.TopLeft:
                    case SpriteAlignment.TopRight:
                        y = Camera.main.pixelHeight - y - this.Rect.rect.height;
                        break;
                }

                return y;
            }
        }

        private void OnEnable() {
            this.Rect.anchoredPosition3D = new Vector3(this.X, this.Y);
        }
    }
}
