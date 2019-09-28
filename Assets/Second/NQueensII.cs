using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NQueensII : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int res = 0;

    /**
    https://leetcode.com/problems/n-queens-ii/

    利用三个数组保存列，45度，135度的占用情况
     */
    public int TotalNQueens(int n) {
        bool[] cols = new bool[n];
        bool[] slope_45 = new bool[2 * n - 1];
        bool[] slope_135 = new bool[2 * n - 1];
        BackTrack(cols, slope_45, slope_135, 0);
        
        return res;
    }
    
    void BackTrack(bool[] cols, bool[] slope_45, bool[] slope_135, int row){
        if (row == cols.Length){
            res++;
            return ;
        }
        
        for (int i = 0; i < cols.Length; i++){
            if (!cols[i] && !slope_45[row + i] && !slope_135[cols.Length - 1 + i - row]){
                cols[i] = slope_45[row + i] = slope_135[cols.Length - 1 + i - row] = true;
                BackTrack(cols, slope_45, slope_135, row + 1);
                cols[i] = slope_45[row + i] = slope_135[cols.Length - 1 + i - row] = false;
            }
        }
    }
}
