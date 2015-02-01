using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaFe.EvolutionaryProgram.Implements.Functions;
using SantaFe.EvolutionaryProgram.Implements.Terminals;

namespace SantaFe.EvolutionaryProgram
{
    class Evolution
    {
        public List<Program> population;
        public List<Program> oldPopulation;
        public int populationSize;
        int maxDepth;
        public int maxSteps;
        Form1 form1;
        public int generationCount;

        public static Random random;

        public Evolution(int maxPopulation, int maxSteps, int maxDepth, Ant ant,Form1 form1)
        {
            this.populationSize = maxPopulation;
            this.maxSteps = maxSteps;
            this.maxDepth = maxDepth;
            this.form1 = form1;
            population = new List<Program>();
            initializePopulation(maxDepth, ant);
        }

        public void initializePopulation(int maxDepth, Ant ant)
        {
            for(int i=0;i<populationSize;i++)
                population.Add(new Program(maxDepth,ant));
        }

        public List<Program> selection(List<Program> input)
        {
            //Tournament selection with elitism is implemented, the best individual is always preserved, along with some others, that survive the tournament
            List<Program> newPopulation = new List<Program>();
            newPopulation.Add(getBestProgramOutOfPopulation(input).clone());

            for (int i = 0; i < populationSize-1; i++)
            {
                Program A = input[random.Next(input.Count)];
                Program B = input[random.Next(input.Count)];
                if (A.fitness > B.fitness)
                    newPopulation.Add(A.clone());
                else
                    newPopulation.Add(B.clone());
            }

            return newPopulation;
        }

        Program getBestProgramOutOfPopulation(List<Program> population)
        {
            Program best = population[0];

            for (int i = 1; i < population.Count; i++)
                if (population[i].fitness > best.fitness)
                    best = population[i];

            return best;
        }

        public List<Program> crossover(List<Program> input)
        {
            
            List<Program> newPopulation = new List<Program>();
            
            //We have elitism, so we never crossover or mutate the best program
            newPopulation.Add(getBestProgramOutOfPopulation(input));
            input.Remove(newPopulation[0]);
            

            while (input.Count > 1)
            {
                int randomProgramA = random.Next(input.Count);
                Program A = input[randomProgramA];
                input.RemoveAt(randomProgramA);

                int randomProgramB = random.Next(input.Count);
                Program B = input[randomProgramB];
                input.RemoveAt(randomProgramB);

                Program.crossoverTwoPrograms(A, B);

                newPopulation.Add(A);
                newPopulation.Add(B);
            }

            return newPopulation;
        }

        public void evolve()
        {
            population = selection(population);
            population = crossover(population);
            population = mutation(population);

            form1.incrementGeneration();
        }
        public void select()
        {
            population = selection(population);
        }
        public void cross()
        {
            population = crossover(population);
        }
        public void mutate()
        {
            population = mutation(population);
        }

        public List<Program> mutation(List<Program> input)
        {
            List<Program> newPopulation = new List<Program>();

            //We have elitism, so we never crossover or mutate the best program
            newPopulation.Add(getBestProgramOutOfPopulation(input));
            input.Remove(newPopulation[0]);

            while (input.Count > 0)
            {
                int m = random.Next(40);
                if (m == 20)
                {
                    //If it's a hit, mutate tree
                    Program.mutateProgram(input[0]);
                }

                newPopulation.Add(input[0]);
                input.RemoveAt(0);
            }

            return newPopulation;
        }

        public void singleAction(InputData inputData, int individualIndex)
        {
            if ( individualIndex >= populationSize || individualIndex < 0 )
                individualIndex = populationSize - 1;
            population.ElementAt(individualIndex).getDecision(inputData);
        }

        public void allActionsForCurrentGeneration()
        {
            for (int i = 0; i < population.Count;i++ )
            {
                form1.setAntIndex(i);
                for (int j = 0; j < maxSteps; j++)
                {
                    population[i].getDecision(form1.getInputData());
                    form1.setStep(j);
                }
                form1.resetGridAndAnt();
                form1.refreshList(i);
            }
        }

        public void actionsForSingleAnt(int antIndex)
        {
            if (antIndex >= population.Count)
                antIndex = 0;
            for (int j = 0; j < maxSteps; j++)
            {
                population[antIndex].getDecision(form1.getInputData());
                form1.setStep(j);
            }
            form1.resetGridAndAnt();
        }

        public Program getProgram(int programIndex)
        {
            return population.ElementAt(programIndex);
        }

        public void runMultipleEvolutions()
        {
            for (int i = 0; i < generationCount; i++)
            {
                allActionsForCurrentGeneration();
                evolve();
            }
        }

    }
}
