using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveZeroSumConsecutiveNodesfromLinkedList : MonoBehaviour
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
    https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list/

    技巧：数组中前缀和可以解决多种问题
    将链表转换为数组并且去掉链表中的0节点，然后计算这个数组的前缀和数组
     */
    public ListNode RemoveZeroSumSublists(ListNode head) {
        List<int> list = new List<int>();
        ListNode node = head;
        while (node != null){
            list.Add(node.val);
            node = node.next;
        }
        
        int[] preSum = new int[list.Count + 1];
        preSum[1] = list[0];
        for (int i = 2; i < preSum.Length; i++){
            preSum[i] += preSum[i - 1] + list[i - 1];
        }
        
        for (int left = 0; left < preSum.Length; left++){
            for (int right = preSum.Length - 1; right > left; right--){
                if (preSum[left] == preSum[right]){
                    for (int j = left + 1; j <= right && j < preSum.Length; j++){
                        list[j - 1] = 0;
                    }
                    left = right - 1;
                    break;
                }
            }
        }
        
        node = new ListNode(0);
        ListNode temp = node;
        for (int i = 0; i < list.Count; i++){
            if (list[i] != 0){
                temp.next = new ListNode(list[i]);
                temp = temp.next;
            }
        }
        
        return node.next;
    }


    /**
    递归解法
     */
    public ListNode RemoveZeroSumSublists_(ListNode head) {
        if (head == null) return null;
        ListNode node = head;
        int sum = 0;
        
        while (node != null){
            if (node.val + sum == 0) head = node.next;
            sum += node.val;
            node = node.next;
        }
        
        if (head != null){
            head.next = RemoveZeroSumSublists_(head.next);
        }
        
        return head;
    }
}
