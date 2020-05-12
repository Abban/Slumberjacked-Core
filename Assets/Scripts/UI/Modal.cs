using UnityEngine;

namespace BBX.UI
{
    public class Modal : MonoBehaviour
    {
        [SerializeField] private bool hideOnStart = true;
        [SerializeField] private CanvasGroup canvasGroup = null;

        protected void Start()
        {
            if (hideOnStart)
            {
                Hide();
            }
        }

        protected void Show()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        protected void Hide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}