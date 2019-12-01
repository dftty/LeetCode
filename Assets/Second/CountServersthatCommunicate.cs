using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountServersthatCommunicate : MonoBehaviour
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
    https://leetcode.com/problems/count-servers-that-communicate/

    第一次提交时没有仔细阅读题目，把题目当成了深度优先搜索类型，导致提交错误。
    仔细读题之后才发现题意是只要在同一行或者同一列就可以交流，因此使用两个数组来
    保存每行每列电脑出现的次数，最后把每行每列出现超过一台电脑的答案相加即可。
    */
    public int CountServers(int[][] grid) {
        int res = 0;
        
        int[] row = new int[grid.Length];
        int[] col = new int[grid[0].Length];
        
        for (int i = 0; i < grid.Length; i++){
            for (int j = 0; j < grid[i].Length; j++){
                if (grid[i][j] == 1){
                    row[i]++;
                    col[j]++;
                }
            }
        }
        
        for (int i = 0; i < grid.Length; i++){
            for (int j = 0; j < grid[i].Length; j++){
                if (grid[i][j] == 1 && (row[i] > 1 || col[j] > 1)){
                    res++;
                }
            }
        }
        
        return res;
    }
}
