using System;
using System.Collections;
using UnityEngine;

namespace BBX.Main.SceneManagement
{
    public class SceneTransition: MonoBehaviour, ISceneTransition
    {
        [SerializeField] private CanvasGroup canvas = null;


        public void Start()
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        }
        

        public IEnumerator Show()
        {
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;

            yield return null;
        }


        public IEnumerator Hide()
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
            
            yield return null;
        }
    }
}