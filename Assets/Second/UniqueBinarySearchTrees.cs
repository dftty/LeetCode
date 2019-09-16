using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueBinarySearchTrees : MonoBehaviour
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
    https://leetcode.com/problems/unique-binary-search-trees/
    动态规划
    解法网站:
    https://leetcode.com/problems/unique-binary-search-trees/discuss/31666/DP-Solution-in-6-lines-with-explanation.-F(i-n)-G(i-1)-*-G(n-i)
     */
    public int NumTrees(int n) {
        int[] G = new int[n + 1];
        G[0] = G[1] = 1;
        
        for (int i = 2; i <= n; i++){
            for (int j = 1; j <= i; j++){
                G[i] += G[j - 1] * G[i - j];
            }
        }
        
        return G[n];                                                                                                                     
    }
}
