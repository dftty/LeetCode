using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroupAnagrams : MonoBehaviour
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
    https://leetcode.com/problems/group-anagrams/
    遍历数组，将每个字符串排序之后进行比较，然后存储在字典中

    优化改解法需要优化排序，将排序改成O(n)时间
     */
    public IList<IList<string>> GroupAnagrams_(string[] strs) {
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        IList<IList<string>> res = new List<IList<string>>();
        for(int i = 0; i < strs.Length; i++){
            char[] temp = strs[i].ToCharArray();
            
            Array.Sort(temp);
            string key = new string(temp);
            if(dic.ContainsKey(key)){
                dic[key].Add(strs[i]);
            }else{
                List<string> list = new List<string>();
                list.Add(strs[i]);
                dic.Add(key, list);
            }
        }
        
        foreach(KeyValuePair<string, List<string>> list in dic){
            res.Add(list.Value);
        }
        return res;
    }

    /**
    利用素数只有1和本身的性质，将其作为key保存
     */
    public IList<IList<string>> GroupAnagrams_Num(string[] strs) {
        int[] prime = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103};
        Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
        IList<IList<string>> res = new List<IList<string>>();
        for(int i = 0; i < strs.Length; i++){
            int key = 1;
            foreach(char c in strs[i]){
                key *= (c - '0');
            }

            if(dic.ContainsKey(key)){
                dic[key].Add(strs[i]);
            }else{
                List<string> list = new List<string>();
                list.Add(strs[i]);
                dic.Add(key, list);
            }
        }
        
        foreach(KeyValuePair<int, List<string>> list in dic){
            res.Add(list.Value);
        }
        
        return res;
    }
}
