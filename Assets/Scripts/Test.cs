using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RemoveOuterParentheses("(()())(())");
		//CamelMatch(new string[]{"FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"}, "FB");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string RemoveOuterParentheses(string S) {
        Stack<char> stack = new Stack<char>();
        StringBuilder sb = new StringBuilder();
		int startIndex = 0;
		int count = 0;
        for(int i = 0; i < S.Length; i++){
			count++;
			if(stack.Count == 1 && stack.Peek() == '(' && S[i] == ')'){
				sb.Append(S.Substring(startIndex, count).Substring(1, count - 2));
				stack.Pop();
				count = 0;
				startIndex = i + 1;
			}else if(stack.Count > 0 && stack.Peek() == '(' && S[i] == ')'){
				stack.Pop();
			}else{
				stack.Push(S[i]);
			}
        }
        
        return sb.ToString();
    }

    public int BFS(TreeNode root, int rootMax){
        if(root == null) return 0;
        
        int max = 0;
        int curMax = rootMax - root.val;
        int left = BFS(root.left, Math.Max(rootMax, root.val));
        int right = BFS(root.right, Math.Max(rootMax, root.val));
        
        max = Math.Max(curMax, left);
        max = Math.Max(max, right);
        
        return max;
    }

	public IList<bool> CamelMatch(string[] queries, string pattern) {
        IList<bool> result = new List<bool>();
        
        for(int i = 0; i < queries.Length; i++){
            int first = 0;
            int second = 0;
            string temp = queries[i];
            while(first < temp.Length && second < pattern.Length){
                if(temp[first++] == pattern[second++]) continue;
                else if(temp[first] >= 'a' && temp[first] <= 'z'){
                    first++;
                }else{
                    break;
                }
            }
            
            while(first < temp.Length && temp[first] >= 'a' && temp[first] <= 'z'){
                first++;
            }
            
            if(first == temp.Length && second == pattern.Length){
                result.Add(true);
            }else{
                result.Add(false);
            }
        }
        
        return result;
    }
}
