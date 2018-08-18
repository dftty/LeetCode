using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conteest_814 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TreeNode first = new TreeNode(1);
		TreeNode sec = new TreeNode(0);
		TreeNode thr = new TreeNode(0);
		TreeNode four = new TreeNode(1);

		first.right = sec;
		sec.left = thr;
		sec.right = four;

		PruneTree(first);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public TreeNode PruneTree(TreeNode root) {
        Set(root);
		return root;
    }

	// Medium
	// 如果 leftchild为root的左节点， leftchild = null 这句代码是不会让 root.left 为空的，必须直接设置root.left = null
	void Set(TreeNode root){
		if(root == null) return ;

		if(root.left != null) Set(root.left);
		if(root.right != null) Set(root.right);

		if(root.left != null && root.left.val == -1){
			root.left = null;
		}

		if(root.right != null && root.right.val == -1){
			root.right = null;
		}

		if(root.val == 0 && root.left == null && root.right == null){
			root.val = -1;
		}
	}
}
