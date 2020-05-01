using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Third
{

    public class WordBreakII : MonoBehaviour
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
        https://leetcode.com/problems/word-break-ii/
        Tag:回溯 动态规划

        思路：使用回溯进行解决，会导致TLE错误
        */
        HashSet<string> hashSet;
        public IList<string> WordBreak(string s, IList<string> wordDict) {
            hashSet = new HashSet<string>(wordDict);
            IList<string> res = new List<string>();
            BackTrack(res, new List<string>(), 0, s);
            return res;
        }
        
        void BackTrack(IList<string> res, List<string> temp, int start, string s){
            if (start > s.Length) return;
            if (start == s.Length){
                StringBuilder sb = new StringBuilder();
                foreach (string str in temp){
                    sb.Append(str + " ");
                }
                sb.Length = sb.Length - 1;
                res.Add(sb.ToString());
                return ;
            }
            
            for (int i = 1; i <= s.Length - start; i++){
                string sub = s.Substring(start, i);
                if (hashSet.Contains(sub)){
                    temp.Add(sub);
                    BackTrack(res, temp, start + i, s);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }
    }

}