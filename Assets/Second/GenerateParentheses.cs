using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GenerateParentheses : MonoBehaviour
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
    https://leetcode.com/problems/generate-parentheses/

    回溯问题，需要的答案是配对的组合
    因此是有特殊条件的回溯，需要记录添加进去的括号数量，然后进行判断
     */
    public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        BackTrack(new StringBuilder(), 0, 0, n, result);
        return result;
    }
    
    void BackTrack(StringBuilder sb, int open, int close, int n, IList<string> result){
        if(sb.Length == n * 2){
            result.Add(sb.ToString());
            return; 
        }
        
        if(open < n){
            sb.Append('(');
            BackTrack(sb, open + 1, close, n, result);
            sb.Length = sb.Length - 1;
        }
        
        if(close < open){
            sb.Append(')');
            BackTrack(sb, open, close + 1, n, result);
            sb.Length = sb.Length - 1;
        }
    }
}
