using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LetterCombinationsofaPhoneNumber : MonoBehaviour
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
    https://leetcode.com/problems/letter-combinations-of-a-phone-number/

    利用队列先进先出实现功能
    这个实现类似于广度优先搜索
     */
    public IList<string> LetterCombinations(string digits) {
        if(digits == null || digits.Length == 0) return new List<string>();
        string[] map = new string[]{"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("");
        for(int i = 0; i < digits.Length; i++){
            int length = queue.Count;
            for(int j = 0; j < length; j++){
                string temp = queue.Dequeue();
                for(int k = 0; k < map[digits[i] - '0' - 2].Length ;k++){
                    // 这里我在组合字符串是不确定c#中是否可以 string + char 这样操作。   提交之后发现可以
                    queue.Enqueue(temp + map[digits[i] - '0' - 2][k]);
                }
            }
        }
        return new List<string>(queue);
    }

    /**
    使用回溯方法解决
    类似于深度优先搜索
     */
    string[] map = new string[]{"0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
    public IList<string> LetterCombinations_(string digits) {
        if(digits == null || digits.Length == 0) return new List<string>();
        IList<string> res = new List<string>();
        Combine(new StringBuilder(), digits, 0, res);
        return res;
    }
    
    public void Combine(StringBuilder sb, string digits, int index, IList<string> res){
        if(sb.Length == digits.Length){
            res.Add(sb.ToString());
            return ;
        }
        
        for(int i = index; i < digits.Length; i++){
            for(int j = 0; j < map[digits[i] - '0'].Length; j++){
                sb.Append(map[digits[i] - '0'][j]);
                Combine(sb, digits, i + 1, res);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
