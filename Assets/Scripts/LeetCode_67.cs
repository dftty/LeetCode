using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_67 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AddBinary("101111", "10");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Easy https://leetcode.com/problems/add-binary/description/
	// 2018/6/2
    public string AddBinary(string a, string b) {
        StringBuilder sb = new StringBuilder();
        
        if(a.Length < b.Length){
			int length = b.Length - a.Length;
            for(int i = 0; i < length; i++){
                a = "0" + a;
            }
        }else{
			int length = a.Length - b.Length;
            for(int i = 0; i < length; i++){
                b = "0" + b;
            }
        }
        Debug.Log(b);
        bool isAdd = false;
        for(int i = a.Length - 1; i >= 0; i--){
            if(isAdd){
                if(a[i] == '1' && b[i] == '1'){
                    sb.Insert(0, "1");
                }else if((a[i] == '1' && b[i] == '0') || (a[i] == '0' && b[i] == '1')){
                    sb.Insert(0, "0");
                }else{
                    sb.Insert(0, "1");
                    isAdd = false;
                }
            }else{
                if(a[i] == '1' && b[i] == '1'){
                    sb.Insert(0, "0");
                    isAdd = true;
                }else if((a[i] == '1' && b[i] == '0') || (a[i] == '0' && b[i] == '1')){
                    sb.Insert(0, "1");
                }else{
                    sb.Insert(0, "0");
                }
            }
        }
        if(isAdd) sb.Insert(0, "1");
        
        return sb.ToString();
    }

	public string AddBinary_(string a, string b) {
        StringBuilder sb = new StringBuilder();
        
        int i = a.Length;
		int j = b.Length;
		int carry = 0;
		while(i < a.Length || j < b.Length){
			int sum = carry;
			if(i < a.Length) sum = a[i] - '0';
			if(j < b.Length) sum = b[i] - '0';

			sb.Append(sum % 2);
			carry = sum / 2;
		}
        
        return sb.ToString();
    }
}
