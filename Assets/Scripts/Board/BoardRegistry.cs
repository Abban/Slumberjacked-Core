using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BBX.Board
{
    public class BoardRegistry<T> where T : class
    {
        private readonly Dictionary<Vector2Int, T> _items;

        
        public BoardRegistry()
        {
            _items = new Dictionary<Vector2Int, T>();
        }
        
        
        public BoardRegistry(Dictionary<Vector2Int, T> items)
        {
            _items = items;
        }

        
        /// <summary>
        /// Add a new item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="at"></param>
        /// <exception cref="Exception"></exception>
        public void Add(T item, Vector2Int at)
        {
            if (Exists(at))
            {
                throw new Exception( $"Tried to add {typeof(T)} at position where one already exists ({at})" );
            }
            
            if (Exists(item))
            {
                throw new Exception( $"Tried to add same item of type {typeof(T)} to the registry twice!" );
            }
            
            _items.Add(at, item);
        }

        
        /// <summary>
        /// Get an item at a position
        /// </summary>
        /// <param name="at"></param>
        /// <returns></returns>
        public T Get(Vector2Int at)
        {
            if (Exists(at))
            {
                return _items[at];
            }

            return null;
        }
        
        
        /// <summary>
        /// Get the position of an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Vector2Int GetPosition(T item)
        {
            var itemRow = _items.FirstOrDefault(x => x.Value == item);

            if (itemRow.Value == null)
            {
                throw new Exception( $"Tried to get position of {typeof(T)} but the object does not exist on the board" );
            }

            return itemRow.Key;
        }

        
        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Remove(T item)
        {
            var itemRow = _items.FirstOrDefault(x => x.Value == item);
            
            if (itemRow.Value == null)
            {
                throw new Exception( $"Tried to get remove {typeof(T)} but the object does not exist on the board" );
            }
            
            Remove(itemRow.Key);
        }

        
        /// <summary>
        /// Remove an item at a position
        /// </summary>
        /// <param name="at"></param>
        /// <exception cref="Exception"></exception>
        public void Remove(Vector2Int at)
        {
            if (!Exists(at))
            {
                throw new Exception( $"Tried to remove item at {at} but no item exists in this position" );
            }
            
            _items.Remove(at);
        }

        
        /// <summary>
        /// Check an item exists at a position
        /// </summary>
        /// <param name="at"></param>
        /// <returns></returns>
        public bool Exists(Vector2Int at)
        {
            return _items.ContainsKey(at);
        }
        
        
        /// <summary>
        /// Check an item exists
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Exists(T item)
        {
            return _items.FirstOrDefault(x => x.Value == item).Value != null;
        }

        
        /// <summary>
        /// Move an item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="to"></param>
        /// <exception cref="Exception"></exception>
        public void Move(T item, Vector2Int to)
        {
            if (Exists(to))
            {
                throw new Exception($"Tried to move an item to a place where another item exists {to}");
            }
            
            Remove(item);
            Add(item, to);
        }
    }
}