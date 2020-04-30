using System.Collections;
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
        }

        // Update is called once per frame
        void Update()
        {
            
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
    public TreeNode GetNext(TreeNode node)
    {
        TreeNode right = node.right;
        if (right != null)
        {
            while (right.left != null)
            {
                right = right.left;
            }
            return right;
        }

        TreeNode parent = node.parent;
        if (parent != null && parent.left == node)
        {
            return parent;
        }
        while (parent != null && parent.left != node)
        {
            node = parent;
            parent = node.parent;
        }

        if (parent != null)
        {
            return parent;
        }

        return null;
    }

    public class Queue
    {
        private Stack<int> stack_1;
        private Stack<int> stack_2;

        public Queue()
        {
            stack_1 = new Stack<int>();
            stack_2 = new Stack<int>();
        }

        // O(1) 时间
        public void AppendTail(int num)
        {
            stack_1.Push(num);
        }

        // O(n) 时间
        // public int DeleteHead()
        // {
        //     if (stack_1.Count == 0)
        //     {
        //         throw new Exception("Queue is empty");
        //     }

        //     while (stack_1.Count > 1)
        //     {
        //         stack_2.Push(stack_1.Pop());
        //     }

        //     int result = stack_1.Pop();

        //     while (stack_2.Count > 0)
        //     {
        //         stack_1.Push(stack_2.Pop());
        //     }

        //     return result;
        // }

        
        public int DeleteHead()
        {
            if (stack_2.Count == 0)
            {
                while (stack_1.Count > 0)
                {
                    stack_2.Push(stack_1.Pop());
                }
            }

            if (stack_2.Count == 0)
            {
                throw new Exception("Queue is empty");
            }

            return stack_2.Pop();
        }   

        public string MaxSubArray(string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++){
                if (sb.Length == 0){
                    sb.Append(str[i]);
                }else
                {
                    int index = sb.Length;
                    for (; index > 0; index--){
                        if (sb[index - 1] >= str[i]){
                            break;
                        }
                    }
                    sb.Length = index - 1 >= 0 ? index - 1 : 0;
                    sb.Append(str[i]);
                }
            }

            return sb.ToString();
        }
    }
      
}
