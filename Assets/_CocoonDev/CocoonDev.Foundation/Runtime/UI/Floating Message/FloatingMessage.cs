using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using PrimeTween;

namespace CocoonDev.Foundation.UI
{
    public class FloatingMessage : MonoBehaviour
    {
        private static FloatingMessage s_instance;

        [SerializeField]
        private RectTransform _windowRectTransform;
        [SerializeField]
        private CanvasGroup _windowCanvasGroup;
        [SerializeField]
        private TextMeshProUGUI _floatingText;
        [SerializeField]
        private Image _panelImage;

        [Space]
        [SerializeField]
        private Vector2 _panelPadding = new Vector2(30, 25);

        private Tween _animationTween;

#if UNITY_EDITOR
        /// <seealso href="https://docs.unity3d.com/Manual/DomainReloading.html"/>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            s_instance = null;
        }
#endif

        public void Initialize()
        {
            s_instance = this;

            // Init clickable panel
            EventTrigger trigger = _floatingText.gameObject.AddComponent<EventTrigger>();

            // Create new event entry
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((eventData) => { OnPanelClicked(); });

            // Add entry to trigger
            trigger.triggers.Add(entry);
        }

        private void OnPanelClicked()
        {
            s_instance._animationTween.Stop();
            s_instance._animationTween = Tween.Alpha(s_instance._windowCanvasGroup, 0, 0.3F, Ease.OutCirc, useUnscaledTime: true)
                .OnComplete(() => s_instance._windowRectTransform.gameObject.SetActive(false));
        }


        public static void ShowMessage(string message, float timeMultiplier = 1)
        {
            ShowMessageTask(message, timeMultiplier).Forget();
        }

        public static async UniTaskVoid ShowMessageTask(string message, float timeMultiplier)
        {
            await ShowMessageAsync(message, timeMultiplier);
        }

        public static async UniTask ShowMessageAsync(string message, float timeMultiplier = 1.0F)
        {
            if (s_instance != null)
            {
                s_instance._animationTween.Stop();

                s_instance._floatingText.text = message;


                s_instance._windowRectTransform.gameObject.SetActive(true);
                s_instance._windowRectTransform.localScale = Vector2.one;

                s_instance._windowCanvasGroup.alpha = 1;
                s_instance._animationTween = Tween.Delay(1.5F * timeMultiplier, delegate {
                    s_instance._animationTween = Tween.Alpha(s_instance._windowCanvasGroup, 0, 0.5F * timeMultiplier, Ease.OutCirc, useUnscaledTime: true)
                    .OnComplete(() => s_instance._windowRectTransform.gameObject.SetActive(false));
                }, useUnscaledTime: true);

                await UniTask.NextFrame();
                LayoutRebuilder.ForceRebuildLayoutImmediate(s_instance._floatingText.rectTransform);
                s_instance._panelImage.rectTransform.anchoredPosition = s_instance._floatingText.rectTransform.anchoredPosition;
                s_instance._panelImage.rectTransform.sizeDelta = s_instance._floatingText.rectTransform.sizeDelta + s_instance._panelPadding;

            }
            else
            {
                Debug.Log("[Floating Message]: " + message);
                Debug.LogError("[Floating Message]: ShowMessage() method has called, but module isn't initialized! Add Floating Message module to Project Init Settings.");
            }
        }
    }
}
