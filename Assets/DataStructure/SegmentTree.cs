using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**

https://www.geeksforgeeks.org/segment-tree-set-1-sum-of-given-range/
线段树问题
解法为用数组来保存线段树
 */
public class SegmentTree{

	/**
	这是构建线段树的代码
	 */
	int[] st;

	public SegmentTree(int[] arr, int n){
		// 这里采用了对数的换底公式，相当于计算 log 以2 为底n的对数,然后向上取整
		// Math.Log(n, 2)
		int x = (int)(Math.Ceiling(Math.Log(n) / Math.Log(2)));

		int max_size = 2 * (int)Math.Pow(2, x) - 1;
		st = new int[max_size];

		constructSTUtil(arr, 0, n - 1, 0);
	}

	int getMid(int s, int e){
		return s + (e - s) / 2;
	}

	int constructSTUtil(int[] arr, int ss, int se, int si){
		if(ss == se){
			st[si] = arr[ss];
			return arr[ss];
		}

		int mid = getMid(ss, se);

		// 这里保存的值取决于算法题目的要求,本题要求区间的和
		st[si] = constructSTUtil(arr, ss, mid, si * 2 + 1) + constructSTUtil(arr, mid + 1, se, si * 2 + 2);

		return st[si];
	}

	/*
	下面是题目的解法
	 */
	int getSumUtil(int ss, int se, int qs, int qe, int si){
		if(qs <= ss && qe >= se){
			return st[si];
		}

		if(se < qs || ss > qe){
			return 0;
		}

		int mid = getMid(ss, se);
		return getSumUtil(ss, mid, qs, qe, 2 * si + 1) + getSumUtil(mid + 1, se, qs, qe, 2 * si + 2);
	}

	void updateValueUtil(int ss, int se, int i, int diff, int si){
		if(i < ss || i > se){
			return ;
		}

		st[si] = st[si] + diff;
		if(se != ss){
			int mid = getMid(ss, se);
			updateValueUtil(ss, mid, i, diff, 2 * si + 1);
			updateValueUtil(mid + 1, se, i, diff, 2 * si + 2);
		}
	}

	void updateValue(int[] arr, int n, int i, int new_val){
		if(i < 0 || i > n - 1){
			return ;
		}

		int diff = new_val - arr[i];
		arr[i] = new_val;

		updateValueUtil(0, n - 1, i, diff, 0);
	}

}
