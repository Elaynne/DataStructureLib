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
        void Insert(object key, object value);

        /// <summary>
        /// Search the given value to remove
        /// </summary>
        /// <param name="value"></param>
        bool Remove(object key);

        /// <summary>
        /// Search the value on a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Node Search(object key);

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