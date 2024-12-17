using System;

namespace MST
{
    internal class Program
    {
        static int V = 5; // Number of v in the graph

        // find the vertex with the minimum key value
        static int MinKey(int[] key, bool[] selected)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!selected[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        // print the constructed MST
        static void PrintMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");
            }
        }

        // implement Prim's Algorithm for Minimum Spanning Tree
        static void PrimMST(int[,] graph)
        {
            int[] parent = new int[V];     
            int[] key = new int[V];        
            bool[] selected = new bool[V]; 

            
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                selected[i] = false;
            }

            key[0] = 0;       
            parent[0] = -1;  

            for (int count = 0; count < V - 1; count++)
            {
                // minimum key vertex
                int u = MinKey(key, selected);
                selected[u] = true; 

                // Update the key values of adjacent vertices
                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && !selected[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            
            PrintMST(parent, graph);
        }

        static void Main(string[] args)
        {
           
            int[,] graph = new int[,]
            {
                { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 }
            };

            Console.WriteLine("Prim's Algorithm - Minimum Spanning Tree:");
            PrimMST(graph);   
            Console.ReadLine();
        }
    }
}
