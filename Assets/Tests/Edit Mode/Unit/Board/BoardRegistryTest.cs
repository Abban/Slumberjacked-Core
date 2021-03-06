using System;
using BBX.Main.Level.Interfaces;
using NUnit.Framework;
using UnityEngine;
using BBX.Main.Level.Utilities;

namespace Unit.Board
{
    [TestFixture]
    public class BoardRegistryTest
    {
        private class TestBoardItem : IBoardItem
        {
            public Vector2Int Position { get; }
            
            public bool Initialised { get; private set; }
            
            public bool HasReset { get; private set; }
            
            public TestBoardItem(Vector2Int position)
            {
                Position = position;
            }
            
            public void Initialise()
            {
                Initialised = true;
            }
            
            public void Reset()
            {
                HasReset = true;
            }
        }
        
        [Test]
        public void OnAddItem_AddsItem()
        {
            var item = new TestBoardItem(Vector2Int.one);
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item);

            Assert.That( boardRegistry.Exists(item) );
        }
        
        
        [Test]
        public void OnAddItem_AddsItemAtCorrectPosition()
        {
            var item = new TestBoardItem(Vector2Int.one);
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item);

            Assert.That( boardRegistry.Get(Vector2Int.one) == item );
        }

        
        [Test]
        public void OnAddItemTwice_ThrowsException()
        {
            var item = new TestBoardItem(Vector2Int.one);
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item);
            
            Assert.Throws<Exception>(() => boardRegistry.Add(item));
        }


        [Test]
        public void OnAddItem_IfItemAlreadyExistsAtPosition_ThrowsException()
        {
            var item = new TestBoardItem(Vector2Int.one);
            var item2 = new TestBoardItem(Vector2Int.one);
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item);

            Assert.Throws<Exception>(() => boardRegistry.Add(item2));
        }


        [Test]
        public void OnGetItem_WhenNoItemExists_ReturnsNull()
        {
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();

            Assert.That(boardRegistry.Get(position) == null);
        }


        [Test]
        public void OnRemoveItem_RemovesItem()
        {
            var position = Vector2Int.one;
            var item = new TestBoardItem(position);
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item);

            Assert.That(boardRegistry.Get(position) == item);
            
            boardRegistry.Remove(item);
            
            Assert.That(boardRegistry.Get(position) == null);
        }


        [Test]
        public void OnRemoveItem_WhenNoItemExists_ThrowsException()
        {
            var item = new TestBoardItem(Vector2Int.zero);
            var boardRegistry = new BoardRegistry<TestBoardItem>();

            Assert.Throws<Exception>(() => boardRegistry.Remove(item));
        }


        [Test]
        public void OnRemoveItemAtPosition_RemovesItem()
        {
            var position = Vector2Int.one;
            var item = new TestBoardItem(position);
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item);

            Assert.That( boardRegistry.Get(position) == item );
            
            boardRegistry.Remove(position);
            
            Assert.That(boardRegistry.Get(position) == null);
        }


        [Test]
        public void OnRemoveItemAtPosition_WhenNoItemExists_ThrowsException()
        {
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();

            Assert.Throws<Exception>(() => boardRegistry.Remove(position));
        }
    }
}