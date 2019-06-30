using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstringwithConcatenationofAllWords : MonoBehaviour
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
    https://leetcode.com/problems/substring-with-concatenation-of-all-words/

    使用两个map来进行判断，第一个map用于记录words数组中所有单词的出现次数
    第二个map用于每次迭代当前迭代的字母开始单词出现的次数
     */
    public IList<int> FindSubstring(string s, string[] words) {
        if(words == null || words.Length == 0) return new List<int>();
        Dictionary<string, int> count = new Dictionary<string, int>();
        
        foreach(string str in words){
            if(count.ContainsKey(str)){
                count[str]++;
            }else{
                count.Add(str, 1);
            }
        }
        
        int n = s.Length;
        int sum = words.Length;
        int len = words[0].Length;
        IList<int> res = new List<int>();
        for(int i = 0; i <= n - sum * len; i++){
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int j = 0;
            while(j < sum){
                string str = s.Substring(i + j * len, len);
                if(dic.ContainsKey(str)){
                    dic[str]++;
                }else{
                    dic.Add(str, 1);
                }
                
                if(!count.ContainsKey(str)){
                    break;
                }
                
                if(dic[str] > count[str]){
                    break;
                }
                
                j++;
            }
            
            if(j == sum){
                res.Add(i);
            }
        }
        
        return res;
    }
}
