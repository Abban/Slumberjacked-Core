using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using BBX.Actor;
using BBX.Actor.Interfaces;
using BBX.Library.StateObserver;
using BBX.Main.Level;
using BBX.TestSpies;
using BBX.TestFixtures;

namespace Integration.Actors
{
    [TestFixture]
    public class ActorTest
    {
        private Board _board;
        private ActorSettings _actorSettings;
        private IActorStatuses _actorStatuses;
        private ActorBrainSpy _actorBrain;
        private ActorSettings _blockerSettings;
        private ActorSettings _pushableSettings;


        [SetUp]
        public void SetUp()
        {
            _board = Resources.Load<Board>("TestActor/TestBoard");
            _actorSettings = Resources.Load<ActorSettings>("TestActor/TestActorSettings");
            _actorStatuses = new TestActorStatuses();
            _actorBrain = Resources.Load<ActorBrainSpy>("TestActor/TestActorBrainSpy");
            _blockerSettings = Resources.Load<ActorSettings>("TestActor/TestBlockerSettings");
            _pushableSettings = Resources.Load<ActorSettings>("TestActor/TestPushableSettings");

            var levelState = Resources.Load<LevelState>("TestActor/TestLevelState");
            levelState.Initialise(new ObservableStateBroker());
            levelState.GameplayState.Value = LevelState.GameplayStates.Playing;
        }


        [Test]
        public void OnStart_InitialisesBrain()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;

            _board.Initialise(new List<IActor> {actorController});

            Assert.That(_actorBrain.Initialised);
            Assert.That(_actorBrain.Enabled);
        }


        [Test]
        public void OnDispose_DisablesBrain()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;

            _board.Initialise(new List<IActor> {actorController});

            actorController.Dispose();

            Assert.That(!_actorBrain.Enabled);
        }


        [Test]
        public void OnMove_MovesToPosition()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;

            _board.Initialise(new List<IActor> {actorController});

            _actorBrain.Callback.Invoke(Vector2Int.down);

            Assert.That(actorController.Position == Vector2Int.down);
        }


        [Test]
        public void OnInteractWithPushable_PerformsPush()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;
            var pushableActor = new ActorFactory(_pushableSettings, _actorStatuses, Vector2Int.right).Controller;

            _board.Initialise(new List<IActor> {actorController, pushableActor});

            _actorBrain.Callback.Invoke(Vector2Int.right);

            Assert.That(actorController.Position == Vector2Int.right);
            Assert.That(pushableActor.Position == Vector2Int.right + Vector2Int.right);
        }


        [Test]
        public void OnMove_WhenBlocked_DoesNotMove()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;

            _board.Initialise(
                new List<IActor> {actorController},
                new List<Vector2Int> {Vector2Int.right}
            );

            _actorBrain.Callback.Invoke(Vector2Int.right);

            Assert.That(actorController.Position == Vector2Int.zero);
        }


        [Test]
        public void OnMove_WhenBlockedByActor_DoesNotMove()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;
            var blockerActor = new ActorFactory(_blockerSettings, _actorStatuses, Vector2Int.right).Controller;

            _board.Initialise(new List<IActor> {actorController, blockerActor});

            _actorBrain.Callback.Invoke(Vector2Int.right);

            Assert.That(actorController.Position == Vector2Int.zero);
        }


        [Test]
        public void OnInteract_WhenPushableButBlocked_Blocks()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;
            var pushableActor = new ActorFactory(_pushableSettings, _actorStatuses, Vector2Int.right).Controller;

            _board.Initialise(
                new List<IActor> {actorController, pushableActor},
                new List<Vector2Int> {Vector2Int.right * 2}
            );

            _actorBrain.Callback.Invoke(Vector2Int.right);

            Assert.That(actorController.Position == Vector2Int.zero);
            Assert.That(pushableActor.Position == Vector2Int.right);
        }


        [Test]
        public void OnReset_ReturnsToOriginalState()
        {
            var actorController = new ActorFactory(_actorSettings, _actorStatuses, Vector2Int.zero).Controller;

            _board.Initialise(new List<IActor> {actorController});

            _actorBrain.Callback.Invoke(Vector2Int.down);
            Assert.That(actorController.Position == Vector2Int.down);

            actorController.Reset();
            Assert.That(actorController.Position == Vector2Int.zero);
        }
    }
}