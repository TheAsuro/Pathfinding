using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinding
{
    public partial class WorldDisplay : Form
    {
        private Dictionary<Point, BlockInfo> fields = new Dictionary<Point, BlockInfo>();
        const int fieldSize = 16;

        private Point startPoint;
        public Point StartPoint { get { return startPoint; } }
        private Point endPoint;
        public Point EndPoint { get { return endPoint; } }
        private List<Point> obstaclePoints = new List<Point>();

        private Form1 parentForm;

        public WorldDisplay(Form1 parent)
        {
            InitializeComponent();

            parentForm = parent;
        }

        private void SetStartPoint(Point p)
        {
            SetField(startPoint, new BlockInfo(BlockType.None));
            startPoint = p;
            SetField(startPoint, new BlockInfo(BlockType.StartBlock));
        }

        private void SetEndPoint(Point p)
        {
            SetField(endPoint, new BlockInfo(BlockType.None));
            endPoint = p;
            SetField(endPoint, new BlockInfo(BlockType.EndBlock));
        }

        private void RemovePoint(Point p)
        {
            if (startPoint == p)
                SetField(startPoint, new BlockInfo(BlockType.None));
            if (endPoint == p)
                SetField(endPoint, new BlockInfo(BlockType.None));

            RemoveObstacleAt(p);
        }

        private void ToggleObstacle(Point p)
        {
            if (obstaclePoints.Contains(p))
            {
                obstaclePoints.Remove(p);
            }
            else
            {
                AddObstaclePoint(p);
            }
        }

        private void AddObstaclePoint(Point p)
        {
            obstaclePoints.Add(p);
            SetField(p, new BlockInfo(BlockType.WallBlock));
        }

        private void RemoveObstacleAt(Point p)
        {
            Point removePoint = Point.Empty;
            obstaclePoints.ForEach((Point listedPoint) => { if (listedPoint.Equals(p)) removePoint = listedPoint; });
            if (removePoint == Point.Empty)
                return;

            obstaclePoints.Remove(removePoint);
            SetField(removePoint, new BlockInfo(BlockType.None));
        }

        public void AddMarkedPoint(Point p, Color color)
        {
            if (!fields.ContainsKey(p) || (fields.ContainsKey(p) && (fields[p].type == BlockType.None || fields[p].type == BlockType.MarkerBlock)))
            {
                BlockInfo bInfo = new BlockInfo(BlockType.MarkerBlock);
                bInfo.color = color;
                SetField(p, bInfo);
            }
        }

        private void SetField(Point p, BlockInfo type)
        {
            if (p.X < 0 || p.Y < 0)
                throw new InvalidOperationException("Field values out of bounds!");

            if (fields.ContainsKey(p))
            {
                fields.Remove(p);
            }
            fields[p] = type;
                
            this.OnPaint(new PaintEventArgs(this.CreateGraphics(), this.Bounds));
        }

        private void DrawFields(Graphics g)
        {
            foreach (KeyValuePair<Point, BlockInfo> pair in fields)
            {   
                DrawField(g, pair.Key, pair.Value.color);
            }
        }

        private void DrawField(Graphics g, Point p, Color color)
        {
            Brush brush = new SolidBrush(color);

            Rectangle rect = new Rectangle(p.X * fieldSize, p.Y * fieldSize, fieldSize - 1, fieldSize - 1);
            g.FillRectangle(brush, rect);
        }

        private void WorldDisplay_Paint(object sender, PaintEventArgs e)
        {
            DrawFields(e.Graphics);
        }

        private void WorldDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            Point cursorPos = this.PointToClient(Cursor.Position);
            Point targetField = new Point(cursorPos.X / fieldSize, cursorPos.Y / fieldSize);
            switch(parentForm.SelectedBlockType)
            {
                case BlockType.StartBlock:
                    SetStartPoint(targetField);
                    break;
                case BlockType.WallBlock:
                    ToggleObstacle(targetField);
                    break;
                case BlockType.EndBlock:
                    SetEndPoint(targetField);
                    break;
                case BlockType.None:
                    RemovePoint(targetField);
                    break;
                    
            }

            this.OnPaint(new PaintEventArgs(this.CreateGraphics(), this.Bounds));
        }

        public void ClearMarkers()
        {
            List<Point> fieldsToClear = new List<Point>();
            foreach (KeyValuePair<Point, BlockInfo> field in fields)
            {
                if (field.Value.type == BlockType.MarkerBlock)
                {
                    fieldsToClear.Add(field.Key);
                }
            }
            foreach (Point key in fieldsToClear)
            {
                SetField(key, new BlockInfo(BlockType.None));
            }
        }

        public Dictionary<Point, BlockType> GetFieldTypes()
        {
            Dictionary<Point, BlockType> dict = new Dictionary<Point, BlockType>();
            foreach (KeyValuePair<Point, BlockInfo> pair in fields)
            {
                dict.Add(pair.Key, pair.Value.type);
            }
            return dict;
        }

        private struct BlockInfo
        {
            public BlockInfo(BlockType blockType)
            {
                type = blockType;

                switch (type)
                {
                    case BlockType.StartBlock:
                        color = Color.Orange; break;
                    case BlockType.WallBlock:
                        color = Color.Gray; break;
                    case BlockType.EndBlock:
                        color = Color.LightGreen; break;
                    case BlockType.MarkerBlock:
                        color = Color.LightBlue; break;
                    default:
                        color = Color.Green; break; 
                }
            }

            public Color color;
            public BlockType type;
        }
    }
}

public enum BlockType
{
    StartBlock,
    WallBlock,
    EndBlock,
    MarkerBlock,
    None
}