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
        Tag:  回溯

        思路：使用回溯来对所有组合进行穷举

        技巧：在解题过程中，如果能使用数组代替哈希表或者字典，那么就使用数组，这样对于大量的递归遍历来说，
        数组在时间和内存上会有很大的节省。

        */

        public bool IsSolvable(string[] words, string result) {
            int[] charValue = new int[26];

            HashSet<char> charSet = new HashSet<char>();
            bool[] head = new bool[26];
            for (int i = 0; i < words.Length; i++){
                head[words[i][0] - 'A'] = true;
                for (int j = 0; j < words[i].Length; j++){
                    charSet.Add(words[i][j]);

                    charValue[words[i][j] - 'A'] += (int)Math.Pow(10, words[i].Length - j - 1);
                }
            }
            
            head[result[0] - 'A'] = true;
            for (int i = 0; i < result.Length; i++){
                charSet.Add(result[i]);

                charValue[result[i] - 'A'] -= (int)Math.Pow(10, result.Length - i - 1);
            }
            
            char[] list = new List<char>(charSet).ToArray();
            return BackTrack(list, 0, new bool[10], head, 0L, charValue);
        }
        
        bool BackTrack(char[] charList, int start, bool[] use, bool[] head, long sum, int[] charValue){
            if (start == charList.Length) {
                return sum == 0;
            }
            
            for (int i = 0; i < 10; i++){
                if (i == 0 && head[charList[start] - 'A']) continue;
                if (!use[i]) {
                    use[i] = true;
                    if (BackTrack(charList, start + 1, use, head, sum + charValue[charList[start] - 'A'] * i, charValue)){
                        return true;
                    }

                    use[i] = false;
                }   
            }
            
            return false;
        }


        /**

        该解法在c#中导致了TLE。
        原因分析： 使用回溯时应该在遇到正确解法的时候就返回，而不是把所有的情况全部遍历一遍
        使用dic，set之类的也会大量增加时间
         
        public bool IsSolvable(string[] words, string result) {
            int[] charValue = new int[128];

            HashSet<char> charSet = new HashSet<char>();
            bool[] head = new bool[128];
            for (int i = 0; i < words.Length; i++){
                head[words[i][0]] = true;
                for (int j = 0; j < words[i].Length; j++){
                    charSet.Add(words[i][j]);

                    charValue[words[i][j] - 'A'] += (int)Math.Pow(10, words[i].Length - i - 1);
                }
            }
            
            head[result[0]] = true;
            for (int i = 0; i < result.Length; i++){
                charSet.Add(result[i]);

                charValue[result[i] - 'A'] -= (int)Math.Pow(10, result.Length - i - 1);
            }
            
            char[] list = new List<char>(charSet).ToArray();
            return BackTrack(list, 0, new bool[10], head, 0L, charValue);
        }
        
        bool BackTrack(char[] charList, int start, bool[] use, bool[] head, long sum, int[] charValue){
            if (start == charList.Length) {
                return sum == 0;
            }
            
            for (int i = 0; i < 10; i++){
                if (i == 0 && head[charList[start]]) continue;
                if (use[i]) continue;
                use[i] = true;
                if (BackTrack(charList, start + 1, use, head, sum + charValue[charList[start] - 'A'] * i, charValue)){
                    return true;
                }
                use[i] = false;
            }
            
            return false;
        }

        */
    }

}