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
    public TreeNode RecoverFromPreorder(string S) {
        if(string.IsNullOrEmpty(S)) return null;
        return Generate(S, 0);
    }
    
    public TreeNode Generate(string S, int currentDepth){
        if(index >= S.Length) return null;
        
        int tempIndex = index;
        int length = 0;
        while(tempIndex < S.Length && S[tempIndex] != '-'){
            length++;
            tempIndex++;
        }
        int num = int.Parse(S.Substring(index, length));
        TreeNode tempNode = new TreeNode(num);
        
        if(tempIndex >= S.Length) return tempNode;
        length = 0;
        while(tempIndex < S.Length && S[tempIndex] == '-'){
            length++;
            tempIndex++;
        }
        
        
        if(currentDepth + 1 != length){
            
            return tempNode;
        }
        
        index = tempIndex;
        
        tempNode.left = Generate(S, currentDepth + 1);
        tempNode.right = Generate(S, currentDepth + 1);
        
        return tempNode;
    }
}
