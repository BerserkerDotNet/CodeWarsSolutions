using System.Collections.Generic;
using System.Linq;
using Solutions.Infrastructure;

namespace Solutions.SortBinaryTreeByLevels
{
    public class SortBinaryTreeByLevels : ISolution
    {
        const int LevelIncrease = 10000;
        public string DisplayName => "Sort binary tree by levels";

        public void Execute(IHost host)
        {
            throw new System.NotImplementedException();
        }

        public List<int> TreeByLevels(Node node)
        {
            var result = new Dictionary<int, int>();
            if (node == null)
            {
                return result.Values.ToList();
            }

            AddNodeChildren(node, result, 0);
            var sordetList = result.Keys.OrderBy(k => k).Select(k=> result[k]).ToList();
            return sordetList;
        }

        private void AddNodeChildren(Node node, Dictionary<int, int> result, int levelIndex)
        {
            var indexies = result.Keys.Where(k => k >= levelIndex * LevelIncrease && k < (levelIndex + 1) * LevelIncrease);
            var nextAvailableNumber = indexies.Any() ? indexies.Max() + 1 : levelIndex * LevelIncrease;
            result.Add(nextAvailableNumber, node.Value);
            if (node.Left != null)
            {
                AddNodeChildren(node.Left, result, levelIndex + 1);
            }

            if (node.Right != null)
            {
                AddNodeChildren(node.Right, result, levelIndex + 1);
            }
        }
    }

    public class Node
    {
        public Node Left;
        public Node Right;
        public int Value;

        public Node(int value)
            : this(null, null, value)
        {
        }

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }
}