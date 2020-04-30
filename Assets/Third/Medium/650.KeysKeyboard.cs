using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{

	public class KeysKeyboard : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
        
		}

		/**
		https://leetcode.com/problems/2-keys-keyboard/
		Tag:动态规划

		思路：使用深度优先搜索解决，遍历所有可能的选择。

			 */
		public int MinSteps(int n)
		{
			return Min(1, 0, n);
		}

		int Min(int n, int lastCopyCount, int end)
		{
			if (n == end)
			{
				return 0;
			}

			if (n > end)
			{
				return 1 << 11;
			}

			int res = int.MaxValue;
			if (lastCopyCount != 0)
			{
				res = Math.Min(res, Min(n + lastCopyCount, lastCopyCount, end) + 1);
				res = Math.Min(res, Min(n * 2, n, end) + 2);
			}
			else
			{
				res = Math.Min(res, Min(n + n, n, end) + 2);
			}

			return res;
		}
	}

}