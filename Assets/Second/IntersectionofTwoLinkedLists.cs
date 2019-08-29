using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionofTwoLinkedLists : MonoBehaviour
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
    https://leetcode.com/problems/intersection-of-two-linked-lists/
    O(n)空间解法
     */
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        HashSet<ListNode> hashSet = new HashSet<ListNode>();
        
        ListNode node = headA;
        while(node != null){
            hashSet.Add(node);
            node = node.next;
        }
        
        node = headB;
        while(node != null && !hashSet.Contains(node)){
            node = node.next;
        }
        
        return node;
    }


    /**
    Discuss O(1)空间解法
    在一个链表的结点遇到空结点后，可以令这个指针指向另一个结点的开头，一直到两个结点相等为止
     */
    public ListNode GetIntersectionNode_(ListNode headA, ListNode headB) {
        if (headA == null || headB == null){
            return null;
        }
        
        ListNode a = headA, b = headB;
        
        while(a != b){
            a = a == null ? headB : a.next;
            b = b == null ? headA : b.next;
        }
        
        return a;
    }
}
