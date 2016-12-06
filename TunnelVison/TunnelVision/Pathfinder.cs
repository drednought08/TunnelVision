using System;
using System.Collections.Generic;

namespace TunnelVisionPathfinder
{
    public class Pathfinder
    {
        ///requires a grid with open "walkable" points, and coordinates from and to destination
        ///returns a dictionary of the optimal path found with coordinates in form "XXX.YYY"
        /* Possible processing:
            foreach (KeyValuePair<int, string> tile in path)
            {
                string[] tiles = tile.Value.Split('.');
                int tileX = Int32.Parse(tiles[0]);
                int tileY = Int32.Parse(tiles[1]);;
            }
         */
        
        public Dictionary<int, string> Search(int fromX, int fromY, int toX, int toY, int[,] grid)
        {
            Dictionary<int, Dictionary<string, double>> nextNodes = new Dictionary<int, Dictionary<string, double>>();
            Dictionary<int, string> shortestPath = new Dictionary<int, string>();
            Dictionary<int, string> pathway = new Dictionary<int, string>();
            int[,] origGrid = grid;
            int step = 0;
            string start = fromX + "." + fromY;
            string end = toX + "." + toY;
            bool forward = true;
            //int[] adj = new[] { 1, -1, 0 };
            int[] adj = {1, -1};
            while (true)
            {
                if (step < 0)
                {
                    return shortestPath;
                }
                if (nextNodes.Count < 1 && shortestPath.Count > 0)
                {
                    return shortestPath;
                }
                Dictionary<string, double> adjacentNodes = new Dictionary<string, double>();    //create dictionary
                string closestNode = "";
                double closestDist = 1000;
                double dist = 0;
                if (nextNodes.ContainsKey(step) && forward == false)    //check if theres a previous list
                {
                    if (nextNodes.TryGetValue(step, out adjacentNodes)) //try to get the previous dictionary of nodes
                    {
                        if (adjacentNodes.Count > 0)
                        {
                            foreach (KeyValuePair<string, double> node in adjacentNodes)
                                //iterate through looking for the next closest node
                            {
                                if (node.Value < closestDist)
                                    //if current node is closer than the closest distance so far found
                                {
                                    closestDist = node.Value;
                                    closestNode = node.Key;
                                }
                            }
                            adjacentNodes.Remove(closestNode);  //remove closest node to avoid backtracking loops, being added to pathway anyway

                            if (pathway.ContainsKey(step))
                            {
                                pathway.Remove(step);
                            }
                            pathway.Add(step, closestNode);
                            step++;
                            forward = true;
                            start = closestNode;
                        }
                        else
                        {
                            nextNodes.Remove(step);
                            pathway.Remove(step);
                            step--;
                            forward = false;
                            continue;
                        }
                    }
                    else //if no dictionary in previous step, restart loop going back another step
                    {
                        nextNodes.Remove(step);
                        pathway.Remove(step);
                        step--;
                        forward = false;
                        continue;
                    }
                }
                string location = start;
                string[] coor = location.Split('.');
                int x = Int32.Parse(coor[0]);
                int y = Int32.Parse(coor[1]);
                grid[x, y] = 1; //block off this node since its being used, prevent looping backtracks

                /*This for loop, used with adj array { 1, -1, 0 } is for checking all 8 adjacent tiles, still buggy

                foreach (int xx in adj)
                {
                    foreach (int yy in adj)
                    {
                        if (grid[x + xx, y + yy] == 0 ||
                            (shortestPath.ContainsValue((int)(x + xx) + "." + (int)(y + yy)) &&
                             !pathway.ContainsValue((int)(x + xx) + "." + (int)(y + yy)))) //if grid space is empty
                        {
                            if (!adjacentNodes.ContainsKey((int)(x + xx) + "." + (int)(y + yy)))
                            {
                                dist = Math.Sqrt(Math.Pow((toX - (x + xx)), 2) + Math.Pow((toY - (y + yy)), 2));
                                adjacentNodes.Add((int)(x + xx) + "." + (int)(y + yy), dist);
                            }
                        }
                    }
                }
                */

                //These loops use only the top bottom left and right adjacent tiles using just {1, -1}
                foreach (int yy in adj)
                {
                    if (grid[x, y + yy] == 0 ||
                        (shortestPath.ContainsValue((int)(x) + "." + (int)(y + yy)) &&
                         !pathway.ContainsValue((int)(x) + "." + (int)(y + yy)))) //if grid space is empty
                    {
                        if (!adjacentNodes.ContainsKey((int)(x) + "." + (int)(y + yy)))
                        {
                            dist = Math.Sqrt(Math.Pow((toX - (x)), 2) + Math.Pow((toY - (y + yy)), 2));
                            adjacentNodes.Add((int)(x) + "." + (int)(y + yy), dist);
                        }
                    }
                }
                foreach (int xx in adj)
                {
                    if (grid[x + xx, y] == 0 ||
                        (shortestPath.ContainsValue((int)(x + xx) + "." + (int)(y)) &&
                         !pathway.ContainsValue((int)(x + xx) + "." + (int)(y)))) //if grid space is empty
                    {
                        if (!adjacentNodes.ContainsKey((int)(x + xx) + "." + (int)(y)))
                        {
                            dist = Math.Sqrt(Math.Pow((toX - (x + xx)), 2) + Math.Pow((toY - (y)), 2));
                            adjacentNodes.Add((int)(x + xx) + "." + (int)(y), dist);
                        }
                    }
                }

                if (adjacentNodes.Count < 1)    //if there arent any nodes left to check in this dictionary
                {
                    //backtrack
                    nextNodes.Remove(step);

                    pathway.Remove(step);
                    forward = false;
                    step--;
                    continue;
                }
                    nextNodes.Remove(step);
                    nextNodes.Add(step, adjacentNodes); //otherwise add this new dictionary to the parent dictionary
                
                foreach (KeyValuePair<string, double> node in adjacentNodes)
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
                    //return pathway;
                    if (shortestPath.Count < 1 || pathway.Count < shortestPath.Count)
                    {
                        shortestPath.Clear();
                        foreach (KeyValuePair<int, string> node in pathway)
                        {
                            shortestPath.Add(node.Key, node.Value);
                        }
                    }

                    grid = origGrid;
                        nextNodes.Remove(step);
                        step = 0;
                        forward = false;
                        pathway.Clear();
                        continue;
                }
                     start = closestNode;
                    if (pathway.ContainsKey(step))
                    {
                        pathway.Remove(step);
                    }
                    pathway.Add(step, closestNode);
                    step++;
                forward = true;
            }
        }
    }
}
 
