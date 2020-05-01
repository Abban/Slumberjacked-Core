using System.Collections;
using UnityEngine;

namespace BBX.Main.Scene
{
    public class SceneTransition: MonoBehaviour, ISceneTransition
    {
        [SerializeField] private CanvasGroup canvas = null;

        public bool IsVisible { get; private set; }


        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }


        private void Start()
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
            IsVisible = false;
        }
        

        public IEnumerator Show()
        {
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
            IsVisible = true;

            yield return null;
        }


        public IEnumerator Hide()
        {
            yield return new WaitForSeconds(1);
            
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
            IsVisible = false;
            
            yield return null;
        }
    }
}