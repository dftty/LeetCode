using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapacityToShipPackagesWithinDDays : MonoBehaviour {


    /**
    Capacity To Ship Packages Within D Days

    A conveyor belt has packages that must be shipped from one port to another within D days.

    The i-th package on the conveyor belt has a weight of weights[i].  Each day, we load the ship with packages on the conveyor belt (in the order given by weights). We may not load more weight than the maximum weight capacity of the ship.

    Return the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within D days.

    思考一个小时没有想法，看了标签之后发现有一个Binary Search，但是看数组怎么也联系不到二分查找上去。
    最后一看答案，原来是用二分查找来查找目标的值。这个目标值并不是在原数组里查找，而是自己将上下限计算出来之后，
    在这个范围内进行二分查找。

    因为查找的是最小值，因此左边界每次改变的时候递增1，不可以赋值为mid。
     */
    public int ShipWithinDays(int[] weights, int D) {
        int left = 0;
        int right = 0;
        
        for(int i = 0; i < weights.Length; i++){
            left = Math.Max(left, weights[i]);
            right += weights[i];
        }

        while(left < right){
            int need = 1;
            int count = 0;

            int mid = (left + right) / 2;
            for(int i = 0; i < weights.Length; i++){
                if(count + weights[i] > mid){
                    need += 1;
                    count = 0;
                }
                count += weights[i];
            }

            if(need > D) left += 1;
            else right = mid;
        }

        return left;
    }

}
