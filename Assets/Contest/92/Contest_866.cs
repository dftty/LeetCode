using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest_866 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TreeNode root = new TreeNode(3);

		TreeNode node_1 = new TreeNode(5);
		TreeNode node_2 = new TreeNode(6);

		TreeNode node_3 = new TreeNode(2);
		TreeNode node_4 = new TreeNode(7);

		TreeNode node_5 = new TreeNode(4);
		TreeNode node_6 = new TreeNode(1);

		TreeNode node_7 = new TreeNode(0);
		TreeNode node_8 = new TreeNode(8);

		root.left = node_1;
		root.right = node_6;
		node_1.left = node_2;
		node_1.right = node_3;
		node_3.left = node_4;
		node_3.right = node_5;
		node_6.left = node_7;
		node_6.right = node_8;

		SubtreeWithAllDeepest(root);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public TreeNode deepNode;

	public int maxdeep = -1;
	TreeNode result = null;
	public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        if(root == null) return root;
        int deep = 0;
        FindMin(deep, root);
        
		
		if(deepNode != null){
			result = Find(root, deepNode);
		}

		return result;
    }
    
    void FindMin(int deep, TreeNode root){
        if(root == null) return ;
        
        if(deep > maxdeep){
            maxdeep = deep;
            deepNode = root;
        }
        
        FindMin(++deep, root.left);
        deep--;
        FindMin(++deep, root.right);
        deep--;
    }

	TreeNode Find(TreeNode root, TreeNode target){
		if(root == null) return null;

		if(root.left == target || root.right == target) result = root;

		Find(root.left, target);
		Find(root.right, target);

		return null;
	}
}
