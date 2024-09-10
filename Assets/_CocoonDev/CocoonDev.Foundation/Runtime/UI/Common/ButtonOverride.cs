using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CocoonDev.Foundation.UI
{
    [RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
    public class ButtonOverride : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        // Components
        [SerializeField]
        private RectTransform _rectTransform;
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private bool _interactable = true;
        private Tween _buttonTween;

        public bool Interactable
        {
            get => _interactable;
            set
            {
                _canvasGroup.interactable = value;
                _canvasGroup.blocksRaycasts = value;

                _interactable = value;
            }
        }

        private void OnValidate()
        {
            if(_rectTransform == false)
                _rectTransform = GetComponent<RectTransform>();
            if(_canvasGroup == false)
                _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDownAnimation();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerClick();
        }

        private void PointerDownAnimation()
        {
            _buttonTween.Complete();
            if (_interactable)
            {
                _buttonTween = Tween.Scale(_rectTransform
                    , 0.9F
                    , 0.05F
                    , Ease.OutQuad
                    , useUnscaledTime: true);
            }
        }

        private void PointerClick()
        {
            _buttonTween.Complete();

            if (_interactable)
            {
                _buttonTween = Tween.Scale(_rectTransform
                    , 1.0F
                    , 0.05F
                    , Ease.InQuad
                    , useUnscaledTime: true);
            }
        }
    }
}
