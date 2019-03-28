using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_82 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium 
	public ListNode DeleteDuplicates(ListNode head) {
        ListNode result = new ListNode(0);
        result.next = head;
        
        ListNode last = result;
        ListNode current = result.next;
        int? remove = null;
        
        while(current != null){
            if(remove.HasValue && remove.Value == current.val){
                last.next = current.next;
                current = last.next;
                continue;
            }
            if(current.next != null && current.val == current.next.val){
                remove = current.val;
                last.next = current.next;
                current = last.next;
            }else{
                last = current;
                current = current.next;
            }
        }
        
        
        
        return result.next;
    }
}
