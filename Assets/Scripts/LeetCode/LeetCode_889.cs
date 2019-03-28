using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeetCode_889 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public TreeNode ConstructFromPrePost(int[] pre, int[] post) {
        List<TreeNode> list = new List<TreeNode>();

		list.Add(new TreeNode(pre[0]));

		for(int i = 1, j = 0; i < pre.Length; i++){
			TreeNode node = new TreeNode(pre[i]);
			while(list[list.Count - 1].val == post[j]){
				list.RemoveAt(list.Count - 1);
				j++;
			}
			if(list.Count == 0) continue;
			if(list[list.Count - 1].left == null) list[list.Count - 1].left = node;
			else list[list.Count - 1].right = node;
			list.Add(node);
		}

		return list[0];
    }
}
