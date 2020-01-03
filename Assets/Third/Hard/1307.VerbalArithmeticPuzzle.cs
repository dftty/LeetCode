using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Third
{

    public class VerbalArithmeticPuzzle : MonoBehaviour
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
        https://leetcode.com/problems/verbal-arithmetic-puzzle/
        Hard
        Tag:  广度优先搜索

        */
        bool valid = false;
        public bool IsSolvable(string[] words, string result) {
            HashSet<char> charSet = new HashSet<char>();
            HashSet<char> headSet = new HashSet<char>();
            for (int i = 0; i < words.Length; i++){
                headSet.Add(words[i][0]);
                for (int j = 0; j < words[i].Length; j++){
                    charSet.Add(words[i][j]);
                }
            }
            
            headSet.Add(result[0]);
            for (int i = 0; i < result.Length; i++){
                charSet.Add(result[i]);
            }
            
            List<char> charList = new List<char>(charSet);
            HashSet<int> numSet = new HashSet<int>();
            BackTrack(charList, 0, numSet, headSet, new Dictionary<char, int>(), words, result);
            return valid;
        }
        
        void BackTrack(List<char> charList, int start, HashSet<int> numSet, HashSet<char> headSet, Dictionary<char, int> dic, string[] words, string result){
            if (start > charList.Count) return ;
            
            if (start < charList.Count){
                for (int i = 0; i < 10; i++){
                    if (i == 0 && headSet.Contains(charList[start])) continue;
                    if (numSet.Contains(i)) continue;
                    
                    numSet.Add(i);
                    dic.Add(charList[start], i);
                    BackTrack(charList, start + 1, numSet, headSet, dic, words, result);
                    numSet.Remove(i);
                    dic.Remove(charList[start]);
                }
            }else {
                Check(dic, words, result);
            }
        }
        
        void Check(Dictionary<char, int> dic, string[] words, string result){
            int sum = 0;
            for (int i = 0; i < words.Length; i++){
                int num = 0;
                for (int j = 0; j < words[i].Length; j++){
                    num = num * 10 + dic[words[i][j]];
                }
                
                sum += num;
            }
            
            int res = 0;
            
            for (int i = 0; i < result.Length; i++){
                res = res * 10 + dic[result[i]];
            }
            
            if (sum == res){
                valid = true;
            }
        }
    }

}