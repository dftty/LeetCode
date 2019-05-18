using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LargestRectangleinHistogram : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LargestRectangleArea(new int[]{2, 4});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Stack解法，时间复杂度为O(n)
	 */
	public int LargestRectangleArea_(int[] heights) {
        if(heights == null || heights.Length == 0) return 0;
        Stack<int> stack = new Stack<int>();
        
        int tp = 0;
        int i = 0;
        int max_area = 0;
        
        while(i < heights.Length){
            if(stack.Count == 0 || heights[i] > heights[stack.Peek()]){
                stack.Push(i++);
            }else{
                tp = heights[stack.Pop()];
                
                max_area = Math.Max(max_area, tp * (stack.Count == 0 ? i : i - stack.Peek() - 1));
            }
            
        }
        
        while(stack.Count > 0){
            tp = heights[stack.Pop()];
            max_area = Math.Max(max_area, tp * (stack.Count == 0 ? i : i - stack.Peek() - 1));
        }
        
        return max_area;
    }

	/**
	线段树解法，时间复杂度O(nlogn)
	这里线段树中其实可以保存最小值的下标即可,可以从heights数组中直接由下标获取值
	 */
	SegmentTreeMin st = null;

	public int LargestRectangleArea(int[] heights) {
        st = new SegmentTreeMin(heights, heights.Length);

		return MaxBar(0, heights.Length - 1, heights.Length - 1);
    }

	public int MaxBar(int start, int end, int se){
		// 这里如果start小于end 的情况下，直接返回0， 不可以调用查询
		if(start == end){
			return st.query(0, se, start, start, 0)[0];
		}else if(start > end){
			return int.MinValue;
		}

		int[] min = st.query(0, se, start, end, 0);
		int leftMax = MaxBar(start, min[1] - 1, se);
		int rightMax = MaxBar(min[1] + 1, end, se);

		return Math.Max(leftMax, Math.Max(min[0] * (end - start + 1), rightMax));
	}

	class SegmentTreeMin{

		/**
		这是构建线段树的代码
		每个节点中保存的值是当前线段中的最小值和此最小值的下标
		*/
		int[][] st;

		public SegmentTreeMin(int[] arr, int n){
			int len = (int)Math.Ceiling(Math.Log(n, 2));
			st = new int[ 2 * (int)Math.Pow(2, len) - 1][];
			for(int i = 0; i < st.Length; i++){
				st[i] = new int[2];
			}
			generateSegTree(0, n - 1, arr, 0);
		}

		public int[] generateSegTree(int ss, int se, int[] arr, int si){
			if(ss == se){
				st[si][0] = arr[ss];
				st[si][1] = ss;
				return st[si];
			}

			int mid = (ss + se) / 2;

			// 该数可以根据要求做改变
			int[] left = generateSegTree(ss, mid, arr, si * 2 + 1);
			int[] right = generateSegTree(mid + 1, se, arr, si * 2 + 2);

			st[si] = left[0] < right[0] ? left : right;

			return st[si];
		}

		public int[] query(int ss, int se, int qs, int qe, int si){
			if(ss >= qs && qe >= se){
				return st[si];
			}

			if(qs > se || qe < ss){
				return new int[2]{int.MaxValue, 0};
			}

			int mid = (ss + se) / 2;
			int[] left = query(ss, mid, qs, qe, 2 * si + 1);
			int[] right = query(mid + 1, se, qs, qe, 2 * si + 2);
			

			return left[0] < right[0] ? left : right;
		}

	}
}
