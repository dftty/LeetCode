using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class UniquePaths : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StringBuilder sb = new StringBuilder();
		sb.Append("abcdefg".ToCharArray());
		sb.Remove(3, sb.Length - 3);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Unique Paths

	DP 问题
	分解为子问题如下：
	result[i, j] = result[i - 1, j] + result[i, j - 1];

	这个方法需要O(m * n) 空间
	 */
	public int UniquePaths_(int m, int n) {
        int[,] result = new int[m,n];
        result[0, 0] = 1;
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(i == 0 || j == 0){
					result[ i, j] = 1;
				}
				else{
                	result[i, j] = result[i - 1, j] + result[i, j - 1];
				}
            }
        }
        
        return result[m - 1, n - 1];
    }

	/**
	在 discuss中，提出了其实只需要使用O(n) 空间就可以实现
	在每次求解子问题的时候，其实我们每次只用当前的空间，而不需要已经走过的空间，
	因此可以重复利用当前空间
	 */
	public int UniquePaths_Discuss(int m, int n){
		int[] col = new int[n];
		for(int i = 0; i < col.Length; i++){
			col[i] = 1;
		}

		for(int i = 1; i < m; i++){
			for(int j = 1; j < n; j++){
				col[j] += col[j - 1];
			}
		}

		return col[n - 1];
	}
}
