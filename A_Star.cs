using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pathfinding
{
    class A_Star : IAlgorithm
    {
        Dictionary<Point, Node> openList = new Dictionary<Point, Node>();
        Dictionary<Point, Node> closedList = new Dictionary<Point, Node>();

        public Point[] GetShortestPath(Point start, Point end, Dictionary<Point, BlockType> fields)
        {
            return GetShortestPathAndNeighbours(start, end, fields, null);
        }

        public Point[] GetShortestPathAndNeighbours(Point start, Point end, Dictionary<Point, BlockType> fields, Action<Point, Color> markPoint)
        {
            openList.Clear();
            closedList.Clear();

            // Create start point
            Node firstNode = new Node(start, BlockType.StartBlock);
            Node currentNode = firstNode;

            // Move to next point until we arrive at the end
            while (currentNode.position != end)
            {
                // Go through all nodes we can go from the current node
                Node[] neighbourNodes = currentNode.GetNeighbours(fields);
                for (int i = 0; i < neighbourNodes.Length; i++)
                {
                    // If the node is not already checked, calculate it's distance to the end
                    if (!closedList.ContainsKey(neighbourNodes[i].position) && neighbourNodes[i].type != BlockType.WallBlock)
                    {
                        neighbourNodes[i].distanceFromStart = currentNode.distanceFromStart + 1;

                        if (openList.ContainsKey(neighbourNodes[i].position))
                        {
                            double listedDistance = openList[neighbourNodes[i].position].distanceFromStart;
                            double myDistance = neighbourNodes[i].distanceFromStart;

                            if (myDistance >= listedDistance)
                                continue;
                            else
                                openList.Remove(neighbourNodes[i].position);

                        }
                        
                        neighbourNodes[i].fValue = neighbourNodes[i].distanceFromStart + neighbourNodes[i].GetDistanceTo(currentNode.position) + neighbourNodes[i].GetDistanceTo(end);
                        neighbourNodes[i].lastNode = currentNode;
                        openList.Add(neighbourNodes[i].position, neighbourNodes[i]);
                    }
                }
                
                // Draw if drawing is needed
                if (markPoint != null)
                    markPoint(currentNode.position, Color.White);

                // Mark current node as checked
                closedList.Add(currentNode.position, currentNode);
                openList.Remove(currentNode.position);

                // If we have more nodes to go to
                if (openList.Count != 0)
                {
                    // Select the one closest to the target
                    Node nextNode = null;
                    foreach (Node node in openList.Values)
                    {
                        if (nextNode == null || node.fValue < nextNode.fValue)
                            nextNode = node;
                    }

                    currentNode = nextNode;
                }
                else
                {
                    throw new Exception("RIP");
                }
            }

            List<Point> points = new List<Point>();
            while (currentNode.lastNode != null)
            {
                points.Add(currentNode.position);
                currentNode = currentNode.lastNode;
            }

            return points.ToArray();
        }
    }

    class Node
    {
        public Point position;
        public double fValue; //a* points
        public BlockType type;
        public Node lastNode;
        public double distanceFromStart = 0d;

        public Node(Point pos, BlockType t)
        {
            position = pos;
            fValue = -1;
            type = t;
        }

        public double GetDistanceTo(Point goal) //rough distance, ignores walls
        {
            double x = Math.Abs(position.X - goal.X);
            double y = Math.Abs(position.Y - goal.Y);
            return Math.Sqrt(x * x + y * y);
        }

        public Node[] GetNeighbours(Dictionary<Point, BlockType> fieldTypes)
        { 
            List<Node> neighbourPoints = new List<Node>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (position.X + i >= 0 && position.Y + j >= 0)
                    {
                        if (!(i == 0 && j == 0))
                        {
                            Point p = new Point(position.X + i, position.Y + j);
                            BlockType type = BlockType.None;
                            if (fieldTypes.ContainsKey(p)) type = fieldTypes[p];
                            neighbourPoints.Add(new Node(p, type));
                        }
                    }
                }
            }

            return neighbourPoints.ToArray();
        }
    }
}
