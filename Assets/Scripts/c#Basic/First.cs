using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First
{
    
    const string LENGTH = "length";

    static string HEIGHT = "height";

    const int len = 10;

    First(){
        #pragma warning disable 
        const int len = 0;
    }

    void Test(){
        Debug.Log(len);
    }

}
