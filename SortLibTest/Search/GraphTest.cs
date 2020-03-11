using Xunit;
using SortLib.Search;
using System;
using System.Text;

namespace SortLibTest.Search
{
    public class GraphTest
    {
        private readonly int[] vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private readonly Tuple<int,int>[] edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

        [Fact]
        public void DeepFirstSearchTest()
        {
            //Arrange
            var graph = new Graph<int>(vertices, edges);
            var search = new GraphSearch();
            //Act
            string result = new StringBuilder(string.Join(", ", search.DeepFirstSearch(graph, 1))).ToString();
            // Assert
            Assert.Equal("1, 3, 6, 5, 8, 9, 10, 7, 4, 2", result);
        }


        [Fact]
        public void BreadthFirstSearchTest()
        {
            //Arrange
            var graph = new Graph<int>(vertices, edges);
            var search = new GraphSearch();
            //Act
            string result = new StringBuilder(string.Join(", ", search.BreadthFirstSearch(graph, 1))).ToString();
            // Assert
            Assert.Equal("1, 2, 3, 4, 5, 6, 7, 8, 9, 10", result);
        }

        [Fact]
        public void ShortestPath()
        {
            //Arrange
            var graph = new Graph<int>(vertices, edges);
            var search = new GraphSearch();
            //Act
            var result = search.ShortestPath(graph, 1);
            string shortestPath = string.Empty;
            // Assert 
            shortestPath = (string.Join(", ", result(7)));
            Assert.Equal("1, 2, 4, 7", shortestPath);
        }
    }
}
