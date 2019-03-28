using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_49 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/group-anagrams/description/#
	// 2018/6/12
    // 将字符串转化为char数组，排序后放到map中，利用Map 实现O(1) 查找，
	public IList<IList<string>> GroupAnagrams(string[] strs) {
        IList<IList<string>> result = new List<IList<string>>();
        if(strs == null || strs.Length == 0) return result;
        Dictionary<string, int> store = new Dictionary<string, int>();
        int index = 0;
        
        for(int i = 0; i < strs.Length; i++){
            char[] temp = strs[i].ToCharArray();
            Array.Sort(temp);
            string tempStr = new string(temp);
            
            if(store.ContainsKey(tempStr)){
                result[store[tempStr]].Add(strs[i]);
            }else{
                IList<string> strList = new List<string>();
                strList.Add(strs[i]);
                result.Add(strList);
                store.Add(tempStr, index++);
            }
        }
        
        return result;
    }
}
