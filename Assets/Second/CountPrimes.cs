using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPrimes : MonoBehaviour
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
    计算小于n的大于0的所有素数的个数，利用一个bool数组来保存每个数字是否是素数
    一个数如果是素数，那么它的倍数一定不是素数
    从2 开始计算，2的倍数都不是素数
     */
    public int CountPrimes_(int n) {
        bool[] valid = new bool[n];
        int count = 0;
        for (int i = 2; i < n; i++){
            if (!valid[i]){
                count++;
                for (int j = 2; i * j < n; j++){
                    valid[i * j] = true;
                }
            }
        }
        
        return count;
    }
}
