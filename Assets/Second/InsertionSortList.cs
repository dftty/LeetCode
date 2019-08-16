using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSortList : MonoBehaviour
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
    https://leetcode.com/problems/insertion-sort-list/

    对链表实现插入排序，可以创建一个新链表，然后遍历传入链表，每次取第一个值，然后和新链表从头到尾进行比较，然后插入对应位置.!--
     */
    public ListNode InsertionSortList_(ListNode head) {
        ListNode node = new ListNode(int.MinValue);
        
        ListNode remain = head;
        ListNode pre = node;
        while(remain != null){
            ListNode temp = remain;
            remain = remain.next;
            temp.next = null;
            while(pre.next != null && pre.next.val < temp.val){
                pre = pre.next;
            }
            
            if(pre.next != null){
                temp.next = pre.next;
            }
            pre.next = temp;
            pre = node;
        }
        return node.next;
    }
}
