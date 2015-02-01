using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SantaFe.EvolutionaryProgram;
using System.Timers;

namespace SantaFe
{
    public partial class Form1 : Form
    {
        Grid grid;
        //Used for drawing the grid, to see the width of the cell
        int cellWidth = 20;
        Evolution evolution;
        Ant ant;
        int generation = 0;
        int antIndex = 0;
        int step = 0;
        int maxSteps = 400;
        int maxPopulation = 500;
        int maxDepth = 5;
        Random random = new Random();
        System.Timers.Timer timer;


        public void resetGridAndAnt()
        {
            grid.resetGrid();
            ant.resetAnt();
        }

        public Form1()
        {
            InitializeComponent();

            SantaFe.EvolutionaryProgram.Program.random = random;
            Evolution.random = random;

            grid = new Grid(32);
            grid.loadGrid();

            ant = new Ant(grid);
            ant.x = 0; ant.y = 0;
            ant.form1 = this;
            evolution = new Evolution(maxPopulation, maxSteps, maxDepth, ant, this);
            fillListWithAnts();

            timer = new System.Timers.Timer(1000 / 30);
            timer.Elapsed += onTimer;
            timer.Enabled = true;
        }

        private void saveGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid.saveGrid();
        }

        private void loadGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid.loadGrid();
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            grid.draw(e, cellWidth);
            ant.draw(e, cellWidth);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            int gridX = x / cellWidth;
            int gridY = y / cellWidth;

            if (grid.isWithin(gridX, gridY))
            {
                if (grid.getCell(gridX, gridY))
                    grid.setCell(gridX, gridY, false);
                else
                    grid.setCell(gridX, gridY, true);
            }
            panel1.Refresh();
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            evolution.singleAction(getInputData(), 0);

