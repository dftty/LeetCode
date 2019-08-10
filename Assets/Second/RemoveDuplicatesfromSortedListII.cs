using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDuplicatesfromSortedListII : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/

    额外创建一个头结点，然后遍历
     */
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode res = new ListNode(0);
        res.next = head;
        ListNode first = res;
        
        while(first != null){
            ListNode node = first.next;
            if(node != null){
                ListNode second = node;
                int count = 1;
                while(second.next != null && second.val == second.next.val){
                    second = second.next;
                    count++;
                }
                
                if(count > 1){
                    // 表示有移除的结点，first结点不需要改变
                    first.next = second.next;
                }else{
                    first.next = second;
                    first = first.next;
                }
                
            }else{
                first = node;
            }
            
            
        }
        
        return res.next;
        
    }
}
