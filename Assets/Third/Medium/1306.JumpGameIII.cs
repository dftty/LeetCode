using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Third
{

    public class JumpGameIII : MonoBehaviour
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
        https://leetcode.com/problems/jump-game-iii/
        Medium
        Tag: 广度优先搜索

        思路：根据题意可以知道，只要我们到达过某个下标，就无需再次到达这个下标，因为不论从那个节点到达这个下标，之后的操作都是一样的。
        因此可以使用一个hashset来记录已经到达的下标，
        然后我们使用队列来记录，首先start入队，然后计算左右下标，如果在数组范围内并且没有被达到过，就加入队列继续查找
        直到找到0为止。

        */
        public bool CanReach(int[] arr, int start) {
            HashSet<int> reach = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            reach.Add(start);
            while (queue.Count > 0){
                int num = queue.Dequeue();
                if (arr[num] == 0) return true;
                
                int left = num - arr[num];
                int right = num + arr[num];
                
                if (!reach.Contains(left) && left >= 0){
                    queue.Enqueue(left);
                    reach.Add(left);
                }
                
                if (!reach.Contains(right) && right < arr.Length){
                    queue.Enqueue(right);
                    reach.Add(right);
                }
            }
            
            return false;
        }
    }

}