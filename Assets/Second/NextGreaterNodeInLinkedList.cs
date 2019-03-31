using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGreaterNodeInLinkedList : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Next Greater Node In Linked List
	We are given a linked list with head as the first node.  Let's number the nodes in the list: node_1, node_2, node_3, ... etc.

	Each node may have a next larger value: for node_i, next_larger(node_i) is the node_j.val such that j > i, node_j.val > node_i.val, and j is the smallest possible choice.  If such a j does not exist, the next larger value is 0.

	Return an array of integers answer, where answer[i] = next_larger(node_{i+1}).

	以下为O(n^2)解法

	 */
	public int[] NextLargerNodes(ListNode head) {
        List<int> result = new List<int>();

        ListNode leftMaxNode = head;
        Dictionary<int, int> zeroIndex = new Dictionary<int, int>();
        while(head != null){
            if(head.next != null && head.next.val > head.val){
                while(leftMaxNode != head.next){
                    if(leftMaxNode.val >= head.next.val){
                        result.Add(0);
                        zeroIndex.Add(result.Count - 1, leftMaxNode.val);
                    }else{
                        result.Add(head.next.val);
                    }
                    leftMaxNode = leftMaxNode.next;
                }

                leftMaxNode = head.next;
            }
            head = head.next;
        }
        
        while(leftMaxNode != null){
            result.Add(0);
            leftMaxNode = leftMaxNode.next;
        }
        
        int[] array = result.ToArray();
        for(int i = 0; i < array.Length; i++){
            if(array[i] == 0 && zeroIndex.ContainsKey(i)){
                int temp = zeroIndex[i];
                for(int j = i + 1; j < array.Length; j++){
                    if(temp < array[j]){
                        array[i] = array[j];
                        break;
                    }
                }
            }
        }
        
        return array;
    }

	/**
	使用栈，可以将递减的数列的值和下标依次放入栈中，当遇到比栈顶大的数时，栈顶出栈，然后将结果数组中该下标的值设置为当前的值。
	 */
	public int[] NextLargerNodes_(ListNode head) {
        int length = 0;
        ListNode temp = head;
        while(temp != null){
            length++;
            temp = temp.next;
        }
        Stack<Pair> stack = new Stack<Pair>();
        int[] result = new int[length];
        length = 0;
        while(head != null){
            while(stack.Count > 0 && head.val > stack.Peek().val){
                Pair pair = stack.Pop();
                result[pair.index] = head.val;
            }
            
            stack.Push(new Pair(head.val, length++));
            head = head.next;
        }
        
        
        return result;
    }
    
    public struct Pair{
        public int val;
        public int index;
        
        public Pair(int val, int index){
            this.val = val;
            this.index = index;
        }
    }
}
