using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LeetCode_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/add-two-numbers/description/
	// 2018/6/23
	
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        ListNode result = null;
        while(l1 != null){
            sb1.Append(l1.val + "");
            l1 = l1.next;
        }
        
        while(l2 != null){
            sb2.Append(l2.val + "");
            l2 = l2.next;
        }
        
        int index1 = 0;
        int index2 = 0;
        
        StringBuilder res = new StringBuilder();
        int temp = 0;
        while(index1 < sb1.Length || index2 < sb2.Length){
            int sum = 0;
            if(index1 < sb1.Length) sum += sb1[index1++] - '0';
            if(index2 < sb2.Length) sum += sb2[index2++] - '0';
            
            sum += temp;
            
            res.Append((sum % 10) + "");
            temp = sum / 10;
        }
        
        if(temp != 0) res.Append(temp + "");
        
        ListNode tempNode = null;
        for(int i = 0; i < res.Length ; i++){
            if(i == 0){
                result = new ListNode(res[i] - '0');
                tempNode = result;
            }else{
                tempNode.next = new ListNode(res[i] - '0');
                tempNode = tempNode.next;
            }
        }
        return result;
    }
}
