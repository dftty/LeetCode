using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueensThatCanAttacktheKing : MonoBehaviour
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
    https://leetcode.com/problems/queens-that-can-attack-the-king/

    使用数组定义好8个方向，然后遍历
     */
    public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) {
        int[][] dir = new int[8][];
        
        dir[0] = new int[2]{-1, 0};
        dir[1] = new int[2]{-1, -1};
        dir[2] = new int[2]{0, -1};
        dir[3] = new int[2]{1, -1};
        dir[4] = new int[2]{1, 0};
        dir[5] = new int[2]{1, 1};
        dir[6] = new int[2]{0, 1};
        dir[7] = new int[2]{-1, 1};
        
        bool[] has = new bool[8];
        
        HashSet<KeyValuePair<int, int>> hashSet = new HashSet<KeyValuePair<int, int>>();
        for (int i = 0; i < queens.Length; i++){
            hashSet.Add(new KeyValuePair<int, int>(queens[i][0], queens[i][1]));
        }
        
        IList<IList<int>> res = new List<IList<int>>();
        for (int i = 1; i <= 8; i++){
            for (int j = 0; j < dir.Length; j++){
                int x = dir[j][0] * i + king[0];
                int y = dir[j][1] * i + king[1];
                
                if (!has[j] && hashSet.Contains(new KeyValuePair<int, int>(x, y))){
                    has[j] = true;
                    IList<int> list = new List<int>(){x, y};
                    res.Add(list);
                }
            }
        }
        
        return res;
    }
}
