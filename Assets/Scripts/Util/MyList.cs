using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyList<T> : IEnumerable<T>
{
    System.Object[] objs;

    // 索引器的定义
    System.Object this[int index]{
        get {
            return objs[index];
        }
        set{
            objs[index] = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        List<int> list = new List<int>();
        int temp = list.Capacity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IEnumerable.GetEnumerator(){
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator(){
        return null;
    }
}
