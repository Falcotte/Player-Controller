using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace AngryKoala.Inputs
{
    public class InputController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        #region Touchpad

        [SerializeField] private RectTransform canvas;
        [SerializeField] private InputArea inputArea;

        [SerializeField] private Touchpad touchPadPrefab;
        private Touchpad touchpad;

        private RectTransform container;
        private RectTransform background;
        private RectTransform handle;

        private enum TouchpadTypes { StaticTouchpad, DynamicTouchpad }
        [SerializeField] private TouchpadTypes touchpadType;

        private bool staticTouchpadEnabled => touchpadType == TouchpadTypes.StaticTouchpad;
        private bool dynamicTouchpadEnabled => touchpadType == TouchpadTypes.DynamicTouchpad;

        [SerializeField] private bool followTouch;

        private enum TouchpadBehaviours { ReturnToDefaultPosition, StayAtNewPosition }
        [SerializeField] private TouchpadBehaviours touchpadBehaviour;

        [SerializeField] private bool instantReturn;
        [SerializeField] private float returnSpeed;

        [SerializeField] private bool hideOnPointerUp;

        private float handleLimit = 1f;

        [SerializeField] private Color activeColor;
        [SerializeField] private Color inactiveColor;
        [SerializeField] private float colorChangeDelay = 0.1f;
        [SerializeField] private float colorChangeSpeed = 0.2f;

        private Vector2 touchpadCenter = Vector2.zero;
        private Vector3 containerDefaultPosition;
        private Vector2 touchpadCorrectedPosition;
        private bool containerDefaultPositionSet;

        private Vector2 inputVector = Vector2.zero;

        private float horizontal { get { return inputVector.x; } }
        private float vertical { get { return inputVector.y; } }
        private Vector2 direction { get { return new Vector2(horizontal, vertical); } }

        private bool isTouching;

        private Vector2 initialTouchPosition;
        private Vector2 touchPosition;

        #endregion

        private void OnEnable()
        {
            if(touchpad == null)
            {
                touchpad = Instantiate(touchPadPrefab, transform);

                touchpad.Canvas = canvas;
                touchpad.InputArea = inputArea;

                container = touchpad.Container;
                background = touchpad.Background;
                handle = touchpad.Handle;
            }
            else
            {
                touchpad.gameObject.SetActive(true);
            }

            if(hideOnPointerUp)
            {
                SetTouchpadColor(inactiveColor, changeColorInstantly: true);
            }
            else
            {
                SetTouchpadColor(activeColor, changeColorInstantly: true);
            }

            // Touchpad default position gets set when it first activates
            if(!containerDefaultPositionSet)
            {
                containerDefaultPosition = container.anchoredPosition;
                containerDefaultPositionSet = true;
            }
        }

        private void OnDisable()
        {
            if(touchpad != null)
            {
                touchpad.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if(isTouching)
            {
                touchPosition = CurrentTouchPosition();
                inputArea.SetTouchPos(touchPosition);

                inputArea.OnTouch?.Invoke();
            }
        }

        #region Touch

        public void OnPointerDown(PointerEventData eventData)
        {
            if(inputArea != null)
            {
                isTouching = true;
                inputArea.SetIsTouching(true);

                touchpadCorrectedPosition = touchpad.AdjustEventDataPosition(eventData.position);

                initialTouchPosition = eventData.position;
                touchPosition = initialTouchPosition;

                inputArea.OnTouchDown?.Invoke();

                if(dynamicTouchpadEnabled)
                {
                    container.DOKill();
                    container.anchoredPosition = touchpadCorrectedPosition;

                    touchpadCenter = touchpadCorrectedPosition;

                    if(hideOnPointerUp)
                    {
                        SetTouchpadColor(activeColor);
                    }
                }
                else if(staticTouchpadEnabled)
                {
                    touchpadCenter = container.anchoredPosition;

                    Vector2 direction = eventData.position - touchpadCenter;
                    inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);

                    handle.transform.localPosition = inputVector * background.sizeDelta.x / 2f * handleLimit;

                    HandleAxes();
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if(inputArea != null)
            {
                isTouching = false;
                inputArea.SetIsTouching(false);

                inputArea.OnTouchUp?.Invoke();

                initialTouchPosition = Vector2.zero;
                touchPosition = Vector2.zero;
                inputArea.SetTouchPos(touchPosition);

                if(dynamicTouchpadEnabled)
                {
                    if(touchpadBehaviour == TouchpadBehaviours.ReturnToDefaultPosition)
                    {
                        if(instantReturn)
                        {
                            container.anchoredPosition = containerDefaultPosition;
                        }
                        else
                        {
                            container.DOKill();
                            container.DOAnchorPos(containerDefaultPosition, returnSpeed).SetSpeedBased();
                        }
                    }
                    if(hideOnPointerUp)
                    {
                        SetTouchpadColor(inactiveColor, 0f);
                    }
                }
                handle.anchoredPosition = Vector2.zero;

                inputVector = Vector2.zero;

                HandleAxes();
            }
        }

#if UNITY_EDITOR
        private Vector2 CurrentTouchPosition()
        {
            if(inputArea != null)
            {
                if(isTouching)
                {
                    return Input.mousePosition;
                }
                else
                {
                    return Vector2.zero;
                }
            }
            return Vector2.zero;
        }
#else
        private Vector2 CurrentTouchPosition()
        {
            if(inputArea != null)
            {
                if(Input.touchCount > 0)
                {
                    return Input.touches[0].position;
                }
            }
            return Vector2.zero;
        }
#endif

        #endregion

        #region Drag

        public void OnDrag(PointerEventData eventData)
        {
            if(inputArea != null)
            {
                touchpadCorrectedPosition = touchpad.AdjustEventDataPosition(eventData.position);

                Vector2 direction = touchpadCorrectedPosition - touchpadCenter;

                if(direction.magnitude > background.sizeDelta.x / 2f)
                {
                    if(dynamicTouchpadEnabled && followTouch)
                    {
                        container.anchoredPosition += new Vector2(direction.x, direction.y).normalized * (direction.magnitude - background.sizeDelta.x / 2f);
                        touchpadCenter = container.anchoredPosition;
                    }
                    inputVector = direction.normalized;
                }
                else
                {
                    inputVector = direction / (background.sizeDelta.x / 2f);
                }

                handle.transform.localPosition = inputVector * background.sizeDelta.x / 2f * handleLimit;

                HandleAxes();
            }
        }

        #endregion

        private void HandleAxes()
        {
            inputArea.SetHorizontal(inputVector.x);
            inputArea.SetVertical(inputVector.y);
            inputArea.SetDirection(inputVector);
        }

        private void SetTouchpadColor(Color color, float overrideColorChangeDelay = -1f, bool changeColorInstantly = false)
        {
            foreach(Image image in container.GetComponentsInChildren<Image>())
            {
                DOTween.Kill(image);
                if(!changeColorInstantly)
                {
                    if(overrideColorChangeDelay < 0f)
                    {
                        image.DOColor(color, colorChangeSpeed).SetEase(Ease.Linear).SetDelay(colorChangeDelay);
                    }
                    else
                    {
                        image.DOColor(color, colorChangeSpeed).SetEase(Ease.Linear).SetDelay(overrideColorChangeDelay);
                    }
                }
                else
                {
                    image.color = color;
                }
            }
        }

        public void SetTouchpadColors(Color activeColor, Color inactiveColor)
        {
            this.activeColor = activeColor;
            this.inactiveColor = inactiveColor;

            if(isTouching)
            {
                SetTouchpadColor(activeColor);
            }
            else
            {
                SetTouchpadColor(inactiveColor);
            }
        }
    }
}