using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListCycle : MonoBehaviour
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
    使用两个指针，一个快，一个慢，如果中间有环，那么最终快慢指针会指向同一个节点。
     */
    public bool HasCycle(ListNode head) {
        ListNode fast = head;
        ListNode slow = head;
        
        while(slow != null && fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
            
            if(fast == slow){
                return true;
            }
        }
        
        return false;
    }
}
