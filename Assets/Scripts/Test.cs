﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.Diagnostics;
using System.Linq;

public class Test : MonoBehaviour {

        void Start()
        {
            string[] words = new string[]{"SIX","SEVEN","SEVEN"};
            string result = "TWENTY";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            IsSolvable(words, result);
            UnityEngine.Debug.Log(sw.ElapsedMilliseconds);
            UnityEngine.Debug.Log(count);

            int[] arr = new int[3];
            
            Array.Sort(arr, new IntCompare());

            AssetBundle ab = AssetBundle.LoadFromFile("");
            ab.LoadAssetAsync("name");
        }

        public class IntCompare : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return 0;
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public int[] MaxSlidingWindow(int[] nums, int k) {
            if (nums == null || nums.Length == 0) return new int[0];
            int[] res = new int[nums.Length - k + 1];
            
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < nums.Length; i++){
                while (list.Count > 0 && list.First.Value < i - k + 1){
                    list.RemoveFirst();
                }

                while (list.Count > 0 && nums[list.Last.Value] < nums[i]){
                    list.RemoveLast();
                }

                list.AddLast(nums[i]);
                if (i - k + 1 > 0){
                    res[i - k + 1] = nums[list.First.Value];
                }
            }

            return res;
        }

        public void T(int a)
        {

        }

        public int T(int a, int b)
        {
            return 0;
        }

        /**
        
        */
        int count = 0;

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
            count++;
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

    //     public bool IsSolvable(string[] words, string result)
    // {
    //     int[] charValues = new int[26];
    //     bool[] isFirstWordChar = new bool[26];

    //     HashSet<char> charsSet = new HashSet<char>();
    //     foreach (var word in words)
    //     {
    //         for (int i = 0; i < word.Length; i++)
    //         {
    //             if (i == 0)
    //             {
    //                 isFirstWordChar[word[i] - 'A'] = true;
    //             }
    //             charsSet.Add(word[i]);
    //             // set value to power of 10 starting from LSB
    //             charValues[word[i] - 'A'] += (int)Math.Pow(10, word.Length - i - 1);
    //         }
    //     }

    //     for (int i = 0; i < result.Length; i++)
    //     {
    //         if (i == 0)
    //         {
    //             isFirstWordChar[result[i] - 'A'] = true;
    //         }
    //         charsSet.Add(result[i]);
    //         charValues[result[i] - 'A'] -= (int)Math.Pow(10, result.Length - i - 1);
    //     }

    //     int visited = 0;
    //     long sum = 0L;
    //     char[] distinctChars = charsSet.ToArray();
    //     UnityEngine.Debug.Log(distinctChars.Length);

    //     if (dfs(0, distinctChars, visited, sum, isFirstWordChar, charValues))
    //     {
    //         return true;
    //     }

    //     return false;
    // }

    // private bool dfs(int charIndex, char[] distinctChars, int visited, long sum, bool[] isFirstWordChar, int[] charValues)
    // {
    //     count++;
    //     if (charIndex == distinctChars.Length)
    //     {
    //         return sum == -10;
    //     }

    //     for (int d = 0; d <= 9; d++)
    //     {
	// 	    // #3: Each words[i] and result are decoded as one number without leading zeros.
    //         if (d == 0 && isFirstWordChar[distinctChars[charIndex] - 'A'])
    //         {
    //             continue;
    //         }

    //         if ((visited & (1 << d)) == 0)
    //         {
    //             visited |= (1 << d);

    //             if (dfs(charIndex + 1, distinctChars, visited, sum + charValues[distinctChars[charIndex] - 'A'] * d, isFirstWordChar, charValues))
    //             {
    //                 return true;
    //             }

    //             visited ^= (1 << d);
    //         }
    //     }

    //     return false;
    // }
    
      
}

public class IteratorSample : IEnumerable
{
    object[] values;
    int startPoint;

    public IteratorSample(object[] values, int startPoint)
    {
        this.values = values;
        this.startPoint = startPoint;
    }

    public IEnumerator GetEnumerator()
    {
        //return new IterationIteratorSample(this);

        for (int index = 0; index < values.Length; index++){
            yield return values[(index + startPoint) % values.Length];
        }
    }

    class IterationIteratorSample : IEnumerator
    {
        IteratorSample parent;
        int position;

        public IterationIteratorSample(IteratorSample parent)
        {
            this.parent = parent;
            this.position = -1;
        }

        public bool MoveNext()
        {
            if (position != parent.values.Length){
                position++;
            }
            return position < parent.values.Length;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position == parent.values.Length)
                {
                    throw new Exception();
                }
                
                int index = position + parent.startPoint;
                index = index % parent.values.Length;
                return parent.values[index];
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}