using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Test : MonoBehaviour {

    public GameObject obj;

    public delegate T HandleTest<out T>();

    /// <summary>
    /// 代理和事件
    /// </summary>
    private event HandleTest<int> handle;

    public event HandleTest<int> Handle
    {
        add
        {
            handle += value;
        }
        remove
        {
            handle -= value;
        }
    }



	// Use this for initialization
	void Start () {
		IsRobotBounded("GL");
		List<int> list = new List<int>();

        int[,] temp = new int[2, 2]{{5, 2}, {3, 4}};

        Debug.Log(temp);

        Debug.Log(int.MinValue);

        handle += GetInt;

        Pair pair = new Pair(1, 1);
        Dictionary<Pair, int> dic = new Dictionary<Pair, int>();
        dic.Add(pair, 0);

        Debug.Log(dic.ContainsKey(new Pair(1, 1)));

        // KeyValuePair<int, int> pair = new KeyValuePair<int, int>(1, 1);
        // Dictionary<KeyValuePair<int, int>, int> dic = new Dictionary<KeyValuePair<int, int>, int>();
        // dic.Add(pair, 0);
        // Debug.Log(dic.ContainsKey(new KeyValuePair<int, int>(1, 1)));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 vector = new Vector3();
            transform.RotateAround(new Vector3(vector.x + 0.5f, vector.y - 0.5f, vector.z), new Vector3(0, 0, 0.5f), -90);
            //obj.transform.position = new Vector3(vector.x + 0.5f, vector.y - 0.5f, vector.z);
        }
	}

    public int GetInt()
    {
        return 0;
    }

    public bool IsRobotBounded(string instructions) {
        int[][] dirs = new int[4][]{new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 0}};
        
        int curDir = 0;
        int[] startPosition = new int[2]{0, 0};
        for(int i = 0; i < 4; i++){
            for(int j = 0; j < instructions.Length; j++){
                if(instructions[j] == 'G'){
                    startPosition[0] += dirs[curDir][0];
                    startPosition[1] += dirs[curDir][1];
                }else if(instructions[j] == 'L'){
                    curDir += 1;
                    curDir = curDir % 4;
                }else{
                    curDir -= 1;
                    curDir = curDir < 0 ? 3 : curDir;
                }
            }
            
            if(startPosition[0] == 0 && startPosition[1] == 0){
                return true;
            }
        }
        
        return false;
    }

	public string ReverseParentheses(string s) {
        StringBuilder res = new StringBuilder();
        Stack<char> stack = new Stack<char>();
        List<StringBuilder> list = new List<StringBuilder>();
        list.Add(new StringBuilder(""));
        foreach (char c in s){
            if (stack.Count == 0 && c == '('){
                stack.Push(c);
                list.Add(new StringBuilder(""));
            }else if (stack.Count > 0 && c == ')'){
                char[] arr = list[list.Count - 1].ToString().ToCharArray();
                Array.Reverse(arr);
                list[list.Count - 2].Append(new string(arr));
                list.RemoveAt(list.Count - 1);
                stack.Pop();
            }else {
                list[list.Count - 1].Append(c);
            }
        }
        
        foreach(StringBuilder sbStr in list){
            res.Append(sbStr);
        }
        
        return res.ToString();
    }

	public IList<bool> CamelMatch(string[] queries, string pattern) {
        IList<bool> result = new List<bool>();
        
        for(int i = 0; i < queries.Length; i++){
            int first = 0;
            int second = 0;
            string temp = queries[i];
            while(first < temp.Length && second < pattern.Length){
                if(temp[first++] == pattern[second++]) continue;
                else if(temp[first] >= 'a' && temp[first] <= 'z'){
                    first++;
                }else{
                    break;
                }
            }
            
            while(first < temp.Length && temp[first] >= 'a' && temp[first] <= 'z'){
                first++;
            }
            
            if(first == temp.Length && second == pattern.Length){
                result.Add(true);
            }else{
                result.Add(false);
            }
        }
        
        return result;
    }
}
