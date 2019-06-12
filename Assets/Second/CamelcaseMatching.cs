using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamelcaseMatching : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	https://leetcode.com/problems/camelcase-matching/
	Camelcase Matching
	A query word matches a given pattern if we can insert lowercase letters 
	to the pattern word so that it equals the query. (We may insert each character 
	at any position, and may insert 0 characters.)
	Given a list of queries, and a pattern, return an answer list of booleans, 
	where answer[i] is true if and only if queries[i] matches the pattern.

	给两个字符串，判断第一个字符串是否可以由第二个字符串在任意位置插入小写字母来合成
	简单的字符串匹配问题
	 */
	public IList<bool> CamelMatch(string[] queries, string pattern) {
        IList<bool> result = new List<bool>();
        
        for(int i = 0; i < queries.Length; i++){
            int first = 0;
            int second = 0;
            string temp = queries[i];
            while(first < temp.Length && second < pattern.Length){
                if(temp[first] == pattern[second]) {
                    first++;
                    second++;
                }else if(temp[first] >= 'a' && temp[first] <= 'z'){
                    first++;
                }else{
                    break;
                }
            }
            
			// 做题时第一次没有考虑第一个字符串最后的小写字母
            while(first < temp.Length && temp[first] >= 'a' && temp[first] <= 'z'){
                first++;
            }
            
            if(first == temp.Length && second == pattern.Length){
                result.Add(true);
            }else{
                result.Add(false);
            }
        }
        
        return result;
    }

	/**
	Discuss解法
    其实只需要记录第一个字符串匹配的长度，然后和pattern比较即可
    如果匹配字符串比查询字符串长，则不可能匹配
	 */
	public IList<bool> CamelMatch_Discuss(string[] queries, string pattern) {
        IList<bool> result = new List<bool>();
        
        for(int i = 0; i < queries.Length; i++){
			result.Add(Test(queries[i], pattern));
        }
        
        return result;
    }
    
    public bool Test(string temp, string pattern){
        int second = 0;
        for(int j = 0; j < temp.Length; j++){
            if(second < pattern.Length && temp[j] == pattern[second]){
                second++;
            }else if(temp[j] >='A' && temp[j] <= 'Z'){
                return false;
            }
        }
        return second == pattern.Length;
    }
}
