using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class RestoreIPAddresses : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(RestoreIpAddresses("2552"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/restore-ip-addresses/submissions/

    回溯法，那么久是使用递归，首先应该想好返回条件和答案的添加条件是什么
    数字长度是1到3，因此循环长度为1到3
    每添加一个数字，后面添加一个 .  然后添加的点的数量加一，当点的数量达到4的时候说明IP组合完成
    然后需要判断是否使用了全部的字符串，如果是，则添加字符串并去掉最后一个点。
     */
    public IList<string> RestoreIpAddresses(string s) {
        IList<string> res = new List<string>();
        BackTrack(res, new StringBuilder(), s, 0, 0);
        
        return res;
    }
    
    public void BackTrack(IList<string> res,StringBuilder sb, string s, int startIndex, int dotCount){
        if(dotCount == 4 && sb.Length - 4 == s.Length){
            res.Add(sb.ToString().Substring(0, sb.Length - 1));
            return ;
        }
        if(dotCount == 4){
            return ;
        }
        
        for(int i = 1; i <= 3 ; i++){
            if(startIndex + i > s.Length) return ;
            int num = int.Parse(s.Substring(startIndex, i));
            if(num >= 0 && num <= 255){
                sb.Append(num + ".");
                BackTrack(res, sb, s, startIndex + i, dotCount + 1);
                sb.Length = sb.Length - num.ToString().Length - 1;
            }
        }
    }
}
