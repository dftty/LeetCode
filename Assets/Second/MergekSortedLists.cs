using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergekSortedLists : MonoBehaviour
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
    https://leetcode.com/problems/merge-k-sorted-lists/

    思路：将ListNode数组转化成List，然后每次遍历List，找出最小值，添加到结果中，然后移除null结点，一直到list数组长度为0
     */
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode res = new ListNode(0);
        ListNode node = res;
        List<ListNode> list = new List<ListNode>();
        
        
        
        if(lists == null || lists.Length == 0){
            return res.next;
        }
        
        for(int i = 0; i < lists.Length; i++){
            if(lists[i] != null){
                list.Add(lists[i]);
            }
        }
        
        bool isEnd = false;
        
        while(!isEnd && list.Count > 0){
            int num = list[0].val;
            int index = 0;
            for(int i = 0; i < list.Count; i++){
                if(num > list[i].val){
                    num = list[i].val;
                    index = i;
                }
            }
            
            node.next = new ListNode(list[index].val);
            node = node.next;
            list[index] = list[index].next;
            
            if(list[index] == null){
                list.RemoveAt(index);
            }
            
            if(list.Count == 0){
                isEnd = true;
            }
        }
        
        return res.next;
        
    }


    /**
    采用分治法，分别合并node，时间比上面方法减少了三倍左右
     */
    public ListNode MergeKLists_(ListNode[] lists) {
        if(lists == null || lists.Length == 0){
            return null;
        }else if(lists.Length == 1){
            return lists[0];
        }else if(lists.Length == 2){
            return MergeLists(lists[0], lists[1]);
        }else {
            int len = lists.Length / 2;
            ListNode[] node1 = new ListNode[len];
            ListNode[] node2 = new ListNode[lists.Length - len];
            
            for(int i = 0; i < lists.Length; i++){
                if(i >= len){
                    node2[i - len] = lists[i];
                }else {
                    node1[i] = lists[i];
                }
            }
            
            return MergeLists(MergeKLists(node1), MergeKLists(node2));
        }
    }
    
    public ListNode MergeLists(ListNode node1, ListNode node2){
        ListNode res = new ListNode(0);
        ListNode node = res;
        while(node1 != null || node2 != null){
            if(node1 == null){
                node.next = node2;
                node2 = node2.next;
                node = node.next;
                continue;
            }
            
            if(node2 == null){
                node.next = node1;
                node1 = node1.next;
                node = node.next;
                continue;
            }
            
            if(node1.val < node2.val){
                node.next = node1;
                node1 = node1.next;
            }else{
                node.next = node2;
                node2 = node2.next;
            }
            node = node.next;
        }
        
        return res.next;
    } 
}
