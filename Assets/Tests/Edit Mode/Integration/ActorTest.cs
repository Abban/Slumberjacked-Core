using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using BBX.Actor;
using BBX.Main.Level;
using BBX.TestSpies;

namespace Integration.Actors
{
    [TestFixture]
    public class ActorTest
    {
        private Board _board;
        private ActorSettings _actorSettings;
        private ActorBrainSpy _actorBrain;
        private ActorSettings _blockerSettings;
        private ActorSettings _pushableSettings;

        
        [SetUp]
        public void SetUp()
        {
            _board = Resources.Load<Board>("TestActor/TestBoard");
            _actorSettings = Resources.Load<ActorSettings>("TestActor/TestActorSettings");
            _actorBrain = Resources.Load<ActorBrainSpy>("TestActor/TestActorBrainSpy");
            _blockerSettings = Resources.Load<ActorSettings>("TestActor/TestBlockerSettings");
            _pushableSettings = Resources.Load<ActorSettings>("TestActor/TestPushableSettings");
        }
        
        
        [Test]
        public void OnStart_InitialisesBrain()
        {
            _board.Initialise();

            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            
            actorController.Start();
            
            Assert.That(_actorBrain.Initialised);
            Assert.That(_actorBrain.Enabled);
        }
        
        
        [Test]
        public void OnStart_RegistersWithBoard()
        {
            _board.Initialise();
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            actorController.Start();
            
            Assert.That(_board.Exists(actorController));
        }
        
        
        [Test]
        public void OnDispose_DisablesBrain()
        {
            _board.Initialise();
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            actorController.Start();
            actorController.Dispose();
            
            Assert.That(!_actorBrain.Enabled);
        }


        [Test]
        public void OnMove_MovesToPosition()
        {
            _board.Initialise();
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            actorController.Start();
            
            _actorBrain.Callback.Invoke(Vector2Int.down);

            Assert.That(actorController.Position == Vector2Int.down);
            Assert.That(_board.GetPosition(actorController) == Vector2Int.down);
        }
        
        
        [Test]
        public void OnInteractWithPushable_PerformsPush()
        {
            _board.Initialise();
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            var pushableActor = new ActorFactory(_pushableSettings, Vector2Int.right).Controller;
            
            actorController.Start();
            pushableActor.Start();
            
            _actorBrain.Callback.Invoke(Vector2Int.right);

            Assert.That(_board.GetPosition(actorController) == Vector2Int.right);
            Assert.That(_board.GetPosition(pushableActor) == Vector2Int.right + Vector2Int.right);
        }
        
        
        [Test]
        public void OnMove_WhenBlocked_DoesNotMove()
        {
            _board.Initialise(new List<Vector2Int>{ Vector2Int.right });
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            
            actorController.Start();
            
            _actorBrain.Callback.Invoke(Vector2Int.right);
            
            Assert.That(actorController.Position == Vector2Int.zero);
            Assert.That(_board.GetPosition(actorController) == Vector2Int.zero);
        }
        
        
        [Test]
        public void OnMove_WhenBlockedByActor_DoesNotMove()
        {
            _board.Initialise();
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            var blockerActor = new ActorFactory(_blockerSettings, Vector2Int.right).Controller;
            
            actorController.Start();
            blockerActor.Start();
            
           _actorBrain.Callback.Invoke(Vector2Int.right);

           Assert.That(_board.GetPosition(actorController) == Vector2Int.zero);
        }


        [Test]
        public void OnInteract_WhenPushableButBlocked_Blocks()
        {
            _board.Initialise(new List<Vector2Int>{ Vector2Int.right * 2 });
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            var pushableActor = new ActorFactory(_pushableSettings, Vector2Int.right).Controller;
            
            actorController.Start();
            pushableActor.Start();
            
            _actorBrain.Callback.Invoke(Vector2Int.right);
            
            Assert.That(actorController.Position == Vector2Int.zero);
            Assert.That(_board.GetPosition(actorController) == Vector2Int.zero);
            Assert.That(pushableActor.Position == Vector2Int.right);
            Assert.That(_board.GetPosition(pushableActor) == Vector2Int.right);
        }
        
        
        [Test]
        public void OnReset_ReturnsToOriginalState()
        {
            _board.Initialise();
            
            var actorController = new ActorFactory(_actorSettings, Vector2Int.zero).Controller;
            actorController.Start();
            
            _actorBrain.Callback.Invoke(Vector2Int.down);
            
            Assert.That(actorController.Position == Vector2Int.down);
            Assert.That(_board.GetPosition(actorController) == Vector2Int.down);
            
            _board.Initialise();
            actorController.Reset();
            
            Assert.That(actorController.Position == Vector2Int.zero);
            Assert.That(_board.GetPosition(actorController) == Vector2Int.zero);
        }
    }
}