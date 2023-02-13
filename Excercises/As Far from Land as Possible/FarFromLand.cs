using System.Text;

namespace Quiz.FarFromLand
{
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