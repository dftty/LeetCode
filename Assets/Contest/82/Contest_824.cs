using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Contest_824 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(ToGoatLatin("The quick brown fox jumped over the lazy dog"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Easy https://leetcode.com/problems/most-profit-assigning-work/description/
    // 2018/4/29
    // string Substring 方法， 参数为，起始位置，长度。
	public string ToGoatLatin(string S) {
        string[] strs = S.Split(' ');
        string vowel = "aeiouAEIOU";
        
        StringBuilder sb = new StringBuilder();
        
        if(strs != null && strs.Length > 0){
            for(int i = 0; i < strs.Length; i++){
                StringBuilder temp = new StringBuilder();
                
                if(vowel.Contains(strs[i].Substring(0, 1))){
                    temp.Append(strs[i]);
                }else {
					if(strs[i].Length > 1){
						temp.Append(strs[i].Substring(1, strs[i].Length - 1));
						temp.Append(strs[i][0]);
					}else{
						temp.Append(strs[i][0]);
					}
                }
                temp.Append("ma");
                for(int j = 0; j < i + 1; j++){
                    temp.Append("a");
                }
                
                sb.Append(temp.ToString() + " ");
            }
        }
        
        if(sb.Length > 0){
            return sb.ToString().Substring(0, sb.Length - 1);
        }else{
			return sb.ToString();
		}
		
    }
}
