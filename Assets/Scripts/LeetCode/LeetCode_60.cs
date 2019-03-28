using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_60 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("me".Replace('m', 'a'));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/permutation-sequence/description/
	// 2018/8/15
	// Discuss solution O(n)   https://leetcode.com/problems/permutation-sequence/discuss/22507/%22Explain-like-I'm-five%22-Java-Solution-in-O(n)
	public string GetPermutation(int n, int k) {
		// 阶乘数组
        int[] factorial = new int[n + 1];
        List<int> list = new List<int>();
        StringBuilder sb = new StringBuilder();
        factorial[0] = 1;
        int sum = 1;
        for(int i = 1; i <= n; i++){
            sum = sum * i;
            factorial[i] = sum;
            list.Add(i);
        }
        
        k--;
        
        for(int i = n; i > 0 ;i--){
            int index = k / factorial[i - 1];
            sb.Append(list[index]);
            list.RemoveAt(index);
            k = k - index * factorial[i - 1];
        }
        return sb.ToString();
    }
}
