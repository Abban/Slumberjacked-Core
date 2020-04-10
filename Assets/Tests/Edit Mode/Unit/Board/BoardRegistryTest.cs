using System;
using BBX.Board;
using NUnit.Framework;
using UnityEngine;

namespace Unit.Board
{
    [TestFixture]
    public class BoardRegistryTest
    {
        private class TestBoardItem
        {
        }
        
        [Test]
        public void OnAddItem_AddsItem()
        {
            var item = new TestBoardItem();
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, position);

            Assert.That( boardRegistry.Exists(item) );
        }
        
        
        [Test]
        public void OnAddItem_AddsItemAtCorrectPosition()
        {
            var item = new TestBoardItem();
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, position);

            Assert.That( boardRegistry.Get(position) == item );
        }

        
        [Test]
        public void OnAddItemTwice_ThrowsException()
        {
            var item = new TestBoardItem();
            var position1 = Vector2Int.one;
            var position2 = Vector2Int.down;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, position1);
            
            Assert.Throws<Exception>(() => boardRegistry.Add(item, position2));
        }


        [Test]
        public void OnGetPosition_GetsCorrectPosition()
        {
            var item = new TestBoardItem();
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, position);

            Assert.That( boardRegistry.GetPosition(item) == position );
        }


        [Test]
        public void OnAddItemWhereItemExists_ThrowsException()
        {
            var item = new TestBoardItem();
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, position);

            Assert.Throws<Exception>(() => boardRegistry.Add(item, position));
        }


        [Test]
        public void OnGetItemWhereNoItemExists_ReturnsNull()
        {
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();

            Assert.That(boardRegistry.Get(position) == null);
        }


        [Test]
        public void OnGetPositionWhereNoItemExists_ThrowsException()
        {
            var item = new TestBoardItem();
            var boardRegistry = new BoardRegistry<TestBoardItem>();

            Assert.Throws<Exception>(() => boardRegistry.GetPosition(item));
        }


        [Test]
        public void OnRemoveItem_RemovesItem()
        {
            var item = new TestBoardItem();
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, position);

            Assert.That( boardRegistry.Get(position) == item );
            
            boardRegistry.Remove(item);
            
            Assert.That(boardRegistry.Get(position) == null);
        }


        [Test]
        public void OnRemoveItemWhereNoItemExists_ThrowsException()
        {
            var item = new TestBoardItem();
            var boardRegistry = new BoardRegistry<TestBoardItem>();

            Assert.Throws<Exception>(() => boardRegistry.Remove(item));
        }


        [Test]
        public void OnRemoveItemAtPosition_RemovesItem()
        {
            var item = new TestBoardItem();
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, position);

            Assert.That( boardRegistry.Get(position) == item );
            
            boardRegistry.Remove(position);
            
            Assert.That(boardRegistry.Get(position) == null);
        }


        [Test]
        public void OnRemoveItemAtPositionWhereNoItemExists_ThrowsException()
        {
            var position = Vector2Int.one;
            var boardRegistry = new BoardRegistry<TestBoardItem>();

            Assert.Throws<Exception>(() => boardRegistry.Remove(position));
        }


        [Test]
        public void OnMoveItem_MovesItem()
        {
            var item = new TestBoardItem();
            var fromPosition = Vector2Int.one;
            var toPosition = Vector2Int.down;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item, fromPosition);
            boardRegistry.Move(item, toPosition);
            
            Assert.That(boardRegistry.Get(fromPosition) == null);
            Assert.That( boardRegistry.Get(toPosition) == item );
        }


        [Test]
        public void OnMoveItemToPositionWhereAnotherExists_ThrowsException()
        {
            var item1 = new TestBoardItem();
            var item2 = new TestBoardItem();
            var fromPosition = Vector2Int.one;
            var toPosition = Vector2Int.down;
            var boardRegistry = new BoardRegistry<TestBoardItem>();
            
            boardRegistry.Add(item1, fromPosition);
            boardRegistry.Add(item2, toPosition);
            
            Assert.Throws<Exception>(() => boardRegistry.Move(item1, toPosition));
        }
    }
}