            panel1.Refresh();
        }

        public InputData getInputData()
        {
            InputData inputData = new InputData();
            if (ant.x <= 0 && ant.orientation == Ant.Orientation.left)
                inputData.wallAhead = true;
            else if (ant.x >= grid.gridSize && ant.orientation == Ant.Orientation.right)
                inputData.wallAhead = true;
            else if (ant.y <= 0 && ant.orientation == Ant.Orientation.up)
                inputData.wallAhead = true;
            else if (ant.y >= grid.gridSize && ant.orientation == Ant.Orientation.down)
                inputData.wallAhead = true;
            else
                inputData.wallAhead = false;

            if (ant.orientation == Ant.Orientation.left && !inputData.wallAhead)
                if (grid.grid.ElementAt(ant.x - 1).ElementAt(ant.y))
                    inputData.foodAhead = true;
            else if (ant.orientation == Ant.Orientation.up && !inputData.wallAhead)
                if (grid.grid.ElementAt(ant.x).ElementAt(ant.y - 1))
                    inputData.foodAhead = true;
            else if (ant.orientation == Ant.Orientation.right && !inputData.wallAhead)
                if (grid.grid.ElementAt(ant.x + 1).ElementAt(ant.y))
                    inputData.foodAhead = true;
            else if (ant.orientation == Ant.Orientation.down && !inputData.wallAhead)
                if (grid.grid.ElementAt(ant.x).ElementAt(ant.y + 1))
                    inputData.foodAhead = true;

            return inputData;
        }

        private void buttonSetAntsOff_Click(object sender, EventArgs e)
        {
            Thread worker = new Thread(new ThreadStart(evolution.allActionsForCurrentGeneration));
            worker.Start();
        }

        private void buttonEvolveAnts_Click(object sender, EventArgs e)
        {
            evolution.evolve();
        }

        public void setAntIndex(int index)
        {
            antIndex = index;
            setAntIndexLabel(antIndex);
        }
        delegate void setAntIndexDelegate(int antIndex);
        void setAntIndexLabel(int antIndex)
        {
            if (labelAntIndex.InvokeRequired)
                labelAntIndex.Invoke(new setAntIndexDelegate(setAntIndexLabel), antIndex);
            else
                labelAntIndex.Text = antIndex.ToString();
        }

        public void setStep(int step)
        {
            this.step = step;
            setStepLabel(step);
        }

        delegate void setStepCounterDelegate(int step);
        void setStepLabel(int step)
        {
            if (labelStep.InvokeRequired)
                labelStep.Invoke(new setStepCounterDelegate(setStepLabel), step);
            else
                labelStep.Text = step.ToString();
        }

        private void buttonNextAnt_Click(object sender, EventArgs e)
        {
            if (antIndex >= maxPopulation - 1)
                antIndex = 0;
            else
                antIndex++;
            setAntIndexLabel(antIndex);

            this.Refresh();
        }

        private void buttonSetOffSingleAnt_Click(object sender, EventArgs e)
        {
            evolution.actionsForSingleAnt(antIndex);
        }

        private void doubleBufferPanelTreePanel_Paint(object sender, PaintEventArgs e)
        {
            evolution.getProgram(antIndex).draw(e);
        }

        void fillListWithAnts()
        {
            for (int i = 0; i < maxPopulation; i++)
            {
                ListViewItem item=new ListViewItem(i.ToString());
                item.SubItems.Add(evolution.getProgram(i).fitness.ToString());
                listViewAntsList.Items.Add(item);
            }
        }

        private delegate void refreshListDelegate(int index);
        public void refreshList(int index)
        {
            if (listViewAntsList.InvokeRequired)
                listViewAntsList.Invoke(new refreshListDelegate(refreshList),new object[]{index});
            else
            {
                ListViewItem item = listViewAntsList.Items[index];
                item.SubItems[1].Text = evolution.getProgram(index).fitness.ToString();
            }
                
        }

        private delegate void incrementGenerationDelegate();
        public void incrementGeneration()
        {
            if (labelGenerationNum.InvokeRequired)
                labelGenerationNum.Invoke(new incrementGenerationDelegate(incrementGeneration));
            else
            {
                generation += 1;
                labelGenerationNum.Text = generation.ToString();
            }
        }

        private void listViewAntsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count > 0)
            {
                antIndex = ((ListView)sender).SelectedItems[0].Index;
                labelAntIndex.Text = antIndex.ToString();
                labelFitness.Text = evolution.getProgram(antIndex).fitness.ToString();
                this.Refresh();
            }
        }

        private void buttonSelection_Click(object sender, EventArgs e)
        {
            evolution.select();
            this.Refresh();
        }

        private void buttonCrossover_Click(object sender, EventArgs e)
        {
            evolution.cross();
            this.Refresh();
        }

        private void buttonMutation_Click(object sender, EventArgs e)
        {
            evolution.mutate();
            this.Refresh();
        }

        private void buttonStartEvolution_Click(object sender, EventArgs e)
        {

            evolution.generationCount = Convert.ToInt32(numericUpDownNumberOfGenerations.Value);
            Thread worker = new Thread(new ThreadStart(evolution.runMultipleEvolutions));
            worker.Start();
        }
        
        delegate void refreshDelegate();
        void refresh()
        {
            if (this.InvokeRequired)
                this.Invoke(new refreshDelegate(refresh));
            else
                this.Refresh();
        }

        delegate void refreshMainDrawingPanelDelegate();
        public void refreshMainDrawingPanel()
        {
            if (panel1.InvokeRequired)
                panel1.Invoke(new refreshMainDrawingPanelDelegate(refreshMainDrawingPanel));
            else
                panel1.Refresh();
        }

        void onTimer(Object source, ElapsedEventArgs e)
        {
            refreshMainDrawingPanel();
        }

        private void radioButtonSlowAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                timer.Stop();
                ant.slowAnimation = true;
            }
            else
            {
                timer.Start();
                ant.slowAnimation = false;
            }
        }
        
    }
}
