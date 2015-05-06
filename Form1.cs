using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Pathfinding
{
    public partial class Form1 : Form
    {
        private WorldDisplay display;
        private static IAlgorithm pathfindingAlgorithm;

        public Form1()
        {
            InitializeComponent();

            display = new WorldDisplay(this);
            display.Show();
        }

        public BlockType SelectedBlockType
        {
            get
            {
                if (rbStart.Checked)
                    return BlockType.StartBlock;
                if (rbWall.Checked)
                    return BlockType.WallBlock;
                if (rbEnd.Checked)
                    return BlockType.EndBlock;
                if (rbNone.Checked)
                    return BlockType.None;

                return BlockType.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display.Show();
        }

        private void bnStart_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => CalculatePath(display.StartPoint, display.EndPoint));
        }

        private void CalculatePath(Point start, Point end)
        {
            display.ClearMarkers();
            SelectAlgorithmFromGui();

            Dictionary<Point, BlockType> fieldTypes = display.GetFieldTypes();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            pathfindingAlgorithm.GetShortestPath(start, end, fieldTypes);
            sw.Stop();
            MessageBox.Show(sw.ElapsedTicks + " ticks\n" + sw.ElapsedMilliseconds + " ms");

            Point[] path = pathfindingAlgorithm.GetShortestPathAndNeighbours(start, end, fieldTypes, (Point p, Color c) => display.AddMarkedPoint(p, c));

            for (int i = 0; i < path.Length; i++)
            {
                display.AddMarkedPoint(path[i], Color.LightBlue);
            }
        }

        private void SelectAlgorithmFromGui()
        {
            if (rbAStar.Checked)
                pathfindingAlgorithm = new A_Star();
        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            display.ClearMarkers();
        }
    }
}
