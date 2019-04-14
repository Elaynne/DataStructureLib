using SortLib.Search;
using System.Collections.Generic;

namespace SortLib.Interface
{
    public interface ITree
    {
        /// <summary>
        /// Insert a value and salve the key for search
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Insert(int key, int value);

        /// <summary>
        /// Search the given value to remove
        /// </summary>
        /// <param name="value"></param>
        bool Remove(int value);

        /// <summary>
        /// Search the value on a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Node Search(int key);

        /// <summary>
        /// Insert a value and salve the key for search
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Insert(string key, string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        bool Remove(string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Node Search(string key);

        /// <summary>
        /// Display the route in order
        /// </summary>
        void InOrder();

        /// <summary>
        /// Display the route pre order
        /// </summary>
        void PreOrder();

        /// <summary>
        /// Display the route pos order
        /// </summary>
        void PosOrder();
    }
}