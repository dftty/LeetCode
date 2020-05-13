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

        /**
        使用字典缓存结果
        */
        public IList<string> WordBreak_(string s, IList<string> wordDict) {
            return BackTrack(s, new HashSet<string>(wordDict), new Dictionary<string, IList<string>>());
        }
        
        IList<string> BackTrack(string s, HashSet<string> word, Dictionary<string, IList<string>> dic){
            if (dic.ContainsKey(s)){
                return dic[s];
            }
            
            if (string.IsNullOrEmpty(s)){
                return new List<string>(){""};
            }
            
            IList<string> res = new List<string>();

            foreach (string str in word){
                if (s.StartsWith(str)){
                    IList<string> list = BackTrack(s.Substring(str.Length), word, dic);
                    foreach (string st in list){
                        res.Add(str + (st.Length == 0 ? "" : " ") + st);
                    }
                }
            }
            
            dic.Add(s, res);
            return res;
        }
    }

}