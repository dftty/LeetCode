using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_138 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Medium https://leetcode.com/problems/copy-list-with-random-pointer/description/
	// 2018/6/30
	// Discuss solution
	// 1.Iterate the original list and duplicate each node. The duplicate
	//   of each node follows its original immediately.
	// 2.Iterate the new list and assign the random pointer for each
	//   duplicated node.
	// 3.Restore the original list and extract the duplicated nodes.
	public RandomListNode CopyRandomList(RandomListNode head) {
        RandomListNode itea = head, next;
        
        while(itea != null){
            next = itea.next;
            RandomListNode temp = new RandomListNode(itea.label);
            itea.next = temp;
            temp.next = next;
            itea = next;
        }
        
        itea = head;
        while(itea != null){
            if(itea.random != null){
                itea.next.random = itea.random.next;
            }
            itea = itea.next.next;
        }
        
        itea = head;
        RandomListNode copy, copyIt;
        copy = copyIt = new RandomListNode(0);
        RandomListNode result = copy;
        while(itea != null){
            next = itea.next.next;
            
            copy = itea.next;
            copyIt.next = copy;
            copyIt = copy;
            
            itea.next = next;
            itea = next;
        }
        
        return result.next;
    }

	public class RandomListNode {
		public int label;
		public RandomListNode next, random;
		public RandomListNode(int x) { this.label = x; }
	};
}
