using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_23 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Hard https://leetcode.com/problems/merge-k-sorted-lists/description/
    // 2018/7/3
    // loop array, merge each list.
	public ListNode MergeKLists(ListNode[] lists) {
        if(lists == null || lists.Length == 0) return null;
        ListNode result = lists[0];
        
        for(int i = 1; i < lists.Length; i++){
            result = Merge(result, lists[i]);
        }
        
        return result;
    }
    
    public ListNode Merge(ListNode l1, ListNode l2){
        ListNode result = new ListNode(0);
        ListNode node = result;
        while(l1 != null || l2 != null){
            ListNode temp = new ListNode(0);
            if(l1 != null && l2 != null){
                if(l1.val > l2.val){
                    temp.val = l2.val;
                    l2 = l2.next;
                }else{
                    temp.val = l1.val;
                    l1 = l1.next;
                }
            }else if(l1 != null){
                temp.val = l1.val;
                l1 = l1.next;
            }else{
                temp.val = l2.val;
                l2 = l2.next;
            }
            node.next = temp;
            node = temp;
        }
        return result.next;
    }


    // Discuss solution
    public ListNode MergeKLists_(ListNode[] lists) {
        return partition(lists, 0, lists.Length-1);
    }
    
   public static ListNode partition(ListNode[] lists,int s,int e)
   {
        if(s==e)  return lists[s];
        if(s<e)
        {
            int q=(s+e)/2;
            ListNode l1=partition(lists,s,q);
            ListNode l2=partition(lists,q+1,e);
            return merge(l1,l2);
        }
           else
            return null;
    }

    
   public static ListNode merge(ListNode l1,ListNode l2)
   {
        if(l1==null) return l2;
        if(l2==null) return l1;
        if(l1.val<l2.val)
        {
            l1.next=merge(l1.next,l2);
            return l1;
        }
       else
        {
            l2.next=merge(l1,l2.next);
            return l2;
        }
    }
}
