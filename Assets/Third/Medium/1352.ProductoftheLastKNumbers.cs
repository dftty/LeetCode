using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class ProductoftheLastKNumbers : MonoBehaviour
    {
        
        /**
        https://leetcode.com/problems/product-of-the-last-k-numbers/
        Medium
        Tag: 数组

        思路：类似于前缀和，可以保存前缀积，只不过当添加的数字为0时，就需要将
        前缀积中所有非0的值设为0

        */
        public class ProductOfNumbers {
        
            List<int> nums;
            List<int> products;

            public ProductOfNumbers() {
                nums = new List<int>();
                products = new List<int>();
                products.Add(1);
            }
            
            public void Add(int num) {
                nums.Add(num);
                
                if (num == 0){
                    for (int i = products.Count - 1; i >= 0; i--){
                        if (products[i] == 0){
                            break;
                        }
                        
                        products[i] = 0;
                    }
                }
                
                int product = num * products[products.Count - 1] == 0 ? num : num * products[products.Count - 1];
                products.Add(product);
            }
            
            public int GetProduct(int k) {
                
                int index = nums.Count - k;
                if (products[index] == 0 && products[index + 1] != 0){
                    return products[products.Count - 1];
                }else if (products[index] == 0){
                    return 0;
                }
                
                return products[products.Count - 1] / products[index];
            }
        }


    }

}