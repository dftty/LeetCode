using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**

https://www.geeksforgeeks.org/segment-tree-set-1-range-minimum-query/
线段树问题
解法为用数组来保存线段树
 */
public class SegmentTreeMin{

	/**
	这是构建线段树的代码
	 */
	int[] st;

	public SegmentTreeMin(int[] arr, int n){
		int len = (int)Math.Ceiling(Math.Log(2, n));
		st = new int[ 2 * (int)Math.Pow(2, len) - 1];


	}

	public int generateSegTree(int ss, int se, int[] arr, int si){
		if(ss == se){
			st[si] = arr[ss];
			return st[si];
		}

		int mid = (ss + se) / 2;

		// 该数可以根据要求做改变
		st[si] = Math.Min(generateSegTree(ss, mid, arr, 2 * si + 1),
					generateSegTree(mid + 1, se, arr, 2 * si + 2));
		

		return st[si];
	}

	public int query(int ss, int se, int qs, int qe, int si){
		if(ss >= qs && qe >= se){
			return st[si];
		}

		if(qs > se || qe < ss){
			return Int32.MaxValue;
		}

		int mid = (ss + se) / 2;

		return Math.Min(query(ss, mid, qs, qe, 2 * si + 1), query(mid + 1, se, qs, qe, 2 * si + 2));
	}

	





	

}
