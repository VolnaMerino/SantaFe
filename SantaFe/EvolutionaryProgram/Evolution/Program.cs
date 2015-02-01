using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SantaFe.EvolutionaryProgram.Implements.Functions;
using SantaFe.EvolutionaryProgram.Implements.Terminals;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram
{
    class Program
    {
        public TreeNode root;
        int maxDepth;
        Ant ant;
        public static Random random;
        public int fitness = 0;
        public int depth = 0;

        public Program(int maxDepth, Ant ant)
        {
            this.maxDepth = maxDepth;
            this.ant = ant;
            fitness = 0;

            TreeNode.ant = ant;

            root = initializeTree(maxDepth);
        }

        public Program()
        {
        }

        public Program clone()
        {
            Program newProgram = new Program();
            newProgram.maxDepth = maxDepth;
            newProgram.ant = ant;
            newProgram.root = root.clone(null);

            return newProgram;
        }

        public TreeNode initializeTree(int maxDepth)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            nodeList.Add(getRandomFunction());

            TreeNode ret = nodeList[0];
            //We make the tree level by level, first levels we fill with functions, the last level we fill with terminals, after the for loop
            for (int i = 0; i < maxDepth - 1; i++)
            {
                bool addedFunction = false;
                for (int j = 0; j < nodeList.Count; j++)
                {
                    
                    TreeNode node = nodeList[j];
                    if (node is Function)
                    {
                        node.left = getRandomNode();
                        node.left.parent = node;
                        node.right = getRandomNode();
                        node.right.parent = node;
                        if (node.left is Function || node.right is Function)
                            addedFunction = true;
                        if (node is Progn3)
                        {
                            node.middle = getRandomNode();
                            node.middle.parent = node;
                            if (node.middle is Function)
                                addedFunction = true;
                        }

                    }
                }
                if (!addedFunction)
                {
                    nodeList = replaceRandomChildTerminalWithFunction(nodeList);
                }
                nodeList = getChildren(nodeList);
                depth++;
            }

            for (int i = 0; i < nodeList.Count; i++)
            {
                TreeNode node = nodeList[i];
                node.left = getRandomTerminal();
                node.left.parent = node;
                node.right = getRandomTerminal();
                node.right.parent = node;
                if (node is Progn3)
                {
                    node.middle = getRandomTerminal();
                    node.middle.parent = node;
                }

                
            }
            depth++;
            return ret;
        }

        public List<TreeNode> replaceRandomChildTerminalWithFunction(List<TreeNode> input)
        {
            TreeNode randomNode;
            do{
                 randomNode = input.ElementAt(random.Next(input.Count));
            }while(randomNode is Terminal);

            

            if (randomNode is Progn3)
            {
                int randomChild = random.Next(3);
                switch (randomChild)
                {
                    case 0: randomNode.left = getRandomFunction(); randomNode.left.parent = randomNode; break;
                    case 1: randomNode.middle = getRandomFunction(); randomNode.middle.parent = randomNode; break;
                    case 2: randomNode.right = getRandomFunction(); randomNode.right.parent = randomNode; break;
                }
            }
            else
            {
                int randomChild = random.Next(2);
                switch (randomChild)
                {
                    case 0: randomNode.left = getRandomFunction(); randomNode.left.parent = randomNode; break;
                    case 1: randomNode.right = getRandomFunction(); randomNode.right.parent = randomNode; break;
                }
            }

            return input;
        }

        TreeNode getRandomNode()
        {
            int rand = random.Next(2);

            if(rand==0)
                return getRandomFunction();
            else
                return getRandomTerminal();
        }

        TreeNode getRandomFunction()
        {
            int rand = random.Next(4);

            TreeNode ret;

            switch (rand)
            {
                case 0: ret = new IfFoodAhead(); break;
                case 1: ret = new Progn2(); break;
                case 2: ret = new Progn3(); break;
                case 3: ret = new IfWallAhead(); break;

                default: ret = new IfFoodAhead(); break;
            }

            return ret;
        }

        TreeNode getRandomTerminal()
        {
            int rand = random.Next(3);

            TreeNode ret;

            switch (rand)
            {
                case 0: ret = new Left(); break;
                case 1: ret = new Right(); break;
                case 2: ret = new Move(); break;

                default: ret = new Left(); break;
            }

            return ret;
        }


        public static List<TreeNode> getChildren(List<TreeNode> input)
        {
            List<TreeNode> ret=new List<TreeNode>();

            foreach (TreeNode node in input)
            {
                if (node is Function)
                {
                    ret.Add(node.getLeft());
                    ret.Add(node.getRight());
                    if (node.getMiddle() != null)
                        ret.Add(node.getMiddle());
                }
                
            }

            return ret;
        }

        public void getDecision(InputData inputData)
        {
            TreeNode.inputData = inputData;
            root.evaluate();
            fitness = ant.foodEaten;

            //Terminal decision=(Terminal)root.evaluate();
            //decision.execute(ant);
        }

        public void draw(PaintEventArgs e)
        {
            Brush brush = new SolidBrush(root.getColor());
            Font font = new Font(FontFamily.GenericSansSerif, 7);

            int textHeight = Convert.ToInt32(e.Graphics.MeasureString("ANYTEXT", font).Height);

            float X = e.ClipRectangle.Width / 2;
            float Y = 0;
            int symbolWidth = 20;

            //Drawing root
            e.Graphics.FillEllipse(brush, X-symbolWidth/2, Y, symbolWidth, symbolWidth);
            root.position = new PointF(X, Y);

            //e.Graphics.DrawString(root.getTextRepresentation(), font, brush, new PointF(X - root.getTextRepresentationWidth(font, e) / 2, Y));
            Y += symbolWidth*2;

            List<TreeNode> level = new List<TreeNode>();
            level.Add(root);
            level = getChildren(level);
            while (level.Count > 0)
            {
                X -= (level.Count * symbolWidth) / 2;

                for (int i = 0; i < level.Count; i++)
                {
                    if (level[i] != null)
                    {
                        //e.Graphics.DrawString(level[i].getTextRepresentation(), font, brush, new PointF(X - level[i].getTextRepresentationWidth(font, e) / 2 + i * symbolWidth, Y));
                        brush = new SolidBrush(level[i].getColor());
                        e.Graphics.FillEllipse(brush, X + i * symbolWidth, Y, symbolWidth, symbolWidth);
                        level[i].position = new PointF(X + i * symbolWidth, Y);
                    }
                }

                Y += symbolWidth*2;
                X = e.ClipRectangle.Width / 2;
                level = getChildren(level);
            }

            brush.Dispose();
        }

        public static void crossoverTwoPrograms(Program A, Program B)
        {
            //We'll get a random level to swap stuff in and it will be 2 levels lower than max depth, since we don't just want to swap terminals
            int randomLevelIndex = random.Next(1, A.maxDepth - 2);
            List<TreeNode> levelFromA = getLevel(A, randomLevelIndex);
            List<TreeNode> levelFromB = getLevel(B, randomLevelIndex);
            
            //Get random nodes to swap children at
            TreeNode nodeFromA = levelFromA[random.Next(levelFromA.Count)];
            TreeNode nodeFromB = levelFromB[random.Next(levelFromB.Count)];

            nodeFromA.parent.swapNode(nodeFromA, nodeFromB);
            nodeFromB.parent.swapNode(nodeFromB, nodeFromA);


            TreeNode tmp = nodeFromA.parent;
            nodeFromA.parent = nodeFromB.parent;
            nodeFromB.parent = tmp;

            /*
            //Make a random child index for A and for B, to determine, whether we're swapping left, right or middle child
            //0 - left, 1 - right, 2 - middle
            int randomChildIndexForA = getRandomChildIndex(nodeFromA is Progn3);
            int randomChildIndexForB = getRandomChildIndex(nodeFromB is Progn3);

            TreeNode randomChildFromA = getRandomChildFromNode(nodeFromA, randomChildIndexForA);
            TreeNode randomChildFromB = getRandomChildFromNode(nodeFromB, randomChildIndexForB);

            swapChildren(nodeFromA, randomChildFromB, randomChildIndexForA);
            swapChildren(nodeFromB, randomChildFromA, randomChildIndexForB);
            */
        }

        public Program CompareTo(Program toCompare)
        {
            if (this.fitness > toCompare.fitness)
                return this;
            else
                return toCompare;
        }

        static bool isTreenodeFull(TreeNode node, int maxDepth, int levelIndex)
        {
            List<TreeNode> level = new List<TreeNode>();
            level.Add(node);
            for (int i = levelIndex; i < maxDepth; i++)
            {
                level = getChildren(level);
                if (level.Count == 0)
                    return false;
            }
                
            return true;
        }

        public static void mutateProgram(Program toMutate)
        {
            //Get a random level from the program
            int randomLevelIndex=random.Next(toMutate.maxDepth/2);
            List<TreeNode> level = getLevel(toMutate, randomLevelIndex);
            //Get a random node from a level
            TreeNode node = level[random.Next(level.Count)];
            replaceRandomChildWithNewTree(toMutate, node, randomLevelIndex);
        }

        static void replaceRandomChildWithNewTree(Program program, TreeNode node, int levelIndex)
        {
            int index = getRandomChildIndex(node is Progn3);
            if (index == 0)
            {
                node.left = program.initializeTree(program.maxDepth - levelIndex - 1);
                node.left.parent = node;
            }
            else if (index == 1)
            {
                node.right = program.initializeTree(program.maxDepth - levelIndex - 1);
                node.right.parent = node;
            }
            else
            {
                node.middle = program.initializeTree(program.maxDepth - levelIndex - 1);
                node.middle.parent = node;
            }
        }

        static List<TreeNode> getLevel(Program program, int levelIndex)
        {
            List<TreeNode> ret = new List<TreeNode>();
            ret.Add(program.root);
            for (int i = 0; i < levelIndex; i++)
            {
                if(getChildren(ret).Count > 0)
                    ret = getChildren(ret);
            }

            return ret;
        }

        static void swapChildren(TreeNode parent, TreeNode child, int index)
        {
            if (index == 0)
                parent.left = child;
            else if (index == 1)
                parent.right = child;
            else
                parent.middle = child;
        }

        static TreeNode getRandomChildFromNode(TreeNode node, int index)
        {
            if (index == 0)
                return node.left;
            else if (index == 1)
                return node.right;
            else 
                return node.middle;
        }

        static int getRandomChildIndex(bool isProgn3)
        {
            if (isProgn3)
                return random.Next(3);
            else
                return random.Next(2);
        }
    
}
}
