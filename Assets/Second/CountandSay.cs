using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class CountandSay : MonoBehaviour
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
    https://leetcode.com/problems/count-and-say/

    每次遍历计算每个字符的数量，然后重新组成字符串
     */
    public string CountAndSay(int n) {
        string s = "1";
        
        for(int i = 1; i < n; i++){
            StringBuilder sb = new StringBuilder();
            int index = 0;
            while(index < s.Length){
                int num = s[index] - '0';
                int count = 1;
                while(index + 1 < s.Length && s[index] == s[index + 1]){
                    count++;
                    index++;
                }
                
                sb.Append(count);
                sb.Append(num);
                index++;
            }
            s = sb.ToString();
        }
        
        return s;
    }
}
