using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPipes : MonoBehaviour
{
    public Transform[] pos;
    LineRenderer line;
    void Awake()
    {
        line = GetComponent<LineRenderer>(); 
        pos = GetComponentsInChildren<Transform>();
        line.positionCount = pos.Length;
        for(int i =0 ; i < pos.Length; i ++){ 
            line.SetPosition(i, pos[i].transform.position);
        }
    }


}
