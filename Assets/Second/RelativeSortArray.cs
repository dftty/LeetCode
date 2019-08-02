using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeSortArray : MonoBehaviour
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
    https://leetcode.com/problems/relative-sort-array/

    类似于桶排序
     */
    public int[] RelativeSortArray_(int[] arr1, int[] arr2) {
        int[] temp = new int[1001];
        
        for(int i = 0; i < arr1.Length; i++){
            temp[arr1[i]]++;
        }
        
        List<int> result = new List<int>();
        for(int i = 0; i < arr2.Length; i++){
            while(temp[arr2[i]]-- > 0){
                result.Add(arr2[i]);
            }
        }
        
        for(int i = 0; i < temp.Length; i++){
            while(temp[i]-- > 0){
                result.Add(i);
            }
        }
        
        return result.ToArray();
    }
}
