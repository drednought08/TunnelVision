using System;
using System.Collections.Generic;

namespace TunnelVisionPathfinder
{
    public class Pathfinder
    {
        public Dictionary<int, double> Search(int fromX, int fromY, int toX, int toY, int[,] grid)
        {
            Dictionary<int, Dictionary<double, double>> nextNodes = new Dictionary<int, Dictionary<double, double>>();
            Dictionary<int, double> pathway = new Dictionary<int,double>();
            int step = 0;
            double start = fromX + ((double)fromY / 10);
            double end = toX + ((double)toY / 10);
            while (true)
            {
                Dictionary<double, double> adjacentNodes = new Dictionary<double, double>();    //create dictionary
                double closestNode = 0.0, closestDist = 100;
                double dist = 0;
                if (nextNodes.ContainsKey(step))    //check if theres a previous list
                {
                    if (nextNodes.TryGetValue(step, out adjacentNodes)) //try to get the previous dictionary of nodes
                    {
                        if (adjacentNodes.Count > 0)
                        {
                            foreach (KeyValuePair<double, double> node in adjacentNodes)
                                //iterate through looking for the next closest node
                            {
                                if (node.Value < closestDist)
                                    //if current node is closer than the closest distance so far found
                                {
                                    closestDist = node.Value;
                                    closestNode = node.Key;
                                }
                            }
                            if (pathway.ContainsKey(step))
                            {
                                pathway.Remove(step);
                            }
                            pathway.Add(step, closestNode);
                            step++;
                            start = closestNode;
                        }
                        else
                        {
                            nextNodes.Remove(step);
                            pathway.Remove(step);
                            step--;
                            continue;
                        }
                    }
                    else //if no dictionary in previous step, restart loop going back another step
                    {
                        nextNodes.Remove(step);
                        pathway.Remove(step);
                        step--;
                        continue;
                    }
                }
                double location = start;
                int x = (int)location;
                int y = (int)(location * 10) - x * 10;
                grid[x, y] = 1; //block off this node since its being used, prevent looping backtracks
                if (x > 0)  //try not to fall off grid
                {
                    int tempX = x - 1;
                    if (grid[tempX, y] == 0)    //if grid space is empty
                    {
                        dist = Math.Sqrt(Math.Pow((toX - tempX), 2) + Math.Pow((toY - y), 2));
                        adjacentNodes.Add(tempX + ((double)y / 10), dist);
                    }
                    tempX = x + 1;
                    if (grid[tempX, y] == 0)    //if grid space is empty
                    {
                        dist = Math.Sqrt(Math.Pow((toX - tempX), 2) + Math.Pow((toY - y), 2));
                        adjacentNodes.Add(tempX + ((double)y / 10), dist);
                    }
                }
                if (y > 0)  //try not to fall off grid
                {
                    int tempY = y - 1;
                    if (grid[x, tempY] == 0)    //if grid space is empty
                    {
                        dist = Math.Sqrt(Math.Pow((toX - x), 2) + Math.Pow((toY - tempY), 2));
                        adjacentNodes.Add(x + ((double)tempY / 10), dist);
                    }
                    tempY = y + 1;
                    if (grid[x, tempY] == 0)    //if grid space is empty
                    {
                        dist = Math.Sqrt(Math.Pow((toX - x), 2) + Math.Pow((toY - tempY), 2));
                        adjacentNodes.Add(x + ((double)tempY / 10), dist);
                    }
                }
                if (adjacentNodes.Count < 1)    //if there arent any nodes left to check in this dictionary
                {
                    //backtrack
                    nextNodes.Remove(step);
                    pathway.Remove(step);
                    step--;
                    continue;
                }
                else
                {
                    nextNodes.Remove(step);
                    nextNodes.Add(step, adjacentNodes); //otherwise add this new dictionary to the parent dictionary
                }
                
                foreach (KeyValuePair<double, double> node in adjacentNodes)
                {
                    if (node.Value < closestDist)
                    {
                        closestDist = node.Value;
                        closestNode = node.Key;
                    }
                }
                adjacentNodes.Remove(closestNode);//remove the node just used from the list, for backtracking

                if (closestNode == end)
                {
                    return pathway;
                }
                     start = closestNode;
                    if (pathway.ContainsKey(step))
                    {
                        pathway.Remove(step);
                    }
                    pathway.Add(step, closestNode);
                    step++;
            }
        }
    }
}
