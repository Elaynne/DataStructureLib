using System;
using System.Collections.Generic;

namespace SortLib.Search
{
    /// <summary>
    /// This Graph was build by https://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public Graph()
        { }
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T,T>> edges)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach (var edge in edges)
            {
                AddEdges(edge);
            }
        }

        private void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }
        private void AddEdges(Tuple<T,T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

    }

    public class GraphSearch
    {
        public HashSet<T> DeepFirstSearch<T>(Graph<T> graph, T initialVertex)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(initialVertex))
                return visited;

            var stack = new SortLib.Collections.Stack<T>();
            stack.Push(initialVertex);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (visited.Contains(vertex))
                    continue;
                
                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }
            return visited;
        }

        public HashSet<T> BreadthFirstSearch<T>(Graph<T> graph, T initialVertex)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(initialVertex))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(initialVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                { 
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
            return visited;
        }
    }
}
