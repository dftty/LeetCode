using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DataStruct{
	public class TreeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TreeNode roots = new TreeNode();
		roots.num = 6;
		TreeNode first = new TreeNode();
		TreeNode sec = new TreeNode();
		TreeNode thi = new TreeNode();
		TreeNode four = new TreeNode();
		TreeNode five = new TreeNode();

		first.num = 1;
		sec.num = 2;
		thi.num = 3;
		four.num = 4;
		five.num = 8;

		roots.left = sec;
		sec.left = first;
		sec.right = four;
		four.left = thi;
		roots.right = five;

		PostOrder(roots);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PreOrder(TreeNode roots){
		Debug.Log(roots.num);

		if(roots.left != null) PreOrder(roots.left);
		if(roots.right != null) PreOrder(roots.right);
	}

	void InOrder(TreeNode roots){
		if(roots.left != null) InOrder(roots.left);
		Debug.Log(roots.num);
		if(roots.right != null) InOrder(roots.right);
	}

	void PostOrder(TreeNode roots){
		if(roots.left != null) PostOrder(roots.left);
		if(roots.right != null) PostOrder(roots.right);
		Debug.Log(roots.num);
	}
}

class TreeNode{
	public int num;
	public TreeNode left;
	public TreeNode right;
}
}

