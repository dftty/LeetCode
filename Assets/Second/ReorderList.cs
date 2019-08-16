using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReorderList : MonoBehaviour
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
    https://leetcode.com/problems/reorder-list/
    使用一个List记录所有节点，然后重新赋值

    做题过程中犯了一个错误，忘记清除之前所有节点的next节点，导致了题目检测TLE问题
     */
    public void ReorderList_(ListNode head) {
        List<ListNode> list = new List<ListNode>();
        
        ListNode node = head;
        while(node != null){
            list.Add(node);
            node = node.next;
        }
        
        ListNode res = new ListNode(0);
        node = res;
        while(list.Count > 0){
            node.next = list[0];
            node.next.next = null;
            list.RemoveAt(0);
            node = node.next;
            if(list.Count > 0){
                node.next = list[list.Count - 1];
                node.next.next = null;
                list.RemoveAt(list.Count - 1);
                node = node.next;
            }
        }
    }


    /**
    Discuss 解法，首先反转后一半列表，然后迭代重新链接
    https://leetcode.com/problems/reorder-list/discuss/44992/Java-solution-with-3-steps
     */
    public void ReorderList_Discuss(ListNode head) {
        if(head == null || head.next == null) return ;
        ListNode fast = head;
        ListNode slow = head;
        while(fast.next != null && fast.next.next != null){
            fast = fast.next.next;
            slow = slow.next;
        }
        
        ListNode preMiddle = slow;
        ListNode preCurrent = slow.next;
        while(preCurrent.next != null){
            ListNode current = preCurrent.next;
            preCurrent.next = current.next;
            current.next = preMiddle.next;
            preMiddle.next = current;
        }
        
        slow = head;
        fast = preMiddle.next;
        while(slow != preMiddle){
            preMiddle.next = fast.next;
            fast.next = slow.next;
            slow.next = fast;
            slow = fast.next;
            fast = preMiddle.next;
        }
    }
}
