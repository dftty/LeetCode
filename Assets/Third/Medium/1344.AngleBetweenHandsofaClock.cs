using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Third
{
    
    public class AngleBetweenHandsofaClock : MonoBehaviour
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
        https://leetcode.com/problems/angle-between-hands-of-a-clock/
        Medium
        Tag: 数学

        Discuss思路：分别计算分针和时针从12开始顺时针走过的角度，然后计算出它俩差的绝对值，
        如果小于180度就是答案，如果大于180度，那么答案就是360减去差值。

        */
        public double AngleClock(int h, int m) {
            double hour = h * 30 + (double)m / 2;
            double min = m * 6;
            double diff = Math.Abs(hour - min);
            
            if (diff < 180){
                return diff;
            }
            
            return 360 - diff;
        }
    }

}