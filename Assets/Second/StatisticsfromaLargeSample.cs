using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatisticsfromaLargeSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int sum = 177847815;
        int total = 1000000;
        Debug.Log(Math.Round(sum / (double)total,5, MidpointRounding.ToEven));
        double[] temp = new double[2];
        temp[0] = sum / (double)total;
        Debug.Log(temp[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/statistics-from-a-large-sample/

    计算最大值，最小值，平均数，中位数，众数
    本题c#解法leetcode不能接受，请使用python
     */
    public double[] SampleStats(int[] count) {
        double[] result = new double[5];
        int totalCount = 0;
        int sum = 0;
        int singleMax = 0;
        // 首先找出最大最小
        for(int i = 0; i < count.Length; i++){
            if(result[0] == 0 && count[i] != 0){
                result[0] = (double)i;
            }
            
            if(count[i] != 0){
                result[1] = (double)i;
                totalCount += count[i];
                sum = sum + i * count[i];
                
                if(count[i] > singleMax){
                    result[4] = (double)i;
                    singleMax = count[i];
                }
            }
            
        }
        
        if(count[0] != 0){
            result[0] = (double)0;
        }
        
        result[2] = (double)Math.Round(sum / (decimal)totalCount,6);
        bool isOdd = totalCount % 2 != 0;
        int middleIndex = totalCount / 2;
        int currentCount = 0;
        Console.WriteLine(isOdd);
        for(int i = 0; i < count.Length; i++){
            if(count[i] != 0){
                currentCount += count[i];
            }
            
            if(isOdd && currentCount >= middleIndex){
                result[3] = (double)i;
                return result;
            }else if(!isOdd && currentCount > middleIndex && result[3] == 0){
                result[3] = (double)i;
                return result;
            }else if(!isOdd && currentCount == middleIndex && result[3] == 0){
                result[3] += (double)i;
            }else if(!isOdd && result[3] != 0 && count[i] != 0){
                result[3] += (double)i;
                result[3] = result[3] / 2;
                return result;
            }
        }
        return result;
    }
}
