using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_17 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/generate-parentheses/description/
	// Discuss solution
	public IList<string> LetterCombinations(string digits) {
        List<string> ans = new List<string>();
		Queue<string> temp = new Queue<string>();
		if(digits.Equals("")) return ans;
		string[] mapping = new string[] {"0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
		temp.Enqueue("");
		for(int i =0; i<digits.Length;i++){
			int x = digits[i] - '0';
			while(temp.Peek().Length == i){
				string t = temp.Dequeue();
				foreach(char s in mapping[x].ToCharArray())
					temp.Enqueue(t+s);
			}
		}
		
		while(temp.Count > 0){
			ans.Add(temp.Dequeue());
		}

		return ans;
    }
}
