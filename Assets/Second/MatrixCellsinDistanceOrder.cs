using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MatrixCellsinDistanceOrder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	Matrix Cells in Distance Order

	解这道题用了大概19分钟，题意一开始就读懂了，然后思路卡在了如何在计算出所有的Cell后，将他们按照距离顺序依次添加到结果中
	最后想出的方法是，将所有长度都存在一个dictionary中，但是dictionary是无序的，本题中最大距离是200，所以最后在循环中依次
	遍历出每个长度的Cell，然后返回

	在看Discuss的解法后，其中使用的方法是在创建Cell这个数组的时候，多加一位，在这一位中保存这个Cell的距离，最后用这一位进行排序，
	排序完成后将数组中的值在复制出来返回。

	Discuss使用的技巧就是多用一位数组，保存这个值来为后面比较
	 */
	public int[][] AllCellsDistOrder(int R, int C, int r0, int c0) {
        Dictionary<int, List<int[]>> result = new Dictionary<int, List<int[]>>();
        
        for(int i = 0; i < R; i++){
            for(int j = 0; j < C; j++){
                int length = Math.Abs(r0 - i) + Math.Abs(c0 - j);
                if(result.ContainsKey(length)){
                    result[length].Add(new int[]{i, j});
                }else{
                    List<int[]> list = new List<int[]>(){new int[]{i, j}};
                    result.Add(length, list);
                }
            }
        }
        
        List<int[]> resultList = new List<int[]>();
        for(int i = 0; i <= 201; i++){
            if(result.ContainsKey(i)){
                foreach(int[] temp in result[i]){
                    resultList.Add(temp);
                }
            }
        }
        
        return resultList.ToArray();
    }

	/**
	Discuss solution
	 */
	public int[][] AllCellsDistOrder_Discuss(int R, int C, int r0, int c0){
		int[][] cells = new int[R * C][];
		int index = 0;
		for(int i = 0; i < R; i++){
			for(int j = 0; j < C; j++){
				int length = Math.Abs(r0 - i) + Math.Abs(c0 - j);
				cells[index++] = new int[]{i, j, length};
			}
		}

		Array.Sort(cells, (a, b) =>{
			return a[2] - b[2];
		});

		int[][] result = new int[R * C][];
		for(int i = 0; i < cells.Length; i++){
			result[i] = new int[]{cells[i][0], cells[i][1]};
		}

		return result;
	}
}
