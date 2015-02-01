namespace SantaFe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelGenerationNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSetAntsOff = new System.Windows.Forms.Button();
            this.buttonEvolveAnts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAntIndex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStep = new System.Windows.Forms.Label();
            this.buttonSetOffSingleAnt = new System.Windows.Forms.Button();
            this.buttonNextAnt = new System.Windows.Forms.Button();
            this.listViewAntsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.labelFitness = new System.Windows.Forms.Label();
            this.buttonSelection = new System.Windows.Forms.Button();
            this.buttonMutation = new System.Windows.Forms.Button();
            this.buttonCrossover = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStartEvolution = new System.Windows.Forms.Button();
            this.numericUpDownNumberOfGenerations = new System.Windows.Forms.NumericUpDown();
            this.radioButtonQuickAnimation = new System.Windows.Forms.RadioButton();
            this.radioButtonSlowAnimation = new System.Windows.Forms.RadioButton();
            this.doubleBufferPanelTreePanel = new SantaFe.DoubleBufferPanel();
            this.panel1 = new SantaFe.DoubleBufferPanel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfGenerations)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1811, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGridToolStripMenuItem,
            this.loadGridToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // saveGridToolStripMenuItem
            // 
            this.saveGridToolStripMenuItem.Name = "saveGridToolStripMenuItem";
            this.saveGridToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveGridToolStripMenuItem.Text = "Save grid";
            this.saveGridToolStripMenuItem.Click += new System.EventHandler(this.saveGridToolStripMenuItem_Click);
            // 
            // loadGridToolStripMenuItem
            // 
            this.loadGridToolStripMenuItem.Name = "loadGridToolStripMenuItem";
            this.loadGridToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.loadGridToolStripMenuItem.Text = "Load grid";
            this.loadGridToolStripMenuItem.Click += new System.EventHandler(this.loadGridToolStripMenuItem_Click);
            // 
            // labelGenerationNum
            // 
            this.labelGenerationNum.AutoSize = true;
            this.labelGenerationNum.Location = new System.Drawing.Point(727, 29);
            this.labelGenerationNum.Name = "labelGenerationNum";
            this.labelGenerationNum.Size = new System.Drawing.Size(13, 13);
            this.labelGenerationNum.TabIndex = 2;
            this.labelGenerationNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(659, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Generation:";
            // 
            // buttonSetAntsOff
            // 
            this.buttonSetAntsOff.Location = new System.Drawing.Point(6, 19);
            this.buttonSetAntsOff.Name = "buttonSetAntsOff";
            this.buttonSetAntsOff.Size = new System.Drawing.Size(98, 23);
            this.buttonSetAntsOff.TabIndex = 4;
            this.buttonSetAntsOff.Text = "Set ants off";
            this.buttonSetAntsOff.UseVisualStyleBackColor = true;
            this.buttonSetAntsOff.Click += new System.EventHandler(this.buttonSetAntsOff_Click);
            // 
            // buttonEvolveAnts
            // 
            this.buttonEvolveAnts.Location = new System.Drawing.Point(6, 48);
            this.buttonEvolveAnts.Name = "buttonEvolveAnts";
            this.buttonEvolveAnts.Size = new System.Drawing.Size(98, 23);
            this.buttonEvolveAnts.TabIndex = 0;
            this.buttonEvolveAnts.Text = "Evolve ants";
            this.buttonEvolveAnts.UseVisualStyleBackColor = true;
            this.buttonEvolveAnts.Click += new System.EventHandler(this.buttonEvolveAnts_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ant:";
            // 
            // labelAntIndex
            // 
            this.labelAntIndex.AutoSize = true;
            this.labelAntIndex.Location = new System.Drawing.Point(727, 42);
            this.labelAntIndex.Name = "labelAntIndex";
            this.labelAntIndex.Size = new System.Drawing.Size(13, 13);
            this.labelAntIndex.TabIndex = 6;
            this.labelAntIndex.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Step:";
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(727, 55);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(13, 13);
            this.labelStep.TabIndex = 8;
            this.labelStep.Text = "0";
            // 
            // buttonSetOffSingleAnt
            // 
            this.buttonSetOffSingleAnt.Location = new System.Drawing.Point(6, 19);
            this.buttonSetOffSingleAnt.Name = "buttonSetOffSingleAnt";
            this.buttonSetOffSingleAnt.Size = new System.Drawing.Size(98, 23);
            this.buttonSetOffSingleAnt.TabIndex = 9;
            this.buttonSetOffSingleAnt.Text = "Set ant off";
            this.buttonSetOffSingleAnt.UseVisualStyleBackColor = true;
            this.buttonSetOffSingleAnt.Click += new System.EventHandler(this.buttonSetOffSingleAnt_Click);
            // 
            // buttonNextAnt
            // 
            this.buttonNextAnt.Location = new System.Drawing.Point(6, 48);
            this.buttonNextAnt.Name = "buttonNextAnt";
            this.buttonNextAnt.Size = new System.Drawing.Size(98, 23);
            this.buttonNextAnt.TabIndex = 10;
            this.buttonNextAnt.Text = "Next Ant";
            this.buttonNextAnt.UseVisualStyleBackColor = true;
            this.buttonNextAnt.Click += new System.EventHandler(this.buttonNextAnt_Click);
            // 
            // listViewAntsList
            // 
            this.listViewAntsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewAntsList.GridLines = true;
            this.listViewAntsList.LabelWrap = false;
            this.listViewAntsList.Location = new System.Drawing.Point(846, 29);
            this.listViewAntsList.Name = "listViewAntsList";
            this.listViewAntsList.Size = new System.Drawing.Size(84, 354);
            this.listViewAntsList.TabIndex = 12;
            this.listViewAntsList.UseCompatibleStateImageBehavior = false;
            this.listViewAntsList.View = System.Windows.Forms.View.Details;
            this.listViewAntsList.SelectedIndexChanged += new System.EventHandler(this.listViewAntsList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ant";
            this.columnHeader1.Width = 31;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fitness";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(659, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fitness:";
            // 
            // labelFitness
            // 
            this.labelFitness.AutoSize = true;
            this.labelFitness.Location = new System.Drawing.Point(727, 68);
            this.labelFitness.Name = "labelFitness";
            this.labelFitness.Size = new System.Drawing.Size(13, 13);
            this.labelFitness.TabIndex = 14;
            this.labelFitness.Text = "0";
            // 
            // buttonSelection
            // 
            this.buttonSelection.Location = new System.Drawing.Point(6, 19);
            this.buttonSelection.Name = "buttonSelection";
            this.buttonSelection.Size = new System.Drawing.Size(98, 23);
            this.buttonSelection.TabIndex = 15;
            this.buttonSelection.Text = "Selection";
            this.buttonSelection.UseVisualStyleBackColor = true;
            this.buttonSelection.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // buttonMutation
            // 
            this.buttonMutation.Location = new System.Drawing.Point(6, 77);
            this.buttonMutation.Name = "buttonMutation";
            this.buttonMutation.Size = new System.Drawing.Size(98, 23);
            this.buttonMutation.TabIndex = 16;
            this.buttonMutation.Text = "Mutation";
            this.buttonMutation.UseVisualStyleBackColor = true;
            this.buttonMutation.Click += new System.EventHandler(this.buttonMutation_Click);
            // 
            // buttonCrossover
            // 
            this.buttonCrossover.Location = new System.Drawing.Point(6, 48);
            this.buttonCrossover.Name = "buttonCrossover";
            this.buttonCrossover.Size = new System.Drawing.Size(98, 23);
            this.buttonCrossover.TabIndex = 17;
            this.buttonCrossover.Text = "Crossover";
            this.buttonCrossover.UseVisualStyleBackColor = true;
            this.buttonCrossover.Click += new System.EventHandler(this.buttonCrossover_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSetOffSingleAnt);
            this.groupBox1.Controls.Add(this.buttonNextAnt);
            this.groupBox1.Location = new System.Drawing.Point(662, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 81);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "One Ant";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSelection);
            this.groupBox2.Controls.Add(this.buttonMutation);
            this.groupBox2.Controls.Add(this.buttonCrossover);
            this.groupBox2.Location = new System.Drawing.Point(662, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 115);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "One Generation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSetAntsOff);
            this.groupBox3.Controls.Add(this.buttonEvolveAnts);
            this.groupBox3.Location = new System.Drawing.Point(662, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 82);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "One generation, multiple ants";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.buttonStartEvolution);
            this.groupBox4.Controls.Add(this.numericUpDownNumberOfGenerations);
            this.groupBox4.Location = new System.Drawing.Point(662, 389);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 97);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Multiple generations, multiple ants";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Generations:";
            // 
            // buttonStartEvolution
            // 
            this.buttonStartEvolution.Location = new System.Drawing.Point(6, 63);
            this.buttonStartEvolution.Name = "buttonStartEvolution";
            this.buttonStartEvolution.Size = new System.Drawing.Size(92, 23);
            this.buttonStartEvolution.TabIndex = 1;
            this.buttonStartEvolution.Text = "Start Evolution";
            this.buttonStartEvolution.UseVisualStyleBackColor = true;
            this.buttonStartEvolution.Click += new System.EventHandler(this.buttonStartEvolution_Click);
            // 
            // numericUpDownNumberOfGenerations
            // 
            this.numericUpDownNumberOfGenerations.Location = new System.Drawing.Point(79, 37);
            this.numericUpDownNumberOfGenerations.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownNumberOfGenerations.Name = "numericUpDownNumberOfGenerations";
            this.numericUpDownNumberOfGenerations.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownNumberOfGenerations.TabIndex = 0;
            this.numericUpDownNumberOfGenerations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // radioButtonQuickAnimation
            // 
            this.radioButtonQuickAnimation.AutoSize = true;
            this.radioButtonQuickAnimation.Checked = true;
            this.radioButtonQuickAnimation.Location = new System.Drawing.Point(662, 511);
            this.radioButtonQuickAnimation.Name = "radioButtonQuickAnimation";
            this.radioButtonQuickAnimation.Size = new System.Drawing.Size(101, 17);
            this.radioButtonQuickAnimation.TabIndex = 22;
            this.radioButtonQuickAnimation.TabStop = true;
            this.radioButtonQuickAnimation.Text = "Quick animation";
            this.radioButtonQuickAnimation.UseVisualStyleBackColor = true;
            // 
            // radioButtonSlowAnimation
            // 
            this.radioButtonSlowAnimation.AutoSize = true;
            this.radioButtonSlowAnimation.Location = new System.Drawing.Point(662, 534);
            this.radioButtonSlowAnimation.Name = "radioButtonSlowAnimation";
            this.radioButtonSlowAnimation.Size = new System.Drawing.Size(96, 17);
            this.radioButtonSlowAnimation.TabIndex = 23;
            this.radioButtonSlowAnimation.Text = "Slow animation";
            this.radioButtonSlowAnimation.UseVisualStyleBackColor = true;
            this.radioButtonSlowAnimation.CheckedChanged += new System.EventHandler(this.radioButtonSlowAnimation_CheckedChanged);
            // 
            // doubleBufferPanelTreePanel
            // 
            this.doubleBufferPanelTreePanel.AutoScroll = true;
            this.doubleBufferPanelTreePanel.AutoSize = true;
            this.doubleBufferPanelTreePanel.Location = new System.Drawing.Point(936, 29);
            this.doubleBufferPanelTreePanel.Name = "doubleBufferPanelTreePanel";
            this.doubleBufferPanelTreePanel.Size = new System.Drawing.Size(863, 703);
            this.doubleBufferPanelTreePanel.TabIndex = 11;
            this.doubleBufferPanelTreePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.doubleBufferPanelTreePanel_Paint);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 641);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1811, 744);
            this.Controls.Add(this.radioButtonSlowAnimation);
            this.Controls.Add(this.radioButtonQuickAnimation);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelFitness);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewAntsList);
            this.Controls.Add(this.doubleBufferPanelTreePanel);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAntIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelGenerationNum);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfGenerations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGridToolStripMenuItem;
        private System.Windows.Forms.Label labelGenerationNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetAntsOff;
        private System.Windows.Forms.Button buttonEvolveAnts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAntIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStep;
        public DoubleBufferPanel panel1;
        private System.Windows.Forms.Button buttonSetOffSingleAnt;
        private System.Windows.Forms.Button buttonNextAnt;
        private DoubleBufferPanel doubleBufferPanelTreePanel;
        private System.Windows.Forms.ListView listViewAntsList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelFitness;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonSelection;
        private System.Windows.Forms.Button buttonMutation;
        private System.Windows.Forms.Button buttonCrossover;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStartEvolution;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfGenerations;
        private System.Windows.Forms.RadioButton radioButtonQuickAnimation;
        private System.Windows.Forms.RadioButton radioButtonSlowAnimation;
    }
}

