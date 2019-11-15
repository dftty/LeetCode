using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reconstructa2RowBinaryMatrix : MonoBehaviour
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
    https://leetcode.com/problems/reconstruct-a-2-row-binary-matrix/

    贪心解法
    做题时没有仔细读题并且考虑周全，导致测试时出现了各种错误

    首先没有判断upper和lower是否可以满足colsum中的所有2的列
    */
    public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum) {
        int sum = 0;
        foreach(int i in colsum){
            sum += i;
        }
        IList<IList<int>> res = new List<IList<int>>();
        if (sum != upper + lower){
            return res;
        }
        
        IList<int> first = new List<int>();
        IList<int> second = new List<int>();
        
        for (int i = 0; i < colsum.Length; i++){
            if (colsum[i] == 2){
                first.Add(1);
                second.Add(1);
                upper--;
                lower--;
            }else {
                first.Add(0);
                second.Add(0);
            }
        }
        
        if (upper < 0 || lower < 0){
            return res;
        }
        
        for (int i = 0; i < colsum.Length; i++){
            if (colsum[i] != 1){
                continue;
            }
            if (upper > 0){
                first[i] = 1;
                upper--;
            }else{
                second[i] = 1;
                lower--;
            }
        }
        
        res.Add(first);
        res.Add(second);
        return res;
    }
}
