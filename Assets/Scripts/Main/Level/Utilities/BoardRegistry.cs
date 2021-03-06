using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BBX.Main.Level.Interfaces;
using BBX.Utility;

namespace BBX.Main.Level.Utilities
{
    public class BoardRegistry<T> where T : IBoardItem
    {
        public List<T> Items { get; }


        public BoardRegistry()
        {
            Items = new List<T>();
        }
        
        
        public BoardRegistry(List<T> items)
        {
            Items = items;
        }

        
        /// <summary>
        /// Add a new item
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Add(T item)
        {
            if (Exists(item))
            {
                ExceptionLogger.Exception($"Tried to add same item of type {typeof(T)} to the registry twice!");
            }
            
            if (Exists(item.Position))
            {
                ExceptionLogger.Exception($"Tried to add {typeof(T)} at position where one already exists ({item.Position})");
            }
            
            Items.Add(item);
        }

        
        /// <summary>
        /// Get an item at a position
        /// </summary>
        /// <param name="at"></param>
        /// <returns></returns>
        public T Get(Vector2Int at)
        {
            return Items.FirstOrDefault(x => x.Position == at);
        }


        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Remove(T item)
        {
            if (!Items.Remove(item))
            {
                ExceptionLogger.Exception( $"Tried to get remove {typeof(T)} but the object does not exist on the board" );
            }
        }

        
        /// <summary>
        /// Remove an item at a position
        /// </summary>
        /// <param name="at"></param>
        /// <exception cref="Exception"></exception>
        public void Remove(Vector2Int at)
        {
            var item = Get(at);
            
            if (item == null)
            {
                ExceptionLogger.Exception( $"Tried to remove item at {at} but no item exists in this position" );
            }
            
            Items.Remove(item);
        }

        
        /// <summary>
        /// Check an item exists at a position
        /// </summary>
        /// <param name="at"></param>
        /// <returns></returns>
        public bool Exists(Vector2Int at)
        {
            return Items.FirstOrDefault(x => x.Position == at) != null;
        }
        
        
        /// <summary>
        /// Check an item exists
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Exists(T item)
        {
            return Items.Contains(item);
        }
    }
}