using System.Text;

namespace Quiz.FarFromLand
{
    /*Given an n x n grid containing only values 0 and 1
    ,where 0 represents water and 1 represents land
    ,find a water cell such that its distance to the nearest land cell is maximized
    ,and return the distance. If no land or water exists in the grid, return -1.

    The distance used in this problem is the Manhattan distance: 
    the distance between two cells (x0, y0) and (x1, y1) is |x0 - x1| + |y0 - y1|.   */
    public class Solution {
        public int MaxDistance(int[][] grid) {
            (int y, int x)[] dir = {(1, 0), (0, 1), (-1, 0), (0, -1)};
            Queue<(int y, int x)> search = new();
            bool[,] visited = new bool[grid.Length ,grid[0].Length];

            for(int i = 0; i < grid.Length; ++i)
            {
                for(int j = 0; j < grid[i].Length; ++j)
                {
                    if(1 == grid[i][j])
                    {
                        search.Enqueue((i, j));
                        visited[i, j] = true;
                    }
                }
            }

            int distance = -1;

            while(0 != search.Count)
            {
                int size = search.Count;

                while(0 != size--) 
                {
                    (int y, int x) root = search.Dequeue();

                    foreach(var step in dir)
                    {
                        int x = root.x + step.x;
                        int y = root.y + step.y;
                        
                        if(x >= 0 && y >= 0 && x < grid.Length && y < grid[0].Length && visited[y, x] != true)
                        {
                            search.Enqueue((y, x));
                            visited[y, x] = true;
                        }
                    }
                }
                ++distance;
            }
            return distance == 0 ? -1 : distance;
        }
    }
}