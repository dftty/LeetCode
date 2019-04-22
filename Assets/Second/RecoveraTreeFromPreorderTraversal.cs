using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveraTreeFromPreorderTraversal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int index = 0;

    /**
    Recover a Tree From Preorder Traversal

    首先我们可以想象有这样一道题，给你一个二叉树，输出类似于本题中的字符串。
    我们就可以想到可以用递归来解决这道题目，在每次遍历中，首先需要遍历'-'的数量，表示当前这个数在第几层
    每次递归将当前层数传递进去，就可以判断这个数是否在这一层

    Disscuss中有stack解法，和这个解法中的深度类似，遇到栈的数量大于深度时，出栈直到等于深度为止

     */
    public TreeNode RecoverFromPreorder(string S) {
        if(string.IsNullOrEmpty(S)) return null;
        return Generate(S, 0);
    }
    
    public TreeNode Generate(string S, int currentDepth){
        if(index >= S.Length) return null;
        
        // 首先计算当前的层数
        int tempIndex = index;
        int length = 0;
        while(tempIndex < S.Length && S[tempIndex] == '-'){
            length++;
            tempIndex++;
        }
        
        if(currentDepth != length){
            return null;
        }

        // 然后计算这个数字
        length = 0;
        index = tempIndex;
        while(tempIndex < S.Length && S[tempIndex] != '-'){
            length++;
            tempIndex++;
        }
        int num = int.Parse(S.Substring(index, length));
        TreeNode tempNode = new TreeNode(num);

        index = tempIndex;
        tempNode.left = Generate(S, currentDepth + 1);
        tempNode.right = Generate(S, currentDepth + 1);
        
        return tempNode;
    }
}
