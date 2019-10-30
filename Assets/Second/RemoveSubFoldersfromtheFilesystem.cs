using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RemoveSubFoldersfromtheFilesystem : MonoBehaviour
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
    https://leetcode.com/problems/remove-sub-folders-from-the-filesystem/

    将数组进行排序
     */
    public IList<string> RemoveSubfolders(string[] folder) {
        Array.Sort(folder);
        
        IList<string> res = new List<string>();
        res.Add(folder[0]);
        
        for (int i = 1; i < folder.Length; i++){
            if (folder[i].StartsWith(res[res.Count - 1])){
                string[] temp1 = res[res.Count - 1].Split('/');
                string[] temp2 = folder[i].Split('/');
                bool has = true;
                for (int j = 0; j < temp1.Length; j++){
                    if (temp1[j] != temp2[j]){
                        has = false;
                    }
                }
                
                if (has)
                    continue;
            }
            
            res.Add(folder[i]);
        }
        return res;
    }
}
