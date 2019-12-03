using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class NumberofBurgerswithNoWasteofIngredients : MonoBehaviour
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
        https://leetcode.com/problems/number-of-burgers-with-no-waste-of-ingredients/
        Medium 
        Tag: Math Greddy

        思路：可以将题目转化为二元一次方程组
        假设有x个J汉堡，y个S汉堡，那么
        4x + 2y = ts
        x + y = cs

        计算这个方程即可拿到答案
        */
        public IList<int> NumOfBurgers(int ts, int cs) {
            int remain = ts - (cs * 2);
            if (remain >= 0 && remain % 2 == 0){
                int x = (ts - (cs * 2)) / 2;
                if (x > cs) return new List<int>();
                return new List<int>(){x, cs - x};
            }
            
            return new List<int>();
        }

        /**
        Discuss 解法

        思路：类似于古代的鸡兔同笼问题，采用抬腿法解决

        本题中，只需要保证ts的数量为偶数，ts的数量不会超过左右边界即可

        */
        public IList<int> NumOfBurgers_Discuss(int ts, int cs){
            if (ts % 2 == 0 && ts >= cs * 2 && cs >= ts / 4){
                return new List<int>(){(ts - cs * 2) / 2, 2 * cs - ts / 2};
            }

            return new List<int>();
        }
    }

}