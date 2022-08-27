using UnityEngine;

namespace AngryKoala.Inputs
{
    public class Touchpad : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        public RectTransform Container => container;
        [SerializeField] private RectTransform background;
        public RectTransform Background => background;
        [SerializeField] private RectTransform handle;
        public RectTransform Handle => handle;

        public enum AnchorTypes { Left, Right, Center }
        public AnchorTypes AnchorType;

        public RectTransform Canvas;
        public InputArea InputArea;

        /// <summary>
        /// eventData.position is adjusted to match the inputArea here
        /// </summary>
        /// <param name="eventDataPosition"></param>
        /// <returns></returns>
        public Vector2 AdjustEventDataPosition(Vector2 eventDataPosition)
        {
            switch(AnchorType)
            {
                case AnchorTypes.Left:
                    return new Vector2(eventDataPosition.x / Screen.width * Canvas.rect.width - InputArea.InputAreaBoundaryMin.x / Screen.width * Canvas.rect.width,
                        eventDataPosition.y / Screen.height * Canvas.rect.height - InputArea.InputAreaBoundaryMin.y / Screen.height * Canvas.rect.height);
                case AnchorTypes.Right:
                    return new Vector2(eventDataPosition.x / Screen.width * Canvas.rect.width - InputArea.InputAreaBoundaryMax.x / Screen.width * Canvas.rect.width,
                        eventDataPosition.y / Screen.height * Canvas.rect.height - InputArea.InputAreaBoundaryMin.y / Screen.height * Canvas.rect.height);
                case AnchorTypes.Center:
                    return new Vector2(eventDataPosition.x / Screen.width * Canvas.rect.width - (InputArea.InputAreaWidth / 2f + InputArea.InputAreaBoundaryMin.x) / Screen.width * Canvas.rect.width,
                        eventDataPosition.y / Screen.height * Canvas.rect.height - InputArea.InputAreaBoundaryMin.y / Screen.height * Canvas.rect.height);
            }

            return Vector2.zero;
        }
    }
}