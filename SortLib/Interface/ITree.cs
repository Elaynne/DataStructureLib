using SortLib.Search;
using System.Collections.Generic;

namespace SortLib.Interface
{
    public interface ITree
    {
        /// <summary>
        /// Get the height of the node or the tree if index is null
        /// </summary>
        /// <param name="tree">The array of the tree</param>
        /// <param name="index">index of the node to evaluate height, if its null, it'll be 0 (the tree root)</param>
        /// <returns></returns>
        int GetHeight(int[] tree, int? index);

        /// <summary>
        /// Get the capacity of the tree's leafs  2^h
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        int GetLeafCapacity(int[] tree);

        /// <summary>
        /// Get all nodes of a given heght, the max number of node in a height 'h' is 2^h
        /// To Get all leafs, get the leafs from max(h)
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        List<Node> GetNodesAtHeight(int[] tree, int height);//validate heigth
        
        /// <summary>
        /// Capacity of a tree with a given height
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        int GetTreeCapacity(int height);
        
        void Insert(int value);
        void Remove(int value);
        void Search(int value);

        void InOrder();
        void PreOrder();
        void PosOrder();
    }
   

}