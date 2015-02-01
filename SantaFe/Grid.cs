using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe
{
    class Grid
    {
        public List<List<bool>> grid;
        public int gridSize;
        public string gridFileName = "grid.txt";

        public Grid(int size)
        {
            gridSize = size;
            initializeGrid();
        }

        void initializeGrid()
        {
            grid = new List<List<bool>>(gridSize);
            for (int i = 0; i < gridSize; i++)
            {
                grid.Add(new List<bool>(gridSize));
                for (int j = 0; j < gridSize; j++)
                    grid[i].Add(false);
            }
        }

        public void resetGrid()
        {
            initializeGrid();
            loadGrid();
        }

        public bool getCell(int x, int y)
        {
            return grid.ElementAt(x).ElementAt(y);
        }

        public void setCell(int x, int y, bool setTo)
        {
            grid.ElementAt(x)[y] = setTo;
        }

        public Boolean isWithin(int x, int y)
        {
            return x < gridSize && y < gridSize;
        }

        public void saveGrid()
        {
            string toWrite="";
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (grid.ElementAt(i).ElementAt(j))
                        toWrite += "1";
                    else
                        toWrite += "0";
                }
                toWrite += "\n";
            }
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(gridFileName);
            }
            catch (FileNotFoundException e)//Is the file not there yet?
            {
                Console.WriteLine(e.StackTrace);
                File.Create(gridFileName).Dispose();//Creates file, if there's none existant yet
                writer = new StreamWriter(gridFileName);
            }

            if (writer == null)//File still not created? Something went wrong terribly.
            {
                MessageBox.Show("Bad things are happening, file with tests was not found, it's creation attempt failed");
                return;//Kill the method, the programmer must investigate what went to hell.
            }

            writer.Write(toWrite);

            writer.Close();

        }

        public void loadGrid()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(gridFileName);
            }
            catch (FileNotFoundException e)//Is the file not there yet?
            {
                Console.WriteLine(e.StackTrace);
                File.Create(gridFileName).Dispose();//Creates file, if there's none existant yet
                reader = new StreamReader(gridFileName);
            }

            if (reader == null)//File still not created? Something went wrong terribly.
            {
                MessageBox.Show("Bad things are happening, file with tests was not found, it's creation attempt failed");
                return;//Kill the method, the programmer must investigate what went to hell.
            }
            grid = new List<List<bool>>(gridSize);
            for (int x = 0; x < gridSize; x++)
            {
                grid.Add(new List<bool>(gridSize));
            }

            int i=0;

            while (!reader.EndOfStream)
            {
                string tmp = reader.ReadLine();
                for(int j=0;j<gridSize;j++)
                    if (tmp[j]=='1')
                        grid[i].Add(true);
                    else
                        grid[i].Add(false);

                i++;
            }

            reader.Close();
        }

        public void draw(PaintEventArgs e, int cellWidth)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Brush brush = new SolidBrush(Color.Gray);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    e.Graphics.DrawRectangle(pen, i * cellWidth, j * cellWidth, cellWidth, cellWidth);
                    if (getCell(i, j))
                        e.Graphics.FillRectangle(brush, i * cellWidth, j * cellWidth, cellWidth, cellWidth);
                }
            }

            pen.Dispose();
            brush.Dispose();
        }
        
    }
}
