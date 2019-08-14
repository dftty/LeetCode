using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListCycleII : MonoBehaviour
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
    https://leetcode.com/problems/linked-list-cycle-ii/

    O(n)空间解法
     */
    public ListNode DetectCycle(ListNode head) {
        HashSet<ListNode> dic = new HashSet<ListNode>();
        
        ListNode node = head;
        while(node != null){
            if(dic.Contains(node)){
                return node;
            }
            
            dic.Add(node);
            node = node.next;
        }
        
        return null;
    }


    /**
    O(1) 空间解法
    Discuss 解释如下
    https://leetcode.com/problems/linked-list-cycle-ii/discuss/44793/O(n)-solution-by-using-two-pointers-without-change-anything
     */
    public ListNode DetectCycle__(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;
        
        bool hasCircle = false;
        
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
            
            if(slow == fast){
                hasCircle = true;
                break;
            }
        }
        
        if(!hasCircle){
            return null;
        }
        
        fast = head;
        while(fast != slow){
            slow = slow.next;
            fast = fast.next;
        }
        
        return fast;
    }
}
