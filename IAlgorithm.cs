using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pathfinding
{
    interface IAlgorithm
    {
        Point[] GetShortestPath(Point start, Point end, Dictionary<Point, BlockType> fields);
        Point[] GetShortestPathAndNeighbours(Point start, Point end, Dictionary<Point, BlockType> fields, Action<Point, Color> markPoint);
    }
}
