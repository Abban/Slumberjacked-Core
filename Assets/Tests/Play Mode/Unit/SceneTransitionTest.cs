using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BBX.Main.Game;
using BBX.Main.Scene;

namespace Play.Unit.Game
{
    public class SceneTransitionTest
    {
        private ISceneTransition _transition;
        
        
        [SetUp]
        public void Setup()
        {
            var gameFactory = Resources.Load<GameFactory>("Settings/Game/GameFactory");
            _transition = gameFactory.SceneTransition;
        }
        
        
        [UnityTest]
        public IEnumerator OnAwake_IsNotVisible()
        {
            yield return null;

            Assert.That(!_transition.IsVisible);
        }
        
        
        [UnityTest]
        public IEnumerator OnShow_BecomesVisible()
        {
            yield return _transition.Show();
            
            Assert.That(_transition.IsVisible);
        }
        
        
        [UnityTest]
        public IEnumerator OnHide_BecomesNotVisible()
        {
            yield return _transition.Show();
            yield return _transition.Hide();
            
            Assert.That(!_transition.IsVisible);
        }
    }
}