using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsFarfromLandasPossible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/as-far-from-land-as-possible/

    Discuss 的BFS解法
    https://leetcode.com/problems/as-far-from-land-as-possible/discuss/360963/C%2B%2B-with-picture-DFS-and-BFS

    
     */
    public int MaxDistance(int[][] grid) {
        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
        
        for (int i = 0; i < grid.Length; i++){
            for (int j = 0; j < grid[i].Length; j++){
                if (grid[i][j] == 1){
                    queue.Enqueue(new KeyValuePair<int, int>(i - 1, j));
                    queue.Enqueue(new KeyValuePair<int, int>(i + 1, j));
                    queue.Enqueue(new KeyValuePair<int, int>(i, j - 1));
                    queue.Enqueue(new KeyValuePair<int, int>(i, j + 1));
                }
            }
        }
        int step = 1;
        int max = -1;
        while (queue.Count > 0){
            int count = queue.Count; 
            for (int i = 0; i < count ;i++){
                KeyValuePair<int, int> keyvalue = queue.Dequeue();
                int x = keyvalue.Key, y = keyvalue.Value;
                if (x >= 0 && y >= 0 && x < grid.Length && y < grid.Length && grid[x][y] == 0){
                    grid[x][y] = step;
                    max = Math.Max(max, step);
                    queue.Enqueue(new KeyValuePair<int, int>(x - 1, y));
                    queue.Enqueue(new KeyValuePair<int, int>(x + 1, y));
                    queue.Enqueue(new KeyValuePair<int, int>(x, y - 1));
                    queue.Enqueue(new KeyValuePair<int, int>(x, y + 1));
                }
            }
            
            step++;
        }
        
        return max;
    }
}
