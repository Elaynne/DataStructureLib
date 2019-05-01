using SortLib.Search;
using System.Collections.Generic;

namespace SortLib.Interface
{
    public interface ITree<T, G>
    {
        /// <summary>
        /// Insert a value and salve the key for search
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Insert(T key, G value);

        /// <summary>
        /// Search the given value to remove
        /// </summary>
        /// <param name="value"></param>
        bool Remove(T key);

        /// <summary>
        /// Search the value on a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Node<T, G> Search(T key);

        /// <summary>
        /// Display the route in order
        /// </summary>
        string InOrder();

        /// <summary>
        /// Display the route pre order
        /// </summary>
        string PreOrder();

        /// <summary>
        /// Display the route pos order
        /// </summary>
        string PosOrder();
    }
}