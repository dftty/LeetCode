using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathInZigzagLabelledBinaryTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PathInZigZagTree(14));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    https://leetcode.com/problems/path-in-zigzag-labelled-binary-tree/

    首先计算出行数
     */
    public IList<int> PathInZigZagTree(int label) {
        int row = 0;
        int count = 1;
        while(count <= label){
            count <<= 1;
            row++;
        }
        
        row--;
        List<int> path = new List<int>();
        path.Add(label);
        while (row > 0) {
            int position;

            if (row % 2 == 0)
                position = label - (1 << row);
            else
                position = 2 * (1 << row) - 1 - label;

            position /= 2;
            row--;

            if (row % 2 == 0)
                label = (1 << row) + position;
            else
                label = 2 * (1 << row) - 1 - position;

            path.Add(label);
        }
        path.Reverse();
        return path;
    }
}
