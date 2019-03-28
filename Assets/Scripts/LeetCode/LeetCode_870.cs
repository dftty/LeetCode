using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_870 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] result = AdvantageCount(new int[]{28,47,45,8,2,10,25,35,43,37,33,30,33,20,33,42,43,36,34,3,16,23,15,10,19,42,13,47,0,21,36,38,0,5,3,28,4,20,14,5,19,22,29,17,3,16,35,0,26,0}, new int[]{44,10,27,4,27,40,46,40,45,0,41,2,44,50,36,30,37,4,44,4,12,13,35,20,19,25,38,42,43,14,2,4,5,38,4,38,0,35,12,32,38,33,3,1,19,46,23,13,24,41});
	
        int[] first = new int[]{44,10,27,4 ,27,40,46,40,45,0,41,2,44,50,36,30,37,4 ,44,4 ,12,13,35,20,19,25,38,42,43,14,2,4 ,5 ,38,4 ,38,0,35,12,32,38,33,3,1 ,19,46,23,13,24,41};
        int[] second = new int[]{45,13,28,5 ,28,42,47,42,47,2,43,3,0 ,0 ,0 ,33,38,5 ,0 ,8 ,14,15,36,21,20,26,43,22,23,16,3,10,10,30,16,33,3,36,17,33,35,34,4,19,20,35,25,19,29,37};
        int[] thrid = new int[]{35,15,29,13,28,47,35,45,33,3,47,4,30,23,37,33,38,10,22,10,16,19,36,21,20,28,43,0 ,0 ,19,3,8 ,14,43,5 ,42,2,36,16,33,42,34,5,3 ,20,0 ,25,17,26,0};
        Debug.Log(first.Length);
        for(int i = 0;  i< first.Length; i++){
            if(result[i] - first[i] > 0) Debug.Log("1");
            if(thrid[i] - first[i] > 0) Debug.Log("2");
        }
    }
    // 44,50,36,44,42,43,38,38,38,46,41
    // 0 ,0 ,0 ,0 ,22,23,30,33,35,35,37
    


	// 44,10,27,4 ,27,40,46,40,45,0,41,2,44,50,36,30,37,4 ,44,4 ,12,13,35,20,19,25,38,42,43,14,2,4 ,5 ,38,4 ,38,0,35,12,32,38,33,3,1 ,19,46,23,13,24,41
    // 45,13,28,5 ,28,42,47,42,47,2,43,3,0 ,0 ,0 ,33,38,5 ,0 ,8 ,14,15,36,21,20,26,43,22,23,16,3,10,10,30,16,33,3,36,17,33,35,34,4,19,20,35,25,19,29,37
    // 35,15,29,13,28,47,35,45,33,3,47,4,30,23,37,33,38,10,22,10,16,19,36,21,20,28,43,0 ,0 ,19,3,8 ,14,43,5 ,42,2,36,16,33,42,34,5,3 ,20,0 ,25,17,26,0
	// Update is called once per frame
	void Update () {
		
	}

    // Medium https://leetcode.com/problems/advantage-shuffle/description/
    // 2018/7/16
    // 先将A数组排序，然后遍历B数组，在A用二分查找寻找合适的数
    public int[] AdvantageCount(int[] A, int[] B) {
        int[] result = new int[A.Length];
        bool[] isUse = new bool[A.Length];
        List<int> list_A = new List<int>(A);
        list_A.Sort();
        for(int i = 0; i < B.Length; i++){
            int temp = FindMin(list_A, B[i]);
            if(temp != int.MinValue){
                isUse[i] = true;
                result[i] = temp;
            }
        }

        for(int i = 0; i < isUse.Length; i++){
            if(isUse[i] == false){
                result[i] = list_A[0];
                list_A.RemoveAt(0);
            }
        }

        return result;
    }

    public int FindMin(List<int> list, int target){
        int lo = 0;
        int hi = list.Count - 1;
        int result = 0;
        if(list[0] > target){
            result = list[0];
            list.RemoveAt(0);
            return result;
        }

        while(lo <= hi){
            
            int middle = (lo + hi) / 2;
            if(middle + 1 < list.Count && list[middle] <= target && list[middle + 1] > target){
                result = list[middle + 1];
                list.RemoveAt(middle + 1);
                return result;
            }else if(middle - 1 >= 0 && list[middle] > target && list[middle - 1] <= target){
                result = list[middle];
                list.RemoveAt(middle);
                return result;
            }else if(list[middle] <= target){
                lo = middle + 1;
            }else{
                hi = middle - 1;
            }
        }

        return int.MinValue;
    }

    // 第一名解法
    // 对于b数组，创建一个新的二维数组，存储b的值和下标，然后对b的值进行排序
    public int[] advantageCount(int[] a, int[] b) {
        int n = a.Length;
        int[][] bi = new int[n][];
        for(int i = 0;i < n;i++){
            bi[i] = new int[]{b[i], i};
        }
        Array.Sort(bi, (x, y) => x[0] - y[0]);
        Array.Sort(a);
        int p = 0;
        int[] ra = new int[n];
        for(int i = 0; i < ra.Length; i++) ra[i] = -1;
        bool[] used = new bool[n];
        for(int i = 0;i < n;i++){
            while(p < n && a[p] <= bi[i][0]){
                p++;
            }
            if(p < n){
                ra[bi[i][1]] = a[p];
                used[p] = true;
                p++;
            }
        }
        int q = 0;
        for(int i = 0;i < n;i++){
            if(!used[i]){
                while(q < n && ra[q] != -1)q++;
                if(q < n)
                ra[q] = a[i];
            }
        }
        return ra;
	}
    
    
}
