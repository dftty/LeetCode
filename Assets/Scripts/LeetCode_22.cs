using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_22 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GenerateParenthesis(3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/generate-parentheses/description/
	// Discuss solution
	public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
		BackTrack(result, "", n , 0);
		return result;
    }

	public void BackTrack(IList<string> result, string sb, int m, int n){
		if(m ==0 && n == 0){
			result.Add(sb);
			return ;
		}

		if(n > 0) BackTrack(result, sb + ")", m, n - 1);
		if(m > 0) BackTrack(result, sb + "(", m - 1, n + 1);
	}
}
