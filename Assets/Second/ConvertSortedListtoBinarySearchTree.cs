using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertSortedListtoBinarySearchTree : MonoBehaviour
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
    https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/

    Discuss 解法， 递归构造
     */
    public TreeNode SortedListToBST(ListNode head) {
        if(head == null){
            return null;
        }
        
        TreeNode res = toBST(head, null);
        return res;
    }
    
    public TreeNode toBST(ListNode head, ListNode tail){
        ListNode slow = head;
        ListNode fast = head;
        
        if(head == tail){
            return null;
        }
        
        // 这里注意fast判断条件都为tail
        /**
        使用一个慢指针，一个快指针，可以快速找到这个链表的中点。
         */
        while(fast != tail && fast.next != tail){
            fast = fast.next.next;
            slow = slow.next;
        }
        TreeNode root = new TreeNode(slow.val);
        root.left = toBST(head, slow);
        root.right = toBST(slow.next, tail);
        
        return root;
    }
}
