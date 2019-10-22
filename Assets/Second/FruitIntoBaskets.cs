using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitIntoBaskets : MonoBehaviour
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
    https://leetcode.com/problems/fruit-into-baskets/

    题目表述非常不清晰，看了Discuss后发现题目的意思是
    找到一个子数组，这个子数组中最多包含两个不同的数字

    滑动窗口算法，使用一个count数组对tree数组中出现的数字进行计数
    使用itemNum来表示当前子数组中使用了多少不同的数字,遍历过程中，如果当前数字的count为0，那么itemNum加一，
    如果itemNum大于子数组中要求的最大数字的数量，我们就要从左向右开始删除前面出现的数字，知道其中一个数字的数量为0为止。
     */
    public int TotalFruit(int[] tree) {
        int maxDistinceNum = 2;
        int itemNum = 0;
        int[] count = new int[40001];
        
        int res = 0;
        int left = 0;
        for (int i = 0; i < tree.Length; i++){
            int n = tree[i];
            if (count[n] == 0){
                itemNum++;
            }
            count[n]++;
            while(itemNum > maxDistinceNum && left < i){
                count[tree[left]]--;
                if (count[tree[left]] == 0){
                    itemNum--;
                }
                left++;
            }
            
            res = Math.Max(res, i - left + 1);
        }
        
        return res;
    }
}
