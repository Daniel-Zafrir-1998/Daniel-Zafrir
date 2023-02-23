using System.Text;


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

        Dictionary<int, List<int>> adj = BuildAdjList(roads);

       (_, long fuel) = dfs(adj, 0, -1 ,seats, 0);

        return fuel;
    }

    private (int people, long fuel) dfs(Dictionary<int, List<int>> adj, int node, int parent, int seats, long fuel)
    {
        (int tempPeople, long tempFuel) = (1, fuel);

        foreach(var value in adj[node])
        {
            if (value != parent)
            {
                (int people, long currentFuel) = 
                dfs(adj
                , value
                , node
                , seats
                , fuel);
                tempPeople += people;
                tempFuel += currentFuel;
            }
        }

        if (0 != node)
        {
            tempFuel += (long)Math.Ceiling((double)tempPeople / seats);
        }

        return (tempPeople , tempFuel);
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