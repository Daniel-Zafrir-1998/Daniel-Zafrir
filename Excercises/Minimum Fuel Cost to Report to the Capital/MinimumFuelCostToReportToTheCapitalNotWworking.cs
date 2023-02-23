using System.Text;

/* Warning This Solution Not Working 
    I didn`t knew graph when approching this problem so i leaned how to travrse it 
    and also litte math trick from leetcode.
    so i followed the leetcode solution but i wanted to try and make it iterative 
    it not working it close,
    i think the problem is that im not counting fron the end of the tree in doing the math for the closest node 
    so when i calc seat it need to be from the end so i was a week on this question when i gaveup
    */ 


    /*
    2477. Minimum Fuel Cost to Report to the Capital
    Medium
    1.7K
    67
    company
    Microsoft
    There is a tree (i.e., a connected, undirected graph with no cycles)
     structure country network consisting of n cities numbered from 0 to n - 1 and exactly n - 1 roads.
      The capital city is city 0. You are given a 2D integer array roads where roads[i] = [ai, bi] denotes 
      that there exists a bidirectional road connecting cities ai and bi.

    There is a meeting for the representatives of each city. The meeting is in the capital city.

    There is a car in each city. You are given an integer seats that indicates the number of seats in each car.

    A representative can use the car in their city to travel or change the car and ride with another
     representative. The cost of traveling between two cities is one liter of fuel.

    Return the minimum number of liters of fuel to reach the capital city.
    */


public class Solution {
    public long MinimumFuelCost(int[][] roads, int seats) 
    {
        if (0 == roads.Length)
        {
            return 0;
        }

        bool[] visited = new bool[roads.Length + 1];
        Dictionary<int, List<int>> adj = BuildAdjList(roads);
        Stack<(List<int> values, int depth)> graphElement = new();
        double toReturn = 0;
        
        graphElement.Push((adj[0] , 0));
        visited[0] = true;

        while(0 != graphElement.Count)
        {
            var neighbors = graphElement.Pop();
            
            foreach(var neighbor in neighbors.values)
            {
                if (true != visited[neighbor])
                {
                    graphElement.Push((adj[neighbor], neighbors.depth + 1));
                    visited[neighbor] = true;
                }
            }
            toReturn += Math.Ceiling((double)neighbors.depth / seats);
        }

        return Convert.ToInt64(toReturn);
    }

    private static Dictionary<int, List<int>> BuildAdjList(int[][] roads)
    {
        Dictionary<int, List<int>> adjToReturn = new(roads.Length);

        InitList(adjToReturn, roads.Length);

        foreach(int[] road in roads)
        {
            adjToReturn[road[0]].Add(road[1]);
            adjToReturn[road[1]].Add(road[0]);
        }

        return adjToReturn;
    }

    private static void InitList(Dictionary<int, List<int>> adj, int size)
    {
        for(int i = 0; i <= size; ++i)
        {
            adj.Add(i, new());
        }
    }
}