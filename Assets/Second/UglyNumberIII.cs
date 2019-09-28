using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UglyNumberIII : MonoBehaviour
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
    https://leetcode.com/problems/ugly-number-iii/

    注意： 该题遇到两个int值计算溢出的情况，
    第一：  a，b，c三个数中如果非常大，那么计算其中两个数相乘会导致溢出
    第二： 计算二分范围时，采用(lo + hi) / 2的方式计算也会导致溢出。
     */
    public int NthUglyNumber(int n, int a, int b, int c) {
        long ab = (long)a * (long)b / gcd(a, b);
        long ac = (long)a * (long)c / gcd(a, c);
        long bc = (long)b * (long)c / gcd(b, c);
        long abc = (long)a * bc / gcd(a, bc);
        
        long lo = 0, hi = 2 * 1000000000;
        
        while (lo < hi){
            long mid = (lo + hi) / 2;
            long count = mid / a + mid / b + mid / c - mid / ab - mid / ac - mid / bc + mid / abc;
            
            if (count < n){
                lo = mid + 1;
            }else{
                hi = mid;
            }
        }
        
        return (int)lo;
    }
    
    public long gcd(long a, long b){
        if (a % b == 0){
            return b;
        }else{
            return gcd(b, a % b);
        }
    }
}
