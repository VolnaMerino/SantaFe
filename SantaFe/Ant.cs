using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SantaFe
{

    class Ant
    {
        public Grid grid;
        public int foodEaten = 0;
        public Form1 form1;
        public bool slowAnimation = false;

        public Ant(Grid grid)
        { 
            this.grid = grid;
        }

        public void eatFood(int x,int y)
        {
            grid.setCell(x, y, false);
            foodEaten++;
        }

        public enum Orientation 
        { 
            left=0,
            up=1,
            right=2,
            down=3
        };
        public int x;
        public int y;
        public Orientation orientation;

        void refreshMainPanel()
        {
            if(slowAnimation)
                form1.refreshMainDrawingPanel();
        }

        public void turnLeft()
        {
            if (orientation == Orientation.down)
                orientation = Orientation.left;
            else
                orientation++;

            refreshMainPanel();
        }
        public void turnRight()
        {
            if (orientation == Orientation.left)
                orientation = Orientation.down;
            else
                orientation--;

            refreshMainPanel();
        }
        public void goForward()
        {
            switch (orientation)
            {
                case Orientation.left: if(x>0) x--; break;
                case Orientation.up: if(y<grid.gridSize-1) y++; break;
                case Orientation.right: if(x<grid.gridSize-1) x++; break;
                case Orientation.down: if(y>0) y--; break;
            }
            if (grid.getCell(x, y))
            {
                eatFood(x,y);
            }

            refreshMainPanel();
        }
        delegate void refreshMainFormDelegate();
        void refreshMainForm()
        {
            if (form1.InvokeRequired)
                form1.Invoke(new refreshMainFormDelegate(goForward));
            else
                form1.Refresh();
        }

        public void resetAnt()
        {
            foodEaten = 0;
            x = 0;
            y = 0;
        }

        public void draw(PaintEventArgs e, int cellWidth)
        {
            Point a = new Point(0, 0);
            Point b = new Point(0, 0);
            Point c = new Point(0, 0);
            switch (orientation)
            {
                case Ant.Orientation.left:
                    a.X = x * cellWidth;
                    a.Y = y * cellWidth + cellWidth / 2;
                    b.X = x * cellWidth + cellWidth;
                    b.Y = y * cellWidth;
                    c.X = x * cellWidth + cellWidth;
                    c.Y = y * cellWidth + cellWidth;
                    break;
                case Orientation.up:
                    a.X = x * cellWidth + cellWidth / 2;
                    a.Y = y * cellWidth;
                    b.X = x * cellWidth;
                    b.Y = y * cellWidth + cellWidth;
                    c.X = x * cellWidth + cellWidth;
                    c.Y = y * cellWidth + cellWidth;
                    break;
                case Orientation.right:
                    a.X = x * cellWidth + cellWidth;
                    a.Y = y * cellWidth + cellWidth / 2;
                    b.X = x * cellWidth;
                    b.Y = y * cellWidth;
                    c.X = x * cellWidth;
                    c.Y = y * cellWidth + cellWidth;
                    break;
                case Orientation.down:
                    a.X = x * cellWidth + cellWidth / 2;
                    a.Y = y * cellWidth + cellWidth;
                    b.X = x * cellWidth;
                    b.Y = y * cellWidth;
                    c.X = x * cellWidth + cellWidth;
                    c.Y = y * cellWidth;
                    break;
            }
            Point[] points = { a, b, c };
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.FillPolygon(brush, points);
            brush.Dispose();
        }
    }
}
