using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MajorityElement : MonoBehaviour
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
    https://leetcode.com/problems/majority-element/
    第一种解法，排序之后，位于中间的一定是这个数
    
     */
    public int MajorityElement_1(int[] nums) {
        Array.Sort(nums);
        
        return nums[nums.Length / 2];
    }

    /**
    第二种解法，使用字典记录出现次数，最后返回最多的
     */
    public int MajorityElement_2(int[] nums) {
        Dictionary<int, int> temp = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++){
            if(temp.ContainsKey(nums[i])){
                temp[nums[i]]++;
            }else{
                temp.Add(nums[i], 1);
            }
        }
        
        int result = nums[0];
        int count = temp[result];
        
        foreach(KeyValuePair<int, int> val in temp){
            if(val.Value > count){
                count = val.Value;
                result = val.Key;
            }
        }
        
        return result;
    }

    /**
    第三种方法，计算每个数中的二进制位，出现最多的那个数的二进制位的数量一定大于数组长度的一半
     */
    public int MajorityElement_3(int[] nums) {
        int[] bit = new int[32];
        
        for(int i = 0; i < nums.Length; i++){
            for(int j = 0; j < 32; j++){
                bit[j] += (nums[i] >> j) & 1;
            }
        }
        
        int res = 0;
        for(int i = 0; i < 32; i++){
            bit[i] = (bit[i] > nums.Length / 2) ? 1 : 0;
            res += (bit[i] << i);
        }
        
        return res;
    }

    /**
    第四种解法
    http://www.cs.utexas.edu/~moore/best-ideas/mjrty/

    摩尔投票算法
     */
    public int MajorityElement_4(int[] nums) {
        int res = nums[0];
        int count = 1;
        
        for(int i = 0; i < nums.Length; i++){
            if(count == 0){
                count = 1;
                res = nums[i];
            }else if(nums[i] == res){
                count++;
            }else{
                count--;
            }
        }
        
        return res;
    }
}
