using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPermutationinBinaryRepresentation : MonoBehaviour
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
    https://leetcode.com/problems/circular-permutation-in-binary-representation/

    Discuss解法， 格雷码, 从start位置开始
    https://cp-algorithms.com/algebra/gray-code.html
     */
    public IList<int> CircularPermutation(int n, int start) {
        int[] arr = new int[1 << n];
        
        for (int i = 0; i < arr.Length; i++){
            arr[i] = i ^ i >> 1;
        }
        
        IList<int> res = new List<int>();
        for (int i = 0; i < arr.Length; i++){
            if (arr[i] == start){
                for (int j = 0; j < arr.Length; j++){
                    res.Add(arr[(i + j) % (1 << n)]);
                }
            }
        }
        
        return res;
    }
}
