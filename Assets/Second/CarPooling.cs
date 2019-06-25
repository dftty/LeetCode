using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarPooling : MonoBehaviour
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
    https://leetcode.com/problems/car-pooling/

    使用上车时间进行排序，然后遍历数组，
    使用一个list保存已经遍历过的数组，其中保存遍历数组的下标和下车时间，每次遍历中判断当前的开始时间是否超过了已经
    遍历过的下车时间，如果已经超过，则让乘客下车，并且在list中删除
     */
    public bool CarPooling_(int[][] trips, int capacity) {
        Array.Sort(trips, (a, b) => {
            return a[1] - b[1];
        });
        
        List<int[]> list = new List<int[]>();
        int currentCap = 0;
        for(int i = 0; i < trips.Length; i++){
            if(list.Count == 0){
                currentCap += trips[i][0];
                list.Add(new int[]{i, trips[i][2]});
                if(currentCap > capacity){
                    return false;
                }
                continue;
            }
            
            List<int[]> removeList = new List<int[]>();
            for(int j = 0; j < list.Count; j++){
                if(trips[i][1] >= list[j][1]){
                    currentCap -= trips[list[j][0]][0];
                    removeList.Add(list[j]);
                }
            }
            
            for(int j = 0; j < removeList.Count; j++){
                list.Remove(removeList[j]);
            }
            
            currentCap += trips[i][0];
            list.Add(new int[]{i, trips[i][2]});
            if(currentCap > capacity){
                return false;
            }
        }
        return true;
    }

    /**
    将上车下车时间和乘客放入一个list中，然后进行排序
     */
    public bool CarPooling_Discuss(int[][] trips, int capacity) {
        List<int[]> events = new List<int[]>();

        for(int i = 0; i < trips.Length; i++){
            events.Add(new int[]{trips[i][1], trips[i][0]});
            events.Add(new int[]{trips[i][2], -trips[i][0]});
        }

        int[][] arrays = events.ToArray();

        Array.Sort(arrays);

        events.Sort((a, b) =>{
            int first = a[0] - b[0];
            if(first != 0){
                return first;
            }
            return a[1] - b[1];
        });
        int people = 0;
        for(int i = 0; i < events.Count; i++){
            people += events[i][1];
            Console.WriteLine(people);
            if(people > capacity){
                return false;
            }
        }

        return true;
    }
}
