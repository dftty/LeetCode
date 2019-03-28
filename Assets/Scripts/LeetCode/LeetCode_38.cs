using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_38 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/count-and-say/description/
	// 2018/5/31
	public string CountAndSay(int n) {
        string first = "1";
        for(int i = 0; i < n - 1; i++){
            StringBuilder sb = new StringBuilder();
            int count = 0;
            char ch = first[0];
            int j = 0;
            while(j < first.Length){
                while(j < first.Length && ch == first[j]){
                    count++;
                    j++;
                }
                sb.Append(count + "" + ch);
                
                count = 0;
                ch = j == first.Length ? '0' : first[j];
            }
            first = sb.ToString();
        }
        
        return first;
    }
}
