using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyListwithRandomPointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Node node1 = new Node();
        Node node2 = new Node();
        node1.val = 1;
        node1.next = node2;
        node1.random = node2;
        node2.val = 2;
        node2.random = node2;
        CopyRandomList_(node1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /**
    https://leetcode.com/problems/copy-list-with-random-pointer/

    O(n) 空间解法，记录每个节点的下标
     */
    public Node CopyRandomList(Node head) {
        Dictionary<Node, int> dict = new Dictionary<Node, int>();
        
        if(head == null){
            return null;
        }
        
        int index = 0;
        Node node = head;
        while(node != null){
            dict.Add(node, index++);
            node = node.next;
        }
        
        List<Node> list = new List<Node>();
        
        Node res = new Node();
        res.val = 0;
        Node resNode = res;
        node = head;
        while(node != null){
            resNode.next = new Node();
            resNode.next.val = node.val;
            node = node.next;
            resNode = resNode.next;
            list.Add(resNode);
        }
        
        resNode  = res.next;
        node = head;
        while(node != null){
            // 这里注意字典的key不能为空
            if(node.random != null){
                resNode.random = list[dict[node.random]];
            }
            resNode = resNode.next;
            node = node.next;
        }
        
        return res.next;
    }

    /**
    
     */
    public Node CopyRandomList_(Node head) {
        Node res = head;
        
        if(head == null){
            return null;
        }
        Node temp = null;
        while(res != null){
            temp = res.next;
            Node node = new Node();
            node.val = res.val;
            res.next = node;
            node.next = temp;
            res = temp;
        }
        
        res = head;
        while(res != null){
            if(res.random != null){
                res.next.random = res.random.next;
            }
            
            res = res.next.next;
        }
        
        res = head;
        temp = new Node();
        temp.next = res;
        res = temp;
        // 做题时这里遇到了错误，没有把原始的链表恢复，导致题目验证一直错误
        while(temp.next != null){
            Node node = temp.next;
            temp.next = temp.next.next;
            node.next = temp.next.next;
            temp = temp.next;
        }
        return res.next;
        
    }
}

public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(){}
    public Node(int _val,Node _next,Node _random) {
        val = _val;
        next = _next;
        random = _random;
    }
}
