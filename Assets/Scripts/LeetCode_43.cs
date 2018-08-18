using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_43 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(Multiply("408", "5"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Medium https://leetcode.com/problems/multiply-strings/description/
    // 2018/6/11
	public string Multiply(string num1, string num2) {
        StringBuilder sb = new StringBuilder();
        
        
        for(int i = num2.Length - 1; i >= 0; i--){
            int firstNum = num2[i] - '0';
            int secondNum = 0, carry = 0;
            int j = num1.Length - 1;
            //if(firstNum == 0) continue;
            
            StringBuilder temp = new StringBuilder();
            for(int k = num2.Length - i - 1; k > 0; k--){
                temp.Insert(0, "0");
            }
            while(j >= 0){
                secondNum = num1[j--] - '0';
                int sum = firstNum * secondNum;
                sum += carry;
                
                temp.Insert(0, sum % 10);
                carry = sum / 10;
            }
            
            if(carry > 0){
                temp.Insert(0, carry);
            }
            carry = 0;
            
            StringBuilder temp1 = new StringBuilder();
            int m = sb.Length - 1, n = temp.Length - 1;
            while(m >= 0 || n >= 0){
                int sum = 0;
                if(m >= 0) sum += sb[m--] - '0';
                if(n >= 0) sum += temp[n--] - '0';
                
                sum += carry;
                temp1.Insert(0, sum % 10);
                carry = sum / 10;
            }
            if(carry > 0){
                temp1.Insert(0, carry);
            }
            
            sb = temp1;
        }

        while(sb.Length > 1 && sb[0] == '0'){
            sb.Remove(0, 1);
        }

        
        return sb.ToString();
    }
}
